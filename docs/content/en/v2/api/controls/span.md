---
id: "v2-span"
title: "Span"
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

**Inheritance:** [Element]({{< ref "element.md" >}}) }) 
**Xamarin.Forms documentation:** Span [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.span) / [Guide](//TODO)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](//TODO).

## Constructors

| Constructors | Description |
|--|--|
| Span(text: string) | //TODO Defines a Span widget with items list, selected index and onSelectedIndexChanged event |

## Properties
//TODO qdd descriptions
| Properties | Description |
|--|--|
| backgroundColor(light: FabColor, ?dark: FabColor)  | |
| characterSpacing(value: float)  | |
| font(?size: float, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string)
| lineHeight(value: float)  | |
| style(value: Style)  ||
| textColor(light: FabColor, ?dark: FabColor) ||
| textDecorations(value: TextDecorations) ||
| textTransform(value: TextTransform) ||
| gestureRecognizers(//TODO) ||
| reference(value: value: ViewRef<Span>) | |


## Usages
// TODO
```fs
Span(//TODO)
    .backgroundColor(light: FabColor, ?dark: FabColor)  
    .characterSpacing(value: float)   
    .font(?size: float, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string)
    .lineHeight(value: float) 
    .style(value: Style)  
    .textColor(light: FabColor, ?dark: FabColor) 
    .textDecorations(value: TextDecorations) 
    .textTransform(value: TextTransform) 
    .gestureRecognizers(//TODO) 
    .reference(value: value: ViewRef<Span>)
```

### Get access to the underlying Xamarin.Forms.Span

```fs
let spanRef = ViewRef<Span>()

Span(["Item 1"; "Item 2"; "Item 3"], 0, SelectedIndexChanged) //TODO not sure 
    .reference(spanRef) 
```
