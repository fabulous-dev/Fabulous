---
title : "Checkbox"
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
View.CheckBox(true)
```

<img src="images/view/CheckBox-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fs 
View.CheckBox
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.LayoutColor,
        isChecked = true
    )
```


<img src="images/view/CheckBox-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [`Xamarin.Forms.CheckBox`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.CheckBox)

<br /> 

### More examples

```fs 

View.CheckBox(
    isChecked = true,
    checkedChanged = (fun on -> dispatch (...))
)
```