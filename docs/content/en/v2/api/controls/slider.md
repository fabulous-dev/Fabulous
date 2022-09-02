---
id: "v2-slider"
title: "Slider"
description: ""
lead: ""
date: 2022-09-02T00:00:00+00:00
lastmod: 2022-09-02T00:00:00+00:00
draft: false
images: []
menu:
  docs:
    parent: "controls"
toc: true
---

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "navigableelement.md" >}}) -> [VisualElement]({{< ref "visualelement.md" >}}) -> [View]({{< ref "view.md" >}})  
**Xamarin.Forms documentation:** Slider [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.slider) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/slider)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/slider).

## Constructors

| Constructors | Description |
|--|--|
| Slider(min: float, max: float, value: float, onValueChanged: float -> 'msg) | //TODO Defines a Slider widget with items list, selected index and onSelectedIndexChanged event |

## Properties
//TODO qdd descriptions
| Properties | Description |
|--|--|
| maximumTrackColor(light: FabColor, ?dark: FabColor)  | |
| minimumTrackColor(light: FabColor, ?dark: FabColor)  | |
| thumbColor(light: FabColor, ?dark: FabColor)  | |
| thumbImage(light: ImageSource, ?dark: ImageSource) ||
| thumbImage(light: string, ?dark: string) ||
| thumbImage(light: Uri, ?dark: Uri) ||
| thumbImage(light: Stream, ?dark: Stream) ||
| onDragCompleted(onDragCompleted: 'msg) ||
| onDragStarted(onDragStarted: 'msg) ||
| reference(value: value: ViewRef<Slider>) | |


## Usages
// TODO 
```fs
Slider(//TODO)
    .maximumTrackColor(light: FabColor, ?dark: FabColor) 
    .minimumTrackColor(light: FabColor, ?dark: FabColor)  
    .thumbColor(light: FabColor, ?dark: FabColor)  
    .thumbImage(light: ImageSource, ?dark: ImageSource) 
    .thumbImage(light: string, ?dark: string) 
    .thumbImage(light: Uri, ?dark: Uri)
    .thumbImage(light: Stream, ?dark: Stream))
    .onDragCompleted(onDragCompleted: 'msg) 
    .onDragStarted(onDragStarted: 'msg) 
```

### Get access to the underlying Xamarin.Forms.Slider

```fs
let sliderRef = ViewRef<Slider>()

Slider(["Item 1"; "Item 2"; "Item 3"], 0, SelectedIndexChanged) //TODO not sure 
    .reference(sliderRef) 
```
