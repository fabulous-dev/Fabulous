{% include_relative _header.md %}

{% include_relative contents.md %}

Interface objects (Views) for presentation
------
##### `topic last updated: v1.0 - 04.04.2021 - 02:51pm`
<br /> 

| Name                                      | Description                                                                                | Appearance                                                  |
|-------------------------------------------|--------------------------------------------------------------------------------------------|-------------------------------------------------------------|
| [BoxView](interface/present/BoxView.md)   | renders a simple rectangle of a specified width, height, and color                         | <img src="images/views/BoxView-adr-styled.png" width="300"> |
| [Image](interface/present/Image.md)       | can be loaded specifically for each platform, or they can be downloaded for display        | <img src="images/views/Image-adr-styled.png" width="300">   |
| [Label](interface/present/Label.md)       | used for displaying text, both single and multi-line                                       | <img src="images/views/Label-adr-styled.png" width="300">   |
| [Map](interface/present/Map.md)           | a cross-platform view for displaying and annotating maps                                   | <img src="images/views/Map-adr-styled.png" width="300">  |
| [Ellipse](interface/present/Ellipse.md)   | derives from the Shape class, and can be used to draw ellipses and circles                 | <img src="images/views/Ellipse-adr-styled.png" width="300">  |
| [Line](interface/present/Line.md)         | derives from the Shape class, and can be used to draw lines                                | <img src="images/views/Line-adr-styled.png" width="300">  |
| [Path](interface/present/Path.md)         | derives from the Shape class, and can be used to draw curves and complex shapes            | <img src="images/views/Path-adr-styled.png" width="300">  |
| [Polygon](interface/present/Polygon.md)   | derives from the Shape class, and can be used to draw polygons                             | <img src="images/views/Polygon-adr-styled.png" width="300">  |
| [Polyline](interface/present/Polyline.md) | derives from the Shape class, and can be used to draw a series of connected straight lines | <img src="images/views/Polyline-adr-styled.png" width="300">  |
| [Rectangle](interface/present/Rectangle.md)| derives from the Shape class, and can be used to draw rectangles and squares.              | <img src="images/views/Rectangle-adr-styled.png" width="300">  |
| [WebView](interface/present/WebView.md)   | supports: HTML&CSS websites, Documents, HTML strings, Local Files                          | <img src="images/views/WebView-adr-styled.png" width="300">  |
| [OpenGlView](interface/present/OpenGlView.md) | displays OpenGL content                                                                    | <img src="images/views/OpenGlView-adr-styled.png" width="300">  |



### Polygon

`Polygon` can be used to draw polygons, which are connected series of lines that form closed shapes. 

```fsharp 
let polygonPoints1 = "40,10 70,80 10,50"
let polygonPoints2 = "0 48, 0 144, 96 150, 100 0, 192 0, 192 96, 50 96, 48 192, 150 200 144 48"

View.Label("Polygon")
View.Polygon(
    points = Points.fromString polygonPoints1,
    fill = View.SolidColorBrush(Color.AliceBlue),
    stroke = View.SolidColorBrush(Color.Green),
    strokeThickness = 5.
)

View.Label("Polygon with dashed stroke")
View.Polygon(
    points = Points.fromString polygonPoints1,
    fill = View.SolidColorBrush(Color.AliceBlue),
    stroke = View.SolidColorBrush(Color.Green),
    strokeThickness = 5.,
    strokeDashArray = [ 1.; 1. ],
    strokeDashOffset = 6.
)

View.Label("EvenOdd polygon")
View.Polygon(
    points = Points.fromString polygonPoints2,
    fill = View.SolidColorBrush(Color.Blue),
    fillRule = Shapes.FillRule.EvenOdd,
    stroke = View.SolidColorBrush(Color.Red),
    strokeThickness = 3.
)

View.Label("NonZero polygon")
View.Polygon(
    points = Points.fromString polygonPoints2,
    fill = View.SolidColorBrush(Color.Black),
    fillRule = Shapes.FillRule.Nonzero,
    stroke = View.SolidColorBrush(Color.Yellow),
    strokeThickness = 3.
)
```

See also:

* [Polygon in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/shapes/polygon)
* [`Xamarin.Forms.Shapes.Polygon`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.shapes.polygon?view=xamarin-forms)

<br /> 

### Polyline

`Polyline` can be used to draw a series of connected straight lines. A polyline is similar to a polygon, except the last point in a polyline is not connected to the first point. 

```fsharp 
let polylinePoints1 = "0,0 10,30, 15,0 18,60 23,30 35,30 40,0 43,60 48,30 100,30"
let polylinePoints2 = "0 48, 0 144, 96 150, 100 0, 192 0, 192 96, 50 96, 48 192, 150 200 144 48"
let polylinePoints3 = "20 20,250 50,20 120"

View.Label("Polygon")
View.Polyline(
    points = Points.fromString polylinePoints1,
    stroke = View.SolidColorBrush(Color.Red),
    strokeThickness = 1.
)

View.Label("Polyline with dashed stroke")
View.Polyline(
    points = Points.fromString polylinePoints1,
    stroke = View.SolidColorBrush(Color.Red),
    strokeThickness = 2.,
    strokeDashArray = [ 1.; 1. ],
    strokeDashOffset = 6.
)

View.Label("EvenOdd polyline")
View.Polyline(
    points = Points.fromString polylinePoints2,
    fill = View.SolidColorBrush(Color.Blue),
    fillRule = Shapes.FillRule.EvenOdd,
    stroke = View.SolidColorBrush(Color.Red),
    strokeThickness = 3.
)

View.Label("NonZero polyline")
View.Polyline(
    points = Points.fromString polylinePoints2,
    fill = View.SolidColorBrush(Color.Black),
    fillRule = Shapes.FillRule.Nonzero,
    stroke = View.SolidColorBrush(Color.Yellow),
    strokeThickness = 3.
)

View.Label("LineJoin: Miter")
View.Polyline(
    points = Points.fromString polylinePoints3,
    stroke = View.SolidColorBrush(Color.DarkBlue),
    strokeThickness = 20.,
    strokeLineJoin = Shapes.PenLineJoin.Miter
)

View.Label("LineJoin: Bevel")
View.Polyline(
    points = Points.fromString polylinePoints3,
    stroke = View.SolidColorBrush(Color.DarkBlue),
    strokeThickness = 20.,
    strokeLineJoin = Shapes.PenLineJoin.Bevel
)

View.Label("LineJoin: Round")
View.Polyline(
    points = Points.fromString polylinePoints3,
    stroke = View.SolidColorBrush(Color.DarkBlue),
    strokeThickness = 20.,
    strokeLineJoin = Shapes.PenLineJoin.Round
)
```

See also:

* [Polyline in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/shapes/polyline)
* [`Xamarin.Forms.Shapes.Polyline`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.shapes.polyline?view=xamarin-forms)

<br /> 

### Rectangle

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

See also:

* [Rectangle in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/shapes/rectangle)
* [`Xamarin.Forms.Shapes.Rectangle`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.shapes.rectangle?view=xamarin-forms)

<br /> 

### WebView

`WebView` is a view for displaying web and HTML content in your app:

```fsharp 
let fabulousSite = "https://fsprojects.github.io/Fabulous/Fabulous.XamarinForms/"
View.WebView( 
    source = UrlWebViewSource.op_Implicit fabulousSite, 
    backgroundColor = Color.Red,
    margin = Thickness(20.)
)
```

See also:

* [WebView in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/webview?tabs=windows)
* [`Xamarin.Forms.Shapes.WebView`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.webview?view=xamarin-forms)

<br /> 

### Map

This topic is covered [here](extensions-maps.md)

<br /> 

### OpenGLView

A View that displays OpenGL content.

```fsharp
View.OpenGLView(
    hasRenderLoop = true,
    margin = Thickness 20.
)
```
See also:

* [`Xamarin.Forms.Shapes.OpenGLView`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.openglview?view=xamarin-forms)