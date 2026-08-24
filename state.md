# Repo Assist Memory

## Status
- Repo was freshly reset/unified (issue #1143, "Welcome" post, created 2026-08-24). No prior history to draw on.

## Issues
- #1143: Welcome/intro issue, no action required (not a bug/feature request). Reviewed 2026-08-24.

## PRs
- None open as of 2026-08-24.

## Investigation notes for future work (Task 10 candidates)
- src/neutral/Fabulous.Core/WidgetDiff.fs:43 — TODO: hot-path skip-repeating-scalars function; author unsure if more optimal approach exists. Potential perf investigation (Task 8) but needs benchmarks before touching hot path.
- src/neutral/Fabulous.Core/Array.fs:393-394 — TODO: optimize Array.append paths in `Few`/`Many` cases.
- src/neutral/Fabulous.Core/Array.fs:622 — TODO: handle growth (unclear scope, needs investigation to define exact issue).
- src/neutral/Fabulous.Core/Builders.fs:244 — TODO: optimize with addMut.
- src/neutral/Fabulous.Core/Attributes.fs:45 — TODO: better conversion algorithm question, low priority.
- src/neutral/Fabulous.Core/ViewNode.fs:18 — TODO: consider combining handlers mapMsg and property bag; would need design discussion, possibly breaking change.

None of these are yet turned into fixes since they need benchmarks/careful validation before a surgical, low-risk PR could be made confidently. Next run: pick one (e.g. Array.fs growth handling) and investigate feasibility of a safe, tested improvement.

## Comments made
(none yet)

## Fix attempts
(none yet)

## Backlog cursor
- Issue list cursor: none (only 1 open issue, already reviewed)

## Monthly Activity Issue
- Not yet created (this run creates the first one for 2026-08).
