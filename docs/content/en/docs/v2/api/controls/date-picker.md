---
id: "v2-date-picker"
title: "Date Picker"
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

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "navigableelement.md" >}}) -> [VisualElement]({{< ref "visualelement.md" >}}) -> [View]({{< ref "view.md" >}})  
**Xamarin.Forms documentation:** DatePicker [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.datepicker) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/datepicker)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/datepicker).

## Constructors
| Constructors | Description |
|--|--|
| DatePicker(date: DateTime, onDateSelected: DateTime -> 'msg) | Defines a DatePicker widget with a date and onDateSelected event |

## Properties
| Properties | Description |
|--|--|
| characterSpacing(value: float) | Sets the spacing between each character of the date picker |
| font(?size: float, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string) | Sets the font family used |
| format(value: string) | Sets the format of the date picker |
| minimumDate(value: DateTime) | Sets the minimum date of the date picker |
| maximumDate(value: DateTime) | Sets the maximum date of the date picker |
| textColor(light: Color, ?dark: Color) | Sets the text color depending if light or dark mode |
| textTransform(value: TextTransform) | Sets the text transformation (lowercase, uppercase) to apply on the text |
| reference(value: ViewRef&lt;DatePicker&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.DatePicker` instance associated to this widget |

## iOS-specific Properties
| Properties | Description |
|--|--|
| updateMode(value: iOSSpecific.UpdateMode) | Sets the update mode (Immediately or WhenFinished) of the date picker |

## Events

None

## Usages

```fs
    DatePicker(DateTime.Now, DateTimeChanged)
        .characterSpacing(1.0)
        .format("dd/MM/yyyy")
        .minimumDate(DateTime.Now)
        .maximumDate(DateTime.Now.AddYears(1))
        .textColor(Color.Red, Color.Blue)
        .font(namedSize = NamedSize.Large, fontFamily = "Arial", attributes = FontAttributes.Bold)
        .textTransform(TextTransform.Lowercase)
```

### Get access to the underlying Xamarin.Forms.DatePicker

```fs
let datePickerRef = ViewRef<DatePicker>()

DatePicker(DateTime.Now, DateTimeChanged)
    .reference(datePickerRef)
```
