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

## Basic example

```fs
View.ProgressBar(progress = 0.5)
```

<img src="images/view/ProgressBar-adr-basic.png" width="300">

## Basic example with styling

```fs
View.ProgressBar(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.LayoutColor,
    progress = 0.5
)
```

<img src="images/view/ProgressBar-adr-styled.png" width="300">

See also:

* [ProgressBar in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/ProgressBar)
* [`Xamarin.Forms.ProgressBar`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.ProgressBar)
