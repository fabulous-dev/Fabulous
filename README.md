F# Functional-Reactive App Development, using Xamarin.Forms 
=======

[![NuGet version](https://badge.fury.io/nu/Elmish.XamarinForms.svg)](https://badge.fury.io/nu/Elmish.XamarinForms)

Never write a ViewModel class again!  Conquer the world with clean dynamic UIs!

This library uses a variation of [elmish](https://fable-elmish.github.io/), an Elm architecture implemented in F#, to build Xamarin.Forms applications. Fable-elmish was originally written for [Fable](https://github.com/fable-compiler) applications, however it is used here for Xamarin.Forms. Have a look at the [elmish docs site](https://fable-elmish.github.io/elmish/) if you are not familiar with the Elm architecture.

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

Dynamic views are only efficient for large UIs if the "unchanging" parts of a UI are "memoized", returning identical
objects on each invocation of the `view` function.  Amortization must be done explicitly and carefully. Here is an example for a 6x6 Grid that never changes:
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
Inside the function passed to `dependsOn` the `model` is rebound to be inaccessbile.  This helps ensure that this part of the
view description doesn't depend on captured variables.  You can also extract this part of the view description to a separate function.

Here is an example where some of the model is extracted:
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
If not, this section of the view will be reused.

Roadmap
--------

* Programming model: Do these from `Xamarin.Forms.Core`: 
  * Menu, MenuItem, NavigationBar, Accelerator
  * Animation
  * OpenGLView
  * CachingStrategy parameter to ListView
  * Allow configuration of protected overrides such as OnSleep, OnResume, OnStart etc.

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

* Performance:
  * Road test differential update
  * Minimize updates where possible
  * Experiment with different approaches to amortization
  * Amortize function closure creation
  * Use integer atoms for property names
  * Do better list comparison/diffing
  * Consider keeping a running identity hash on the immutable objects
  * Consider implementing equality and hash on the immutable objects
  * Perf-test on large lists and do resulting perf work

* Handle 3rd party controls.
  * Examples: `Xamarin.Forms.Maps`, `SkiaSharp`
  * Please add more examples of 3rd party controls
  * Consider whether to continue using a code generator or to switch to a type provider
  * Make any necessary changes/additions to the `bindings.json` format (nothing is set in stone yet)

* Consider allowing explicit static Xaml through a type provider, e.g `xaml<"""<StackLayout Padding="20">...</StackLayout>""">`, evaluating to a `XamlElement`

* Make some small F# langauge improvements to improve code:
  * Remove `yield` in more cases
  * Automatically dependsOn function values that do not capture any arguments and consider making the `dispatch` function global (partly to avoid is being seen as a captured argument)
  * Allow syntax `Xaml.Foo(prop1=expr1, [ // end of line`
  * `TryGetValue` on F# immutable map
  * Allow a default unnamed argument for `children` so the argument name doesn't have to be given explicitly


Old docs: Static Views
------
If you really want to use static Xaml, then you will need to do bindings to that Xaml.

Bindings in your XAML code will look like typical bindings, but a bit of extra code is needed to 
map those bindings to your Elmish model. These are the viewBindings, which expose parts of the model to the view. 

There are helper functions to create bindings located in the `Binding` module:
* `oneWay`
  * Basic source-to-view binding. Maps to `BindingMode.OneWay`.
  * Takes a getter (`'model -> 'a`)
* `twoWay`
  * Binding from source to view, or view to source, and usually used for input controls. Maps to `BindingMode.TwoWay` or `BindingMode.OneWayToSource`.
  * Takes a getter (`'model -> 'a`) and a setter (`'a -> 'model -> 'msg`) that returns a message.
* `twoWayValidation`
  * Binding from source to view, or view to source, and usually used for input controls. Maps to `BindingMode.TwoWay` or `BindingMode.OneWayToSource`. Setter will implement validation which is exposed to the view through typical `INotifyDataErrorInfo` properties.
  * Takes a getter (`'model -> 'a`) and a setter (`'a -> 'model -> Result<'msg,string>`) that indicates whether the input is valid or not.
* `cmd`
  * Basic command binding
  * Takes an execute function (`'model -> 'msg`)
* `cmdIf`
  * Conditional command binding
  * Takes an execute function (`'model -> 'msg`) and a canExecute function (`'model -> bool`)
* `vm`
  * Composite model binding
  * Takes a getter (`'model -> 'a`) and the composite model viewBindings, where `'a` is your composite model member. 
* `oneWayMap`
  * Basic source-to-view binding with a map function. This should be used for cases where it is desirable to have one type in your model and return a different type to the view. This will be more performant than mapping directly in the getter.
  * Takes a getter (`'model -> 'a`) and a mapper (`'a -> 'b`).

The last string argument to each binding is the name of the property as referenced in the XAML binding.
```fsharp
    let view _ _ = 
        let clockViewBinding : ViewBindings<ClockModel,ClockMsg> =
            [ "Time" |> Binding.oneWay (fun m -> m.Time) ]

        [ "Increment" |> Binding.cmd (fun m -> Increment)
          "Decrement" |> Binding.cmdIf (fun m -> Decrement) (fun m -> m.StepSize = 1)
          "Count" |> Binding.oneWay (fun m -> m.Count)
          "StepSize" |> Binding.twoWay (fun m -> (double m.StepSize)) (fun v m -> v |> int |> SetStepSize)
          "Clock" |> Binding.vm (fun m -> m.Clock) clockViewBinding ClockMsg ]
```
Note:  A viewBinding created with `Binding.vm` would be bound to the DataContext of a user control.


Old docs: Subscriptions
------

Subscriptions, which are events sent from outside the view or the dispatch loop, are created using `Cmd.ofSub`. For example, dispatching events on a timer:
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


Old docs: Multiple Pages and Navigation
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
This library is derived from [Elmish.WPF](https://github.com/Prolucid/Elmish.WPF). In turn that would not have been possible without the elmish engine, [fable-elmish](https://github.com/fable-elmish/elmish), written by [et1975](https://github.com/et1975). This project technically has no tie to [Fable](http://fable.io/), which is an F# to JavaScript transpiler that is definitely worth checking out.

An early sample of Elmish for Xamarin Forms adapted from Elmish.WPF was drafted by [github user @dboris](https://github.com/dboris/elmish-forms).
