# PolyLineSegment

**Inheritance:** [PathSegment](pathsegment.md)\
**AvaloniaUI documentation:** PolyLineSegment [API](https://reference.avaloniaui.net/api/Avalonia.Media/PathSegment/)

## Constructors

| Constructors                        | Description                       |
| ----------------------------------- | --------------------------------- |
| PolyLineSegment(points: Point list) | Creates a PolyLineSegment widget. |

## Properties

| Properties                | Description                                                           |
| ------------------------- | --------------------------------------------------------------------- |
| reference(value: ViewRef) | Link a ViewRef to access the direct PolyLineSegment control instance. |

## Usages

```fsharp
PolyLineSegment([ Point(50., 10.); Point(50., 50.) ])
```

#### Get access to the underlying PolyLineSegment

```fsharp
let pathSegmentRef = ViewRef<PolyLineSegment>()

PolyLineSegment([ Point(50., 10.); Point(50., 50.) ])
    .reference(pathSegmentRef)
```
