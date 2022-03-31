---
title : "TabbedPage"
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
View.TabbedPage(children = [
        View.ContentPage(title ="First Tab", content = View.Label("TabbedPage 1"))                
        View.ContentPage(title ="Second Tab", content = View.Label("TabbedPage 2"))
] )
```
<img src="images/pages/tabbed-adr-basic.png" width="300">
<br /> 

### Basic example with styling
```fs       
View.TabbedPage(
    backgroundColor = style.PageColor,
    title ="TabbedPage",
    children = [
        View.ContentPage( title ="First Tab", content = View.Label
            (                                 
                horizontalOptions = style.Position,
                verticalOptions = style.Position,
                backgroundColor = style.ViewColor,
                padding = style.Padding,
                text = "TabbedPage 1" 
            ) 
        )
        View.ContentPage( title ="Second Tab", content = View.Label
            (                                
                horizontalOptions = style.Position,
                verticalOptions = style.Position,
                backgroundColor = style.ViewColor,
                padding = style.Padding,
                text = "TabbedPage 2"
            ) 
        )                
    ] )
```

<img src="images/pages/tabbed-adr-styled.png" width="300">

<br />

See also:

* [`Xamarin.Forms.TabbedPage`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.TabbedPage)


