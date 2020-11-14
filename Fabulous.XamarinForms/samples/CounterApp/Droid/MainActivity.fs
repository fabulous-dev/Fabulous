// Copyright Fabulous contributors. See LICENSE.md for license.
namespace Droid

open Android.App
open Android.Content.PM
open Android.OS
open Xamarin.Forms.Platform.Android
open CounterApp

[<Activity (Label = "CounterApp.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = (ConfigChanges.ScreenSize ||| ConfigChanges.Orientation))>]
type MainActivity() =
    inherit FormsApplicationActivity()
    override this.OnCreate (bundle: Bundle) =
        FormsAppCompatActivity.TabLayoutResource <- Resources.Layout.Tabbar
        FormsAppCompatActivity.ToolbarResource <- Resources.Layout.Toolbar
        
        base.OnCreate(bundle)
        Xamarin.Forms.Forms.Init(this, bundle)
        this.LoadApplication(CounterApp())

