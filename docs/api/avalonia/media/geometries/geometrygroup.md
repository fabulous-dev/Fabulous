# GeometryGroup

**Inheritance:** [Geometry](geometry.md)\
**AvaloniaUI documentation:** GeometryGroup [API](https://reference.avaloniaui.net/api/Avalonia.Media/Geometry/)

## Constructors

| Constructors                      | Description                     |
| --------------------------------- | ------------------------------- |
| GeometryGroup(fillRule: FillRule) | Creates a GeometryGroup widget. |

## Properties

| Properties                | Description                                                         |
| ------------------------- | ------------------------------------------------------------------- |
| reference(value: ViewRef) | Link a ViewRef to access the direct GeometryGroup control instance. |

## Usages

```fsharp
GeometryGroup(FillRule.EvenOdd) {
    EllipseGeometry(100., 100.).center(Point(150., 150.))
    EllipseGeometry(100., 100.).center(Point(250., 150.))
    EllipseGeometry(100., 100.).center(Point(150., 250.))
    EllipseGeometry(100., 100.).center(Point(250., 250.))
}
```

#### Get access to the underlying GeometryGroup

```fsharp
let geometryRef = ViewRef<GeometryGroup>()

(GeometryGroup(FillRule.EvenOdd) {
    EllipseGeometry(100., 100.).center(Point(150., 150.))
    EllipseGeometry(100., 100.).center(Point(250., 150.))
    EllipseGeometry(100., 100.).center(Point(150., 250.))
    EllipseGeometry(100., 100.).center(Point(250., 250.))
})
    .reference(geometryRef)
```
