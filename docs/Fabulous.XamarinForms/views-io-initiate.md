{% include_relative _header.md %}

{% include_relative contents.md %}

Interface objects (Views) for initiating commands
------
##### `topic last updated: v1.0 - 04.04.2021 - 02:51pm`

| Editing text                                    | Description                                                                                                                    | Appearance                                                   |
|-------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------|
| [Button](interface/initiate/Button.md)           | usually displays a short text string indicating a command                                                                      | <img src="images/views/Button-adr-styled.png" width="300"> |
| [ImageButton](interface/initiate/ImageButton.md) | combines the Button view and Image view to create a button whose content is an image                                           | <img src="images/views/ImageButton-adr-styled.png" width="300"> |
| [RadioButton](interface/initiate/RadioButton.md) | a type of button that allows users to select one option from a set                                                             | <img src="images/views/RadioButton-adr-styled.png" width="300"> |
| [RefreshView](interface/initiate/RefreshView.md) | a container control that provides pull to refresh functionality for scrollable content                                         | <img src="images/views/RefreshView-adr-styled.png" width="300"> |
| [SearchBar](interface/initiate/SearchBar.md)     | a user input control used to initiating a search                                                                               | <img src="images/views/SearchBar-adr-styled.png" width="300"> |
| [SwipeView](interface/initiate/SwipeView.md)     | a container control that wraps around an item of content, and provides context menu items that are revealed by a swipe gesture | <img src="images/views/SwipeView-adr-styled.png" width="300"> |

<br /> 

### Button

Buttons are created using `View.Button`. The `command` of a button will normally dispatch a messsage.  For example:

```fsharp 
View.Button(text = "Deposit", command = (fun () -> dispatch (Add 10.0)))
```
<img src="https://user-images.githubusercontent.com/52166903/60180200-5dfc5b00-9817-11e9-87d1-e3d254b1cf2b.png" width="400">

See also:

* [Xamarin guide to Button](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/button)
* [`Xamarin.Forms.Core.Button`](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/button/)

<br /> 

### ImageButton



See also:

* [Xamarin guide to ImageButton](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/imagebutton)
* [`Xamarin.Forms.ImageButton`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.imagebutton)

<br /> 

### RadioButton
```fsharp 
View.StackLayout( children = [
    // These RadioButtons will be grouped togehter, beacause they are in the same StackLayout
    View.RadioButton(
        padding = Thickness 2.0,
        content = Content.String("content1"), 
        isChecked = true
        checkedChanged = (fun on -> dispatch (...))
    )
    View.RadioButton(
        padding = Thickness 2.0,
        content = Content.String("content2"), 
        isChecked = false
        checkedChanged = (fun on -> dispatch (...))
    )
])
```

See also:

* [Xamarin guide to RadioButton](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/radiobutton)
* [`Xamarin.Forms.RadioButton`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.radiobutton?view=xamarin-forms)

<br /> 

### RefreshView

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
See also:

* [Xamarin guide to RefreshView](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/refreshview)
* [`Xamarin.Forms.RefreshView`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.refreshview?view=xamarin-forms)

<br /> 

### SearchBar
A simple `SearchBar` is as follows:

```fsharp
View.SearchBar(
    placeholder = "Enter search term",
    searchCommand = (fun searchBarText -> dispatch  (ExecuteSearch searchBarText)),
    searchCommandCanExecute=true)
```

<img src="https://user-images.githubusercontent.com/52166903/60180196-5d63c480-9817-11e9-9c21-e8b19dee8474.png" width="400">

See also:

* [Xamarin guide to SearchBar](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/searchbar)
* [Xamarin.Forms.Core.SearchBar](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.searchbar?view=xamarin-forms)

<br /> 

### SwipeView

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

See also:

* [Xamarin guide to SwipeView](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/swipeview)
* [`Xamarin.Forms.SwipeView`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.swipeview?view=xamarin-forms)