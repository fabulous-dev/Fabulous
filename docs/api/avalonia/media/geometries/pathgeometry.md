# PathGeometry

**Inheritance:** [Geometry](geometry.md)\
**AvaloniaUI documentation:** PathGeometry [API](https://reference.avaloniaui.net/api/Avalonia.Media/PathGeometry/)

## Constructors

| Constructors                                       | Description                    |
| -------------------------------------------------- | ------------------------------ |
| PathGeometry(fillRule: FillRule)                   | Creates a PathGeometry widget. |
| PathGeometry(pathData: string, fillRule: FillRule) | Creates a PathGeometry widget. |

## Properties

| Properties                | Description                                                        |
| ------------------------- | ------------------------------------------------------------------ |
| reference(value: ViewRef) | Link a ViewRef to access the direct PathGeometry control instance. |

## Usages

```fsharp
PathGeometry(FillRule.EvenOdd) {
    PathFigure(Point(10., 50.)) {
        ArcSegment(Point(200., 100.), Size(100., 50.))
    }
}
```

#### Get access to the underlying AvaloniaUI PathGeometry

```fsharp
let geometryRef = ViewRef<PathGeometry>()

(PathGeometry(FillRule.EvenOdd) {
    PathFigure(Point(10., 50.)) {
        ArcSegment(Point(200., 100.), Size(100., 50.))
    }
})
    .reference(geometryRef)
```
