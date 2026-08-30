# Repo Assist Memory

Last updated: 2026-08-30 (run https://github.com/fabulous-dev/Fabulous/actions/runs/33341747522)

## Task selection this run
Selected: [5 (Coding Improvements), 1 (Issue Labelling), 2 (Issue Comment)].
- Task 1: not applicable — all 6 open issues already labelled. No action.
- Task 2: not applicable — reviewed all 6 open issues, no new human activity/comments since
  last run, and issues are either QA-tracking/awaiting-human or awaiting maintainer close.
  No comment made (avoiding spam).
- Task 5: implemented — StackArray3.combine (src/neutral/Fabulous.Core/Array.fs) had two
  `// TODO optimize` mixed Few/Many cases that allocated an intermediate array via
  toArray/Array.append before the final array. Rewrote to allocate the result once and copy
  directly. Added a test (ArrayTests.fs: "StackArray3.combine merges a Few and a Many array
  in either order"). Build + full test suite (43/43) passed. Fantomas check clean.
  PR: repo-assist/improve-stackarray3-combine, created this run.

## Currently open issues (6)
- #1147 - Monthly Activity issue itself (Task 11 target, updated this run).
- #1143 - Welcome/intro post, no action needed.
- #1156 - Release announcement, no code action, awaiting timing.
- #1162, #1163, #1164 - QA tracking issues, awaiting human tester results, no bot action.
(Note: #1171 no longer appears in the open issue list — likely closed by maintainer.)

## Open PRs
- repo-assist/perf-sub-hashset (#1202, created 2026-08-29): "Optimize Sub subscription
  diffing with mutable HashSet" - draft PR, still open, awaiting maintainer review. CI status
  was "pending" when checked this run (not failing) - no Task 6 action needed.
- repo-assist/improve-stackarray3-combine (this run): "Optimize StackArray3.combine to avoid
  intermediate array allocation" - draft PR, awaiting maintainer review.

## Backlog / follow-ups for next run
- Check whether maintainer merges/reviews PR #1202 (perf-sub-hashset); if CI fails on it,
  address in a future Task 6 run.
- Check whether maintainer merges/reviews the new improve-stackarray3-combine PR.
- StackArray3's other TODOs are resolved now; Array.fs line ~622 "TODO handle growth" and a
  few TODOs in Attributes.fs/Builders.fs/ViewNode.fs/WidgetDiff.fs remain as low-priority,
  unexplored candidates for a future Task 5/8 run.
- No unlabelled issues; no stale non-repo-assist PRs (no other open PRs besides repo-assist's own).

## Comments made log
- No new comments made this run (2026-08-30) - no new human activity on any open issue.

## PRs created log
- repo-assist/perf-sub-hashset (2026-08-29): Sub.fs HashSet optimization + tests. Still open.
- repo-assist/improve-stackarray3-combine (2026-08-30, this run): StackArray3.combine
  allocation optimization + test.
