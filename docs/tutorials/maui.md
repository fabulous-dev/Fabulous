# Build a .NET MAUI app

This tutorial creates, changes, tests, and publishes a Fabulous 10 application. MAUI development requires a [.NET SDK and MAUI workload](https://learn.microsoft.com/dotnet/maui/get-started/installation); Android needs an SDK/emulator, Apple targets require macOS and Xcode, and Windows needs Windows with the MAUI workload.

## Create and run

Install the current template and confirm that NuGet selected a `10.0.x` version:

```bash
dotnet workload install maui
dotnet new install Fabulous.MauiControls.Templates
dotnet new fabulous-mauicontrols -n Counter
cd Counter
dotnet restore
dotnet build -f net10.0-android
dotnet build -f net10.0-android -t:Run
```

On Windows, the generated project also targets `net10.0-windows10.0.19041.0` (added automatically when the workload runs on Windows, or unconditionally with `-p:FabulousWindowsOnly=true`).

For local Windows development, we recommend using an unpackaged application.

1. In your `.fsproj`, add the following lines into the main `<PropertyGroup>`:

```xml
   <WindowsPackageType>None</WindowsPackageType>

   <!-- F#: avoid WASDK injecting a .cs auto-initializer (FS0226) -->
   <WindowsAppSdkUndockedRegFreeWinRTInitialize>false</WindowsAppSdkUndockedRegFreeWinRTInitialize>
```

2. In `Properties/launchSettings.json`, the json shall be like this:

```json
   {
     "profiles": {
       "Windows Machine": {
         "commandName": "Project",
         "nativeDebugging": false
       }
     }
   }
```

   Use `"commandName": "Project"` (not `"MsixPackage"`).

Then build and run:

```bash
dotnet build -f net10.0-windows10.0.19041.0
dotnet run   -f net10.0-windows10.0.19041.0
```

Unpackaged builds avoid the Windows App SDK/MSIX deployment issues discussed below and provide a faster edit-build-run cycle during development.
See [deployment](../guides/deployment.md) for packaging and store publishing details.

The generated project contains platform hosts and an `App.fs` with the application logic. Compare it with the maintained [MAUI CounterApp](https://github.com/fabulous-dev/Fabulous/blob/main/samples/maui/CounterApp/App.fs), which demonstrates model, messages, asynchronous commands, layouts, controls, events, and modifiers in one compiled file.

## Debugging on Windows from Visual Studio

This section applies when running Visual Studio directly on a Windows machine to debug the `net10.0-windows10.0.19041.0` target.

Visual Studio has its own Solution Platform selector (the dropdown next to the `Debug`/`Release` configuration in the toolbar), tracked in the `.sln` file and completely independent of any `RuntimeIdentifier`/`Platform` set in the `.fsproj`. It defaults to `Any CPU`.

#### Packaged apps (`WindowsPackageType=MSIX`, the default)

A packaged Windows app host cannot be architecture-neutral — MSIX requires a concrete architecture, enforced by the Windows App SDK build pipeline itself, not by Fabulous. In Visual Studio, this requirement interacts badly with Solution Platform, intermediate output paths, splash-screen packaging, and Appx deployment. In practice, reliable F5 debugging of packaged Fabulous/F# MAUI Windows apps from Visual Studio is not something we can currently document as working.

Typical failures include a missing `splashSplashScreen.png` (`DEP0700`), a missing `.appxrecipe`, activation/registration errors, and path mismatches when Solution Platform is switched to `x64`.

For local development, switch to unpackaged (recommended for both CLI and Visual Studio development) instead of relying on packaged deployment.

#### Unpackaged apps (`<WindowsPackageType>None</WindowsPackageType>`)

This constraint doesn't apply — the MSIX-specific check never runs, so `Any CPU` debugging works fine. Unpackaged builds also skip the MSIX packaging step entirely, which speeds up local build/debug cycles considerably. Use this during development if you don't need MSIX-specific features.

1. In your `.fsproj`, add the following lines into the main `<PropertyGroup>`:

```xml
   <WindowsPackageType>None</WindowsPackageType>

   <!-- F#: avoid WASDK injecting a .cs auto-initializer (FS0226) -->
   <WindowsAppSdkUndockedRegFreeWinRTInitialize>false</WindowsAppSdkUndockedRegFreeWinRTInitialize>
```

2. In `Properties/launchSettings.json`, the json shall be like this:

```json
   {
     "profiles": {
       "Windows Machine": {
         "commandName": "Project",
         "nativeDebugging": false
       }
     }
   }
```

   Use `"commandName": "Project"` (not `"MsixPackage"`).

3. Run:

```bash
   dotnet build -f net10.0-windows10.0.19041.0 -c Debug
   dotnet run   -f net10.0-windows10.0.19041.0 -c Debug
```

   Or press F5 in Visual Studio with the Windows TFM selected. Leave Solution Platform on `Any CPU`.

## Follow the data flow

`init` creates the first model. A widget event dispatches a `Msg`; `update` returns the next model and any command; `view` describes the desired widget tree. `Program.statefulWithCmd init update |> Program.withView view` connects those functions. Fabulous reconciles the next widget tree with the live MAUI controls instead of rebuilding the whole native tree.

Try adding a message and button by following the existing `Increment` case. Keep side effects in a command, not in `view`, so `update` remains testable. See [programs and commands](../concepts/programs.md) for the three program constructors.

## Layout, interaction, and navigation

The CounterApp uses `VStack`, `HStack`, `Slider`, and modifiers such as `.padding(20.)`. For grid placement and child-message mapping, use the compiled [basic navigation sample](https://github.com/fabulous-dev/Fabulous/blob/main/samples/maui/Navigation/BasicNavigation/Sample.fs). The repository also has [component navigation](https://github.com/fabulous-dev/Fabulous/tree/main/samples/maui/Navigation/ComponentNavigation) and a [navigation path](https://github.com/fabulous-dev/Fabulous/tree/main/samples/maui/Navigation/NavigationPath) for history-oriented flows.

Build a richer application by choosing controls from the [MAUI Gallery](https://github.com/fabulous-dev/Fabulous/tree/main/samples/maui/Gallery) and checking their current builders in the [generated API inventory](https://fabulous-dev.github.io/Fabulous/docs/api/source-inventory/).

## Test and publish

Run a build before deploying:

```bash
dotnet build -c Release -f net10.0-android
dotnet publish -c Release -f net10.0-android
```

Signing, store packaging, iOS/Mac Catalyst, and Windows commands are covered in [deployment](../guides/deployment.md). Unit-test `init` and `update` using the pattern in [testing and debugging](../guides/testing-debugging.md).
