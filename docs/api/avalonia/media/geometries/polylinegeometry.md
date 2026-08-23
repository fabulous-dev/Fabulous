# PolylineGeometry

**Inheritance:** [Geometry](geometry.md)\
**AvaloniaUI documentation:** PolylineGeometry [API](https://reference.avaloniaui.net/api/Avalonia.Media/PolylineGeometry/)

## Constructors

| Constructors                                         | Description                        |
| ---------------------------------------------------- | ---------------------------------- |
| PolylineGeometry(points: Point list, isFilled: bool) | Creates a PolylineGeometry widget. |

## Properties

| Properties                | Description                                                            |
| ------------------------- | ---------------------------------------------------------------------- |
| reference(value: ViewRef) | Link a ViewRef to access the direct PolylineGeometry control instance. |

## Usages

```fsharp
PolylineGeometry([ Point(0., 0.); Point(50., 50.); Point(0., 50.) ], true)
```

#### Get access to the underlying PolylineGeometry

```fsharp
let geometryRef = ViewRef<PolylineGeometry>()

PolylineGeometry([ Point(0., 0.); Point(50., 50.); Point(0., 50.) ], true)
    .reference(geometryRef)
```
