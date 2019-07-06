Fabulous for Xamarin.Forms - Guide
=======

{% include_relative contents-views.md %}

Using OxyPlot Charts
-----------

Below is an example of an extension for [OxyPlot](http://docs.oxyplot.org/). To use the extension:

1. Follow the instructions to [add references and initialize renderers](http://docs.oxyplot.org/en/latest/getting-started/hello-xamarin-forms.html)
2. Add a reference to the [`Fabulous.XamarinForms.OxyPlot`](https://www.nuget.org/packages/Fabulous.XamarinForms.OxyPlot) package across your solution.

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
    View.CarouselPage(children=
        [ for m in plotModels ->
                View.ContentPage(content =
                View.PlotView(model=m,
                                horizontalOptions=LayoutOptions.FillAndExpand,
                                verticalOptions=LayoutOptions.FillAndExpand)) ])
```

See also:

* [Core Elements](views-elements.md)
* [View Extensions](views-extending.md)
