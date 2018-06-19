Elmish.XamarinForms Guide
=======


Structure of an App
------

Here is the typical structure for an app:
```fsharp
type Msg =
    | ...
    

/// The model from which the view is generated
type Model = 
    { ... }

/// Returns the initial state
let init() = { ... }
    
/// The funtion to update the view
let update (msg:Msg) (model:Model) = ...

/// The view function giving updated content for the page
let view (model: Model) dispatch = ...

type App () = 
    inherit Application ()

    let runner = 
        Program.mkSimple init update view
        |> Program.withConsoleTrace
        |> Program.withDynamicView
        |> Program.run
```

### The Model

The model is the core data from which the whole state of the app can be resurrected.  Consider the model to be "the information
I would need on restart to get the app back to the same visual state".

The model is generally immutable but may also contain service connections.

Some advantages of using an immutable model are:

* It is easy to unit test your `init`, `update` and `view` functions
* You can save/restore your model relatively easily
* It makes tracing causality usually very simple

### The `init` function

The `init` function returns your initial state.

### Messages and the `update` function

Each model gets an `update` function for message processing. The messages are either messages from the `view` or from external events.

### The `view` function

The `view` function computes an immutable Xaml-like description. In the above example, the choice between a label and button depends on the `model.Pressed` value.


Dynamic Views
------------

Dynamic `view` functions are written using an F# DSL, see ``Elmish.XamarinForms.DynamicViews``.
Dynamic Views excel in cases where the existence, characteristics and layout of the view depends on information in the model. React-style differential update is used to update the Xamarin.Forms display based on the previous and current view descriptions.

The F# DSL is [generated](https://github.com/fsprojects/Elmish.XamarinForms/tree/master/Elmish.XamarinForms/Xamarin.Forms.Core.fs) from a [declarative model](https://github.com/fsprojects/Elmish.XamarinForms/blob/master/Generator/bindings.json) using a [code generator](https://github.com/fsprojects/Elmish.XamarinForms/tree/master/Generator) adapted from [@praeclarum](https://github.com/praeclarum)'s [ImmutableUI generator](https://github.com/praeclarum/ImmutableUI).
* There is only one UI element type (XamlElement, an immutable property bag).
* Safe creation is done through helpers such as [`Xaml.Button(...)`](https://github.com/fsprojects/Elmish.XamarinForms/tree/master/Elmish.XamarinForms/DynamicXaml.fs#L1248).

### Dynamic Views: ContentPage

[Link: `Xamarin.Forms.Core.ContentPage` docs](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/contentpage/).

A single page app typically returns a `ContentPage`:

```fsharp
let view model dispatch =
    Xaml.ContentPage(
        title="Pocket Piggy Bank",
        content= Xaml.Label(text = sprintf "Hello world!")
    )
```

### Dynamic Views: StackLayout

[Link: `Xamarin.Forms.Core.StackLayout` docs](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/stacklayout/).

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


### Dynamic Views:  Button

[Link: `Xamarin.Forms.Core.Button` docs](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/button/).

Buttons are created using `Xaml.Button`. The `command` of a button will normally dispatch a messsage.  For example:

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
                    yield Xaml.Label(text = sprintf "Logged in as : %s" user)
                    yield Xaml.Label(text = sprintf "Balance: %s%.2f" model.CurrencySymbol model.Balance)
                    yield Xaml.Button(text = "Withdraw", command=(fun () -> dispatch (Spend 10.0m)), canExecute=(model.Balance > 0.0m))
                    yield Xaml.Button(text = "Deposit", command=(fun () -> dispatch (Add 10.0m)))
                    yield Xaml.Button(text = "Logout", command=(fun () -> dispatch (Login None)))
                | None ->
                    yield Xaml.Button(text = "Login", command=(fun () -> dispatch (Login (Some "user"))))
            ]))
```

### Dynamic Views: ListView, ListGroupedView

[Link: `Xamarin.Forms.Core.ListView` docs](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/listview/).

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

#### DynamicViews: "Infinite" or "unbounded" ListViews 

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

### Dynamic Views: Other Controls

All other controls from `Xamarin.Forms.Core` are available in the programming model.  See the `AllControls` sample.


### Dynamic Views and Navigation

Multiple pages are just generated as part of the overall view.

Four multi-page navigation models are shown in `AllControls`:

* MasterDetail
* NavigationPage (using push/pop)
* TabbedPage
* CarouselPage

#### NavigationPage push/pop

The basic principles are easy:
1. Keep some information in your model indicating the page stack (e.g. a list of page identifiers or page models)
2. Return the current visual page stack in the `pages` property of `NavigationPage`.
3. Set `HasNavigationBar` and `HasBackButton` on each sub-page according to your desire
4. Dispatch messages in order to navigate, where the corresponding `update` adjusts the page stack in the model 

```fsharp
let view model dispatch = 
    Xaml.NavigationPage(pages=
        [ for page in model.PageStack do
            match page with 
            | "Home" -> 
                yield Xaml.ContentPage(...).HasNavigationBar(true).HasBackButton(true)
            | "PageA" -> 
                yield Xaml.ContentPage(...).HasNavigationBar(true).HasBackButton(true)
            | "PageB" -> 
                yield Xaml.ContentPage(...).HasNavigationBar(true).HasBackButton(true)
        ])
```

#### Example: Modal pages

A modal page is done by yielding an additional page in the NavigationPage. For example, here is an "About" page example:

```fsharp
type Model =
    { ShowAbout: bool 
      ...
    }

type Msg = 
    | ...
    | ShowAbout of bool

let view model dispatch = 
    ...
    Xaml.NavigationPage(pages=
        [ yield Xaml.ContentPage(title="Root Page", content=Xaml.Button(text="About", command=(fun () -> dispatch (ShowAbout true)))) 
          if model.ShowAbout then 
              yield 
                  Xaml.ContentPage(title="About", 
                      content= Xaml.StackLayout(
                          children=[ 
                              Xaml.Label(text = "Elmish.XamarinForms, version " + string (typeof<XamlElement>.Assembly.GetName().Version))
                              Xaml.Button(text = "Continue", command=(fun () -> dispatch (ShowAbout false) ))
                          ]))
        ])
```

#### Navigation Toolbar

A toolbar can be added to a navigation page using `.ToolbarItems([ ... ])` as follows:

```fsharp
let view model dispatch = 
    ...
    Xaml.NavigationPage(pages=
        [ Xaml.ContentPage(...)
            .ToolbarItems([Xaml.ToolbarItem(text="About", command=(fun () -> dispatch (ShowAbout true))) ] )
```

#### TabbedPage navigation

Return a `TabbedPage` from your view:
```fsharp
let view model dispatch = 
    Xaml.TabbedPage(children= [ ... ])
```

#### CarouselPage navigation

Return a `CarouselPage` from your view:
```fsharp
let view model dispatch = 
    Xaml.CarouselPage(children= [ ... ])
```

#### MasterDetail Page navigation

Principles:
1. Keep some information in your model indicating the current detail being shown
2. Return a `MasterDetailPage` from your `view` function

See the `AllControls` sample

### Dynamic Views: Performance Hints

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

### Dynamic Views: Resource Dictionaries

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


### Dynamic Views: Differential Update of Lists of Things

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


Styling
-------

Styling is a significant topic in Xamarin.Forms programming.  See [the extensive Xamarin.Forms documentation on styling](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/styles/).


#### F#-coded styling

One approach is to manually code up styling simply by using normal F# programming to abstract away commonality between
various parts of your view logiv.

We do not give a guide here as it is routine application of F# coding.  The [Fulma](https://mangelmaxime.github.io/Fulma/#fulma) approach to styling may also be of interest and provide inspiration.

There are many upsides to this approach. The downsides are:
* styling is done using F# coding, and some UI designers may prefer to work with CSS or another styling technique
* there is no easy way to provide default styling base on selectors like "All buttons" (except of course to carefully code your F# to make sure all button creations go through a particular helper)
* you may end up hand-rolling certain selector queries and patterns from other styling languages.

#### CSS styling with Xamarin.Forms 3.0

1. create a CSS file with appropriate selectors and property specifications, e.g.
```css
stacklayout {
    margin: 20;
}

.mainPageTitle {
    font-style: bold;
    font-size: medium;
}

.detailPageTitle {
    font-style: bold;
    font-size: medium;
    text-align: center;
}

```
where `stacklayout` referes to all elements of that type, and `.mainPageTitle` refers to a specific element style-class path. 

2. Add the style sheet to your app as an `EmbeddedResource` node

3. Load it into your app:
```
type App () as app = 
    inherit Application ()
    do app.Resources.Add(StyleSheet.FromAssemblyResource(Assembly.GetExecutingAssembly(),"MyProject.Assets.styles.css"))
```

4. Set `StyleClass` for named elements, e.g. 

```fsharp
      Xaml.Label(text="Hello", styleClass=detailPageTitle")
      ...
      Xaml.Label(text="Main Page", styleClass="mainPageTitle")
```

#### "Xaml" coding via explicit `Style` objects

You can also use "Xaml styling" by creating specific `Style` objects using the `Xamarin.Forms` APIs directly
and attaching them to your application.  See [the Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/styles/xaml/).  We don't go into details here

Models
-------

### Models: Messages and Validation

Validation is generally done on updates to the model, storing error messages from validation logic in the model
so they can be correctly and simply displayed to the user.  Here is an example of a typical pattern.

```fsharp

    type Temperature = 
       | Value of double
       | ParseError of string  
       
    type Model = 
        { TempF: Temperature
          TempC: Temperature }

    /// Validate a temperature in Farenheit, can be shared between client/server
    let validateF text =  ... // return a Result

    /// Validate a temperature in celcius, can be shared between client/server
    let validateC text = // return a Result 

    let update msg model =
        match msg with
        | SetF textF -> 
            match validateF textF with
            | Ok newF -> { model with TempF = Value newF }
            | Error msg -> { model with TempF = ParseError msg }
            
        | SetC textC -> 
            match validateC textC with
            | Ok newC -> { model with TempC = Value newC }
            | Error msg -> { model with TempC = ParseError msg }
```

Note that the same validation logic can be used in both your app and a service back-end.

### Models: Saving Application State

Application state is very simple to save by serializing the model into `app.Properties`. For example, you can store as JSON as follows using [`FsPickler` and `FsPickler.Json`](https://github.com/mbraceproject/FsPickler), which use `Json.NET`:
```fsharp
open MBrace.FsPickler.Json

type Application() = 
    ....
    let modelId = "model"
    override __.OnSleep() = 
        app.Properties.[modelId] <- FsPickler.CreateJsonSerializer().PickleToString(runner.Model)

    override __.OnResume() = 
        try 
            match app.Properties.TryGetValue modelId with
            | true, (:? string as json) -> 
                runner.SetCurrentModel(FsPickler.CreateJsonSerializer().UnPickleOfString(json), Cmd.none)
            | _ -> ()
        with ex -> 
            program.onError("Error while restoring model found in app.Properties", ex)

    override this.OnStart() = this.OnResume()
```

Messages, Commands and Control
------------

### Messages, Commands and Asynchronous Actions

Asynchronous actions are triggered by having the `update` function return "commands", which can trigger later `dispatch` of further messages.

* Change `Program.mkSimple` to `Program.mkProgram`

```fsharp
    let program = Program.mkProgram App.init App.update App.view
```

* Change your `update` function to return a pair of a model and a command. For most messages the command will be `Cmd.none` but for basic async actions use `Cmd.ofAsyncMsg`.

For example, here is one pattern for a timer loop that can be turned on/off:

```fsharp
    type Model = 
        { ...
          TimerOn: bool 
        }
        
    type Message = 
        | ...
        | TimedTick
        | TimerToggled of bool
        
    let timerCmd = 
        async { do! Async.Sleep 200
                return TimedTick }
        |> Cmd.ofAsyncMsg

    let update msg model =
        match msg with
        | ...
        | TimerToggled on -> { model with TimerOn = on }, (if on then timerCmd else Cmd.none)
        | TimedTick -> if model.TimerOn then { model with Count = model.Count + model.Step }, timerCmd else model, Cmd.none
```
The state-resurrection `OnResume` logic of your application (see above) should also be adjusted to restart
appropriate `async` actions accoring to the state of the application.

NOTE: Making all stages of async computations (and their outcomes, e.g. cancellation and/or exceptions) explicit can add
additional messages and model states. This comes with pros and cons. Please discuss concrete examples by opening issues
in this repository.

### Messages: Global asynchronous event subscriptions

You can also set up global subscriptions, which are events sent from outside the view or the dispatch loop. For example, dispatching `ClockMsg` messages on a global timer:
```fsharp
    let timerTick dispatch =
        let timer = new System.Timers.Timer(1.0)
        timer.Elapsed.Subscribe (fun _ -> dispatch (ClockMsg System.DateTime.Now)) |> ignore
        timer.Enabled <- true
        timer.Start()

    ...
    let runner = 
        ...
        |> Program.withSubscription (fun _ -> Cmd.ofSub timerTick)
        ...
        
```

