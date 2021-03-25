{% include_relative _header.md %}

{% include_relative contents.md %}

Interface objects (Views) for presentation
------
##### (topic last updated: v 0.61.0)
<br /> 

### BoxView
An example `BoxView` is as follows:
```fsharp 
View.BoxView(
    color = Color.CornflowerBlue, 
    cornerRadius = CornerRadius 10., 
    horizontalOptions = LayoutOptions.Center
    )
```
<img src="https://user-images.githubusercontent.com/6429007/60753625-c1377b80-9fd5-11e9-91cc-eaef04a372cf.png" width="400">

See also:

* [`Xamarin.Forms.Core.BoxView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.BoxView)

<br /> 

### Ellipse
```fsharp 
View.Ellipse(
    width = 50.,
    height = 50.,
    fill = View.SolidColorBrush(Color.Orange),
    horizontalOptions = LayoutOptions.Center 
    )
```

<br /> 

### Label
```fsharp 
View.Label(text = "this is a label")
```

<br /> 

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

<br /> 

### Image
A simple image drawn from a resource or URL is as follows:

```fsharp
let monkey =  "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
                    
View.Image( source =  Image.ImagePath monkey)
```

<img src="https://user-images.githubusercontent.com/52166903/60180198-5d63c480-9817-11e9-9458-379a848ccca4.png" width="400">

See also:

* [Images in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/images?tabs=vswin)
* [`Xamarin.Forms.Core.Image`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Image)

<br /> 

### Map
```fsharp 

```

<br /> 

### OpenGLView
```fsharp 

```
<br /> 

### Path
```fsharp 

```

<br /> 

### Polygon
```fsharp 

```

<br /> 

### Polyline
```fsharp 

```

<br /> 

### Rectangle
```fsharp 

```

<br /> 

### WebView
```fsharp 

```
