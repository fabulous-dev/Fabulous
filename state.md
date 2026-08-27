# Repo Assist Memory

## Status
- Repo was freshly reset/unified (issue #1143, "Welcome" post, created 2026-08-24).

## Issues
- #1143: Welcome/intro issue, no action required. Labelled `documentation`.
- #1156: 10.0.0 release announcement. Labelled `documentation`.
- #1148: Release blockers/signoff tracking issue. Labelled `needs triage`. Needs human testers.
- #1166: Website links to archived repos + outdated commercial-support section. FIXED via PR #1168 (repo-assist/fix-issue-1166-website-links), still open for review.
- #1169: Welcome page — leftover editorial note + wrong "next steps" links. Labelled `documentation`, `good first issue` (2026-08-27). Commented acknowledging clean fix; left for community/maintainer to apply (reporter provided exact replacement text). Not yet fixed by Repo Assist.
- #1170: "Choose a backend" page — nav label vs "flavor" terminology mismatch, table links point to tutorials instead of get-started. Labelled `documentation`, `good first issue` (2026-08-27). Commented acknowledging clean fix. Not yet fixed by Repo Assist.
- #1171: MAUI tutorial NU1605 downgrade warning (template pinned `MicrosoftMauiControlsPkgVersion` default to 8.0.14 vs required >=10.0.100) + missing Windows run/debug guidance. Labelled `bug`, `documentation` (2026-08-27). FIXED part 1 (NU1605) via PR #1177 (branch repo-assist/fix-issue-1171-maui-template-version-eeb958e86e05448a, open). FIXED part 2 (Windows guidance) 2026-08-27 via PR on branch repo-assist/fix-issue-1171-windows-guidance, edits docs/tutorials/maui.md + CHANGELOG.md. Both parts now addressed; issue awaiting maintainer close/merge.

## PRs
- PR #1168 (repo-assist/fix-issue-1166-website-links, 2026-08-25): fixes #1166. Still open, awaiting review (protected-files warning re: CHANGELOG.md).
- PR #1177 (repo-assist/fix-issue-1171-maui-template-version-eeb958e86e05448a, 2026-08-27): fixes #1171 part 1 (NU1605 warning). Open, awaiting review.
- repo-assist/fix-issue-1171-windows-guidance (2026-08-27, triggered via /repo-assist comment on #1171): fixes #1171 part 2 (Windows run/debug docs). Draft PR created this run.
- #1167 (community, closed/merged): "Fix typo in get-started.md".

## Investigation notes for future work (Task 10 candidates)
- src/neutral/Fabulous.Core/WidgetDiff.fs:43 — TODO: hot-path skip-repeating-scalars function; needs benchmarks.
- src/neutral/Fabulous.Core/Array.fs:393-394, 622 — TODO: optimize Array.append / growth handling paths.
- src/neutral/Fabulous.Core/Builders.fs:244 — TODO: optimize with addMut.
- src/neutral/Fabulous.Core/Attributes.fs:45 — TODO: better conversion algorithm, low priority.
- src/neutral/Fabulous.Core/ViewNode.fs:18 — TODO: consider combining handlers mapMsg and property bag; possibly breaking change.
None yet turned into fixes; need benchmarks/careful validation first.

## Comments made
- #1166 (2026-08-25): linked fix PR #1168.
- #1169 (2026-08-27): acknowledged clean suggested fix, labelled.
- #1170 (2026-08-27): acknowledged clean suggested fix, labelled.
- #1171 (2026-08-27, run 33117468654, triggered via /repo-assist command): confirmed both parts fixed, linked PR #1177 (part 1) and new PR for part 2 (Windows guidance).

## Fix attempts
- #1166: PR #1168 (open).
- #1171 part 1: PR #1177 (open).
- #1171 part 2: PR on branch repo-assist/fix-issue-1171-windows-guidance (open, this run — command-mode trigger).

## Backlog cursor
- Issue list cursor: reached end of open issues as of 2026-08-27 (12 open: #1143,#1147,#1148,#1156,#1162,#1163,#1164,#1166,#1168,#1169,#1170,#1171). Next run: check #1162/#1163/#1164 QA tracking sub-issues for new human comments; check if #1168/new PR merged; consider fixing #1169/#1170 directly if untouched, and #1171 part 2 (Windows guidance).

## Monthly Activity Issue
- #1147 "[repo-assist] Monthly Activity 2026-08" — updated 2026-08-27 with run history entry (run 33027188500): new PR for #1171, labelling+comments on #1169/#1170/#1171.
