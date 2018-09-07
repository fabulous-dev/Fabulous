# Dev Notes

## Dev Notes - Building

On OSX:

```fsharp
mono .paket/paket.exe restore
dotnet restore
open Fabulous.sln
./build.sh NuGet
./build.sh Test
```

On Windows:

```
.paket\paket.exe restore
dotnet restore
start Fabulous.sln
.\build NuGet
.\build Test
```

## Dev Notes - Releasing

Before releasing a new version, the version number need to be updated in several places:

* Add a new entry at the top of [RELEASE_NOTES.md](RELEASE_NOTES.md) (FAKE will use that version when building)
* Replace the old version number in [tools.md](docs/tools.md)
* Update the default value of `ElmishXamarinFormsPkg` in [template.json](templates/content/blank/.template.config/template.json)
* Replace the old version number in [LiveUpdate.fs](Fabulous.LiveUpdate/LiveUpdate.fs)

NB.: If you're releasing the same version, you might need to do the following first:
* Run `git clean -xfd .`
* Remove all `Fabulous*` folders from `.nuget`

Once done, open a terminal to build the NuGet packages:

On OSX:
```
./build.sh NuGet
```

On Windows:
```
.\build NuGet
```

FAKE will have updated all the `AssemblyInfo.fs` files. Commit all changes.

Lastly, publish all the generated packages to NuGet by running these commands:

On OSX:
```
APIKEY=[Your personal NuGet API KEY]

mono .nuget/NuGet.exe push "build_output/Fabulous.*.nupkg" $APIKEY -Source https://www.nuget.org

cp build_output/Fabulous.*.nupkg  ~/Downloads
```

On Windows (console):
```
set APIKEY=[Your personal NuGet API KEY]

.nuget\NuGet.exe push build_output\Fabulous.*.nupkg  %APIKEY% -Source https://www.nuget.org

copy build_output\Fabulous.*.nupkg  %USERPROFILE%\Downloads
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
