namespace Fabulous.XamarinForms.Samples.FabulousWeather

open Fabulous
open Fabulous.XamarinForms

[<AutoOpen>]
module PancakeView =
    let BackgroundGradientStops = Attributes.defineBindable<Xamarin.Forms.PancakeView.GradientStopCollection> Xamarin.Forms.PancakeView.PancakeView.BackgroundGradientStopsProperty
    let Content = Attributes.defineBindableWidget Xamarin.Forms.PancakeView.PancakeView.ContentProperty
    let PancakeViewKey = Widgets.register<Xamarin.Forms.PancakeView.PancakeView>()
    
    type IPancakeViewMarker = inherit IViewMarker

    type Fabulous.XamarinForms.View with
        static member inline PancakeView<'msg, 'marker when 'marker :> IViewMarker>(backgroundGradientStops, content: WidgetBuilder<'msg, 'marker>) =
            ViewHelpers.build<'msg, IPancakeViewMarker> PancakeViewKey
                [| BackgroundGradientStops.WithValue(backgroundGradientStops) |]
                [| Content.WithValue(content.Compile()) |]
                [||]