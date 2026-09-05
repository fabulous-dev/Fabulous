# Repo Assist Memory

Last updated: 2026-09-05 (run https://github.com/fabulous-dev/Fabulous/actions/runs/33998620295)

## Task selection this run
Selected: [2 (Issue Investigation and Comment), 3 (Issue Investigation and Fix), 5 (Coding Improvements)].
- Task 2: reviewed all 6 open issues (#1143, #1156, #1162, #1163, #1164, #1281) — no new human
  comments since last run except the standing "QA hold" comment on #1281 (already logged).
  Nothing warranted a new comment; no action taken (issues #1162-1164 are repo-assist QA tracking
  placeholders awaiting human testers, #1143/#1156 are informational, #1281 is the monthly summary).
- Task 3: no issues labelled `bug`, `help wanted`, or `good first issue` currently open (checked
  full open-issue list) — no fixable bug found this run. Fell back toward Task 5 effort instead.
- Task 5: used an explore sub-agent to scan src/neutral/Fabulous.Core for a new low-risk issue not
  already surveyed (previous TODO markers in Array.fs/Attributes.fs/Builders.fs/ViewNode.fs/
  WidgetDiff.fs already rejected). Found a genuine inconsistency in DispatchThrottle.fs: the
  leading-edge `Dispatch` call (`values |> Option.iter emit`) did not wrap `emit` in try/with,
  unlike the timer callback and FlushAsync, so a throwing dispatch handler would crash the
  caller's thread instead of routing to onError. Fixed with the same try/with -> reportError
  pattern, added a regression test ("Leading throttle routes emit exceptions on the first
  dispatch to onError") in CmdTests.fs, added CHANGELOG entry, and created a draft PR:
  repo-assist/fix-dispatchthrottle-leading-error-handling. Build/tests green (43/43 passed),
  fantomas check clean.

## Currently open issues (6)
- #1281 - Monthly Activity issue (Task 11 target, rewritten to standard format this run;
  previous body used a different structure — corrected).
- #1143 - Welcome/intro post, no action needed.
- #1156 - Release announcement (10.0.0), no code action, awaiting timing.
- #1162, #1163, #1164 - QA tracking issues (rendering/lifecycle, accessibility, input/nav),
  awaiting human tester results, no bot action expected until testers report findings.

## Open PRs
- #1202 repo-assist/perf-sub-hashset (created 2026-08-29) - still holding per collaborator QA request.
- #1234 repo-assist/improve-stackarray3-combine (created 2026-08-30) - still holding.
- #1270 repo-assist/test-stackarray3-coverage (created 2026-08-31) - still holding.
- NEW: repo-assist/fix-dispatchthrottle-leading-error-handling (created 2026-09-05) - fixes
  DispatchThrottle.Dispatch leading-edge emit exceptions not being routed to onError, with
  regression test + CHANGELOG entry. Build/tests green.
- NOTE: repo-assist/fix-summary-xamarinforms-links (#1280, docs fix) and
  repo-assist/eng-pin-github-script-action-v2 from prior runs are no longer showing in the open
  PR list as of this run (likely merged/closed) — issue #1299 (leftover from a failed push) can
  likely be closed by maintainer if not already.

## Backlog / follow-ups for next run
- Suggest maintainer lift the QA/canary hold on #1202/#1234/#1270 (waiting since late August) or
  provide an update — flagged again in the Monthly Activity issue.
- Verify whether the new fix-dispatchthrottle PR shows up correctly next run (confirm push succeeded).
- Test coverage gaps: Memo.fs, Reconciler.fs, WidgetDiff.fs still have no dedicated test files
  (candidate for Task 9 next time it's selected).
- No open bug/help-wanted/good-first-issue labelled issues currently — Task 3 will need to fall
  back to Task 2 or investigate newly filed issues in future runs.

## Comments made log
- No new issue comments made this run (Task 2: nothing warranted comment).

## PRs created log
- repo-assist/perf-sub-hashset (2026-08-29): Sub.fs HashSet optimization + tests. Still open (#1202).
- repo-assist/improve-stackarray3-combine (2026-08-30): StackArray3.combine allocation
  optimization + test. Still open (#1234).
- repo-assist/test-stackarray3-coverage (2026-08-31): StackArray3 add/get/find/combine unit
  tests (7 new tests). Still open (#1270).
- repo-assist/fix-summary-xamarinforms-links (2026-09-02): docs fix, no longer in open PR list
  (likely merged).
- repo-assist/eng-pin-github-script-action-v2 (2026-09-04): pin actions/github-script to commit
  SHA, no longer in open PR list (likely merged; superseded issue #1299).
- repo-assist/fix-dispatchthrottle-leading-error-handling (2026-09-05): Fixed DispatchThrottle
  leading-edge Dispatch not routing emit exceptions to onError (inconsistent with timer callback
  and FlushAsync). Added regression test + CHANGELOG entry. Build/tests green (43/43).
