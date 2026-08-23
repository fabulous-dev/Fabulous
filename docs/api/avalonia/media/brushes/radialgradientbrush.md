# RadialGradientBrush

**Inheritance:** [GradientBrush](gradientbrush.md)\
**AvaloniaUI documentation:** RadialGradientBrush [API](https://reference.avaloniaui.net/api/Avalonia.Media/RadialGradientBrush/)

## Constructors

| Constructors                                                          | Description                           |
| --------------------------------------------------------------------- | ------------------------------------- |
| RadialGradientBrush(center: RelativePoint)                            | Creates a RadialGradientBrush widget. |
| RadialGradientBrush(center: Point, unit: RelativeUnit)                | Creates a RadialGradientBrush widget. |
| RadialGradientBrush(center: RelativePoint, origin: RelativePoint)     | Creates a RadialGradientBrush widget. |
| RadialGradientBrush(center: Point, origin: Point, unit: RelativeUnit) | Creates a RadialGradientBrush widget. |
| RadialGradientBrush()                                                 | Creates a RadialGradientBrush widget. |

## Properties

| Properties                | Description                                                               |
| ------------------------- | ------------------------------------------------------------------------- |
| radius(value: float)      | Sets the Radius property.                                                 |
| reference(value: ViewRef) | Link a ViewRef to access the direct RadialGradientBrush control instance. |

## Usages

```fsharp
RadialGradientBrush(Point(0., 0.), Point(0., 0.), RelativeUnit.Absolute) {
    GradientStop(Colors.Black, 0.)
    GradientStop(Colors.Orange, 1.0)
}
```

#### Get access to the underlying RadialGradientBrush

```fsharp
let brushesRef = ViewRef<RadialGradientBrush>()

(RadialGradientBrush(Point(0., 0.), Point(0., 0.), RelativeUnit.Absolute) {
    GradientStop(Colors.Black, 0.)
    GradientStop(Colors.Orange, 1.0)
})
    .reference(brushesRef)
```
