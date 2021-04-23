{% include_relative _header.md %}

{% include_relative contents.md %}

FlyoutPage
--------
##### `topic last updated: v1.0 - 02.04.2021 - 11:47pm`

<br /> 

### Basic example

```fsharp 
flyout = View.ContentPage
    (   title ="flyoutPage",    
        content = 
            View.StackLayout( children = [
                View.ListViewGrouped(
                    items = [ 
                        "Introduction Pages", View.TextCell("Introduction Pages"), introductionPages
                        "Sample Pages", View.TextCell("Sample Pages"), samplePages
                        "Sample Layouts", View.TextCell("Sample Layouts"), sampleLayouts 
                        "Sample Displays", View.TextCell("Sample Displays"), sampleDisplays
                    ], 
                    itemSelected = (fun idx -> dispatch (ListViewSelectedItemChanged idx.Value))
                )
            ])
    ), 
detail = View.NavigationPage
    (   title = "details",         
        pages = [ activePage model.SelectedPage ] 
    )
```
<img src="images/pages/flyout-adr-basic.png" width="300">
<br /> <br /> 


See also:

* [`Xamarin.Forms.FlyoutPage`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.FlyoutPage)