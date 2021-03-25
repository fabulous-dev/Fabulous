{% include_relative _header.md %}

{% include_relative contents.md %}

Shells 
------
##### (topic last updated: v 0.61.0)
<br /> 

Xamarin.Forms Shell reduces the complexity of mobile application development by providing the fundamental features that most mobile applications require. This includes a common navigation user experience, a URI-based navigation scheme, and an integrated search handler.

```fsharp     
View.Shell(title = "TitleShell",
    items = [
        View.ShellItem(items = [
            View.ShellSection( items = [
                View.ShellContent(title = "Section 1", 
                    content = View.ContentPage( content = View.Button(text = "press me")
                    )                                        
                )]
            )]
        )]
)      
```

See also:

* [Xamarin guide to Shell](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/shell)
* [`Xamarin.Forms.Core.Shell`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.shell)