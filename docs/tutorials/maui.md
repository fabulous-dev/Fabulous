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

On Windows, the generated project also targets `net10.0-windows10.0.19041.0` (added automatically when the workload runs on Windows, or unconditionally with `-p:FabulousWindowsOnly=true`). Build and run/debug that target directly instead of using an Android emulator:

```bash
dotnet build -f net10.0-windows10.0.19041.0
dotnet build -f net10.0-windows10.0.19041.0 -t:Run
```

The `-t:Run` target launches and deploys the app; to debug from an IDE (Visual Studio or the C#/F# Dev Kit in VS Code), set the project's target framework to `net10.0-windows10.0.19041.0` and start debugging as usual. See [deployment](../guides/deployment.md) for packaging and store publishing details.

The generated project contains platform hosts and an `App.fs` with the application logic. Compare it with the maintained [MAUI CounterApp](https://github.com/fabulous-dev/Fabulous/blob/main/samples/maui/CounterApp/App.fs), which demonstrates model, messages, asynchronous commands, layouts, controls, events, and modifiers in one compiled file.

## Debugging on Windows from Visual Studio

Visual Studio has its own Solution Platform selector (the dropdown next to the `Debug/Release` configuration in the toolbar), tracked in the `.sln` file and completely independent of any `RuntimeIdentifier/Platform` set in the `.fsproj`. It defaults to `Any CPU`. Because a packaged Windows app host cannot be `Any CPU`, leaving this at the default causes deployment to fail.

Therefore, before debugging on Windows in Visual Studio you shall:

1) Open `Build` > `Configuration Manager`.
 
Under `Active solution platform`, select `x64` — create it first if it isn't listed (`New...` > `x64`, copying settings from `Any CPU`). This is a Visual Studio / solution-file setting, not a project-file setting — it is not affected by `RuntimeIdentifier` or `Platform defaults` in the `.fsproj`, so this step is required regardless of the template version and cannot be fixed upstream in Fabulous.

2) Confirm your project's row shows `x64` under Platform.

Rebuild the solution (`Build` > `Rebuild Solution`), not an incremental build. Switching platforms after a prior `Any CPU` build can leave stale intermediate/output files that reproduce the same error even once the platform is set correctly. If rebuilding does not clear it, delete the `bin` and `obj` folders and rebuild again.

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
