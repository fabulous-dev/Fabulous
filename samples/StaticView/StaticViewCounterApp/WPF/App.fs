namespace StaticViewCounterApp.WPF

open System

open Xamarin.Forms
open Xamarin.Forms.Platform.WPF

type MainWindow() = 
    inherit FormsApplicationPage()

module Main = 
    [<EntryPoint>]
    [<STAThread>]
    let main(_args) =

        let app = new System.Windows.Application()
        Forms.Init()
        let window = MainWindow() 
        window.LoadApplication(new StaticViewCounterApp.StaticViewCounterApp())

        app.Run(window)
