Fabulous for Xamarin.Forms - Guide
=======

{% include_relative contents-views.md %}

Pages
------

### ContentPage

A single page app typically returns a `ContentPage`. For example:

```fsharp
let view model dispatch =
    View.ContentPage(
        title = "Pocket Piggy Bank",
        content = View.Label(text = sprintf "Hello world!")
    )
```

For other kinds of pages, see [Multi-page Applications and Navigation](views-navigation.md)

See also:

* [`Xamarin.Forms.Core.ContentPage`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.ContentPage)

Layouts
-------------------

Xamarin.Forms has several layouts and features for organizing content on screen.
For a comprehensive guide see the [Xamarin Guide to Layouts](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/)

[![Xamarin.Forms Layouts](https://user-images.githubusercontent.com/7204669/41666541-aae7b246-74a2-11e8-891a-1c9194632d8b.png "Xamarin.Forms Layouts")](https://user-images.githubusercontent.com/7204669/41666541-aae7b246-74a2-11e8-891a-1c9194632d8b.png)

### StackLayout

StackLayout organizes views in a one-dimensional line ("stack"), either horizontally or vertically. Views in a StackLayout can be sized based on the space in the layout using layout options. Positioning is determined by the order views were added to the layout and the layout options of the views.

```fsharp
View.StackLayout(
    padding=20.0,
    children = [
        View.Label(text = sprintf "Welcome to the bank!")
        View.Label(text = sprintf "Balance: %s%.2f" model.CurrencySymbol model.Balance)
    ]
)
```

<img src="https://user-images.githubusercontent.com/52166903/60177364-9d737900-9810-11e9-8090-c3de01be59b0.png" width="400">

See also:

* [Xamarin guide to StackLayout](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/stack-layout/)
* [Xamarin API docs for `StackLayout`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.StackLayout)

### AbsoluteLayout

AbsoluteLayout positions and sizes child elements proportional to its own size and position or by absolute values.
Child views may be positioned and sized using proportional values or static values, and proportional and static values can be mixed.

```fsharp
View.AbsoluteLayout(
    backgroundColor = Color.Blue.WithLuminosity(0.9),
    children = [
       View.Label(text = "Top Left", textColor = Color.Black)
           .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
           .LayoutBounds(Rectangle(0.0, 0.0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize))
       View.Label(text = "Centered", textColor = Color.Black)
           .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
           .LayoutBounds(Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize))
       View.Label(text = "Bottom Right", textColor = Color.Black)
           .LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
           .LayoutBounds(Rectangle(1.0, 1.0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize))
    ]
)
```

<img src="https://user-images.githubusercontent.com/52166903/60177353-9c424c00-9810-11e9-80ab-f5725c970143.png" width="400">

See also:

* [Xamarin guide to AbsoluteLayout](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/absolute-layout/)
* [Xamarin API docs for `AbsoluteLayout`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.AbsoluteLayout)

### RelativeLayout

RelativeLayout is used to position and size views relative to properties of the layout or sibling views. Unlike AbsoluteLayout, RelativeLayout does not have the concept of the moving anchor and does not have facilities for positioning elements relative to the bottom or right edges of the layout. RelativeLayout does support positioning elements outside of its own bounds.

An example `RelativeLayout` is as follows:

```fsharp
View.RelativeLayout(
    children =
        [ View.Label(text = "RelativeLayout Example", textColor = Color.Red)
              .XConstraint(Constraint.RelativeToParent(fun parent -> 0.0))
          View.Label(text = "Positioned relative to my parent", textColor = Color.Red)
              .XConstraint(Constraint.RelativeToParent(fun parent -> parent.Width / 3.0))
              .YConstraint(Constraint.RelativeToParent(fun parent -> parent.Height / 2.0))
        ]
)
```

See also:

* [Xamarin guide to RelativeLayout](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/relative-layout/)
* [Xamarin API docs for `RelativeLayout`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.RelativeLayout)

### FlexLayout

FlexLayout is similar to the Xamarin.Forms StackLayout in that it can arrange its children horizontally and vertically in a stack. However, the FlexLayout is also capable of wrapping its children if there are too many to fit in a single row or column, and also has many options for orientation, alignment, and adapting to various screen sizes.

```fsharp
View.FlexLayout(
    direction=FlexDirection.Column,
    children = [
        View.Label(text = "Seated Monkey", fontSize="Large", textColor=Color.Blue)
        View.Label(text = "This monkey is laid back and relaxed.")
        View.Label(text = "  - Often smiles mysteriously")
        View.Label(text = "  - Sleeps sitting up")

        View.Image(widthRequest = 160.0, heightRequest = 240.0,
            source = "images/160px-Vervet_monkey_Krugersdorp_game_reserve_%285657678441%29.jpg"
        ).FlexOrder(-1).FlexAlignSelf(FlexAlignSelf.Center)

        View.Label(margin = Thickness(0.0, 4.0)).FlexGrow(1.0)
        View.Button(text = "Learn More", fontSize = "Large", cornerRadius = 20)
    ]
)
```

<img src="https://user-images.githubusercontent.com/52166903/60180202-5dfc5b00-9817-11e9-974d-091a32fbda3f.png" width="400">

See also:

* [Xamarin guide to FlexLayout](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/flex-layout/)
* [Xamarin API docs for `FlexLayout`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.FlexLayout)

### Grid

Grid supports arranging views into rows and columns. Rows and columns can be set to have proportional sizes or absolute sizes. The Grid layout should not be confused with traditional tables and is not intended to present tabular data. Grid does not have the concept of row, column or cell formatting. Unlike HTML tables, Grid is purely intended for laying out content.

An example `Grid` is as follows:

```fsharp
View.Grid(
    rowdefs = [for i in 1 .. 6 -> box "auto"],
    coldefs = [for i in 1 .. 6 -> box "auto"],
    children = [
        for i in 1 .. 6 do
            for j in 1 .. 6 ->
                let color = Color((1.0/float i), (1.0/float j), (1.0/float (i+j)), 1.0)
                View.BoxView(color).GridRow(i-1).GridColumn(j-1)
    ]
)
```

Notes:

* Row and column definitions can use `"*"`, `N*` where `N` is a number, `"auto"` or a thickness
* Fluent methods `.GridRow(..)` and `.GridColumn(..)` are used to place the items in locations on the grid.

<img src="https://user-images.githubusercontent.com/52166903/60177360-9cdae280-9810-11e9-98fd-fda569cd8836.png" width="400">

See also:

* [`Xamarin.Forms.Core.Grid`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Grid)

### ScrollView

ScrollView contains layouts and enables them to scroll offscreen. ScrollView is also used to allow views
to automatically move to the visible portion of the screen when the keyboard is showing.

```fsharp
View.ScrollView(View.StackLayout(padding=20.0, children= ...) )
```

The scroll position can be setted programmatically through the attribute `scrollTo`. This attribute needs the X and Y coordinates to scroll to and an indication whether it should be animated or not. (`Animated`/`NotAnimated`)

Note: Fabulous will try to scroll to these coordinates every time it needs to refresh the UI. Making use of the optional argument is recommended.

You can also subscribe to the event `Scrolled` to be notified when the scrolling is over.

```fsharp
View.ScrollView(content=(...),
    ?scrollTo=(if model.ShouldScroll then Some (500.0, 0.0, Animated) else None),
    scrolled=(fun args -> dispatch Scrolled))
```

For more complex scenarios, you can directly use the method from Xamarin.Forms [`ScrollView.ScrollToAsync(x, y, animated)`](https://docs.microsoft.com/dotnet/api/xamarin.forms.scrollview.scrolltoasync?view=xamarin-forms)
This method offers the advantage of being awaitable until the end of the scrolling.
To do this, a reference to the underlying ScrollView is needed.


```fsharp
let scrollViewRef = ViewRef<ScrollView>()

View.ScrollView(ref=scrollViewRef, content=(...))

// Some time later (usually in a Cmd)
let scrollToCoordinates x y animated =
    async {
        match scrollViewRef.TryValue with
        | None ->
            return None
        | Some scrollView ->
            do! scrollView.ScrollToAsync(x, y, animated) |> Async.AwaitTask
            return (Some Scrolled)
    } |> Cmd.ofAsyncMsgOption
```

<img src="https://user-images.githubusercontent.com/52166903/60177362-9d737900-9810-11e9-9529-81640e681186.png" width="400">

See also:

* [Xamarin guide to ScrollView](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/scroll-view)
* [`Xamarin.Forms.Core.ScrollView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.ScrollView)

### CarouselView, Shell

`CarouselView` and `Shell` are available in Xamarin.Forms 4.0. 

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

```

See also:

* [Xamarin.Forms 4.0 Preview](https://devblogs.microsoft.com/xamarin/xamarin-forms-4-0-preview/)