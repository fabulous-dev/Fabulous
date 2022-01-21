namespace Fabulous.XamarinForms.Samples.FabulousWeather

open Fabulous
open Fabulous.XamarinForms
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IPancakeView =
    inherit IView

module PancakeView =
    let WidgetKey =
        Widgets.register<Xamarin.Forms.PancakeView.PancakeView> ()

    let BackgroundGradientStops =
        Attributes.defineBindable<Xamarin.Forms.PancakeView.GradientStopCollection>
            Xamarin.Forms.PancakeView.PancakeView.BackgroundGradientStopsProperty

    let Content =
        Attributes.defineBindableWidget Xamarin.Forms.PancakeView.PancakeView.ContentProperty

[<AutoOpen>]
module PancakeViewBuilders =
    type Fabulous.XamarinForms.View with
        static member inline PancakeView<'msg, 'marker when 'marker :> IView>
            (
                backgroundGradientStops,
                content: WidgetBuilder<'msg, 'marker>
            ) =
            WidgetBuilder<'msg, IPancakeView>(
                PancakeView.WidgetKey,
                AttributesBundle(
                    StackList.one (PancakeView.BackgroundGradientStops.WithValue(backgroundGradientStops)),
                    ValueSome [| PancakeView.Content.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
