// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.DynamicViews 

[<AutoOpen>]
module OxyPlotExtension = 

    open System
    open Xamarin.Forms
    open OxyPlot
    open OxyPlot.Axes
    open OxyPlot.Series
    open OxyPlot.Xamarin.Forms
    open Fabulous.DynamicViews

    let ModelAttribKey = AttributeKey<_> "OxyPlot_Model"
    let ControllerAttribKey = AttributeKey<_> "OxyPlot_Controller"

    type Fabulous.DynamicViews.View with
        /// Describes a Map in the view
        static member inline PlotView
            (model: PlotModel, ?controller: PlotController, 
             // inherited attributes common to all views
             ?horizontalOptions, ?verticalOptions, ?margin, ?gestureRecognizers, ?anchorX, ?anchorY, ?backgroundColor, ?heightRequest,
             ?inputTransparent, ?isEnabled, ?isVisible, ?minimumHeightRequest, ?minimumWidthRequest, ?opacity,
             ?rotation, ?rotationX, ?rotationY, ?scale, ?style, ?translationX, ?translationY, ?widthRequest,
             ?resources, ?styles, ?styleSheets, ?classId, ?styleId, ?automationId, ?created, ?styleClass) =

            // Count the number of additional attributes
            let attribCount = 1
            let attribCount = match controller with Some _ -> attribCount + 1 | None -> attribCount 

            // Populate the attributes of the base element
            let attribs =
                ViewBuilders.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions,
                                       ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY,
                                       ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent,
                                       ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest,
                                       ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation,
                                       ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style,
                                       ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest,
                                       ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId,
                                       ?automationId=automationId, ?created=created, ?styleClass=styleClass)

            // Add our own attributes.
            attribs.Add(ModelAttribKey, model) 
            match controller with None -> () | Some v -> attribs.Add(ControllerAttribKey, v) 

            // The create method
            let create () = PlotView()

            // The update method
            let update (prevOpt: ViewElement voption) (source: ViewElement) (target: PlotView) = 
                ViewBuilders.UpdateView (prevOpt, source, target)
                source.UpdatePrimitive(prevOpt, target, ModelAttribKey, (fun target v -> target.Model <- v))
                source.UpdatePrimitive(prevOpt, target, ControllerAttribKey, (fun target v -> target.Controller <- v))

            // The element
            ViewElement.Create(create, update, attribs)

#if DEBUG 

    module Sample1 = 
        let plotModelCos =
            let model = PlotModel(Title = "Example 1")
            model.Series.Add(new OxyPlot.Series.FunctionSeries(Math.Cos, 0.0, 10.0, 0.1, "cos(x)"))
            model

        let plotModelHeatMap =
            let model = PlotModel (Title = "Heatmap")
            model.Axes.Add(LinearColorAxis (Palette = OxyPalettes.Rainbow(100)))
            let singleData = [ for x in 0 .. 99 -> Math.Exp((-1.0 / 2.0) * Math.Pow(((double)x - 50.0) / 20.0, 2.0)) ]
            let data = Array2D.init 100 100 (fun x y -> singleData.[x] * singleData.[(y + 30) % 100] * 100.0)
            let heatMapSeries =
                HeatMapSeries(X0 = 0.0, X1 = 99.0, Y0 = 0.0, Y1 = 99.0, Interpolate = true,
                                RenderMethod = HeatMapRenderMethod.Bitmap, Data = data)
            model.Series.Add(heatMapSeries)
            model

        let plotModels = [ plotModelCos; plotModelHeatMap ]

        let sample = 
            View.CarouselPage(children=
                [ for m in plotModels ->
                        View.ContentPage(content =
                        View.PlotView(model=m,
                                        horizontalOptions=LayoutOptions.FillAndExpand, 
                                        verticalOptions=LayoutOptions.FillAndExpand)) ])
#endif
