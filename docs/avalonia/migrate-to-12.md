# Migrate to Avalonia 12

Fabulous 10 uses Avalonia 12. Applications upgrading from Fabulous.Avalonia on Avalonia 11 must update code that uses APIs renamed or removed by Avalonia.

## Developer tools

Avalonia 12 replaces `Avalonia.Diagnostics` with the `AvaloniaUI.DiagnosticsSupport` package. The Fabulous extension keeps `attachDevTools` as a compatibility name, but its options overload now accepts an `Action<DeveloperToolsOptions>`. New code should use `attachDeveloperTools`:

```fsharp
Window(content).attachDeveloperTools(Action<DeveloperToolsOptions>(fun options ->
    options.Gesture <- KeyGesture(Key.F12)))
```

The parameterless and `KeyGesture` overloads are also available under both names.

## Renamed control APIs

Avalonia renamed watermark and window-decoration APIs. Update Fabulous modifiers as follows:

| Avalonia 11 modifier | Avalonia 12 modifier |
| --- | --- |
| `watermark` | `placeholderText` |
| `useFloatingWatermark` | `useFloatingPlaceholder` |
| `systemDecorations` | `windowDecorations` (old name kept as compat alias, now accepts `WindowDecorations`) |

`extendClientAreaChromeHints` has no direct successor — it was removed by Avalonia 12 with no replacement modifier. Combine `windowDecorations` with `extendClientAreaToDecorationsHint` to achieve the equivalent effect. Native menu item `toggleType` now accepts `MenuItemToggleType`.

## Event and binding types

The `onGotFocus` and `onLostFocus` callbacks now receive `FocusChangedEventArgs`. `displayMemberBinding` now accepts `BindingBase` instead of `IBinding`.

Avalonia removed pointer-over-element tracking and menu-item click forwarding from the corresponding controls, so the Fabulous `pointerOverElement` and `enableMenuItemClickForwarding` modifiers have been removed.

## Virtualized templates

Avalonia 12 changed `ITreeDataTemplate.Build` to receive an `INameScope`. Fabulous virtualized collections adopt that contract internally; application code using Fabulous collection builders requires no change. Custom Avalonia data-template implementations must update their `Build` signature.
