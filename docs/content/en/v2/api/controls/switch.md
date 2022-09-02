---
id: "v2-switch"
title: "Switch"
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
**Xamarin.Forms documentation:** Switch [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.switch) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/switch)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/switch).

## Constructors

| Constructors | Description |
|--|--|
| Switch(isToggled: bool, onToggled: bool -> 'msg) | //TODO Defines a Switch widget with items list, selected index and onSelectedIndexChanged event |

## Properties
//TODO qdd descriptions
| Properties | Description |
|--|--|
| thumbColor(light: FabColor, ?dark: FabColor)  | |
| colorOn(light: FabColor, ?dark: FabColor)  | |
| reference(value: value: ViewRef<Switch>) | |

## Usages
// TODO
```fs
Switch(//TODO)
    .thumbColor(light: FabColor, ?dark: FabColor)
    .colorOn(light: FabColor, ?dark: FabColor) 
    
```

### Get access to the underlying Xamarin.Forms.Switch

```fs
let switchRef = ViewRef<Switch>()

Switch(["Item 1"; "Item 2"; "Item 3"], 0, SelectedIndexChanged) //TODO not sure 
    .reference(switchRef) 
```
