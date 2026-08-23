# DrawingBrush

**Inheritance:** [TileBrush](tilebrush.md)\
**AvaloniaUI documentation:** DrawingBrush [API](https://reference.avaloniaui.net/api/Avalonia.Media/Brush/)

## Constructors

| Constructors                                            | Description                    |
| ------------------------------------------------------- | ------------------------------ |
| DrawingBrush(source: WidgetBuilder<'msg, #IFabDrawing>) | Creates a DrawingBrush widget. |

## Properties

| Properties                | Description                                                        |
| ------------------------- | ------------------------------------------------------------------ |
| reference(value: ViewRef) | Link a ViewRef to access the direct DrawingBrush control instance. |

## Usages

```fsharp
DrawingBrush(GeometryDrawing())
```

#### Get access to the underlying DrawingBrush

```fsharp
let brushesRef = ViewRef<DrawingBrush>()

DrawingBrush(GeometryDrawing())
    .reference(brushesRef)
```
