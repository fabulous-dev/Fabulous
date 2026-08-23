# BoxView

**Inheritance:** [Element](https://docs.fabulous.dev/v2/api/controls/element/) -> [NavigableElement](https://docs.fabulous.dev/v2/api/navigable-element/) -> [VisualElement](https://docs.fabulous.dev/v2/api/visual-element/) -> [View](https://docs.fabulous.dev/v2/api/view/)\
**Xamarin.Forms documentation:** BoxView [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.boxview) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/boxview)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/boxview).

### Constructors&#x20;

| Constructors                              | Description                                                                 |
| ----------------------------------------- | --------------------------------------------------------------------------- |
| BoxView(light: FabColor, ?dark: FabColor) | Define a BoxView widget with its fill color depending if light or dark mode |

### Properties&#x20;

| Properties                          | Description                                                                                          |
| ----------------------------------- | ---------------------------------------------------------------------------------------------------- |
| cornerRadius(value: float)          | Sets the corner radius                                                                               |
| reference(value: ViewRef\<BoxView>) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.BoxView` instance associated to this widget |

### Usages&#x20;

```fsharp
BoxView(light = Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor())
    .cornerRadius(10.)
```

#### Get access to the underlying Xamarin.Forms.BoxView [#](https://docs.fabulous.dev/v2/api/controls/box-view/#get-access-to-the-underlying-xamarinformsboxview) <a href="#get-access-to-the-underlying-xamarinformsboxview" id="get-access-to-the-underlying-xamarinformsboxview"></a>

```fsharp
let boxViewRef = ViewRef<BoxView>()

BoxView(Color.Red.ToFabColor())
    .reference(boxViewRef)
```
