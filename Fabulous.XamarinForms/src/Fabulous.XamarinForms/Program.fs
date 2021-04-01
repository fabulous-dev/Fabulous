// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms

open System
open Fabulous
open Fabulous.Tracing
open Xamarin.Forms

/// Program module - functions to manipulate program instances
[<RequireQualifiedAccess>]
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module XamarinFormsProgram =
    let private onError (text: string) (ex: exn) =
        Console.WriteLine(sprintf "%s: %A" text ex)

    let private syncDispatch (dispatch: 'msg -> unit) =
        fun msg ->
            Device.BeginInvokeOnMainThread(fun () -> dispatch msg)

    let private syncAction (fn: unit -> unit) =
        fun () ->
            Device.BeginInvokeOnMainThread (fun () -> fn())

    let mkComponent
        (init: 'arg -> 'model * Cmd<'msg> * 'externalMsg list)
        (update: 'msg -> 'model -> 'model * Cmd<'msg> * 'externalMsg list)
        (view: 'model -> Dispatch<'msg> -> #IViewElement) =

        { init = init
          update = update
          view = (fun model dispatch -> (view model dispatch) :> IViewElement)
          canReuseView = canReuseView
          syncDispatch = syncDispatch
          syncAction = syncAction
          subscribe = (fun _ _ -> null)
          traceLevel = TraceLevel.None
          trace = (fun _ _ -> ())
          onError = onError }

    let mkComponentWithCmdMsg
        (init: 'arg -> 'model * 'cmdMsg list * 'externalMsg list)
        (update: 'msg -> 'model -> 'model * 'cmdMsg list * 'externalMsg list)
        (view: 'model -> Dispatch<'msg> -> #IViewElement)
        (mapToCmd: 'cmdMsg -> Cmd<'msg>) =

        let convert = fun (model, cmdMsgs, externalMsgs) -> model, (cmdMsgs |> List.map mapToCmd |> Cmd.batch), externalMsgs
        mkComponent (fun arg -> init arg |> convert) (fun msg model -> update msg model |> convert) view

    /// Simple program that produces only new state with `init` and `update`.
    let mkSimple (init : 'arg -> 'model) (update : 'msg -> 'model -> 'model) (view : 'model -> Dispatch<'msg> -> #IViewElement) : RunnerDefinition<'arg, 'msg, 'model, unit> =
        mkComponent
            (fun arg -> let model = init arg in model, Cmd.none, [])
            (fun msg model -> let model = update msg model in model, Cmd.none, [])
            view

    /// Typical program, new commands are produced by `init` and `update` along with the new state.
    let mkProgram (init : 'arg -> 'model * Cmd<'msg>) (update : 'msg -> 'model -> 'model * Cmd<'msg>) (view : 'model -> Dispatch<'msg> -> #IViewElement) : RunnerDefinition<'arg, 'msg, 'model, unit> =
        mkComponent
            (fun arg -> let model, cmd = init arg in model, cmd, [])
            (fun msg model -> let model, cmd = update msg model in model, cmd, [])
            view

    /// Typical program, new commands are produced discriminated unions returned by `init` and `update` along with the new state.
    let mkProgramWithCmdMsg (init: 'arg -> 'model * 'cmdMsg list) (update: 'msg -> 'model -> 'model * 'cmdMsg list) (view: 'model -> Dispatch<'msg> -> #IViewElement) (mapToCmd: 'cmdMsg -> Cmd<'msg>) : RunnerDefinition<'arg, 'msg, 'model, unit> =
        mkComponentWithCmdMsg
            (fun arg -> let model, cmdMsgs = init arg in model, cmdMsgs, [])
            (fun msg model -> let model, cmdMsgs = update msg model in model, cmdMsgs, [])
            view
            mapToCmd

    let runWith (element: Element) (arg: 'arg) (definition: RunnerDefinition<'arg, 'msg, 'model, 'externalMsg>) =
        let runner = Runner() :> IRunner<'arg, 'msg, 'model, 'externalMsg>
        runner.Start(definition, arg)
        runner.AttachView(element, ValueNone)
        runner

    let run (element: Element) (definition: RunnerDefinition<unit, 'msg, 'model, 'externalMsg>) =
        runWith element () definition