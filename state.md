# Repo Assist Memory

Last updated: 2026-09-09 (run https://github.com/fabulous-dev/Fabulous/actions/runs/34416913121)

## Task selection this run
Selected: [6 (Maintain Repo Assist PRs), 8 (Performance Improvements), 9 (Testing Improvements)].
- Task 6 (primary action): Found all 5 open repo-assist PRs (#1202, #1234, #1270, #1303, #1311).
  #1311 (test-widgetdiff-scalarchanges) was already up to date with main. The other 4
  (#1202, #1234, #1270, #1303) had gone stale again since last rebase (2026-09-07) due to
  many more doc/website/MAUI-debugging PRs merging into main, causing renewed CHANGELOG.md
  merge conflicts (the recurring pattern: `## [Unreleased]` section empty on main, each
  PR branch adds its own bullet under Unreleased -> conflict). Rebased all 4 onto
  origin/main, manually resolved CHANGELOG.md conflicts each time by keeping the branch's
  own Unreleased entry plus main's existing 10.0.1 section, skipped a duplicate
  re-application of the same commit each rebase hit (GitHub PR branches apparently contain
  the same logical commit twice — once from an earlier local-then-remote sync — rebase
  correctly no-net-changed on `git rebase --skip` after the first application landed).
  Ran full test suite after each rebase: #1202 45/45, #1234 43/43, #1270 50/50, #1303 43/43
  — all green. Pushed all 4 via push_to_pull_request_branch.
- Tasks 4/8 substituted to Task 9 again this run: same blocker as last run — sandbox lacks
  MAUI workloads (`maui-tizen`) so `dotnet list package --outdated` fails against the full
  `Fabulous.sln`; did not have time to retry scoping to individual .fsproj files this run
  either (rebasing 4 branches took priority). No measurable, low-risk perf opportunity was
  identified quickly enough to pursue safely.
- Task 9 (secondary action): Added
  src/neutral/Fabulous.Tests/WidgetDiffEnvironmentChangesTests.fs covering
  WidgetDiff.EnvironmentChanges: empty prev/next, all-Added when prev empty, all-Removed
  when next empty, Updated on differing value, no-op on identical value, disjoint key sets
  (one Removed + one Added), and the SkipRepeatingScalars duplicate-key dedup behavior.
  EnvironmentChange is a byref-like struct (IsByRefLike) — same workaround as ScalarChange:
  projected into a private plain-data EnvironmentChangeKind DU before collecting. 7 new
  tests, full suite went from 42 -> 49, all green. Had to fix one gotcha: `Assert.AreEqual([],
  changes)` fails with a type-mismatch error (`FSharpList<Object>` vs `FSharpList<T>`)
  because F#'s empty-list-literal type inference defaults to `obj` in that position; had to
  use `List.empty<EnvironmentChangeKind>` explicitly instead. Ran
  `dotnet fantomas src/neutral/Fabulous.Tests/WidgetDiffEnvironmentChangesTests.fs` to
  auto-fix formatting before creating PR (branch
  repo-assist/test-widgetdiff-environmentchanges). Added CHANGELOG entry under [Unreleased].
- Task 11: rewrote Monthly Activity issue #1281 (still September 2026) — updated Suggested
  Actions to note all 4 rebased PRs plus the new WidgetDiff.EnvironmentChanges PR, updated
  Future Work to mention WidgetChanges/WidgetCollectionChanges/Memo.fs as remaining test gaps,
  prepended new Run History entry with this run's timestamp/link.

## Currently open issues (7, unchanged from last run)
- #1304 - Human QA/canary summary from collaborator MiroslavHustak; freeze considered lifted
  since NuGet 10.0.1 shipped 2026-09-07. No further action needed.
- #1281 - Monthly Activity issue (Task 11 target), updated this run.
- #1162, #1163, #1164 - QA tracking issues (rendering/lifecycle, accessibility,
  input/navigation) with detailed automation research notes already posted by repo-assist.
  No new human activity — no further comment needed unless new activity appears.
- #1143 - Welcome/intro post, no action needed.
- #1156 - Release announcement (10.0.0), no code action needed; 10.0.1 has since shipped too.

## Open PRs (6, all repo-assist)
- #1202 repo-assist/perf-sub-hashset - rebased again + tests green (45/45) as of 2026-09-09.
  Awaiting review. Watch for renewed staleness if many more docs PRs merge before review.
- #1234 repo-assist/improve-stackarray3-combine - rebased again + tests green (43/43) as of
  2026-09-09. Awaiting review.
- #1270 repo-assist/test-stackarray3-coverage - rebased again + tests green (50/50) as of
  2026-09-09. Awaiting review.
- #1303 repo-assist/fix-dispatchthrottle-leading-error-handling - rebased again + tests green
  (43/43) as of 2026-09-09. Awaiting review.
- #1311 repo-assist/test-widgetdiff-scalarchanges - already up to date with main this run,
  49/49 tests green. Awaiting review.
- repo-assist/test-widgetdiff-environmentchanges (NEW this run, 2026-09-09) -
  WidgetDiff.EnvironmentChanges unit tests, 49/49 suite green, draft PR created. Awaiting
  review.

## Backlog / follow-ups for next run
- IMPORTANT PATTERN: this repo merges a very high volume of small doc/website/MAUI-debugging
  PRs into main (mostly from a collaborator, MiroslavHustak). Each one that touches
  CHANGELOG.md's `## [Unreleased]` section (adding then immediately releasing it, leaving it
  empty again) causes renewed conflicts on every open repo-assist branch. Expect to need to
  re-rebase these open PRs (#1202/#1234/#1270/#1303/#1311/env-changes) again next run even
  after this run's rebase — check `git merge-base --is-ancestor origin/main origin/<branch>`
  first before assuming a rebase is unnecessary.
- When rebasing hits "could not apply <commit>... " immediately after a successful CHANGELOG
  resolution+continue, and the file diffs (Sub.fs/Array.fs/etc, not CHANGELOG/docs) come back
  empty between HEAD and the commit being applied, it's a duplicate commit already applied
  earlier in the same rebase (or from a previous sync) — `git rebase --skip` is correct and
  safe; always verify with `git diff --stat origin/main HEAD` afterward to confirm only the
  intended production files changed.
- Test coverage gaps remaining: Memo.fs still fully untested. WidgetDiff.fs now has coverage
  for ScalarChanges and EnvironmentChanges — WidgetChanges, WidgetCollectionChanges, and
  Reconciler.fs (thin wrapper around WidgetDiff.create + node.ApplyDiff) remain uncovered.
  Good candidates for next Task 9 run. WidgetChanges/WidgetCollectionChanges are more complex
  (involve nested widget diffing / view reconciliation, not just plain-data attributes) so
  may need more careful test setup with mock IViewNode / CanReuseView callbacks.
- Task 4 (Engineering): still haven't tried scoping `dotnet list package --outdated` to
  individual .fsproj files (Fabulous.Core, Fabulous.Tests) instead of Fabulous.sln to work
  around the missing maui-tizen workload in this sandbox. Try this explicitly next Task 4 run.
- No open bug/help-wanted/good-first-issue labelled issues currently — Task 3 not applicable
  until new labelled issues appear.
- No new human comments since last run on #1162/#1163/#1164/#1143/#1156/#1304 — no
  re-engagement needed.

## Comments made log
- No new issue comments made this run (Task 9 focus was a test-only PR needing no issue
  linkage/comment since it doesn't close any specific issue; Task 6 was PR-branch pushes only,
  no issue comments).

## PRs created log
- repo-assist/perf-sub-hashset (2026-08-29): Sub.fs HashSet optimization + tests. Still open (#1202).
- repo-assist/improve-stackarray3-combine (2026-08-30): StackArray3.combine allocation
  optimization + test. Still open (#1234).
- repo-assist/test-stackarray3-coverage (2026-08-31): StackArray3 add/get/find/combine unit
  tests (7 new tests). Still open (#1270).
- repo-assist/fix-dispatchthrottle-leading-error-handling (2026-09-05): Fixed DispatchThrottle
  leading-edge Dispatch not routing emit exceptions to onError. Still open (#1303).
- repo-assist/test-widgetdiff-scalarchanges (2026-09-08): WidgetDiff.ScalarChanges unit tests
  (7 new tests, test-only, no production code changed). Still open (#1311).
- repo-assist/test-widgetdiff-environmentchanges (2026-09-09, NEW): WidgetDiff.EnvironmentChanges
  unit tests (7 new tests, test-only, no production code changed). Just created this run.
