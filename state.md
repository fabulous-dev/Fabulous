# Repo Assist Memory

Last updated: 2026-09-04 (run https://github.com/fabulous-dev/Fabulous/actions/runs/33929419256)

## Task selection this run
Selected: [6 (Maintain Repo Assist PRs), 4 (Engineering Investments), 5 (Coding Improvements)].
- Task 6: checked #1202, #1234, #1270 — no CI check runs reported for any, collaborator's
  "hold off until canary/QA completes" comment still stands with no new activity. No updates
  pushed, no nudges made.
- Task 4: discovered the previous run's "pin actions/github-script" PR had failed to git push
  and instead surfaced as issue #1299 with manual recreation instructions. Re-did the fix
  cleanly on a fresh branch (repo-assist/eng-pin-github-script-action-v2), pinning
  actions/github-script@v7 to 3a2844b7e9c422d3c10d287c895573f7108da1b3 in
  .github/workflows/pr-artifacts.yml, added a CHANGELOG.md [Unreleased] entry, and successfully
  created the PR this time. Issue #1299 should be closed by maintainer once this PR merges.
- Task 5: re-reviewed the same outstanding `// TODO` markers (Array.fs growth/append-optimize,
  Attributes.fs conversion algorithm, Builders.fs addMut, ViewNode.fs handler combining,
  WidgetDiff.fs hot path) — none rose to a clearly beneficial, low-risk change worth a PR,
  same conclusion as prior runs.

## Currently open issues (7)
- #1299 - "[repo-assist] Pin actions/github-script..." — leftover from failed push last run;
  now superseded by the successfully-created PR this run. Flagged for maintainer to close.
- #1281 - Monthly Activity issue (Task 11 target, updated this run).
- #1143 - Welcome/intro post, no action needed.
- #1156 - Release announcement, no code action, awaiting timing.
- #1162, #1163, #1164 - QA tracking issues, awaiting human tester results, no bot action.

## Open PRs
- #1202 repo-assist/perf-sub-hashset (created 2026-08-29) - still holding per collaborator request.
- #1234 repo-assist/improve-stackarray3-combine (created 2026-08-30) - still holding.
- #1270 repo-assist/test-stackarray3-coverage (created 2026-08-31) - still holding.
- #1280 repo-assist/fix-summary-xamarinforms-links (created 2026-09-02) - docs fix for #1278.
- NEW: repo-assist/eng-pin-github-script-action-v2 (created 2026-09-04) - pins
  actions/github-script to commit SHA in pr-artifacts.yml. Docs/workflow-only, no build needed.
  This supersedes the abandoned attempt that became issue #1299.

## Backlog / follow-ups for next run
- Verify whether the new "eng-pin-github-script-action-v2" PR pushed/created successfully
  (check it shows up in the PR list next run); if not, investigate push failures further.
- Before creating any new perf/coding PRs (Tasks 5/8): check whether #1202/#1234/#1270 have been
  merged/closed or the QA hold has been lifted by a maintainer comment.
- Suggest maintainer close issue #1299 once the new PR is reviewed/merged (duplicate/leftover
  from a failed push).
- TODO markers survey still pending (Array.fs ~622, Attributes.fs SmallScalars.Int, Builders.fs
  ~244, ViewNode.fs ~18, WidgetDiff.fs ~43) — author's own comments suggest no perf difference,
  likely not worth pursuing.
- Test coverage gaps: Memo.fs, Reconciler.fs, WidgetDiff.fs still have no dedicated test files.

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
- repo-assist/eng-pin-github-script-action-20260903 (2026-09-03): FAILED TO PUSH — became
  issue #1299 instead of a PR.
- repo-assist/eng-pin-github-script-action-v2 (2026-09-04): Pinned actions/github-script to
  commit SHA in .github/workflows/pr-artifacts.yml (re-attempt of 2026-09-03's failed push).
  Docs/workflow-only, no build/test needed. Supersedes issue #1299.
