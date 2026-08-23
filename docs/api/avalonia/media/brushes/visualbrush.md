# VisualBrush

**Inheritance:** [TileBrush](tilebrush.md)\
**AvaloniaUI documentation:** VisualBrush [API](https://reference.avaloniaui.net/api/Avalonia.Media/VisualBrush/)

## Constructors

| Constructors                                           | Description                   |
| ------------------------------------------------------ | ----------------------------- |
| VisualBrush(content: WidgetBuilder<'msg, #IFabVisual>) | Creates a VisualBrush widget. |

## Properties

| Properties                | Description                                                       |
| ------------------------- | ----------------------------------------------------------------- |
| reference(value: ViewRef) | Link a ViewRef to access the direct VisualBrush control instance. |

## Usages

```fsharp
VisualBrush(TextBlock("Hello"))
```

#### Get access to the underlying VisualBrush

```fsharp
let brushesRef = ViewRef<VisualBrush>()

VisualBrush(TextBlock("Hello"))
    .reference(brushesRef)
```
