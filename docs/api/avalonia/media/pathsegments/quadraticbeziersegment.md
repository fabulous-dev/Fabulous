# QuadraticBezierSegment

**Inheritance:** [PathSegment](pathsegment.md)\
**AvaloniaUI documentation:** QuadraticBezierSegment [API](https://reference.avaloniaui.net/api/Avalonia.Media/QuadraticBezierSegment/)

## Constructors

| Constructors                                         | Description                              |
| ---------------------------------------------------- | ---------------------------------------- |
| QuadraticBezierSegment(point1: Point, point2: Point) | Creates a QuadraticBezierSegment widget. |

## Properties

| Properties                | Description                                                                  |
| ------------------------- | ---------------------------------------------------------------------------- |
| reference(value: ViewRef) | Link a ViewRef to access the direct QuadraticBezierSegment control instance. |

## Usages

```fsharp
QuadraticBezierSegment(Point(50., 0.), Point(50., -50.))
```

#### Get access to the underlying QuadraticBezierSegment

```fsharp
let pathSegmentRef = ViewRef<QuadraticBezierSegment>()

QuadraticBezierSegment(Point(50., 0.), Point(50., -50.))
    .reference(pathSegmentRef)
```
