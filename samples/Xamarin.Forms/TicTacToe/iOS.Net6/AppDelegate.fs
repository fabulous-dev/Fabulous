namespace TicTacToe.iOS

open System
open UIKit
open Foundation
open Xamarin.Essentials
open Xamarin.Forms
open Xamarin.Forms.Platform.iOS
open TicTacToe
open Fabulous.XamarinForms

[<Register("AppDelegate")>]
type AppDelegate() =
    inherit FormsApplicationDelegate()

    override this.FinishedLaunching(app, options) =
        Forms.Init()
        let application: Xamarin.Forms.Application = unbox(Program.create App.program ())
        this.LoadApplication(application)
        base.FinishedLaunching(app, options)
