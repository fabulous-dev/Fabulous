Elmish.XamarinForms Guide - Views
=======

The `view` function is written using an F# DSL.
View functions excel in cases where the existence, characteristics and layout of the view depends on information
in the model. Differential update is used to efficiently update the Xamarin.Forms display based on the previous
and current view descriptions.

### Views: ContentPage

A single page app typically returns a `ContentPage`:

```fsharp
let view model dispatch =
    Xaml.ContentPage(
        title="Pocket Piggy Bank",
        content= Xaml.Label(text = sprintf "Hello world!")
    )
```

See also: 
* [`Xamarin.Forms.Core.ContentPage`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.ContentPage).

### Views: StackLayout

A stack layout is a vertically-stacked sequence of content:

```fsharp
let view model dispatch =
    Xaml.ContentPage(
        title="Pocket Piggy Bank",
        content=Xaml.StackLayout(padding=20.0,
            children = [
                Xaml.Label(text = sprintf "Welcome to the bank!")
                Xaml.Label(text = sprintf "Balance: %s%.2f" model.CurrencySymbol model.Balance)
            ]))
```

See also:
* [`Xamarin.Forms.Core.StackLayout`](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/stack-layout/).



### Views:  Button

Buttons are created using `Xaml.Button`. The `command` of a button will normally dispatch a messsage.  For example:

```fsharp
    Xaml.Button(text="Deposit", command=(fun () -> dispatch (Add 10.0)))
```

Here is a larger example:

```fsharp
type Model =
    { Balance : decimal
      CurrencySymbol : string
      User: string option }

type Msg =
    | Spend of decimal
    | Add of decimal
    | Login of string option

let update msg model =
    match msg with
    | Spend x -> {model with Balance = model.Balance - x}, Cmd.none
    | Add x -> {model with Balance = model.Balance + x}, Cmd.none
    | Login user -> { model with User = user }, Cmd.none

let view model dispatch =
    Xaml.ContentPage(
        title="Pocket Piggy Bank",
        content=Xaml.StackLayout(padding=20.0,
            horizontalOptions=LayoutOptions.Center,
            verticalOptions=LayoutOptions.CenterAndExpand,
            children = [
                match model.User with
                | Some user ->
                    yield Xaml.Label(text=sprintf "Logged in as : %s" user)
                    yield Xaml.Label(text=sprintf "Balance: %s%.2f" model.CurrencySymbol model.Balance)
                    yield Xaml.Button(text="Withdraw", command=(fun () -> dispatch (Spend 10.0m)), canExecute=(model.Balance > 0.0m))
                    yield Xaml.Button(text="Deposit", command=(fun () -> dispatch (Add 10.0m)))
                    yield Xaml.Button(text="Logout", command=(fun () -> dispatch (Login None)))
                | None ->
                    yield Xaml.Button(text="Login", command=(fun () -> dispatch (Login (Some "user"))))
            ]))
```

See also:
* [`Xamarin.Forms.Core.Button`](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/button/).


### Views: ListView, ListGroupedView

A simple `ListView` is as follows:
```fsharp
    Xaml.ListView(items = [ Xaml.Label "Ionide"
                            Xaml.Label "Visual Studio"
                            Xaml.Label "Emacs"
                            Xaml.Label "Visual Studio Code"
                            Xaml.Label "JetBrains Rider"], 
                  itemSelected=(fun idx -> dispatch (ListViewSelectedItemChanged idx)))
```

In the underlying implementation, each visual item is placed in a `ContentCell`.
Currently the `itemSelected` callback uses integers indexes for keys to identify the elements (NOTE: this may change in future updates).

There is also a `ListViewGrouped` for grouped items of data.  This uses the same Xamarin control under the hood but in a different mode of use.

See also:
* [`Xamarin.Forms.Core.ListView`](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/listview/).


#### Views: "Infinite" or "unbounded" ListViews 

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
    Xaml.ListView(items = [ for i in 1 .. model.LatestItemAvailable do 
                              yield Xaml.Label("Item " + string i) ], 
                  itemAppearing=(fun idx -> if idx >= max - 2 then dispatch (GetMoreItems (idx + 10) ) )  )
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
                              yield dependsOn i (fun model i -> Xaml.Label("Item " + string i)) ]
```
With that, this simple list views scale to > 10,000 items on a modern phone, though your mileage may vary.
There are many other techniques (e.g. save the latest collection of visual element descriptions in the model, or to use a `ConditionalWeakTable` to associate it with the latest model).  We will document further techniques in due course. 

Thre is also an `itemDisappearing` event for `ListView` that can be used to discard data from the underlying model and restrict the
range of visual items that need to be generated.

### Views: Other Controls

All other controls from `Xamarin.Forms.Core` are available in the programming model.  See the `AllControls` sample.

See also
* [`Xamarin.Forms` API docs](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms).



### Views: Performance Hints

Dynamic views are only efficient for large UIs if the unchanging parts of a UI are "memoized", returning identical
objects on each invocation of the `view` function.  This must be done explicitly, currently using `dependsOn`. Here is an example for a 6x6 Grid that depends on nothing, i.e. never changes:
```fsharp
let view model dispatch =
    ...
    dependsOn () (fun model () -> 
        Xaml.StackLayout(
          children=
            [ Xaml.Label(text=sprintf "Grid (6x6, auto):")
              Xaml.Grid(rowdefs= [for i in 1 .. 6 -> box "auto"],
                        coldefs=[for i in 1 .. 6 -> box "auto"], 
                        children = [ for i in 1 .. 6 do for j in 1 .. 6 -> 
                                       Xaml.BoxView(Color((1.0/float i), (1.0/float j), (1.0/float (i+j)), 1.0) )
                                              .GridRow(i-1).GridColumn(j-1) ] )
            ])
```
Inside the function - the one passed to `dependsOn` - the `model` is rebound to be inaccessbile with a `DoNotUseMe` type so you can't use it. Here is an example where some of the model is extracted:
```fsharp
let view model dispatch =
    ...
    dependsOn (model.CountForSlider, model.StepForSlider) (fun model (count, step) -> 
        Xaml.Slider(minimum=0.0, maximum=10.0, value= double step, 
                    valueChanged=(fun args -> dispatch (SliderValueChanged (int (args.NewValue + 0.5)))), 
                    horizontalOptions=LayoutOptions.Fill)) 
    ...
```
In the example, we extract properties `CountForSlider` and `StepForSlider` from the model, and bind them to `count` and `step`.  If either of these change, the section of the view will be recomputed and no adjustments will be made to the UI.
If not, this section of the view will be reused. This helps ensure that this part of the view description only depends on the parts of the model extracted.

You can also use 
* the `fix` function for portions of a view that have no dependencies at all (besides the "dispatch" function)
* the `fixf` function for command callbacks that have no dependencies at all (besides the "dispatch" function)

### Views: Resource Dictionaries

In Elmish.XamarinForms, resources dictionaries are just "simple F# programming", e.g.
```fsharp
let horzOptions = LayoutOptions.Center
let vertOptions = LayoutOptions.CenterAndExpand
```
is basically the eqivalent of Xaml:
```xml
<ContentPage.Resources>
    <ResourceDictionary>
        <LayoutOptions x:Key="horzOptions"
                     Alignment="Center" />

        <LayoutOptions x:Key="vertOptions"
                     Alignment="Center"
                     Expands="True" />
    </ResourceDictionary>
</ContentPage.Resources>
```
In other words, you can normally forget about resource dictionaries and just program as you would normally in F#.

Other kinds of resources like images need a little more attention and you may need to ship multiple versions of images etc. for Android and iOS.  TBD: write a guide on these, in the meantime see the samples.


### Views: Differential Update of Lists of Things

There are a few different kinds of list in view descriptions:
1. lists of raw data (e.g. data for a chart control, though there are no samples like that yet in this library)
2. long lists of UI elements that are used to produce cells (e.g. `ListView`, see above)
3. short lists of UI elements (e.g. StackLayout `children`)
4. short lists of pages (e.g. NavigationPages `pages`)

The perf of incremental update to these is progressively less important as you go down that list above.  

For all of the above, the typical, naive implementation of the `view` function returns a new list
instance on each invocation. The incremental update of dynamic views maintains a corresponding mutable target
(e.g. the `Children` property of a `Xamarin.Forms.StackLayout`, or an `ObservableCollection` to use as an `ItemsSource` to a `ListView`) based on the previous (PREV) list and the new (NEW) list.  The list diffing currently does the following:
1. trims of excess elements from TARGET down to size LIM = min(NEW.Count, PREV.Count)
2. incrementally updates existing elements 0..MIN-1 in TARGET (skips this if PREV.[i] is reference-equal to NEW.[i])
3. creates elements LIM..NEW.Count-1

This means
1. Incremental update costs minimally one transition of the whole list.
2. Incremental update recycles visual elements at the start of the list and handles add/remove at end of list relatively efficiently
3. Returning a new list that inserts an element at the beginning will recreate all elements down the way.

Basically, incremental update is faster if items are being added/removed at the end, rather than the beginning of the list. 

The above is sufficient for many purposes, but care must always be taken with large lists and data sources, see `ListView` above for example.  Care must also be taken whenever data updates very rapidly.


