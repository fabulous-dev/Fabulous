// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
namespace CounterApp

open Elmish
open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews
open Xamarin.Forms

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

type CounterApp () = 
    inherit Application ()

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
            yield Xaml.StackLayout(padding=20.0, verticalOptions=LayoutOptions.Center,
              children=[
                 Xaml.Label(text= sprintf "%d" model.Count, horizontalOptions=LayoutOptions.Center, fontSize = "Large")
                 Xaml.Button(text="Increment", command= (fun () -> dispatch Increment))
                 Xaml.Button(text="Decrement", command= (fun () -> dispatch Decrement))
                 Xaml.StackLayout(padding=20.0, orientation=StackOrientation.Horizontal, horizontalOptions=LayoutOptions.Center,
                                  children = [ Xaml.Label(text="Timer"); 
                                               Xaml.Switch(isToggled=model.TimerOn, toggled = (fun on -> dispatch (TimerToggled on.Value))) ])
                 Xaml.Slider(minimum=0.0, maximum=10.0, value= double model.Step, valueChanged=(fun args -> dispatch (SetStep (int (args.NewValue + 0.5)))))
                 Xaml.Label(text=sprintf "Step size: %d" model.Step, horizontalOptions=LayoutOptions.Center) 
              ])
            if model <> initModel then 
                yield Xaml.Button(text="Reset", horizontalOptions=LayoutOptions.Center, command= (fun () -> dispatch Reset))
          ]))

    do
        let page = 
            Program.mkProgram init update view
            |> Program.withConsoleTrace
            |> Program.withDynamicView
            |> Program.run

        do PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(page.On<PlatformConfiguration.iOS>(), true) |> ignore

        base.MainPage <- page
