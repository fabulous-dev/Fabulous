# LineGeometry

**Inheritance:** [Geometry](geometry.md)\
**AvaloniaUI documentation:** LineGeometry [API](https://reference.avaloniaui.net/api/Avalonia.Media/LineGeometry/)

## Constructors

| Constructors                                     | Description                    |
| ------------------------------------------------ | ------------------------------ |
| LineGeometry(startPoint: Point, endPoint: Point) | Creates a LineGeometry widget. |

## Properties

| Properties                | Description                                                        |
| ------------------------- | ------------------------------------------------------------------ |
| reference(value: ViewRef) | Link a ViewRef to access the direct LineGeometry control instance. |

## Usages

```fsharp
LineGeometry(Point(10., 20.), Point(100., 130.))
```

#### Get access to the underlying LineGeometry

```fsharp
let geometryRef = ViewRef<LineGeometry>()

LineGeometry(Point(10., 20.), Point(100., 130.))
    .reference(geometryRef)
```
