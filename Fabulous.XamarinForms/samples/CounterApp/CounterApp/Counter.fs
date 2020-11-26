namespace CounterApp

open Fabulous
open Fabulous.XamarinForms

module Counter =
    type Model =
        { Count: int }

    type Msg =
        | Increment
        | Decrement

    let init () = { Count = 0 }

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + 1 }
        | Decrement -> { model with Count = model.Count - 1 }

    let view model dispatch =
        View.StackLayout([
            View.Label(sprintf "Counter is %i" model.Count)
            View.Button(
                text = "Increment",
                command = fun _ -> dispatch Increment
            )
            View.Button(
                text = "Decrement",
                command = fun _ -> dispatch Decrement
            )
            View.Label(sprintf "Component updated on %A" System.DateTime.Now.TimeOfDay)
        ])

    let program =
        XamarinFormsProgram.mkSimple init update view
#if DEBUG
        |> Program.withConsoleTrace
#endif

    type Fabulous.XamarinForms.View with
        static member inline Counter() = Component.forProgram(program)