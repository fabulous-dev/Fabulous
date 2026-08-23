---
description: Encapsulates a Avalonia application.
---

# Application

**Inheritance:** [AvaloniaObject](https://reference.avaloniaui.net/api/Avalonia/AvaloniaObject/)\
AvaloniaUI **documentation:** Application [API](https://reference.avaloniaui.net/api/Avalonia/Application/)

### Constructors&#x20;

| Constructors                                                   | Description                                                   |
| -------------------------------------------------------------- | ------------------------------------------------------------- |
| DesktopApplication(window: WidgetBuilder<'msg, #IFabWindow>)   | Creates a DesktopApplication widget with a content widget.    |
| SingleViewApplication(view: WidgetBuilder<'msg, #IFabControl>) | Creates a SingleViewApplication widget with a content widget. |

### Properties&#x20;

| Properties                                 | Description                                                                                         |
| ------------------------------------------ | --------------------------------------------------------------------------------------------------- |
| name(value: string)                        | Sets the applications name.                                                                         |
| debugOverlays(value:RendererDebugOverlays) | Sets the application debug overlays.                                                                |
| isSystemBarVisible(value: bool)            | Sets the application system bar visibility.                                                         |
| displayEdgeToEdge(value: bool)             | Sets the application display edge to edge.                                                          |
| systemBarColor(value: Color)               | Sets the application system bar color.                                                              |
| reference(value: ViewRef\<FabApplication>) | Sets a `ViewRef` instance to retrieve the `Avalonia.Application` instance associated to this widget |

### Events&#x20;

| Properties                                                           | Description                                                                                               |
| -------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- |
| onThemeVariantChanged(value: ThemeVariant, fn: ThemeVariant -> 'msg) | <p>Raised when the theme variant changes and</p><p>sets the application theme variant.</p>                |
| onThemeVariantChanged(fn: ThemeVariant -> 'msg)                      | Raised when the application theme variant changed event.                                                  |
| onResourcesChanged(fn: ResourcesChangedEventArgs -> 'msg)            | Raised when the resources change.                                                                         |
| onUrlsOpened(fn: UrlOpenedEventArgs -> 'msg)                         | Raised when the application receives urls to open.                                                        |
| onColorValuesChanged(fn: PlatformColorValues -> 'msg)                | Raised when current system color values are changed. Including changing of a dark mode and accent colors. |
| onSafeAreaChanged(fn: Platform.SafeAreaChangedArgs -> 'msg)          | Raised when the safe area is changed.                                                                     |
|                                                                      |                                                                                                           |

### Usages&#x20;

```fsharp
DesktopApplication(
    Window(
        VStack() {
            TextBlock("Hello World!")
        }
    )
)

SingleViewApplication(
    VStack() {
        TextBlock("Hello World!")
    }
)

```

#### Get access to the underlying Application&#x20;

```fsharp
let applicationRef = ViewRef<FabApplication>()

DesktopApplication(
    Window(
        VStack() {
            TextBlock("Hello World!")
        }
    )
).reference(applicationRef)

SingleViewApplication(
    VStack() {
        TextBlock("Hello World!")
    }
).reference(applicationRef)
```
