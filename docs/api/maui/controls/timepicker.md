# TimePicker

**Inheritance:** [Element](https://docs.fabulous.dev/v2/api/controls/element/) -> [NavigableElement](https://docs.fabulous.dev/v2/api/navigable-element/) -> [VisualElement](https://docs.fabulous.dev/v2/api/visual-element/) -> [View](https://docs.fabulous.dev/v2/api/view/)\
**Xamarin.Forms documentation:** TimePicker [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.timepicker) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/timepicker)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/timepicker).

### Constructors&#x20;

| Constructors                                                 | Description                                                      |
| ------------------------------------------------------------ | ---------------------------------------------------------------- |
| TimePicker(time: TimeSpan, onTimeSelected: TimeSpan -> ‘msg) | Defines a TimePicker widget with a time and onTimeSelected event |

### Properties&#x20;

| Properties                                                                                  | Description                                                                                             |
| ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- |
| characterSpacing(value: float)                                                              | Sets the spacing between each character of the time picker                                              |
| font(?size: float, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string) | Sets the font family used                                                                               |
| format(value: string)                                                                       | Sets the format of the time picker                                                                      |
| textColor(light: FabColor, ?dark: FabColor)                                                 | Sets the text color depending if light or dark mode                                                     |
| textTransform(value: TextTransform)                                                         | Sets the text transformation (lowercase, uppercase) to apply on the text                                |
| reference(value: ViewRef\<TimePicker>)                                                      | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.TimePicker` instance associated to this widget |

### iOS-specific Properties&#x20;

| Properties                                | Description                                                           |
| ----------------------------------------- | --------------------------------------------------------------------- |
| updateMode(value: iOSSpecific.UpdateMode) | Sets the update mode (Immediately or WhenFinished) of the time picker |

### Usages&#x20;

```fsharp
TimePicker(TimeSpan.Parse("00:00:01"), TimeChanged)
    .characterSpacing(1.0)
    .format("dd/MM/yyyy")
    .textColor(Color.Red.ToFabColor(), Color.Blue.ToFabColor())
    .font(namedSize = NamedSize.Large, fontFamily = "Arial", attributes = FontAttributes.Bold)
    .textTransform(TextTransform.Lowercase)
```

#### Get access to the underlying Xamarin.Forms.TimePicker&#x20;

```fsharp
let timePickerRef = ViewRef<TimePicker>()

TimePicker(TimeSpan.Parse("00:00:01"), TimeChanged)
    .reference(timePickerRef)
```
