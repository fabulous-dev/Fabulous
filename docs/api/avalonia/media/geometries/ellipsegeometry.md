# EllipseGeometry

**Inheritance:** [Geometry](geometry.md)\
**AvaloniaUI documentation:** EllipseGeometry [API](https://reference.avaloniaui.net/api/Avalonia.Media/EllipseGeometry/)

## Constructors

| Constructors                                    | Description                       |
| ----------------------------------------------- | --------------------------------- |
| EllipseGeometry(radiusX: float, radiusY: float) | Creates a EllipseGeometry widget. |

## Properties

| Properties                | Description                                                           |
| ------------------------- | --------------------------------------------------------------------- |
| center(value: Point)      | Sets the Center property.                                             |
| rect(value: Rect)         | Sets the Rect property.                                               |
| reference(value: ViewRef) | Link a ViewRef to access the direct EllipseGeometry control instance. |

## Usages

```fsharp
EllipseGeometry(100., 100.).center(Point(150., 150.))
```

#### Get access to the underlying EllipseGeometry

```fsharp
let geometryRef = ViewRef<EllipseGeometry>()

EllipseGeometry(100., 100.).center(Point(150., 150.))
    .reference(geometryRef)
```
