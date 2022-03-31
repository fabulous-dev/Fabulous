---
title : "NavigationPage"
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

A Page that manages the navigation and user-experience of a stack of other pages.

### Basic example
```fs 
View.NavigationPage
    (
        pages = [
            View.ContentPage(title = "ContentPage", content = View.Label("NavigationPage with a single Label"))
        ]
    )
```

<img src="images/pages/navigation-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling
```fs 
View.NavigationPage
    (
        pages = [
            View.ContentPage(
                title = "ContentPage", 
                content = 
                    View.Label
                        (
                            horizontalOptions = model.MyStyle.Position,
                            verticalOptions = model.MyStyle.Position,
                            backgroundColor = model.MyStyle.ViewColor,
                            padding = model.MyStyle.Padding,
                            text = "NavigationPage with a single Label" "
                        )
        ]
    )
```

<img src="images/pages/navigation-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [`Xamarin.Forms.NavigationPage`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.NavigationPage)