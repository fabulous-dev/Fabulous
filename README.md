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

Example Views
------

The sample [CounterApp](https://github.com/fsprojects/Elmish.XamarinForms/blob/master/Samples/CounterApp/CounterApp/CounterApp.fs) contains a slightly larger example of Button/Label/Slider controls.

The sample [AllControls](https://github.com/fsprojects/Elmish.XamarinForms/blob/master/Samples/AllControls/AllControls/AllControls.fs) contains examples of instantiating most controls in `Xamarin.Forms.Core`.

Screenshots from Anrdoid (Google Pixel):

<img src="https://user-images.githubusercontent.com/7204669/39318922-57c95174-4977-11e8-94a9-cc385101ce5d.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318926-59f844e6-4977-11e8-9834-325a6517ced6.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318929-5b66c776-4977-11e8-8317-ee1c121301d4.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318934-5cbe3c3a-4977-11e8-92aa-c3fdf644b01c.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318936-5e2380bc-4977-11e8-8912-f078744a2bde.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318938-5f6ec4f4-4977-11e8-97a9-779edd3594bc.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318941-60c1b0f0-4977-11e8-8a4a-57e17ef8c6ec.png" width="100">


Dynamic Views
------

Dynamic `view` functions are written using an F# DSL, see ``Elmish.XamarinForms.DynamicViews``.
Dynamic Views excel in cases where the existence, characteristics and layout of the view depends on information in the model. React-style differential update is used to update the Xamarin.Forms display based on the previous and current view descriptions.

Notes:
* The F# DSL is [generated](https://github.com/fsprojects/Elmish.XamarinForms/tree/master/Elmish.XamarinForms/DynamicXaml.fs) from a [declarative model](https://github.com/fsprojects/Elmish.XamarinForms/blob/master/Generator/bindings.json) using a [code generator](https://github.com/fsprojects/Elmish.XamarinForms/tree/master/Generator) adapted from [@praeclarum](https://github.com/praeclarum)'s [ImmutableUI generator](https://github.com/praeclarum/ImmutableUI).
* There is only one UI element type (XamlElement, an immutable property bag).
* Safe creation is done through helpers such as [`Xaml.Button(...)`](https://github.com/fsprojects/Elmish.XamarinForms/tree/master/Elmish.XamarinForms/DynamicXaml.fs#L1248).
* There are some additional F# DSL helpers, e.g. [`button |> withText "Hello"`](https://github.com/fsprojects/Elmish.XamarinForms/tree/master/Elmish.XamarinForms/DynamicXaml.fs#L729) (note: you don't have
to use these, and the samples don't use them).

Dynamic Views and Performance
------

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


Advantages of an immutable model
------

* Easy to unit test your `init`, `update` and `view` functions
* Can save/restore your model very easily (see below)
* Makes tracing causality usually very simple


Saving Application State
--------------

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

Models and Validation
------

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

ListViews
------

The programming model supports several more bespoke uses of the underlying [`ListView`](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/listview/) control from `Xamarin.Forms.Core`.  In the simplest form, the `items` property specifies a collection of `XamlElement`:
```fsharp
    Xaml.ListView(items = [ Xaml.Label "Ionide"
                            Xaml.Label "Visual Studio"
                            Xaml.Label "Emacs"
                            Xaml.Label "Visual Studio Code"
                            Xaml.Label "Jet Brains Rider"], 
                  itemSelected=(fun idx -> dispatch (ListViewSelectedItemChanged idx)))
```
Each item becomes a `ContentCell`.  Currently the `itemSelected` callback uses integers indexes for
keys to identify the elements, this may change in future updates.

There is also a `ListViewGrouped` for grouped items of data,

"Infinite" or "unbounded" ListViews 
-------

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

Asynchronous actions
-----

Asynchronous actions are triggered by having the `update` function return "commands", which can trigger later `dispatch` of further messages.

* Change `Program.mkSimple` to `Program.mkProgram`

    let program = Program.mkProgram App.init App.update App.view

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

You can also set up global subscriptions, see the Elmish documentation for now.  

Making all stages of async computations (and their outcomes, e.g. cancellation and/or exceptions) explicit can add
additional messages and model states. This comes with pros and cons. Please discuss concrete examples by opening issues
in this repository.

Differential Update of Lists of Things
-----

There are a few different kinds of list in Xamarin.Forms - basically 
1. lists of raw data (e.g. data for a chart control, though there are no samples like that yet in this library)
2. lists of XamlElement that are used to produce cells (e.g. ListView)
3. lists of UI elements (e.g. StackLayout `children`)
4. lists of pages (e.g. NavigationPages `pages`)

The perf of incremental update to these is progressively less important as you go down that list above.  

For (1) - (4) the `view` function returns a new list instance on each invocation. The incremental update process
maintains a target (e.g. the `Children` property of a `Xamarin.Forms.StackLayout`, or an `ObservableCollection` to use as an `ItemsSource`) based on the previous (P) list and the new (N) list.  The list diffing currenly does the following:
1. trims of excess elements from TARGET down to size LIM = min(NEW.Count, PREV.Count)
2. incrementally updates existing elements 0..MIN-1 in TARGET (skips this if PREV.[i] is reference-equal to NEW.[i])
3. creates elements LIM..NEW.Count-1

This means
1. Incremental update costs minimally one transition of the whole list.
2. Incremental update recycles visual elements at the start of the list and handles add/remove at end of list relatively efficiently
3. Returning a new list that inserts an element at the beginning will recreate all elements down the way.

The above is sufficient for many purposes, but care must always be taken with large lists and data sources, see `ListView` above for example.

Roadmap
--------

* Programming model: Do these from `Xamarin.Forms.Core`: 
  * Move to `seq<_>` as the de-facto model type
  * Menu, MenuItem, NavigationBar, Accelerator
  * Animation
  * OpenGLView
  * Assess further common async patterns
  * Assess further common incremental update of large data sets, e.g. `chunks { ... }`

* Docs
  * Generate `///` docs in code generator

* Programming efficiency
  * Support F# in Xamarin Live Player
  * Support hot-reloading of the saved model, reapplying to the same app where possible

* Handle 3rd party controls.
  * Examples: `Xamarin.Forms.Maps`, `SkiaSharp`
  * Consider whether to continue using a code generator or to switch to a type provider (see [this comment](https://github.com/fsprojects/Elmish.XamarinForms/issues/50#issuecomment-390396365))
  * Make any necessary changes/additions to the `bindings.json` format (nothing is set in stone yet)

* Templates
  * Develop a template pack

* Debugging
  * Improve diagnostics when property update fails
  * Fix bug where ranges for locals seem off-by-one in Android debugging

* Testing
  * Add an explicit unit-test project

* Real-world road-testing:
  * Apps using charting
  * Apps using maps

* App size:
  * Check the Xamarin tree-shaker cuts out all unused code from DynamicXaml.fs

* Performance:
  * Memoize function closure creation
  * Use integer atoms for property names
  * Do better list comparison/diffing
  * Allow a `ChunkList` tree as input to ListView etc., e.g. `chunks { yield! stablePart; yield newElement; yield! stablePart2 }` 
  * Consider keeping a running identity hash on the immutable objects
  * Consider implementing equality and hash on the immutable objects
  * Perf-test on large lists and do resulting perf work
  * Consider moving 'view' and 'model' computations off the UI thread

* Communication
  * Develop a sample that includes both client and server development, like [this talk](https://skillsmatter.com/skillscasts/11308-safe-apps-with-f-web-stack)

* Consider allowing explicit static Xaml through a type provider, e.g `xaml<"""<StackLayout Padding="20">...</StackLayout>""">`, evaluating to a `XamlElement`

* Make some small F# langauge improvements to improve code:
  * Remove `yield` in more cases
  * Automatically save function values that do not capture any arguments and consider making the `dispatch` function global (partly to avoid is being seen as a captured argument)
  * [Allow syntax `Xaml.Foo(prop1=expr1, [ // end of line`](https://github.com/Microsoft/visualfsharp/pull/4929)
  * [`TryGetValue` on F# immutable map](https://github.com/Microsoft/visualfsharp/pull/4827/)
  * Allow a default unnamed argument for `children` so the argument name doesn't have to be given explicitly
  * Allow the use of struct options for optional arguments (to reduce allocations)
  * Implement the C# 5.0 "open static classes" feature in F# to allow the `Xaml.` prefix to be dropped

Bugs:
  * Fix issue for slider where minimum = 1.0, maximum=10.0 (i.e. when value=0 and minimum gets set before maximum?)
  * Fix issue with application reload in AllControls.fs

Static Views and "Half Elmish"
------

In some circumstances there are advantages to using static Xaml, and static bindings from the model to those views. This is called "Half Elmish" and is the primary technique used by [`Elmish.WPF`](https://github.com/Prolucid/Elmish.WPF) at time of writing. (It was also  the original technique used by this repo and the prototype `Elmish.Forms`).   

"Half Elmish" is a pragmatic choice to allow, but doesn't provide the same level of cognitive-simplicity. In the words of Jim Bennett:

> As a C#/XAML dev I really like the half Elmish model. I’m comfortable with XAML so like being able to use the Elmish bits to create a nice immutable model and have clean code, but still using XAML and binding as I’m comfortable there. This feels more like how existing C# Xamarin devs would move to F#. Full elmish is how F# devs will move to Xamarin.

Static Xaml + bindings has signifcant pros:
* Pro: in some circumstances perf can be better
* Pro: you can interact with existing xaml assets
* Pro: you can interact with 3rd party controls relatively easily
* Con: you have to know a lot more about Xaml (e.g. binding, commands, templating, converters)
* Con: you get more files in your project (e.g. 3 instead of 1, even for simple examples)
* Con: you are more reliant on tooling (which is often a bit flakey...)
* Con: you may end up using more mutable data structures
* Con: there are  more failure points (e.g. magic strings to link the Xaml to the code through binding etc.).  
* Con: the Xaml is static, and only made dynamic through the addition of control bindings to turn elements on/off

If you want to use static Xaml, then you will need to do bindings to that Xaml.
Bindings in your XAML code will look like typical bindings, but a bit of extra code is needed to 
map those bindings to your Elmish model. These are the viewBindings, which expose parts of the model to the view. 

Here is a full example (excluding Xaml):
```fsharp
namespace CounterApp

open Elmish
open Elmish.XamarinForms
open Elmish.XamarinForms.StaticViews
open Xamarin.Forms

type Model = 
  { Count : int
    Step : int }

type Msg = 
    | Increment 
    | Decrement 
    | Reset
    | SetStep of int

type CounterApp () = 
    inherit Application ()

    let init () = { Count = 0; Step = 3 }

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + model.Step }
        | Decrement -> { model with Count = model.Count - model.Step }
        | Reset -> init ()
        | SetStep n -> { model with Step = n }

    let view () =
        CounterPage (),
        [ "CounterValue" |> Binding.oneWay (fun m -> m.Count)
          "CounterValue2" |> Binding.oneWay (fun m -> m.Count + 1)
          "IncrementCommand" |> Binding.msg Increment
          "DecrementCommand" |> Binding.msg Decrement
          "ResetCommand" |> Binding.msgIf Reset (fun m -> m <> init ())
          "ResetVisible" |> Binding.oneWay (fun m ->  m <> init ())
          "StepValue" |> Binding.twoWay (fun m -> double m.Step) (fun v -> SetStep (int (v + 0.5))) ]

    let runner = 
        Program.mkSimple init update view
        |> Program.withConsoleTrace
        |> Program.withStaticView
        |> Program.run

    do base.MainPage <- runner.InitialMainPage
```
There are helper functions to create bindings located in the `Binding` module:
* `Binding.oneWay getter`
  * Basic source-to-view binding. Maps to `BindingMode.OneWay`.
  * Takes a getter (`'model -> 'a`)
* `Binding.twoWay getter setter`
  * Binding from source to view, or view to source, and usually used for input controls. 
  * Takes a getter (`'model -> 'a`) and a setter (`'a -> 'model -> 'msg`) that returns a message.
* `Binding.oneWayFromView setter`
  * Binding from view to source, and usually used for input controls. 
  * Takes a a setter (`'a -> 'model -> 'msg`) that returns a message.
* `Binding.twoWayValidation getter setter`
  * Binding from source to view and view to source, and usually used for input controls. Maps to `BindingMode.TwoWay`. Setter will implement validation.
  * Takes a getter (`'model -> 'a`) and a setter (`'a -> 'model -> Result<'msg,string>`) that indicates whether the input is valid or not.
* `Binding.msg`
  * Basic command binding to dispatch a message
  * Takes an execute function (`'model -> 'msg`)
* `Binding.msgIf`
  * Conditional command binding to dispatch a message
  * Takes an execute function (`'model -> 'msg`) and a canExecute function (`'model -> bool`)
* `Binding.msgWithParamIf`
  * Conditional command binding to dispatch a message, with an additional `CommandParameter`
  * Takes an execute function (`'model -> 'msg`) and a canExecute function (`'model -> bool`)
* `Binding.subView initf getter toMsg viewBindings name`
  * Composite model binding
  * Takes a sub-model initializer sub-model getter (`'model -> '_model`) to fetch part of a model, a message embedder (`'_msg -> 'msg`) to embed sub-component messages into a larger space of messages, and the composite sub-model viewBindings, and a name for the sub-model
* `oneWayMap`
  * One-way binding that applies a map when passing data to the view.
  * Takes a getter (`'model -> 'a`) and a mapper (`'a -> 'b`).

The string piped to each binding is the name of the property as referenced in the XAML binding.


Elmish Subscriptions
------

Elmish subscriptions are events sent from outside the view or the dispatch loop, are created using `Cmd.ofSub`. For example, dispatching events on a timer:
```fsharp
    let timerTick dispatch =
        let timer = new System.Timers.Timer(1.0)
        timer.Elapsed.Subscribe (fun _ -> dispatch (System.DateTime.Now |> Tick |> ClockMsg)) |> ignore
        timer.Enabled <- true
        timer.Start()

    let subscribe model =
        Cmd.ofSub timerTick
```
NOTE: we may switch to using the Xamarin `MessagingCenter` that is global to the application.


Multiple Pages and Navigation
------

There is some experimental support for multiple-page apps and navigation. See the MasterDetailApp sample.  This currently only supports static views.


Dev Notes - Releasing
------

Use this:

    .\build NuGet
    set APIKEY=...
    .nuget\NuGet.exe push C:\GitHub\dsyme\Elmish.XamarinForms\build_output\Elmish.XamarinForms.*.nupkg  %APIKEY% -Source https://www.nuget.org
    copy C:\GitHub\dsyme\Elmish.XamarinForms\build_output\Elmish.XamarinForms.*.nupkg  %USERPROFILE%\Downloads

Credits
-----
This library is inspired by [Elmish.WPF](https://github.com/Prolucid/Elmish.WPF), [Elmish.Forms](https://github.com/dboris/elmish-forms) and [elmish](https://github.com/elmish/elmish), written by [et1975](https://github.com/et1975). This project technically has no tie to [Fable](http://fable.io/), which is an F# to JavaScript transpiler that is definitely worth checking out.

