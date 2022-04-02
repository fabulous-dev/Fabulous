---
title : "TimePicker"
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
View.TimePicker()
```

<img src="images/view/TimePicker-adr-basic.png" width="300">

### Basic example with styling

```fs
View.TimePicker(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.ViewColor
)
```

<img src="images/view/TimePicker-adr-styled.png" width="300">

See also:

* [`Xamarin.Forms.TimePicker`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.TimePicker)

## More examples

```fs
View.TimePicker(
    time = TimeSpan(12, 22, 0)
)
```
