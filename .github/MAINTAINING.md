# Maintaining

## Releasing

Before releasing a new version, add a new entry at the top of [RELEASE_NOTES.md](RELEASE_NOTES.md).  
FAKE will use that version when building, and these release notes will be attributed to the NuGet packages description as well as the GitHub Release that will be created later.

Once done, open a terminal to let FAKE update the package version where needed:

On OSX:
```
./build.sh UpdateVersion
```

On Windows:
```
.\build UpdateVersion
```

FAKE will have updated `Directory.Build.props`, `Fabulous.XamarinForms.nuspec`, nuspec files of the Fabulous.XamarinForms extensions and `template.json`. Commit all changes.

Create a branch named `release/X.Y.Z` (where X.Y.Z is the version number you want Fabulous to be)  
And start a pull request for this branch back to `master`.  
Include in the PR message all the pull requests numbers that will be part of the release. (see for example: https://github.com/fsprojects/Fabulous/pull/463)

After merging in master with GitHub, the automated build pipeline will create a new GitHub Release for the specified version (and release notes) and publish all packages to NuGet automatically.

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

Every pull request is automatically valided with a partial build on a Windows agent (compile) and a full build on a macOS agent (compile and test)  
If needed, collaborators and owners of this repository can run a full build on Windows, macOS and Linux by commenting `/azp run full build` in a pull request.

All commits in master (like merged PRs) are built with a full build (Windows, macOS and Linux)
