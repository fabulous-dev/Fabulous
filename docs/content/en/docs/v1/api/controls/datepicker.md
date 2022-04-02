---
id: "v1-datepicker"
title : "DatePicker"
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
View.DatePicker()
```

## Basic example with styling

```fs
View.DatePicker(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.ViewColor
)
```

See also:

* [`Xamarin.Forms.DatePicker`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.DatePicker)

## More examples

```fs
View.DatePicker(
    minimumDate = DateTime.Today,
    maximumDate = DateTime.Today + TimeSpan.FromDays(365.0),
    date = startDate,
    dateSelected = (fun args -> dispatch (StartDateSelected args.NewDate))
)
```

<img src="https://user-images.githubusercontent.com/52166903/60177357-9cdae280-9810-11e9-9979-1e91cf8c5ea6.png" width="400">
