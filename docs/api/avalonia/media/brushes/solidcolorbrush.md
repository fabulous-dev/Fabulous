# SolidColorBrush

**Inheritance:** [Brush](brush.md)\
**AvaloniaUI documentation:** SolidColorBrush [API](https://reference.avaloniaui.net/api/Avalonia.Media/SolidColorBrush/)

## Constructors

| Constructors                  | Description                       |
| ----------------------------- | --------------------------------- |
| SolidColorBrush(color: Color) | Creates a SolidColorBrush widget. |

### Properties

| Properties                | Description                                                           |
| ------------------------- | --------------------------------------------------------------------- |
| reference(value: ViewRef) | Link a ViewRef to access the direct SolidColorBrush control instance. |

## Usages

```fsharp
SolidColorBrush(Colors.Maroon)
```

#### Get access to the underlying SolidColorBrush

```fsharp
let brushesRef = ViewRef<SolidColorBrush>()

SolidColorBrush(Colors.Maroon)
    .reference(transformRef)
```
