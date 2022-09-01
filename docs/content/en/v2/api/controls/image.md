---
id: "v2-image"
title: "Image"
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
**Xamarin.Forms documentation:** Image [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.image) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/images?tabs=macos)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/images?tabs=macos).

## Constructors

| Constructors | Description |
|--|--|
| Image(aspect: Aspect, light: ImageSource, ?dark: ImageSource) | //TODO Defines a Image widget with a text |
| Image(aspect: Aspect, light: string, ?dark: string)  | | // TODO
| Image(aspect: Aspect, light: Uri, ?dark: Uri) || // TODO
| Image(aspect: Aspect, light: Stream, ?dark: Stream) || //TODO


## Properties
//TODO Add descriptions
| Properties | Description |
|--|--|
| isAnimationPlaying(isAnimationPlaying: bool) ||
| isOpaque(value: bool) ||
| reference(value: ViewRef<Image>) ||


## Usages
//TODO fill the parentheses
```fs
Image(//TODO)
    .isAnimationPlaying(isAnimationPlaying: bool)
    .isOpaque(value: bool) 
    .reference(value: ViewRef<Image>) 
```

### Get access to the underlying Xamarin.Forms.Image

```fs
let imageRef = ViewRef<Image>()

Image(//TODO)
    .reference(imageRef)
```
