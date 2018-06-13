open Xamarin.Forms.Platform.WPF
open Xamarin.Forms
open System
open AllControls

type MainWindow() as this =
    inherit FormsApplicationPage()

    do Forms.Init()
    do this.LoadApplication(new App())

[<STAThread>] 
[<EntryPoint>]
let main argv = 
    (new System.Windows.Application()).Run(MainWindow()) // return an integer exit code