namespace HelloWorld

open Android.App
open Microsoft.Maui

[<Application>]
type MainApplication(handle, ownership) =
    inherit MauiApplication(handle, ownership)

    do HelloWorld.Resource.UpdateIdValues()
    
    override _.CreateMauiApp() = MauiProgram.CreateMauiApp()