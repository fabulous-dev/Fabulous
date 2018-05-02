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
module Init =
    let combo2 init1 init2 () = 
        let model1 = init1()
        let model2 = init2()
        (model1, model2)

    let combo3 init1 init2 init3 () = 
        let model1 = init1()
        let model2 = init2()
        let model3 = init3()
        (model1, model2, model3)

    let combo4 init1 init2 init3 init4 () = 
        let model1 = init1()
        let model2 = init2()
        let model3 = init3()
        let model4 = init4()
        (model1, model2, model3, model4)

    let combo5 init1 init2 init3 init4 init5 () =
        let model1 = init1()
        let model2 = init2()
        let model3 = init3()
        let model4 = init4()
        let model5 = init5()
        (model1, model2, model3, model4, model5)

[<RequireQualifiedAccess>]
module InitCmd =
    let combo2 init1 init2 () = 
        let model1, cmd1 = init1()
        let model2, cmd2 = init2()
        (model1, model2), Cmd.batch [cmd1; cmd2]

    let combo3 init1 init2 init3 () = 
        let model1, cmd1 = init1()
        let model2, cmd2 = init2()
        let model3, cmd3 = init3()
        (model1, model2, model3), Cmd.batch [cmd1; cmd2; cmd3]

    let combo4 init1 init2 init3 init4 () = 
        let model1, cmd1 = init1()
        let model2, cmd2 = init2()
        let model3, cmd3 = init3()
        let model4, cmd4 = init4()
        (model1, model2, model3, model4), Cmd.batch [cmd1; cmd2; cmd3; cmd4]

    let combo5 init1 init2 init3 init4 init5 () =
        let model1, cmd1 = init1()
        let model2, cmd2 = init2()
        let model3, cmd3 = init3()
        let model4, cmd4 = init4()
        let model5, cmd5 = init5()
        (model1, model2, model3, model4, model5), Cmd.batch [cmd1; cmd2; cmd3; cmd4; cmd5]


[<RequireQualifiedAccess>]
module Update =

    let combo2 (update1: Update<_, _, _>) (update2: Update<_, _, _>) : Update<_,_,_> = fun msg (model1, model2) ->
        match msg with
        | Choice1Of2 msg1 -> let newModel, cmds, extmsg = update1 msg1 model1 in (newModel, model2), Cmd.map Choice1Of2 cmds, extmsg 
        | Choice2Of2 msg2 -> let newModel, cmds, extmsg = update2 msg2 model2 in (model1, newModel), Cmd.map Choice2Of2 cmds, extmsg 

    let combo3 (update1: Update<_, _, _>) (update2: Update<_, _, _>) (update3: Update<_, _, _>) : Update<_,_,_> = fun msg (model1, model2, model3) ->
        match msg with
        | Choice1Of3 msg1 -> let newModel, cmds, extmsg = update1 msg1 model1 in (newModel, model2, model3), Cmd.map Choice1Of3 cmds, extmsg  
        | Choice2Of3 msg2 -> let newModel, cmds, extmsg = update2 msg2 model2 in (model1, newModel, model3), Cmd.map Choice2Of3 cmds, extmsg  
        | Choice3Of3 msg3 -> let newModel, cmds, extmsg = update3 msg3 model3 in (model1, model2, newModel), Cmd.map Choice3Of3 cmds, extmsg  

    let combo4 (update1: Update<_, _, _>) (update2: Update<_, _, _>) (update3: Update<_, _, _>) (update4: Update<_, _, _>) : Update<_,_,_> = fun msg (model1, model2, model3, model4) ->
        match msg with
        | Choice1Of4 msg1 -> let newModel, cmds, extmsg = update1 msg1 model1 in (newModel, model2, model3, model4), Cmd.map Choice1Of4 cmds, extmsg  
        | Choice2Of4 msg2 -> let newModel, cmds, extmsg = update2 msg2 model2 in (model1, newModel, model3, model4), Cmd.map Choice2Of4 cmds, extmsg  
        | Choice3Of4 msg3 -> let newModel, cmds, extmsg = update3 msg3 model3 in (model1, model2, newModel, model4), Cmd.map Choice3Of4 cmds, extmsg  
        | Choice4Of4 msg4 -> let newModel, cmds, extmsg = update4 msg4 model4 in (model1, model2, model3, newModel), Cmd.map Choice4Of4 cmds, extmsg  

    let combo5 (update1: Update<_, _, _>) (update2: Update<_, _, _>) (update3: Update<_, _, _>) (update4: Update<_, _, _>) (update5: Update<_, _, _>) : Update<_,_,_> = fun msg (model1, model2, model3, model4, model5) ->
        match msg with
        | Choice1Of5 msg1 -> let newModel, cmds, extmsg = update1 msg1 model1 in (newModel, model2, model3, model4, model5), Cmd.map Choice1Of5 cmds, extmsg 
        | Choice2Of5 msg2 -> let newModel, cmds, extmsg = update2 msg2 model2 in (model1, newModel, model3, model4, model5), Cmd.map Choice2Of5 cmds, extmsg 
        | Choice3Of5 msg3 -> let newModel, cmds, extmsg = update3 msg3 model3 in (model1, model2, newModel, model4, model5), Cmd.map Choice3Of5 cmds, extmsg 
        | Choice4Of5 msg4 -> let newModel, cmds, extmsg = update4 msg4 model4 in (model1, model2, model3, newModel, model5), Cmd.map Choice4Of5 cmds, extmsg 
        | Choice5Of5 msg5 -> let newModel, cmds, extmsg = update5 msg5 model5 in (model1, model2, model3, model4, newModel), Cmd.map Choice5Of5 cmds, extmsg 

    /// Reconcile external messages by turning them into changes in the composed model and/or commands
    let reconcile f (update: Update<'model,'msg,'extmsg>) : Update<'model,'msg> = fun msg model ->
        let newModel, cmds, extmsg = update msg model
        let newModel2, cmds2 = f extmsg newModel
        newModel2, Cmd.batch [cmds; cmds2]

[<RequireQualifiedAccess>]
module StaticView =

    let internal setBindingContextsUntyped (bindings: ViewBindings<'model, 'msg>) (viewModel: StaticViewModel<obj, obj>) = 
        for (bindingName, binding) in bindings do 
            match binding with 
            | BindSubModel (ViewSubModel (initf, _, _, _, _)) -> 
                let subModel = viewModel.[bindingName]
                initf subModel
            | _ -> ()

    let internal setBindingContexts (bindings: ViewBindings<'model, 'msg>) (viewModel: StaticViewModel<'model, 'msg>) = 
        for (bindingName, binding) in bindings do 
            match binding with 
            | BindSubModel (ViewSubModel (initf, _, _, _, _)) -> 
                let subModel = viewModel.[bindingName]
                initf subModel
            | _ -> ()

    let internal staticPageInitUntyped (page: Page) (bindings: ViewBindings<'model, 'msg>) =
        fun (objViewModel: obj) ->
            match objViewModel with
            | :? StaticViewModel<obj, obj> as viewModel -> 
                setBindingContextsUntyped bindings viewModel
                page.BindingContext <- objViewModel
            | _ -> failwithf "unexpected type in staticPageInitUntyped: %A" (objViewModel.GetType())

    let internal genViewName = let mutable c = 0 in fun () -> c <- c + 1; "View"+string c

    let internal apply (view: StaticView<_, _, _>) = 
        let page, bindings = view() 
        let name = genViewName()
        name, page, bindings

    let subPage (view1: StaticView<'model, 'msg, 'page>) =
        let nm1, page1, bindings1 = apply view1
        page1,
        [ nm1 |> Binding.subView (staticPageInitUntyped page1 bindings1) id id bindings1 ]

    let combo2 (view1: StaticView<'model1, 'msg1, 'page1>) (view2: StaticView<'model2, 'msg2, 'page2>) =
        let nm1, page1, bindings1 = apply view1
        let nm2, page2, bindings2 = apply view2
        (page1, page2),
        [ nm1 |> Binding.subView (staticPageInitUntyped page1 bindings1) (fun (a,_) -> a) Choice1Of2 bindings1
          nm2 |> Binding.subView (staticPageInitUntyped page1 bindings2) (fun (_,a) -> a) Choice2Of2 bindings2 ]

    let combo3 (view1: StaticView<'model1, 'msg1, 'page1>) (view2: StaticView<'model2, 'msg2, 'page2>) (view3: StaticView<'model3, 'msg3, 'page3>) = 
        let nm1, page1, bindings1 = apply view1
        let nm2, page2, bindings2 = apply view2
        let nm3, page3, bindings3 = apply view3
        (page1, page2, page3),
        [ nm1 |> Binding.subView (staticPageInitUntyped page1 bindings1) (fun (a,_,_) -> a) Choice1Of3 bindings1
          nm2 |> Binding.subView (staticPageInitUntyped page2 bindings2) (fun (_,a,_) -> a) Choice2Of3 bindings2
          nm3 |> Binding.subView (staticPageInitUntyped page3 bindings3) (fun (_,_,a) -> a) Choice3Of3 bindings3 ]

    let combo4 (view1: StaticView<'model1, 'msg1, 'page1>) (view2: StaticView<'model2, 'msg2, 'page2>) (view3: StaticView<'model3, 'msg3, 'page3>) (view4: StaticView<'model4, 'msg4, 'page4>) =
        let nm1, page1, bindings1 = apply view1
        let nm2, page2, bindings2 = apply view2
        let nm3, page3, bindings3 = apply view3
        let nm4, page4, bindings4 = apply view4
        (page1, page2, page3, page4),
        [ nm1 |> Binding.subView (staticPageInitUntyped page1 bindings1) (fun (a,_,_,_) -> a) Choice1Of4 bindings1
          nm2 |> Binding.subView (staticPageInitUntyped page2 bindings2) (fun (_,a,_,_) -> a) Choice2Of4 bindings2
          nm3 |> Binding.subView (staticPageInitUntyped page3 bindings3) (fun (_,_,a,_) -> a) Choice3Of4 bindings3
          nm4 |> Binding.subView (staticPageInitUntyped page4 bindings4) (fun (_,_,_,a) -> a) Choice4Of4 bindings4 ]

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
    /// The subscription is called once - with the initial model, but can dispatch new messages at any time.
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
        let mutable dispatchImpl = (fun msg -> failwith "do not call dispatch during initialization")
        let dispatch msg = dispatchImpl msg

        do Debug.WriteLine "run: computing static components of view"

        // Extract the static content from the view
        let viewInfo = program.view ()

        // If the view is dynamic, create the initial page
        let viewInfo, mainPage = 
            match viewInfo with 
            | Choice1Of2 (mainPage, bindings) -> Choice1Of2 (mainPage, bindings), mainPage
            | Choice2Of2 ((app: Application), contentf: _ -> _ -> XamlElement) -> 
                let pageDescription = contentf initialModel dispatch
                let mainPage = pageDescription.CreateAsPage()
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
                        let newPageDescription: XamlElement = contentf updatedModel dispatch
                        if canReuseDefault prevPageDescription newPageDescription then
                            newPageDescription.UpdateIncremental (prevPageDescription, app.MainPage)
                        else
                            app.MainPage <- newPageDescription.CreateAsPage()
                        //app.Properties.["model"] <- updatedModel
                        Choice2Of2 (newPageDescription, app, contentf)
                lastViewData <- Some viewData
                      
        do 
           dispatchImpl <- (fun msg -> Device.BeginInvokeOnMainThread(fun () -> processMsg msg))

           Debug.WriteLine "updating the initial view"

           updateView initialModel 

           Debug.WriteLine "dispatching initial commands"
           for sub in (program.subscribe initialModel @ cmd) do
                sub dispatch

        member __.InitialMainPage = mainPage

        member __.Model 
            with get () = lastModel 
            and set model = 
                Debug.WriteLine "updating the view after setting the model"
                lastModel <- model
                updateView model


    /// Creates the view model for the given page and starts the Elmish dispatch loop for the matching program
    let run program = ProgramRunner(program)

    /// Add navigation to an application, used only for Static Xaml.
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
