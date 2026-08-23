# Picker

**Inheritance:** [Element](https://docs.fabulous.dev/v2/api/controls/element/) -> [NavigableElement](https://docs.fabulous.dev/v2/api/navigable-element/) -> [VisualElement](https://docs.fabulous.dev/v2/api/visual-element/) -> [View](https://docs.fabulous.dev/v2/api/view/)\
**Xamarin.Forms documentation:** Picker [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.picker) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/picker)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/picker).

### Constructors&#x20;

| Constructors                                                                        | Description                                                                              |
| ----------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------- |
| Picker(items: string list, selectedIndex: int, onSelectedIndexChanged: int -> ‘msg) | Defines a Picker widget with items list, selected index and onSelectedIndexChanged event |

### Properties&#x20;

| Properties                                                                                  | Description                                                                                         |
| ------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- |
| characterSpacing(value: float)                                                              | Sets the spacing between each character of the picker                                               |
| horizontalTextAlignment(value: TextAlignment)                                               | Sets the horizontal text alignment of the picker                                                    |
| verticalTextAlignment(value: TextAlignment)                                                 | Sets the vertical text alignment of the picker                                                      |
| font(?size: float, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string) | Sets the font family used                                                                           |
| textColor(light: FabColor, ?dark: FabColor)                                                 | Sets the text color depending if light or dark mode                                                 |
| textTransform(value: TextTransform)                                                         | Sets the text transformation (lowercase, uppercase) to apply on the text                            |
| title(value: string)                                                                        | Sets the title of the picker                                                                        |
| titleColor(light: FabColor, ?dark: FabColor)                                                | Sets the title color depending if light or dark mode                                                |
| reference(value: ViewRef\<Picker>)                                                          | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.Picker` instance associated to this widget |

### iOS-specific Properties&#x20;

| Properties                                | Description                                                      |
| ----------------------------------------- | ---------------------------------------------------------------- |
| updateMode(value: iOSSpecific.UpdateMode) | Sets the update mode (Immediately or WhenFinished) of the picker |

### Usages&#x20;

```fsharp
Picker(["Item 1"; "Item 2"; "Item 3"], 0, SelectedIndexChanged)
    .characterSpacing(1.0)
    .textColor(Color.Red.ToFabColor(), Color.Blue.ToFabColor())
    .titleColor(Color.Red.ToFabColor(), Color.Blue.ToFabColor())
    .verticalTextAlignment(TextAlignment.Center)
    .horizontalTextAlignment(TextAlignment.Center)
    .font(namedSize = NamedSize.Large, fontFamily = "Arial", attributes = FontAttributes.Bold)
    .textTransform(TextTransform.Lowercase)
```

#### Get access to the underlying Xamarin.Forms.Picker&#x20;

```fsharp
let pickerRef = ViewRef<Picker>()

Picker(["Item 1"; "Item 2"; "Item 3"], 0, SelectedIndexChanged)
    .reference(pickerRef)
```
