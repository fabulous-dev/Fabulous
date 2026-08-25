# Repo Assist Memory

## Status
- Repo was freshly reset/unified (issue #1143, "Welcome" post, created 2026-08-24). No prior history to draw on.

## Issues
- #1143: Welcome/intro issue, no action required (not a bug/feature request). Labelled `documentation`. Reviewed 2026-08-24, 2026-08-25.
- #1156: 10.0.0 release announcement. Labelled `documentation`.
- #1148: Release blockers/signoff tracking issue (has sub-issues #1162/#1163/#1164 QA tracking). Labelled `needs triage`. Still has open checklist items (manual product signoff, doc verification, deprecation warning triage). Not fixable by Repo Assist directly — needs human testers.
- #1166: Website links to archived repos (Fabulous.MauiControls/XamarinForms/Avalonia) + outdated commercial-support section. FIXED 2026-08-25: opened PR "Fix website links to archived repos and remove outdated commercial support section" (branch repo-assist/fix-issue-1166-website-links), commented linking PR. Labelled `documentation`, `bug`.

## PRs
- repo-assist/fix-issue-1166-website-links (2026-08-25): fixes #1166, edits website/layouts/index.html + CHANGELOG.md. Draft PR, no Hugo available locally to build-verify; low risk template edit.
- #1167 (community, non-Repo-Assist): "Fix typo in get-started.md" — noted for maintainer review, not actioned by Repo Assist.

## Investigation notes for future work (Task 10 candidates)
- src/neutral/Fabulous.Core/WidgetDiff.fs:43 — TODO: hot-path skip-repeating-scalars function; author unsure if more optimal approach exists. Potential perf investigation (Task 8) but needs benchmarks before touching hot path.
- src/neutral/Fabulous.Core/Array.fs:393-394 — TODO: optimize Array.append paths in `Few`/`Many` cases.
- src/neutral/Fabulous.Core/Array.fs:622 — TODO: handle growth (unclear scope, needs investigation to define exact issue).
- src/neutral/Fabulous.Core/Builders.fs:244 — TODO: optimize with addMut.
- src/neutral/Fabulous.Core/Attributes.fs:45 — TODO: better conversion algorithm question, low priority.
- src/neutral/Fabulous.Core/ViewNode.fs:18 — TODO: consider combining handlers mapMsg and property bag; would need design discussion, possibly breaking change.

None of these are yet turned into fixes since they need benchmarks/careful validation before a surgical, low-risk PR could be made confidently. Next run: pick one (e.g. Array.fs growth handling) and investigate feasibility of a safe, tested improvement.

## Comments made
(none yet)

## Fix attempts
(none yet)

## Backlog cursor
- Issue list cursor: reached end of open issues as of 2026-08-25 (8 open: #1143, #1147, #1148, #1156, #1162, #1163, #1164, #1166). Next run: resume review from #1162/#1163/#1164 (QA tracking sub-issues, needs triage/documentation labels already present) — check if any new human comments; also watch for new issues after #1166.

## Monthly Activity Issue
- #1147 "[repo-assist] Monthly Activity 2026-08" — updated 2026-08-25 with run history entry for this run (PR for #1166, labelling of #1143/#1148/#1156/#1166).
