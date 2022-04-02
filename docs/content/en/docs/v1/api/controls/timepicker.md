---
id: "v1-timepicker"
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
toc: true
---

## Basic example

```fs
View.TimePicker()
```

### Basic example with styling

```fs
View.TimePicker(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.ViewColor
)
```

See also:

* [`Xamarin.Forms.TimePicker`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.TimePicker)

## More examples

```fs
View.TimePicker(
    time = TimeSpan(12, 22, 0)
)
```
