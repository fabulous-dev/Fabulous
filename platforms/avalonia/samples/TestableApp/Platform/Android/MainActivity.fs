namespace TestableApp.Android

open Android.App
open Android.Content.PM
open Avalonia
open Avalonia.Android
open TestableApp
open Fabulous.Avalonia

[<Activity(Label = "Counter.Android",
           Theme = "@style/MyTheme.NoActionBar",
           Icon = "@drawable/icon",
           LaunchMode = LaunchMode.SingleTop,
           ConfigurationChanges = (ConfigChanges.Orientation ||| ConfigChanges.ScreenSize))>]
type MainActivity() =
    inherit AvaloniaMainActivity<FabApplication>()

    override this.CustomizeAppBuilder(_builder: AppBuilder) =
        AppBuilder.Configure<FabApplication>().UseAndroid()
