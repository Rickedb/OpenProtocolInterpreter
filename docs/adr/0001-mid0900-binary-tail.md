# ADR-0001: MID 0900 binary tail via Parse(byte[]) and full per-revision layouts

**Status:** Accepted  
**Date:** 2026-09-07  
**Deciders:** OPI fork maintainers (Haller + Erne)

## Context

Open Protocol Spec R 2.21.1 §5.8.9 defines MID 0900 (Trace curve data) with an ASCII lead, a single NUL (`0x00`) separator, and a binary tail of `NumberOfSamples × 2-byte big-endian signed` values. OPI’s `DataField` model is text-oriented. Upstream and this fork previously listed 0900/0901 as unavailable for that reason.

MID 0901 (plot parameters) is ASCII-only per Tables 146–148; it does not carry the binary sample tail. It still needs the same “full layout per revision” packing rule when revisions insert fields mid-message.

## Decision

1. **No custom `DataField` subclass** for binary samples.
2. **MID 0900** overrides `Parse(byte[])` / `Pack()` / `PackBytes()` / `BuildHeader()`:
   - Parse the ASCII lead with existing field helpers.
   - Locate the NUL inside the header-declared body; copy bytes after it into `RawBinaryData`.
   - Decode/encode samples manually as big-endian Int16 (`TraceSamples`).
3. **Register the complete field list for each revision** (not only deltas). Base `BuildHeader`/`Pack` aggregate revisions `1..N`, which is wrong for full layouts — overrides sum/emit **only** `Header.StandardizedRevision`.
4. **MID 0901** uses the same full-per-revision + active-revision `BuildHeader`/`Pack` pattern, without a binary tail.

## Alternatives considered

| Option | Pros | Cons |
|--------|------|------|
| Custom binary `DataField` | Uniform field model | Breaks string `Pack`/`Parse`, touches core infrastructure for one MID family |
| Separate binary parser outside Mid | Keeps Mid pure ASCII | Duplicates header/length rules; weaker interpreter integration |
| Delta-only field registration (stock OPI style) | Matches most MIDs | Rev 2/3 insert fields mid-body; deltas mis-size and mis-index the volatile region |

## Consequences

- Consumers must use **`Parse(byte[])` / `PackBytes()`** for MID 0900 to retain samples; string `Parse`/`Pack` handle the ASCII lead (and NUL on pack) only.
- Future MIDs with the same NUL+binary pattern should copy this approach rather than extending `DataField`.
- Unit tests for 0900 are primarily byte-array round-trips; 0901 keeps ASCII + byte-array tests.
