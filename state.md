# Repo Assist Memory

Last updated: 2026-08-28 (run https://github.com/fabulous-dev/Fabulous/actions/runs/33220311002)

## Reconciliation note
Live state re-verified this run via GitHub API. Open issues (7): #1143, #1147, #1156,
#1162, #1163, #1164, #1171. No open PRs at all (repo-assist or otherwise).

## Currently open issues
- #1147 - Monthly Activity issue itself (Task 11 target).
- #1143 - Welcome/intro post, no action needed.
- #1156 - Release announcement, no code action, awaiting timing.
- #1162, #1163, #1164 - QA tracking issues, awaiting human tester results, no bot action.
- #1171 - MAUI tutorial NU1605 downgrade warning. Maintainer (dsyme) explicitly asked on
  2026-08-28 to re-verify by ACTUALLY running `dotnet new` and inspecting output, not just
  trusting memory/diffs. Done this run:
    - Installed `fabulous-mauicontrols` template from templates/maui/content/blank (main).
    - Ran `dotnet new fabulous-mauicontrols -n VerifyApp`; generated .fsproj pins
      Microsoft.Maui.Controls / .Compatibility to 10.0.100 (not old 8.0.14).
    - MAUI workloads not installable in sandbox, so isolated the NuGet resolution logic in
      a minimal repro project (Fabulous.MauiControls 10.0.0 + the two Maui packages):
      pinned 8.0.14 -> reproduces exact NU1605 text from issue; pinned 10.0.100 -> zero
      warnings on `dotnet restore`. This ties generated-project version to symptom
      presence/absence directly (stronger evidence than prior run's diff-only check).
    - Posted verification comment on #1171 recommending maintainer close it.
    - No further code change needed; template fix (from earlier PR #1177 / commit d06cdd00)
      is confirmed effective for freshly generated MAUI apps.
  Cleaned up all temp verification directories and uninstalled the temp template afterward.

## Open PRs
None currently open (repo-assist or otherwise).

## Task selection this run
Selected: [2 (Issue Comment), 9 (Testing Improvements), 3 (Issue Fix)].
- Task 2: satisfied by the #1171 re-verification comment (substantive, not a rubber-stamp).
- Task 3: #1171 was the only bug-labelled issue; already fixed/verified, no code change
  needed this run (verification-only task, not a code fix).
- Task 9: not separately actioned this run due to time budget; deferred to next run -
  revisit StackArray3 test coverage (see below) and look for other test gaps.

## Backlog / follow-ups for next run
- StackArray3 (src/neutral/Fabulous.Core/Array.fs) has no call sites elsewhere in the
  codebase - worth checking whether it's dead/preparatory code or intended for future
  wiring (noted in a previous run, still unresolved).
- Re-check whether maintainer closes #1171 after this run's verification comment; if not
  closed and no new activity, no further action needed (comment already posted).
- No unlabelled issues; no stale non-repo-assist PRs (there are no open PRs at all).
- Consider Task 9 (testing improvements) more thoroughly next run given it was selected
  but not deeply pursued this run.

## Comments made log
- #1171 (2026-08-28, this run): posted detailed re-verification comment with dotnet new +
  isolated NuGet restore repro proving the fix works, per maintainer's explicit request.
