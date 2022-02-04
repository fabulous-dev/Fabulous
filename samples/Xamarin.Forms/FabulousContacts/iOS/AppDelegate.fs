namespace FabulousContacts.iOS

open System
open System.IO
open Plugin.Media
open UIKit
open Foundation
open Xamarin.Essentials
open Xamarin.Forms
open Xamarin.Forms.Platform.iOS
open FabulousContacts
open Fabulous.XamarinForms

[<Register("AppDelegate")>]
type AppDelegate() =
    inherit FormsApplicationDelegate()

    let getDbPath () =
        let docFolder =
            Environment.GetFolderPath(Environment.SpecialFolder.Personal)

        let libFolder =
            Path.Combine(docFolder, "..", "Library", "Databases")

        if not (Directory.Exists libFolder) then
            Directory.CreateDirectory(libFolder) |> ignore
        else
            ()

        Path.Combine(libFolder, "Contacts.db3")

    override this.FinishedLaunching(app, options) =
        Forms.Init()
        //FormsMaps.Init()

        CrossMedia.Current.Initialize()
        |> Async.AwaitTask
        |> ignore

        let dbPath = getDbPath ()
        let appx = (App.program dbPath)
        let application: Xamarin.Forms.Application = unbox (Program.create appx ())
        this.LoadApplication(application)
        base.FinishedLaunching(app, options)
