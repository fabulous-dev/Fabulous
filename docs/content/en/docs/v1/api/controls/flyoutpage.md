---
id: "v1-flyoutpage"
title : "FlyoutPage"
description: ""
lead: ""
date: 2022-03-31T00:00:00+00:00
lastmod: 2022-03-31T00:00:00+00:00
draft: false
images: []
menu:
    docs:
        parent: "controls"
toc: true
---

## Basic example

```fs
View.FlyoutPage(
    flyout =
        View.ContentPage(
            title ="flyoutPage",
            content =
                View.StackLayout([
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
    detail =
        View.NavigationPage(
            title = "details",
            pages = [ activePage model.SelectedPage ]
        )
)
```

See also:

* [`Xamarin.Forms.FlyoutPage`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.FlyoutPage)
