---
id: "v2-indicator-view"
title: "IndicatorView"
description: ""
lead: ""
date: 2022-06-12T00:00:00+00:00
lastmod: 2022-06-12T00:00:00+00:00
draft: false
images: []
menu:
    docs:
        parent: "controls"
toc: true
---

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "navigableelement.md" >}}) -> [VisualElement]({{< ref "visualelement.md" >}}) -> [View]({{< ref "view.md" >}}) -> [Layout]({{< ref "layout.md" >}}) -> [TemplatedView]({{< ref "templated-view.md" >}})  
**Xamarin.Forms documentation:** IndicatorView [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.indicatorview) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/indicatorview)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/indicatorview).

## Constructors

| Constructors | Description |
|--|--|
| IndicatorView(reference: ViewRef<IndicatorView>) | Creates a new instance of the control with the given reference. |

## Properties

| Properties | Description |
|--|--|
| selectedIndicatorColor(light: FabColor, ?dark: FabColor) | Sets The color of the selected indicator. |
| indicatorSize(size: float) | Sets The size of the indicator. |
| indicatorShape(shape: IndicatorShape) | Sets The shape of the indicator. |
| hideSingle(hide: bool) | Whether to hide the indicator if there is only one item. |
| indicatorColor(light: FabColor, ?dark: FabColor) | Sets the indicator color. |
| maximumVisible(count: int) | Sets the maximum number of visible indicators. |

## Usages

```fs
let indicatorViewRef = ViewRef<IndicatorView>()

IndicatorView(indicatorViewRef)
    .selectedIndicatorColor(Color.Red.ToFabColor(), Color.Blue.ToFabColor())
    .indicatorSize(24.)
    .indicatorsShape(IndicatorShape.Circle)
    .indicatorColor(Palette.MidGrey)
```
### Get access to the underlying Xamarin.Forms.IndicatorView

```fs
let indicatorViewRef = ViewRef<IndicatorView>()

IndicatorView(//TODO)
    .reference(indicatorViewRef)
```
