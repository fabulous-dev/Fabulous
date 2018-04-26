// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
namespace AllControls.Droid

open System

open Android.App
open Android.Content
open Android.Content.PM
open Android.Runtime
open Android.Views
open Android.Widget
open Android.OS
open Xamarin.Forms.Platform.Android

[<Activity (Label = "AllControls.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = (ConfigChanges.ScreenSize ||| ConfigChanges.Orientation))>]
type MainActivity() =
    inherit FormsApplicationActivity()
    override this.OnCreate (bundle: Bundle) =
        base.OnCreate (bundle)

        Xamarin.Forms.Forms.Init (this, bundle)

        this.LoadApplication (new AllControls.App ())

