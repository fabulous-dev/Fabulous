namespace NewApp.macOS

open System
open AppKit
open Foundation
open Xamarin.Forms
open Xamarin.Forms.Platform.MacOS

[<Register("AppDelegate")>]
type AppDelegate() =
    inherit FormsApplicationDelegate()
    let  style = NSWindowStyle.Closable ||| NSWindowStyle.Resizable ||| NSWindowStyle.Titled

    let  rect = new CoreGraphics.CGRect(nfloat 200.0, nfloat 1000.0, nfloat 1024.0, nfloat 768.0)

    let window = new NSWindow(rect, style, NSBackingStore.Buffered, false, Title = "Xamarin.Forms on Mac!", TitleVisibility = NSWindowTitleVisibility.Hidden)

    override __.MainWindow = window

    override this.DidFinishLaunching(notification: NSNotification) =
        Forms.Init()
        this.SetupNativeMenu()
        this.LoadApplication(new NewApp.App())

        base.DidFinishLaunching(notification)

    override __.WillTerminate(notification: NSNotification) =
        // Insert code here to tear down your application
        ()
        
    override __.ApplicationShouldTerminateAfterLastWindowClosed(_) = true        

    member this.SetupNativeMenu() =
        let menuBar = new NSMenu()
        let appMenuItem = new NSMenuItem()
        menuBar.AddItem(appMenuItem)
        
        let appMenu = new NSMenu()
        appMenuItem.Submenu <- appMenu
        
        let quitMenuItem = new NSMenuItem(sprintf "Quit %s" window.Title, "q", EventHandler(fun _ _ ->
            NSApplication.SharedApplication.Terminate(menuBar)
        ))
        appMenu.AddItem(quitMenuItem)
            
        NSApplication.SharedApplication.MainMenu <- menuBar

module EntryClass = 
    [<EntryPoint>]
    let Main(args: string[]) =
        NSApplication.Init() |> ignore
        NSApplication.SharedApplication.Delegate <- new AppDelegate()
        NSApplication.Main(args)
        0
