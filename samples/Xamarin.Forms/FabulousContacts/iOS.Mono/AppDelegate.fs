namespace FabulousContacts.iOS

open System
open System.IO
open Plugin.Media
open UIKit
open Foundation
open Xamarin
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

        if not(Directory.Exists libFolder) then
            Directory.CreateDirectory(libFolder) |> ignore
        else
            ()

        Path.Combine(libFolder, "Contacts.db3")

    override this.FinishedLaunching(app, options) =
        Forms.Init()
        FormsMaps.Init()

        CrossMedia.Current.Initialize()
        |> Async.AwaitTask
        |> ignore

        let dbPath = getDbPath()

        let application =
            Program.startApplicationWithArgs dbPath App.program

        this.LoadApplication(application)
        base.FinishedLaunching(app, options)

module Main =
    [<EntryPoint>]
    let main args =
        UIApplication.Main(args, null, typeof<AppDelegate>)
        0
