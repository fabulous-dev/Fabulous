# Repo Assist Memory

## Status
- Repo was freshly reset/unified (issue #1143, "Welcome" post, created 2026-08-24). No prior history to draw on.

## Issues
- #1143: Welcome/intro issue, no action required (not a bug/feature request). Reviewed 2026-08-24.
- #1148: Release blockers/signoff checklist for 10.0.0. Labelled `documentation` 2026-08-24. Track for maintainer follow-up; do not action items requiring manual/human signoff.
- #1156: 10.0.0 release announcement. Labelled `documentation` 2026-08-24. Informational only.

## PRs
- Created draft PR "Update test tooling packages (coverlet.collector, NUnit3TestAdapter)" from branch repo-assist/eng-test-package-updates-20260824 (2026-08-24, Task 4). Bumped coverlet.collector 3.1.2->3.2.0 and NUnit3TestAdapter 5.0.0->5.2.0 in Directory.Packages.props. Core+Avalonia tests passed locally; MAUI tests untestable in sandbox (no maui-tizen workload) but low risk (packaging-only change).

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
- Issue list cursor: reviewed all 4 open issues (#1143, #1147, #1148, #1156) as of 2026-08-24. Next run should re-check #1148 for newly checked-off items and watch for new issues on #1156.

## Monthly Activity Issue
- #1147 exists for 2026-08, updated 2026-08-24 with Task 4 PR and labelling activity.
