---
id: "v2-carousel-view"
title: "CarouselView"
description: ""
lead: ""
date: 2022-06-03T00:00:00+00:00
lastmod: 2022-06-03T00:00:00+00:00
draft: false
images: []
menu:
  docs:
    parent: "collections"
toc: true
---

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "navigable-element.md" >}}) -> [VisualElement]({{< ref "visual-element.md" >}})  -> [View]({{< ref "view.md" >}}) -> [View]({{< ref "items-view.md" >}})  
**Xamarin.Forms documentation:** CarouselView [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.carouselview) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/carouselview)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/carouselview).

## Constructors

| Constructors | Description |
|--|--|
| CarouselView(items: seq<'itemData>) | Creates a CarouselView with the specified items. |

## Properties

| Properties | Description |
|--|--|
| isBounceEnabled(value: bool) | Sets a value that indicates whether the scrolling bounce is enabled. |
| isDragging(value: bool) | Sets a value that indicates whether the scroll dragging is enabled. |
| isScrollAnimated(value: bool) | Sets a value that indicates whether the scrolling is animated. |
| isSwipeEnabled(value: bool) | Sets a value that indicates whether the scrolling swipe is enabled. |
| loop(value: bool) | Sets a value that indicates whether the scrolling loop is enabled. |
| peekAreaInsets(value: Thickness) | Sets a value that indicates the peek area insets. |
| peekAreaInsets(value: float) | Sets a value that indicates the peek area insets. |
| peekAreaInsets(left: float, top: float, right: float, bottom: float) | Sets values that indicates the peek area insets. |
| indicatorView(value: ViewRef&lt;IndicatorView&gt;) | Sets a value that indicates the indicator view. |
| reference(value: ViewRef&lt;CarouselView&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.CarouselView` instance associated to this widget |

## Events

| Properties | Description |
|--|--|
| onScrollToRequested(onScrollToRequested: ScrollToRequestEventArgs -> 'msg) | Event that is fired when one of the ScrollTo methods is invoked. The ScrollToRequestedEventArgs object that accompanies the ScrollToRequested event has many properties, including IsAnimated, Index, Item, and ScrollToPosition. These properties are set from the arguments specified in the ScrollTo method calls. |
| onScrolled(ItemsViewScrolledEventArgs -> 'msg) | Event that is fired to indicate that scrolling occurred. The ItemsViewScrolledEventArgs object that accompanies the Scrolled event has many properties. |

## Usages

```fs
let items = [ 1 .. 1000 ]

let indicatorViewRef = ViewRef<IndicatorView>()

(CarouselView(items)
    (fun item -> Label($"{item}")))
    .indicatorView(indicatorViewRef)
    .isScrollAnimated(false)
    .isSwipeEnabled(false)
    .isBounceEnabled(false)
    .isDragging(false)
```

### Get access to the underlying Xamarin.Forms.CollectionView

```fs
let carouselViewRef = ViewRef<CarouselView>()

(CarouselView(items)
    (fun item -> Label($"{item}")))
    .reference(carouselViewRef)
```
