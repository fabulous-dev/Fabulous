# BezierSegment

**Inheritance:** [PathSegment](pathsegment.md)\
**AvaloniaUI documentation:** BezierSegment [API](https://reference.avaloniaui.net/api/Avalonia.Media/BezierSegment/)

## Constructors

| Constructors                                               | Description                     |
| ---------------------------------------------------------- | ------------------------------- |
| BezierSegment(point1: Point, point2: Point, point3: Point) | Creates a BezierSegment widget. |

## Properties

| Properties                | Description                                                         |
| ------------------------- | ------------------------------------------------------------------- |
| reference(value: ViewRef) | Link a ViewRef to access the direct BezierSegment control instance. |

## Usages

```fsharp
BezierSegment(Point(100., 0.), Point(200., 200.), Point(300., 100.))
```

#### Get access to the underlying BezierSegment

```fsharp
let pathSegmentRef = ViewRef<BezierSegment>()

BezierSegment(Point(100., 0.), Point(200., 200.), Point(300., 100.))
    .reference(pathSegmentRef)
```
