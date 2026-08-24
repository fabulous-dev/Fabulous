# Build an Avalonia app

This tutorial creates a desktop Fabulous 10 application, connects MVU state to Avalonia widgets, runs tests, and prepares a release build. Use the multi-platform template only when you also need Android or iOS hosts.

The template and standard Avalonia controls do not require a commercial control license. Avalonia also offers premium controls under a freemium model; read [Avalonia licensing](../avalonia/licensing.md) before adding extension controls.

## Create and run

```bash
dotnet new install Fabulous.Avalonia.Templates
dotnet new fabulous-avalonia -n Counter
cd Counter
dotnet restore
dotnet run -c Debug
```

Confirm that template installation selected a `10.0.x` package. The maintained [Avalonia MVU CounterApp](https://github.com/fabulous-dev/Fabulous/blob/main/samples/avalonia/Mvu/CounterApp/App.fs) is the reference implementation: it uses `Program.statefulWithCmd`, tracing, exception handling, `Component`, layouts, events, and modifiers. The app selects `DesktopApplication` or `SingleViewApplication` at compile time, so shared UI stays in one file while each target keeps a small native host.

## Change the app

Follow one message end to end: `Button("Increment", Increment)` dispatches `Increment`; `update` creates a model with a larger count; the component observes the program through `Context.Mvu`; and `TextBlock` receives the new value. Fabulous diffs that widget description against the previous one and updates the existing Avalonia controls.

Add another message and control using the same pattern. Use `VStack`, `HStack`, `Grid`, `Dock`, or `Canvas` according to the layout behavior you need. Modifiers such as `.centerHorizontal()` and `.margin(20.)` return a new typed widget builder and can be chained.

For larger flows, start with [basic navigation](https://github.com/fabulous-dev/Fabulous/tree/main/samples/avalonia/Mvu/Navigation/BasicNavigation), then compare [component navigation](https://github.com/fabulous-dev/Fabulous/tree/main/samples/avalonia/Mvu/Navigation/ComponentNavigation) and [navigation path](https://github.com/fabulous-dev/Fabulous/tree/main/samples/avalonia/Mvu/Navigation/NavigationPath). The [Gallery](https://github.com/fabulous-dev/Fabulous/tree/main/samples/avalonia/Gallery) is the compiled catalog for controls, styling, gestures, and extension packages.

## Test and publish

```bash
dotnet build -c Release
dotnet publish -c Release -f net8.0 -r linux-x64 --self-contained true
```

Before publishing, add pure update tests and an Avalonia headless test. The repository's [TestableApp](https://github.com/fabulous-dev/Fabulous/tree/main/samples/avalonia/TestableApp) demonstrates both and captures a screenshot artifact in CI; see [testing and debugging](../guides/testing-debugging.md). Runtime identifiers and mobile hosts are covered in [deployment](../guides/deployment.md).