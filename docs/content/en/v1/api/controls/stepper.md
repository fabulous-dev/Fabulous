---
id: "v1-stepper"
title : "Stepper"
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
View.Stepper( 5.0 )
```

## Basic example with styling

```fs
View.Stepper(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.ViewColor,
    minimumMaximum = (0.0, 10.0),
    value = 5.0
)
```

See also:

* [`Xamarin.Forms.Stepper`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Stepper)

## More examples

Use a Stepper for selecting a numeric value from a range of values.

```fs
View.Stepper(
    minimumMaximum = (0.0, 10.0),
    value = 2.,
    increment = 1.,
    valueChanged = fun args -> dispatch (SliderValueChanged (...))
)
```
