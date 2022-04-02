---
title : "Label"
description: ""
lead: ""
date: 2022-03-31T00:00:00+00:00
lastmod: 2022-03-31T00:00:00+00:00
draft: false
images: []
menu:
    docs:
        parent: "controls"
weight: 101
toc: true
---

## Basic example

```fs
View.Label("Label")
```

<img src="images/view/Label-adr-basic.png" width="300">

## Basic example with styling

```fs
View.Label(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.ViewColor,
    padding = style.Padding,
    text = "Label"
)
```

<img src="images/view/Label-adr-styled.png" width="300">

See also:

* [Label in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/text/Label)
* [`Xamarin.Forms.Label`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Label)

## More examples

The Label view is used for displaying text, both single and multi-line. Labels can have text decorations, colored text, and use custom fonts (families, sizes, and options).

```fs
View.Label(text = "this is a label")
```
