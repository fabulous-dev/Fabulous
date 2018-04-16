WORK IN PROGRESS SAMPLE
=======

Xamarin.Forms done the Elmish Way
=======

[![NuGet version](https://badge.fury.io/nu/Elmish.XamarinForms.svg)](https://badge.fury.io/nu/Elmish.XamarinForms)

Never write a ViewModel class again!

This library uses [fable-elmish](https://fable-elmish.github.io/), an Elm architecture implemented in F#, to build Xamarin.Forms applications. Fable-elmish was originally written for [Fable](https://github.com/fable-compiler) applications, however it is used here for Xamarin.Forms. It is highly recommended to have a look at the [elmish docs site](https://fable-elmish.github.io/elmish/) if you are not familiar with the Elm architecture.

Getting started with Elmish.XamarinForms
------
* Create an F# Windows Application (or Console) project. This is where your Elmish model will live.
* Add nuget package `Elmish.XamarinForms` to to your Elmish project.
* Create a Xamarin.Forms Class Library project. This is where your XAML views will live.
* Reference your View project in your Elmish project.

The Elmish Stuff
------
Here is an example of an Elmish model (`Model`) with a composite model inside of it (`ClockModel`) and the corresponding messages:
```fsharp
    type ClockMsg =
        | Tick of DateTime

    type ClockModel =
        { Time: DateTime }

    type Msg =
        | ClockMsg of ClockMsg
        | Increment
        | Decrement
        | SetStepSize of int

    type Model = 
        { Count: int
          StepSize: int
          Clock: ClockModel }
```
The init function returns your initial state, and each model gets an update function for message processing:
```fsharp
    let init() = { Count = 0; StepSize = 1; Clock = { Time = DateTime.Now }}
    
    let clockUpdate (msg:ClockMsg) (model:ClockModel) =
        match msg with
        | Tick t -> { model with Time = t }

    let update (msg:Msg) (model:Model) =
        match msg with
        | Increment -> { model with Count = model.Count + model.StepSize }
        | Decrement -> { model with Count = model.Count - model.StepSize }
        | SetStepSize n -> { model with StepSize = n }
        | ClockMsg m -> { model with Clock = clockUpdate m model.Clock }
```
Subscriptions, which are events sent from outside the view or the dispatch loop, are created using `Cmd.ofSub`. For example, dispatching events on a timer:
```fsharp
    let timerTick dispatch =
        let timer = new System.Timers.Timer 1.
        timer.Elapsed.Subscribe (fun _ -> dispatch (System.DateTime.Now |> Tick |> ClockMsg)) |> ignore
        timer.Enabled <- true
        timer.Start()

    let subscribe model =
        Cmd.ofSub timerTick
```

Binding the Elmish to the XAML (Static Views)
------
Bindings in your XAML code will look like typical bindings, but a bit of extra code is needed to map those bindings to your Elmish model. These are the viewBindings, which expose parts of the model to the view. 

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

Tying it all together
-----
Pass an instance of your main page into `Program.runPage`. The DataContext of this instance will be automatically set to your main model.
```fsharp
type CounterApp () = 
    inherit Application ()

    ...
    let page = CounterApp.CounterPage ()

    do
        Program.mkSimple init update view
        |> Program.withConsoleTrace
        |> Program.runPage page

        base.MainPage <- page
```

Multiple Pages and Navigation
------

There is some experimental support for multiple-page apps and navigation. See the MasterDetailApp sample.


Binding the Elmish to the XAML (Flickering Dynamic Views)
------

There is **toy-only** support for dynamic view functions that compute entire new content on each update.  This results in flickering,
dynamic visual updates so is not yet appropriate for use, but is an interesting programming model experiment called the "Full Elmish" or "Phase 2" approach. In
this case, the `view` function can compute new content. A small F# DSL is provided for this in ``Elmish.XamarinForms.DynamicViewHelpers``.

```fsharp
    open Elmish.XamarinForms.DynamicViewHelpers

    ...
    /// The dynamic 'view' function giving updated content for the page
    let view model dispatch =
        rect Color.BlackGreen 
```
Your application must be started as follows:
```fsharp
    let page = 
        Program.mkSimple 
            init 
            (update gameOver) 
            (fun _ _ -> MyPage(), [ (* any static bindings *) ], App.view) 
        |> Program.withConsoleTrace
        |> Program.runDynamicView
```
This is work in progress and may change.  

Releasing
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
