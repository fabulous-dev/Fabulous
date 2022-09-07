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
| RadioButton(isChecked: bool, onChecked: bool -> 'msg) | Define a default RadioButton widget with the checked state |
| RadioButton(content: string, isChecked: bool, onChecked: bool -> 'msg)  | Define a RadioButton widget with a text and the checked state |

## Properties

| Properties | Description |
|--|--|
| borderColor(light: FabColor, ?dark: FabColor) | Sets the border color depending if light or dark mode |
| groupName(value: string) | Sets the group name |
| borderWidth(value: float) | Sets the border width |
| characterSpacing(spacing: float) | Sets the character spacing |
| cornerRadius(value: float) | Sets the corner radius |
| font(?size: float, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string) | Sets the font |
| textColor(light: FabColor, ?dark: FabColor) | Sets the text color |
| textTransform(value: TextTransform) | Sets the transformation for the text |
| reference(value: ViewRef&lt;RadioButton&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.RadioButton` instance associated to this widget |

## Usages

```fs
RadioButton(model.IsChecked, CheckedChangedMsg)
    .progressColor(Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor())
    .borderColor(Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor())  
    .groupName("MyGroup") 
    .borderWidth(10.) 
    .characterSpacing(2.) 
    .cornerRadius(5.) 
    
RadioButton("Cat", model.IsChecked, CheckedChangedMsg)
    .font(namedSize = NamedSize.Large, fontFamily = "Arial", attributes = FontAttributes.Bold)
    .textColor(Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor()) 
    .textTransform(TextTransform.Lowercase)
```

### Get access to the underlying Xamarin.Forms.RadioButton

```fs
let radioButtonRef = ViewRef<RadioButton>()

RadioButton(model.IsChecked, CheckedChangedMsg)
    .reference(radioButtonRef)
```
