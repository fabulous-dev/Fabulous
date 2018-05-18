open Xamarin.Forms.Platform.WPF
open Xamarin.Forms
open System

// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

type MainWindow() as this =
    inherit FormsApplicationPage()

    do Forms.Init()
    do this.LoadApplication(new CounterApp.CounterApp())

[<STAThread>] 
[<EntryPoint>]
let main argv = 
    (new System.Windows.Application()).Run(MainWindow()) // return an integer exit code
