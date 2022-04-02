---
id: "v1-slider"
title : "Slider"
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
View.Slider( 5.0 )
```

## Basic example with styling

```fs
View.Slider(
    backgroundColor = style.ViewColor,
    minimumMaximum = (0.0, 10.0),
    value = 5.0
)
```

See also:

* [`Xamarin.Forms.Slider`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Slider)

## More examples

```fs
View.Slider(
    minimumMaximum = (0.0, 10.0),
    value = double step,
    valueChanged = (fun args -> dispatch (SliderValueChanged (int (args.NewValue + 0.5))))
)
```

<img src="https://user-images.githubusercontent.com/52166903/60177363-9d737900-9810-11e9-8842-aeb904e7d739.png" width="400">
