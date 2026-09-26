# Migrate to Fabulous 10.0.x

Fabulous 10 unifies core, MAUI, Avalonia, extensions, templates, samples, and releases in this repository. The NuGet package ID for core remains `Fabulous`, and public namespaces remain `Fabulous`; the project and assembly are named `Fabulous.Core`. All maintained packages now share the `10.0.x` release line.

## From Fabulous 3 prereleases

1. Remove prerelease pins such as `3.0.0-pre22` or `3.0.0-pre23` and reference the same `10.0.x` version for `Fabulous`, `Fabulous.MauiControls` or `Fabulous.Avalonia`, and any maintained extensions.
2. Replace references to the former platform repositories with package references or the new source locations under `src/maui` and `src/avalonia`.
3. Reinstall `Fabulous.MauiControls.Templates` or `Fabulous.Avalonia.Templates` at `10.0.x`, generate a temporary app, and compare project hosts/resources with your app.
4. Build every target and run update tests plus backend UI tests. Do not infer device compatibility from a neutral build.

Most Fabulous 3 MVU code keeps `Program.stateful`, `statefulWithCmd`, or `statefulWithCmdMsg`; verify tuple shapes against [programs and commands](../concepts/programs.md). Use the current [MAUI](https://github.com/fabulous-dev/Fabulous/tree/main/samples/maui) and [Avalonia](https://github.com/fabulous-dev/Fabulous/tree/main/samples/avalonia) samples when an imported prerelease example differs.

## From Fabulous 2 or Xamarin.Forms

There is no maintained Xamarin.Forms backend in Fabulous 10. Migrate the host to .NET MAUI or Avalonia and replace `Fabulous.XamarinForms` imports, `XamarinFormsProgram.run`, and Xamarin.Forms control types with the chosen backend. Do not mechanically rename namespaces: create a current template app, move the model/update logic first, then rebuild the view using current builders and modifiers.

Replace old `View.*` constructors with the backend's current `open type Fabulous.Maui.View` or `open type Fabulous.Avalonia.View` style. Revisit navigation, styles, platform services, permissions, and `ViewRef` code because their native APIs changed. The two [end-to-end tutorials](../tutorials/maui.md) and [UI guide](../concepts/ui.md) provide current starting points.

## `Cmd` module changes (since 2.5.0-pre8)

If you're coming from Fabulous 2.4.x or earlier, the `Cmd` module changed substantially in `2.5.0-pre8` (2024-01-30, bundled into PR #1066, a change primarily about component disposal lifecycle) — well before the Fabulous 3 or 10.0.0 lines, and never called out at the time as a breaking `Cmd` API change. If your code predates this, check for the following:

- **`Cmd.ofSub`** — removed. `Sub` is no longer bridged into `Cmd`; wire your subscription directly through the current subscription mechanism instead.
- **`Cmd.dispatch`** — removed from the public API (the internal equivalent, `Cmd.exec`, is private and also gained an `onError` handler parameter).
- **The `Sub<'msg>` type used by `Cmd`** (`Dispatch<'msg> -> unit`) — renamed to `Effect<'msg>`. A new `Cmd.ofEffect : Effect<'msg> -> Cmd<'msg>` bridges it into `Cmd`. (This is unrelated to the current, still-present `Sub` subscription mechanism with `SubId`/`IDisposable`-based lifecycle tracking — the naming overlap between the two is coincidental and has caused confusion.)
- **`Cmd.ofAsyncMsg` / `Cmd.ofAsyncMsgOption` / `Cmd.ofTaskMsg`** — relocated to `Cmd.OfAsync.msg` / `Cmd.OfAsync.msgOption` / `Cmd.OfTask.msg`.
- **`Cmd.ofAsyncResult` / `Cmd.ofTaskResult`** — removed. `Cmd.OfAsync.either` / `Cmd.OfTask.either` are the closest equivalents, but take **two** continuations (`ofSuccess`, `ofError`) instead of the previous **three** (`success`, `error` for a domain `Result.Error`, `failure` for a thrown exception). If your code relied on that distinction, handle it explicitly — e.g. catch exceptions inside your task function and fold them into your `Result` before it reaches `either`, so a thrown exception and a domain error don't collapse into the same handler.

> ⚠️ The `ofAsyncResult`/`ofTaskResult` change is the one most likely to cause a silent behavioral bug rather than a compile error: a mechanical rename to `Cmd.OfAsync.either` will build successfully but changes what happens when your task throws.

Finish by removing retired packages and links, clearing `bin`/`obj`, restoring, and checking the installed package graph:

```bash
dotnet list package --include-transitive
dotnet build -c Release
dotnet test -c Release
```
