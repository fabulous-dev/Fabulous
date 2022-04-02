---
id: "v1-switch"
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
toc: true
---

## Basic example

```fs
View.Switch()
```

## Basic example with styling

```fs
View.Switch(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.ViewColor,
    isToggled = false
)
```

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
