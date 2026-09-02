# Repo Assist Memory

Last updated: 2026-09-02 (run https://github.com/fabulous-dev/Fabulous/actions/runs/33695073446)

## Task selection this run
Selected: [10 (Take the Repository Forward), 3 (Issue Investigation and Fix), 8 (Performance Improvements)].
- Substituted: Task 3 was executed as a documentation fix rather than a code bug fix — the only
  actionable "fixable" item found was the broken xamarinforms/*.md links in docs/api/SUMMARY.md,
  flagged by a new documentation-scan issue #1278 (created via /repo-assist command by
  @MiroslavHustak, already answered by the command-mode run). Task 8/10 had no new actionable
  items beyond what's already queued/blocked (see below) — treated as "no new work" and folded
  into completing #1278's actionable finding instead, per Progress Imperative.
- Created PR fixing #1278's one actionable finding: removed stale Xamarin.Forms section (~40
  broken links) from docs/api/SUMMARY.md. Docs-only change, no build/test needed.
- The 3 open repo-assist PRs (#1202, #1234, #1270) still carry the collaborator's "hold off
  until canary/QA completes" comment from late August — no new comment/update since. Continuing
  to respect the hold; did not push updates or nudge.
- Reviewed all issues; no unlabelled issues besides #1278 (already unlabelled — no fitting label
  applied since it's a completed one-off scan request, not an ongoing bug/enhancement).

## Currently open issues (7)
- #1278 - Documentation scan request (command-mode), answered with findings comment; this run's
  PR closes its one actionable item (broken xamarinforms links). No further action needed unless
  maintainer asks about the other cosmetic findings (legacy-page trailing whitespace - low value).
- #1147 - Monthly Activity issue itself (Task 11 target, updated this run).
- #1143 - Welcome/intro post, no action needed.
- #1156 - Release announcement, no code action, awaiting timing.
- #1162, #1163, #1164 - QA tracking issues, awaiting human tester results, no bot action.

## Open PRs
- #1202 repo-assist/perf-sub-hashset (created 2026-08-29) - still holding per collaborator request.
- #1234 repo-assist/improve-stackarray3-combine (created 2026-08-30) - still holding.
- #1270 repo-assist/test-stackarray3-coverage (created 2026-08-31) - still holding.
- NEW: repo-assist/fix-summary-xamarinforms-links (created 2026-09-02) - docs fix for #1278.

## Backlog / follow-ups for next run
- Before creating any new perf/coding PRs (Tasks 5/8): check whether #1202/#1234/#1270 have been
  merged/closed or the QA hold has been lifted by a maintainer comment.
- Monitor the new docs PR (fix-summary-xamarinforms-links) for CI/review status.
- TODO markers survey still pending (Array.fs ~622, Attributes.fs SmallScalars.Int, Builders.fs
  ~244, ViewNode.fs ~18, WidgetDiff.fs ~43) — author's own comments suggest no perf difference,
  likely not worth pursuing.
- Test coverage gaps: Memo.fs, Reconciler.fs, WidgetDiff.fs still have no dedicated test files.
- Other cosmetic doc findings from #1278 (trailing whitespace in legacy-marked pages under
  docs/advanced and docs/samples-and-tutorials) - explicitly low priority/excluded from
  published docs, not worth a dedicated PR.

## Comments made log
- No new issue comments made this run (command-mode /repo-assist on #1278 was already answered
  by a separate command-mode workflow run before this scheduled run started).

## PRs created log
- repo-assist/perf-sub-hashset (2026-08-29): Sub.fs HashSet optimization + tests. Still open (#1202).
- repo-assist/improve-stackarray3-combine (2026-08-30): StackArray3.combine allocation
  optimization + test. Still open (#1234).
- repo-assist/test-stackarray3-coverage (2026-08-31): StackArray3 add/get/find/combine unit
  tests (7 new tests). Still open (#1270).
- repo-assist/fix-summary-xamarinforms-links (2026-09-02): Removed stale Xamarin.Forms broken
  links section from docs/api/SUMMARY.md, closes #1278's actionable finding.
