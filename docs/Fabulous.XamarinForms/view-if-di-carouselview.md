{% include_relative _header.md %}

{% include_relative contents.md %}

CarouselView
--------

##### `topic last updated: v1.0 - 24.04.2021 - 11:47pm`

### [back to interface objects](view-interface-objects.html#interface-objects)

<br />

displays a scrollable list of data 

<br /> 

### Basic example


```fsharp 
View.CarouselView(items = [
    View.Label("First CarouselView")
    View.Label("Second CarouselView")
    View.Label("Third CarouselView")
] )
```

<img src="images/views/CarouselView-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.CarouselView
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.LayoutColor,
        items = [
            View.Label
                (
                    horizontalOptions = style.Position,
                    verticalOptions = style.Position,
                    backgroundColor = style.ViewColor,
                    padding = style.Padding,  
                    text = ("First CarouselView")
                )
            View.Label
                (
                    horizontalOptions = style.Position,
                    verticalOptions = style.Position,
                    backgroundColor = style.ViewColor2,
                    padding = style.Padding,  
                    text = ("Second CarouselView")
                )
            View.Label
                (
                    horizontalOptions = style.Position,
                    verticalOptions = style.Position,
                    backgroundColor = style.ViewColor3,
                    padding = style.Padding,  
                    text = ("Third CarouselView")
                )
        ] 
    )
```


<img src="images/views/CarouselView-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [CarouselView in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/CarouselView)
* [`Xamarin.Forms.CarouselView`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.carouselview?view=xamarin-forms)