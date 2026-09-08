# Repo Assist Memory

Last updated: 2026-09-08 (run https://github.com/fabulous-dev/Fabulous/actions/runs/34290611038)

## Task selection this run
Selected: [9 (Testing Improvements), 4 (Engineering Investments), 8 (Performance Improvements)].
- Task 9 (primary action): WidgetDiff.fs (668 lines) had zero test coverage. Added
  src/neutral/Fabulous.Tests/WidgetDiffTests.fs covering WidgetDiff.ScalarChanges: empty
  prev/next, all-Added when prev empty, all-Removed when next empty, Updated on differing
  numeric value, no-op on identical value, disjoint attribute sets (one Removed + one Added),
  and the SkipRepeatingScalars duplicate-key dedup behavior. ScalarChange is a byref-like
  struct (IsByRefLike) so results can't be stored directly in a list/ResizeArray — worked
  around by projecting each ScalarChange into a private plain-data `ScalarChangeKind` DU
  before collecting. 7 new tests, full suite went from 42 -> 49, all green. Ran
  `dotnet fantomas src/neutral/Fabulous.Tests/WidgetDiffTests.fs` to auto-fix formatting
  before creating PR (branch repo-assist/test-widgetdiff-scalarchanges). Added CHANGELOG
  entry under [Unreleased].
- Tasks 4/8 substituted to Task 9 this run: `dotnet list package --outdated` against the
  full `Fabulous.sln` fails in this sandbox with NETSDK1147 (missing `maui-tizen` workload)
  for the MAUI projects — can't assess dependency updates repo-wide without that workload.
  No measurable, low-risk perf opportunity was identified quickly enough to pursue safely.
  Next run: try `dotnet list package --outdated` scoped to just Fabulous.Core.fsproj /
  Fabulous.Tests.fsproj (avoiding the full solution) to get Task 4 unblocked without needing
  MAUI workloads.
- Task 11: rewrote Monthly Activity issue #1281 (still September 2026) — added the new
  WidgetDiff test PR to Suggested Actions, updated Future Work to mention remaining
  WidgetDiff change-types (WidgetChanges/WidgetCollectionChanges/EnvironmentChanges) and
  Memo.fs as still-untested, prepended new Run History entry.

## Currently open issues (7, unchanged from last run)
- #1304 - Human QA/canary summary from collaborator MiroslavHustak; freeze considered lifted
  since NuGet 10.0.1 shipped 2026-09-07. No further action needed.
- #1281 - Monthly Activity issue (Task 11 target), updated this run.
- #1162, #1163, #1164 - QA tracking issues (rendering/lifecycle, accessibility,
  input/navigation) with detailed automation research notes already posted by repo-assist.
  No new human activity — no further comment needed unless new activity appears.
- #1143 - Welcome/intro post, no action needed.
- #1156 - Release announcement (10.0.0), no code action needed; 10.0.1 has since shipped too.

## Open PRs (5, all repo-assist)
- #1202 repo-assist/perf-sub-hashset - rebased + tests green as of 2026-09-07. Awaiting review.
- #1234 repo-assist/improve-stackarray3-combine - rebased + tests green as of 2026-09-07. Awaiting review.
- #1270 repo-assist/test-stackarray3-coverage - rebased + tests green as of 2026-09-07. Awaiting review.
- #1303 repo-assist/fix-dispatchthrottle-leading-error-handling - rebased + tests green as of
  2026-09-07. Awaiting review.
- repo-assist/test-widgetdiff-scalarchanges (NEW this run, 2026-09-08) - WidgetDiff.ScalarChanges
  unit tests, 49/49 suite green, draft PR created. Awaiting review.

## Backlog / follow-ups for next run
- Watch #1202/#1234/#1270/#1303/(new WidgetDiff PR) for merge, further CI issues, or staleness;
  if CI fails due to repo-assist's own changes, push a fix (Task 6). If any go stale (14+ days
  without maintainer action), consider a gentle status-check comment.
- Test coverage gaps remaining: Memo.fs still fully untested. WidgetDiff.fs now has coverage
  for ScalarChanges only — WidgetChanges, WidgetCollectionChanges, EnvironmentChanges, and
  Reconciler.fs (thin wrapper around WidgetDiff.create + node.ApplyDiff) remain uncovered.
  Good candidates for next Task 9 run.
- Task 4 (Engineering): try scoping `dotnet list package --outdated` to individual .fsproj
  files (Fabulous.Core, Fabulous.Tests) instead of Fabulous.sln to work around the missing
  maui-tizen workload in this sandbox.
- No open bug/help-wanted/good-first-issue labelled issues currently — Task 3 not applicable
  until new labelled issues appear.
- No new human comments since last run on #1162/#1163/#1164/#1143/#1156 — no re-engagement needed.

## Comments made log
- No new issue comments made this run (Task 9 focus was a test-only PR needing no issue
  linkage/comment since it doesn't close any specific issue).

## PRs created log
- repo-assist/perf-sub-hashset (2026-08-29): Sub.fs HashSet optimization + tests. Still open (#1202).
- repo-assist/improve-stackarray3-combine (2026-08-30): StackArray3.combine allocation
  optimization + test. Still open (#1234).
- repo-assist/test-stackarray3-coverage (2026-08-31): StackArray3 add/get/find/combine unit
  tests (7 new tests). Still open (#1270).
- repo-assist/fix-dispatchthrottle-leading-error-handling (2026-09-05): Fixed DispatchThrottle
  leading-edge Dispatch not routing emit exceptions to onError. Still open (#1303).
- repo-assist/test-widgetdiff-scalarchanges (2026-09-08, NEW): WidgetDiff.ScalarChanges unit
  tests (7 new tests, test-only, no production code changed). Just created this run.
