---
id: "v2-time-picker"
title: "TimePicker"
description: ""
lead: ""
date: 2022-04-23T00:00:00+00:00
lastmod: 2022-04-23T00:00:00+00:00
draft: false
images: []
menu:
    docs:
        parent: "controls"
toc: true
---

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "navigable-element.md" >}}) -> [VisualElement]({{< ref "visual-element.md" >}}) -> [View]({{< ref "view.md" >}})  
**Xamarin.Forms documentation:** TimePicker [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.timepicker) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/timepicker)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/timepicker).

## Constructors

| Constructors | Description |
|--|--|
| TimePicker(time: TimeSpan, onTimeSelected: TimeSpan -> 'msg) | Defines a TimePicker widget with a time and onTimeSelected event |

## Properties

| Properties | Description |
|--|--|
| characterSpacing(value: float) | Sets the spacing between each character of the time picker |
| font(?size: float, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string) | Sets the font family used |
| format(value: string) | Sets the format of the time picker |
| textColor(light: FabColor, ?dark: FabColor) | Sets the text color depending if light or dark mode |
| textTransform(value: TextTransform) | Sets the text transformation (lowercase, uppercase) to apply on the text |
| reference(value: ViewRef&lt;TimePicker&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.TimePicker` instance associated to this widget |

## iOS-specific Properties

| Properties | Description |
|--|--|
| updateMode(value: iOSSpecific.UpdateMode) | Sets the update mode (Immediately or WhenFinished) of the time picker |

## Usages

```fs
TimePicker(TimeSpan.Parse("00:00:01"), TimeChanged)
    .characterSpacing(1.0)
    .format("dd/MM/yyyy")
    .textColor(Color.Red.ToFabColor(), Color.Blue.ToFabColor())
    .font(namedSize = NamedSize.Large, fontFamily = "Arial", attributes = FontAttributes.Bold)
    .textTransform(TextTransform.Lowercase)
```

### Get access to the underlying Xamarin.Forms.TimePicker

```fs
let timePickerRef = ViewRef<TimePicker>()

TimePicker(TimeSpan.Parse("00:00:01"), TimeChanged)
    .reference(timePickerRef)
```
