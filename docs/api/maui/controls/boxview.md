# BoxView

**Inheritance:** [Element](https://github.com/fabulous-dev/Fabulous/blob/main/docs/api/maui/element.md) -> [NavigableElement](https://github.com/fabulous-dev/Fabulous/blob/main/docs/api/maui/navigableelement.md) -> [VisualElement](https://github.com/fabulous-dev/Fabulous/blob/main/docs/api/maui/visualelement.md) -> [View](https://github.com/fabulous-dev/Fabulous/blob/main/docs/api/maui/view.md/)\
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

#### Get access to the underlying Xamarin.Forms.BoxView [#](https://fabulous-dev.github.io/Fabulous/v2/api/controls/box-view/#get-access-to-the-underlying-xamarinformsboxview) <a href="#get-access-to-the-underlying-xamarinformsboxview" id="get-access-to-the-underlying-xamarinformsboxview"></a>

```fsharp
let boxViewRef = ViewRef<BoxView>()

BoxView(Color.Red.ToFabColor())
    .reference(boxViewRef)
```
