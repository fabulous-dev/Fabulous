---
id: "v1-polyline"
title : "Polyline"
description: ""
lead: ""
date: 2022-03-31T00:00:00+00:00
lastmod: 2022-03-31T00:00:00+00:00
draft: false
images: []
menu:
    docs:
        parent: "controls"
toc: true
---

## Basic example

```fs
View.Polyline(
    points = Points.fromString "0,0 10,30, 15,0 18,60 23,30 35,30 40,0 43,60 48,30 100,30",
    stroke = View.SolidColorBrush(Color.Black),
    strokeThickness = 1.
)
```

## Basic example with styling

```fs
View.Polyline(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.ViewColor,
    margin = style.Thickness,  
    points = Points.fromString "0,0 10,30, 15,0 18,60 23,30 35,30 40,0 43,60 48,30 100,30",
    stroke = View.SolidColorBrush(Color.Black),
    strokeThickness = 1.
)
```

See also:

* [Polyline in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/shapes/Polyline)
* [`Xamarin.Forms.Polyline`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Polyline)

## More examples

`Polyline` can be used to draw a series of connected straight lines. A polyline is similar to a polygon, except the last point in a polyline is not connected to the first point.

```fs
let polylinePoints1 = "0,0 10,30, 15,0 18,60 23,30 35,30 40,0 43,60 48,30 100,30"
let polylinePoints2 = "0 48, 0 144, 96 150, 100 0, 192 0, 192 96, 50 96, 48 192, 150 200 144 48"
let polylinePoints3 = "20 20,250 50,20 120"

// Polygon
View.Polyline(
    points = Points.fromString polylinePoints1,
    stroke = View.SolidColorBrush(Color.Red),
    strokeThickness = 1.
)

// Polyline with dashed stroke
View.Polyline(
    points = Points.fromString polylinePoints1,
    stroke = View.SolidColorBrush(Color.Red),
    strokeThickness = 2.,
    strokeDashArray = [ 1.; 1. ],
    strokeDashOffset = 6.
)

// EvenOdd polyline
View.Polyline(
    points = Points.fromString polylinePoints2,
    fill = View.SolidColorBrush(Color.Blue),
    fillRule = Shapes.FillRule.EvenOdd,
    stroke = View.SolidColorBrush(Color.Red),
    strokeThickness = 3.
)

// NonZero polyline
View.Polyline(
    points = Points.fromString polylinePoints2,
    fill = View.SolidColorBrush(Color.Black),
    fillRule = Shapes.FillRule.Nonzero,
    stroke = View.SolidColorBrush(Color.Yellow),
    strokeThickness = 3.
)

// LineJoin: Miter
View.Polyline(
    points = Points.fromString polylinePoints3,
    stroke = View.SolidColorBrush(Color.DarkBlue),
    strokeThickness = 20.,
    strokeLineJoin = Shapes.PenLineJoin.Miter
)

// LineJoin: Bevel
View.Polyline(
    points = Points.fromString polylinePoints3,
    stroke = View.SolidColorBrush(Color.DarkBlue),
    strokeThickness = 20.,
    strokeLineJoin = Shapes.PenLineJoin.Bevel
)

// LineJoin: Round
View.Polyline(
    points = Points.fromString polylinePoints3,
    stroke = View.SolidColorBrush(Color.DarkBlue),
    strokeThickness = 20.,
    strokeLineJoin = Shapes.PenLineJoin.Round
)
```
