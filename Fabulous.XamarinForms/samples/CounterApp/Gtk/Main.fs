namespace CounterApp.Gtk

open System
open Xamarin.Forms
open Xamarin.Forms.Platform.GTK

module Main =
    [<EntryPoint>]
    let Main(args) =
        Gtk.Application.Init()
        Forms.Init()

        let app = new CounterApp.CounterApp()
        let window = new FormsWindow()
        window.LoadApplication(app)
        window.SetApplicationTitle("CounterApp")
        window.Show();

        Gtk.Application.Run()
        0
