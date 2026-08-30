# FormattedLabel

**Inheritance:** [Element](https://fabulous-dev.github.io/Fabulous/v2/api/controls/element/) -> [NavigableElement](https://fabulous-dev.github.io/Fabulous/v2/api/navigable-element/) -> [VisualElement](https://fabulous-dev.github.io/Fabulous/v2/api/visual-element/) -> [View](https://fabulous-dev.github.io/Fabulous/v2/api/view/) -> [Label](https://fabulous-dev.github.io/Fabulous/v2/api/controls/label/)\
**Xamarin.Forms documentation:** FormattedLabel [API](https://todo/) / [Guide](https://todo/)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://todo/).

### Constructors&#x20;

| Constructors     | Description                                                                 |
| ---------------- | --------------------------------------------------------------------------- |
| FormattedLabel() | Define a FormattedLabel widget. This widget accept Span widgets as children |

### Properties&#x20;

| Properties                        | Description                                                                                        |
| --------------------------------- | -------------------------------------------------------------------------------------------------- |
| reference(value: ViewRef\<Label>) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.Label` instance associated to this widget |

### Usages&#x20;

```fsharp
(FormattedLabel() {
  Span("Hello")
    .font(size = 20., attributes = FontAttributes.Bold)
    
  Span("World")
    .textColor(Color.Red.ToFabColor())
})
  .font(fontFamily = "Consolas")
```

#### Get access to the underlying Xamarin.Forms.FormattedLabel [#](https://fabulous-dev.github.io/Fabulous/v2/api/controls/formatted-label/#get-access-to-the-underlying-xamarinformsformattedlabel) <a href="#get-access-to-the-underlying-xamarinformsformattedlabel" id="get-access-to-the-underlying-xamarinformsformattedlabel"></a>

```fsharp
let formattedLabelRef = ViewRef<Label>()

(FormattedLabel() {
  Span("Hello")
})
    .reference(labelRef)
```
