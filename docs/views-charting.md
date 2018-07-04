Elmish.XamarinForms Guide
=======

{% include_relative contents-views.md %}

Defining a Charts extension
-----------

Below is an example of an extension for [OxyPlot](http://docs.oxyplot.org/). To use the extension:

1. Follow the instructions to [add references and initialize renderers](ttp://docs.oxyplot.org/en/latest/getting-started/hello-xamarin-forms.html)
2. Add the extension code below to your app. 

[![OxyPlot example](https://user-images.githubusercontent.com/7204669/42291878-777cb47c-7fc6-11e8-9eaa-4dfd784bddf2.png)](https://user-images.githubusercontent.com/7204669/42291878-777cb47c-7fc6-11e8-9eaa-4dfd784bddf2.png)

Here is an example translated from [the OxyPlot documentation](http://docs.oxyplot.org/en/latest/models/series/HeatMapSeries.html).
```fsharp
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

let view (model: Model) dispatch =
    Xaml.CarouselPage(children=
        [ for m in plotModels ->
                Xaml.ContentPage(content =
                Xaml.PlotView(model=m,
                                horizontalOptions=LayoutOptions.FillAndExpand, 
                                verticalOptions=LayoutOptions.FillAndExpand)) ])
```

Here is the code for the extension:

```fsharp
[<AutoOpen>]
module OxyPlotExtension =

    open Elmish.XamarinForms.DynamicViews
    open OxyPlot.Xamarin.Forms

    let ModelAttribKey = AttributeKey<_> "OxyPlot_Model"
    let ControllerAttribKey = AttributeKey<_> "OxyPlot_Controller"

    type Xaml with
        /// Describes a Map in the view
        static member inline PlotView
            (model: PlotModel, ?controller: PlotController,
             // inherited attributes common to all views
             ?horizontalOptions, ?verticalOptions, ?margin, ?gestureRecognizers, ?anchorX, ?anchorY, ?backgroundColor, ?heightRequest,
             ?inputTransparent, ?isEnabled, ?isVisible, ?minimumHeightRequest, ?minimumWidthRequest, ?opacity,
             ?rotation, ?rotationX, ?rotationY, ?scale, ?style, ?translationX, ?translationY, ?widthRequest,
             ?resources, ?styles, ?styleSheets, ?classId, ?styleId) =

            // Count the number of additional attributes
            let attribCount = 1
            let attribCount = match controller with Some _ -> attribCount + 1 | None -> attribCount 

            // Populate the attributes of the base element
            let attribs =
                Xaml.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions,
                               ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation,
                               ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style,
                               ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest,
                               ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

            // Add our own attributes.
            attribs.Add(ModelAttribKey, model) 
            match controller with None -> () | Some v -> attribs.Add(ControllerAttribKey, v)

            // The create method
            let create () = new PlotView()

            // The update method
            let update (prevOpt: ViewElement voption) (source: ViewElement) (target: PlotView) =
                Xaml.UpdateView (prevOpt, source, target)
                source.UpdatePrimitive(prevOpt, target, ModelAttribKey, (fun target v -> target.Model <- v))
                source.UpdatePrimitive(prevOpt, target, ControllerAttribKey, (fun target v -> target.Controller <- v))

            // The element
            ViewElement.Create(create, update, attribs)
```

See also:

* [Core Elements](views-elements.md)
* [View Extensions](views-extending.md)
