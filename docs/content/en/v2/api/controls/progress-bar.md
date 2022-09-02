---
id: "v2-progress-bar"
title: "ProgressBar"
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

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "navigableelement.md" >}}) -> [VisualElement]({{< ref "visualelement.md" >}}) -> [View]({{< ref "view.md" >}}) -> [InputView]({{< ref "input-view.md" >}})  
**Xamarin.Forms documentation:** ProgressBar [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.progressbar) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/progressbar)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/progressbar).

## Constructors

| Constructors | Description |
|--|--|
| ProgressBar(progress: float) | //TODO |
| ProgressBar(progress: float, duration: int, easing: Easing) | //TODO |

## Properties
//TODO add descriptions 
| Properties | Description |
|--|--|
| progressColor(light: FabColor, ?dark: FabColor) | |
| reference(value: ViewRef<ProgressBar>) |  | 

## Usages

```fs
ProgressBar(//TODO)
    .progressColor(//TODO)
    
```

### Get access to the underlying Xamarin.Forms.ProgressBar

```fs
let progressBarRef = ViewRef<ProgressBar>()

ProgressBar("Enter a description", TexChanged, SearchButtonPressed)
    .reference(progressBarRef)
```
