---
id: "v2-box-view"
title: "BoxView"
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
**Xamarin.Forms documentation:** BoxView [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.boxview) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/boxview)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/boxview).

## Constructors
// TODO Add descriptions
| Constructors | Description |
|--|--|
| BoxView(light: FabColor, ?dark: FabColor) |  |

## Properties
//TODO add descriptions
| Properties | Description |
|--|--|
| cornerRadius(value: float) |  |
| reference(value: ViewRef<BoxView>) |  |


## Usages

```fs
BoxView(//TODO)
    .cornerRadius(//TODO)

```

### Get access to the underlying Xamarin.Forms.BoxView

```fs
let boxViewRef = ViewRef<BoxView>()

BoxView(//TODO)
    .reference(boxViewRef)
```
