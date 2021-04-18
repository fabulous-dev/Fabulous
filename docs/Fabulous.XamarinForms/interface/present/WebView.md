{% include_relative ../../_header.md %}

{% include_relative ../../contents.md %}

WebView
--------

<br /> 

### Basic example


```fsharp 
View.ContentPage(                    
    backgroundColor = style.PageColor,
    title ="WebView",                         
    content = 
        View.WebView
            (                        
                source = UrlWebViewSource.op_Implicit "https://fsprojects.github.io/Fabulous/Fabulous.XamarinForms/"
            )
)
```

<img src="../../images/views/WebView-adr-basic.png" width="300">

<br /> <br /> 

### Basic example with styling

```fsharp 
View.ContentPage(                    
    backgroundColor = style.PageColor,
    title ="WebView",                         
    content = 
        View.WebView
            (
                backgroundColor = style.ViewColor,
                margin = style.Thickness,                                
                source = UrlWebViewSource.op_Implicit "https://fsprojects.github.io/Fabulous/Fabulous.XamarinForms/"
            )
)
```


<img src="../../images/views/WebView-adr-styled.png" width="300">

<br /> <br /> 

See also:

* [WebView in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/WebView)
* [`Xamarin.Forms.WebView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.WebView)

<br /> 

### More examples

`WebView` is a view for displaying web and HTML content in your app:

```fsharp 
let fabulousSite = "https://fsprojects.github.io/Fabulous/Fabulous.XamarinForms/"
View.WebView( 
    source = UrlWebViewSource.op_Implicit fabulousSite, 
    backgroundColor = Color.Red,
    margin = Thickness(20.)
)
```