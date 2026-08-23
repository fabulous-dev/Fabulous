namespace Gallery.Android

open Android.App
open System
open Android.Content.PM
open Android.Runtime
open Avalonia
open Avalonia.Android
open Fabulous.Avalonia
open Gallery

[<Activity(Label = "Gallery.Android",
           Theme = "@style/MyTheme.NoActionBar",
           Icon = "@drawable/icon",
           ConfigurationChanges = (ConfigChanges.Orientation ||| ConfigChanges.ScreenSize))>]
type MainActivity() =
    inherit AvaloniaMainActivity()

[<Application>]
type MainApplication(handle: IntPtr, ownership: JniHandleOwnership) =
    inherit AvaloniaAndroidApplication<FabApplication>(handle, ownership)

    override this.CustomizeAppBuilder(_builder: AppBuilder) = MainView.create().UseAndroid()
