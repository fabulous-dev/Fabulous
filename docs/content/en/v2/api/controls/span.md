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
**Xamarin.Forms documentation:** Span [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.span)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.span).

## Constructors

| Constructors | Description |
|--|--|
| Span(text: string) | Define a Span widget with a text |

## Properties

| Properties | Description |
|--|--|
| backgroundColor(light: FabColor, ?dark: FabColor) | Sets the background color depending if light or dark mode |
| characterSpacing(value: float) | Sets the character spacing |
| font(?size: float, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string) | Sets the font |
| lineHeight(value: float) | Sets the line height |
| style(value: Style) | Sets the style to apply |
| textColor(light: FabColor, ?dark: FabColor) | Sets the text color depending if light or dark mode |
| textDecorations(value: TextDecorations) | Sets the text decoration |
| textTransform(value: TextTransform) | Sets the text transformation |
| gestureRecognizers() | Sets a collection of gesture recognizers to attach to this widget |
| reference(value: ViewRef&lt;Span&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.Span` instance associated to this widget |

## Usages

```fs
Span("Hello, Word!")
    .backgroundColor(Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor())  
    .characterSpacing(2.)   
    .font(namedSize = NamedSize.Large, fontFamily = "Arial", attributes = FontAttributes.Bold)
    .lineHeight(1.5) 
    .style(Xamarin.Forms.Style())  
    .textColor(Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor()) 
    .textDecorations(TextDecorations.Underlined) 
    .textTransform(TextTransform.Lowercase) 
    .gestureRecognizers() {
      TapGestureRecognizer(...)
      SwipeGestureRecognizer(...)
    }
```

### Get access to the underlying Xamarin.Forms.Span

```fs
let spanRef = ViewRef<Span>()

Span("Hello, World!")
    .reference(spanRef) 
```
