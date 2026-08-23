# RotateTransform

**Inheritance:** [Transform](../../transform.md)\
**AvaloniaUI documentation:** RotateTransform [API](https://reference.avaloniaui.net/api/Avalonia.Media/RotateTransform/)

## Constructors

| Constructors                                                  | Description                       |
| ------------------------------------------------------------- | --------------------------------- |
| RotateTransform(angle: float, centerX: float, centerY: float) | Creates a RotateTransform widget. |
| RotateTransform(angle: float)                                 | Creates a RotateTransform widget. |
| RotateTransform()                                             | Creates a RotateTransform widget. |

## Properties

| Properties                | Description                                                           |
| ------------------------- | --------------------------------------------------------------------- |
| reference(value: ViewRef) | Link a ViewRef to access the direct RotateTransform control instance. |

## Usages

```fsharp
VisualBrush(...)
    .transform(
        RotateTransform(45.)
    )
```

#### Get access to the underlying RotateTransform

```fsharp
let transformRef = ViewRef<RotateTransform>()

VisualBrush(...)
    .transform(
        RotateTransform(45.)
            .reference(transformRef)
    )
```
