# ConicGradientBrush

**Inheritance:** [GradientBrush](gradientbrush.md)\
**AvaloniaUI documentation:** ConicGradientBrush [API](https://reference.avaloniaui.net/api/Avalonia.Media/ConicGradientBrush/)

## Constructors

| Constructors                                                        | Description                          |
| ------------------------------------------------------------------- | ------------------------------------ |
| ConicGradientBrush(center: RelativePoint, angle: float)             | Creates a ConicGradientBrush widget. |
| ConicGradientBrush(center: RelativePoint)                           | Creates a ConicGradientBrush widget. |
| ConicGradientBrush(center: Point, unit: RelativeUnit, angle: float) | Creates a ConicGradientBrush widget. |
| ConicGradientBrush(center: Point, unit: RelativeUnit)               | Creates a ConicGradientBrush widget. |
| ConicGradientBrush(angle: float)                                    | Creates a ConicGradientBrush widget. |
| ConicGradientBrush()                                                | Creates a ConicGradientBrush widget. |

## Properties

| Properties                | Description                                                              |
| ------------------------- | ------------------------------------------------------------------------ |
| reference(value: ViewRef) | Link a ViewRef to access the direct ConicGradientBrush control instance. |

## Usages

```fsharp
ConicGradientBrush(Point(30., 30.), RelativeUnit.Absolute, 90.) {
    GradientStop(Colors.Red, 0.)
    GradientStop(Colors.Blue, 0.25)
    GradientStop(Colors.Brown, 0.5)
    GradientStop(Colors.Green, 0.75)
    GradientStop(Colors.Purple, 0.1)
}
```

#### Get access to the underlying ConicGradientBrush

```fsharp
let brushesRef = ViewRef<ConicGradientBrush>()

(ConicGradientBrush(Point(30., 30.), RelativeUnit.Absolute, 90.) {
    GradientStop(Colors.Red, 0.)
    GradientStop(Colors.Blue, 0.25)
    GradientStop(Colors.Brown, 0.5)
    GradientStop(Colors.Green, 0.75)
    GradientStop(Colors.Purple, 0.1)
})
    .reference(brushesRef)
```
