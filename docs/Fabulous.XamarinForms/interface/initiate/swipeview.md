{% include_relative ../../_header.md %}

{% include_relative ../../contents.md %}

SwipeView
--------

<br /> 

### Basic example


```fsharp 
(
    leftItems =                                 
        View.SwipeItems
            (
                items = [ 
                    View.SwipeItem("Left 1")
                    View.SwipeItem("Left 2")
                ]
            ),
    rightItems =                                 
        View.SwipeItems
            (
                items = [
                    View.SwipeItem("Right 1")
                    View.SwipeItem("Right 2")
                ]
            ),
    content = View.Grid
        (
            height = 60.,
            width = 300.,
            children = [
                View.Label("test")
            ]
        )
)
```

<img src="../../images/views/SwipeView-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.SwipeView
(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.LayoutColor,
    padding = style.Padding,
    leftItems =                                 
        View.SwipeItems
            (
                items = [
                    View.SwipeItem
                        (
                            backgroundColor = style.ViewColor,
                            text = "Left 1"
                        )
                    View.SwipeItem
                        (
                            backgroundColor = style.ViewColor2,
                            text = "Left 2"
                        )
                ]
            ),
    rightItems =                                 
        View.SwipeItems
            (
                items = [
                    View.SwipeItem
                        (
                            backgroundColor = style.ViewColor3,
                            text = "Right 1"
                        )
                    View.SwipeItem
                        (
                            backgroundColor = style.ViewColor4,
                            text = "Right 2"
                        )
                ]
            ),
    content = View.Grid
        (
            height = 60.,
            width = 300.,
            children = [
                View.Label
                    (   
                        horizontalOptions = style.Position,
                        verticalOptions = style.Position,
                        backgroundColor = style.ViewColor,
                        padding = style.Padding,
                        text = "test"
                    )
            ]
        )
)
```


<img src="../../images/views/SwipeView-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [SwipeView in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/SwipeView)
* [`Xamarin.Forms.SwipeView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.SwipeView)

<br /> 

### More examples

The SwipeView is a container control that wraps around an item of content, and provides context menu items that are revealed by a swipe gesture:

```fsharp 
View.SwipeView(
                leftItems = View.SwipeItems(
                    items = [
                        View.SwipeItem(text="Left 1", backgroundColor=Color.LightPink)
                        View.SwipeItem(text="Left 2", backgroundColor=Color.LightGreen)
                    ]
                ),
                rightItems = View.SwipeItems(
                    items = [
                        View.SwipeItem(text="Right 1", backgroundColor=Color.LightPink)
                        View.SwipeItem(text="Right 2", backgroundColor=Color.LightGreen)
                    ]
                ),
                content = View.Grid(
                    height=60.0,
                    width=300.0,
                    backgroundColor=Color.LightGray,
                    children = [
                        View.BoxView(Color.Blue)
                    ]
                )
            )
```