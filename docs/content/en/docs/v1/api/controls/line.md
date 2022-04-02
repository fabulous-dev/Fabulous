---
title : "Line"
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

## Basic example

```fs
View.Line(
    stroke = View.SolidColorBrush(Color.Black),
    x1 = 40.,
    y1 = 0.,
    x2 = 0.,
    y2 = 120.
)
```

<img src="images/view/Line-adr-basic.png" width="300">

## Basic example with styling

```fs
View.Line(
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

<img src="images/view/Line-adr-styled.png" width="300">

See also:

* [Line in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/shapes/Line)
* [`Xamarin.Forms.Line`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Line)

## More examples

`Line` can be used to draw lines.

```fs
// Line
View.Line(
    x1 = 40.,
    y1 = 0.,
    x2 = 0.,
    y2 = 120.,
    stroke = View.SolidColorBrush(Color.Red)
)

// Line with stroke
View.Line(
    x1 = 40.,
    y1 = 0.,
    x2 = 0.,
    y2 = 120.,
    stroke = View.SolidColorBrush(Color.DarkBlue),
    strokeThickness = 4.
)

// Dashed line
View.Line(
    x1 = 40.,
    y1 = 0.,
    x2 = 0.,
    y2 = 120.,
    stroke = View.SolidColorBrush(Color.DarkBlue),
    strokeDashArray = [ 1.; 1. ],
    strokeDashOffset = 6.
)

// LineCap: Flat
View.Line(
    x1 = 0.,
    y1 = 20.,
    x2 = 300.,
    y2 = 20.,
    stroke = View.SolidColorBrush(Color.Red),
    strokeThickness = 12.,
    strokeLineCap = Shapes.PenLineCap.Flat
)

// LineCap: Square
View.Line(
    x1 = 0.,
    y1 = 20.,
    x2 = 300.,
    y2 = 20.,
    stroke = View.SolidColorBrush(Color.Red),
    strokeThickness = 12.,
    strokeLineCap = Shapes.PenLineCap.Square
)

// LineCap: Round
View.Line(
    x1 = 0.,
    y1 = 20.,
    x2 = 300.,
    y2 = 20.,
    stroke = View.SolidColorBrush(Color.Red),
    strokeThickness = 12.,
    strokeLineCap = Shapes.PenLineCap.Round
)
```
