---
id: "v1-path"
title : "Path"
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
View.Path(
    stroke = View.SolidColorBrush(Color.Black),
    data = Content.fromString "M 10,100 C 100,0 200,200 300,100"
)
```

## Basic example with styling

```fs
View.Path(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.ViewColor,
    stroke = View.SolidColorBrush(Color.Black),
    data = Content.fromString "M 10,100 C 100,0 200,200 300,100"
)
```

See also:

* [Path in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/shapes/Path)
* [`Xamarin.Forms.Path`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Path)

## More examples

`Path` can be used to draw curves and complex shapes. These curves and shapes are often described using Geometry objects.

```fs
// Path
View.Path(
    stroke = View.SolidColorBrush(Color.Black),
    aspect = Stretch.Uniform,
    horizontalOptions = LayoutOptions.Center,
    data = Content.fromString "M 10,50 L 200,70"
)

// Cubic Bezier Path
View.Path(
    stroke = View.SolidColorBrush(Color.Black),
    aspect = Stretch.Uniform,
    horizontalOptions = LayoutOptions.Center,
    data = Content.fromString "M 10,100 C 100,0 200,200 300,100"
)
```
