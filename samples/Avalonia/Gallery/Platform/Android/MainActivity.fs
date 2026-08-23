namespace Gallery.Android

open Android.App
open Android.Content.PM
open Avalonia
open Avalonia.Android
open Fabulous.Avalonia
open Gallery

[<Activity(Label = "Gallery.Android",
           Theme = "@style/MyTheme.NoActionBar",
           Icon = "@drawable/icon",
           ConfigurationChanges = (ConfigChanges.Orientation ||| ConfigChanges.ScreenSize))>]
type MainActivity() =
    inherit AvaloniaMainActivity<FabApplication>()

    override this.CustomizeAppBuilder(_builder: AppBuilder) = MainView.create().UseAndroid()
