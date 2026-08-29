# Repo Assist Memory

Last updated: 2026-08-29 (run https://github.com/fabulous-dev/Fabulous/actions/runs/33280925431)

## Task selection this run
Selected: [3 (Issue Fix), 8 (Performance Improvements), 2 (Issue Comment)].
- Task 3: no fixable bug/help-wanted/good-first-issue found this run (only #1171, already fixed &
  re-verified multiple times; no new bug reports). Substituted with more Task 8 work.
- Task 8: implemented — replaced immutable Set with mutable HashSet in Sub.fs subscription
  diffing (Sub.Internal.diff / NewSubs.calculate), which runs every Program update cycle.
  Added SubTests.fs (3 new tests). PR: repo-assist/perf-sub-hashset branch, created via
  create_pull_request tool this run.
- Task 2: reviewed all 7 open issues for new human comments since last run - none found, so
  no comment was made (avoiding redundant/spammy engagement per anti-spam guideline).

## Currently open issues (7)
- #1147 - Monthly Activity issue itself (Task 11 target, updated this run).
- #1143 - Welcome/intro post, no action needed.
- #1156 - Release announcement, no code action, awaiting timing.
- #1162, #1163, #1164 - QA tracking issues, awaiting human tester results, no bot action.
- #1171 - MAUI tutorial NU1605 downgrade warning. Verified fixed and re-verified 3x
  (dotnet new + isolated NuGet restore repro) across the last 3 runs. Awaiting maintainer
  to close. No further action needed unless new activity appears.

## Open PRs
- repo-assist/perf-sub-hashset (this run): "Optimize Sub subscription diffing with mutable
  HashSet" - draft PR, awaiting maintainer review.

## Backlog / follow-ups for next run
- StackArray3 (src/neutral/Fabulous.Core/Array.fs) has no call sites elsewhere in the
  codebase - worth checking whether it's dead/preparatory code or intended for future
  wiring (noted in several previous runs, still unresolved - low priority).
- Check whether maintainer merges/reviews the perf-sub-hashset PR; if CI fails on it,
  address in a future Task 6 run.
- Check whether maintainer closes #1171 (no new action needed from bot side).
- No unlabelled issues; no stale non-repo-assist PRs (there are no other open PRs).
- Considered other perf candidates in WidgetDiff.fs/Reconciler.fs/ViewNode.fs during
  exploration this run - already heavily hand-optimized (struct enumerators, spans,
  IsByRefLike) - no further clear low-risk wins found there without deeper profiling.

## Comments made log
- #1171 (2026-08-28, previous run): posted detailed re-verification comment with dotnet new +
  isolated NuGet restore repro proving the fix works, per maintainer's explicit request.
- No new comments made this run (2026-08-29) - no new human activity on any open issue.

## PRs created log
- repo-assist/perf-sub-hashset (2026-08-29, this run): Sub.fs HashSet optimization + tests.
