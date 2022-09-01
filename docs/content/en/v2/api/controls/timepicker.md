---
id: "v2-timepicker"
title: "TimePicker"
description: ""
lead: ""
time: 2022-09-01T00:00:00+00:00
lastmod: 2022-09-01T00:00:00+00:00
draft: false
images: []
menu:
  docs:
    parent: "controls"
toc: true
---

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "navigableelement.md" >}}) -> [VisualElement]({{< ref "visualelement.md" >}}) -> [View]({{< ref "view.md" >}})  
**Xamarin.Forms documentation:** TimePicker [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.timepicker) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/timepicker)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/timepicker).

## Constructors

| Constructors | Description |
|--|--|
| TimePicker((time: System.TimeSpan, onTimeSelected: System.TimeSpan -> 'msg)  | Defines a TimePicker widget with a text |

## Properties

| Properties | Description |
|--|--|
| characterSpacing(value: float) | Sets the spacing between each character of the text |
| format(value: string) | // TODO: Add description |
| textColor(light: FabColor, ?dark: FabColor) | Sets the text color depending if light or dark mode |
| textTransform(value: TextTransform) | Sets the text transformation (lowercase, uppercase) to apply on the text |
| font(?size: float, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string) | Sets the font family used |
| reference(value: ViewRef<TimePicker>) | // TODO: Add description |
| updateMode(mode: iOSSpecific.UpdateMode) | // TODO: Add description |

## Usages
// TODO: Add missing examples
```fs
TimePicker(//TODO)
    .characterSpacing(1.)
    .format()
    .textColor(light = Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor())
    .textTransform(TextTransform.Lowercase)
    .font(namedSize = NamedSize.Large, fontFamily = "Arial", attributes = FontAttributes.Bold)
    .reference()
    .updateMode()
```

### Get access to the underlying Xamarin.Forms.TimePicker

```fs
let timepickerRef = ViewRef<TimePicker>()

TimePicker(//TODO)
    .reference(timepickerRef)
```
