Fabulous for Xamarin.Forms - Guide
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
    { TimerOn: bool
      Count: int
      Step: int }
        
type Message = 
    | TimedTick
    | TimerToggled of bool
        
let timerCmd = 
    async { do! Async.Sleep 200
            return TimedTick }
    |> Cmd.ofAsyncMsg

let init () = { TimerOn = false; Count = 0; Step = 1 }, Cmd.none
    
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

Replacing commands with command messages for better testability
------

Commands are a great way for executing a set of tasks (asynchronous or not) after receiving a message.

But behind the scenes, `Cmd<'msg>` is really only an array of functions. This makes testing `Cmd<'msg>` really difficult (no way to know what the functions are) and the functions `init` and `update` as well.

In the case you want to unit test your code, even if you're using `Cmd<'msg>` inside `init` and `update`, the best way is to use of the `CmdMsg` pattern. 

This is a general pattern, applicable when using an Elm-like programming model.  
It is not linked to Fabulous specifically.  

Fabulous only provides some helpers to help you achieve this with less code.  

The principle is to replace any direct usage of `Cmd<'msg>` from `init` and `update`, and instead use a discriminated union called `CmdMsg`.

```fsharp
type Model = 
    { TimerOn: bool
      Count: int
      Step: int }
        
type Msg = 
    | TimedTick
    | TimerToggled of bool

type CmdMsg =
    | TimerTick

let init () =
    { TimerOn = false; Count = 0; Step = 1 }, [] // An empty list means no action
    
let update msg model =
    match msg with
    | TimerToggled on ->
       { model with TimerOn = on }, [ if on then yield TimerTick ]
    | TimedTick ->
       if model.TimerOn then
          { model with Count = model.Count + model.Step }, [ TimerTick ]
       else
          model, []
```

Doing this transforms the output of both `init` and `update` to pure data output, which can then be easily unit tested

```fsharp
[<Test>]
let togglingOnShouldTriggerTimerTick () =
    let initialModel = { TimerOn = false; Count = 0; Step = 1 }
    let expectedReturn = { TimerOn = true; Count = 0; Step = 1 }, [ TimerTick ]
    App.update (TimerToggled true) initialModel |> should equal expectedReturn
```

The actual commands are still executed as `Cmd<'msg>` though.  
So in order to make this work with Fabulous, you need a function that will convert a `CmdMsg` to a `Cmd<'msg>`

Fabulous then helps you boot your application using `Program.mkProgramWithCmdMsg`

```fsharp
let mapCommands cmdMsg =
    match cmdMsg with
    | TimerTick -> timerCmd()

type App() as app =
    inherit Application()

    let runner =
        Program.mkProgramWithCmdMsg init update view mapCommands
        |> XamarinFormsProgram.run app
```

Note that `Program.mkProgramWithCmdMsg` doesn't do anything magic.  
It only applies `mapCommands` to any `CmdMsg` returned by `init` and `update`.  
You could achieve the exact same behavior by converting them yourself and using `Program.mkProgram`.

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

Webrequests in a Command
----
Sometimes it is needed to make some web requests. Which tool you use here does not matter. For example you could use FSharp.Data to make HttpRequests.
These are the steps that you have to do, to make it work:
1. Create a case in the message type for a successful and failure webrequests
```fsharp
type Msg =
    | LoginClicked
    | LoginSuccess
    | AuthError
```
2. Implement the Command and return the correct message
```fsharp
let authUser (username : string) (password : string) =
    async {
        do! Async.SwitchToThreadPool()
        // make your http call
        // FSharp.Data.HTTPUtil is used here
        let! response = Http.AsyncRequest
                            (url = URL, body = TextRequest """ {"username": "test", "password": "testpassword"} """,
                             httpMethod = "POST", silentHttpErrors = true)
        let r =
            match response.StatusCode with
            | 200 -> LoginSuccess
            | _ -> AuthError
        return r
    }
    |> Cmd.ofAsyncMsg
```
3. Call the Command from update e.g. when a button is clicked
```fsharp
let update msg model =
    match msg with
    | LoginClicked -> { model with IsRunning = true }, authUser model.Username model.Password // Call the Command
    | LoginSuccess ->
        { model with IsLoggedIn = true
                     IsRunning = false }, Cmd.none
    | AuthError ->
        { model with IsLoggedIn = false
                     IsRunning = false }, Cmd.none
```
4. Create your view as you need
```fsharp
match model.IsLoggedIn with
| true -> LoggedInSuccesful
| false -> LoginView
```

Platform-specific dispatch
-----

Some platform-specific features (like deep linking, memory warnings, ...) are not available in Xamarin.Forms, and need you to implement them in the corresponding app projet.  
In this case, you might want to dispatch a message from the app project to Fabulous to start a shared logic between platforms (to warn user, ...).

To allow for this kind of use case, the `dispatch` function is exposed as a `Dispatch(msg)` method by the `ProgramRunner`. By default this runner is not accessible, but you can make a read-only property to let apps access it.

```fsharp
type App() as app =
    inherit Application()

    let runner =
        Program.mkProgram init update view
        |> XamarinFormsProgram.run app

    member __.Program = runner // Add this line
```

Once done, you can access it in the app project

- Android
```fsharp
[<Activity>]
type MainActivity() =
    inherit FormsApplicationActivity()

    // Store the App instance
    let mutable _app: App option = None

    override this.OnCreate (bundle: Bundle) =
        base.OnCreate (bundle)

        Forms.Init (this, bundle)

        // Initialize the app and store its reference
        let app = new App()
        this.LoadApplication(app)
        _app <- Some app

    override this.OnTrimMemory(level) =
        // If the app is initialized, dispatch the message
        match _app with
        | Some app -> app.Program.Dispatch(Msg.ReceivedLowMemoryWarning)
        | None -> ()
```

- iOS
```fsharp
[<Register("AppDelegate")>]
type AppDelegate () =
    inherit FormsApplicationDelegate ()

    // Store the App instance
    let mutable _app: App option = None

    override this.FinishedLaunching (uiApp, options) =
        Forms.Init()

        // Initialize the app and store its reference
        let app = new AllControls.App()
        this.LoadApplication (app)
        _app <- Some app

        base.FinishedLaunching(uiApp, options)

    override this.ReceiveMemoryWarning(uiApp) =
        // If the app is initialized, dispatch the message
        match _app with
        | Some app -> app.Program.Dispatch(Msg.ReceivedLowMemoryWarning)
        | None -> ()
```
