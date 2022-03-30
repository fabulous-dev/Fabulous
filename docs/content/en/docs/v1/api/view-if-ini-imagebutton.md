{% include_relative _header.md %}

{% include_relative contents.md %}

ImageButton
--------
##### `topic last updated: v1.0 - 24.04.2021 - 11:47pm`

### [back to interface objects](view-interface-objects.html#interface-objects)

<br />

<br /> 

### Basic example


```fsharp 
View.ImageButton
    (
        source = Image.ImagePath "icon.png"
    )
```

<img src="images/view/ImageButton-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.ImageButton
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.ButtonColor,
        padding = style.Padding,
        source = Image.ImagePath "icon.png"

    )
```


<img src="images/view/ImageButton-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [ImageButton in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/ImageButton)
* [`Xamarin.Forms.ImageButton`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.ImageButton)

<br /> 

### More examples

The ImageButton displays an image and responds to a tap or click that directs an application to carry out a particular task.

```fsharp 
let monkey =  "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"

View.ImageButton(
    source = Image.ImagePath monkey
)
```