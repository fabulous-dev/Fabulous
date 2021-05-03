{% include_relative _header.md %}

{% include_relative contents.md %}

Line
--------
##### `topic last updated: v1.0 - 24.04.2021 - 11:47pm`

### [back to interface objects](view-interface-objects.html#interface-objects)

<br />

### Basic example


```fsharp 
View.Line
    (
        stroke = View.SolidColorBrush(Color.Black),
        x1 = 40., 
        y1 = 0., 
        x2 = 0., 
        y2 = 120.
    )
```

<img src="images/views/Line-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.Line
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.ViewColor,
        stroke = View.SolidColorBrush(Color.Black),
        x1 = 40., 
        y1 = 0., 
        x2 = 0., 
        y2 = 120.
    )
```


<img src="images/views/Line-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [Line in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/shapes/Line)
* [`Xamarin.Forms.Line`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Line)

<br /> 

### More examples

`Line` can be used to draw lines.

```fsharp 
View.Label(text = "Line")
View.Line(x1 = 40., y1 = 0., x2 = 0., y2 = 120., stroke = View.SolidColorBrush(Color.Red))

View.Label(text = "Line with stroke")
View.Line(x1 = 40., y1 = 0., x2 = 0., y2 = 120., stroke = View.SolidColorBrush(Color.DarkBlue), strokeThickness = 4.)

View.Label(text = "Dashed line")
View.Line(x1 = 40., y1 = 0., x2 = 0., y2 = 120., stroke = View.SolidColorBrush(Color.DarkBlue), strokeDashArray = [ 1.; 1. ], strokeDashOffset = 6.)

View.Label(text = "LineCap: Flat")
View.Line(x1 = 0., y1 = 20., x2 = 300., y2 = 20., stroke = View.SolidColorBrush(Color.Red), strokeThickness = 12., strokeLineCap = Shapes.PenLineCap.Flat)

View.Label(text = "LineCap: Square")
View.Line(x1 = 0., y1 = 20., x2 = 300., y2 = 20., stroke = View.SolidColorBrush(Color.Red), strokeThickness = 12., strokeLineCap = Shapes.PenLineCap.Square)

View.Label(text = "LineCap: Round")
View.Line(x1 = 0., y1 = 20., x2 = 300., y2 = 20., stroke = View.SolidColorBrush(Color.Red), strokeThickness = 12., strokeLineCap = Shapes.PenLineCap.Round)
```