# IndicatorView

**Inheritance:** [Element](https://docs.fabulous.dev/v2/api/controls/element/) -> [NavigableElement](https://docs.fabulous.dev/v2/api/navigable-element/) -> [VisualElement](https://docs.fabulous.dev/v2/api/visual-element/) -> [View](https://docs.fabulous.dev/v2/api/view/) -> [Layout](https://docs.fabulous.dev/v2/api/layouts/layout/) -> [TemplatedView](https://docs.fabulous.dev/v2/api/layouts/templated-view/)\
**Xamarin.Forms documentation:** IndicatorView [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.indicatorview) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/indicatorview)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/indicatorview).

### Constructors&#x20;

| Constructors                      | Description                                             |
| --------------------------------- | ------------------------------------------------------- |
| IndicatorView(reference: ViewRef) | Define a IndicatorView widget with the given reference. |

### Properties&#x20;

| Properties                                               | Description                                              |
| -------------------------------------------------------- | -------------------------------------------------------- |
| selectedIndicatorColor(light: FabColor, ?dark: FabColor) | Sets The color of the selected indicator.                |
| indicatorSize(size: float)                               | Sets The size of the indicator.                          |
| indicatorShape(shape: IndicatorShape)                    | Sets The shape of the indicator.                         |
| hideSingle(hide: bool)                                   | Whether to hide the indicator if there is only one item. |
| indicatorColor(light: FabColor, ?dark: FabColor)         | Sets the indicator color.                                |
| maximumVisible(count: int)                               | Sets the maximum number of visible indicators.           |

### Usages&#x20;

```fsharp
let indicatorViewRef = ViewRef<IndicatorView>()

IndicatorView(indicatorViewRef)
    .selectedIndicatorColor(Color.Red.ToFabColor(), Color.Blue.ToFabColor())
    .indicatorSize(24.)
    .indicatorsShape(IndicatorShape.Circle)
    .indicatorColor(Palette.MidGrey)
```
