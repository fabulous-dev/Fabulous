{% include_relative _header.md %}

{% include_relative contents.md %}

Interface objects (Views) for initiating commands
------
##### `topic last updated: v 0.61.0 - 31.03.2021 - 02:29pm,`
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

The ImageButton displays an image and responds to a tap or click that directs an application to carry out a particular task.

```fsharp 
let monkey =  "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"

View.ImageButton(
    source = Image.ImagePath monkey
)
```

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