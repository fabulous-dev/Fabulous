// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
namespace CounterApp

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

    let initModel () = { Count = 0; Step = 1; TimerOn=false }

    let init () = initModel () , Cmd.none

    let timerCmd () = 
        async { do! Async.Sleep 200
                return TimedTick }
        |> Cmd.ofAsyncMsg

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + model.Step }, Cmd.none
        | Decrement -> { model with Count = model.Count - model.Step }, Cmd.none
        | Reset -> init ()
        | SetStep n -> { model with Step = n }, Cmd.none
        | TimerToggled on -> { model with TimerOn = on }, (if on then timerCmd() else Cmd.none)
        | TimedTick -> if model.TimerOn then { model with Count = model.Count + model.Step }, timerCmd() else model, Cmd.none 

    let view (model: Model) dispatch = 
        View.ContentPage(
          content=View.StackLayout(padding=30.0,verticalOptions = LayoutOptions.Center,
            children=[ 
              // If you want the button to disappear when in the initial condition then use this:
              yield View.Label(text= sprintf "%d" model.Count, horizontalOptions=LayoutOptions.Center, fontSize = "Large")
              yield View.Button(text="Increment", command= (fun () -> dispatch Increment))
              yield View.Button(text="Decrement", command= (fun () -> dispatch Decrement)) 
              yield View.StackLayout(padding=20.0, orientation=StackOrientation.Horizontal, horizontalOptions=LayoutOptions.Center,
                              children = [ View.Label(text="Timer")
                                           View.Switch(isToggled=model.TimerOn, toggled=(fun on -> dispatch (TimerToggled on.Value))) ])
              yield View.Slider(minimum=0.0, maximum=10.0, value= double model.Step, valueChanged=(fun args -> dispatch (SetStep (int (args.NewValue + 0.5)))))
              yield View.Label(text=sprintf "Step size: %d" model.Step, horizontalOptions=LayoutOptions.Center) 
              //if model <> initModel () then 
              yield View.Button(text="Reset", horizontalOptions=LayoutOptions.Center, command=(fun () -> dispatch Reset), canExecute = (model <> initModel () ))
            ]))   
             
    let program = 
        Program.mkProgram init update view 
        |> Program.withConsoleTrace

#if TESTEVAL
    let testInit = fst (init ())
    let testView = view testInit (fun _ -> ())
#endif

type CounterApp () as app = 
    inherit Application ()

    let runner = App.program |> Program.runWithDynamicView app

#if DEBUG && !TESTEVAL
    do runner.EnableLiveUpdate ()
#endif


(*
#if !NO_SAVE_MODEL_WITH_JSON
    let modelId = "model"
    let serializer = MBrace.FsPickler.Json.FsPickler.CreateJsonSerializer()

    override __.OnSleep() = 

        let json = serializer.PickleToString(runner.CurrentModel)
        Debug.WriteLine("OnSleep: saving model into app.Properties, json = {0}", json)

        app.Properties.[modelId] <- json

    override __.OnResume() = 
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

    override this.OnStart() = this.OnResume()

#endif
*)
