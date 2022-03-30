{% include_relative _header.md %}

{% include_relative contents.md %}

Rectangle
--------
##### `topic last updated: v1.0 - 24.04.2021 - 11:47pm`

### [back to interface objects](view-interface-objects.html#interface-objects)

<br />

### Basic example


```fsharp 
View.Rectangle
    (                   
        fill = View.SolidColorBrush(Color.Black),
        stroke = View.SolidColorBrush(Color.Orange),
        strokeThickness = 5.,                                
        width = 150.,
        height = 50.
    )
```

<img src="images/view/Rectangle-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.Rectangle
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.ViewColor,      
        margin = style.Thickness,                            
        fill = View.SolidColorBrush(Color.Black),
        stroke = View.SolidColorBrush(Color.Orange),
        strokeThickness = 5.,                                
        width = 150.,
        height = 50.
    )
```


<img src="images/view/Rectangle-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [Rectangle in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/shapes/Rectangle)
* [`Xamarin.Forms.Rectangle`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Rectangle)

<br /> 

### More examples

`Rectangle` can be used to draw rectangles and squares. 

```fsharp 
View.Label("Filled rectangle")
View.Rectangle(
    fill = View.SolidColorBrush(Color.Red),
    width = 150.,
    height = 50.,
    horizontalOptions = LayoutOptions.Start
)

View.Label("Square")
View.Rectangle(
    stroke = View.SolidColorBrush(Color.Red),
    strokeThickness = 4.,
    width = 150.,
    height = 150.,
    horizontalOptions = LayoutOptions.Start
)

View.Label("Rectangle with stroke")
View.Rectangle(
    stroke = View.SolidColorBrush(Color.Red),
    strokeThickness = 4.,
    width = 150.,
    height = 50.,
    horizontalOptions = LayoutOptions.Start
)

View.Label("Filled rectangle with stroke")
View.Rectangle(
    fill = View.SolidColorBrush(Color.DarkBlue),
    stroke = View.SolidColorBrush(Color.Red),
    strokeThickness = 4.,
    width = 150.,
    height = 50.,
    horizontalOptions = LayoutOptions.Start
)

View.Label("Filled rectangle with dashed stroke")
View.Rectangle(
    fill = View.SolidColorBrush(Color.DarkBlue),
    stroke = View.SolidColorBrush(Color.Red),
    strokeThickness = 4.,
    strokeDashArray = [ 1.; 1. ],
    strokeDashOffset = 6.,
    width = 150.,
    height = 50.,
    horizontalOptions = LayoutOptions.Start
)

View.Label("Rectangle with rounded corners")
View.Rectangle(
    fill = View.SolidColorBrush(Color.Blue),
    stroke = View.SolidColorBrush(Color.Black),
    strokeThickness = 3.,
    radiusX = 50.,
    radiusY = 10.,
    width = 200.,
    height = 100.,
    horizontalOptions = LayoutOptions.Start
)
```