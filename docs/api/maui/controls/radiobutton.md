# RadioButton

**Inheritance:** [Element](https://docs.fabulous.dev/v2/api/controls/element/) -> [NavigableElement](https://docs.fabulous.dev/v2/api/navigable-element/) -> [VisualElement](https://docs.fabulous.dev/v2/api/visual-element/) -> [View](https://docs.fabulous.dev/v2/api/view/) -> [Layout](https://docs.fabulous.dev/v2/api/layouts/layout/) -> [TemplatedView](https://docs.fabulous.dev/v2/api/layouts/templated-view/)\
**Xamarin.Forms documentation:** RadioButton [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.radiobutton) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/radiobutton)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/radiobutton).

### Constructors&#x20;

| Constructors                                                           | Description                                                   |
| ---------------------------------------------------------------------- | ------------------------------------------------------------- |
| RadioButton(isChecked: bool, onChecked: bool -> ‘msg)                  | Define a default RadioButton widget with the checked state    |
| RadioButton(content: string, isChecked: bool, onChecked: bool -> ‘msg) | Define a RadioButton widget with a text and the checked state |

### Properties&#x20;

| Properties                                                                                  | Description                                                                                              |
| ------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------- |
| borderColor(light: FabColor, ?dark: FabColor)                                               | Sets the border color depending if light or dark mode                                                    |
| groupName(value: string)                                                                    | Sets the group name                                                                                      |
| borderWidth(value: float)                                                                   | Sets the border width                                                                                    |
| characterSpacing(spacing: float)                                                            | Sets the character spacing                                                                               |
| cornerRadius(value: float)                                                                  | Sets the corner radius                                                                                   |
| font(?size: float, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string) | Sets the font                                                                                            |
| textColor(light: FabColor, ?dark: FabColor)                                                 | Sets the text color                                                                                      |
| textTransform(value: TextTransform)                                                         | Sets the transformation for the text                                                                     |
| reference(value: ViewRef\<RadioButton>)                                                     | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.RadioButton` instance associated to this widget |

### Usages&#x20;

```fsharp
RadioButton(model.IsChecked, CheckedChangedMsg)
    .progressColor(Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor())
    .borderColor(Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor())  
    .groupName("MyGroup") 
    .borderWidth(10.) 
    .characterSpacing(2.) 
    .cornerRadius(5.) 
    
RadioButton("Cat", model.IsChecked, CheckedChangedMsg)
    .font(namedSize = NamedSize.Large, fontFamily = "Arial", attributes = FontAttributes.Bold)
    .textColor(Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor()) 
    .textTransform(TextTransform.Lowercase)
```

#### Get access to the underlying Xamarin.Forms.RadioButton [#](https://docs.fabulous.dev/v2/api/controls/radio-button/#get-access-to-the-underlying-xamarinformsradiobutton) <a href="#get-access-to-the-underlying-xamarinformsradiobutton" id="get-access-to-the-underlying-xamarinformsradiobutton"></a>

```fsharp
let radioButtonRef = ViewRef<RadioButton>()

RadioButton(model.IsChecked, CheckedChangedMsg)
    .reference(radioButtonRef)
```
