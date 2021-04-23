{% include_relative _header.md %}

{% include_relative contents.md %}

Switch
--------

<br /> 

### Basic example


```fsharp 
View.Switch()
```

<img src="images/views/Switch-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.Switch
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.ViewColor,
        isToggled = false
    )
```


<img src="images/views/Switch-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [`Xamarin.Forms.Switch`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Switch)

<br /> 

### More examples

`Switch` is a horizontal toggle button that can be manipulated by the user to toggle between on and off states, which are represented by a boolean value. 

```fsharp 
View.Switch(
    isToggled = false, 
    toggled = fun on -> dispatch (SwitchToggled (...))
)
```