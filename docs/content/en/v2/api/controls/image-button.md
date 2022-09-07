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

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "../navigable-element.md" >}}) -> [VisualElement]({{< ref "../visual-element.md" >}}) -> [View]({{< ref "../view.md" >}})  
**Xamarin.Forms documentation:** ImageButton [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.imagebutton) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/imagebutton)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/imagebutton).

## Constructors

| Constructors | Description |
|--|--|
| ImageButton(aspect: Aspect, light: ImageSource, onClicked: 'msg, ?dark: ImageSource) | Define a ImageButton widget with an ImageSource depending if light or dark mode |
| ImageButton(aspect: Aspect, light: string, onClicked: 'msg, ?dark: string) | Define a ImageButton widget with a path to an image depending if light or dark mode |
| ImageButton(aspect: Aspect, light: Uri, onClicked: 'msg, ?dark: Uri) | Define a ImageButton widget with a URI to an image depending if light or dark mode |
| ImageButton(aspect: Aspect, light: Stream, onClicked: 'msg, ?dark: Stream) | Define a ImageButton widget with an image Stream depending if light or dark mode |

## Properties

| Properties | Description |
|--|--|
| borderColor(light: FabColor, ?dark: FabColor) | Sets the border color |
| borderWidth(value: float) | Sets the border width |
| cornerRadius(value: float) | Sets the corner radius |
| isLoading(value: bool) | Sets if the image is currently loading |
| isOpaque(value: bool) | Sets if the image is opaque |
| isPressed(value: bool) | Sets if the image is currently pressed |
| padding(value: Thickness) | Sets the padding |
| padding(value: float) | Sets a uniform padding |
| padding(left: float, top: float, right: float, bottom: float) | Sets the padding |
| reference(value: ViewRef&lt;ImageButton&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.ImageButton` instance associated to this widget |

## Events

| Properties | Description |
|--|--|
| onPressed(onPressed: 'msg) | Sets the event handler for the image button pressed event |
| onReleased(onReleased: 'msg) | Sets the event handler for the image button released event |

## Usages

```fs
ImageButton(Aspect.AspectFit, "image-light.png", dark = "image-dark.png")
    .borderColor(light = Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor()) 
    .borderWidth(5.) 
    .isLoading(false) 
    .isOpaque(true) 
    .isPressed(false) 
    .padding(Thickness(5., 10., 5., 10.)) 
    .padding(10.) 
    .padding(5., 10., 5., 10.) 
    .onPressed(PressedMsg) 
    .onReleased(ReleasedMsg)
    
ImageButton(Aspect.AspectFit, FileImageSource(...), dark = StreamImageSource(...))

ImageButton(Aspect.AspectFit, Uri("http://..."), dark = Uri("http://..."))

ImageButton(Aspect.AspectFit, MemoryStream(), dark = FileStream())
```

### Get access to the underlying Xamarin.Forms.ImageButton

```fs
let imageButtonRef = ViewRef<ImageButton>()

ImageButton(Aspect.AspectFit, light = "image-light.png", dark = "image-dark.png")
    .reference(imageButtonRef)
```
