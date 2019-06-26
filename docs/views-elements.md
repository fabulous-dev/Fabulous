Fabulous - Guide
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

Lists and Tables
-------------------

### ListView, ListGroupedView

A simple `ListView` is as follows:

```fsharp
View.ListView(
    items = [ View.Label "Ionide"
              View.Label "Visual Studio"
              View.Label "Emacs"
              View.Label "Visual Studio Code"
              View.Label "JetBrains Rider"],
    itemSelected=(fun idx -> dispatch (ListViewSelectedItemChanged idx)))
```

In the underlying implementation, each visual item is placed in a `ContentCell`.
Currently the `itemSelected` callback uses integers indexes for keys to identify the elements (NOTE: this may change in future updates).

There is also a `ListViewGrouped` for grouped items of data.  This uses the same Xamarin control under the hood but in a different mode of use.

<img src="https://user-images.githubusercontent.com/52166903/60180201-5dfc5b00-9817-11e9-9508-a0daa7b7a81d.png" width="400">

See also:

* [`Xamarin.Forms.Core.ListView`](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/listview/)

### TableView

An example `TableView` is as follows:

```fsharp
View.TableView(
    items = [
        ("Videos", [ View.SwitchCell(on=true, text="Luca 2008", onChanged=(fun args -> ()) )
                     View.SwitchCell(on=true, text="Don 2010", onChanged=(fun args -> ()) ) ] )
        ("Books", [ View.SwitchCell(on=true, text="Expert F#", onChanged=(fun args -> ()) )
                    View.SwitchCell(on=false, text="Programming F#", onChanged=(fun args -> ()) ) ])
        ("Contact", [ View.EntryCell(label="Email", placeholder="foo@bar.com", completed=(fun args -> ()) )
                      View.EntryCell(label="Phone", placeholder="+44 87654321", completed=(fun args -> ()) )] )])
```

<img src="https://user-images.githubusercontent.com/52166903/60177365-9d737900-9810-11e9-92d5-88487316bbf6.png" width="400">

See also:

* [`Xamarin.Forms.Core.TableView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.TableView)

#### "Infinite" or "unbounded" ListViews

"Infinite" (really "unbounded") lists are created by using the `itemAppearing` event to prompt a message which nudges the
underlying model in a direction that will then supply new items to the view.

For example, consider this pattern:

```fsharp
type Model =
    { ...
      LatestItemAvailable: int
    }

type Message =
    ...
    | GetMoreItems of int

let update msg model =
    match msg with
    | ...
    | GetMoreItems n -> { model with LatestItemAvailable = n }

let view model dispatch =
    ...
    View.ListView(
        items = [ for i in 1 .. model.LatestItemAvailable do
                     yield View.Label("Item " + string i) ],
        itemAppearing = (fun idx -> if idx >= max - 2 then dispatch (GetMoreItems (idx + 10) ) )  )
...
```

Note:

* The underlying data in the model is just an integer `LatestItemAvailable` (normally it would really be a list of actual entities drawn from a data source)
* On each update to the view we produce all the visual items from `Item 1` onwards
* The `itemAppearing` event is called for each item, e.g. when item `10` appears
* When the event triggers we grow the underlying data model by 10
* This will trigger an update of the view again, with more visual elements available (but not yet appearing)

Surprisingly even this naive technique  is fairly efficient. There are numerous ways to make this more efficient (we aim to document more of these over time too).  One simple one is to memoize each individual visual item using `dependsOn`:

```fsharp
        items = [ for i in 1 .. model.LatestItemAvailable do
                    yield dependsOn i (fun model i -> View.Label("Item " + string i)) ]
```

With that, this simple list views scale to > 10,000 items on a modern phone, though your mileage may vary.
There are many other techniques (e.g. save the latest collection of visual element descriptions in the model, or to use a `ConditionalWeakTable` to associate it with the latest model).  We will document further techniques in due course.

Thre is also an `itemDisappearing` event for `ListView` that can be used to discard data from the underlying model and restrict the
range of visual items that need to be generated.

Other Core Elements
-------------------

All other controls from `Xamarin.Forms.Core` are available in the programming model.  See the `AllControls` sample if
the control is not documented here.

### Button

Buttons are created using `View.Button`. The `command` of a button will normally dispatch a messsage.  For example:

```fsharp
View.Button(text = "Deposit", command = (fun () -> dispatch (Add 10.0)))
```

<img src="https://user-images.githubusercontent.com/52166903/60180200-5dfc5b00-9817-11e9-87d1-e3d254b1cf2b.png" width="400">

See also:

* [Xamarin guide to Button](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/button)
* [`Xamarin.Forms.Core.Button`](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/button/)

### Slider

A simple `Slider` is as follows:

```fsharp
View.Slider(
    minimum = 0.0,
    maximum = 10.0,
    value= double step,
    valueChanged=(fun args -> dispatch (SliderValueChanged (int (args.NewValue + 0.5))))
)
```

<img src="https://user-images.githubusercontent.com/52166903/60177363-9d737900-9810-11e9-8842-aeb904e7d739.png" width="400">

See also:

* [Xamarin guide to Slider](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/slider)
* [`Xamarin.Forms.Core.Slider`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Slider)

### ActivityIndicator

A simple `ActivityIndicator` is as follows:

```fsharp
View.ActivityIndicator(isRunning = (count > 0))
```

<img src="https://user-images.githubusercontent.com/52166903/60177355-9c424c00-9810-11e9-8275-bd8c2ebcf3c8.png" width="400">

See also:

* [`Xamarin.Forms.Core.ActivityIndicator`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.ActivityIndicator)

### DatePicker

A simple `DatePicker` is as follows:

```fsharp
View.DatePicker(minimumDate = DateTime.Today,
    maximumDate = DateTime.Today + TimeSpan.FromDays(365.0),
    date = startDate,
    dateSelected=(fun args -> dispatch (StartDateSelected args.NewDate)))
```

<img src="https://user-images.githubusercontent.com/52166903/60177357-9cdae280-9810-11e9-9979-1e91cf8c5ea6.png" width="400">

See also:

* [Xamarin guide to DatePicker](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/datepicker)
* [`Xamarin.Forms.Core.DatePicker`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.DatePicker)

### Editor

An example `Editor` is as follows:

```fsharp
View.Editor(text = editorText,
    textChanged = (fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
    completed = (fun text -> dispatch (EditorEditCompleted text)))
```

<img src="https://user-images.githubusercontent.com/52166903/60175558-d2c99800-980b-11e9-9755-860cc9a60dcf.png" width="400">

See also:

* [`Xamarin.Forms.Core.Editor`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Editor)

### BoxView

An example `BoxView` is as follows:

```fsharp
View.BoxView(Color.Fuchsia)
```

<img src="https://user-images.githubusercontent.com/52166903/60177356-9cdae280-9810-11e9-9478-165b9da84745.png" width="400">

See also:

* [`Xamarin.Forms.Core.BoxView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.BoxView)

### Entry

An example `Entry` is as follows:

```fsharp
View.Entry(
    text = entryText,
    textChanged = (fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
    completed = (fun text -> dispatch (EntryEditCompleted text))
)
```

An example `Entry` with password is as follows:

```fsharp
View.Entry(
    text = password,
    isPassword = true,
    textChanged = (fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
    completed = (fun text -> dispatch (EntryEditCompleted text))
)
```

An example `Entry` with a placeholder is as follows:

```fsharp
View.Entry(
    placeholder = "Enter text",
    textChanged = (fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
    completed = (fun text -> dispatch (EntryEditCompleted text))
)
```

<img src="https://user-images.githubusercontent.com/52166903/60177359-9cdae280-9810-11e9-9d80-059a9a885b72.png" width="400">

See also:

* [`Xamarin.Forms.Core.Entry`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Entry)

### Frame

A frame contains other content. A simple `Frame` is as follows:

```fsharp
View.Frame(hasShadow = true, backgroundColor = Colors.Fuchsia)
```

<img src="https://user-images.githubusercontent.com/52166903/60180199-5d63c480-9817-11e9-9a64-f306924eb25d.png" width="400">

See also:

* [`Xamarin.Forms.Core.Frame`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Frame)

### Image

A simple image drawn from a resource or URL is as follows:

```fsharp
let monkey = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"

View.Image(source = monkey)
```

<img src="https://user-images.githubusercontent.com/52166903/60180198-5d63c480-9817-11e9-9458-379a848ccca4.png" width="400">

See also:

* [Images in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/images?tabs=vswin)
* [`Xamarin.Forms.Core.Image`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Image)

### Picker

A simple `Picker` is as follows:

```fsharp
let pickerItems =
    [| ("Aqua", Color.Aqua); ("Black", Color.Black);
       ("Blue", Color.Blue); ("Fucshia", Color.Fuchsia);
       ("Gray", Color.Gray); ("Green", Color.Green);
       ("Lime", Color.Lime); ("Maroon", Color.Maroon);
       ("Navy", Color.Navy); ("Olive", Color.Olive);
       ("Purple", Color.Purple); ("Red", Color.Red);
       ("Silver", Color.Silver); ("Teal", Color.Teal);
       ("White", Color.White); ("Yellow", Color.Yellow ) |]

View.Picker(
    title = "Choose Color:",
    textColor = snd pickerItems.[pickedColorIndex],
    selectedIndex = pickedColorIndex,
    itemsSource = Array.map fst pickerItems,
    selectedIndexChanged = (fun (i, item) -> dispatch (PickerItemChanged i))
)
```

<img src="https://user-images.githubusercontent.com/52166903/60177361-9d737900-9810-11e9-87a2-ade4880f7222.png" width="400">

See also:

* [`Xamarin.Forms.Core.Picker`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.Picker)

### SearchBar

A simple `SearchBar` is as follows:

```fsharp
View.SearchBar(
    placeholder = "Enter search term",
    searchCommand = (fun searchBarText -> dispatch  (ExecuteSearch searchBarText)),
    canExecute=true)
```

<img src="https://user-images.githubusercontent.com/52166903/60180196-5d63c480-9817-11e9-9c21-e8b19dee8474.png" width="400">

See also:

* [Xamarin.Forms.Core.SearchBar](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.searchbar?view=xamarin-forms)


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


Pop-ups
-------------------

Pop-ups are a special case in Fabulous: they are part of the view, but don't follow the same lifecycle as the rest of the UI. In Xamarin.Forms pop-ups are exposed through 2 methods of the current page: `DisplayAlert` and `DisplayActionSheet`.

In Fabulous we only describe what a page should look like and have no access to UI elements. As such, there is no direct implementation of those 2 methods in Fabulous but instead we can use the static property `Application.Current.MainPage` exposed by Xamarin.Forms.

Here is an example of the use of a confirmation pop-up - note the requirement of `Cmd.AsyncMsg` so as not to block on the UI thread:
```fsharp
type Msg =
    | DisplayAlert
    | AlertResult of bool

let update (msg : Msg) (model : Model) =
    match msg with
    | DisplayAlert ->
        let alertResult = async {
            let! alert =
                Application.Current.MainPage.DisplayAlert("Display Alert", "Confirm", "Ok", "Cancel")
                |> Async.AwaitTask
            return AlertResult alert }

        model, Cmd.ofAsyncMsg alertResult

    | AlertResult alertResult -> ... // Do something with the result
```

<img src="https://user-images.githubusercontent.com/52166903/60180195-5d63c480-9817-11e9-9c12-bab34b7fbb77.png" width="400">

_Why don't we add a Fabulous wrapper for those?_
Doing so would only end up duplicating the existing methods and compel us to maintain these in sync with Xamarin.Forms.
See [Pull Request #147](https://github.com/fsprojects/Fabulous/pull/147) for more information

See also:

* [Displaying Pop-ups](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/navigation/pop-ups)
* [`Xamarin.Forms.Core.Page.DisplayAlert`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.page.displayalert)
* [`Xamarin.Forms.Core.Page.DisplayActionSheet`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.page.displayactionsheet)
