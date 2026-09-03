# Repo Assist Memory

Last updated: 2026-09-03 (run https://github.com/fabulous-dev/Fabulous/actions/runs/33817534545)

## Task selection this run
Selected: [6 (Maintain Repo Assist PRs), 4 (Engineering Investments), 5 (Coding Improvements)].
- Task 6: checked #1202, #1234, #1270 — no CI check runs reported for any of the three, and the
  collaborator's (@MiroslavHustak) "hold off until canary/QA completes" comment on each still
  stands with no new activity since. No updates pushed, no nudges made — respecting the hold.
- Task 4: found the repo's only remaining unpinned GitHub Action reference —
  `actions/github-script@v7` in `.github/workflows/pr-artifacts.yml` — every other workflow in
  the repo already pins `actions/github-script` (and all third-party actions) to a full commit
  SHA. Pinned it to the same SHA (`3a2844b7e9c422d3c10d287c895573f7108da1b3 # v9.0.0`) used
  everywhere else. Docs/workflow-only change, no build/test needed. Created draft PR (see below).
  Checked Dependabot alerts (none visible/authorized) and Directory.Packages.props versions -
  nothing else stood out as a safe, actionable dependency bump this run.
- Task 5: reviewed outstanding `// TODO` markers (Array.fs:622 growth handling, Builders.fs:244
  addMut optimization, WidgetDiff.fs:43, ViewNode.fs:18, Attributes.fs:45) - as noted in prior
  runs, none rose to a clearly beneficial, low-risk change worth a new PR, especially given the
  existing QA hold on #1202/#1234/#1270 already queued for review. Deferred rather than adding
  to the review backlog.

## Currently open issues (6)
- #1281 - Monthly Activity issue itself (Task 11 target, updated this run).
- #1143 - Welcome/intro post, no action needed.
- #1156 - Release announcement, no code action, awaiting timing.
- #1162, #1163, #1164 - QA tracking issues, awaiting human tester results, no bot action.
(Note: #1278 from last run appears to have been closed/resolved - no longer in open issue list.)

## Open PRs
- #1202 repo-assist/perf-sub-hashset (created 2026-08-29) - still holding per collaborator request.
- #1234 repo-assist/improve-stackarray3-combine (created 2026-08-30) - still holding.
- #1270 repo-assist/test-stackarray3-coverage (created 2026-08-31) - still holding.
- #1280 repo-assist/fix-summary-xamarinforms-links (created 2026-09-02) - docs fix for #1278.
- NEW: repo-assist/eng-pin-github-script-action-20260903 (created 2026-09-03) - pins
  actions/github-script to commit SHA in pr-artifacts.yml. Docs/workflow-only, no build needed.

## Backlog / follow-ups for next run
- Before creating any new perf/coding PRs (Tasks 5/8): check whether #1202/#1234/#1270 have been
  merged/closed or the QA hold has been lifted by a maintainer comment.
- Monitor the new eng-pin-github-script-action PR and the fix-summary-xamarinforms-links PR (#1280)
  for CI/review status.
- TODO markers survey still pending (Array.fs ~622, Attributes.fs SmallScalars.Int, Builders.fs
  ~244, ViewNode.fs ~18, WidgetDiff.fs ~43) — author's own comments suggest no perf difference,
  likely not worth pursuing.
- Test coverage gaps: Memo.fs, Reconciler.fs, WidgetDiff.fs still have no dedicated test files.
- Dependabot alerts: list_dependabot_alerts returned a secrecy-filtered result this run
  (1 item hidden, not authorized) - could not evaluate; try again next run.

## Comments made log
- No new issue comments made this run.

## PRs created log
- repo-assist/perf-sub-hashset (2026-08-29): Sub.fs HashSet optimization + tests. Still open (#1202).
- repo-assist/improve-stackarray3-combine (2026-08-30): StackArray3.combine allocation
  optimization + test. Still open (#1234).
- repo-assist/test-stackarray3-coverage (2026-08-31): StackArray3 add/get/find/combine unit
  tests (7 new tests). Still open (#1270).
- repo-assist/fix-summary-xamarinforms-links (2026-09-02): Removed stale Xamarin.Forms broken
  links section from docs/api/SUMMARY.md, closes #1278's actionable finding. Still open (#1280).
- repo-assist/eng-pin-github-script-action-20260903 (2026-09-03): Pinned actions/github-script
  to commit SHA in .github/workflows/pr-artifacts.yml (the only unpinned action reference left
  in the repo). Docs/workflow-only, no build/test needed.
