// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
namespace AllControls

open System
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
    | SliderValueChanged of int
    | TextChanged of string * string
    | EditorEditCompleted 
    | EntryEditCompleted 
    | DateSelected of DateTime * DateTime

type AllControls () = 
    inherit Application ()

    let init () = { Count = 0; Step = 3 }

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + model.Step }
        | Decrement -> { model with Count = model.Count - model.Step }
        | Reset -> init ()
        | SliderValueChanged n -> { model with Step = n }
        | TextChanged (oldValue, newValue) -> model
        | EditorEditCompleted -> model
        | EntryEditCompleted  -> model
        | DateSelected (oldValue, newValue) -> model

    let view (model: Model) dispatch =
        Xaml.ScrollView(
           Xaml.StackLayout(padding=20.0,
              children=[
                Xaml.Label(text="ActivityIndicator:")
                Xaml.ActivityIndicator(isRunning=(model.Count > 5), horizontalOptions=LayoutOptions.Center)
                
                Xaml.Label(text="Button:")
                Xaml.Button(text="Increment", command= (fun () -> dispatch Increment), horizontalOptions=LayoutOptions.Center)
                
                Xaml.Label(text="Button (cornerRadius 3):")
                Xaml.Button(text="Decrement", cornerRadius=3, command= (fun () -> dispatch Decrement), horizontalOptions=LayoutOptions.Center)
                
                Xaml.Label(text="DatePicker:")
                Xaml.DatePicker(minimumDate= System.DateTime.Now, maximumDate=DateTime.Now + TimeSpan.FromDays(365.0), 
                                dateSelected=(fun args -> dispatch (DateSelected (args.OldDate, args.NewDate))), 
                                horizontalOptions=LayoutOptions.Center)
                
                Xaml.Label(text="Editor:")
                Xaml.Editor(text= "Hic haec hoc", horizontalOptions=LayoutOptions.Center, 
                            textChanged=(fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
                            completed=(fun args -> dispatch (EditorEditCompleted)))

                Xaml.Label(text="Entry:")
                Xaml.Entry(text= "the initial entru=y", horizontalOptions=LayoutOptions.Center, 
                            textChanged=(fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
                            completed=(fun args -> dispatch EntryEditCompleted))

                Xaml.Label(text="Entry (password):")
                Xaml.Entry(text= "secret", isPassword=true, horizontalOptions=LayoutOptions.Center, 
                            textChanged=(fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
                            completed=(fun args -> dispatch EntryEditCompleted))

                Xaml.Label(text="Entry (placeholder):")
                Xaml.Entry(placeholder= "Enter some text", horizontalOptions=LayoutOptions.Center, 
                            textChanged=(fun args -> dispatch (TextChanged(args.OldTextValue, args.NewTextValue))),
                            completed=(fun args -> dispatch EntryEditCompleted))

                Xaml.Label(text="Frame (hasShadow=true):")
                Xaml.Frame(hasShadow=true, horizontalOptions=LayoutOptions.Center)


                Xaml.Label(text="Grid (6x6, auto):")
                Xaml.Grid(rowdefs= [for i in 1 .. 6 -> box "auto"], coldefs=[for i in 1 .. 6 -> box "auto"], children = [ for i in 1 .. 6 do for j in 1 .. 6 -> Xaml.BoxView(Color((1.0/float i), (1.0/float j), (1.0/float (i+j)), 1.0) ).WithGridRow(i).WithGridColumn(j) ])

                Xaml.Label(text="Label:")
                Xaml.Label(text= sprintf "%d" model.Count, horizontalOptions=LayoutOptions.Center)

                // Xaml.AbsoluteLayout: TODO
                // Xaml.Accelerator: TODO
                // Xaml.Animation: TODO
                // Xaml.AppLinkEntry: TODO
                // Xaml.BoxView: TODO
                // Xaml.Cell, EntryCell: TODO
                // Xaml.CarouselPage: TODO
                // Xaml.ContentPage: TODO
                // TODO: fix slider where minimum = 1.0 (gets set before maximum..)

                Xaml.Label(text="Slider:")
                Xaml.Slider(minimum=0.0, maximum=10.0, value= double model.Step, valueChanged=(fun args -> dispatch (SliderValueChanged (int (args.NewValue + 0.5)))), horizontalOptions=LayoutOptions.Center)
              ]))

    do
        let page = 
            Program.mkSimple init update 
                (fun _ _ -> HelperPage(), [], view) 
            |> Program.withConsoleTrace
            |> Program.runDynamicView

        base.MainPage <- page
