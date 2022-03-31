---
title : "Ellipse"
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
View.Ellipse(fill = View.SolidColorBrush(Color.Black), width = 50., height = 50.)
```

<img src="images/view/Ellipse-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fs 
View.Ellipse
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.ViewColor,
        fill = View.SolidColorBrush(Color.Black),
        width = 50.,
        height = 50.
    )
```


<img src="images/view/Ellipse-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [Ellipse in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/shapes/Ellipse)
* [`Xamarin.Forms.Ellipse`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Ellipse)

<br /> 

### More examples

`Ellipse` can be used to draw ellipses and circles.

```fs 
View.Ellipse(
    width = 50.,
    height = 50.,
    fill = View.SolidColorBrush(Color.Orange),
    horizontalOptions = LayoutOptions.Center 
    )
```