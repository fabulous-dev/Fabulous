namespace BasicNavigation

open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module PageC =
    type Model = { Count: int }

    type Msg =
        | Increment
        | Decrement

    let init () = { Count = 0 }

    let update msg model =
        match msg with
        | Increment -> { Count = model.Count + 1 }
        | Decrement -> { Count = model.Count - 1 }

    let view model =
        VStack() {
            Label("Page c")
                .foreground(Brushes.White)
                .fontSize(32.)
                .centerHorizontal()
                .margin(0., 0., 0., 30.)

            Label($"Count: {model.Count}").centerHorizontal()

            Button("Increment", Increment)
            Button("Decrement", Decrement)
        }
        |> _.centerHorizontal()
