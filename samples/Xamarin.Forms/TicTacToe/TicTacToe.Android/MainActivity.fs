// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace TicTacToe.Android

open System

open Android.App
open Android.Content
open Android.Content.PM
open Android.Runtime
open Android.Views
open Android.Widget
open Android.OS
open Fabulous.XamarinForms
open Fabulous.XamarinForms.Samples.TicTacToe
open Xamarin.Forms.Platform.Android
open TicTacToe

[<Activity(Label = "TicTacToe.Android",
           Icon = "@drawable/icon",
           Theme = "@style/MainTheme",
           MainLauncher = true,
           ConfigurationChanges = (ConfigChanges.ScreenSize
                                   ||| ConfigChanges.Orientation))>]
type MainActivity() =
    inherit FormsAppCompatActivity()

    override this.OnCreate(bundle: Bundle) =
        FormsAppCompatActivity.TabLayoutResource <- Resources.Layout.Tabbar
        FormsAppCompatActivity.ToolbarResource <- Resources.Layout.Toolbar

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
