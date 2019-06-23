// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous

open Elmish

/// Representation of the host framework with access to the root view to update (e.g. Xamarin.Forms.Application)
type IHost =
    /// Gets a reference to the root view item (e.g. Xamarin.Forms.Application.MainPage)
    abstract member GetRootView : unit -> obj
    /// Sets a new instance of the root view item (e.g. Xamarin.Forms.Application.MainPage)
    abstract member SetRootView : obj -> unit
    
type private ProgramAccessor<'model, 'msg>(program: Program<unit, 'model, 'msg, ViewElement>) =
    let mutable dispatchOpt : ('msg -> unit) option = None
    let mutable onErrorOpt : (string * exn -> unit) option = None
    
    member __.Dispatch(msg) =
        let dispatch =
            Option.defaultWith (fun () ->
                    let mutable value = ignore
                    Program.withSyncDispatch (fun dispatch -> value <- dispatch; dispatch) program |> ignore
                    dispatchOpt <- Some value
                    value
                ) dispatchOpt
            
        dispatch msg
        
    member __.OnError(message) =
        let onError =
            Option.defaultWith (fun () ->
                    let mutable value = ignore
                    Program.mapErrorHandler (fun onError -> value <- onError; onError) program |> ignore
                    onErrorOpt <- Some value
                    value
                ) onErrorOpt
            
        onError message

/// Starts the Elmish dispatch loop for the page with the given Elmish program
type ProgramRunner<'model, 'msg>(host: IHost, canReuseView: ViewElement -> ViewElement -> bool, program: Program<unit, 'model, 'msg, ViewElement>) =

    let mutable alternativeRunnerOpt = None
    let mutable lastModelOpt = None
    let mutable lastViewDataOpt = None
    
    let programAccessor = ProgramAccessor(program)

    member __.CurrentModel =
        match lastModelOpt with
        | None -> failwith "No current model"
        | Some lastModel -> lastModel
        
    member __.Dispatch(msg) = programAccessor.Dispatch(msg)

    member __.UpdateView (updatedModel, dispatch) =
        lastModelOpt <- Some updatedModel

        match lastViewDataOpt with
        | None ->
            let newRootElement = Program.view program updatedModel dispatch
            let rootView = newRootElement.Create()
            host.SetRootView(rootView)
            lastViewDataOpt <- Some newRootElement

        | Some prevPageElement ->
            let newPageElement = 
                try Program.view program updatedModel dispatch
                with ex ->
                    programAccessor.OnError ("Unable to evaluate view:", ex)
                    prevPageElement

            if canReuseView prevPageElement newPageElement then
                let rootView = host.GetRootView()
                newPageElement.UpdateIncremental (prevPageElement, rootView)
            else
                let pageObj = newPageElement.Create()
                host.SetRootView(pageObj)

            lastViewDataOpt <- Some newPageElement

    member runner.ChangeProgram (newProgram: Program<unit, obj, obj, ViewElement>) =
        let alternativeRunner = ProgramRunner(host, canReuseView, newProgram)
        alternativeRunnerOpt <- Some alternativeRunner

/// Program module - functions to manipulate program instances
[<RequireQualifiedAccess>]
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module FabulousProgram =
    let runWith host canReuseView arg program =
        let runner = ProgramRunner(host, canReuseView, program)

        let setState model dispatch =
            runner.UpdateView (model, dispatch)

        program
        |> Program.withSetState setState
        |> Program.runWith arg
        
        runner
        
    let runFabulous host canReuseView program =
        runWith host canReuseView () program