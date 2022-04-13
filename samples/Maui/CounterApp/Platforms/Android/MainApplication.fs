namespace CounterApp

open Android.App
open Android.Runtime
open System
open Microsoft.Maui

[<Application>]
type MainApplication (handle: IntPtr, ownership: JniHandleOwnership) =
    inherit MauiApplication(handle, ownership)

    override this.CreateMauiApp() = MauiProgram.CreateMauiApp()