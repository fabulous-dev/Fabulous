// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous

open Elmish

/// Representation of the host framework with access to the root view to update (e.g. Xamarin.Forms.Application)
type IHost =
    /// Gets a reference to the root view item (e.g. Xamarin.Forms.Application.MainPage)
    abstract member GetRootView : unit -> obj
    /// Sets a new instance of the root view item (e.g. Xamarin.Forms.Application.MainPage)
    abstract member SetRootView : obj -> unit

/// Starts the Elmish dispatch loop for the page with the given Elmish program
type ProgramRunner<'model, 'msg>(host: IHost, canReuseView: ViewElement -> ViewElement -> bool, program: Program<unit, 'model, 'msg, ViewElement>) =

    let mutable alternativeRunnerOpt = None
    let mutable lastModelOpt = None
    let mutable lastViewDataOpt = None

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
                    //program.onError ("Unable to evaluate view:", ex)
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
module Program =
    let withFabulous host canReuseView program =
        let runner = ProgramRunner(host, canReuseView, program)

        let setState model dispatch =
            runner.UpdateView (model, dispatch)

        program |> Program.withSetState setState