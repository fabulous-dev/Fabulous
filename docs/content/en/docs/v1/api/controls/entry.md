---
id: "v1-entry"
title : "Entry"
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
View.Entry("Entry")
```

## Basic example with styling

```fs
View.Entry(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.LayoutColor,
    text = "Entry"
)
```

See also:

* [Entry in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/text/Entry)
* [`Xamarin.Forms.`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.)

## More examples

An example `Entry` is as follows:

```fs
View.Entry(
    text = entryText,
    textChanged = (fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
    completed = (fun text -> dispatch (EntryEditCompleted text))
)
```

An example `Entry` with password is as follows:

```fs
View.Entry(
    text = password,
    isPassword = true,
    textChanged = (fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
    completed = (fun text -> dispatch (EntryEditCompleted text))
)
```

An example `Entry` with a placeholder is as follows:

```fs
View.Entry(
    placeholder = "Enter text",
    textChanged = (fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
    completed = (fun text -> dispatch (EntryEditCompleted text))
)
```

<img src="https://user-images.githubusercontent.com/52166903/60177359-9cdae280-9810-11e9-9d80-059a9a885b72.png" width="400">
