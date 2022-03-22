namespace CounterApp

open Fabulous
open Fabulous.XamarinForms

open type Fabulous.XamarinForms.View

module App =
    type Model =
        { Toggled: bool
          WillMount: bool
          DidMount: bool
          WillUnmount: bool
          DidUnmount: bool }

    type Msg =
        | Toggle
        | WillMount
        | DidMount
        | WillUnmount
        | DidUnmount

    let init () =
        { Toggled = false
          WillMount = false
          DidMount = false
          WillUnmount = false
          DidUnmount = false }

    let update msg model =
        match msg with
        | Toggle ->
            { model with Toggled = not model.Toggled }
        | WillMount ->
            { model with WillMount = true; WillUnmount = false; DidUnmount = false }
        | DidMount ->
            { model with DidMount = true }
        | WillUnmount ->
            { model with WillUnmount = true; WillMount = false; DidMount = false }
        | DidUnmount ->
            { model with DidUnmount = true }

    let view model =
        Application(
            ContentPage(
                "CounterApp",
                (VStack() {
                    Label($"Hello: {model.Toggled}")
                    Button("Toggle", Toggle)
                    
                    Label($"WillMount: {model.WillMount}")
                    Label($"DidMount: {model.DidMount}")
                    Label($"WillUnmount: {model.WillUnmount}")
                    Label($"DidUnmount: {model.DidUnmount}")
                    
                    if model.Toggled then
                        VStack() {
                            Label("Lifecycle label")
                                .willMount(WillMount)
                                .didMount(DidMount)
                                .willUnmount(WillUnmount)
                                .didUnmount(DidUnmount)
                                .backgroundColor(Xamarin.Forms.Color.Red)
                        }
                 })
                    .padding(30.)
                    .centerVertical ()
            )
        )

    let program =
        Program.statefulApplication init update view
