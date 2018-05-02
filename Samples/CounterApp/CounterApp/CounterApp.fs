// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
namespace CounterApp

open Elmish
open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews
open Xamarin.Forms

module App = 
    type Model = 
      { Count : int
        Step : int
        TimerOn: bool }

    type Msg = 
        | Increment 
        | Decrement 
        | Reset
        | SetStep of int
        | TimerToggled of bool
        | TimedTick

    let initModel = { Count = 0; Step = 1; TimerOn=false }

    let init () = initModel, Cmd.none

    let timerCmd = 
        async { do! Async.Sleep 200
                return TimedTick }
        |> Cmd.ofAsyncMsg

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + model.Step }, Cmd.none
        | Decrement -> { model with Count = model.Count - model.Step }, Cmd.none
        | Reset -> init ()
        | SetStep n -> { model with Step = n }, Cmd.none
        | TimerToggled on -> { model with TimerOn = on }, (if on then timerCmd else Cmd.none)
        | TimedTick -> if model.TimerOn then { model with Count = model.Count + model.Step }, timerCmd else model, Cmd.none

    let view (model: Model) dispatch =
        Xaml.ContentPage(
          content=Xaml.StackLayout(padding=20.0,
            children=[ 
              yield 
                Xaml.StackLayout(padding=20.0, verticalOptions=LayoutOptions.Center,
                  children=[
                    Xaml.Label(text= sprintf "%d" model.Count, horizontalOptions=LayoutOptions.Center, fontSize = "Large")
                    Xaml.Button(text="Increment", command= fixf (fun () -> dispatch Increment))
                    Xaml.Button(text="Decrement", command= fixf (fun () -> dispatch Decrement))
                    Xaml.StackLayout(padding=20.0, orientation=StackOrientation.Horizontal, horizontalOptions=LayoutOptions.Center,
                                    children = [ Xaml.Label(text="Timer"); 
                                                Xaml.Switch(isToggled=model.TimerOn, toggled = fixf (fun on -> dispatch (TimerToggled on.Value))) ])
                    Xaml.Slider(minimum=0.0, maximum=10.0, value= double model.Step, valueChanged=fixf (fun args -> dispatch (SetStep (int (args.NewValue + 0.5)))))
                    Xaml.Label(text=sprintf "Step size: %d" model.Step, horizontalOptions=LayoutOptions.Center) 
                  ])
              // If you want the button to disappear when in the initial condition then use this:
              //if model <> initModel then 
              yield Xaml.Button(text="Reset", horizontalOptions=LayoutOptions.Center, command= fixf (fun () -> dispatch Reset), canExecute = (model <> initModel))
            ]))

type CounterApp () as app = 
    inherit Application ()

    do
        Program.mkProgram App.init App.update App.view
        |> Program.withConsoleTrace
        |> Program.runWithDynamicView app
