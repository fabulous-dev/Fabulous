---
id: "v1-tabbedpage"
title : "TabbedPage"
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
View.TabbedPage([
    View.ContentPage(
        title = "First Tab",
        content = View.Label("TabbedPage 1")
    )
    View.ContentPage(
        title = "Second Tab",
        content = View.Label("TabbedPage 2")
    )
])
```

## Basic example with styling

```fs
View.TabbedPage(
    backgroundColor = style.PageColor,
    title = "TabbedPage",
    children = [
        View.ContentPage(
            title ="First Tab",
            content = View.Label(
                horizontalOptions = style.Position,
                verticalOptions = style.Position,
                backgroundColor = style.ViewColor,
                padding = style.Padding,
                text = "TabbedPage 1" 
            ) 
        )
        View.ContentPage(
            title ="Second Tab",
            content = View.Label(
                horizontalOptions = style.Position,
                verticalOptions = style.Position,
                backgroundColor = style.ViewColor,
                padding = style.Padding,
                text = "TabbedPage 2"
            )
        )
    ]
)
```

See also:

* [`Xamarin.Forms.TabbedPage`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.TabbedPage)
