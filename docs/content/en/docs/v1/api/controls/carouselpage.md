---
id: "v1-carouselpage"
title : "CarouselPage"
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
View.CarouselPage(
    children = [
        View.ContentPage(
            title ="carousel1",
            content = View.Label("carousel page 1")
        )
        View.ContentPage(
            title ="carousel2",
            content = View.Label("carousel page 2")
        )
    ]
)
```

## Basic example with styling

```fs
View.CarouselPage(
    backgroundColor = style.PageColor,
    title = "CarouselPage",
    children = [
        View.ContentPage(
            title ="carousel1",
            content = View.Label(
                horizontalOptions = style.Position,
                verticalOptions = style.Position,
                backgroundColor = style.ViewColor,
                padding = style.Padding,
                text = "carousel page 1"
            )
        )
        View.ContentPage(
            title ="carousel1",
            content = View.Label(
                horizontalOptions = style.Position,
                verticalOptions = style.Position,
                backgroundColor = style.ViewColor,
                padding = style.Padding,
                text = "carousel page 2"
            )
        )
    ]
)
```

See also:

* [`Xamarin.Forms.CarouselPage`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.CarouselPage)
