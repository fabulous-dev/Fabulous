---
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
weight: 101
toc: true
---

### Basic example


```fs 
View.Path(stroke = View.SolidColorBrush(Color.Black), data = Content.fromString "M 10,100 C 100,0 200,200 300,100")
```

<img src="images/view/Path-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fs 
View.Path
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.ViewColor,                                
        stroke = View.SolidColorBrush(Color.Black),
        data = Content.fromString "M 10,100 C 100,0 200,200 300,100"
    )
```


<img src="images/view/Path-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [Path in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/shapes/Path)
* [`Xamarin.Forms.Path`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Path)

<br /> 

### More examples

 `Path` can be used to draw curves and complex shapes. These curves and shapes are often described using Geometry objects. 

```fs 
View.Label(text = "Path")
View.Path(
    stroke = View.SolidColorBrush(Color.Black),
    aspect = Stretch.Uniform,
    horizontalOptions = LayoutOptions.Center,
    data = Content.fromString "M 10,50 L 200,70"
)

View.Label(text = "Cubic Bezier Path")
View.Path(
    stroke = View.SolidColorBrush(Color.Black),
    aspect = Stretch.Uniform,
    horizontalOptions = LayoutOptions.Center,
    data = Content.fromString "M 10,100 C 100,0 200,200 300,100"
)
```