---
title : "SearchBar"
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
View.SearchBar(placeholder = "SearchBar")
```

<img src="images/view/SearchBar-adr-basic.png" width="300">

## Basic example with styling

```fs
View.SearchBar(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.ViewColor,
    placeholder = "SearchBar"
)
```

<img src="images/view/SearchBar-adr-styled.png" width="300">

See also:

* [SearchBar in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/SearchBar)
* [`Xamarin.Forms.SearchBar`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.SearchBar)

## More examples

A simple `SearchBar` is as follows:

```fs
View.SearchBar(
    placeholder = "Enter search term",
    searchCommand = (fun searchBarText -> dispatch  (ExecuteSearch searchBarText)),
    searchCommandCanExecute=true
)
```

<img src="https://user-images.githubusercontent.com/52166903/60180196-5d63c480-9817-11e9-9c21-e8b19dee8474.png" width="400">
