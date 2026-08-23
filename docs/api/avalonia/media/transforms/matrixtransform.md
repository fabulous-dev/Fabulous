# MatrixTransform

**Inheritance:** [Transform](../../transform.md)\
**AvaloniaUI documentation:** MatrixTransform [API](https://reference.avaloniaui.net/api/Avalonia.Media/MatrixTransform/)

## Constructors

| Constructors                    | Description                       |
| ------------------------------- | --------------------------------- |
| MatrixTransform(matrix: Matrix) | Creates a MatrixTransform widget. |

## Properties

| Properties                | Description                                                           |
| ------------------------- | --------------------------------------------------------------------- |
| reference(value: ViewRef) | Link a ViewRef to access the direct MatrixTransform control instance. |

## Usages

```fsharp
(DrawingGroup() {
    ...
}).transform(
    MatrixTransform(Matrix.Parse("1,0,0,1.25,-10,1031.4"))
)
```

#### Get access to the underlying MatrixTransform

```fsharp
let transformRef = ViewRef<MatrixTransform>()

(DrawingGroup() {
    ...
}).transform(
    MatrixTransform(Matrix.Parse("1,0,0,1.25,-10,1031.4"))
        .reference(transformRef)
)
```
