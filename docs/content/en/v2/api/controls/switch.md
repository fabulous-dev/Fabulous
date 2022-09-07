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
| Switch(isToggled: bool, onToggled: bool -> 'msg) | Define a Switch widget with its toggled state |

## Properties
| Properties | Description |
|--|--|
| thumbColor(light: FabColor, ?dark: FabColor) | Sets the thumb color depending if light or dark mode |
| colorOn(light: FabColor, ?dark: FabColor) | Sets the color when switch is toggled on |
| reference(value: ViewRef&lt;Switch&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.Switch` instance associated to this widget |

## Usages
```fs
Switch(model.Toggled, ToggledMsg)
    .thumbColor(Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor())
    .colorOn(Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor()) 
```

### Get access to the underlying Xamarin.Forms.Switch

```fs
let switchRef = ViewRef<Switch>()

Switch(model.Toggled, ToggledMsg) 
    .reference(switchRef) 
```
