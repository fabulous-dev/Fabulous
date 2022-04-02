---
id: "v1-radiobutton"
title : "RadioButton"
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
View.StackLayout([
    View.RadioButton(Content.String "RadioButton 1")
    View.RadioButton(Content.String "RadioButton 2")
])
```

## Basic example with styling

```fs
View.StackLayout(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.LayoutColor,
    children = [
        View.RadioButton(
            horizontalOptions = style.Position,
            verticalOptions = style.Position,
            backgroundColor = style.ViewColor,
            padding = style.Padding,
            isChecked = true,
            content = Content.String "RadioButton 1"
        )
        View.RadioButton(
            horizontalOptions = style.Position,
            verticalOptions = style.Position,
            backgroundColor = style.ViewColor,
            padding = style.Padding,
            isChecked = false,
            content = Content.String "RadioButton 2"
        )
    ]
)
```

See also:

* [RadioButton in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/RadioButton)
* [`Xamarin.Forms.RadioButton`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.RadioButton)

## More examples

```fs
View.StackLayout([
    // These RadioButtons will be grouped together, beacause they are in the same StackLayout
    View.RadioButton(
        padding = Thickness 2.0,
        content = Content.String("content1"),
        isChecked = true
        checkedChanged = (fun on -> dispatch (...))
    )
    View.RadioButton(
        padding = Thickness 2.0,
        content = Content.String("content2"),
        isChecked = false
        checkedChanged = (fun on -> dispatch (...))
    )
])
```
