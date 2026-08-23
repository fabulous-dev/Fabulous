# GradientStop

**Inheritance:** [AvaloniaObject](https://reference.avaloniaui.net/api/Avalonia/AvaloniaObject/)\
**AvaloniaUI documentation:** GradientStop [API](https://reference.avaloniaui.net/api/Avalonia.Media/GradientStop/)

## Constructors

| Constructors                               | Description                    |
| ------------------------------------------ | ------------------------------ |
| GradientStop(color: Color, offset: float)  | Creates a GradientStop widget. |
| GradientStop(color: string, offset: float) | Creates a GradientStop widget. |

## Properties

| Properties                | Description                                                        |
| ------------------------- | ------------------------------------------------------------------ |
| reference(value: ViewRef) | Link a ViewRef to access the direct GradientStop control instance. |

## Usages

```fsharp
GradientStop(Colors.Blue, 0.)
```

#### Get access to the underlying GradientStop

```fsharp
let brushesRef = ViewRef<GradientStop>()

GradientStop(Colors.Blue, 0.)
    .reference(brushesRef)
```
