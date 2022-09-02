---
id: "v2-image-button"
title: "ImageButton"
description: ""
lead: ""
date: 2022-09-01T00:00:00+00:00
lastmod: 2022-09-01T00:00:00+00:00
draft: false
images: []
menu:
  docs:
    parent: "controls"
toc: true
---

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "navigableelement.md" >}}) -> [VisualElement]({{< ref "visualelement.md" >}}) -> [View]({{< ref "view.md" >}})  
**Xamarin.Forms documentation:** ImageButton [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.imagebutton) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/imagebutton)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/imagebutton).

## Constructors

| Constructors | Description |
|--|--|
| ImageButton(aspect: Aspect, light: ImageSource, onClicked: 'msg, ?dark: ImageSource) | //TODO Defines a ImageButton widget with a text |
| ImageButton(aspect: Aspect, light: string, onClicked: 'msg, ?dark: string) | | // TODO
| ImageButton(aspect: Aspect, light: Uri, onClicked: 'msg, ?dark: Uri) || // TODO
| ImageButton(aspect: Aspect, light: Stream, onClicked: 'msg, ?dark: Stream) || //TODO


## Properties
//TODO Add descriptions 
| Properties | Description |
|--|--|
| borderColor(light: FabColor, ?dark: FabColor) ||
| borderWidth(value: float) ||
| cornerRadius(value: float) ||
| isLoading(value: bool) ||
| isOpaque(value: bool) ||
| isPressed(value: bool) ||
| padding(value: Thickness) ||
| padding(value: float) ||
| padding(left: float, top: float, right: float, bottom: float) ||
| onPressed(onPressed: 'msg) ||
| onReleased(onReleased: 'msg) ||
| reference(value: ViewRef<ImageButton>) ||


## Usages
//TODO fill the parentheses
```fs
ImageButton(//TODO)
    .borderColor(light: FabColor, ?dark: FabColor) 
    .borderWidth(value: float) 
    .isLoading(value: bool) 
    .isOpaque(value: bool) 
    .isPressed(value: bool) 
    .padding(value: Thickness) 
    .padding(value: float) 
    .padding(left: float, top: float, right: float, bottom: float) 
    .onPressed(onPressed: 'msg) 
    .onReleased(onReleased: 'msg) 
    .reference(value: ViewRef<ImageButton>) 
```

### Get access to the underlying Xamarin.Forms.ImageButton

```fs
let imageButtonRef = ViewRef<ImageButton>()

ImageButton(//TODO)
    .reference(imageButtonRef)
```
