{% include_relative _header.md %}

{% include_relative contents.md %}

ContentPage
--------
##### `topic last updated: v1.0 - 02.04.2021 - 11:47pm`

<br /> 

### Basic example
A single page app typically returns a `ContentPage`. For example:

```fsharp 
View.ContentPage(title = "ContentPage", content = View.Label("ContentPage with a single Label"))
```
<img src="images/pages/content-adr-basic.png" width="300">
<br /> <br /> 

### Basic example with styling

```fsharp 
View.ContentPage(
    backgroundColor = style.PageColor,
    title = "ContentPage",
    content = 
        View.Label
            (   
                horizontalOptions = style.Position,
                verticalOptions = style.Position,
                backgroundColor = style.ViewColor,
                padding = style.Padding,
                text = sprintf "ContentPage with a single Label" 
            )
)
```
<img src="images/pages/content-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [`Xamarin.Forms.ContentPage`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.ContentPage)









