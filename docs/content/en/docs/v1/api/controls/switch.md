---
title : "Switch"
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
View.Switch()
```

<img src="images/view/Switch-adr-basic.png" width="300">

## Basic example with styling

```fs
View.Switch(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.ViewColor,
    isToggled = false
)
```

<img src="images/view/Switch-adr-styled.png" width="300">

See also:

* [`Xamarin.Forms.Switch`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Switch)

## More examples

`Switch` is a horizontal toggle button that can be manipulated by the user to toggle between on and off states, which are represented by a boolean value.

```fs
View.Switch(
    isToggled = false,
    toggled = fun on -> dispatch (SwitchToggled (...))
)
```
