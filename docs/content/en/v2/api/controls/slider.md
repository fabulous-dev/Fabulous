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

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "navigable-element.md" >}}) -> [VisualElement]({{< ref "visual-element.md" >}}) -> [View]({{< ref "view.md" >}})  
**Xamarin.Forms documentation:** Slider [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.slider) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/slider)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/slider).

## Constructors

| Constructors | Description |
|--|--|
| Slider(min: float, max: float, value: float, onValueChanged: float -> 'msg) | Define a Slider widget with the min-max bounds and the current value |

## Properties

| Properties | Description |
|--|--|
| maximumTrackColor(light: FabColor, ?dark: FabColor) | Sets the color of the maximum track depending if light or dark mode |
| minimumTrackColor(light: FabColor, ?dark: FabColor) | Sets the color of the minimum track depending if light or dark mode |
| thumbColor(light: FabColor, ?dark: FabColor) | Sets the color of the thumb |
| thumbImage(light: ImageSource, ?dark: ImageSource) | Sets the image of the thumb using ImageSource depending if light or dark mode |
| thumbImage(light: string, ?dark: string) | Sets the image of the thumb using a path depending if light or dark mode |
| thumbImage(light: Uri, ?dark: Uri) | Sets the image of the thumb using a URI depending if light or dark mode |
| thumbImage(light: Stream, ?dark: Stream) | Sets the image of the thumb using Stream depending if light or dark mode |
| reference(value: ViewRef&lt;Slider&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.Slider` instance associated to this widget |

## Events

| Properties | Description |
|--|--|
| onDragCompleted(onDragCompleted: 'msg) | Sets the event handler for the drag completed event |
| onDragStarted(onDragStarted: 'msg) | Sets the event handler for the drag start event |

## Usages

```fs
Slider(20., 80., model.Value, ValueChangedMsg)
    .maximumTrackColor(Color.Red.ToFabColor(), dark = Color.Blue.ToString()) 
    .minimumTrackColor(Color.Red.ToFabColor(), dark = Color.Blue.ToString())  
    .thumbColor(Color.Red.ToFabColor(), dark = Color.Blue.ToString())  
    .thumbImage("thumb-light.png", dark = "thumb-dark.png")
    .onDragCompleted(DragCompletedMsg) 
    .onDragStarted(DragStartedMsg) 
```

### Get access to the underlying Xamarin.Forms.Slider

```fs
let sliderRef = ViewRef<Slider>()

Slider(20., 80., model.Value, ValueChangedMsg)
    .reference(sliderRef) 
```
