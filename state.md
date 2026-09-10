# Repo Assist Memory

Last updated: 2026-09-10 (run https://github.com/fabulous-dev/Fabulous/actions/runs/34542111804)

## Task selection this run
Selected: [4 (Engineering Investments), 10 (Take the Repository Forward), 1 (Issue Labelling)].
- Task 1 (primary action): Only 1 unlabelled issue existed (#1304, human QA summary report
  from collaborator MiroslavHustak). Labelled it `documentation` (it documents QA/testing
  process notes, no code action needed).
- Task 4 (primary action): Retried the workaround noted in memory last run — scoped
  `dotnet list package --outdated` to individual .fsproj files instead of Fabulous.sln
  (which fails to restore due to missing `maui-tizen` workload in this sandbox). This
  worked cleanly for src/neutral/Fabulous.Core/Fabulous.Core.fsproj and
  src/neutral/Fabulous.Tests/Fabulous.Tests.fsproj. Found FSharp.Core (10.0.100 ->
  10.1.401) and Microsoft.NET.Test.Sdk (18.9.0 -> 18.10.0) behind in
  Directory.Packages.props (central package management). Bumped both (patch/minor,
  low risk). Did NOT touch Fabulous.Core.fsproj's own `VersionOverride="8.0.300"` for
  FSharp.Core (that's an intentional lower-bound for consumers, per the comment in the
  file). Validated: dotnet build Fabulous.Core (net10.0 + netstandard2.1) succeeded,
  dotnet test Fabulous.Tests 42/42 passed, dotnet build
  Fabulous.Avalonia.Tests (-p:FabulousSamplesDesktopOnly=true) succeeded. MAUI projects
  still can't be restored/built here (missing maui-tizen workload) -- documented as a
  known gap in the PR's Test Status section. Created draft PR from branch
  repo-assist/eng-fsharp-core-testsdk-bump-2026-09-10.
- Task 10 (secondary action): Continued closing WidgetDiff.fs test-coverage gaps
  identified in last run's memory. Added
  src/neutral/Fabulous.Tests/WidgetDiffWidgetChangesTests.fs covering
  WidgetDiff.WidgetChanges (used for single-widget attributes like a container's
  Content): empty prev/next, all-Added when prev empty, all-Removed when next empty,
  no-op on identical widget reference, Updated when canReuseView returns true for a
  changed widget, ReplacedBy when canReuseView returns false, and disjoint attribute
  key sets. Used Attributes.defineWidget to create two independent widget-attribute
  definitions (attrA/attrB) and a minimal makeWidget helper building a bare Widget
  record with empty attribute arrays (never registers/uses a WidgetDefinitionStore
  entry since these tests only enumerate WidgetChange values, never call ApplyDiff /
  CreateView). Projected WidgetChange (struct DU carrying Widget values) into a
  private plain-data WidgetChangeKind DU for assertions, same pattern as the prior
  ScalarChanges/EnvironmentChanges test PRs. Ran `dotnet fantomas` on the new file
  (auto-formatted, no diff needed after) and `dotnet fantomas --check
  src/neutral/Fabulous.Tests` (clean). Full suite went from 42 -> 49 (7 new tests),
  all green. Added CHANGELOG entry under [Unreleased]. Created draft PR from branch
  repo-assist/test-widgetdiff-widgetchanges.
- Task 11: rewrote Monthly Activity issue #1281 (still September 2026) -- updated
  Suggested Actions to add the 2 new PRs from this run plus a "check labelling" item
  for #1304, updated Future Work to note WidgetCollectionChanges/
  WidgetCollectionItemChanges/Reconciler.fs/Memo.fs as remaining test gaps and that
  MAUI-referencing packages still can't be checked for updates in this sandbox,
  prepended new Run History entry with this run's timestamp/link.

## Currently open issues (7, unchanged from last run)
- #1304 - Human QA/canary summary from collaborator MiroslavHustak; now labelled
  `documentation` this run. No further action needed.
- #1281 - Monthly Activity issue (Task 11 target), updated this run.
- #1162, #1163, #1164 - QA tracking issues (rendering/lifecycle, accessibility,
  input/navigation) with detailed automation research notes already posted by repo-assist.
  No new human activity -- no further comment needed unless new activity appears.
- #1143 - Welcome/intro post, no action needed.
- #1156 - Release announcement (10.0.0), no code action needed; 10.0.1 has since shipped too.

## Open PRs (8, all repo-assist)
- #1202 repo-assist/perf-sub-hashset - rebased + tests green (45/45) as of 2026-09-09.
  Awaiting review. Watch for renewed staleness if many more docs PRs merge before review.
- #1234 repo-assist/improve-stackarray3-combine - rebased + tests green (43/43) as of
  2026-09-09. Awaiting review.
- #1270 repo-assist/test-stackarray3-coverage - rebased + tests green (50/50) as of
  2026-09-09. Awaiting review.
- #1303 repo-assist/fix-dispatchthrottle-leading-error-handling - rebased + tests green
  (43/43) as of 2026-09-09. Awaiting review.
- #1311 repo-assist/test-widgetdiff-scalarchanges - 49/49 tests green. Awaiting review.
- #1312 repo-assist/test-widgetdiff-environmentchanges - 49/49 tests green. Awaiting review.
- repo-assist/eng-fsharp-core-testsdk-bump-2026-09-10 (NEW this run, 2026-09-10) -
  FSharp.Core + Microsoft.NET.Test.Sdk patch bumps in Directory.Packages.props. Draft PR
  created, awaiting review.
- repo-assist/test-widgetdiff-widgetchanges (NEW this run, 2026-09-10) - WidgetDiff.WidgetChanges
  unit tests, 49/49 suite green, draft PR created. Awaiting review.

## Backlog / follow-ups for next run
- IMPORTANT PATTERN: this repo merges a very high volume of small doc/website/MAUI-debugging
  PRs into main (mostly from a collaborator, MiroslavHustak). Each one that touches
  CHANGELOG.md's `## [Unreleased]` section (adding then immediately releasing it, leaving it
  empty again) causes renewed conflicts on every open repo-assist branch. Expect to need to
  re-rebase these open PRs again next run -- check
  `git merge-base --is-ancestor origin/main origin/<branch>` first before assuming a rebase
  is unnecessary. Now 8 open PRs to track/rebase, up from 6 last run.
- Test coverage gaps remaining: Memo.fs still fully untested. WidgetDiff.fs now has coverage
  for ScalarChanges, EnvironmentChanges, and WidgetChanges -- WidgetCollectionChanges,
  WidgetCollectionItemChanges, and Reconciler.fs (thin wrapper around WidgetDiff.create +
  node.ApplyDiff) remain uncovered. Good candidates for next Task 9/10 run.
  WidgetCollectionChanges/WidgetCollectionItemChanges are more complex (involve
  ArraySlice<Widget>, nested widget diffing / view reconciliation with Insert/Replace/
  Update/Remove item changes, not just plain-data attributes) so may need more careful
  test setup.
- Task 4 (Engineering): confirmed this run that scoping `dotnet list package --outdated`
  to individual .fsproj files (Fabulous.Core.fsproj, Fabulous.Tests.fsproj) DOES work around
  the missing maui-tizen workload -- this is now the established approach. Still haven't
  been able to check MAUI-referencing packages (Microsoft.Maui.Controls, etc.) or Avalonia
  package versions this way -- try `dotnet list src/avalonia/**/*.fsproj package --outdated`
  next Task 4 run (each project individually, since `dotnet list` only accepts one project
  path per invocation).
- No open bug/help-wanted/good-first-issue labelled issues currently -- Task 3 not applicable
  until new labelled issues appear.
- No new human comments since last run on #1162/#1163/#1164/#1143/#1156/#1304 -- no
  re-engagement needed.
- All 7 open issues are now labelled -- Task 1 has no more unlabelled-issue backlog until a
  new issue is filed.

## Comments made log
- No new issue comments made this run (Task 4/10 were PR-creation-only; Task 1 was a
  labelling-only action on #1304, no comment added since the label is self-explanatory and
  the issue already has a substantive human comment).

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
- repo-assist/test-widgetdiff-environmentchanges (2026-09-09): WidgetDiff.EnvironmentChanges
  unit tests (7 new tests, test-only, no production code changed). Still open (#1312).
- repo-assist/eng-fsharp-core-testsdk-bump-2026-09-10 (2026-09-10, NEW): FSharp.Core
  10.0.100->10.1.401 and Microsoft.NET.Test.Sdk 18.9.0->18.10.0 bumps in
  Directory.Packages.props. Just created this run.
- repo-assist/test-widgetdiff-widgetchanges (2026-09-10, NEW): WidgetDiff.WidgetChanges unit
  tests (7 new tests, test-only, no production code changed). Just created this run.
