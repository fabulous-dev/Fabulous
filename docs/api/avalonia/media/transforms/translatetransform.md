# TranslateTransform

**Inheritance:** [Transform](../../transform.md)\
**AvaloniaUI documentation:** [TranslateTransform](https://reference.avaloniaui.net/api/Avalonia.Media/TranslateTransform/) [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.button)

## Constructors

| Constructors                           | Description                          |
| -------------------------------------- | ------------------------------------ |
| TranslateTransform(x: float, y: float) | Creates a TranslateTransform widget. |
| TranslateTransform(x: float)           | Creates a TranslateTransform widget. |
| TranslateTransform()                   | Creates a TranslateTransform widget. |

## Properties

| Properties                | Description                                                              |
| ------------------------- | ------------------------------------------------------------------------ |
| reference(value: ViewRef) | Link a ViewRef to access the direct TranslateTransform control instance. |

## Usages

```fsharp
VisualBrush(...)
    .transform(
        TranslateTransform(45.)
    )
```

#### Get access to the underlying TranslateTransform

```fsharp
let transformRef = ViewRef<TranslateTransform>()

VisualBrush(...)
    .transform(
        TranslateTransform(45.)
            .reference(transformRef)
    )
```
