{% include_relative _header.md %}

{% include_relative contents.md %}

TabbedPage
--------
##### `topic last updated: v1.0 - 24.04.2021 - 11:47pm`

<br /> 
A TabbedPage displays an array of tabs across the top of the screen, each of which loads content onto the screen.

<br /> 
<br /> 

### Basic example
```fsharp       
View.TabbedPage(children = [
        View.ContentPage(title ="First Tab", content = View.Label("TabbedPage 1"))                
        View.ContentPage(title ="Second Tab", content = View.Label("TabbedPage 2"))
] )
```
<img src="images/pages/tabbed-adr-basic.png" width="300">
<br /> 

### Basic example with styling
```fsharp       
View.TabbedPage(
    backgroundColor = style.PageColor,
    title ="TabbedPage",
    children = [
        View.ContentPage( title ="First Tab", content = View.Label
            (                                 
                horizontalOptions = style.Position,
                verticalOptions = style.Position,
                backgroundColor = style.ViewColor,
                padding = style.Padding,
                text = "TabbedPage 1" 
            ) 
        )
        View.ContentPage( title ="Second Tab", content = View.Label
            (                                
                horizontalOptions = style.Position,
                verticalOptions = style.Position,
                backgroundColor = style.ViewColor,
                padding = style.Padding,
                text = "TabbedPage 2"
            ) 
        )                
    ] )
```

<img src="images/pages/tabbed-adr-styled.png" width="300">

<br />

See also:

* [`Xamarin.Forms.TabbedPage`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.TabbedPage)


