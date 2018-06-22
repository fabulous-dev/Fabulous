Elmish.XamarinForms Guide
=======

{% include_relative contents.md %}

The Init and Update Functions
------

The init function returns an initial model, and the update function processes a message and returns a new model:
```fsharp
type Model = { TimerOn: bool } 

type Message = 
    | TimerToggled of bool
    
let init () = { TimerOn = false }
    
let update msg model =
    match msg with
    | TimerToggled on -> { model with TimerOn = on }
```

Commands
------

A `Cmd` is a callback that can dispatch messages, i.e. gets access to `dispatch` when run.
These can be used for event subscriptions to callback, implement timers and so on. They can also be returned
with the model to queue up long running operations such as network calls.

Commands are often asynchronous and nearly always dispatch messages. For example, the simplest way to make a command
is `Cmd.ofAsyncMsg` which triggers a message dispatch when an async completes:
```fsharp
let timerCmd = 
    async { do! Async.Sleep 200
            return TimedTick }
    |> Cmd.ofAsyncMsg
```

The init and update functions may return new "commands".  This is permitted when using `Program.mkProgram`.
For example here is a pattern  to get an initial balance on startup:
```fsharp
    let fetchInitialBalance = Cmd.ofAsyncMsg (async { ... })

    let init () = { ... }, fetchInitialBalance
```
Likewise, for example, here is one pattern for a timer loop that can be turned on/off:

```fsharp
    type Model = 
        { TimerOn: bool }
        
    type Message = 
        | TimedTick
        | TimerToggled of bool
        
    let timerCmd = 
        async { do! Async.Sleep 200
                return TimedTick }
        |> Cmd.ofAsyncMsg

    let init () = { TimerOn = false }, Cmd.none
    
    let update msg model =
        match msg with
        | TimerToggled on -> { model with TimerOn = on }, (if on then timerCmd else Cmd.none)
        | TimedTick -> if model.TimerOn then { model with Count = model.Count + model.Step }, timerCmd else model, Cmd.none
```

### Messages: External event and asynchronous event subscriptions

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
To subscribe to an external event source, use something like this:
```let subscribeToPushEvent disptach = 
     ...
       call dispatch in some closure
    ...

...

    |> Program.withSubscription(fun _ -> Cmd.ofSub subscribeToPushEvent)
```

Everything that wants access to `dispatch` must be mentioned in the composition of the overall app, or as part of a command produced as a result of processing a message, or in the view.

