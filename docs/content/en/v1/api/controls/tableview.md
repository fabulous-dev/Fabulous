---
id: "v1-tableview"
title : "TableView"
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
View.TableView(
    View.TableRoot([
        View.TableSection(
            title = "TextCell",
            items = [
                View.TextCell(text = "First TextCell") 
                View.TextCell(text = "Second TextCell")
            ]
        )
        View.TableSection(
            title = "ImageCell",
            items = [
                View.ImageCell(text = "First ImageCell", image = Image.ImagePath "icon.png") 
                View.ImageCell(text = "Second ImageCell", image = Image.ImagePath "icon2.png") 
            ]
        )
        View.TableSection(
            title = "SwitchCell",
            items = [
                View.SwitchCell(text = "First SwitchCell", isEnabled = false)
                View.SwitchCell(text = "Second SwitchCell", isEnabled = true)
            ]
        )
        View.TableSection(
            title = "EntryCell",
            items = [
                View.EntryCell(label = "First EntryCell", placeholder = "enter text here")
                View.EntryCell(label = "Second EntryCell", placeholder = "enter more text here")
            ]
        )
    ])
)
```

See also:

* [TableView in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/TableView)
* [`Xamarin.Forms.TableView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.TableView)

## More examples

<img src="https://user-images.githubusercontent.com/52166903/60177365-9d737900-9810-11e9-92d5-88487316bbf6.png" width="400">
