# CheckBox

**Inheritance:** [Element](https://docs.fabulous.dev/v2/api/controls/element/) -> [NavigableElement](https://docs.fabulous.dev/v2/api/navigable-element/) -> [VisualElement](https://docs.fabulous.dev/v2/api/visual-element/) -> [View](https://docs.fabulous.dev/v2/api/view/)\
**Xamarin.Forms documentation:** CheckBox [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.checkbox) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/checkbox)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/checkbox).

### Constructors&#x20;

| Constructors                                              | Description               |
| --------------------------------------------------------- | ------------------------- |
| CheckBox(isChecked: bool, onCheckedChanged: bool -> ‘msg) | Defines a CheckBox widget |

### Properties&#x20;

| Properties                                         | Description                                                                                           |
| -------------------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| characterSpacing(light: FabColor, ?dark: FabColor) | Sets the spacing between each character of the text                                                   |
| reference(value: ViewRef\<CheckBox>)               | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.CheckBox` instance associated to this widget |

### Usages&#x20;

```fsharp
CheckBox(model.Checked, CheckedChanged)
    .characterSpacing(1.)
```

#### Get access to the underlying Xamarin.Forms.CheckBox&#x20;

```fsharp
let checkboxRef = ViewRef<CheckBox>()

CheckBox(model.Checked, CheckedChanged)
    .reference(checkboxRef)
```
