# Pen

**Inheritance:** [AvaloniaObject](https://reference.avaloniaui.net/api/Avalonia/AvaloniaObject/)\
**AvaloniaUI documentation:** Pen [API](https://reference.avaloniaui.net/api/Avalonia.Media/Pen/)

## Constructors

| Constructors                                                  | Description           |
| ------------------------------------------------------------- | --------------------- |
| Pen(brush: WidgetBuilder<'msg, #IFabBrush>, thickness: float) | Creates a Pen widget. |
| Pen(brush: IBrush, thickness: float)                          | Creates a Pen widget. |
| Pen(brush: string, thickness: float)                          | Creates a Pen widget. |

## Properties

| Properties                                          | Description                                               |
| --------------------------------------------------- | --------------------------------------------------------- |
| dashStyle(value: WidgetBuilder<'msg, IFaDashStyle>) | Sets the DashStyle property.                              |
| lineCap(value: PenLineCap)                          | Sets the LineCap property.                                |
| lineJoin(value: PenLineCap)                         | Sets the LineJoin property.                               |
| miterLimit(value: float)                            | Sets the MiterLimit property.                             |
| reference(value: ViewRef)                           | Link a ViewRef to access the direct Pen control instance. |

## Usages

```fsharp
Pen(SolidColorBrush(Colors.Red), 0.)
    .dashStyle(DashStyle([ 2.; 2. ], 0.))
    .lineCap(PenLineCap.Flat)
    .lineJoin(PenLineJoin.Miter)
    .miterLimit(0.)
```

#### Get access to the underlying Pen

```fsharp
let penRef = ViewRef<Pen>()

Pen(SolidColorBrush(Colors.Red), 0.)
    .dashStyle(DashStyle([ 2.; 2. ], 0.))
    .lineCap(PenLineCap.Flat)
    .lineJoin(PenLineJoin.Miter)
    .miterLimit(0.)
    .reference(penRef)
```
