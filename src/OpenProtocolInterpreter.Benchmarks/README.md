# OpenProtocolInterpreter.Benchmarks

[BenchmarkDotNet](https://benchmarkdotnet.org/) suite for the library. It is a plain console app, kept apart
from `MIDTesters.Core` on purpose: a benchmark needs an optimized, non instrumented, single process host,
which is the opposite of what a test host gives you.

## Running

```bash
# everything, full precision (several minutes)
dotnet run -c Release --project src/OpenProtocolInterpreter.Benchmarks

# one class
dotnet run -c Release --project src/OpenProtocolInterpreter.Benchmarks -- --filter '*InterpreterModeBenchmarks*'

# short job, for checking the suite still runs after a change
dotnet run -c Release --project src/OpenProtocolInterpreter.Benchmarks -- --quick

# list what is available
dotnet run -c Release --project src/OpenProtocolInterpreter.Benchmarks -- --list flat
```

`-c Release` is not optional; BenchmarkDotNet refuses to run a debug build. Everything other than `--quick`
is passed straight to BenchmarkDotNet, so its whole command line is available.

Reports land in `BenchmarkDotNet.Artifacts/results` next to the binaries, including a GitHub flavoured
markdown table that can be pasted into an issue or a pull request.

## What is measured

| Class | Question it answers |
|---|---|
| `InterpreterModeBenchmarks` | What do `InterpreterMode.Both`, `Controller` and `Integrator` cost? |
| `RegistrationBenchmarks` | Is it worth registering only the mids I use instead of `UseAllMessages()`? |
| `ParsingBenchmarks` | What does a parse cost per package width, and what does the `byte[]` overload add? |
| `PackingBenchmarks` | What does building the outgoing package cost, and what does `PackBytes` add over `Pack`? |

### Reading the interpreter mode results

Only `Register all messages` is a like for like comparison across the three modes: it is the same call with
a different argument. The parse rows cannot be, because a mid travels in one direction only, so a
`Controller` interpreter physically never receives the packages an `Integrator` one does. Each mode is
therefore benchmarked against the traffic it actually sees (`Packages.IncomingFor`), and each row should be
read on its own.

What the three columns do show is *where* a mode costs anything. Registration only wires up 24 lazy
templates and is mode independent. The mode is paid for on the first parse, when a template is materialized
and `Controller`/`Integrator` additionally filter out the mids of the opposite direction, work `Both` skips.

## Adding a benchmark

Sample packages live in `Packages.cs` and are copied from the test suite, so anything benchmarked is known
to parse. Add new ones there rather than inlining a raw string, and keep them grouped by direction
(`IController` mids are sent by the controller, `IIntegrator` mids by the integrator) so the mode benchmarks
keep working.

Benchmark bodies must not assert. An assertion measures the assertion; correctness belongs in
`MIDTesters.Core`. Where a benchmark depends on a package parsing, check it once in `[GlobalSetup]` so a
broken sample fails the run instead of quietly reporting the cost of an exception.
