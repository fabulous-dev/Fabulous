namespace Fabulous.XamarinForms.Samples.CounterApp

open Xamarin.Forms
open Fabulous.XamarinForms
open type Fabulous.XamarinForms.View

module App =
    type Model =
        { Count: int }

    type Msg =
        | Increment
        | Decrement

    let init () =
        { Count = 0 }

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + 1 }
        | Decrement -> { model with Count = model.Count - 1 }

    let view model =
        Application(
            ContentPage(
                VerticalStackLayout([
                    Label($"Count = {model.Count}")
                        .centerAndExpand()

                    Button("Increment", Increment)
                    Button("Decrement", Decrement)
                        .verticalOptions(LayoutOptions.StartAndExpand)
                ])
            )
        )

    let program = Program.statefulApplication init update view