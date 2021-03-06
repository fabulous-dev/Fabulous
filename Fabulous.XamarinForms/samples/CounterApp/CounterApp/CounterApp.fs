// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace CounterApp

open System.Diagnostics
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

open Counter
open Timer
open NameForm

module App =
    type Model =
      { TimerEnabled: bool
        FullName: string }

    type Msg =
        | TimerToggled of bool
        | NameFormMsg of NameForm.ExternalMsg

    let init () = { TimerEnabled = false; FullName = "" }

    let update msg model =
        match msg with
        | TimerToggled value -> { model with TimerEnabled = value }
        | NameFormMsg msg ->
            match msg with
            | NameForm.ExternalMsg.FullNameChanged value -> { model with FullName = value }

    let view (model: Model) dispatch =
        View.Application(
            View.ContentPage(
                View.StackLayout(
                    padding = Thickness 30.0,
                    verticalOptions = LayoutOptions.Center,
                    spacing = 30.,
                    children = [
                        View.Switch(
                            isToggled = model.TimerEnabled,
                            toggled = fun x -> dispatch (TimerToggled x.Value)
                        )
                        
                        if not model.TimerEnabled then
                            View.Grid([
                                View.Label("Hello")
                            ])
                        else
                            View.StackLayout(
                                backgroundColor = Color.LightBlue,
                                children = [
                                    View.Timer(
                                        key = "timer",
                                        state = { IsEnabled = model.TimerEnabled }
                                    )
                                ]
                            )
                        
//                        View.Grid(
//                            backgroundColor = Color.LightGreen,
//                            children = [
//                                View.Counter()
//                            ]
//                        )
//
//                        View.Grid(
//                            backgroundColor = Color.Yellow,
//                            children = [
//                                View.Counter()
//                            ]
//                        )
//
//                        View.StackLayout(
//                            orientation = StackOrientation.Horizontal,
//                            children = [
//                                View.Switch(
//                                    isToggled = model.TimerEnabled,
//                                    toggled = fun x -> dispatch (TimerToggled x.Value)
//                                )
//                                View.Label("Enable timer")
//                            ]
//                        )
//
//                        View.StackLayout(
//                            backgroundColor = Color.LightBlue,
//                            children = [
//                                View.Timer({ IsEnabled = model.TimerEnabled })
//                            ]
//                        )
//
//                        View.Label(sprintf "Component values: %s" model.FullName)
//
//                        View.StackLayout(
//                            backgroundColor = Color.LightSalmon,
//                            children = [
//                                View.NameForm(fun msg -> dispatch (NameFormMsg msg))
//                            ]
//                        )
                    ]
                )
            )
        )

    let program =
        XamarinFormsProgram.mkSimple init update view
#if DEBUG
        |> Program.withTraceLevel Tracing.TraceLevel.Info
        |> Program.withConsoleTrace
#endif

type CounterApp () as app =
    inherit Application ()

    let _ =
        App.program
        |> XamarinFormsProgram.run app