namespace Calculator.Gtk

open System
open Xamarin.Forms
open Xamarin.Forms.Platform.GTK

module Main =
    [<EntryPoint>]
    let Main(args) =
        Gtk.Application.Init()
        Forms.Init()

        let app = new Calculator.CalculatorApp()
        let window = new FormsWindow()
        window.LoadApplication(app)
        window.SetApplicationTitle("Calculator")
        window.Show();

        Gtk.Application.Run()
        0
