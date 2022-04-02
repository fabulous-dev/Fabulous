---
id: "v1-checkbox"
title : "Checkbox"
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
View.CheckBox(true)
```

## Basic example with styling

```fs
View.CheckBox(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.LayoutColor,
    isChecked = true
)
```

See also:

* [`Xamarin.Forms.CheckBox`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.CheckBox)

## More examples

```fs
View.CheckBox(
    isChecked = true,
    checkedChanged = (fun on -> dispatch (...))
)
```
