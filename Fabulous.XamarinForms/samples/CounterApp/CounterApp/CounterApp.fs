// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace CounterApp

open System.Diagnostics
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

open Counter
open Timer
open NameForm


module TestCell =
    type Model =
        { Value: int }
        
    let init value =
        { Value = value }
    
    let view model dispatch =
        View.Grid([
            View.Label(
                text = $"Cell {model.Value}",
                margin = Thickness(100.)
            )
        ])
        
    let program = XamarinFormsProgram.mkSimple init (fun (msg: unit) model -> model) view
    
    type Fabulous.XamarinForms.View with
        static member inline TestCell(value) =
            View.ContentView(
                Component.forProgramWithArgs(
                    $"Cell-{value}",
                    program,
                    value
                )
            )

open TestCell

module App =
    type Model =
      { Values: int list }

    type Msg =
        | Nothing

    let init () =
        { Values = List.init 100 id }

    let update msg model =
        match msg with
        | Nothing -> model

    let view (model: Model) dispatch =
        View.Application(
            View.ContentPage(
                View.CollectionView([
                    for value in model.Values do
                        View.TestCell(value)
                ])
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