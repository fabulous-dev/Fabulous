// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.

namespace Fabulous.XamarinForms

open Elmish
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

module Program =
    let private syncDispatch (dispatch: 'msg -> unit) =
        fun msg ->
            Device.BeginInvokeOnMainThread(fun () -> dispatch msg)

    let runWithXamarinForms app (program: Program<unit, 'model, 'msg, ViewElement>) =
        let host = XamarinFormsHost(app)

        program
        |> Program.withFabulous host ViewHelpers.canReuseView
        |> Program.withSyncDispatch syncDispatch
        |> Program.run