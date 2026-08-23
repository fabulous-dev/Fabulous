# Switch

**Inheritance:** [Element](https://docs.fabulous.dev/v2/api/controls/element/) -> [NavigableElement](https://docs.fabulous.dev/v2/api/navigable-element/) -> [VisualElement](https://docs.fabulous.dev/v2/api/visual-element/) -> [View](https://docs.fabulous.dev/v2/api/view/)\
**Xamarin.Forms documentation:** Switch [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.switch) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/switch)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/switch).

### Constructors&#x20;

| Constructors                                     | Description                                   |
| ------------------------------------------------ | --------------------------------------------- |
| Switch(isToggled: bool, onToggled: bool -> ‘msg) | Define a Switch widget with its toggled state |

### Properties&#x20;

| Properties                                   | Description                                                                                         |
| -------------------------------------------- | --------------------------------------------------------------------------------------------------- |
| thumbColor(light: FabColor, ?dark: FabColor) | Sets the thumb color depending if light or dark mode                                                |
| colorOn(light: FabColor, ?dark: FabColor)    | Sets the color when switch is toggled on                                                            |
| reference(value: ViewRef\<Switch>)           | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.Switch` instance associated to this widget |

### Usages&#x20;

```fsharp
Switch(model.Toggled, ToggledMsg)
    .thumbColor(Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor())
    .colorOn(Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor()) 
```

#### Get access to the underlying Xamarin.Forms.Switch&#x20;

```fsharp
let switchRef = ViewRef<Switch>()

Switch(model.Toggled, ToggledMsg) 
    .reference(switchRef) 
```
