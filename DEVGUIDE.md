# Contributing

Contributing is easy:

1. [Fork](https://help.github.com/articles/fork-a-repo/) the repository
2. Create a new branch for the feature/fix and give it an appropriate name, e.g. `my_fabulous_fix`
3. Do your best work
4. Build/Test as per the below
5. Create a pull request back to `Fabulous/master`

# Dev Notes

## Dev Notes - Prerequisites

- Visual Studio 2017 / Visual Studio for Mac 7 or newer
- Xamarin SDK (Visual Studio Workload: Mobile Development with .NET)
- .NET Core SDK 2.2.100 or newer (or Visual Studio Workload: .NET Desktop Development -> .NET Core 2.2 development tools)

For more information, please refer to the Xamarin.Forms requirements.
https://docs.microsoft.com/en-us/xamarin/xamarin-forms/get-started/installation

.NET Core SDK 2.2.100 or newer is required for building .NET Core 2.2 projects. (e.g. Fabulous.XamarinForms generator)

## Dev Notes - Building

Fabulous is built with FAKE 5.

Fabulous can be built with a single command.  
It will take care of every steps: install FAKE, clean, restore, build and pack.

On OSX:

```
./build.sh
```

On Windows:

```
.\build
```

It is recommended to run this command at least once before working on Fabulous, as some of the code will be generated.
At minimum, you need to run `.\build RunGeneratorForFabulousXamarinForms` to ensure that you have all the dependencies before opening Visual Studio.

## Dev Notes - Running the generator

The Generator is built and run as part of the default build command
If you only want to build the tools and run the generator, use the following commands.

**Please run the generator if there are build errors related to "Missing Xamarin.Forms.Core.fs".**

On OSX:

```
./build.sh RunGeneratorForFabulousXamarinForms
```

On Windows:

```
.\build RunGeneratorForFabulousXamarinForms
```

## Dev Notes - Testing

On OSX:

```
./build.sh Test
```

On Windows:

```
.\build Test
```

## Dev Notes - Testing LiveUpdate

Use the CounterApp to test.  To run the equivalent of the `fabulous` CLI tool use this:

    cd Fabulous.XamarinForms\samples\CounterApp\CounterApp
    adb -d forward  tcp:9867 tcp:9867
    dotnet run --project ..\..\..\..\src\Fabulous.Cli\Fabulous.Cli.fsproj -- --watch --send 

If you want to update your (global!) install of the `fabulous-cli` tool, first bump the version number to avoid clashes, then:

    dotnet pack src\Fabulous.Cli
    dotnet tool uninstall --global fabulous-cli  
    dotnet tool install --global --add-source C:\GitHub\dsyme\Fabulous\src\Fabulous.Cli\bin\Debug\ fabulous-cli
    fabulous --watch --send

## Dev Notes - Releasing

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

## Dev Notes - Configuring GitHub and NuGet on Azure DevOps

To enable the automatic creation of a GitHub Release and automatic publication on NuGet, 2 variables need to be defined in the build pipeline settings on Azure DevOps.

On Azure DevOps, open the build variables of the `Full Build` pipeline (which runs everytime a PR is merged in `master`)  
[Direct link to Azure DevOps](https://dev.azure.com/timothelariviere/Fabulous/_apps/hub/ms.vss-ciworkflow.build-ci-hub?_a=edit-build-definition&id=7&view=Tab_Variables)

Set the following variables:
- `github_token`: Your GitHub Personal Access Token with `repo` and `admin:org` scopes ([Creating a GitHub Personal Access Token](https://help.github.com/en/articles/creating-a-personal-access-token-for-the-command-line))
- `nuget_apikey`: Your NuGet API Key with push rights for all Fabulous packages

## Dev Notes - Checking App Size

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

## Dev Notes - Continuous Integration builds

This repository uses several Azure DevOps pipelines to ensure the code always builds correctly and prepare NuGet packages.

Every pull request is automatically valided with a partial build on a Windows agent (compile) and a full build on a macOS agent (compile and test)  
If needed, collaborators and owners of this repository can run a full build on Windows, macOS and Linux by commenting `/azp run full build` in a pull request.

All commits in master (like merged PRs) are built with a full build (Windows, macOS and Linux)
