---
id: "v2-activity-indicator"
title: "ActivityIndicator"
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
**Xamarin.Forms documentation:** ActivityIndicator [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.activityindicator) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/activityindicator)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/activityindicator).

## Constructors
// TODO Add descriptions 
| Constructors | Description |
|--|--|
| ActivityIndicator(isRunning: bool) |  |

## Properties

| Properties | Description |
|--|--|
| color(light: FabColor, ?dark: FabColor) | Sets the text color depending if light or dark mode |
| reference(value: ViewRef<ActivityIndicator>) |  |


## Usages

```fs
ActivityIndicator(//TODO)
    .color(light = Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor())

```

### Get access to the underlying Xamarin.Forms.ActivityIndicator

```fs
let activityIndicatorRef = ViewRef<ActivityIndicator>()

ActivityIndicator(//TODO)
    .reference(activityIndicatorRef)
```
