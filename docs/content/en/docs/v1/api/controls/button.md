---
title : "Button"
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

### Basic example


```fs 
View.Button("Button")
```

<img src="images/view/Button-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fs 
View.Button
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.ButtonColor,
        padding = style.Padding,
        text = "Button"
    )
```


<img src="images/view/Button-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [Button in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/Button)
* [`Xamarin.Forms.Button`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Button)

<br /> 

### More examples

Buttons are created using `View.Button`. The `command` of a button will normally dispatch a messsage.  For example:

```fs 
View.Button(text = "Deposit", command = (fun () -> dispatch (Add 10.0)))
```
<img src="https://user-images.githubusercontent.com/52166903/60180200-5dfc5b00-9817-11e9-87d1-e3d254b1cf2b.png" width="400">