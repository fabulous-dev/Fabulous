# PathFigure

**Inheritance:** [AvaloniaObject](https://reference.avaloniaui.net/api/Avalonia/AvaloniaObject/)\
**AvaloniaUI documentation:** PathFigure [API](https://reference.avaloniaui.net/api/Avalonia.Media/PathFigure/)

## Constructors

| Constructors                  | Description                  |
| ----------------------------- | ---------------------------- |
| PathFigure(startPoint: Point) | Creates a PathFigure widget. |

## Properties

| Properties                | Description                                                      |
| ------------------------- | ---------------------------------------------------------------- |
| isClosed(value: bool)     | Sets the IsClosed property.                                      |
| isFilled(value: bool)     | Sets the IsFilled property.                                      |
| reference(value: ViewRef) | Link a ViewRef to access the direct PathFigure control instance. |

## Usages

```fsharp
PathFigure(Point(0., 0.)) {
    QuadraticBezierSegment(Point(50., 0.), Point(50., -50.))
    QuadraticBezierSegment(Point(100., -50.), Point(100., 0.))
    LineSegment(Point(50., 0.))
    LineSegment(Point(50., 50.))

}
```

#### Get access to the underlying PathFigure

```fsharp
let pathSegmentRef = ViewRef<PathFigure>()

(PathFigure(Point(0., 0.)) {
    QuadraticBezierSegment(Point(50., 0.), Point(50., -50.))
    QuadraticBezierSegment(Point(100., -50.), Point(100., 0.))
    LineSegment(Point(50., 0.))
    LineSegment(Point(50., 50.))
})
    .reference(pathSegmentRef)
```
