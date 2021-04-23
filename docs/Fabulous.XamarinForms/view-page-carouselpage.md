{% include_relative _header.md %}

{% include_relative contents.md %}

CarouselPage
--------
##### `topic last updated: v1.0 - 24.04.2021 - 11:47pm`

<br />

### Basic example


```fsharp 
View.CarouselPage(children = [
    View.ContentPage(title ="carousel1", content = View.Label("carousel page 1") )
    View.ContentPage(title ="carousel1", content = View.Label("carousel page 2") )
] )
```
<img src="images/pages/content-adr-basic.png" width="300">
<br /> <br /> 

### Basic example with styling

```fsharp 
View.CarouselPage(
    backgroundColor = style.PageColor,
    title = "CarouselPage",
    children = [
        View.ContentPage(title ="carousel1", content = View.Label
            (
                horizontalOptions = style.Position,
                verticalOptions = style.Position,
                backgroundColor = style.ViewColor,
                padding = style.Padding,
                text = "carousel page 1"
            )
        )                
        View.ContentPage(title ="carousel1", content = View.Label
            (
                horizontalOptions = style.Position,
                verticalOptions = style.Position,
                backgroundColor = style.ViewColor,
                padding = style.Padding,
                text = "carousel page 2"
            )
        )
    ]
)
```
<img src="images/pages/carousel-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [`Xamarin.Forms.CarouselPage`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.CarouselPage)