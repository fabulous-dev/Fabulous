namespace Playground.Android

open System
open Android.App
open Android.Content.PM
open Android.Runtime
open Avalonia
open Avalonia.Android
open Playground
open Fabulous.Avalonia

[<Activity(Label = "Counter.Android",
           Theme = "@style/MyTheme.NoActionBar",
           Icon = "@drawable/icon",
           LaunchMode = LaunchMode.SingleTop,
           ConfigurationChanges = (ConfigChanges.Orientation ||| ConfigChanges.ScreenSize))>]
type MainActivity() =
    inherit AvaloniaMainActivity()

[<Application>]
type MainApplication(handle: IntPtr, ownership: JniHandleOwnership) =
    inherit AvaloniaAndroidApplication<FabApplication>(handle, ownership)

    override this.CustomizeAppBuilder(_builder: AppBuilder) = App.create().UseAndroid()
