// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace StaticViewCounterApp

open Fabulous.Core
open Fabulous.StaticView
open Xamarin.Forms

type Model = 
  { Count : int
    Step : int }

type Msg = 
    | Increment 
    | Decrement 
    | Reset
    | SetStep of int

type StaticViewCounterApp () = 
    inherit Application ()

    let init () = { Count = 0; Step = 3 }

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + model.Step }
        | Decrement -> { model with Count = model.Count - model.Step }
        | Reset -> init ()
        | SetStep n -> { model with Step = n }

    let view () =
        CounterPage (),
        [ "CounterValue" |> Binding.oneWay (fun m -> m.Count)
          "CounterValue2" |> Binding.oneWay (fun m -> m.Count + 1)
          "IncrementCommand" |> Binding.msg Increment
          "DecrementCommand" |> Binding.msg Decrement
          "ResetCommand" |> Binding.msgIf Reset (fun m -> m <> init ())
          "ResetVisible" |> Binding.oneWay (fun m ->  m <> init ())
          "StepValue" |> Binding.twoWay (fun m -> double m.Step) (fun v -> SetStep (int (v + 0.5))) ]

    do
        let runner = 
            Program.mkSimple init update view
#if DEBUG
            |> Program.withConsoleTrace
#endif
            |> Program.runWithStaticView
        let page = runner.InitialMainPage

        do PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(page.On<PlatformConfiguration.iOS>(), true) |> ignore
        base.MainPage <- page
