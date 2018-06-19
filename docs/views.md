Views
=======

The `view` function is a function returning your view elements based on the current model. For example:

```fsharp
let view model dispatch =
    Xaml.ContentPage(
        title="Pocket Piggy Bank",
        content= Xaml.Label(text = sprintf "Hello world!")
    )
```

The view function is normal F# code that returns elements expressed using the `Xaml.*` F# DSL.

View functions excel in cases where the existence, characteristics and layout of the view depends on information
in the model. Differential update is used to efficiently update the Xamarin.Forms display based on the previous
and current view descriptions.

### Views: ContentPage

A single page app typically returns a `ContentPage`. For example:

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


