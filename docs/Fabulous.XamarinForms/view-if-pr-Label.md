{% include_relative _header.md %}

{% include_relative contents.md %}

Label
--------

<br /> 

### Basic example


```fsharp 
View.Label("Label")
```

<img src="images/views/Label-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.Label
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.ViewColor,
        padding = style.Padding,
        text = "Label"
    )
```


<img src="images/views/Label-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [Label in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/text/Label)
* [`Xamarin.Forms.Label`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Label)

<br /> 

### More examples

The Label view is used for displaying text, both single and multi-line. Labels can have text decorations, colored text, and use custom fonts (families, sizes, and options).

```fsharp 
View.Label(text = "this is a label")