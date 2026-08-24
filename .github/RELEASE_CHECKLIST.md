# Fabulous 10 release-candidate checklist

This checklist is completed against a specific commit before a Fabulous 10 release. CI supplies package and screenshot artifacts; it does not publish, tag, or mutate NuGet.org.

## Automated evidence

- [ ] The `Build and test` workflow is green for the candidate commit.
- [ ] All 13 `.nupkg` files and all 11 library `.snupkg` files are present in the `Packages` artifact.
- [ ] Package archive, dependency, SDK compatibility, and SourceLink checks pass.
- [ ] All Avalonia desktop samples and blank, desktop, and multi-project templates build.
- [ ] MAUI Android, iOS, Mac Catalyst, and Windows samples build on their native hosted runners.
- [ ] Android, Mac Catalyst, and Windows launch jobs prove that the sample process remains alive after startup.
- [ ] Clean Avalonia and MAUI template consumers restore only from the candidate artifact and NuGet.org.
- [ ] The Pages build passes authored-documentation, API-reference, and internal-link validation.

Record the candidate commit, workflow URL, package artifact URL, screenshot artifact URL, and package version in the release issue. Do not reuse evidence from a different commit.

## Manual signoff

Download the workflow artifacts and test the Gallery plus one representative application on each supported desktop/mobile platform. Record the tester, operating system/device, and result for each row.

| Area | Required checks |
| --- | --- |
| Accessibility | Screen-reader names, keyboard traversal, focus visibility, text scaling, and contrast |
| Input | Pointer/touch, keyboard, text entry, selection, scrolling, and back navigation |
| Navigation | Push, pop, native back, repeated page instances, and deep-link restoration |
| Rendering | Startup, theme changes, layouts, images/fonts, virtualized collections, and dialogs |
| Lifecycle | Suspend/resume, window close/reopen where supported, and no startup or shutdown crash |

All failures must link to an issue or block the release. The maintainer approving release notes records approval in the release issue; approval is not inferred from a green build.

## Publication

Trusted publishing is intentionally not exercised by pull-request CI. After the version-policy issue is resolved, use a dedicated `10.0.x-pre.N` changelog section to verify OIDC publishing. Confirm package ownership and artifact hashes before approving the release workflow.

## Rollback and yank

NuGet packages are immutable and cannot be overwritten.

1. Cancel the Release workflow before the NuGet push step whenever possible.
2. If only some packages were published, finish publishing the same tested artifact set; do not rebuild the same version from a different commit.
3. If a published version is defective, unlist every package at that version on NuGet.org and add a deprecation message pointing to the replacement.
4. Mark the GitHub release as a prerelease or remove it if no package was published. Never move an existing tag to different source.
5. Restore documentation by reverting the Pages source commit; do not edit generated Pages output.
6. Add a changelog entry for the replacement version, rerun the complete candidate checklist, and publish a new version.
7. Record affected package IDs, timestamps, NuGet/GitHub actions, customer impact, and the replacement version in an incident issue.