namespace NewApp.Gtk
    module Main =

        open System
        open Xamarin.Forms
        open Xamarin.Forms.Platform.GTK

        [<EntryPoint>]
        let Main(args) =
            Gtk.Application.Init()
            Forms.Init()

            let app = new NewApp.App()
            let window = new FormsWindow()
            window.LoadApplication(app)
            window.SetApplicationTitle("Hello Fabulous GTK#")
            window.Show();

            Gtk.Application.Run()
            0
