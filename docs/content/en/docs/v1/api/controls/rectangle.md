---
title : "Rectangle"
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
View.Rectangle(
    fill = View.SolidColorBrush(Color.Black),
    stroke = View.SolidColorBrush(Color.Orange),
    strokeThickness = 5.,
    width = 150.,
    height = 50.
)
```

<img src="images/view/Rectangle-adr-basic.png" width="300">

## Basic example with styling

```fs
View.Rectangle(
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

See also:

* [Rectangle in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/shapes/Rectangle)
* [`Xamarin.Forms.Rectangle`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Rectangle)

## More examples

`Rectangle` can be used to draw rectangles and squares.

```fs
// Filled rectangle
View.Rectangle(
    fill = View.SolidColorBrush(Color.Red),
    width = 150.,
    height = 50.,
    horizontalOptions = LayoutOptions.Start
)

// Square
View.Rectangle(
    stroke = View.SolidColorBrush(Color.Red),
    strokeThickness = 4.,
    width = 150.,
    height = 150.,
    horizontalOptions = LayoutOptions.Start
)

// Rectangle with stroke
View.Rectangle(
    stroke = View.SolidColorBrush(Color.Red),
    strokeThickness = 4.,
    width = 150.,
    height = 50.,
    horizontalOptions = LayoutOptions.Start
)

// Filled rectangle with stroke
View.Rectangle(
    fill = View.SolidColorBrush(Color.DarkBlue),
    stroke = View.SolidColorBrush(Color.Red),
    strokeThickness = 4.,
    width = 150.,
    height = 50.,
    horizontalOptions = LayoutOptions.Start
)

// Filled rectangle with dashed stroke
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

// Rectangle with rounded corners
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
