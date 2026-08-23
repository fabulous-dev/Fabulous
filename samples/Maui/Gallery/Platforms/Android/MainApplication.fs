namespace Gallery.Android

open Android.App
open Microsoft.Maui
open Gallery

[<Application>]
type MainApplication(handle, ownership) =
    inherit MauiApplication(handle, ownership)

    do Gallery.Resource.UpdateIdValues()

    override this.CreateMauiApp() = MauiProgram.CreateMauiApp()
