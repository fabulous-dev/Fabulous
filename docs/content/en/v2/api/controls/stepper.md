---
id: "v2-stepper"
title: "Stepper"
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

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "navigable-element.md" >}}) -> [VisualElement]({{< ref "visual-element.md" >}}) -> [View]({{< ref "view.md" >}})  
**Xamarin.Forms documentation:** Stepper [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.stepper) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/stepper)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/stepper).

## Constructors

| Constructors | Description |
|--|--|
| Stepper(min: float, max: float, value: float, onValueChanged: float -> 'msg) | Define a Stepper widget with the min-max bounds and the current value |

## Properties

| Properties | Description |
|--|--|
| increment(value: float) | Sets the increment step between each selected values |
| reference(value: ViewRef&lt;Stepper&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.Stepper` instance associated to this widget |

## Usages

```fs
Stepper(1000., 5000., model.Value, ValueChangedMsg)
    .increment(250.)
```

### Get access to the underlying Xamarin.Forms.Stepper

```fs
let stepperRef = ViewRef<Stepper>()

Stepper(1000., 5000., model.Value, ValueChangedMsg)
    .reference(stepperRef) 
```
