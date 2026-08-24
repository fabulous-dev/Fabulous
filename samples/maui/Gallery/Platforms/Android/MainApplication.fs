namespace Gallery.Android

open Android.App
open Microsoft.Maui
open Gallery

[<Application>]
type MainApplication(handle, ownership) =
    inherit MauiApplication(handle, ownership)

    override this.CreateMauiApp() = MauiProgram.CreateMauiApp()
