namespace FabulousWeather.WPF

open System

open Xamarin.Forms
open Xamarin.Forms.Platform.WPF
open Xamarin.Forms.PancakeView
open System.Windows.Controls

type PancakeViewRenderer() = 
    inherit ViewRenderer<PancakeView, Grid>()
    override this.OnElementChanged args =
        base.OnElementChanged args
        let e = args.NewElement
        if this.Control = null then 
            this.SetNativeControl(Grid())
        if e <> null then
            this.Control.Children.Clear()
            let renderer = Platform.CreateRenderer(e.Content)
            this.Control.Children.Add(renderer.GetNativeElement()) |> ignore
            ()
        ()
[<assembly: ExportRenderer(typeof<PancakeView>, typeof<PancakeViewRenderer>)>] do ()
type MainWindow() = 
    inherit FormsApplicationPage()

module Main = 
    [<EntryPoint>]
    [<STAThread>]
    let main(_args) =

        let app = new System.Windows.Application()
        Forms.Init()
        
        let window = MainWindow() 
        window.LoadApplication(new FabulousWeather.App())

        app.Run(window)
