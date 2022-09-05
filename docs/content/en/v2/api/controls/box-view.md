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
| Constructors | Description |
|--|--|
| BoxView(light: FabColor, ?dark: FabColor) | Define a BoxView widget with its fill color depending if light or dark mode |

## Properties
| Properties | Description |
|--|--|
| cornerRadius(value: float) | Sets the corner radius |
| reference(value: ViewRef<BoxView>) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.BoxView` instance associated to this widget |

## Usages

```fs
BoxView(light = Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor())
    .cornerRadius(10.)
```

### Get access to the underlying Xamarin.Forms.BoxView

```fs
let boxViewRef = ViewRef<BoxView>()

BoxView(Color.Red.ToFabColor())
    .reference(boxViewRef)
```
