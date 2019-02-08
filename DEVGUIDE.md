# Contributing

Contributing is easy:

1. [Fork](https://help.github.com/articles/fork-a-repo/) the repository
2. Create a new branch for the feature/fix and give it an appropriate name `my_fabulous_fix`
3. Do your best work
4. Build/Test as per the below
5. Create a pull request back to `Fabulous/master`

# Dev Notes

## Dev Notes - Prerequisites

- Visual Studio 2017 / Visual Studio for Mac 7
- Xamarin SDK (workload Mobile Development on Visual Studio)
- .NET Core SDK 2.1.300 or newer

For more information, please refer to the Xamarin.Forms requirements.
https://docs.microsoft.com/en-us/xamarin/xamarin-forms/get-started/installation

.NET Core SDK 2.1.300 or newer is required for SourceLink to work.
https://github.com/dotnet/sourcelink#prerequisites

## Dev Notes - Building

Fabulous is built with FAKE 5.  
Make sure you have it installed as a global tool before attempting to build  
https://fake.build/fake-gettingstarted.html

```
dotnet tool install fake-cli -g
```

Once done, you can build Fabulous with a single command.  
It will take care of every steps: clean, restore, build and pack.

On OSX:

```
./build.sh
```

On Windows:

```
.\build
```

It is recommended to run this command at least once before working on Fabulous.

Alternatively, you can run `.paket/paket.exe restore` and `dotnet restore` to ensure that you have all the dependencies before opening Visual Studio.

## Dev Notes - Running the generator

The Generator is built and run as part of the default build command
If you only want to build the tools and run the generator, use the following commands:

On OSX:

```
./build.sh RunGenerator
```

On Windows:

```
.\build RunGenerator
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

## Dev Notes - Releasing

Before releasing a new version, add a new entry at the top of [RELEASE_NOTES.md](RELEASE_NOTES.md) (FAKE will use that version when building).

NB.: If you're releasing the same version, you might need to do the following first:
* Run `git clean -xfd .`
* Remove all `Fabulous*` folders from `~/.nuget` (`%USERPROFILE%\.nuget` on Windows)

Once done, open a terminal to build the NuGet packages:

On OSX:
```
./build.sh
```

On Windows:
```
.\build
```

FAKE will have updated `Directory.Build.props` and `template.json`. Commit all changes.

Lastly, publish all the generated packages to NuGet by running these commands:

On OSX:
```
APIKEY=[Your personal NuGet API KEY]

mono .nuget/NuGet.exe push "build_output/Fabulous.*.nupkg" $APIKEY -Source https://www.nuget.org
```

On Windows (console):
```
set APIKEY=[Your personal NuGet API KEY]

.nuget\NuGet.exe push build_output\Fabulous.*.nupkg  %APIKEY% -Source https://www.nuget.org
```

## Dev Notes - Checking App Size

It is worth occasionally checking that unused code is trimmed from the Android and iOS app packagings by the Mono linker.
There is [one known issue with this](https://github.com/fsprojects/Fabulous/issues/94).

App size on Android is checked by

1. build + deploying `Samples\CounterApp` (to device or emulator)
2. renaming and unziping `Samples\CounterApp\Droid\bin\Release\com.companyname.CounterApp.apk`
3. checking sizes and contents of

       Samples\CounterApp\Droid\bin\Release\com.donsyme.AllControls\assemblies\FSharp.Core.dll
       Samples\CounterApp\Droid\bin\Release\com.donsyme.AllControls\assemblies\Fabulous.Core.dll

   e.g. see [this comment](https://github.com/fsprojects/Fabulous/issues/94#issuecomment-402157490)

Smallest app size is produced by

* "Generate one package per ABI"
* "Enable ProGuard"
* "Linking: Sdk and User assemblies"
* Disable debug instrumentation

![app size](https://user-images.githubusercontent.com/7204669/42222786-1096c20a-7ece-11e8-99d6-e1c63a6a2f30.png)

Also check the app actually runs with these settings.
