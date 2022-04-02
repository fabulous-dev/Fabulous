---
title : "ContentPage"
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

A single page app typically returns a `ContentPage`. For example:

```fs
View.ContentPage(
    title = "ContentPage",
    content = View.Label("ContentPage with a single Label")
)
```

<img src="images/pages/content-adr-basic.png" width="300">

## Basic example with styling

```fs
View.ContentPage(
    backgroundColor = style.PageColor,
    title = "ContentPage",
    content = View.Label(
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.ViewColor,
        padding = style.Padding,
        text = "ContentPage with a single Label"
    )
)
```

<img src="images/pages/content-adr-styled.png" width="300">

See also:

* [`Xamarin.Forms.ContentPage`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.ContentPage)
