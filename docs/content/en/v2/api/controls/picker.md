---
id: "v2-picker"
title: "Picker"
description: ""
lead: ""
date: 2022-04-23T00:00:00+00:00
lastmod: 2022-04-23T00:00:00+00:00
draft: false
images: []
weight: 434
menu:
  docs:
    parent: "controls"
toc: true
---

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "../navigable-element.md" >}}) -> [VisualElement]({{< ref "../visual-element.md" >}}) -> [View]({{< ref "../view.md" >}})  
**Xamarin.Forms documentation:** Picker [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.picker) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/picker)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/picker).

## Constructors

| Constructors | Description |
|--|--|
| Picker(items: string list, selectedIndex: int, onSelectedIndexChanged: int -> 'msg) | Defines a Picker widget with items list, selected index and onSelectedIndexChanged event |

## Properties

| Properties | Description |
|--|--|
| characterSpacing(value: float) | Sets the spacing between each character of the picker |
| horizontalTextAlignment(value: TextAlignment) | Sets the horizontal text alignment of the picker |
| verticalTextAlignment(value: TextAlignment) | Sets the vertical text alignment of the picker |
| font(?size: float, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string) | Sets the font family used |
| textColor(light: FabColor, ?dark: FabColor) | Sets the text color depending if light or dark mode |
| textTransform(value: TextTransform) | Sets the text transformation (lowercase, uppercase) to apply on the text |
| title(value: string) | Sets the title of the picker |
| titleColor(light: FabColor, ?dark: FabColor) | Sets the title color depending if light or dark mode |
| reference(value: ViewRef&lt;Picker&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.Picker` instance associated to this widget |

## iOS-specific Properties

| Properties | Description |
|--|--|
| updateMode(value: iOSSpecific.UpdateMode) | Sets the update mode (Immediately or WhenFinished) of the picker |

## Usages

```fs
Picker(["Item 1"; "Item 2"; "Item 3"], 0, SelectedIndexChanged)
    .characterSpacing(1.0)
    .textColor(Color.Red.ToFabColor(), Color.Blue.ToFabColor())
    .titleColor(Color.Red.ToFabColor(), Color.Blue.ToFabColor())
    .verticalTextAlignment(TextAlignment.Center)
    .horizontalTextAlignment(TextAlignment.Center)
    .font(namedSize = NamedSize.Large, fontFamily = "Arial", attributes = FontAttributes.Bold)
    .textTransform(TextTransform.Lowercase)
```

### Get access to the underlying Xamarin.Forms.Picker

```fs
let pickerRef = ViewRef<Picker>()

Picker(["Item 1"; "Item 2"; "Item 3"], 0, SelectedIndexChanged)
    .reference(pickerRef)
```
