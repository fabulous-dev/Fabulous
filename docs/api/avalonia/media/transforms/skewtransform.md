# SkewTransform

**Inheritance:** [Transform](../../transform.md)\
**AvaloniaUI documentation:** SkewTransform [API](https://reference.avaloniaui.net/api/Avalonia.Media/SkewTransform/)

## Constructors

| Constructors                                | Description                     |
| ------------------------------------------- | ------------------------------- |
| SkewTransform(angleX: float, angleY: float) | Creates a SkewTransform widget. |
| SkewTransform(angleX: float)                | Creates a SkewTransform widget. |
| SkewTransform()                             | Creates a SkewTransform widget. |

## Properties

| Properties                | Description                                                         |
| ------------------------- | ------------------------------------------------------------------- |
| reference(value: ViewRef) | Link a ViewRef to access the direct SkewTransform control instance. |

## Usages

```fsharp
VisualBrush(...)
    .transform(
        SkewTransform(45.)
    )
```

#### Get access to the underlying SkewTransform

```fsharp
let transformRef = ViewRef<SkewTransform>()

VisualBrush(...)
    .transform(
        SkewTransform(45.)
            .reference(transformRef)
    )
```
