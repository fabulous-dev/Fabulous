namespace Fabulous.XamarinForms.Samples.FabulousContacts.Android

open Android.App
open Android.Runtime
open Xamarin.Essentials
open Xamarin.Forms
open Xamarin.Forms.Platform.Android
open Fabulous.XamarinForms.Samples.FabulousContacts

[<Activity(Label = "FabulousContacts.Android", MainLauncher = true, Icon = "@mipmap/icon")>]
type MainActivity() =
    inherit FormsAppCompatActivity()

    override this.OnCreate(bundle) =
        base.OnCreate(bundle)
        Platform.Init(this, bundle)
        Forms.Init(this, bundle)
        this.LoadApplication(App())

    override this.OnRequestPermissionsResult
        (
            requestCode: int,
            permissions: string [],
            [<GeneratedEnum>] grantResults: Android.Content.PM.Permission []
        ) =
        Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults)
        base.OnRequestPermissionsResult(requestCode, permissions, grantResults)
