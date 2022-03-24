---
title: "Label"
description: ""
lead: ""
date: 2022-03-24T00:00:00+00:00
lastmod: 2022-03-24T00:00:00+00:00
draft: false
images: []
menu:
  docs:
    parent: "controls"
toc: true
---

**Inheritance:** [Element](../controls/element.md) -> [NavigableElement](../controls/navigableelement.md) -> [VisualElement](../controls/visualelement.md) -> [View](../controls/view.md)  
**Xamarin.Forms documentation:** [Label Class](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.label)

For details on how the control actually works, please refer to the Xamarin.Forms documentation.

## Constructors

| Constructors | Description |
|--|--|
| Label(text: string) | Define a Label widget |

## Properties

| Properties | Description |
|--|--|
| characterSpacing(value: float) | Sets the spacing between each character of the text |
| font(?size: float, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string) | Sets the font family used |
| horizontalTextAlignment(value: textAlignment) | Sets the horizontal alignment of the text |
| lineBreakMode(value: LineBreakMode) | Sets the line break mode |
| lineHeight(value: float) | Sets the multiplier to apply to the default line height when displaying text |
| maxLines(value: int) | Sets the maximum number of lines allowed |
| padding(value: Thickness) | Sets the amount of padding around the text |
| padding(value: float) | Sets a uniform amount of padding around the text |
| padding(left: float, top: float, right: float, bottom: float) | Sets the amount of padding around the text |
| textColor(light: Color, ?dark: Color) | Sets the text color depending if light or dark mode |
| textDecoration(value: TextDecorations) | Sets the text decorations (underline, strike, etc) to apply on the text |
| textTransform(value: TextTransform) | Sets the text transformation (lowercase, uppercase) to apply on the text |
| textType(value: TextType) | Sets the text type (plain text, HTML) |
| verticalTextAlignment(value: TextAlignment) | Sets the vertical alignment of the text |
| reference(value: ViewRef&lt;Label&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.Label` instance associated to this widget |

## Shorthand properties

| Properties | Description |
|--|--|
| centerTextHorizontal() | Center the text horizontally inside the Label. Same as `horizontalTextAlignment(TextAlignment.Center)` |
| centerTextVertical() | Center the text vertically inside the Label. Same as `verticalTextAlignment(TextAlignment.Center)`  |

## Events

None

## Usages

```fs
Label("Hello World")
    .characterSpacing(1.)
    .font(namedSize = NamedSize.Large, fontFamily = "Arial", attributes = FontAttributes.Bold)
    .horizontalTextAlignment(TextAlignment.Center)
    .lineBreakMode(LineBreakMode.WordWrap)
    .lineHeight(1.5)
    .maxLines(1)
    .padding(10.)
    .textColor(light = Color.Red, dark = Color.Blue)
    .textDecoration(TextDecorations.Underline)
    .textTransform(TextTransform.Lowercase)
    .textType(TextType.Text)
    .verticalTextAlignment(TextAlignment.Center)
```

### Use shorthand properties

```fs
Label("Hello World")
    .size(500., 500.)
    .centerTextHorizontal()
    .centerTextVertical()
```

### Get access to the underlying Xamarin.Forms.Label

```fs
let labelRef = ViewRef<Label>()

Label("Hello World")
    .reference(labelRef)
```
