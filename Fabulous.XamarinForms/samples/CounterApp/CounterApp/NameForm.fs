namespace CounterApp

open Fabulous
open Fabulous.XamarinForms

module NameForm =
    type Model =
        { FirstName: string
          LastName: string }

    type Msg =
        | FirstNameChanged of string
        | LastNameChanged of string

    type ExternalMsg =
        | FullNameChanged of string

    let toFullName model =
        sprintf "%s %s" model.FirstName model.LastName

    let init () = { FirstName = ""; LastName = "" }, Cmd.none, []

    let update msg model =
        match msg with
        | FirstNameChanged value ->
            let newModel = { model with FirstName = value }
            newModel, Cmd.none, [FullNameChanged (toFullName newModel)]

        | LastNameChanged value ->
            let newModel = { model with LastName = value }
            newModel, Cmd.none, [FullNameChanged (toFullName newModel)]

    let view model dispatch =
        View.Grid(
            coldefs = [Auto; Star],
            rowdefs = [Star; Star; Auto],
            children = [
                View.Label("First name:")
                View.Entry(
                    text = model.FirstName,
                    textChanged = fun x -> dispatch (FirstNameChanged x.NewTextValue)
                ).Column(1)

                View.Label("Last name:").Row(1)
                View.Entry(
                    text = model.LastName,
                    textChanged = fun x -> dispatch (LastNameChanged x.NewTextValue)
                ).Column(1).Row(1)

                View.Label(sprintf "Component updated on %A" System.DateTime.Now.TimeOfDay)
                    .ColumnSpan(2)
                    .Row(2)
            ]
        )

    let program = XamarinFormsProgram.mkComponent init update view

    type Fabulous.XamarinForms.View with
        static member inline NameForm(key, onExternalMsg) =
            Component.forProgram(
                key,
                program,
                externalMsg = onExternalMsg
            )

