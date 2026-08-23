# RectangleGeometry

**Inheritance:** [Geometry](geometry.md)\
**AvaloniaUI documentation:** RectangleGeometry [API](https://reference.avaloniaui.net/api/Avalonia.Media/RectangleGeometry/)

## Constructors

| Constructors                  | Description                         |
| ----------------------------- | ----------------------------------- |
| RectangleGeometry(rect: Rect) | Creates a RectangleGeometry widget. |

## Properties

| Properties                | Description                                                             |
| ------------------------- | ----------------------------------------------------------------------- |
| reference(value: ViewRef) | Link a ViewRef to access the direct RectangleGeometry control instance. |

## Usages

```fsharp
RectangleGeometry(Rect(10., 20., 150., 100.))
```

#### Get access to the underlying RectangleGeometry

```fsharp
let geometryRef = ViewRef<RectangleGeometry>()

RectangleGeometry(Rect(10., 20., 150., 100.))
    .reference(geometryRef)
```
