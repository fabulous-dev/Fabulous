namespace Droid

open System
open Android.App
open Android.Content
open Android.Content.PM
open Android.Runtime
open Android.Views
open Android.Widget
open Android.OS
open Xamarin.Forms.Platform.Android

[<Activity(Label = "Fabimals", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = (ConfigChanges.ScreenSize ||| ConfigChanges.Orientation))>]
type MainActivity() =
    inherit FormsAppCompatActivity()
    override this.OnCreate(bundle : Bundle) =
        FormsAppCompatActivity.TabLayoutResource <- Resources.Layout.Tabbar
        FormsAppCompatActivity.ToolbarResource <- Resources.Layout.Toolbar
        base.OnCreate(bundle)
        Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental")
        this.Window.SetStatusBarColor(Android.Graphics.Color.Argb(255, 0, 0,  0))
        Xamarin.Forms.Forms.Init (this, bundle)

        this.LoadApplication (new Fabimals.FabimalsApp ())
