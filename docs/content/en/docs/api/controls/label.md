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
weight: 501
toc: true
---

Constructor

```fs
Label("Hello World")
```

Modifiers

- characterSpacing

```fs
Label("Hello word")
    .characterSpacing(1.)
```
- font

```fs
Label("Hello word")
    .font(size = 12.)
    
Label("Hello word")
    .font(namedSize = NamedSize.Large)
    
Label("Hello word")
    .font(attributes = FontAttributes.Bold)

Label("Hello word")
    .font(fontFamily = "Arial")
```

- horizontalTextAlignment

```fs
Label("Hello word")
    .horizontalTextAlignment(TextAlignment.Center)
```
- lineBreakMode

```fs
Label("Hello word")
    .lineBreakMode(LineBreakMode.WordWrap)
```
- lineHeight

```fs
Label("Hello word")
    .lineHeight(1.5)
```
- maxLines

```fs
Label("Hello word")
    .maxLines(1)
```

- padding

```fs
Label("Hello word")
    .padding(Thickness(10.))
    
Label("Hello word")
    .padding(10.)
    
Label("Hello word")
    .padding(10., 10., 10., 10.)
    
```
- textColor

```fs
Label("Hello word")
    .textColor(Color.Red)
    
Label("Hello word")
    .textColor(light = Color.Red, dark = Color.Blue)
```
- textDecoration

```fs
Label("Hello word")
    .textDecoration(TextDecorations.Underline)
```
- textTransform

```fs
Label("Hello word")
    .textTransform(TextTransform.Lowercase)
```
- textType

```fs
Label("Hello word")
    .textType(TextType.Text)
```
- verticalTextAlignment

```fs
Label("Hello word")
    .verticalTextAlignment(TextAlignment.Center)
```
- centerTextHorizontal

```fs
Label("Hello word")
    .centerTextHorizontal()
```
- centerTextVertical

```fs
Label("Hello word")
    .centerTextVertical()
```
- reference

```fs
let labelRef = ViewRef<Label>()
Label("Hello word")
    .reference(labelRef)
```
