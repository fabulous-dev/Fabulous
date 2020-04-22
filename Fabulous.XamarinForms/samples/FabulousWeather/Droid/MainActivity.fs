namespace FabulousWeather.Droid

open Android.App
open Android.Content.PM
open Android.OS
open Android.Views
open Xamarin.Forms.Platform.Android

[<Activity (Label = "Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = (ConfigChanges.ScreenSize ||| ConfigChanges.Orientation))>]
type MainActivity() =
    inherit FormsApplicationActivity()
    override this.OnCreate (bundle: Bundle) =
        base.OnCreate (bundle)
        this.Window.AddFlags(WindowManagerFlags.TranslucentStatus)
        this.Window.AddFlags(WindowManagerFlags.ForceNotFullscreen)
        Xamarin.Forms.Forms.SetFlags("IndicatorView_Experimental")
        Xamarin.Forms.Forms.Init (this, bundle)
        this.LoadApplication (new FabulousWeather.App())