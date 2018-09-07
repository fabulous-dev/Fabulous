// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace TicTacToe.Droid

open System

open Android.App
open Android.Content
open Android.Content.PM
open Android.Runtime
open Android.Views
open Android.Widget
open Android.OS
open Xamarin.Forms.Platform.Android

[<Activity (Label = "TicTacToe.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = (ConfigChanges.ScreenSize ||| ConfigChanges.Orientation))>]
type MainActivity() =
    inherit FormsAppCompatActivity()
    override this.OnCreate (bundle: Bundle) =
        FormsAppCompatActivity.TabLayoutResource <- TicTacToe.Droid.Resources.Layout.Tabbar
        FormsAppCompatActivity.ToolbarResource <- TicTacToe.Droid.Resources.Layout.Toolbar
        base.OnCreate (bundle)

        Xamarin.Forms.Forms.Init (this, bundle)

        this.LoadApplication (new TicTacToe.App ())
