F# Functional App Development, using Xamarin.Forms 
=======

[![NuGet version](https://badge.fury.io/nu/Elmish.XamarinForms.svg)](https://badge.fury.io/nu/Elmish.XamarinForms) [![Build status (Windows)](https://ci.appveyor.com/api/projects/status/4qajefd4c6sbjfrt/branch/master?svg=true)](https://ci.appveyor.com/project/dsyme/elmish-xamarinforms/branch/master)  [![Build status (OSX)](https://ci.appveyor.com/api/projects/status/4qajefd4c6sbjfrt/branch/master?svg=true)](https://travis-ci.org/fsprojects/Elmish.XamarinForms.svg?branch=master) 

Never write a ViewModel class again!  Conquer the world with clean dynamic UIs!

This library uses a variation of [elmish](https://elmish.github.io/), an Elm architecture implemented in F#, to build Xamarin.Forms applications. Elmish was originally written for [Fable](https://github.com/fable-compiler) applications, however it is used here for mobile applications using Xamarin.Forms. This is a sample and may change.

To quote [@dsyme](http://github.com/dsyme):

> In my work for Xamarin, I'm asking myself "what will appeal to F# devs who want to do Xamarin programming?". These devs are very code-oriented and know F#.  People are liking Elm and React via [Elmish](https://elmish.github.io/elmish/) and also React Native. Can we apply some of the lessons to Xamarin programming?

Getting started with Elmish.XamarinForms
------

1. Create a blank F# Xamarin Forms app in Visual Studio or Visual Studio Code.  Make sure your shared code is an F# .NET Standard 2.0 Library project. 
2. Add nuget package `Elmish.XamarinForms` to to your shared code project.
3. Put the sample code below in your shared app library

A Basic Example
------
Here is a full example of an app:
```fsharp
/// The messages dispatched by the view
type Msg =
    | Pressed

/// The model from which the view is generated
type Model = 
    { Pressed: bool }

/// Returns the initial state
let init() = { Pressed=false }
    
/// The funtion to update the view
let update (msg:Msg) (model:Model) =
    match msg with
    | Pressed -> { model with Pressed = true }

/// The view function giving updated content for the page
let view (model: Model) dispatch =
    if model.Pressed then 
        Xaml.Label(text="I was pressed!")
    else
        Xaml.Button(text="Press Me!", command=(fun () -> dispatch Pressed))

type App () = 
    inherit Application ()

    let runner = 
        Program.mkSimple init update view
        |> Program.withConsoleTrace
        |> Program.withDynamicView
        |> Program.run
```
The init function returns your initial state, and each model gets an update function for message processing. The `view` function computes an immutable Xaml-like description. In the above example, the choice between a label and button depends on the `model.Pressed` value.

Some advantages of using an immutable model are:

* It is easy to unit test your `init`, `update` and `view` functions
* You can save/restore your model relatively easily
* It makes tracing causality usually very simple


Example Views
------

The sample [CounterApp](https://github.com/fsprojects/Elmish.XamarinForms/blob/master/Samples/CounterApp/CounterApp/CounterApp.fs) contains a slightly larger example of Button/Label/Slider controls.

The sample [AllControls](https://github.com/fsprojects/Elmish.XamarinForms/blob/master/Samples/AllControls/AllControls/AllControls.fs) contains examples of instantiating most controls in `Xamarin.Forms.Core`.

Screenshots from Anrdoid (Google Pixel):

<img src="https://user-images.githubusercontent.com/7204669/39318922-57c95174-4977-11e8-94a9-cc385101ce5d.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318926-59f844e6-4977-11e8-9834-325a6517ced6.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318929-5b66c776-4977-11e8-8317-ee1c121301d4.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318934-5cbe3c3a-4977-11e8-92aa-c3fdf644b01c.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318936-5e2380bc-4977-11e8-8912-f078744a2bde.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318938-5f6ec4f4-4977-11e8-97a9-779edd3594bc.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318941-60c1b0f0-4977-11e8-8a4a-57e17ef8c6ec.png" width="100">


## Dynamic Views

Dynamic `view` functions are written using an F# DSL, see ``Elmish.XamarinForms.DynamicViews``.
Dynamic Views excel in cases where the existence, characteristics and layout of the view depends on information in the model. React-style differential update is used to update the Xamarin.Forms display based on the previous and current view descriptions.

Notes:
* The F# DSL is [generated](https://github.com/fsprojects/Elmish.XamarinForms/tree/master/Elmish.XamarinForms/DynamicXaml.fs) from a [declarative model](https://github.com/fsprojects/Elmish.XamarinForms/blob/master/Generator/bindings.json) using a [code generator](https://github.com/fsprojects/Elmish.XamarinForms/tree/master/Generator) adapted from [@praeclarum](https://github.com/praeclarum)'s [ImmutableUI generator](https://github.com/praeclarum/ImmutableUI).
* There is only one UI element type (XamlElement, an immutable property bag).
* Safe creation is done through helpers such as [`Xaml.Button(...)`](https://github.com/fsprojects/Elmish.XamarinForms/tree/master/Elmish.XamarinForms/DynamicXaml.fs#L1248).
* There are some additional F# DSL helpers, e.g. [`button |> withText "Hello"`](https://github.com/fsprojects/Elmish.XamarinForms/tree/master/Elmish.XamarinForms/DynamicXaml.fs#L729) (note: you don't have
to use these, and the samples don't use them).

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


### Dynamic Views: Multiple Pages and Navigation


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

### Dynamic Views: ListView, ListGroupedView and friends

The programming model supports several more bespoke uses of the underlying [`ListView`](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/listview/) control from `Xamarin.Forms.Core`.  In the simplest form, just called `ListView`, the `items` property specifies a collection of visual elements:
```fsharp
    Xaml.ListView(items = [ Xaml.Label "Ionide"
                            Xaml.Label "Visual Studio"
                            Xaml.Label "Emacs"
                            Xaml.Label "Visual Studio Code"
                            Xaml.Label "Jet Brains Rider"], 
                  itemSelected=(fun idx -> dispatch (ListViewSelectedItemChanged idx)))
```
In the underlying implementation, each visual item is placed in a `ContentCell`.
Currently the `itemSelected` callback uses integers indexes for
keys to identify the elements (NOTE: this may change in future updates).

There is also a `ListViewGrouped` for grouped items of data.

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

Basically, incremental update is faster if lists are changing at their beginning, rather than their end.

The above is sufficient for many purposes, but care must always be taken with large lists and data sources, see `ListView` above for example.  Care must also be taken whenever data updates very rapidly.

## Models

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
                runner.Model <- FsPickler.CreateJsonSerializer().UnPickleOfString(json)
            | _ -> ()
        with ex -> 
            program.onError("Error while restoring model found in app.Properties", ex)

    override this.OnStart() = this.OnResume()
```

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

    /// Valdiate a temperature in fareneit, can be shared between client/server
    let validateF text =  ... // return a Result

    /// Valdiate a temperature in celcius, can be shared between client/server
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

## Messages, Commands and Control

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
        |> Program.withSubscription timerTick
        ...
        
```

## Static Views and "Half Elmish"

In some circumstances there are advantages to using static Xaml, and static bindings from the model to those views. This is called "Half Elmish" and is the primary technique used by [`Elmish.WPF`](https://github.com/Prolucid/Elmish.WPF) at time of writing. (It was also  the original technique used by this repo and the prototype `Elmish.Forms`).   

See [HALF-ELMISH.md](HALF-ELMISH.md)

## Roadmap

See [ROADMAP.md](https://github.com/fsprojects/Elmish.XamarinForms/blob/master/ROADMAP.md), a list of TODOs.

## Building

See [DEVGUIDE.md](DEVGUIDE.md).

## Contributing

Please contribute to this library through issue reports, pull requests, code reviews and discussion.


Credits
-----
This library is inspired by [Elmish.WPF](https://github.com/Prolucid/Elmish.WPF), [Elmish.Forms](https://github.com/dboris/elmish-forms) and [elmish](https://github.com/elmish/elmish), written by [et1975](https://github.com/et1975). This project technically has no tie to [Fable](http://fable.io/), which is an F# to JavaScript transpiler that is definitely worth checking out.

