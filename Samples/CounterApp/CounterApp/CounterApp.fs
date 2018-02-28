namespace CounterApp

open Elmish
open Elmish.XamarinForms
open Xamarin.Forms

type Model = 
  { Count : int
    Step : int }

type Msg = 
    | Increment 
    | Decrement 
    | Reset
    | SetStep of int

type CounterApp () = 
    inherit Application ()

    let init () = { Count = 0; Step = 3 }

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + model.Step }
        | Decrement -> { model with Count = model.Count - model.Step }
        | Reset -> init ()
        | SetStep n -> { model with Step = n }

    let view _ _ =
        [ "CounterValue" |> Binding.oneWay (fun m -> m.Count)
          "CounterValue2" |> Binding.oneWay (fun m -> m.Count + 1)
          "IncrementCommand" |> Binding.cmd (fun _ _ -> Cmd.ofMsg Increment)
          "DecrementCommand" |> Binding.cmd (fun _ _ -> Cmd.ofMsg Decrement)
          "ResetCommand" |> Binding.cmdIf (fun _ _ -> Cmd.ofMsg Reset) (fun _ m -> m <> init ())
          "ResetVisible" |> Binding.oneWay (fun m ->  m <> init ())
          "StepValue" |> Binding.twoWay (fun m -> double m.Step) (fun v m -> v |> ((+)0.5) |> int |> SetStep |> Cmd.ofMsg ) ]

    let page = CounterApp.CounterPage ()

    do
        Program.mkSimple init update view
        |> Program.withConsoleTrace
        |> Program.runPage page

        base.MainPage <- page
