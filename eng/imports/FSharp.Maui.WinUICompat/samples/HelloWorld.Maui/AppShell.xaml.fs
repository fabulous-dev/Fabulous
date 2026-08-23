namespace HelloWorld

open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Xaml

type AppShell() as this =
    inherit Shell()

    do this.LoadFromXaml(typeof<AppShell>) |> ignore