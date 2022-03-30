{% include_relative _header.md %}

{% include_relative contents.md %}

RefreshView
--------
##### `topic last updated: v1.0 - 24.04.2021 - 11:47pm`

### [back to interface objects](view-interface-objects.html#interface-objects)

<br />

### Basic example


```fsharp 
View.RefreshView
    (
        content = 
            View.ListView
                (
                    items = [
                        View.TextCell "First ListView"; 
                        View.TextCell "Second ListView"; 
                        View.TextCell "Third ListView"
            ] ) 
    )
```

<img src="images/view/RefreshView-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.RefreshView
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.LayoutColor,
        padding = style.Padding,
        content = 
            View.ListView
                (
                    
                    horizontalOptions = style.Position,
                    verticalOptions = style.Position,
                    backgroundColor = style.ViewColor,
                    items = [
                        View.TextCell "First ListView"; 
                        View.TextCell "Second ListView"; 
                        View.TextCell "Third ListView"
            ] ) 
    )
```


<img src="images/view/RefreshView-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [RefreshView in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/RefreshView)
* [`Xamarin.Forms.RefreshView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.RefreshView)

<br /> 

### More examples

The RefreshView is a container control that provides pull to refresh functionality for scrollable content. Therefore, the child of a RefreshView must be a scrollable control, such as ScrollView, CollectionView, or ListView.

```fsharp 
View.RefreshView(
    View.ScrollView(
        View.BoxView(
            height = 150.,
            width = 150.,
            color = if model.IsRefreshing then Color.Red else Color.Blue
        )
    ),
    isRefreshing = model.IsRefreshing,
    refreshing = (fun () -> dispatch Refresh)
)
```