# ArcSegment

**Inheritance:** [PathSegment](pathsegment.md)\
**AvaloniaUI documentation:** ArcSegment [API](https://reference.avaloniaui.net/api/Avalonia.Media/ArcSegment/)

## Constructors

| Constructors                         | Description                  |
| ------------------------------------ | ---------------------------- |
| ArcSegment(point: Point, size: Size) | Creates a ArcSegment widget. |

## Properties

| Properties                            | Description                                                      |
| ------------------------------------- | ---------------------------------------------------------------- |
| rotationAngle(value: float)           | Sets the RotationAngle property.                                 |
| sweepDirection(value: SweepDirection) | Sets the SweepDirection property.                                |
| isLargeArc(value: bool)               | Sets the IsLargeArc property.                                    |
| reference(value: ViewRef)             | Link a ViewRef to access the direct ArcSegment control instance. |

## Usages

```fsharp
ArcSegment(Point(200., 100.), Size(100., 50.))
    .rotationAngle(45.)
    .isLargeArc(true)
    .sweepDirection(SweepDirection.Clockwise)
```

#### Get access to the underlying ArcSegment

```fsharp
let pathSegmentRef = ViewRef<ArcSegment>()

ArcSegment(Point(200., 100.), Size(100., 50.))
    .rotationAngle(45.)
    .isLargeArc(true)
    .sweepDirection(SweepDirection.Clockwise)
    .reference(pathSegmentRef)
```
