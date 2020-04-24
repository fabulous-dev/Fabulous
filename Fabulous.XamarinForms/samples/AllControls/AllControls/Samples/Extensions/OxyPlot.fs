namespace AllControls.Samples.Extensions

open AllControls.Helpers

open Xamarin.Forms
open OxyPlot
open OxyPlot.Axes
open OxyPlot.Series
open System
open Fabulous.XamarinForms
open Fabulous.XamarinForms.OxyPlot

module OxyPlot =
    let plotModelCos =
        let model = PlotModel(Title = "Example 1")
        model.Series.Add(FunctionSeries(Math.Cos, 0.0, 10.0, 0.1, "cos(x)"))
        model

    let plotModelHeatMap =
        let model = PlotModel(Title = "Heatmap")
        model.Axes.Add(LinearColorAxis(Palette = OxyPalettes.Rainbow(100)))
        
        let singleData =
            [ for x in 0 .. 99 ->
                Math.Exp((-1.0 / 2.0) * Math.Pow(((double)x - 50.0) / 20.0, 2.0)) ]
            
        let data = Array2D.init 100 100 (fun x y -> singleData.[x] * singleData.[(y + 30) % 100] * 100.0)
        
        let heatMapSeries =
            HeatMapSeries(X0 = 0.0, X1 = 99.0, Y0 = 0.0, Y1 = 99.0, Interpolate = true,
                            RenderMethod = HeatMapRenderMethod.Bitmap, Data = data)
        model.Series.Add(heatMapSeries)
        model

    let plotModels = [ plotModelCos; plotModelHeatMap ]
    
    let oxyPlotView() = 
        View.ScrollingContentPage("Plot Samples",
            View.StackLayout(
                [
                    for m in plotModels ->
                        View.PlotView(
                            horizontalOptions = LayoutOptions.FillAndExpand, 
                            verticalOptions = LayoutOptions.FillAndExpand,
                            model = m
                        )
                ]
            )
        )
    
    let view() = 
        match Device.RuntimePlatform with
        | Device.Android  | Device.iOS  -> 
            oxyPlotView()
        | _ -> 
            View.NonScrollingContentPage("OxyPlot",
                View.StackLayout [
                    View.Label(text="OxyPlot for XamarinForms 1.0.0 does not support your platform")
                    View.Label(text="For status see https://github.com/oxyplot/oxyplot-xamarin")
                  ])