// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.

namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

type XamarinFormsHost(app: Application) =
    interface IHost with
        member __.GetRootView() =
            match app.MainPage with
            | null -> failwith "No root view"
            | rootView -> rootView :> obj

        member __.SetRootView(rootView) =
            match rootView with
            | :? Page as page -> app.MainPage <- page
            | _ -> failwithf "Incorrect model type: expected a page but got a %O" (rootView.GetType())

/// Program module - functions to manipulate program instances
[<RequireQualifiedAccess>]
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module XamarinFormsProgram =
    let private syncDispatch (dispatch: 'msg -> unit) =
        fun msg ->
            Device.BeginInvokeOnMainThread(fun () -> dispatch msg)

    let private syncAction (fn: unit -> unit) =
        fun () ->
            Device.BeginInvokeOnMainThread (fun () -> fn())

    let private setXamarinFormsHandlers program =
        program
        |> Program.withCanReuseView ViewHelpers.canReuseView
        |> Program.withSyncDispatch syncDispatch
        |> Program.withSyncAction syncAction

    /// Typical program, new commands are produced by `init` and `update` along with the new state.
    let mkProgram (init : 'arg -> 'model * Cmd<'msg>) (update : 'msg -> 'model -> 'model * Cmd<'msg>) (view : 'model -> Dispatch<'msg> -> ViewElement) =
        Fabulous.Program.mkProgram init update view
        |> setXamarinFormsHandlers

    /// Simple program that produces only new state with `init` and `update`.
    let mkSimple (init : 'arg -> 'model) (update : 'msg -> 'model -> 'model) (view : 'model -> Dispatch<'msg> -> ViewElement) =
        Fabulous.Program.mkSimple init update view
        |> setXamarinFormsHandlers

    /// Typical program, new commands are produced discriminated unions returned by `init` and `update` along with the new state.
    let mkProgramWithCmdMsg (init: 'arg -> 'model * 'cmdMsg list) (update: 'msg -> 'model -> 'model * 'cmdMsg list) (view: 'model -> Dispatch<'msg> -> ViewElement) (mapToCmd: 'cmdMsg -> Cmd<'msg>) =
        Fabulous.Program.mkProgramWithCmdMsg init update view mapToCmd
        |> setXamarinFormsHandlers

    let runWith app arg program =
        let host = XamarinFormsHost(app)

        program
        |> setXamarinFormsHandlers // TODO: Kept for not breaking existing apps. Need to be removed later
        |> Program.runWithFabulous host arg

    let run app program =
        runWith app () program