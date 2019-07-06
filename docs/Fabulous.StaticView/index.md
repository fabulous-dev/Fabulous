Fabulous StaticView
=======

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

If you want to use static Xaml, then you will need to do bindings to that View.
Bindings in your XAML code will look like typical bindings, but a bit of extra code is needed to
map those bindings to your Elmish model. These are the viewBindings, which expose parts of the model to the view.

Here is a full example (excluding Xaml):

```fsharp
namespace CounterApp

open Fabulous.Core
open Fabulous.StaticViews
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
        |> Program.runWithStaticView

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
