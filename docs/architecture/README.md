# Architecture

Fabulous separates a platform-neutral declarative engine from native UI backends. Application code produces immutable widgets; a backend turns each widget into a native object and applies later differences.

## Widgets and attributes

A widget contains a registered `WidgetKey` plus sorted scalar, child-widget, widget-collection, and environment attributes. A backend registers the native target using `Widgets.register<'T>()`; typed builders create `WidgetBuilder` values, and modifiers add attributes. Compare the current [MAUI Button definition](https://github.com/fabulous-dev/Fabulous/blob/main/src/maui/Fabulous.MauiControls/Views/Controls/Button.fs) with the [Avalonia Button definition](https://github.com/fabulous-dev/Fabulous/blob/main/src/avalonia/Fabulous.Avalonia/Views/Controls/Buttons/Button.fs).

Each attribute definition owns comparison and update behavior. Scalar attributes update native values or event subscriptions. Widget attributes reconcile one child. Collection attributes insert, update, replace, or remove children. Environment attributes flow inherited values through the tree. Typed marker interfaces constrain modifiers at compile time, while compiled widgets erase those generic details for the runtime.

## Reconciliation

On the first render, the backend looks up a `WidgetDefinition` in `WidgetDefinitionStore` and creates a native object plus view node. On later renders, [Reconciler.update](https://github.com/fabulous-dev/Fabulous/blob/main/src/neutral/Fabulous.Core/Reconciler.fs) calls `WidgetDiff.create` with the previous and next widget. [WidgetDiff](https://github.com/fabulous-dev/Fabulous/blob/main/src/neutral/Fabulous.Core/WidgetDiff.fs) compares sorted attributes and reports only additions, removals, updates, replacements, and collection edits. The view node applies that diff to the existing native object.

`CanReuseView` decides whether two widgets can share a native instance. Stable widget kind and child order enable reuse; changing the kind at a position replaces the native subtree. Duplicate scalar modifiers use last-value-wins semantics during diffing.

## Backends

Core owns programs, commands, subscriptions, widgets, definitions, diffs, and view-tree contracts. `Fabulous.MauiControls` maps them to MAUI bindable properties/events; `Fabulous.Avalonia` maps them to Avalonia properties/events. Extension packages register more definitions without changing the core engine. Backend startup supplies creation, attachment, dispatch, synchronization, logging, and reuse functions through the view-tree context.

To add a widget, follow a neighboring backend definition: register the target, define typed attributes, expose builders, expose narrowly typed modifiers, add the file to project compile order, and test creation plus attribute updates. The [generated API inventory](https://fabulous-dev.github.io/Fabulous/docs/api/source-inventory/) is rebuilt from those source definitions and catches an out-of-date reference in CI.

