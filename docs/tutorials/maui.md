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

For local Windows development, we recommend an unpackaged application:

1. In your `.fsproj`, add the following lines into the main `<PropertyGroup>`:

```xml
   <WindowsPackageType>None</WindowsPackageType>

   <!-- F#: avoid WASDK injecting a .cs auto-initializer (FS0226) -->
   <WindowsAppSdkUndockedRegFreeWinRTInitialize>false</WindowsAppSdkUndockedRegFreeWinRTInitialize>
```

2. In `Properties/launchSettings.json`, use the `Project` command (not `MsixPackage`):

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

3. Build and run:

```bash
   dotnet build -f net10.0-windows10.0.19041.0 -c Debug
   dotnet run   -f net10.0-windows10.0.19041.0 -c Debug
```

Unpackaged builds skip MSIX packaging entirely, which avoids the deployment issues described [below](#debugging-on-windows-from-visual-studio) and gives a much faster edit-build-run cycle. See [deployment](../guides/deployment.md) for packaging and store publishing details.

The generated project contains platform hosts and an `App.fs` with the application logic. Compare it with the maintained [MAUI CounterApp](https://github.com/fabulous-dev/Fabulous/blob/main/samples/maui/CounterApp/App.fs), which demonstrates model, messages, asynchronous commands, layouts, controls, events, and modifiers in one compiled file.

## Debugging on Windows from Visual Studio

Once your project is unpackaged (see [Create and run](#create-and-run)), debugging in Visual Studio is straightforward:

1. Open the solution on a Windows machine.
2. Make sure the **Windows Machine** profile and the `net10.0-windows10.0.19041.0` target are selected in the toolbar.
3. Leave the Solution Platform (the dropdown next to `Debug`/`Release`) on **Any CPU**.
4. Run a build
5. Press **F5**.

This only works with the unpackaged setup. If `WindowsPackageType` is still the default (`MSIX`), or `launchSettings.json` still uses `MsixPackage`, F5 will hit the packaged deployment problems described below.

Visual Studio's Solution Platform is tracked in the `.sln` file and is completely independent of any `RuntimeIdentifier`/`Platform` set in the `.fsproj`. It defaults to `Any CPU`, and unpackaged apps don't need an architecture-specific host, so that default works.

#### Why not packaged (MSIX)?

A packaged Windows app host cannot be architecture-neutral. MSIX requires a concrete architecture, enforced by the Windows App SDK build pipeline rather than by Fabulous. In Visual Studio, this interacts badly with Solution Platform, intermediate output paths, splash-screen packaging, and Appx deployment, so F5 debugging of packaged Fabulous/F# apps is not currently reliable.

Typical failures include a missing `splashSplashScreen.png` (`DEP0700`), a missing `.appxrecipe`, activation/registration errors, and path mismatches when Solution Platform is switched to `x64`.

Use packaged builds only when you need MSIX-specific features, and test them outside the Visual Studio F5 flow.

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
