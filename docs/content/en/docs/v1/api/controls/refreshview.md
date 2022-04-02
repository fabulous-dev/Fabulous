---
title : "RefreshVIew"
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
View.RefreshView(
    View.ListView([
        View.TextCell("First item")
        View.TextCell("Second item")
        View.TextCell("Third item")
    ])
)
```

<img src="images/view/RefreshView-adr-basic.png" width="300">

## Basic example with styling

```fs
View.RefreshView(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.LayoutColor,
    padding = style.Padding,
    content = 
        View.ListView(
            horizontalOptions = style.Position,
            verticalOptions = style.Position,
            backgroundColor = style.ViewColor,
            items = [
                View.TextCell("First item")
                View.TextCell("Second item")
                View.TextCell("Third item")
            ]
        )
)
```

<img src="images/view/RefreshView-adr-styled.png" width="300">

See also:

* [RefreshView in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/RefreshView)
* [`Xamarin.Forms.RefreshView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.RefreshView)

## More examples

The RefreshView is a container control that provides pull to refresh functionality for scrollable content. Therefore, the child of a RefreshView must be a scrollable control, such as ScrollView, CollectionView, or ListView.

```fs
View.RefreshView(
    View.ScrollView(
        View.BoxView(
            height = 150.,
            width = 150.,
            color = if model.IsRefreshing then Color.Red else Color.Blue
        )
    ),
    isRefreshing = model.IsRefreshing,
    refreshing = (fun () -> dispatch Refresh)
)
```
