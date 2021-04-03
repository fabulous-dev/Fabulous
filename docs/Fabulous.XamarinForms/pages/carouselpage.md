{% include_relative ../_header.md %}

{% include_relative ../contents.md %}

CarouselPage
--------

#### basic example

```fsharp 
View.CarouselPage(
    children = [
        View.ContentPage(title ="carousel1", content = View.Label("carousel page 1"))                
        View.ContentPage(title ="carousel1", content = View.Label("carousel page 2"))
    ]
)
```

See also:

* [`Xamarin.Forms.CarouselPage`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.CarouselPage)