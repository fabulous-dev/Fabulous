---
id: "v2-checkbox"
title: "CheckBox"
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
**Xamarin.Forms documentation:** CheckBox [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.checkbox) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/checkbox)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/checkbox).

## Constructors

| Constructors | Description |
|--|--|
| CheckBox(isChecked: bool, onCheckedChanged: bool -> 'msg) | Defines a CheckBox widget |

## Properties

| Properties | Description |
|--|--|
| characterSpacing(light: FabColor, ?dark: FabColor) | Sets the spacing between each character of the text |
| reference(value: ViewRef&lt;CheckBox&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.CheckBox` instance associated to this widget |

## Usages

```fs
CheckBox(model.Checked, CheckedChanged)
    .characterSpacing(1.)
```

### Get access to the underlying Xamarin.Forms.CheckBox

```fs
let checkboxRef = ViewRef<CheckBox>()

CheckBox(model.Checked, CheckedChanged)
    .reference(checkboxRef)
```
