---
id: "v2-radio-button"
title: "RadioButton"
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

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "navigableelement.md" >}}) -> [VisualElement]({{< ref "visualelement.md" >}}) -> [View]({{< ref "view.md" >}}) -> [Layout]({{< ref "layout.md" >}})  -> [TemplatedView]({{< ref "templatedview.md" >}})
**Xamarin.Forms documentation:** RadioButton [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.radiobutton) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/radiobutton)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/radiobutton).

## Constructors

| Constructors | Description |
|--|--|
| RadioButton(content: string, isChecked: bool, onChecked: bool -> 'msg)  | //TODO |
| RadioButton(isChecked: bool, onChecked: bool -> 'msg) | //TODO |

## Properties
//TODO add descriptions
| Properties | Description |
|--|--|
| borderColor(light: FabColor, ?dark: FabColor)  | |
| groupName(value: string) | |
| borderWidth(value: float) | |
| characterSpacing(spacing: float) ||
| cornerRadius(value: float) ||
| font(?size: double, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string) ||
| textColor(light: FabColor, ?dark: FabColor) ||
| textTransform(value: TextTransform)||
| reference(value: ViewRef<RadioButton>) |  |

## Usages

```fs
RadioButton(//TODO)
    .progressColor(//TODO)
    .borderColor(light: FabColor, ?dark: FabColor)  
    .groupName(value: string) 
    .borderWidth(value: float) 
    .characterSpacing(spacing: float) 
    .cornerRadius(value: float) 
    .font(?size: double, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string) 
    .textColor(light: FabColor, ?dark: FabColor) 
    .textTransform(value: TextTransform)
    
```

### Get access to the underlying Xamarin.Forms.RadioButton

```fs
let radioButtonRef = ViewRef<RadioButton>()

RadioButton("Enter a description", TexChanged, SearchButtonPressed)
    .reference(radioButtonRef)
```
