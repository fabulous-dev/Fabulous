---
id: "v2-button"
title: "Button"
description: ""
lead: ""
date: 2022-04-06T00:00:00+00:00
lastmod: 2022-04-06T00:00:00+00:00
draft: false
images: []
menu:
  docs:
    parent: "controls"
toc: true
---

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "navigableelement.md" >}}) -> [VisualElement]({{< ref "visualelement.md" >}}) -> [View]({{< ref "view.md" >}})  
**Xamarin.Forms documentation:** Button [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.button) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/button)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/button).

## Constructors

| Constructors | Description |
|--|--|
| Button(text: string, onClicked: 'msg) | Defines a Button widget with a text and clicked event |

## Properties

| Properties | Description |
|--|--|
| textColor(light: FabColor, ?dark: FabColor) | Sets the text color depending if light or dark mode |
| textTransform(value: TextTransform) | Sets the text transformation (lowercase, uppercase) to apply on the text |
| cornerRadius(value: int) | Sets the corner radius of the button |
| borderColor(light: FabColor, ?dark: FabColor) | Sets the border color depending if light or dark mode |
| borderWidth(value: float) | Sets the border width of the button |
| padding(value: float) | Sets a uniform amount of padding around the button |
| padding(value: Thickness) | Sets a uniform amount of padding around the button |
| padding(left: float, top: float, right: float, bottom: float) | Sets the amount of padding around the button |
| characterSpacing(value: float) | Sets the spacing between each character of the button |
| contentLayout(position: ImagePosition, spacing: float) | Sets the position and spacing of the image in the button |
| font(?size: float, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string) | Sets the font family used |
| image(light: ImageSource, ?dark: ImageSource) | Sets the image source depending if light or dark mode |
| image(light: string, ?dark: string) | Sets the image source from a file depending if light or dark mode |
| image(light: Uri, ?dark: Uri) | Sets the image source from an uri depending if light or dark mode |
| image(light: Stream, ?dark: Stream) | Sets the image source from a stream depending if light or dark mode |
| onPressed(onPressed: 'msg) | Sets the event handler for the button pressed event |
| onReleased(onReleased: 'msg) | Sets the event handler for the button released event |
| reference(value: ViewRef&lt;Button&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.Button` instance associated to this widget |

## Events

| Properties | Description |
|--|--|
| onPressed(onPressed: 'msg) | Sets the event handler for the button pressed event |
| onReleased(onReleased: 'msg) | Sets the event handler for the button released event |

## Usages

```fs
Button("Press me!", ClickMsg)
    .textColor(light = Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor())
    .textTransform(TextTransform.Lowercase)
    .cornerRadius(10)
    .borderColor(light = Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor())
    .borderWidth(2.)
    .padding(10.)
    .characterSpacing(1.)
    .contentLayout(ImagePosition.Left, 10.)
    .image(light = "icon.png", dark = "icon.png")
    .font(namedSize = NamedSize.Large, fontFamily = "Arial", attributes = FontAttributes.Bold)
    .onPressed(PressedMsg)
    .onReleased(ReleasedMsg)
```

### Get access to the underlying Xamarin.Forms.Button

```fs
let buttonRef = ViewRef<Button>()

Button("Press me!", ClickMsg)
    .reference(buttonRef)
```
