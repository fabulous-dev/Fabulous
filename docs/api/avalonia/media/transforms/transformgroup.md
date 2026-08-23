# TransformGroup

**Inheritance:** [Transform](../../transform.md)\
**AvaloniaUI documentation:** TransformGroup [API](https://reference.avaloniaui.net/api/Avalonia.Media/TransformGroup/)

## Constructors

| Constructors     | Description                      |
| ---------------- | -------------------------------- |
| TransformGroup() | Creates a TransformGroup widget. |

## Properties

| Properties                | Description                                                          |
| ------------------------- | -------------------------------------------------------------------- |
| reference(value: ViewRef) | Link a ViewRef to access the direct TransformGroup control instance. |

## Usages

```fsharp
VisualBrush(...)
    .transform(
        TransformGroup() {
            ScaleTransform(2., 2.)
            SkewTransform(45.)
            RotateTransform()
            TranslateTransform(5., 5.)
        }
    )
```

#### Get access to the underlying TransformGroup

```fsharp
let transformRef = ViewRef<TransformGroup>()

VisualBrush(...)
    .transform(
        (TransformGroup() {
            ScaleTransform(2., 2.)
            SkewTransform(45.)
            RotateTransform()
            TranslateTransform(5., 5.)
        }).reference(transformRef)
    )
```
