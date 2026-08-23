# UI and interaction

## Widgets and modifiers

A widget is an immutable description of a native control. Builders such as `Button`, `TextBlock`, and `ContentPage` establish the widget type and required values. Modifiers such as `.padding`, `.fontSize`, or `.gridRow` add typed attributes and return the builder, so calls can be chained. The available surface is backend-specific; use the [generated source inventory](https://fabulous-dev.github.io/Fabulous/docs/api/source-inventory/) and the compiled [MAUI](https://github.com/fabulous-dev/Fabulous/tree/main/samples/maui/Gallery) or [Avalonia](https://github.com/fabulous-dev/Fabulous/tree/main/samples/avalonia/Gallery) galleries.

Event-aware builders and modifiers accept either an MVU message or, in component APIs, a callback. Prefer messages for state changes. Use `View.map` when a child view has its own message type, as shown by the [MAUI navigation sample](https://github.com/fabulous-dev/Fabulous/blob/main/samples/maui/Navigation/BasicNavigation/Sample.fs).

## Layouts

Stack layouts arrange children in one direction; grids provide explicit rows and columns; dock, canvas, flex, wrap, and absolute layouts suit specialized placement. Keep layout intent in the parent and use attached modifiers such as `.gridRow(1)` on children. Avoid using nested stacks to simulate a grid because it adds controls and makes resizing harder.

## Navigation

Model navigation state explicitly. A discriminated union works for a small fixed flow. Nested components isolate page state. A navigation-path model adds history and back behavior. Compare all three maintained implementations for [MAUI](https://github.com/fabulous-dev/Fabulous/tree/main/samples/maui/Navigation) or [Avalonia](https://github.com/fabulous-dev/Fabulous/tree/main/samples/avalonia/Mvu/Navigation); they are more reliable than copying an isolated snippet.

## Styling

Use modifiers for values driven by the model. Use the backend's native style system for reusable visual rules: MAUI `Style`/resources or Avalonia selectors, themes, and style widgets. Keep theme resources near application construction and dynamic state in widgets. The [MAUI styles sample](https://github.com/fabulous-dev/Fabulous/blob/main/samples/maui/Gallery/Styles.fs) and [Avalonia styles page](https://github.com/fabulous-dev/Fabulous/blob/main/samples/avalonia/Gallery/Pages/StylesPage.fs) show current APIs.

Use `ViewRef` only for native APIs that cannot be expressed declaratively, such as focus or a platform service. A reference couples code to control lifetime; do not use it as a second state store.