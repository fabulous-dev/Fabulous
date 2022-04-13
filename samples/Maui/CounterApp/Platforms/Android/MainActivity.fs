namespace CounterApp

open Android.App
open Android.Content.PM
open Android.OS
open Microsoft.Maui

[<Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = (ConfigChanges.ScreenSize ||| ConfigChanges.Orientation ||| ConfigChanges.UiMode ||| ConfigChanges.ScreenLayout ||| ConfigChanges.SmallestScreenSize ||| ConfigChanges.Density))>]
type MainActivity() =
    inherit MauiAppCompatActivity()
    
    override this.OnCreate(savedInstanceState: Bundle) =
        Resource.UpdateIdValues()
        base.OnCreate(savedInstanceState)