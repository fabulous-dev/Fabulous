---
title : "WebView"
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
View.ContentPage(
    backgroundColor = style.PageColor,
    title ="WebView",
    content = 
        View.WebView(
            source = UrlWebViewSource.op_Implicit "https://fsprojects.github.io/Fabulous/Fabulous.XamarinForms/"
        )
)
```

<img src="images/view/WebView-adr-basic.png" width="300">

### Basic example with styling

```fs
View.ContentPage(
    backgroundColor = style.PageColor,
    title = "WebView",
    content = 
        View.WebView(
            backgroundColor = style.ViewColor,
            margin = style.Thickness,
            source = UrlWebViewSource.op_Implicit "https://fsprojects.github.io/Fabulous/Fabulous.XamarinForms/"
        )
)
```

<img src="images/view/WebView-adr-styled.png" width="300">

See also:

* [WebView in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/WebView)
* [`Xamarin.Forms.WebView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.WebView)

## More examples

`WebView` is a view for displaying web and HTML content in your app:

```fs
let fabulousSite = "https://fsprojects.github.io/Fabulous/Fabulous.XamarinForms/"
View.WebView(
    source = UrlWebViewSource.op_Implicit fabulousSite, 
    backgroundColor = Color.Red,
    margin = Thickness(20.)
)
```
