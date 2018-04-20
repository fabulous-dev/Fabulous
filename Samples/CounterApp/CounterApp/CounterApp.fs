// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
namespace CounterApp

open Elmish
open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews
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

    let view (model: Model) dispatch =
        Xaml.StackLayout(padding=20.0,
          children=[
            yield Xaml.StackLayout(padding=20.0, verticalOptions=LayoutOptions.Center,
              children=[
                 Xaml.Label(text= sprintf "%d" model.Count, horizontalOptions=LayoutOptions.Center, textColor=Color.Blue)
                 Xaml.Label(text= sprintf "%d" (model.Count + 100), horizontalOptions=LayoutOptions.Center, textColor=Color.Green)
                 Xaml.Button(text="Increment", command= (fun () -> dispatch Increment))
                 Xaml.Button(text="Decrement", command= (fun () -> dispatch Decrement))
                 Xaml.Slider(minimum=0.0, maximum=10.0, value= double model.Step, valueChanged=(fun args -> dispatch (SetStep (int (args.NewValue + 0.5)))))
                 Xaml.Label(text=sprintf "Step size: %d" model.Step, horizontalOptions=LayoutOptions.Center) 
              ])
            if model <> init() then 
                yield Xaml.Button(text="Reset", horizontalOptions=LayoutOptions.Center, command= (fun () -> dispatch Reset))
          ])

    do
        let page = 
            Program.mkSimple init update 
                (fun _ _ -> HelperPage(), [], view) 
            |> Program.withConsoleTrace
            |> Program.runDynamicView

        base.MainPage <- page
