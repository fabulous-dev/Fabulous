---
id: "v2-search-bar"
title: "SearchBar"
description: ""
lead: ""
date: 2022-06-02T00:00:00+00:00
lastmod: 2022-06-02T00:00:00+00:00
draft: false
images: []
menu:
docs:
parent: "controls"
toc: true
---

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "../navigable-element.md" >}}) -> [VisualElement]({{< ref "../visual-element.md" >}}) -> [View]({{< ref "../view.md" >}}) -> [InputView]({{< ref "input-view.md" >}})  
**Xamarin.Forms documentation:** SearchBar [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.searchbar) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/searchbar)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/searchbar).

## Constructors

| Constructors | Description |
|--|--|
| SearchBar(text: string, onTextChanged: string -> 'msg, onSearchButtonPressed: 'msg) | Defines a SearchBar widget with a text, onTextChanged and onSearchButtonPressed events. |

## Properties

| Properties | Description |
|--|--|
| cancelButtonColor(light: FabColor, ?dark: FabColor) | Sets a value that indicates the color of the cancel button depending if light or dark mode. |
| font(?size: float, ?namedSize: NamedSize, ?attributes: FontAttributes, ?fontFamily: string) | Sets the font family used |
| horizontalTextAlignment(value: TextAlignment) | Sets the horizontal text alignment. |
| verticalTextAlignment(value: TextAlignment) | Sets the vertical text alignment. |
| reference(value: ViewRef&lt;SearchBar&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.SearchBar` instance associated to this widget |

## Usages

```fs
SearchBar("Enter a description", TextChanged, SearchButtonPressed)
    .keyboard(Keyboard.Email)
    .cancelButtonColor(Color.Green.ToFabColor(), Color.White.ToFabColor())
    .textColor(Color.Red.ToFabColor(), Color.Blue.ToFabColor())
    .font(namedSize = NamedSize.Large, fontFamily = "Arial", attributes = FontAttributes.Bold)
    .textTransform(TextTransform.Lowercase)
```

### Get access to the underlying Xamarin.Forms.SearchBar

```fs
let searchBarRef = ViewRef<SearchBar>()

SearchBar("Enter a description", TexChanged, SearchButtonPressed)
    .reference(searchBarRef)
```
