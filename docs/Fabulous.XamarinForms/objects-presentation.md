{% include_relative _header.md %}

{% include_relative contents.md %}

Views for presentation
------

<br /> 

### BoxView
```fsharp 
View.BoxView(
    color = Color.Red, 
    cornerRadius = CornerRadius 10., 
    horizontalOptions = LayoutOptions.Center
    )
```

### Ellipse
```fsharp 
View.Ellipse(
    width = 50.,
    height = 50.,
    fill = View.SolidColorBrush(Color.Orange),
    horizontalOptions = LayoutOptions.Center 
    )
```
### Label
```fsharp 
View.Label(text = "this is a label")
```
### Line
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
### Image
```fsharp 

```
### Map
```fsharp 

```
### OpenGLView
```fsharp 

```
### Path
```fsharp 

```
### Polygon
```fsharp 

```
### Polyline
```fsharp 

```
### Rectangle
```fsharp 

```
### WebView
```fsharp 

```
