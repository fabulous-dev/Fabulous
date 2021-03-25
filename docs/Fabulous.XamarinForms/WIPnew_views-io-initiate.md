{% include_relative _header.md %}

{% include_relative contents.md %}

Interface objects (Views) for initiating commands
------
##### (topic last updated: v 0.61.0)
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
```fsharp 

```

<br /> 

### RadioButton
```fsharp 

```

<br /> 

### RefreshView
```fsharp 

```

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

* [Xamarin.Forms.Core.SearchBar](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.searchbar?view=xamarin-forms)

<br /> 

### SwipeView
```fsharp 

```