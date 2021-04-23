{% include_relative _header.md %}

{% include_relative contents.md %}

Slider
--------

<br /> 

### Basic example


```fsharp 
View.Slider( 5.0 )
```

<img src="images/views/Slider-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.Slider
(
    backgroundColor = style.ViewColor,
    minimumMaximum = (0.0, 10.0),
    value = 5.0
)
```


<img src="images/views/Slider-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [`Xamarin.Forms.Slider`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Slider)

<br /> 

### More examples

```fsharp
View.Slider(
    minimumMaximum = (0.0, 10.0),
    value= double step,
    valueChanged=(fun args -> dispatch (SliderValueChanged (int (args.NewValue + 0.5))))
)
```

<img src="https://user-images.githubusercontent.com/52166903/60177363-9d737900-9810-11e9-8842-aeb904e7d739.png" width="400">