namespace Fabulous.XamarinForms.Samples.FabulousWeather

open Fabulous
open Fabulous.XamarinForms
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

[<AutoOpen>]
module PancakeView =
    let BackgroundGradientStops =
        Attributes.defineBindable<Xamarin.Forms.PancakeView.GradientStopCollection>
            Xamarin.Forms.PancakeView.PancakeView.BackgroundGradientStopsProperty

    let Content =
        Attributes.defineBindableWidget Xamarin.Forms.PancakeView.PancakeView.ContentProperty

    let PancakeViewKey =
        Widgets.register<Xamarin.Forms.PancakeView.PancakeView>()

    type IPancakeView =
        inherit IView

    type Fabulous.XamarinForms.View with
        static member inline PancakeView<'msg, 'marker when 'marker :> IView>
            (
                backgroundGradientStops,
                content: WidgetBuilder<'msg, 'marker>
            ) =
            WidgetBuilder<'msg, IPancakeView>(
                PancakeViewKey,

                AttributesBundle(
                    StackList.one(BackgroundGradientStops.WithValue(backgroundGradientStops)),
                    Some [| Content.WithValue(content.Compile()) |],
                    None
                )
            )
