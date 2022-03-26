namespace CounterApp

open Fabulous.XamarinForms

open type View

module App =
    type Model =
        { Toggled: bool
          MountedS: bool
          MountedL: bool
          UnmountedS: bool
          UnmountedL: bool }

    type Msg =
        | Toggle
        | Mounted of bool
        | Unmounted of bool

    let init () =
        { Toggled = false
          MountedS = false
          MountedL = false
          UnmountedS = false
          UnmountedL = false }

    let update msg model =
        match msg with
        | Toggle ->
            { model with Toggled = not model.Toggled }
        | Mounted x ->
            if x then
                { model with MountedS = true; UnmountedS = false }
            else
                { model with MountedL = true; UnmountedL = false }
        | Unmounted x ->
            if x then
                { model with UnmountedS = true; MountedS = false }
            else
                { model with UnmountedL = true; MountedL = false }

    let view model =
        Application(
            ContentPage(
                "CounterApp",
                (VStack() {
                    Label($"Hello: {model.Toggled}")
                    Button("Toggle", Toggle)
                    
                    if model.Toggled then
                        (VStack() {
                            Label("Lifecycle label")
                                .onMounted(Mounted false)
                                .onUnmounted(Unmounted false)
                                .backgroundColor(Xamarin.Forms.Color.Red)
                        })
                            .onMounted(Mounted true)
                            .onUnmounted(Unmounted true)
                    
                    Label($"MountedS: {model.MountedS}")
                    Label($"UnmountedS: {model.UnmountedS}")
                    Label($"MountedL: {model.MountedL}")
                    Label($"UnmountedL: {model.UnmountedL}")
                 })
                    .padding(30.)
                    .centerVertical ()
            )
        )

    let program =
        Program.statefulApplication init update view
