---
title : "OpenGLView"
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
View.OpenGLView(hasRenderLoop = true)
```

<img src="images/view/OpenGLView-adr-basic.png" width="300">

## Basic example with styling

```fs
View.OpenGLView(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.ViewColor,
    margin = style.Thickness,
    hasRenderLoop = true
)
```

<img src="images/view/OpenGLView-adr-styled.png" width="300">

See also:

* [`Xamarin.Forms.OpenGLView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.OpenGLView)
