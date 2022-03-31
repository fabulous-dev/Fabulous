---
title : "ProgressBar"
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

The Progress Bar represents progress as a horizontal bar, that is filled to a percentage, represented by a float value. 

<br /> 

### Basic example


```fs 
View.ProgressBar(progress = 0.5)
```

<img src="images/view/ProgressBar-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fs 
View.ProgressBar
(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.LayoutColor,
    progress = 0.5
)
```


<img src="images/view/ProgressBar-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [ProgressBar in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/ProgressBar)
* [`Xamarin.Forms.ProgressBar`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.ProgressBar)

<br /> 

### More examples

`to-do`