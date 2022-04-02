---
title : "ImageButton"
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
View.ImageButton(Image.ImagePath "icon.png")
```

<img src="images/view/ImageButton-adr-basic.png" width="300">

## Basic example with styling

```fs
View.ImageButton(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.ButtonColor,
    padding = style.Padding,
    source = Image.ImagePath "icon.png"
)
```

<img src="images/view/ImageButton-adr-styled.png" width="300">

See also:

* [ImageButton in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/ImageButton)
* [`Xamarin.Forms.ImageButton`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.ImageButton)

## More examples

The ImageButton displays an image and responds to a tap or click that directs an application to carry out a particular task.

```fs
let monkey = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"

View.ImageButton(Image.ImagePath monkey)
```
