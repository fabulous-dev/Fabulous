# ImageBrush

**Inheritance:** TileBrush\
**AvaloniaUI documentation:** ImageBrush [API](https://reference.avaloniaui.net/api/Avalonia.Media/ImageBrush/)

## Constructors

| Constructors               | Description                  |
| -------------------------- | ---------------------------- |
| ImageBrush(source: Bitmap) | Creates a ImageBrush widget. |

## Properties

| Properties                | Description                                                      |
| ------------------------- | ---------------------------------------------------------------- |
| reference(value: ViewRef) | Link a ViewRef to access the direct ImageBrush control instance. |

## Usages

```fsharp
ImageBrush(ImageSource.fromString("icon.png"))
```

#### Get access to the underlying ImageBrush

```fsharp
let brushesRef = ViewRef<ImageBrush>()

ImageBrush(ImageSource.fromString("icon.png"))
    .reference(brushesRef)
```
