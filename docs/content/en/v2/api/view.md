---
id: "v2-view"
title: "View"
description: ""
lead: ""
date: 2022-03-24T00:00:00+00:00
lastmod: 2022-03-24T00:00:00+00:00
draft: false
images: []
menu:
  docs:
    parent: "api"
toc: true
---

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "navigableelement.md" >}}) -> [VisualElement]({{< ref "visualelement.md" >}})  
**Xamarin.Forms documentation:** View [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.view)

## Constructors

This control can't be instantiated on its own. Its properties and events are inherited by its descendants.

## Properties

| Properties | Description |
|--|--|
| horizontalOptions(value: LayoutOptions) | Sets the LayoutOptions that define how the element gets laid horizontally in a layout cycle. |
| verticalOptions(value: LayoutOptions) | Sets the LayoutOptions that define how the element gets laid vertically in a layout cycle. |
| center(?expand: bool) | Set the LayoutOptions that defined if an element that is centered vertically and horizontally, and does expand or not. false is the default value. |
| centerHorizontal(?expand: bool) | Set the LayoutOptions that defined if an element that is centered horizontally and does expand or not. false is the default value. |
| centerVertical(?expand: bool) | Set the LayoutOptions that defined if an element that is centered vertically and does expand or not. false is the default value. |
| alignStartHorizontal(?expand: bool) | Set the LayoutOptions that defined if an element that is aligned to the start horizontally and does expand or not. false is the default value. |
| alignStartVertical(?expand: bool) | Set the LayoutOptions that defined if an element that is aligned to the start vertically and does expand or not. false is the default value. |
| alignEndHorizontal(?expand: bool) | Set the LayoutOptions that defined if an element that is aligned to the end horizontally and does expand or not. false is the default value. |
| alignEndVertical(?expand: bool) | Set the LayoutOptions that defined if an element that is aligned to the end vertically and does expand or not. false is the default value. |
| fillHorizontal(?expand: bool) | Set the LayoutOptions that defined if an element that is filled horizontally and does expand or not. false is the default value. |
| fillVertical(?expand: bool) | Set the LayoutOptions that defined if an element that is filled vertically and does expand or not. false is the default value. |
| margin(value: Thickness) | Sets the margin of the element. |
| margin(value: float) | Sets the margin of the element. |
| margin(left: float, top: float, right: float, bottom: float) | Sets the left, top, right and bottom margin of the element. |
| gestureRecognizers() | Sets the gesture recognizers of the element. |
