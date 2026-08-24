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

Finish by removing retired packages and links, clearing `bin`/`obj`, restoring, and checking the installed package graph:

```bash
dotnet list package --include-transitive
dotnet build -c Release
dotnet test -c Release
```