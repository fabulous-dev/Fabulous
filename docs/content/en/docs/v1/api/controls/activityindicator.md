---
title : "ActivityIndicator"
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
View.ActivityIndicator(isRunning = true)
```

<img src="images/view/ActivityIndicator-adr-basic.png" width="300">

## Basic example with styling

```fs
View.ActivityIndicator(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.LayoutColor,
    isRunning = true
)
```

<img src="images/view/ActivityIndicator-adr-styled.png" width="300">

See also:

* [ActivityIndicator in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/ActivityIndicator)
* [`Xamarin.Forms.ActivityIndicator`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.ActivityIndicator)

## More examples

A simple `ActivityIndicator` is as follows:

```fs
View.ActivityIndicator(
    isRunning = (count > 0)
)
```

<img src="https://user-images.githubusercontent.com/52166903/60177355-9c424c00-9810-11e9-8275-bd8c2ebcf3c8.png" width="400">
