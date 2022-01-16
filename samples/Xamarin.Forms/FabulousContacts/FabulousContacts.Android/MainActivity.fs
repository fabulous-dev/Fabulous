// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace FabulousContacts.Android

open System

open System.IO
open Android.App
open Android.Content
open Android.Content.PM
open Android.Runtime
open Android.Views
open Android.Widget
open Android.OS
open Fabulous.XamarinForms
open Xamarin.Forms.Platform.Android
open FabulousContacts

[<Activity(Label = "FabulousContacts.Android",
           Icon = "@drawable/icon",
           Theme = "@style/MainTheme",
           MainLauncher = true,
           ConfigurationChanges = (ConfigChanges.ScreenSize
                                   ||| ConfigChanges.Orientation))>]
type MainActivity() =
    inherit FormsAppCompatActivity()

    let getDbPath () =
        let path =
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)

        Path.Combine(path, "Contacts.db3")

    override this.OnCreate(bundle: Bundle) =
        FormsAppCompatActivity.TabLayoutResource <- Resources.Layout.Tabbar
        FormsAppCompatActivity.ToolbarResource <- Resources.Layout.Toolbar

        base.OnCreate(bundle)
        Xamarin.Essentials.Platform.Init(this, bundle)
        Xamarin.Forms.Forms.Init(this, bundle)
        let dbPath = getDbPath ()
        let app = App.program(dbPath)
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
