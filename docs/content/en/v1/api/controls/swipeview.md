---
id: "v1-swipeview"
title : "SwipeView"
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
View.SwipeView(
    leftItems =
        View.SwipeItems([
            View.SwipeItem("Left 1")
            View.SwipeItem("Left 2")
        ]),
    rightItems =
        View.SwipeItems([
            View.SwipeItem("Right 1")
            View.SwipeItem("Right 2")
        ]),
    content =
        View.Grid(
            height = 60.,
            width = 300.,
            children = [
                View.Label("test")
            ]
        )
)
```

## Basic example with styling

```fs
View.SwipeView(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.LayoutColor,
    padding = style.Padding,
    leftItems =
        View.SwipeItems([
            View.SwipeItem(
                backgroundColor = style.ViewColor,
                text = "Left 1"
            )
            View.SwipeItem(
                backgroundColor = style.ViewColor2,
                text = "Left 2"
            )
        ]),
    rightItems =
        View.SwipeItems([
            View.SwipeItem(
                backgroundColor = style.ViewColor3,
                text = "Right 1"
            )
            View.SwipeItem(
                backgroundColor = style.ViewColor4,
                text = "Right 2"
            )
        ]),
    content =
        View.Grid(
            height = 60.,
            width = 300.,
            children = [
                View.Label(
                    horizontalOptions = style.Position,
                    verticalOptions = style.Position,
                    backgroundColor = style.ViewColor,
                    padding = style.Padding,
                    text = "test"
                )
            ]
        )
)
```

See also:

* [SwipeView in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/SwipeView)
* [`Xamarin.Forms.SwipeView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.SwipeView)

## More examples

The SwipeView is a container control that wraps around an item of content, and provides context menu items that are revealed by a swipe gesture:

```fs
View.SwipeView(
    leftItems =
        View.SwipeItems([
            View.SwipeItem(text = "Left 1", backgroundColor = Color.LightPink)
            View.SwipeItem(text = "Left 2", backgroundColor = Color.LightGreen)
        ]),
    rightItems =
        View.SwipeItems([
            View.SwipeItem(text = "Right 1", backgroundColor = Color.LightPink)
            View.SwipeItem(text = "Right 2", backgroundColor = Color.LightGreen)
        ]),
    content =
        View.Grid(
            height = 60.0,
            width = 300.0,
            backgroundColor = Color.LightGray,
            children = [
                View.BoxView(Color.Blue)
            ]
        )
)
```
