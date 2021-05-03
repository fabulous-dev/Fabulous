{% include_relative _header.md %}

{% include_relative contents.md %}

RadioButton
--------
##### `topic last updated: v1.0 - 24.04.2021 - 11:47pm`

### [back to interface objects](view-interface-objects.html#interface-objects)

<br />

### Basic example


```fsharp 
View.StackLayout(children = [ View.RadioButton(content = Content.String "RadioButton 1"); View.RadioButton(content = Content.String "RadioButton 2") ] )
```

<img src="images/views/RadioButton-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.StackLayout
    (                                   
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.LayoutColor,
        children = [                                
            View.RadioButton
                (
                    horizontalOptions = style.Position,
                    verticalOptions = style.Position,
                    backgroundColor = style.ViewColor,
                    padding = style.Padding,
                    isChecked = true,                                            
                    content = Content.String "RadioButton 1"
                )
            View.RadioButton
                (
                    horizontalOptions = style.Position,
                    verticalOptions = style.Position,
                    backgroundColor = style.ViewColor,
                    padding = style.Padding,
                    isChecked = false,
                    content = Content.String "RadioButton 2"
                )
        ]
    )
```


<img src="images/views/RadioButton-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [RadioButton in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/RadioButton)
* [`Xamarin.Forms.RadioButton`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.RadioButton)

<br /> 

### More examples

```fsharp 
View.StackLayout( children = [
    // These RadioButtons will be grouped togehter, beacause they are in the same StackLayout
    View.RadioButton(
        padding = Thickness 2.0,
        content = Content.String("content1"), 
        isChecked = true
        checkedChanged = (fun on -> dispatch (...))
    )
    View.RadioButton(
        padding = Thickness 2.0,
        content = Content.String("content2"), 
        isChecked = false
        checkedChanged = (fun on -> dispatch (...))
    )
])
```