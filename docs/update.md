Fabulous - Guide
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

A command (type `Cmd`) is a callback that can dispatch messages, i.e. gets access to `dispatch` when run.

Commands can be used for event subscriptions to callback, implement timers and so on. They can also be returned
with the model to queue up long running operations such as network calls.

Commands are often asynchronous and nearly always dispatch messages. For example, the simplest way to make a command
is `Cmd.ofAsyncMsg` which triggers a message dispatch when an async completes:
```fsharp
let timerCmd = 
    async { do! Async.Sleep 200
            return TimedTick }
    |> Cmd.ofAsyncMsg
```

Triggering Commands on Initialization
------

The `init` function may trigger commands, e.g. initial database requests.  This is permitted when using `Program.mkProgram`.
For example here is a pattern  to get an initial balance on startup:
```fsharp
let fetchInitialBalance = Cmd.ofAsyncMsg (async { ... })

let init () = { ... }, fetchInitialBalance
```

Triggering Commands as Messages are Processed
------

The `update` function may trigger commands such as timers.  This is permitted when using `Program.mkProgram`.
For example, here is one pattern for a timer loop that can be turned on/off:

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

Triggering Commands from External Events
------

You can also set up global subscriptions, which are events sent from outside the view or the dispatch loop. For example, dispatching `ClockMsg` messages on a global timer:
```fsharp
let timerTick dispatch =
    let timer = new System.Timers.Timer(1.0)
    timer.Elapsed.Subscribe (fun _ -> dispatch (ClockMsg System.DateTime.Now)) |> ignore
    timer.Enabled <- true
    timer.Start()

let runner = 
    Program.mkSimple App.init App.update App.view
    |> Program.withSubscription (fun _ -> Cmd.ofSub timerTick)
    |> Program.runWithDynamicView app
        
```
Likewise, the general pattern to subscribe to external event sources is as follows:
```fsharp
let subscribeToPushEvent dispatch = 
     ...
     call dispatch in some closure
     ...

let runner = 
    Program.mkSimple App.init App.update App.view
    |> Program.withSubscription (fun _ -> Cmd.ofSub subscribeToPushEvent)
    |> Program.runWithDynamicView app
        
```

Everything that wants access to `dispatch` must be mentioned in the composition of the overall app, or as part of a command produced as a result of processing a message, or in the view.

Threading and Long-running Operations
------

The rules:
1. `update` gets run on the UI thread.  
2. `dispatch` can be called from any thread. The message will be processed by `update` on the UI thread.
3. `view` gets called on the UI thread. In the future an option may be added to offload the `view` function automatically. 

When handling any long running operation, the operation should initiate it's thing and dispatch a message when done.
If necessary, explicitly off-load and then dispatch at the end, e.g.

```fsharp
let backgroundCmd =
    Cmd.ofAsyncMsg (async { 
        do! Async.SwitchToThreadPool()
        let res = ...
        return msg
    })
```

Optional commands
------

There might be cases where before a message is sent, you need to check if you want to send it (e.g. check user's preferences, ask user's permission, ...)

Fabulous has 2 helper functions for this:

- `Cmd.ofMsgOption`

```fsharp
let autoSaveCmd =
    match userPreference.IsAutoSaveEnabled with
    | false -> None
    | true ->
        autoSave()
        Some Msg.AutoSaveDone

let update msg model =
    match msg with
    | TimedTick -> model, (Cmd.ofMsgOption autoSaveCmd)
    | AutoSaveDone -> ...
```

- `Cmd.ofAsyncMsgOption`

```fsharp
let takePictureCmd = async {
    try
        let! picture = takePictureAsync()
        Some (Msg.PictureTaken picture)
    with
    | exn ->
        do! displayAlert("Exception: " + exn.Message)
        None
}

let update msg model =
    match msg with
    | TakePicture -> model, (Cmd.ofAsyncMsgOption takePictureCmd)
    | PictureTaken -> ...
```