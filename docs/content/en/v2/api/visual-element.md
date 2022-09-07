---
id: "v2-visual-element"
title: "VisualElement"
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

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "navigable-element.md" >}})  
**Xamarin.Forms documentation:** VisualElement [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.visualelement)

## Constructors

This control can't be instantiated on its own. Its properties and events are inherited by its descendants.

## Properties

| Properties | Description |
|--|--|
| anchorX(value: float) | Sets the horizontal anchor of the element. |
| anchorY(value: float) | Sets the vertical anchor of the element. |
| backgroundColor(light: FabColor, ?dark: FabColor) | | Sets the background color depending if light or dark mode |
| background(light: FabColor, ?dark: FabColor) | | Sets the background color depending if light or dark mode |
| clip(content: WidgetBuilder<'msg, 'contentMarker>) | Defines the outline of the contents of an element.
| flowDirection(value: FlowDirection) | Sets the flow direction of the element. |
| size(?width: float, ?height: float) | Sets the size of an element by applying the width and height of the element. |
| width(value: float) | Sets the width of an element. |
| height(value: float) | Sets the height of an element. |
| inputTransparent(value: bool) | Sets a value indicating whether this element should be involved in the user interaction cycle. |
| isEnabled(value: bool) | Sets a value indicating whether this element is enabled. |
| isVisible(value: bool) | Sets a value indicating whether this element is visible. |
| isTabStop(value: bool) | Sets a value that indicates whether a control is included in tab navigation. |
| minimumWidth(value: float) | Sets the minimum width of an element. |
| minimumHeight(value: float) | Sets the minimum height of an element. |
| opacity(value: float) | Sets the opacity of an element. |
| tabIndex(value: int) | Sets the tab index of an element. |
| visual(value: IVisual) | Sets the visual of an element. With the VisualMarker class providing the following IVisual properties: Default, MatchParent, Material. |
| translateTo(x: float, y: float, duration: int, easing: Easing) | Animates an elements TranslationX and TranslationY properties from their current values to the new values. |
| translationX(x: float) | Translates the X position of the element. |
| translationY(y: float) | Translates the Y position of the element. |
| scaleTo(scale: float, duration: int, easing: Easing) | Animates elements Scale property from their current values to the new values. |
| scaleXTo(scale: float) | Animates element ScaleX property from its current value to the new value. |
| scaleYTo(scale: float) | Animates element ScaleY property from its current value to the new value. |
| fadeTo(opacity: float, duration: int, easing: Easing) | Animates elements Opacity property from their current values to the new values. |
| rotateTo(rotation: float, duration: int, easing: Easing) | Animates an elements Rotation property from their current values to the new values. |
| rotateXTo(rotation: float) | Animates element RotationX property from its current value to the new value. |
| rotateYTo(rotation: float) | Animates element RotationY property from its current value to the new value. |

## Events

| Properties | Description |
|--|--|
| onFocused(onFocused: bool -> 'msg) | Event that is triggered when the element is focused. |
| onUnfocused(onUnfocused: bool -> 'msg) | Event that is triggered when the element is unfocused. |
