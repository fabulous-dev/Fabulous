# Rotate3DTransform

**Inheritance:** [Transform](../../transform.md)\
**AvaloniaUI documentation:** Rotate3DTransform [API](https://reference.avaloniaui.net/api/Avalonia.Media/Transform/)

## Constructors

| Constructors                                                                                                                 | Description                         |
| ---------------------------------------------------------------------------------------------------------------------------- | ----------------------------------- |
| Rotate3DTransform(angleX: float, angleY: float, angleZ: float, centerX: float, centerY: float, centerZ: float, depth: float) | Creates a Rotate3DTransform widget. |

## Properties

| Properties                | Description                                                             |
| ------------------------- | ----------------------------------------------------------------------- |
| reference(value: ViewRef) | Link a ViewRef to access the direct Rotate3DTransform control instance. |

## Usages

```fsharp
VisualBrush(...)
    .transform(
        Rotate3DTransform(0., 0., 0., 0., 0., -100, 200.)
    )
```

#### Get access to the underlying Rotate3DTransform

```fsharp
let transformRef = ViewRef<Rotate3DTransform>()

VisualBrush(...)
    .transform(
        Rotate3DTransform(0., 0., 0., 0., 0., -100, 200.)
            .reference(transformRef)
    )
```
