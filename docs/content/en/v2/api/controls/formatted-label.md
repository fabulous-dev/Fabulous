---
id: "v2-formatted-label"
title: "FormattedLabel"
description: ""
lead: ""
date: 2022-09-02T00:00:00+00:00
lastmod: 2022-09-02T00:00:00+00:00
draft: false
images: []
weight: 428
menu:
  docs:
    parent: "controls"
toc: true
---

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "../navigable-element.md" >}}) -> [VisualElement]({{< ref "../visual-element.md" >}}) -> [View]({{< ref "../view.md" >}}) -> [Label]({{< ref "label.md" >}})  
**Xamarin.Forms documentation:** FormattedLabel [API](//TODO) / [Guide](//TODO)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](//TODO).

## Constructors

| Constructors | Description |
|--|--|
| FormattedLabel() | Define a FormattedLabel widget. This widget accept Span widgets as children |

## Properties

| Properties | Description |
|--|--|
| reference(value: ViewRef&lt;Label&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.Label` instance associated to this widget |

## Usages

```fs
(FormattedLabel() {
  Span("Hello")
    .font(size = 20., attributes = FontAttributes.Bold)
    
  Span("World")
    .textColor(Color.Red.ToFabColor())
})
  .font(fontFamily = "Consolas")
```

### Get access to the underlying Xamarin.Forms.FormattedLabel

```fs
let formattedLabelRef = ViewRef<Label>()

(FormattedLabel() {
  Span("Hello")
})
    .reference(labelRef)
```
