{% include_relative _header.md %}

{% include_relative contents.md %}

DatePicker
--------

<br /> 

### Basic example


```fsharp 
View.DatePicker()
```

<img src="images/views/DatePicker-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.DatePicker
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.ViewColor
    )
```


<img src="images/views/DatePicker-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [`Xamarin.Forms.DatePicker`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.DatePicker)

<br /> 

### More examples

```fsharp
View.DatePicker(minimumDate = DateTime.Today,
    maximumDate = DateTime.Today + TimeSpan.FromDays(365.0),
    date = startDate,
    dateSelected=(fun args -> dispatch (StartDateSelected args.NewDate)))
```

<img src="https://user-images.githubusercontent.com/52166903/60177357-9cdae280-9810-11e9-9979-1e91cf8c5ea6.png" width="400">