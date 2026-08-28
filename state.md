# Repo Assist Memory

Last updated: 2026-08-28 (run https://github.com/fabulous-dev/Fabulous/actions/runs/33156879260)

## Reconciliation note
Memory had drifted significantly stale before this run. Many issues previously tracked as
"open, acknowledged fix pending" are now closed (fixed/merged directly by maintainer dsyme
or via separate `/repo-assist` triggered runs). Always re-verify via live GitHub queries
before acting on this file.

## Closed since last reconciliation (no longer actionable)
#1166, #1169, #1170, #1171, #1174, #1179, #1180, #1181, #1182 - all closed (fixed/merged).

## Currently open issues (as of this run)
- #1147 - Monthly Activity issue itself (this file's target, Task 11)
- #1148 - Fabulous 10.0.0 release blockers/signoff - CHANGELOG + Xamarin-docs-marker + deprecation-warning
  triage action items already completed; remaining items are manual product signoff / docs verification
  (not automatable).
- #1156 - Release announcement, awaiting release timing, no code action.
- #1162, #1163, #1164 - QA tracking issues (rendering/lifecycle, accessibility, input/navigation),
  awaiting human tester results, no bot action needed.
- #1143 - Welcome/intro post, no action needed.

## Open PRs
- #1183 - "Bump fabulous-avalonia template default FSharp.Core to 10.0.100" (closes #1179).
  CI green (11 checks, all success/skipped) as of this run. Awaiting maintainer review/merge.
- repo-assist/fix-stackarray3-sortinplace - opened this run, fixes StackArray3.sortInPlace bug (see below).

## This run's finding and fix
Found and fixed a genuine bug in src/neutral/Fabulous.Core/Array.fs:
StackArray3.sortInPlace's Size.Three branch computed
(getKey v0, getKey v1, getKey v1) instead of (getKey v0, getKey v1, getKey v2) -
a copy/paste typo meaning the third element's key was never derived from v2.
Fixed to use getKey v2; added a regression test in ArrayTests.fs covering all
6 permutations of a 3-element sort. Build/tests/fantomas/validate-inventory all passed.
Opened as a draft PR (branch repo-assist/fix-stackarray3-sortinplace), no linked issue
(discovered via code review, not from an open issue).
Note: StackArray3 currently has no call sites elsewhere in the codebase - worth checking
in a future run whether it's dead/preparatory code or intended for future wiring.

## Engineering Investments (Task 4) checks this run
- No network access to NuGet.org in this sandbox (curl blocked) - cannot check for newer
  package versions directly; relied on static review of Directory.Packages.props /
  Directory.Build.props, which appear current (FSharp.Core 10.0.100, Maui.Controls 10.0.100,
  Avalonia 12.1.1, coverlet.collector/NUnit3TestAdapter already bumped in a prior run).
- Reviewed .github/workflows/*.yml action versions (checkout@v4, setup-dotnet@v4, cache@v4) -
  all current, no improvement found.
- No actionable Task 4 item found this run.

## Backlog cursor
No open unaddressed bug/help-wanted/good-first-issue items remain after this run's fix.
Next run: re-check #1148 checklist progress, re-verify #1183 merge status, and consider
following up on whether StackArray3 has since been wired up (would validate blast radius
of this run's fix as more than "preparatory code").

## Comments made log
No new issue comment made this run - action was a direct PR from code review + Task 11
issue update only.
