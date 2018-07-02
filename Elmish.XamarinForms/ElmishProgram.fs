// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
namespace Elmish.XamarinForms

open System
open System.Diagnostics
open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews
open Xamarin.Forms

[<AutoOpen>]
module Values =
    let NoCmd<'a> : Cmd<'a> = Cmd.none

/// We store the current dispatch function for the running Elmish program as a 
/// static-global thunk because we want old view elements stored in the `dependsOn` global table
/// to be recyclable on resumption (when a new ProgramRunner gets created).
type internal ProgramDispatch<'msg>()  = 
    static let mutable dispatchImpl = (fun (_msg: 'msg) -> failwith "do not call dispatch during initialization" : unit)

    static let dispatch = id (fun msg -> dispatchImpl msg)

    static member Dispatch with get () = dispatch and set v = dispatchImpl <- v

/// Program type captures various aspects of program behavior
type Program<'model, 'msg, 'view> = 
    { init : unit -> 'model * Cmd<'msg>
      update : 'msg -> 'model -> 'model * Cmd<'msg>
      subscribe : 'model -> Cmd<'msg>
      view : 'view
      debug : bool
      onError : (string*exn) -> unit }

/// Starts the Elmish dispatch loop for the page with the given Elmish program
type ProgramRunner<'model, 'msg>(app: Application, program: Program<'model, 'msg, _>)  = 

    do Debug.WriteLine "run: computing initial model"

    // Get the initial model
    let (initialModel,cmd) = program.init ()

    let mutable lastModel = initialModel
    let mutable lastViewDataOpt = None
    let dispatch = ProgramDispatch<'msg>.Dispatch

    // If the view is dynamic, create the initial page
    let viewInfo, mainPage = 
        let pageDescription : ViewElement = program.view initialModel dispatch
        let pageObj = pageDescription.Create()
        let mainPage = 
            match pageObj with 
            | :? Page as page -> page
            | _ -> failwithf "Incorrect model type: expected a page but got a %O" (pageObj.GetType())
        app.MainPage <- mainPage
        //app.Properties.["model"] <- initialModel
        (pageDescription), mainPage

    // Start Elmish dispatch loop  
    let rec processMsg msg = 
        try
            let (updatedModel,newCommands) = program.update msg lastModel
            lastModel <- updatedModel
            try 
                updateView updatedModel 
            with ex ->
                program.onError ("Unable to update view:", ex)
            for sub in newCommands do
                try 
                    sub dispatch
                with ex ->
                    program.onError ("Error executing commands:", ex)
        with ex ->
            program.onError ("Unable to process a message:", ex)

    and updateView updatedModel = 
        match lastViewDataOpt with
        | None -> 
            lastViewDataOpt <- Some viewInfo

        | Some prevPageDescription ->
            let newPageDescription: ViewElement = program.view updatedModel dispatch
            if canReuseChild prevPageDescription newPageDescription then
                newPageDescription.UpdateIncremental (prevPageDescription, app.MainPage)
            else
                let pageObj = newPageDescription.Create()
                match pageObj with 
                | :? Page as page -> app.MainPage <- page
                | _ -> failwithf "Incorrect model type: expected a page but got a %O" (pageObj.GetType())

            lastViewDataOpt <- Some newPageDescription
                      
    do 
        // Set up the global dispatch function
        ProgramDispatch<'msg>.Dispatch <- (fun msg -> Device.BeginInvokeOnMainThread(fun () -> processMsg msg))

        Debug.WriteLine "updating the initial view"

        updateView initialModel 

        Debug.WriteLine "dispatching initial commands"
        for sub in (program.subscribe initialModel @ cmd) do
            sub dispatch

    member __.InitialMainPage = mainPage

    member __.CurrentModel = lastModel 

    /// Set the current model, e.g. on resume
    member __.SetCurrentModel(model, cmd: Cmd<_>) =
        Debug.WriteLine "updating the view after setting the model"
        lastModel <- model
        updateView model
        for sub in program.subscribe model @ cmd do
            sub dispatch

/// Program module - functions to manipulate program instances
[<RequireQualifiedAccess>]
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Program =
    let internal onError (text: string, ex: exn) = 
        Debug.WriteLine (sprintf "%s: %A" text ex)

    /// Typical program, new commands are produced by `init` and `update` along with the new state.
    let mkProgram init update view =
        { init = init
          update = update
          view = view
          subscribe = fun _ -> Cmd.none
          debug = false
          onError = onError }

    /// Simple program that produces only new state with `init` and `update`.
    let mkSimple init update view = 
        mkProgram (fun arg -> init arg, Cmd.none) (fun msg model -> update msg model, Cmd.none) view

    /// Subscribe to external source of events.
    /// The subscription is called once - with the initial (or resumed) model, but can dispatch new messages at any time.
    let withSubscription (subscribe : 'model -> Cmd<'msg>) (program: Program<'model, 'msg, 'view>) =
        let sub model =
            Cmd.batch [ program.subscribe model
                        subscribe model ]
        { program with subscribe = sub }

    /// Trace all the updates to the console
    let withConsoleTrace (program: Program<'model, 'msg, 'view>) =
        let traceInit () =
            let initModel,cmd = program.init ()
            Debug.WriteLine (sprintf "Initial state: %0A" initModel)
            initModel,cmd

        let traceUpdate msg model =
            Debug.WriteLine (sprintf "New message: %0A" msg)
            let newModel,cmd = program.update msg model
            Debug.WriteLine (sprintf "Updated state: %0A" newModel)
            newModel,cmd

        { program with
            init = traceInit 
            update = traceUpdate }

    /// Trace all the messages as they update the model
    let withTrace trace (program: Program<'model, 'msg, 'view>) =
        { program
            with update = fun msg model -> trace msg model; program.update msg model}

    /// Handle dispatch loop exceptions
    let withErrorHandler onError (program: Program<'model, 'msg, 'view>) =
        { program
            with onError = onError }

    /// Set debugging to true
    let withDebug program = 
        { program with debug = true }

    /// Run the app with ddynamic views for a specific application
    let runWithDynamicView (app : Application) (program: Program<'model, 'msg, _>) = 
        ProgramRunner(app, program)






    /// Creates the view model for the given page and starts the Elmish dispatch loop for the matching program
    [<Obsolete("Please use Program.runWithDynamicView", true)>]
    let run app program = ProgramRunner(app,program)

    /// Add dynamic views associated with a specific application
    [<Obsolete("Please use Program.runWithDynamicView", true)>]
    let withDynamicView _app (_program: Program<'model, 'msg, _>) = failwith ""

    /// Add dynamic views associated with a specific application
    [<Obsolete("Please open Elmish.XamarinForms.StaticViews and use Program.runWithStaticView", true)>]
    let withStaticView (_program: Program<'model, 'msg, _>) = failwith ""

