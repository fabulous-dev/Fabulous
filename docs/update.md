Elmish.XamarinForms: Update, Messages, Commands and Async
=======

{% include_relative contents.md %}

In its simplest form, when using `Program.mkSimple`, the update function simply returns a new model:
```fsharp
    let init () = { ... }
    
    let update msg model =
        match msg with
        | ...
        | TimerToggled on -> { model with TimerOn = on }
```
The init and update functions may also return new commands when using `Program.mkProgram`:
```fsharp

    let init () = { ... }, Cmd.none
    
    let update msg model =
        match msg with
        | ...
        | TimerToggled on -> { model with TimerOn = on }, (if on then timerCmd else Cmd.none)
```
Asynchronous actions are triggered in this way: by having the `init` and `update` function return commands,
which can trigger later `dispatch` of further messages. To start returning commands from your update function:

* Change `Program.mkSimple` to `Program.mkProgram`

```fsharp
    let program = Program.mkProgram App.init App.update App.view
```

* Change your `update` function to return a pair of a model and a command. For most messages the command will be `Cmd.none` but for basic async actions use `Cmd.ofAsyncMsg`.

For example here is a command to get an initial balance on startup:
```fsharp
    let fetchInitialBalance = Cmd.ofAsyncMsg (async { ... })

    let init () = { ... },fetchInitialBalance
```
Likewise, for example, here is one pattern for a timer loop that can be turned on/off:

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

    let init () = { TimerOn = false }, Cmd.none
    
    let update msg model =
        match msg with
        | ...
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

    |> Program.withSubscription(fun _ -> Cmd.ofSub subscribeToPushEvent)```
(edited)
```

Everything that wants access to `dispatch` must be mentioned in the composition of the overall app, or as part of a command produced as a result of processing a message, or in the view.

### State Resurrection

The state-resurrection `OnResume` logic of your application (see above) should also be adjusted to restart
appropriate `async` actions accoring to the state of the application.

