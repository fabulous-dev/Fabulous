# LinearGradientBrush

**Inheritance:** [GradientBrush](gradientbrush.md)\
**AvaloniaUI documentation:** LinearGradientBrush [API](https://reference.avaloniaui.net/api/Avalonia.Media/LinearGradientBrush/)

## Constructors

| Constructors                                                                                            | Description                           |
| ------------------------------------------------------------------------------------------------------- | ------------------------------------- |
| LinearGradientBrush(startPoint: RelativePoint, endPoint: RelativePoint)                                 | Creates a LinearGradientBrush widget. |
| LinearGradientBrush'(startPoint: RelativePoint, endPoint: RelativePoint)                                | Creates a LinearGradientBrush widget. |
| LinearGradientBrush(startPoint: Point, endPoint: Point, unit: RelativeUnit)                             | Creates a LinearGradientBrush widget. |
| LinearGradientBrush(startPoint: Point, endPoint: Point)                                                 | Creates a LinearGradientBrush widget. |
| LinearGradientBrush(startPoint: Point, endPoint: Point, startUnit: RelativeUnit, endUnit: RelativeUnit) | Creates a LinearGradientBrush widget. |
| LinearGradientBrush()                                                                                   | Creates a LinearGradientBrush widget. |
| LinearGradientBrush'()                                                                                  | Creates a LinearGradientBrush widget. |

## Properties

| Properties                | Description                                                               |
| ------------------------- | ------------------------------------------------------------------------- |
| reference(value: ViewRef) | Link a ViewRef to access the direct LinearGradientBrush control instance. |

## Usages

```fsharp
LinearGradientBrush() {
    GradientStop(Colors.Blue, 0.)
    GradientStop(Colors.Black, 1.)
}
```

#### Get access to the underlying LinearGradientBrush

```fsharp
let brushesRef = ViewRef<LinearGradientBrush>()

(LinearGradientBrush() {
    GradientStop(Colors.Blue, 0.)
    GradientStop(Colors.Black, 1.)
})
    .reference(brushesRef)
```
