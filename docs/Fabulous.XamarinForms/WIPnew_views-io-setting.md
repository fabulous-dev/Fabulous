{% include_relative _header.md %}

{% include_relative contents.md %}

Interface objects (Views) for setting values
------
##### (topic last updated: v 0.61.0)

### CheckBox
```fsharp 

```

<br /> 

### Slider   TODO
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
```fsharp 

```

<br /> 

### Switch
```fsharp 

```

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

```