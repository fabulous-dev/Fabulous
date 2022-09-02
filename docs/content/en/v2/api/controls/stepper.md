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

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "navigableelement.md" >}}) -> [VisualElement]({{< ref "visualelement.md" >}}) -> [View]({{< ref "view.md" >}})  
**Xamarin.Forms documentation:** Stepper [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.stepper) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/stepper)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/stepper).

## Constructors

| Constructors | Description |
|--|--|
| Stepper(min: float, max: float, value: float, onValueChanged: float -> 'msg) | //TODO Defines a Stepper widget with items list, selected index and onSelectedIndexChanged event |

## Properties
//TODO qdd descriptions
| Properties | Description |
|--|--|
| increment(value: float) ||
| reference(value: value: ViewRef<Stepper>) | |

## Usages
// TODO
```fs
Stepper(//TODO)
    .increment(value: float)
    
```

### Get access to the underlying Xamarin.Forms.Stepper

```fs
let stepperRef = ViewRef<Stepper>()

Stepper(["Item 1"; "Item 2"; "Item 3"], 0, SelectedIndexChanged) //TODO not sure 
    .reference(stepperRef) 
```
