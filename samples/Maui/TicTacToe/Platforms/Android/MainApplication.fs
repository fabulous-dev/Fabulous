namespace TicTacToe

open Android.App
open Microsoft.Maui

[<Application>]
type MainApplication(handle, ownership) =
    inherit MauiApplication(handle, ownership)

    do TicTacToe.Resource.UpdateIdValues()

    override _.CreateMauiApp() = MauiProgram.CreateMauiApp()
