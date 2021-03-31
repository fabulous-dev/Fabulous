{% include_relative _header.md %}

{% include_relative contents.md %}

Layouts 
------
##### `topic last updated: v 0.61.0 - 31.03.2021 - 02:29pm,`
<br /> 

Xamarin.Forms has several layouts and features for organizing content on screen.
For a comprehensive guide see the [Xamarin Guide to Layouts](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/)

### Layouts with single content 
<br /> 

| Layout      | Description                                          | Appearance |
|-------------|------------------------------------------------------|------------|
| ContentView | contains a single child                              |            |
| Frame       | displays a border, or frame, around its single child |            |
| ScrollView  | capable of scrolling its contents                    |            |
 
<br /> 

### Layouts with multiple children
<br /> 

| Layout         | Description                                                                           | Appearance |
|----------------|---------------------------------------------------------------------------------------|------------|
| StackLayout    | positions child elements in a stack either horizontally or vertically                 |            |
| Grid           | positions its child elements in a grid of rows and columns                            |            |
| AbsoluteLayout | positions child elements at specific locations relative to its parent                 |            |
| RelativeLayout | positions child elements relative to the RelativeLayout itself or to their siblings   |            |
| FlexLayout     | allows children to be stacked or wrapped with many alignment and orientation options. |            |

<br /> 

[![Xamarin.Forms Layouts](https://user-images.githubusercontent.com/7204669/41666541-aae7b246-74a2-11e8-891a-1c9194632d8b.png "Xamarin.Forms Layouts")](https://user-images.githubusercontent.com/7204669/41666541-aae7b246-74a2-11e8-891a-1c9194632d8b.png)


Examples
------
<br />

### Content View

 A `ContentView` contains a single child element and is typically used to create custom, reusable controls. 

```fsharp 
View.ContentView(
    View.Label("content")
)        
```

See also:

* [Xamarin guide to ContentView](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/ContentView/)
* [Xamarin API docs for `ContentView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.ContentView)

<br /> 

### Frame

A frame contains other content. A simple `Frame` is as follows:

```fsharp 
View.Frame(
        hasShadow = true, 
        backgroundColor = Color.Fuchsia,
        content = View.Label("I'm framed")
    )          
```

<img src="https://user-images.githubusercontent.com/52166903/60180199-5d63c480-9817-11e9-9a64-f306924eb25d.png" width="400">

See also:

* [`Xamarin.Forms.Core.Frame`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Frame)

<br /> 

### ScrollView

ScrollView contains layouts and enables them to scroll offscreen. ScrollView is also used to allow views
to automatically move to the visible portion of the screen when the keyboard is showing.

```fsharp   
View.ScrollView(
    View.StackLayout(children = [
        for i in 1 .. 100 -> View.Label(text = sprintf "item %i" i)
    ])
)        
```
The scroll position can be setted programmatically through the attribute `scrollTo`. This attribute needs the X and Y coordinates to scroll to and an indication whether it should be animated or not. (`Animated`/`NotAnimated`)

Note: Fabulous will try to scroll to these coordinates every time it needs to refresh the UI. Making use of the optional argument is recommended.

You can also subscribe to the event `Scrolled` to be notified when the scrolling is over.

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

<br /> 

### StackLayout

StackLayout organizes views in a one-dimensional line ("stack"), either horizontally or vertically. Views in a StackLayout can be sized based on the space in the layout using layout options. Positioning is determined by the order views were added to the layout and the layout options of the views.

```fsharp 
View.StackLayout(children = [
    View.Label("first label")
    View.Button(text = "first button")
    View.Label("second label")
])        
```

<img src="https://user-images.githubusercontent.com/52166903/60177364-9d737900-9810-11e9-8090-c3de01be59b0.png" width="400">

See also:

* [Xamarin guide to StackLayout](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/stack-layout/)
* [Xamarin API docs for `StackLayout`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.StackLayout)

<br /> 

### Grid

Grid supports arranging views into rows and columns. Rows and columns can be set to have proportional sizes or absolute sizes. The Grid layout should not be confused with traditional tables and is not intended to present tabular data. Grid does not have the concept of row, column or cell formatting. Unlike HTML tables, Grid is purely intended for laying out content.

An example `Grid` is as follows:

```fsharp 
        View.ContentPage(
            View.Grid(
                rowdefs = [
                    Dimension.Auto              // first row = .Row(0)
                    Dimension.Absolute 150.     // second row = .Row(1)
                    Dimension.Auto              // third row = .Row(2)
                    Dimension.Star              // fourth row = .Row(3)
                ],
                coldefs = [
                    Dimension.Absolute 200.     // first column = .Column(0)
                    Dimension.Star              // second column = .Column(1)
                ],
                children = [
                    View.Label(text = "first row", backgroundColor = Color.Red).Row(0)                    
                    View.Label(text = "second row", backgroundColor = Color.Blue).Row(1)
                    View.Label(text = "first column", backgroundColor = Color.Yellow).Row(2).Column(0)
                    View.Label(text = "second column", backgroundColor = Color.Green).Row(2).Column(1)
                    View.Label(text = "column spanning", backgroundColor = Color.Orange).Row(3).ColumnSpan(2)
                ]
            )
        )
```

<img src="https://user-images.githubusercontent.com/52166903/60177360-9cdae280-9810-11e9-98fd-fda569cd8836.png" width="400">

See also:

* [`Xamarin.Forms.Core.Grid`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Grid)

<br /> 

### AbsoluteLayout

AbsoluteLayout positions and sizes child elements proportional to its own size and position or by absolute values.
Child views may be positioned and sized using proportional values or static values, and proportional and static values can be mixed.

```fsharp 
        View.ContentPage(
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
        )
```

<img src="https://user-images.githubusercontent.com/52166903/60177353-9c424c00-9810-11e9-80ab-f5725c970143.png" width="400">

See also:

* [Xamarin guide to AbsoluteLayout](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/absolute-layout/)
* [Xamarin API docs for `AbsoluteLayout`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.AbsoluteLayout)

<br /> 

### RelativeLayout

RelativeLayout is used to position and size views relative to properties of the layout or sibling views. Unlike AbsoluteLayout, RelativeLayout does not have the concept of the moving anchor and does not have facilities for positioning elements relative to the bottom or right edges of the layout. RelativeLayout does support positioning elements outside of its own bounds.

An example `RelativeLayout` is as follows:

```fsharp 
        View.ContentPage(
            View.RelativeLayout(
                children =
                    [ View.Label(text = "RelativeLayout Example", textColor = Color.Red)
                          .XConstraint(Constraint.RelativeToParent(fun parent -> 0.0))
                      View.Label(text = "Positioned relative to my parent", textColor = Color.Red)
                          .XConstraint(Constraint.RelativeToParent(fun parent -> parent.Width / 3.0))
                          .YConstraint(Constraint.RelativeToParent(fun parent -> parent.Height / 2.0))
                    ]
            )
        )
```

See also:

* [Xamarin guide to RelativeLayout](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/relative-layout/)
* [Xamarin API docs for `RelativeLayout`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.RelativeLayout)

<br /> 

### FlexLayout

FlexLayout is similar to the Xamarin.Forms StackLayout in that it can arrange its children horizontally and vertically in a stack. However, the FlexLayout is also capable of wrapping its children if there are too many to fit in a single row or column, and also has many options for orientation, alignment, and adapting to various screen sizes.


```fsharp 
        View.ContentPage(
            View.FlexLayout(
                direction=FlexDirection.Column,
                children = [
                    View.Label(text = "Seated Monkey", fontSize = FontSize.fromNamedSize NamedSize.Large, textColor=Color.Blue)
                    View.Label(text = "This monkey is laid back and relaxed.")
                    View.Label(text = "  - Often smiles mysteriously")
                    View.Label(text = "  - Sleeps sitting up")

                    View.Image(
                        source = Image.ImagePath "images/160px-Vervet_monkey_Krugersdorp_game_reserve_%285657678441%29.jpg"
                    ).Order(-1).AlignSelf(FlexAlignSelf.Center)        
        
                    View.Label(margin = Thickness(0.0, 4.0)).Grow(1.0)
                    View.Button(text = "Learn More", fontSize = FontSize.fromNamedSize NamedSize.Large, cornerRadius = 20)
                ]
            )
        )
```
<img src="https://user-images.githubusercontent.com/52166903/60180202-5dfc5b00-9817-11e9-974d-091a32fbda3f.png" width="400">

See also:

* [Xamarin guide to FlexLayout](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/flex-layout/)
* [Xamarin API docs for `FlexLayout`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.FlexLayout)
