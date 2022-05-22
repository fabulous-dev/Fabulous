---
id: "v1-openglview"
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
toc: true
---

## Basic example

```fs
View.OpenGLView(hasRenderLoop = true)
```

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

See also:

* [`Xamarin.Forms.OpenGLView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.OpenGLView)
