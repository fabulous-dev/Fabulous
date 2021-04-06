{% include_relative _header.md %}

{% include_relative contents.md %}

Interface objects (Views) for setting values
------
##### `topic last updated: v1.0 - 04.04.2021 - 02:51pm`

| Editing text                                  | Description                                                                                           | Appearance                                                   |
|-----------------------------------------------|-------------------------------------------------------------------------------------------------------|--------------------------------------------------------------|
| [CheckBox](interface/setting/CheckBox.md)     | a type of button that can either be checked or empty                                                  | <img src="images/views/sample.png" width="300"> |
| [Slider](interface/setting/TimePicker.md)     | a horizontal bar that can be manipulated by the user to select a double value from a continuous range | <img src="images/views/sample.png" width="300"> |
| [Stepper](interface/setting/TimePicker.md)    | two buttons that can be manipulated to incrementally select a double value from a range of values     | <img src="images/views/sample.png" width="300"> |
| [Switch](interface/setting/TimePicker.md)     | a horizontal toggle button that can be manipulated by the user to toggle between on and off states    | <img src="images/views/sample.png" width="300"> |
| [TimePicker](interface/setting/TimePicker.md) | invokes the platform's date-picker control and allows the user to select a date                       | <img src="images/views/sample.png" width="300"> |
| [DatePicker](interface/setting/TimePicker.md) | invokes the platform's time-picker control and allows the user to select a time                       | <img src="images/views/sample.png" width="300"> |



### Slider   
A simple `Slider` is as follows:

```fsharp
View.Slider(
    minimumMaximum = (0.0, 10.0),
    value= double step,
    valueChanged=(fun args -> dispatch (SliderValueChanged (int (args.NewValue + 0.5))))
)
```

<img src="https://user-images.githubusercontent.com/52166903/60177363-9d737900-9810-11e9-8842-aeb904e7d739.png" width="400">

See also:

* [Xamarin guide to Slider](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/slider)
* [`Xamarin.Forms.Core.Slider`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Slider)

<br /> 

### Stepper

Use a Stepper for selecting a numeric value from a range of values.

```fsharp 
View.Stepper(
    minimumMaximum = (0.0, 10.0),
    value = 2.,
    increment = 1.,
    valueChanged = fun args -> dispatch (SliderValueChanged (...))
)
```

See also:

* [Xamarin guide to Stepper](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/Stepper)
* [`Xamarin.Forms.Stepper`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Stepper)

<br /> 

### Switch

`Switch` is a horizontal toggle button that can be manipulated by the user to toggle between on and off states, which are represented by a boolean value. 

```fsharp 
View.Switch(
    isToggled = false, 
    toggled = fun on -> dispatch (SwitchToggled (...))
)
```

See also:

* [Xamarin guide to Switch](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/Switch)
* [`Xamarin.Forms.Switch`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Switch)

<br /> 

### DatePicker
A simple `DatePicker` is as follows:

```fsharp
View.DatePicker(minimumDate = DateTime.Today,
    maximumDate = DateTime.Today + TimeSpan.FromDays(365.0),
    date = startDate,
    dateSelected=(fun args -> dispatch (StartDateSelected args.NewDate)))
```

<img src="https://user-images.githubusercontent.com/52166903/60177357-9cdae280-9810-11e9-9979-1e91cf8c5ea6.png" width="400">

See also:

* [Xamarin guide to DatePicker](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/datepicker)
* [`Xamarin.Forms.Core.DatePicker`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.DatePicker)

<br /> 

### TimePicker
```fsharp 
View.TimePicker(
    time = TimeSpan (12, 22, 0)                
)
```

See also:

* [Xamarin guide to TimePicker](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/TimePicker)
* [`Xamarin.Forms.Core.TimePicker`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.TimePicker)