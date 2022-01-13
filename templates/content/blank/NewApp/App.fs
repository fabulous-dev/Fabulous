namespace NewApp

open Xamarin.Forms
open Fabulous
open Fabulous.XamarinForms

open type Fabulous.XamarinForms.View

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
                VerticalStackLayout(
                    [ Label("Hello from Fabulous v2!")
                        .font(NamedSize.Title)
                        .centerTextHorizontally ()

                      VerticalStackLayout(
                          [

                            Label($"Count is {model.Count}")
                                .centerTextHorizontally ()

                            Button("Increment", Increment)
                            Button("Decrement", Decrement)

                            ]
                      )
                          .centerVertically (expand = true) ]
                )
            )
        )

    let program =
        Program.statefulApplication init update view
