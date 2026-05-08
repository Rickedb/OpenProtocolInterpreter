# GitHub Copilot Instructions — OpenProtocolInterpreter

## Project Overview

**OpenProtocolInterpreter** is a zero-dependency .NET library that bidirectionally serializes/deserializes Atlas Copco Open Protocol MID messages (fixed-width ASCII) to typed C# objects and back.  
NuGet package: `OpenProtocolInterpreter` · Version: `6.1.1`  
Multi-targeted: `netstandard2.0; net6.0; net8.0; net10.0`

---

## Repository Layout

```
src/
  OpenProtocolInterpreter/   ← main library
    _internals/              ← infrastructure (MessagesTemplate, MidCompiledInstance)
    Enums/                   ← all shared enums (~50 files)
    {Category}/              ← one folder per MID domain (Alarm, Tightening, Job, …)
      I{Category}.cs         ← empty marker interface
      {Category}Messages.cs  ← internal MID registry for the category
      Mid{NNNN}.cs           ← one file per MID number
    MID.cs                   ← abstract base class
    Header.cs                ← 20-char header model
    DataField.cs             ← single field descriptor
    OpenProtocolConvert.cs   ← all type-conversion utilities
    MidInterpreter.cs        ← public entry point
    MidInterpreterMessagesExtensions.cs  ← fluent registration API
  MIDTesters.Core/           ← MSTest test project (net10.0)
sample/                      ← WinForms sample driver (not part of the library)
docs/                        ← vendor protocol specs (Atlas Copco, Desoutter)
```

---

## Core Abstractions

### Header (20 chars, always present)
| Position | Field | Width |
|---|---|---|
| 0–3 | Length | 4 |
| 4–7 | Mid | 4 |
| 8–10 | Revision | 3 |
| 11 | NoAckFlag | 1 |
| 12–13 | StationId | 2 |
| 14–15 | SpindleId | 2 |
| 16–17 | SequenceNumber | 2 |
| 18 | NumberOfMessages | 1 |
| 19 | MessageNumber | 1 |

### DataField
Describes one field within a MID. Key members: `Field` (enum hash), `Index` (absolute offset from byte 0), `Size`, `HasPrefix`, `Value`.  
Use factory statics — **never call the constructor directly**:
- `DataField.String(field, index, size)` — space-padded
- `DataField.Number(field, index, size)` — zero-padded
- `DataField.Boolean(field, index)` — size 1
- `DataField.Timestamp(field, index)` — size 19, format `yyyy-MM-dd:HH:mm:ss`
- `DataField.Volatile(field, index)` — variable-length

### OpenProtocolConvert
The **only** permitted conversion utility. Never use `int.Parse`, `DateTime.Parse`, etc. in MID code.  
Key pairs: `ToBoolean`/`ToString(bool)`, `ToDateTime`/`ToString(DateTime)`, `ToDecimal`/`ToString(decimal)`, `ToInt32`, `ToInt64`, `TruncatedDecimalToString`/`ToTruncatedDecimal`, `TruncatePadded`, `GetBit`/`ToByte`.

---

## MID Class Conventions (mandatory)

Every concrete MID **must** follow this exact pattern:

```csharp
// Namespace: OpenProtocolInterpreter.{Category}
public class Mid0071 : Mid, IAlarm, IController, IAcknowledgeable<Mid0072>
{
    public const int MID = 71; // always present

    // --- Properties ---
    // Simple string / bool
    public string ErrorCode
    {
        get => GetField(1, DataFields.ErrorCode).Value;
        set => GetField(1, DataFields.ErrorCode).SetValue(value);
    }
    // Typed (non-string) — use OpenProtocolConvert
    public bool ControllerReadyStatus
    {
        get => GetField(1, DataFields.ControllerReadyStatus).GetValue(OpenProtocolConvert.ToBoolean);
        set => GetField(1, DataFields.ControllerReadyStatus).SetValue(OpenProtocolConvert.ToString, value);
    }

    // --- Constructors (all three required, enforced by tests) ---
    public Mid0071() : this(DEFAULT_REVISION) { }
    public Mid0071(Header header) : base(header) { HandleRevision(); }
    public Mid0071(int revision) : this(new Header() { Revision = revision, Mid = MID }) { }

    // --- Parse override (only when HandleRevision must run before ProcessDataFields) ---
    public override Mid Parse(string package)
    {
        Header = ProcessHeader(package);
        HandleRevision();
        ProcessDataFields(package);
        return this;
    }

    // --- Field declarations per revision ---
    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
        return new Dictionary<int, List<DataField>>()
        {
            {
                1, new List<DataField>()
                {
                    DataField.String(DataFields.ErrorCode, 20, 4, PaddingOrientation.LeftPadded),
                    DataField.Boolean(DataFields.ControllerReadyStatus, 26),
                    DataField.Boolean(DataFields.ToolReadyStatus, 29),
                    DataField.Timestamp(DataFields.Time, 32)
                }
            },
            {
                2, new List<DataField>() { DataField.String(DataFields.AlarmText, 54, 50) }
            }
        };
    }

    // --- Field identity enum (private or protected, nested inside the class) ---
    protected enum DataFields { ErrorCode, ControllerReadyStatus, ToolReadyStatus, Time, AlarmText }
}
```

**Rules:**
1. Class name: `Mid{NNNN}` with 4-digit zero-padded number.
2. Three required constructors (parameterless, `(Header)`, `(int revision)`) — validated by `DefaultMidTests<T>`.
3. `const int MID = N` must be present.
4. `DataFields` enum is **nested and private/protected** — never a public top-level enum.
5. `RegisterDatafields()` keys are **1-based revision numbers**.
6. Index values in `RegisterDatafields()` are **absolute offsets** from position 0 of the full raw string (header occupies 0–19).
7. Use `DataField` factory methods, not constructors.
8. Property getters/setters delegate to `GetField` / `GetValue` / `SetValue` — no local parsing.
9. Apply the correct **category marker interface** (`IAlarm`, `ITightening`, etc.) and **role interface** (`IController` or `IIntegrator`).
10. Apply **behavior interfaces** as per the spec: `IAcknowledgeable<TAck>`, `IAnswerableBy<TAnswer>`, `IAcceptableCommand`, `IDeclinableCommand`, `ISubscription`, `IUnsubscription`.

---

## Adding a New Category

1. Create folder `src/OpenProtocolInterpreter/{Category}/`.
2. Add `I{Category}.cs` — empty marker interface.
3. Add `{Category}Messages.cs` — `internal class {Category}Messages : MessagesTemplate` with:
   - MID-number dictionary of `MidCompiledInstance`
   - `IsAssignableTo(int mid)` range expression
   - Three constructors (no-arg, `InterpreterMode`, `IEnumerable<Type>`)
4. Add extension method `Use{Category}Messages(...)` to `MidInterpreterMessagesExtensions.cs`.

---

## Registering a New MID in an Existing Category

In `{Category}Messages.cs`, add to the dictionary:
```csharp
{ Mid{NNNN}.MID, new MidCompiledInstance(typeof(Mid{NNNN})) }
```
Extend `IsAssignableTo` if the MID number falls outside the current range expression.

---

## MidInterpreter Usage

```csharp
// Register all categories
var interpreter = new MidInterpreter().UseAllMessages();

// Or selectively, with role filtering
var interpreter = new MidInterpreter()
    .UseAlarmMessages(InterpreterMode.Controller)
    .UseTighteningMessages(InterpreterMode.Integrator);

// Parse
Mid parsed = interpreter.Parse(rawString);              // untyped
Mid0061 typed = interpreter.Parse<Mid0061>(rawString);  // typed
```

---

## Test Conventions

Tests live in `src/MIDTesters.Core/`. Framework: **MSTest** on `net10.0`.

Hierarchy:
```
MidTester (base, creates shared MidInterpreter)
  └── DefaultMidTests<TMid>  (enforces parameterless + Header constructors)
        └── TestMid{NNNN} : DefaultMidTests<Mid{NNNN}>
```

Per-MID test pattern:
```csharp
[TestClass, TestCategory("{Category}")]
public class TestMid0071 : DefaultMidTests<Mid0071>
{
    [TestMethod, TestCategory("Revision 1"), TestCategory("ASCII")]
    public void Mid0071Revision1()
    {
        string pack = @"00530071001         01E851021031042017-12-01:20:12:45";
        var mid = _midInterpreter.Parse<Mid0071>(pack);
        Assert.AreEqual("E851", mid.ErrorCode);
        // ... assert every field
        AssertEqualPackages(pack, mid); // mandatory round-trip check
    }

    [TestMethod, TestCategory("Revision 1"), TestCategory("ByteArray")]
    public void Mid0071ByteRevision1()
    {
        string pack = @"00530071001         01E851021031042017-12-01:20:12:45";
        var mid = _midInterpreter.Parse<Mid0071>(_midInterpreter.GetAsciiBytes(pack));
        Assert.AreEqual("E851", mid.ErrorCode);
        AssertEqualPackages(pack, mid);
    }
}
```

**Rules:**
- Each revision gets its own test method.
- Each revision gets both an ASCII and a ByteArray test method.
- Test fixtures must be real wire strings taken from the vendor protocol spec.
- Always call `AssertEqualPackages` to verify round-trip fidelity.
- Add `[TestCategory("{Category}")]` matching the domain folder name.

---

## Hard Constraints

- **Zero external NuGet dependencies** in `OpenProtocolInterpreter.csproj`. Do not add any.
- **`LangVersion: latest`** — modern C# features are allowed.
- All type conversions in MID code go through `OpenProtocolConvert`. Never call `int.Parse`, `double.Parse`, `DateTime.Parse`, `Convert.ToXxx`, etc. directly.
- Do not use `Reflection` or `dynamic` outside of `_internals/`.
- Do not change `Header` parsing logic — it is shared by all MIDs.
- Field index values are absolute offsets from position 0. The header consumes positions 0–19; the first data field always starts at ≥ 20.
