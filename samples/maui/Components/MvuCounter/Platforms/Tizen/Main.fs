namespace CounterApp

open System
open Microsoft.Maui
open Microsoft.Maui.Hosting

type Program() =
    inherit MauiApplication()

    override this.CreateMauiApp() = MauiProgram.CreateMauiApp()

module Program =
    [<EntryPoint>]
    let main args =
        let app = Program()
        app.Run(args)
