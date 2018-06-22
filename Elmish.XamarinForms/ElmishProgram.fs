// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
namespace Elmish.XamarinForms

open System
open System.Diagnostics
open Elmish.XamarinForms
open Elmish.XamarinForms.StaticViews
open Elmish.XamarinForms.DynamicViews
open Xamarin.Forms

/// Represents a model when you don't have a model.  A Clayton's model.
type NoModel = 
    | NoModel

type Update<'model, 'msg> = 'msg -> 'model -> 'model * Cmd<'msg>
type Update<'model, 'msg, 'extmsg> = 'msg -> 'model -> 'model * Cmd<'msg> * 'extmsg
type StaticView<'model, 'msg, 'page> = unit -> 'page * ViewBindings<'model, 'msg>
type DynamicView<'model, 'msg, 'page> = unit -> 'page * ('model -> 'msg -> Xamarin.Forms.View)

[<AutoOpen>]
module Values =
    let NoCmd<'a> : Cmd<'a> = Cmd.none
    let mutable currentPage : Page = null

[<RequireQualifiedAccess>]
/// For navigation in the half-elmish model
module Nav =

    // TODO: modify the Elmish framework we use to remove this global state and pass it into all commands??
    let mutable globalNavMap : Map<System.IComparable, Page> = Map.empty

    /// Push new location into history and navigate there
    let push (fromPageTag: ('navTarget :> System.IComparable)) (toPageTag: ('navTarget :> System.IComparable)) : Cmd<_> =
        [ fun _ -> 
            let fromPage = globalNavMap.[fromPageTag]
            let toPage = globalNavMap.[toPageTag]
            let nav = fromPage.Navigation
            nav.PushAsync toPage |> ignore ]

    /// Push new location into history and navigate there
    let pushModal (fromPageTag: ('navTarget :> System.IComparable)) (toPageTag: ('navTarget :> System.IComparable)) : Cmd<_> =
        [ fun _ -> 
            let fromPage = globalNavMap.[fromPageTag]
            let toPage = globalNavMap.[toPageTag]
            let nav = fromPage.Navigation
            nav.PushModalAsync toPage |> ignore ]

    let popToRoot (fromPageTag: ('navTarget :> System.IComparable)) : Cmd<_> =
        [ fun _ -> 
            let fromPage = globalNavMap.[fromPageTag]
            let nav = fromPage.Navigation
            nav.PopToRootAsync() |> ignore ]

    let popModal (fromPageTag: ('navTarget :> System.IComparable)) : Cmd<_> =
        [ fun _ -> 
            let fromPage = globalNavMap.[fromPageTag]
            let nav = fromPage.Navigation
            nav.PopModalAsync() |> ignore ]

    let pop (fromPageTag: ('navTarget :> System.IComparable)) : Cmd<_> =
        [ fun _ -> 
            let fromPage = globalNavMap.[fromPageTag]
            let nav = fromPage.Navigation
            nav.PopAsync() |> ignore ]


[<RequireQualifiedAccess>]
/// For combining static view functions in the half-elmish model
module StaticView =

    let internal setBindingContexts (bindings: ViewBindings<'model, 'msg>) (viewModel: StaticViewModel<'model, 'msg>) = 
        for (bindingName, binding) in bindings do 
            match binding with 
            | BindSubModel (ViewSubModel (initf, _, _, _, _)) -> 
                let subModel = viewModel.[bindingName]
                initf subModel
            | _ -> ()

/// Program type captures various aspects of program behavior
type Program<'model, 'msg, 'view> = 
    { init : unit -> 'model * Cmd<'msg>
      update : 'msg -> 'model -> 'model * Cmd<'msg>
      subscribe : 'model -> Cmd<'msg>
      view : 'view
      debug : bool
      onError : (string*exn) -> unit }

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

    /// Starts the Elmish dispatch loop for the page with the given Elmish program
    type ProgramRunner<'model, 'msg>(program: Program<'model, 'msg, _>)  = 

        do Debug.WriteLine "run: computing initial model"

        // Get the initial model
        let (initialModel,cmd) = program.init ()

        let mutable lastModel = initialModel
        let mutable lastViewData = None
        let dispatch = ProgramDispatch<'msg>.Dispatch

        do Debug.WriteLine "run: computing static components of view"

        // Extract the static content from the view
        let viewInfo = program.view ()

        // If the view is dynamic, create the initial page
        let viewInfo, mainPage = 
            match viewInfo with 
            | Choice1Of2 (mainPage, bindings) -> Choice1Of2 (mainPage, bindings), mainPage
            | Choice2Of2 ((app: Application), contentf: _ -> _ -> ViewElement) -> 
                let pageDescription = contentf initialModel dispatch
                let pageObj = pageDescription.Create()
                let mainPage = 
                    match pageObj with 
                    | :? Page as page -> page
                    | _ -> failwithf "Incorrect model type: expected a page but got a %O" (pageObj.GetType())
                app.MainPage <- mainPage
                //app.Properties.["model"] <- initialModel
                Choice2Of2 (pageDescription, app, contentf), mainPage

        // Start Elmish dispatch loop  
        let rec processMsg msg = 
            try
                let (updatedModel,newCommands) = program.update msg lastModel
                lastModel <- updatedModel
                try 
                   updateView updatedModel 
                with ex ->
                    program.onError ("Unable to update view:", ex)
                try 
                    newCommands |> List.iter (fun sub -> sub dispatch)
                with ex ->
                    program.onError ("Error executing commands:", ex)
            with ex ->
                program.onError ("Unable to process a message:", ex)

        and updateView updatedModel = 
            match lastViewData with
            | None -> 

                // Construct the binding context for the view model

                let viewData = 
                    match viewInfo with 
                    | Choice1Of2 (mainPage, bindings) -> 
                        let viewModel = StaticViewModel (updatedModel, dispatch, bindings, program.debug)
                        StaticView.setBindingContexts bindings viewModel
                        mainPage.BindingContext <- box viewModel
                        Choice1Of2 (mainPage, bindings, viewModel)
                    | Choice2Of2 (pageDescription, mainPage, contentf) -> 
                        Choice2Of2 (pageDescription, mainPage, contentf)

                lastViewData <- Some viewData

            | Some prevViewData ->
                let viewData = 
                    match prevViewData with 
                    | Choice1Of2 (page, bindings, viewModel) -> 
                        viewModel.UpdateModel updatedModel
                        Choice1Of2 (page, bindings, viewModel)
                    | Choice2Of2 (prevPageDescription, app, contentf) -> 
                        let newPageDescription: ViewElement = contentf updatedModel dispatch
                        if canReuseChild prevPageDescription newPageDescription then
                            newPageDescription.UpdateIncremental (prevPageDescription, app.MainPage)
                        else
                            let pageObj = newPageDescription.Create()
                            match pageObj with 
                            | :? Page as page -> app.MainPage <- page
                            | _ -> failwithf "Incorrect model type: expected a page but got a %O" (pageObj.GetType())

                        Choice2Of2 (newPageDescription, app, contentf)
                lastViewData <- Some viewData
                      
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

    /// Starts the Elmish dispatch loop for the page with the given Elmish program
    and internal ProgramDispatch<'msg>()  = 
        /// We store the current dispatch function for the running Elmish progream as a 
        /// static-global because we want old view elements stored in the `dependsOn` global table
        /// to be recyclable on resumption (when a new ProgramRunner gets created).
        static let mutable dispatchImpl = (fun (msg: 'msg) -> failwith "do not call dispatch during initialization" : unit)

        static let dispatch = id (fun msg -> dispatchImpl msg)

        static member Dispatch with get () = dispatch and set v = dispatchImpl <- v

    /// Creates the view model for the given page and starts the Elmish dispatch loop for the matching program
    let run program = ProgramRunner(program)

    /// Add navigation to an application, used only for Half-Elmish Static Xaml.
    let withNavigation (program: Program<_,_,_>) = 
        { init = program.init
          update = program.update
          subscribe = program.subscribe
          onError = program.onError
          debug = program.debug
          view = (fun () -> 
              let page, contents, navMap = program.view ()
              Debug.WriteLine "setting global navigation map"
              // TODO: modify the Elmish framework we use to remove this global state and pass it into all commands??
              Nav.globalNavMap <- (navMap |> List.map (fun (tg, page) -> ((tg :> System.IComparable), page)) |> Map.ofList)
              page, contents  )}

    /// Assert that the program uses static views
    let withStaticView (program: Program<'model, 'msg, _>) = 
        { init = program.init
          update = program.update
          subscribe = program.subscribe
          onError = program.onError
          debug = program.debug
          view = (fun () -> 
              let page, bindings = program.view ()
              Choice1Of2 ((page :> Page), bindings)) }

    /// Set debugging to true
    let withDebug program = 
        { program with debug = true }

    /// Add dynamic views associated with a specific application
    let withDynamicView app (program: Program<'model, 'msg, _>) = 
        { init = program.init
          update = program.update
          debug = program.debug
          subscribe = program.subscribe
          onError = program.onError
          view = (fun () -> Choice2Of2 ((app :> Application), program.view)) }

    /// Run the app with ddynamic views for a specific application
    let runWithDynamicView app (program: Program<'model, 'msg, _>) = 
        program 
        |> withDynamicView app
        |> run
