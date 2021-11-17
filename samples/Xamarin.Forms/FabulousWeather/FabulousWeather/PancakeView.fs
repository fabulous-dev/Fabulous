namespace Fabulous.XamarinForms.Samples.FabulousWeather

open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.Widgets
open System.Runtime.CompilerServices

[<AutoOpen>]
module PancakeView =
    let BackgroundGradientStops = Attributes.defineBindable<Xamarin.Forms.PancakeView.GradientStopCollection> Xamarin.Forms.PancakeView.PancakeView.BackgroundGradientStopsProperty
    let Content = Attributes.defineBindableWidget Xamarin.Forms.PancakeView.PancakeView.ContentProperty

    let PancakeViewKey = Widgets.register<Xamarin.Forms.PancakeView.PancakeView>()

    type [<Struct>] PancakeView<'msg> =
        val public ScalarAttributes: ScalarAttribute[]
        val public WidgetAttributes: WidgetAttribute[]
        val public WidgetCollectionAttributes: WidgetCollectionAttribute[]

        new (scalars, widgets, widgetColls) =
            { ScalarAttributes = scalars
              WidgetAttributes = widgets
              WidgetCollectionAttributes = widgetColls }
        
        new (backgroundGradientStops: Xamarin.Forms.PancakeView.GradientStopCollection, content: IViewWidgetBuilder<'msg>) =
            PancakeView<'msg>(
                [| BackgroundGradientStops.WithValue(backgroundGradientStops) |],
                [| Content.WithValue(content.Compile()) |],
                [||]
            )

        interface IViewWidgetBuilder<'msg> with
            member x.Compile() =
                { Key = PancakeViewKey
                  ScalarAttributes = x.ScalarAttributes
                  WidgetAttributes = x.WidgetAttributes
                  WidgetCollectionAttributes = x.WidgetCollectionAttributes }