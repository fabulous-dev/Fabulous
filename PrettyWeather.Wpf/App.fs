namespace PrettyWeather.Wpf

open System

open Xamarin.Forms
open Xamarin.Forms.Platform.WPF
open System.Windows
open System.Windows.Controls


type PancakeViewRenderer() =
    inherit ViewRenderer<PancakeView.PancakeView, Grid>()
    override this.OnElementChanged e = 
        this.Control.Children.Clear()
        let element = this.Element.Content;
        
        //this.Control.Children.Add(e.NewElement.Content)
        ()


type MainWindow() = 
    inherit FormsApplicationPage()

module Main = 
    [<EntryPoint>]
    [<STAThread>]
    let main(_args) =

        let app = new System.Windows.Application()
        Forms.Init()
        let window = MainWindow() 
        window.LoadApplication(new PrettyWeather.PrettyWeatherApp())

        app.Run(window)
