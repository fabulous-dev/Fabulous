{% include_relative _header.md %}

{% include_relative contents.md %}

CheckBox
--------

<br /> 

### Basic example


```fsharp 
View.CheckBox(true)
```

<img src="images/views/checkbox-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.CheckBox
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.LayoutColor,
        isChecked = true
    )
```


<img src="images/views/checkbox-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [`Xamarin.Forms.CheckBox`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.CheckBox)

<br /> 

### More examples

```fsharp 

View.CheckBox(
    isChecked = true,
    checkedChanged = (fun on -> dispatch (...))
)
```