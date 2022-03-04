namespace FabulousContacts.Android

open Android.App
open Android.Content.PM
open Android.Runtime
open Android.Widget
open Xamarin.Forms.Platform.Android
open System.IO

open Fabulous.XamarinForms
open FabulousContacts

[<assembly: UsesPermission(Android.Manifest.Permission.Internet)>]
[<assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)>]
[<assembly: UsesPermission(Android.Manifest.Permission.Internet)>]
[<assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)>]
[<assembly: UsesPermission(Android.Manifest.Permission.ReadExternalStorage)>]
[<assembly: UsesPermission(Android.Manifest.Permission.AccessCoarseLocation)>]
[<assembly: UsesPermission(Android.Manifest.Permission.AccessFineLocation)>]
[<assembly: UsesPermission(Android.Manifest.Permission.AccessLocationExtraCommands)>]
[<assembly: UsesPermission(Android.Manifest.Permission.AccessMockLocation)>]
[<assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)>]
[<assembly: UsesPermission(Android.Manifest.Permission.AccessWifiState)>]
[<assembly: UsesPermission(Android.Manifest.Permission.AccessLocationExtraCommands)>]
[<assembly: UsesPermission(Android.Manifest.Permission.Camera)>]
[<assembly: UsesFeature("android.hardware.camera", Required = false)>]
[<assembly: UsesFeature("android.hardware.camera.autofocus", Required = false)>]
do ()

[<Activity(Label = "FabulousContacts",
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

    let getDbPath () =
        let path =
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)

        Path.Combine(path, "Contacts.db3")

    override this.OnCreate(bundle) =
        Resource.UpdateIdValues()

        FormsAppCompatActivity.TabLayoutResource <- Resource.Layout.Tabbar
        FormsAppCompatActivity.ToolbarResource <- Resource.Layout.Toolbar

        base.OnCreate(bundle)

        Xamarin.Essentials.Platform.Init(this, bundle)
        Xamarin.Forms.Forms.Init(this, bundle)

        let dbPath = getDbPath ()
        let app = App.program (dbPath)
        let application: Xamarin.Forms.Application = unbox (Program.create app ())
        this.LoadApplication(application)

    override this.OnRequestPermissionsResult
        (
            requestCode: int,
            permissions: string [],
            [<GeneratedEnum>] grantResults: Android.Content.PM.Permission []
        ) =
        Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults)
        base.OnRequestPermissionsResult(requestCode, permissions, grantResults)
