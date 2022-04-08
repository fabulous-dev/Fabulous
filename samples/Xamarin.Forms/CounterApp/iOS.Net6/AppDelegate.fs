namespace CounterApp.iOS

open System
open UIKit
open Foundation
open Xamarin.Essentials
open Xamarin.Forms
open Xamarin.Forms.Platform.iOS
open CounterApp
open Fabulous.XamarinForms

[<Register("AppDelegate")>]
type AppDelegate() =
    inherit FormsApplicationDelegate()

    override this.FinishedLaunching(app, options) =
        Forms.Init()

        let application = Program.createApplication App.program ()
        this.LoadApplication(application)

        base.FinishedLaunching(app, options)
