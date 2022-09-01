---
id: "v2-datepicker"
title: "DatePicker"
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
**Xamarin.Forms documentation:** DatePicker [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.datepicker) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/datepicker)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/datepicker).

## Constructors

| Constructors | Description |
|--|--|
| DatePicker(date: DateTime, onDateSelected: DateTime -> 'msg) | Defines a DatePicker widget with a text |

## Properties

| Properties | Description |
|--|--|
| characterSpacing(value: float) | Sets the spacing between each character of the text |
| font(?size: float, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string) | Sets the font family used |
| format(value: string) | // TODO: Add description |
| minimumDate(value: DateTime) | // TODO: Add description |
| maximumDate(value: DateTime) | // TODO: Add description |
| textColor(light: FabColor, ?dark: FabColor) | Sets the text color depending if light or dark mode |
| textTransform(value: TextTransform) | Sets the text transformation (lowercase, uppercase) to apply on the text |
| reference(value: ViewRef<DatePicker>) | // TODO: Add description |
| updateMode(mode: iOSSpecific.UpdateMode) | // TODO: Add description |


## Usages
// TODO: Add missing examples
```fs
DatePicker(DateTime.Now, DateSelected)
    .characterSpacing(1.)
    .font(namedSize = NamedSize.Large, fontFamily = "Arial", attributes = FontAttributes.Bold)
    .format()
    .minimumDate()
    .maximunDate()
    .textColor(light = Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor())
    .textTransform(TextTransform.Lowercase)
    .reference()
    .updateMode()
```

### Get access to the underlying Xamarin.Forms.DatePicker

```fs
let datepickerRef = ViewRef<DatePicker>()

DatePicker(DateTime.Now, DateSelected)
    .reference(datepickerRef)
```
