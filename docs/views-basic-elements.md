### CollectionView, CarouselView, Shell

`CollectionView`, `CarouselView` and `Shell` are available in preview in Xamarin.Forms 3.5.  
Please read the Xamarin.Forms documentation to check whether those controls are available for the platforms you target.

Fabulous provides an initial but partial support for them.  
We will fully support them once officially released.

As they are experimental, each one of these controls requires a flag before they can be used.
- Shell = Shell_Experimental
- CollectionView/CarouselView = CollectionView_Experimental

```fsharp

// iOS
[<Register ("AppDelegate")>]
type AppDelegate () =
    inherit FormsApplicationDelegate ()

    override this.FinishedLaunching (uiApp, options) =
        Xamarin.Forms.Forms.SetFlags([|"Shell_Experimental"; "CollectionView_Experimental"|]);
        (...)

// Android
[<Activity>]
type MainActivity() =
    inherit FormsApplicationActivity()

    override this.OnCreate (bundle: Bundle) =
        base.OnCreate (bundle)
        global.Xamarin.Forms.Forms.SetFlags([|"Shell_Experimental"; "CollectionView_Experimental"|])
        (...)
```

Usage:
```fsharp
View.Shell(title = "TitleShell",
           items = [
               View.ShellItem(
                   items = [
                       View.ShellSection(items = [
                           View.ShellContent(title = "Section 1", content = View.ContentPage(content = View.Button(text = "Button")))         
                       ])
                   ])
           ])

View.CarouselView(itemsSource = [
            View.Label(text="Person1") 
            View.Label(text="Person2")
            View.Label(text="Person3")
            View.Label(text="Person4")
            View.Label(text="Person5")
        ])

View.CollectionView(items=[
            View.Label(text="Person1") 
            View.Label(text="Person2")
            View.Label(text="Person3")
            View.Label(text="Person4")
            View.Label(text="Person5")
        ])
```

See also:

* [Xamarin.Forms 4.0 Preview](https://devblogs.microsoft.com/xamarin/xamarin-forms-4-0-preview/)