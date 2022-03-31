---
title : "CarouselView"
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

displays a scrollable list of data 

<br /> 

### Basic example


```fs 
View.CarouselView(items = [
    View.Label("First CarouselView")
    View.Label("Second CarouselView")
    View.Label("Third CarouselView")
] )
```

<img src="images/view/CarouselView-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fs 
View.CarouselView
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.LayoutColor,
        items = [
            View.Label
                (
                    horizontalOptions = style.Position,
                    verticalOptions = style.Position,
                    backgroundColor = style.ViewColor,
                    padding = style.Padding,  
                    text = ("First CarouselView")
                )
            View.Label
                (
                    horizontalOptions = style.Position,
                    verticalOptions = style.Position,
                    backgroundColor = style.ViewColor2,
                    padding = style.Padding,  
                    text = ("Second CarouselView")
                )
            View.Label
                (
                    horizontalOptions = style.Position,
                    verticalOptions = style.Position,
                    backgroundColor = style.ViewColor3,
                    padding = style.Padding,  
                    text = ("Third CarouselView")
                )
        ] 
    )
```


<img src="images/view/CarouselView-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [CarouselView in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/CarouselView)
* [`Xamarin.Forms.CarouselView`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.carouselview?view=xamarin-forms)