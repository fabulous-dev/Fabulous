Elmish.XamarinForms Guide
=======

* [Structure of an App](#structure-of-an-app)
* [Views](views.md)
* [Models](models.md)
* [Update, Messages and Control](update.md)
* [Styling](styling.md)

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



### The model

The model is the core data from which the whole state of the app can be resurrected.  When designing your model, ask yourself  "what is the information I would need on restart to get the app back to the same essential state". The model is generally immutable but may also contain elements such as service connections.

Generally the model grows organically as you prototype your app.

Some advantages of using an immutable model are:

* It is easy to unit test your `init`, `update` and `view` functions
* You can save/restore your model relatively easily
* It makes tracing causality usually very simple

The `init` function returns your initial model.

### The view function

The view function computes an immutable Xaml-like description. In the above example, the choice between a label and button depends on the `model.Pressed` value.

See [views](views.md), [styling](styling.md) and [navigation](navigation.md).

### The `update` function

Each model gets an `update` function for message processing. The messages are either messages from the `view` or from external events.
If using `Program.mkProgram` your model may also return new commands to trigger asa result of processing a message.

See [update](update.md)

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

