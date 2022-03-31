---
title : "Polygon"
description: ""
lead: ""
date: 2022-03-31T00:00:00+00:00
lastmod: 2022-03-31T00:00:00+00:00
draft: false
images: []
menu:
    docs:
        parent: "controls"
weight: 101
toc: true
---

### Basic example


```fs 
View.Polygon
    (                           
        points = Points.fromString "40,10 70,80 10,50",
        fill = View.SolidColorBrush(Color.Black),
        stroke = View.SolidColorBrush(Color.Orange),
        strokeThickness = 5.            
    )
```

<img src="images/view/Polygon-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fs 
View.Polygon
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.ViewColor,     
        margin = style.Thickness,                             
        points = Points.fromString "40,10 70,80 10,50",
        fill = View.SolidColorBrush(Color.Black),
        stroke = View.SolidColorBrush(Color.Orange),
        strokeThickness = 5.            
    )
```


<img src="images/view/Polygon-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [Polygon in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/shapes/polygon)
* [`Xamarin.Forms.Polygon`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Polygon)

<br /> 

### More examples

`Polygon` can be used to draw polygons, which are connected series of lines that form closed shapes. 

```fs 
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