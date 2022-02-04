namespace TicTacToe.Android

open Android.App
open Android.Content.PM
open Android.Runtime
open Android.Widget
open Xamarin.Forms.Platform.Android

open Fabulous.XamarinForms
open TicTacToe

[<Activity(Label = "TicTacToe",
           Icon = "@drawable/icon",
           Theme = "@style/MainTheme",
           MainLauncher = true,
           ConfigurationChanges = (ConfigChanges.ScreenSize
                                   ||| ConfigChanges.Orientation
                                   ||| ConfigChanges.UiMode
                                   ||| ConfigChanges.ScreenLayout
                                   ||| ConfigChanges.SmallestScreenSize))>]
type MainActivity() =
    inherit FormsAppCompatActivity()

    override this.OnCreate(bundle) =
        Resource.UpdateIdValues()

        FormsAppCompatActivity.TabLayoutResource <- Resource.Layout.Tabbar
        FormsAppCompatActivity.ToolbarResource <- Resource.Layout.Toolbar

        base.OnCreate(bundle)

        Xamarin.Essentials.Platform.Init(this, bundle)
        Xamarin.Forms.Forms.Init(this, bundle)
        let application: Xamarin.Forms.Application = unbox (Program.create App.program ())
        this.LoadApplication(application)

    override this.OnRequestPermissionsResult
        (
            requestCode: int,
            permissions: string [],
            [<GeneratedEnum>] grantResults: Android.Content.PM.Permission []
        ) =
        Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults)
        base.OnRequestPermissionsResult(requestCode, permissions, grantResults)
