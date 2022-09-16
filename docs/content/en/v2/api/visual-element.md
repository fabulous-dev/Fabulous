---
id: "v2-visual-element"
title: "VisualElement"
description: ""
lead: ""
date: 2022-03-24T00:00:00+00:00
lastmod: 2022-03-24T00:00:00+00:00
draft: false
images: []
weight: 406
menu:
  docs:
    parent: "api"
toc: true
---

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "navigable-element.md" >}})  
**Xamarin.Forms documentation:** VisualElement [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.visualelement)

## Constructors

This control can't be instantiated on its own. Its properties and events are inherited by its descendants.

## Properties

| Properties | Description |
|--|--|
| anchorX(value: float) | Sets the anchor of the element on the X axis. |
| anchorY(value: float) | Sets the anchor of the element on the Y axis. |
| backgroundColor(light: FabColor, ?dark: FabColor) | | Sets the background color depending if light or dark mode. |
| background(light: Brush, ?dark: Brush) | | Sets the background brush depending if light or dark mode. |
| clip(content: WidgetBuilder<'msg, 'contentMarker>) | Clips the shape of the element based on a geometry. |
| flowDirection(value: FlowDirection) | Sets the flow direction of the element. |
| focus(isFocused: bool, onFocusChanged: bool -> 'msg) | Sets the focus state of the element and listen for any changes. |
| height(value: float) | Sets the height of an element. |
| inputTransparent(value: bool) | Sets a value indicating whether this element should interact with the user. |
| isEnabled(value: bool) | Sets a value indicating whether this element is enabled. |
| isTabStop(value: bool) | Sets a value that indicates whether a control is included in tab navigation. |
| isVisible(value: bool) | Sets a value indicating whether this element is visible. |
| minimumHeight(value: float) | Sets the minimum height of the element. |
| minimumWidth(value: float) | Sets the minimum width of the element. |
| opacity(value: float) | Sets the opacity of the element. |
| tabIndex(value: int) | Sets the tab index of the element. |
| translationX(x: float) | Translates the position of the element on the X axis. |
| translationY(y: float) | Translates the position of the element on the Y axis. |
| size(?width: float, ?height: float) | Sets the size of an element by applying the width and height of the element. |
| visual(value: IVisual) | Sets the visual of an element. With the VisualMarker class providing the following IVisual properties: Default, MatchParent, Material. |
| width(value: float) | Sets the width of an element. |

## Animations

| Properties | Description |
|--|--|
| fadeTo(opacity: float, duration: int, easing: Easing) | Animates elements Opacity property from their current values to the new values. |
| rotateTo(rotation: float, duration: int, easing: Easing) | Animates an elements Rotation property from their current values to the new values. |
| rotateXTo(rotation: float) | Animates an elements RotationX property from its current value to the new value. This ensures that the input layout is in the same position as the visual layout. |
| rotateYTo(rotation: float) | Animates an elements RotationY property from its current value to the new value. This ensures that the input layout is in the same position as the visual layout. |
| scaleTo(scale: float, duration: int, easing: Easing) | Animates elements Scale property from their current values to the new values. |
| scaleXTo(scale: float) | Animates elements ScaleX property from their current value to the new value. This ensures that the input layout is in the same position as the visual layout. |
| scaleYTo(scale: float) | Animates elements ScaleY property from their current value to the new value. This ensures that the input layout is in the same position as the visual layout. |
| translateTo(x: float, y: float, duration: int, easing: Easing) | Animates an elements TranslationX and TranslationY properties from their current values to the new values. |
