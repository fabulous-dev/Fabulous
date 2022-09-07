---
id: "v2-layout"
title: "Layout"
description: ""
lead: ""
date: 2022-06-12T00:00:00+00:00
lastmod: 2022-06-12T00:00:00+00:00
draft: false
images: []
weight: 450
menu:
  docs:
    parent: "layouts"
toc: true
---

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "../navigable-element.md" >}}) -> [VisualElement]({{< ref "../visual-element.md" >}}) -> [View]({{< ref "../view.md" >}})  
**Xamarin.Forms documentation:** Layout [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.layout)

## Constructors

This control can't be instantiated on its own. Its properties and events are inherited by its descendants.

## Properties

| Properties | Description |
|--|--|
| padding(value: Thickness) | Sets the padding around of the layout. |
| padding(value: float) | Sets the padding around of the layout. |
| padding(left: float, top: float, right: float, bottom: float) | Sets the padding around of the layout. |
| cascadeInputTransparent(value: bool) | Sets a value that indicates whether the input transparent property of the children of the layout is to be cascaded. |
| isClippedToBounds(value: bool) | Sets a value that indicates whether the layout is to be clipped to its bounds. |

## Events

| Properties | Description |
|--|--|
| onLayoutChanged(value: 'msg) | Event that is fired when the layout is changed. |
