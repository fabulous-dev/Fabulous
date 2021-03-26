{% include_relative _header.md %}

{% include_relative contents.md %}

Pages 
------
 These visual elements occupy all or most of the screen and usually contain several layers of lower tier visual elements. 
 For example, a ContentPage may contain a StackLayout which in turn contains several buttons, labeles or other view elements. 

| Page type          | Description                                                                                          | Appearance |
|----------------|------------------------------------------------------------------------------------------------------|------------|
| ContentPage    | a simple page, containing a single View object (usually a layout)                                    |            |
| FlyoutPage     | contains a flyout pane (usually a list or menu) plus a detail pane (usually showing a selected item) |            |
| NavigationPage | manages navigation among other pages using a stack-based architecture                                |            |
| TabbedPage     | allows navigation among child pages using tabs                                                       |            |
| CarouselPage   | allows navigation among child pages through finger swiping                                           |            |


<br /> 

See also [Multi-page Applications and Navigation](pages-navigation.html)

<br /> 

Examples
------
<br />

### ContentPage

A single page app typically returns a `ContentPage`. For example:

```fsharp 
let view model dispatch =
    View.ContentPage(
        title = "Pocket Piggy Bank",
        content = View.Label(text = sprintf "Hello world!")
    )
```

See also:

* [`Xamarin.Forms.Core.ContentPage`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.ContentPage)

### FlyoutPage
```fsharp 
let view model dispatch =
    View.FlyoutPage(
        flyout = View.ContentPage(title ="flyoutPage", content = View.Label("flyout")), // 'title' is needed for the flyout page
        detail = View.ContentPage(content = View.Label("detail"))        
    )
```

### NavigationPage
```fsharp 
let view model dispatch =
    View.NavigationPage(pages = [
        View.ContentPage(title ="navigation", content = View.Label("navigation page 1"))
            .ToolbarItems([
                View.ToolbarItem(text = "About", command = (fun () -> dispatch (ShowAbout true))) 
            ])
    ])
```

### TabbedPage
```fsharp 
let view model dispatch =        
    View.TabbedPage(
        children = [
            View.ContentPage(title ="tab1", content = View.Label("tabbed page 1"))                
            View.ContentPage(title ="tab2", content = View.Label("tabbed page 2"))
            ---
        ]
    )
```

### CarouselPage
```fsharp 
let view model dispatch =
    View.CarouselPage(
        children = [
            View.ContentPage(title ="carousel1", content = View.Label("carousel page 1"))                
            View.ContentPage(title ="carousel1", content = View.Label("carousel page 2"))
        ]
    )
```