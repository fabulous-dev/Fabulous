# DashStyle

**Inheritance:** [Animatable](../animatable.md)\
**AvaloniaUI documentation:** DashStyle [API](https://reference.avaloniaui.net/api/Avalonia.Media/DashStyle/)

## Constructors

| Constructors                                 | Description                 |
| -------------------------------------------- | --------------------------- |
| DashStyle(dashes: float list, offset: float) | Creates a DashStyle widget. |

## Properties

| Properties                | Description                                                     |
| ------------------------- | --------------------------------------------------------------- |
| reference(value: ViewRef) | Link a ViewRef to access the direct DashStyle control instance. |

## Usages

```fsharp
DashStyle([ 2.; 2. ], 0.)
```

#### Get access to the underlying DashStyle

```fsharp
let stylleRef = ViewRef<DashStyle>()

DashStyle([ 2.; 2. ], 0.)
    .reference(stylleRef)
```
