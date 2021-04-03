{% include_relative ../_header.md %}

{% include_relative ../contents.md %}

NavigationPage
--------
##### `topic last updated: v1.0 - 02.04.2021 - 11:47pm`

<br /> 

A Page that manages the navigation and user-experience of a stack of other pages.

### Basic example
```fsharp 
View.NavigationPage
    (
        pages = [
            View.ContentPage(title = "ContentPage", content = View.Label("ContentPage with a single Label"))
        ]
    )
```

<img src="../images/pages/navigation-adr-basic.png" width="300">

<br /> <br /> 

See also:

* [`Xamarin.Forms.NavigationPage`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.NavigationPage)