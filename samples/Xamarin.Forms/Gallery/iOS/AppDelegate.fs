namespace Gallery.iOS

open System
open UIKit
open Foundation
open Xamarin.Essentials
open Xamarin.Forms
open Xamarin.Forms.Platform.iOS
open Fabulous.XamarinForms
open Gallery

[<Register("AppDelegate")>]
type AppDelegate() =
    inherit FormsApplicationDelegate()

    override this.FinishedLaunching(app, options) =
        Forms.Init()
        this.LoadApplication(Program.startApplication App.program)
        base.FinishedLaunching(app, options)

module Main =
    [<EntryPoint>]
    let main args =
        UIApplication.Main(args, null, typeof<AppDelegate>)
        0
