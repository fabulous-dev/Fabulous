namespace CounterApp

open Fabulous.XamarinForms

open type View

module App =
    type Model =
        { Toggled: bool
          Mounted: bool
          Unmounted: bool }

    type Msg =
        | Toggle
        | Mounted
        | Unmounted

    let init () =
        { Toggled = false
          Mounted = false
          Unmounted = false }

    let update msg model =
        match msg with
        | Toggle ->
            { model with Toggled = not model.Toggled }
        | Mounted ->
            { model with Mounted = true; Unmounted = false }
        | Unmounted ->
            { model with Unmounted = true; Mounted = false }

    let view model =
        Application(
            ContentPage(
                "CounterApp",
                (VStack() {
                    Label($"Hello: {model.Toggled}")
                    Button("Toggle", Toggle)
                    
                    Label($"Mounted: {model.Mounted}")
                    Label($"Unmounted: {model.Unmounted}")
                    
                    if model.Toggled then
                        VStack() {
                            Label("Lifecycle label")
                                .onMounted(Mounted)
                                .onUnmounted(Unmounted)
                                .backgroundColor(Xamarin.Forms.Color.Red)
                        }
                 })
                    .padding(30.)
                    .centerVertical ()
            )
        )

    let program =
        Program.statefulApplication init update view
