{% include_relative ../../_header.md %}

{% include_relative ../../contents.md %}

SearchBar
--------

<br /> 

### Basic example


```fsharp 
View.SearchBar(placeholder = "SearchBar")
```

<img src="../../images/views/SearchBar-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.SearchBar
    (
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.ViewColor,
        placeholder = "SearchBar"
    )
```


<img src="../../images/views/SearchBar-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [`Xamarin.Forms.SearchBar`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.SearchBar)

<br /> 

### More examples

A simple `SearchBar` is as follows:

```fsharp
View.SearchBar(
    placeholder = "Enter search term",
    searchCommand = (fun searchBarText -> dispatch  (ExecuteSearch searchBarText)),
    searchCommandCanExecute=true)
```

<img src="https://user-images.githubusercontent.com/52166903/60180196-5d63c480-9817-11e9-9c21-e8b19dee8474.png" width="400">