---
id: "v1-label"
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
toc: true
---

## Basic example

```fs
View.Label("Label")
```

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

See also:

* [Label in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/text/Label)
* [`Xamarin.Forms.Label`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Label)

## More examples

The Label view is used for displaying text, both single and multi-line. Labels can have text decorations, colored text, and use custom fonts (families, sizes, and options).

```fs
View.Label(text = "this is a label")
```
