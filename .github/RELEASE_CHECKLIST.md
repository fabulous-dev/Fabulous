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

## Deprecation warning triage

The `Build and test` job for the 10.0.0 candidate (commit `4a930280`, [run 32787985509](https://github.com/fabulous-dev/Fabulous/actions/runs/32787985509)) reported 60 `FS0044` deprecation warnings across 25 source locations. Grouped by message, they break down as follows:

| Warning | Occurrences | Source |
| --- | --- | --- |
| `EntryCell` (`ListView`/`TableView`) is obsolete; use `CollectionView` instead | 36 | `src/maui/Fabulous.MauiControls/Views/Cells/EntryCell.fs` |
| `SwitchCell` (`ListView`/`TableView`) is obsolete; use `CollectionView` instead | 14 | `src/maui/Fabulous.MauiControls/Views/Cells/SwitchCell.fs` |
| `Page.IsBusy` deprecated, will be removed in .NET 11 | 2 | `src/maui/Fabulous.MauiControls/Views/Pages/_Page.fs`, `ContentPage.fs` |
| Use `SafeAreaEdges` attached property instead of per-edge safe area control | 4 | `src/maui/Fabulous.MauiControls/Views/Layouts/_Layout.fs` |
| Use `SafeAreaElement.IgnoreSafeArea` attached property instead of per-edge safe area control | 4 | `src/maui/Fabulous.MauiControls/Views/Layouts/_Layout.fs` |

All 60 warnings originate from `Microsoft.Maui.Controls` `[Obsolete]` attributes on `EntryCell`, `SwitchCell`, `Page.IsBusy`, and legacy per-edge safe-area properties in the MAUI 10.0.100 baseline that ships with the supported MAUI 10 release. None of these APIs have been *removed* from that baseline — MAUI 10 still ships them as compile-time obsolete members for backward compatibility, so the current Fabulous bindings continue to build and function correctly. No API removal or breaking change is required to ship 10.0.0.

Fabulous intentionally still exposes bindings for `EntryCell` and `SwitchCell` (used only inside legacy `ListView`/`TableView` hosts) and the older per-edge safe-area modifiers for apps migrating from earlier Fabulous/Xamarin.Forms code. Removing these bindings, or suppressing the warnings, is tracked as a follow-up cleanup and is not a release blocker.

## Publication

Trusted publishing is intentionally not exercised by pull-request CI. After the version-policy issue is resolved, use a dedicated `10.0.x-pre.N` changelog section to verify OIDC publishing. Confirm package ownership and artifact hashes before approving the release workflow.

## Rollback and yank

NuGet packages are immutable and cannot be overwritten.

1. Cancel the Release workflow before the NuGet push step whenever possible.
2. If cancellation occurs before any package is published, leave the version untagged; the next `main` push retries it from the newer commit.
3. If only some packages were published, do not reuse that version. Record the affected package IDs and prepare the next higher version.
4. If a published version is defective, unlist every package at that version on NuGet.org and add a deprecation message pointing to the replacement.
5. Mark the GitHub release as a prerelease or remove it if no package was published. Never move an existing tag to different source.
6. Restore documentation by reverting the Pages source commit; do not edit generated Pages output.
7. Add a changelog entry for the replacement version, rerun the complete candidate checklist, and publish a new version.
8. Record affected package IDs, timestamps, NuGet/GitHub actions, customer impact, and the replacement version in an incident issue.