namespace NewApp

open Xamarin.Forms
open Fabulous.XamarinForms

open type View

module App =
    type Model = { Count: int }

    type Msg =
        | Increment
        | Decrement

    let init () = { Count = 0 }

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + 1 }
        | Decrement -> { model with Count = model.Count - 1 }

    let view model =
        Application(
            ContentPage(
                "NewApp",
                VStack() {
                    Label("Hello from Fabulous v2!")
                        .font(namedSize = NamedSize.Title)
                        .centerTextHorizontal()

                    (VStack() {
                        Label($"Count is {model.Count}")
                            .centerTextHorizontal()

                        Button("Increment", Increment)
                        Button("Decrement", Decrement)
                     })
                        .centerVertical(expand = true)
                }
            )
        )

    let program =
        Program.statefulApplication init update view
