namespace TestableApp.iOS

open Avalonia
open Avalonia.iOS
open Fabulous.Avalonia
open Foundation
open TestableApp
open UIKit

[<Register(nameof AppDelegate)>]
type AppDelegate() =
    inherit AvaloniaAppDelegate<FabApplication>()

    override this.CreateAppBuilder() =
        AppBuilder.Configure<FabApplication>().UseiOS()

module Main =
    [<EntryPoint>]
    let main (args: string array) =
        UIApplication.Main(args, null, typeof<AppDelegate>)
        0
