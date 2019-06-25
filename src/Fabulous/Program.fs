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
    member __.OnError =
        let mutable value = ignore
        Program.mapErrorHandler (fun onError -> value <- onError; onError) program |> ignore
        value

type FabulousProgram<'model, 'msg> = Program<unit, 'model, 'msg, ViewElement>

/// Starts the Elmish dispatch loop for the page with the given Elmish program
type ProgramRunner<'model, 'msg>(host: IHost, canReuseView: ViewElement -> ViewElement -> bool, program: FabulousProgram<'model, 'msg>) =

    let mutable lastModelOpt = None
    let mutable lastViewDataOpt = None
    
    let programAccessor = ProgramAccessor(program)

    member __.Host = host
    member __.CanReuseView = canReuseView
    member __.Program = program
    
    member __.CurrentModel =
        match lastModelOpt with
        | None -> failwith "No current model"
        | Some lastModel -> lastModel

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
        
    let replaceCurrent (runner: ProgramRunner<'model, 'msg>) program =
        // TODO: Need a way to stop the previous loop
        runFabulous runner.Host runner.CanReuseView program |> ignore
        
/// Program module - functions to manipulate program instances
[<RequireQualifiedAccess>]
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Program =
    /// Typical program, new commands are produced discriminated unions returned by `init` and `update` along with the new state.
    let mkProgramWithCmdMsg (init: unit -> 'model * 'cmdMsg list) (update: 'msg -> 'model -> 'model * 'cmdMsg list) (view: 'model -> ('msg -> unit) -> ViewElement) (mapToCmd: 'cmdMsg -> Cmd<'msg>) : FabulousProgram<'model, 'msg> =
        let convert = fun (model, cmdMsgs) -> model, (cmdMsgs |> List.map mapToCmd |> Cmd.batch)
        Program.mkProgram (fun arg -> init arg |> convert) (fun msg model -> update msg model |> convert) view