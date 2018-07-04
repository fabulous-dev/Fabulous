// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
namespace NewApp

open System.Diagnostics
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
                    Xaml.Button(text="Increment", command= (fun () -> dispatch Increment))
                    Xaml.Button(text="Decrement", command= (fun () -> dispatch Decrement))
                    Xaml.StackLayout(padding=20.0, orientation=StackOrientation.Horizontal, horizontalOptions=LayoutOptions.Center,
                                    children = [ Xaml.Label(text="Timer")
                                                 Xaml.Switch(isToggled=model.TimerOn, toggled=fixf(fun on -> dispatch (TimerToggled on.Value))) ])
                    Xaml.Slider(minimum=0.0, maximum=10.0, value= double model.Step, valueChanged=fixf(fun args -> dispatch (SetStep (int (args.NewValue + 0.5)))))
                    Xaml.Label(text=sprintf "Step size: %d" model.Step, horizontalOptions=LayoutOptions.Center) 
                  ])
              // If you want the button to disappear when in the initial condition then use this:
              //if model <> initModel then 
              yield Xaml.Button(text="Reset", horizontalOptions=LayoutOptions.Center, command=fixf(fun () -> dispatch Reset), canExecute = (model <> initModel))
            ]))

type App () as app = 
    inherit Application ()

    let program = Program.mkProgram App.init App.update App.view
    let runner = 
        program
#if DEBUG
        |> Program.withConsoleTrace
#endif
        |> Program.runWithDynamicView app

(*  // Uncomment this code to save the applciation state to app.Properties using FsPickler

    let modelId = "model"
    let serializer = MBrace.FsPickler.Json.FsPickler.CreateJsonSerializer()

    override app.OnSleep() = 

        let json = serializer.PickleToString(runner.CurrentModel)
        Debug.WriteLine("OnSleep: saving model into app.Properties, json = {0}", json)

        app.Properties.[modelId] <- json

    override app.OnResume() = 
        Debug.WriteLine "OnResume: checking for model in app.Properties"
        try 
            match app.Properties.TryGetValue modelId with
            | true, (:? string as json) -> 

                Debug.WriteLine("OnResume: restoring model from app.Properties, json = {0}", json)
                let model = serializer.UnPickleOfString<App.Model>(json)

                Debug.WriteLine("OnResume: restoring model from app.Properties, model = {0}", (sprintf "%0A" model))
                runner.SetCurrentModel (model, Cmd.none)

            | _ -> ()
        with ex -> 
            program.onError("Error while restoring model found in app.Properties", ex)

    override app.OnStart() = app.OnResume()

*)
