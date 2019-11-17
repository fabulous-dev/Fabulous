namespace CounterApp.Gtk

open System
open Xamarin.Forms
open Xamarin.Forms.Platform.GTK

module Main =
    [<EntryPoint>]
    let Main(args) =
        Gtk.Application.Init()
        Forms.Init()

        let app = new FabulousWeather.App()
        let window = new FormsWindow()
        window.LoadApplication(app)
        window.SetApplicationTitle("Fabulous Weather")
        window.Show();

        Gtk.Application.Run()
        0
