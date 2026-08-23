# Testing and debugging

## Test state first

Keep `init` and `update` pure and test their returned model plus command or command-message values. The [TestableApp unit tests](https://github.com/fabulous-dev/Fabulous/blob/main/samples/avalonia/TestableApp.UnitTests/Tests.fs) cover initial state and every message without creating a UI:

```bash
dotnet test samples/avalonia/TestableApp.UnitTests/TestableApp.UnitTests.fsproj -c Release -p:FabulousSamplesDesktopOnly=true
```

Prefer `statefulWithCmdMsg` when tests need to assert requested effects. Test `mapCmd` adapters separately at integration boundaries.

## Avalonia headless UI tests

The [headless test project](https://github.com/fabulous-dev/Fabulous/tree/main/samples/avalonia/TestableApp.Headless.XUnit) compiles a widget, creates a native `Window`, sends keyboard input, and asserts rendered control state. Run it on a desktop-only restore:

```bash
FABULOUS_SCREENSHOT_DIR="$PWD/artifacts/screenshots" \
dotnet test samples/avalonia/TestableApp.Headless.XUnit/TestableApp.Headless.XUnit.fsproj \
  -c Release -p:FabulousSamplesDesktopOnly=true
```

`CaptureRenderedFrame` writes `avalonia-counter.png` only when `FABULOUS_SCREENSHOT_DIR` is set. Pull requests upload matching PNG files as the `Screenshots-Avalonia` artifact; the PR artifact workflow adds a link to the successful run. A missing screenshot fails CI. Treat screenshots as inspection artifacts unless a test explicitly performs pixel or snapshot comparison.

## Debug failures

Add `Program.withTrace` to log messages and models, and `Program.withExceptionHandler` to report uncaught loop failures. The [Avalonia CounterApp](https://github.com/fabulous-dev/Fabulous/blob/main/samples/avalonia/Mvu/CounterApp/App.fs) has both. Set a breakpoint in `update` for wrong state, in the event callback for missing input, and in the relevant backend attribute updater for a native-property mismatch.

For headless failures, first verify `window.Show()` was called, dimensions are deterministic, and the control is focused before input. Inspect the screenshot artifact and test output together. For device-only MAUI problems, reproduce on the target emulator/device and collect the platform log; a successful compile does not prove launch or rendering.