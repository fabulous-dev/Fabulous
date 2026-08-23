# ScaleTransform

**Inheritance:** [Transform](../../transform.md)\
**AvaloniaUI documentation:** ScaleTransform [API](https://reference.avaloniaui.net/api/Avalonia.Media/ScaleTransform/)

## Constructors

| Constructors                                 | Description                      |
| -------------------------------------------- | -------------------------------- |
| ScaleTransform(scaleX: float, scaleY: float) | Creates a ScaleTransform widget. |
| ScaleTransform(scaleX: float)                | Creates a ScaleTransform widget. |
| ScaleTransform()                             | Creates a ScaleTransform widget. |

## Properties

| Properties                | Description                                                          |
| ------------------------- | -------------------------------------------------------------------- |
| reference(value: ViewRef) | Link a ViewRef to access the direct ScaleTransform control instance. |

## Usages

```fsharp
VisualBrush(...)
    .transform(
        ScaleTransform(2., 2.)
    )
```

#### Get access to the underlying ScaleTransform

```fsharp
let transformRef = ViewRef<ScaleTransform>()

VisualBrush(...)
    .transform(
        ScaleTransform(2., 2.)
            .reference(transformRef)
    )
```
