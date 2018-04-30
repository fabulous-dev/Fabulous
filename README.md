F# Functional-Reactive App Development, using Xamarin.Forms 
=======

[![NuGet version](https://badge.fury.io/nu/Elmish.XamarinForms.svg)](https://badge.fury.io/nu/Elmish.XamarinForms) [![Build status (Windows)](https://ci.appveyor.com/api/projects/status/4qajefd4c6sbjfrt/branch/master?svg=true)](https://ci.appveyor.com/project/dsyme/elmish-xamarinforms/branch/master)  [![Build status (OSX)](https://ci.appveyor.com/api/projects/status/4qajefd4c6sbjfrt/branch/master?svg=true)](https://travis-ci.org/fsprojects/Elmish.XamarinForms.svg?branch=master)

Never write a ViewModel class again!  Conquer the world with clean dynamic UIs!

This library uses a variation of [elmish](https://elmish.github.io/), an Elm architecture implemented in F#, to build Xamarin.Forms applications. Fable-elmish was originally written for [Fable](https://github.com/fable-compiler) applications, however it is used here for Xamarin.Forms. This is a sample and may change.

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
```
The init function returns your initial state, and each model gets an update function for message processing. The `view` function computes an immutable Xaml-like description. In the above example, the choice between a label and button depends on the `model.Pressed` value.

Your application must be started as follows and assigned to the MainPage of your app:
```fsharp

type App () = 
    inherit Application ()

    let page = 
        Program.mkSimple init update view
        |> Program.withConsoleTrace
        |> Program.withDynamicView
        |> Program.run

    do base.MainPage <- page
```

Example Xaml descriptions
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

Roadmap
--------

* Programming model: Do these from `Xamarin.Forms.Core`: 
  * Menu, MenuItem, NavigationBar, Accelerator
  * Validation
  * Animation
  * OpenGLView
  * Allow configuration of protected overrides such as OnSleep, OnResume, OnStart etc.
  * Fix issue for slider where minimum = 1.0, maximum=10.0 (i.e. when value=0 and minimum gets set before maximum?)

* Programming efficiency
  * Support F# in Xamarin Live Player
  * Support hot-reloading of the saved model, reapplying to the same app where possible
  * Develop a sample that includes both client and server development, like [this talk](https://skillsmatter.com/skillscasts/11308-safe-apps-with-f-web-stack)

* Testing
  * Better unit-testing
  * Add an explicit unit-test project
  * Test with Visual Studio for Mac
  * Test with iOS
  * Most testing so far is done through  [AllControls](https://github.com/fsprojects/Elmish.XamarinForms/blob/master/Samples/AllControls/AllControls/AllControls.fs) project

* Real-world road-testing:
  * Multi-page apps with navigation
  * Apps using charting
  * Apps using maps

* Templates
  * Develop a template pack

* Docs
  * Generate `///` docs in code generator

* Debugging
  * Improve diagnostics when property update fails
  * Fix bug where ranges for locals seem off-by-one in Android debugging

* Performance:
  * Road test differential update
  * Minimize updates where possible
  * Experiment with different approaches to memoization
  * Memoize function closure creation
  * Use integer atoms for property names
  * Do better list comparison/diffing
  * Consider keeping a running identity hash on the immutable objects
  * Consider implementing equality and hash on the immutable objects
  * Perf-test on large lists and do resulting perf work
  * Consider moving 'view' and 'model' computations off the UI thread

* Handle 3rd party controls.
  * Examples: `Xamarin.Forms.Maps`, `SkiaSharp`
  * Please add more examples of 3rd party controls
  * Consider whether to continue using a code generator or to switch to a type provider
  * Make any necessary changes/additions to the `bindings.json` format (nothing is set in stone yet)

* Consider allowing explicit static Xaml through a type provider, e.g `xaml<"""<StackLayout Padding="20">...</StackLayout>""">`, evaluating to a `XamlElement`

* Make some small F# langauge improvements to improve code:
  * Remove `yield` in more cases
  * Automatically save function values that do not capture any arguments and consider making the `dispatch` function global (partly to avoid is being seen as a captured argument)
  * Allow syntax `Xaml.Foo(prop1=expr1, [ // end of line`
  * `TryGetValue` on F# immutable map
  * Allow a default unnamed argument for `children` so the argument name doesn't have to be given explicitly
  * Allow the use of struct options for optional arguments (to reduce allocations)


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

    do
        let page = 
            Program.mkSimple init update view
            |> Program.withConsoleTrace
            |> Program.withStaticView
            |> Program.run

        base.MainPage <- page
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

