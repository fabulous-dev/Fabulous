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

If you're coming from Fabulous 2.4.x or earlier, the `Cmd` module changed substantially in 2.5.0 pre-releases — well before the Fabulous 3 or 10.0.x lines, and never called out at the time as a breaking `Cmd` API change. If your code predates this, check for the following:

- **`Cmd.ofSub`** — removed. Use `Cmd.ofEffect` with a function of the same shape (`Dispatch<'msg> -> unit`) instead. If you used `Cmd.ofSub` to set up a long-lived listener or callback (for example an event handler or a timer), `Cmd.ofEffect` still works, but you may prefer the current `Sub` subscription mechanism, which manages start/stop lifecycle for you.
- **`Cmd.dispatch`** — removed from the public API (the internal equivalent, `Cmd.exec`, is private and also gained an `onError` handler parameter).
- **The old `Sub<'msg>` type** (`Dispatch<'msg> -> unit`) — renamed to `Effect<'msg>`. This is the same type under a new name, not a new type with different semantics. The new `Cmd.ofEffect : Effect<'msg> -> Cmd<'msg>` bridges it into `Cmd`.
  > **Note:** this old `Sub<'msg>` / `Effect<'msg>` is unrelated to the current `Sub` subscription mechanism (`SubId`, `IDisposable`-based lifecycle tracking). The shared name is historical and has caused confusion.
- **`Cmd.ofAsyncMsg` / `Cmd.ofAsyncMsgOption` / `Cmd.ofTaskMsg`** — relocated to `Cmd.OfAsync.msg` / `Cmd.OfAsync.msgOption` / `Cmd.OfTask.msg`. This is **not** a pure rename: in 2.4.x the async work was started on the UI thread, whereas the relocated functions no longer guarantee that. See the threading warning below.
- **`Cmd.ofAsyncResult` / `Cmd.ofTaskResult`** — removed. `Cmd.OfAsync.either` / `Cmd.OfTask.either` are the closest equivalents, but take **two** continuations (`ofSuccess`, `ofError`) instead of the previous **three** (`success`, `error` for a domain `Result.Error`, `failure` for a thrown exception). If your code relied on that distinction, handle it explicitly — e.g. catch exceptions inside your task function and fold them into your `Result` before it reaches `either`, so a thrown exception and a domain error don't collapse into the same handler.

> ⚠️ Two changes are likely to cause silent behavioral bugs rather than compile errors:
>
> 1. **Exception handling** (`ofAsyncResult`/`ofTaskResult`): a mechanical rename to `Cmd.OfAsync.either` will build successfully but changes what happens when your task throws.
> 2. **Threading** (`ofAsyncMsg`/`ofAsyncMsgOption`/`ofTaskMsg`): a mechanical rename to `Cmd.OfAsync.msg` / `Cmd.OfAsync.msgOption` / `Cmd.OfTask.msg` will build successfully, but the old guarantee of starting on the UI thread is gone, so the code may now run elsewhere. This typically surfaces at runtime, for example with APIs that must be called on the main thread, such as .NET MAUI permission checks (`Permissions.CheckStatusAsync`, `Permissions.RequestAsync`).

### Example: keeping a call on the UI thread

If the async body touches UI-thread-affine APIs, marshal that call explicitly instead of relying on the command's starting thread:

```fsharp
// Fabulous 2.4.x — the async was started on the UI thread
Cmd.ofAsyncMsg
    (
        async
            {
                let! status =
                    Permissions.CheckStatusAsync<Permissions.PostNotifications>()
                |> Async.AwaitTask
                return PermissionResult (status = PermissionStatus.Granted)
            }
    )

// Fabulous 10.0.x — marshal the UI-thread-affine call explicitly
Cmd.OfAsync.msg
     (
         async
             {
                 let! status =
                     MainThread.InvokeOnMainThreadAsync<PermissionStatus>(fun () ->
                         Permissions.CheckStatusAsync<Permissions.PostNotifications>())
                     |> Async.AwaitTask
                 return PermissionResult (status = PermissionStatus.Granted)
             }
      )
```
> **Note:** the explicit type argument (`<PermissionStatus>`) is used here to make the overload choice unambiguous.

Finish by removing retired packages and links, clearing `bin`/`obj`, restoring, and checking the installed package graph:

```bash
dotnet list package --include-transitive
dotnet build -c Release
dotnet test -c Release
```

## Program construction changes (MAUI)

In Fabulous 10.0.x, program construction is split between the core MVU program and the MAUI view layer.

### Fabulous 2.4.x vs 10.0.x

**Before:**
```fsharp
Program.statefulWithCmd init update view
|> Program.withSubscription subscriptions
```

**Now:**
```fsharp
Program.statefulWithCmd init update
|> Program.withSubscription subscriptions
|> Fabulous.Maui.Program.withView view
```
### Why

Fabulous 10 separates `Program<'arg,'model,'msg>` (core MVU logic) from `Program<'arg,'model,'msg,'marker>` (includes view rendering). `UseFabulousApp` requires the latter form.

### Subscriptions

If chaining multiple subscriptions, consolidate them:

```fsharp
let subscriptions model : Sub<Msg> =
    Sub.batch
        [
            subscriptionA model
            subscriptionB model
        ]
```
## Program construction changes (Avalonia)

This entry is under preparation.

## ⚠️ Issues during migration

If you run into problems during migration (and you will), please consult the Fabulous community on Discord first (in the F# channel, under the Fabulous project), rather than immediately resorting to LLM-based coding assistants.

Even if you manage to resolve the problem yourself, please share it on Discord. This helps us learn about migration issues that might otherwise never be reported as formal GitHub issues.
