{% include_relative _header.md %}

{% include_relative contents.md %}

Stepper
--------
##### `topic last updated: v1.0 - 24.04.2021 - 11:47pm`

### [back to interface objects](view-interface-objects.html#interface-objects)

<br />

### Basic example


```fsharp 
View.Stepper( 5.0 )
```

<img src="images/views/Stepper-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.Stepper
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.ViewColor,
        minimumMaximum = (0.0, 10.0),
        value = 5.0
    )
```


<img src="images/views/Stepper-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [`Xamarin.Forms.Stepper`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Stepper)

<br /> 

### More examples

Use a Stepper for selecting a numeric value from a range of values.

```fsharp 
View.Stepper(
    minimumMaximum = (0.0, 10.0),
    value = 2.,
    increment = 1.,
    valueChanged = fun args -> dispatch (SliderValueChanged (...))
)
```