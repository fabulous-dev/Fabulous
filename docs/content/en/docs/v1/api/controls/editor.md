---
title : "Editor"
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
View.Editor
    ("Editor")
```

<img src="images/view/Editor-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fs 
View.Editor
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.LayoutColor,
        text = "Editor"
    )
```


<img src="images/view/Editor-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [Editor in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/text/Editor)
* [`Xamarin.Forms.Editor`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Editor)

<br /> 

### More examples

An example `Editor` is as follows:

```fs
View.Editor(text = editorText,
    textChanged = (fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
    completed = (fun text -> dispatch (EditorEditCompleted text)))
```

<img src="https://user-images.githubusercontent.com/52166903/60175558-d2c99800-980b-11e9-9755-860cc9a60dcf.png" width="400">