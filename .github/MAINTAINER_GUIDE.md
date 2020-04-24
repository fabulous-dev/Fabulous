# Maintainer guide

## Keeping track of progress

In order to know what's the progress on the different bugs and features, we use the "Projects" tab.  
There, several projects are already created to manage the state of issues (To do, In progress, Review in progress, Reviewer approved, Done).

All new issues need to be associated to at least one project.

Planned issues and features are tracked using one of the 2 milestones, allowing to know when a release is possible.  
Once verified, issues need to be added to a milestone if work needs to be done.

### Projects

| Name | Description |
|------|-------------|
| CodeGen | Issues and features associated to Fabulous.CodeGen |
| Fabulous | Issues and features associated to Fabulous |
| Fabulous for Xamarin.Forms | Issues and features associated to Fabulous.XamarinForms |
| Fabulous.StaticView for Xamarin.Forms | Issues and features associated to Fabulous.StaticView.XamarinForms |
| Fabulous.XF Extensions | Issues and features associated to the extensions of Fabulous.XamarinForms |
| Repository maintenance | Housekeeping tasks of the repository |

### Milestones

| Name | Description |
|------|-------------|
| vCurrent | The current released version supported (non-breaking changes and bug fixes) |
| vNext | The next version planned to release (new features, breaking changes) |

## Issues

Each new issue needs to be associated at least with 1 type and 1 state labels.  
Area and platform labels are optionals, and can be used if applicable.

#### General

| Name | Description |
|------|-------------|
| duplicate | This issue or pull request already exists |
| good first issue | Good for newcomers |
| help wanted | The issue is up-for-grabs |
| wont fix | The issue won't be fixed |

#### Types

| Name | Description |
|------|-------------|
| t/bug | Something isn't working as expected |
| t/discussion | A subject is being debated |
| t/enhancement | New feature or request |
| t/housekeeping | This is a repository maintenance task |

#### States

| Name | Description |
|------|-------------|
| s/external | The issue is related to an external bug / missing feature |
| s/needs infos | The issue needs to be completed |
| s/needs repro | The issue needs a reproduction |
| s/ready | This issue is ready to be implemented |
| s/unverified | The issue has not been verified yet |
| s/waiting for external | This issue is currently blocked until an external factor is resolved |

#### Areas

Areas indicate if the issue is on a specific part of the library. If it's the library itself that is concerned, no label is needed.

| Name | Description |
|------|-------------|
| a/docs | The issue is regarding the documentation |
| a/liveupdate | The issue is regarding LiveUpdate |
| a/samples | The issue is regarding the samples |
| a/templates | The issue is regarding the templates |
| a/tests | The issue is regarding the unit tests |
| a/tools | The issue is regarding the tools |

#### Platforms (specific to Fabulous.XamarinForms / Fabulous.StaticView.XamarinForms)

| Name | Description |
|------|-------------|
| p/android | Android |
| p/gtk | GTK |
| p/ios | iOS |
| p/macos | macOS |
| p/uwp | UWP |
| p/webassembly | WebAssembly |
| p/wpf | WPF |

## Merging

When merging pull requests, we need to make sure the commits end up in the appropriate branch, depending on the release plans for those PRs.

Let's take for example a currently released version (still being maintained) `v1.0.0` and a next planned version `v2.0.0`.

| Branch name | Also known as | Description |
|-------------|----------|-------------|
| `v1`       | `vCurrent` | Latest released version, currently supported. We can add bug fixes, backwards compatible features, docs update but no breaking changes (and release a `v1.1.0` from it for example). |
| `v2`       | `vNext` | Next version to release. We can add new features we are sure to release next time. |
| `master`       | N/A | Nightly branch with all bug fixes and features not set to a particular version, published to MyGet on each commit. |

*N.B. The branch names are `v1`/`v2` not `vCurrent`/`vNext`, that way when a `v3` comes we don't have to rename everything.*

To make sure commits are correctly retrieved across branches (e.g. a bug fix should be in all branches), we follow some rules:

- After a PR is merged in `vCurrent`, we merge `vCurrent` in `vNext`.
- After a PR is merged in `vNext` (applies to the merge of `vCurrent` too), we merge `vNext` in `master`.
- Any PR merged in `master` stays in `master`

That way, we have the correct commits in all the appropriate branches.  
Those merges should be done regularly.

## Releasing

We follow the [SemVer 2.0.0](https://semver.org/spec/v2.0.0.html) specifications when creating a new version number.  
`vNext` versions should use the appropriate qualifier. E.g. `v2.0.0-alpha1` or `v2.0.0-beta2`.

`vCurrent` and `vNext` will automatically be released on NuGet when creating a git tag on one of their commits with the command line `git tag -a X.Y.Z`.

Before releasing a new version, add a new entry at the top of [RELEASE_NOTES.md](../RELEASE_NOTES.md).  
FAKE will use that version when building, and these release notes will be attributed to the NuGet packages description as well as the GitHub Release that will be created later.

Once done, open a terminal to let FAKE update the package version where needed:

| Platform | Command |
|----------|---------|
| Unix (Linux & macOS) | `./build.sh UpdateVersion` |
| Windows | `.\build UpdateVersion` |

FAKE will have updated `Directory.Build.props`, `Fabulous.XamarinForms.nuspec`, nuspec files of the Fabulous.XamarinForms extensions and `template.json`. Commit all changes.

Send a pull request for these changes back to the branch you want to release.  
Include in the PR message all the pull requests numbers that will be part of the release. (see for example: https://github.com/fsprojects/Fabulous/pull/463)

After the PR is merged, create a tag on the last commit. Azure DevOps will automatically build the branch, create a GitHub release and publish all packages to NuGet from this tag.

## Configuring GitHub and NuGet on Azure DevOps

To enable the automatic creation of a GitHub Release and automatic publication on NuGet, 2 variables need to be defined in the build pipeline settings on Azure DevOps.

On Azure DevOps, open the build variables of the `Full Build` pipeline (which runs everytime a PR is merged in `master`)  
[Direct link to Azure DevOps](https://dev.azure.com/timothelariviere/Fabulous/_apps/hub/ms.vss-ciworkflow.build-ci-hub?_a=edit-build-definition&id=7&view=Tab_Variables)

Set the following variables:
- `github_token`: Your GitHub Personal Access Token with `repo` and `admin:org` scopes ([Creating a GitHub Personal Access Token](https://help.github.com/en/articles/creating-a-personal-access-token-for-the-command-line))
- `nuget_apikey`: Your NuGet API Key with push rights for all Fabulous packages

## Checking App Size

It is worth occasionally checking that unused code is trimmed from the Android and iOS app packagings by the Mono linker.
There is [one known issue with this](https://github.com/fsprojects/Fabulous/issues/94).

App size on Android is checked by

1. build + deploying `Fabulous.XamarinForms\samples\CounterApp` (to device or emulator)
2. renaming and unziping `Fabulous.XamarinForms\samples\CounterApp\Droid\bin\Release\org.fabulous.CounterApp.apk`
3. checking sizes and contents of

       Fabulous.XamarinForms\samples\CounterApp\Droid\bin\Release\org.fabulous.AllControls\assemblies\FSharp.Core.dll
       Fabulous.XamarinForms\samples\CounterApp\Droid\bin\Release\org.fabulous.AllControls\assemblies\Fabulous.Core.dll

   e.g. see [this comment](https://github.com/fsprojects/Fabulous/issues/94#issuecomment-402157490)

Smallest app size is produced by

* "Generate one package per ABI"
* "Enable ProGuard"
* "Linking: Sdk and User assemblies"
* Disable debug instrumentation

![app size](https://user-images.githubusercontent.com/7204669/42222786-1096c20a-7ece-11e8-99d6-e1c63a6a2f30.png)

Also check the app actually runs with these settings.

## Continuous Integration builds

This repository uses several Azure DevOps pipelines to ensure the code always builds correctly and prepare NuGet packages.

Every pull request is automatically validated with a partial build on a Windows agent (compile) and a full build on a macOS agent (compile and test)  
If needed, collaborators and owners of this repository can run a full build on Windows, macOS and Linux by commenting `/azp run full build` in a pull request.

All commits in master (like merged PRs) are built with a full build (Windows, macOS and Linux)

## Other readings

- [Getting started](GETTING_STARTED.md)
- [Contributor guide](CONTRIBUTING.md)