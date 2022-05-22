---
id: "v1-picker"
title : "Picker"
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
let pickerItems =
    [ ("Aqua", Color.Aqua); ("Black", Color.Black);
      ("Blue", Color.Blue); ("Fucshia", Color.Fuchsia);
      ("Gray", Color.Gray); ("Green", Color.Green);
      ("Lime", Color.Lime); ("Maroon", Color.Maroon);
      ("Navy", Color.Navy); ("Olive", Color.Olive);
      ("Purple", Color.Purple); ("Red", Color.Red);
      ("Silver", Color.Silver); ("Teal", Color.Teal);
      ("White", Color.White); ("Yellow", Color.Yellow ) ]

let pickedColorIndex = 2 // placeholder for demonstration purposes
View.ContentPage(title ="Picker", content =
    View.Picker(
        title = "Choose Color:",
        textColor = snd pickerItems.[pickedColorIndex],
        selectedIndex = pickedColorIndex,
        items = List.map fst pickerItems
    )
)
```

See also:

* [Picker in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/Picker)
* [`Xamarin.Forms.Picker`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Picker)

## More examples

<img src="https://user-images.githubusercontent.com/52166903/60177361-9d737900-9810-11e9-87a2-ade4880f7222.png" width="400">
