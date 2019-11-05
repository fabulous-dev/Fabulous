namespace PrettyWeather.Droid

open System

open Android.App
open Android.Content.PM
open Android.OS
open Xamarin.Forms.Platform.Android

[<Activity (Label = "Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = (ConfigChanges.ScreenSize ||| ConfigChanges.Orientation))>]
type MainActivity() =
    inherit FormsApplicationActivity()
    override this.OnCreate (bundle: Bundle) =
        base.OnCreate (bundle)
        Xamarin.Essentials.Platform.Init(this, bundle)
        Xamarin.Forms.Forms.Init (this, bundle)

        this.LoadApplication (new PrettyWeather.PrettyWeatherApp())

    override this.OnRequestPermissionsResult (requestCode,permissions,grantResults) =
        Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        base.OnRequestPermissionsResult(requestCode, permissions, grantResults)
