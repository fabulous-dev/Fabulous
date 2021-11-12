namespace Fabulous.XamarinForms.Samples.FabulousWeather

open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.Widgets
open System.Runtime.CompilerServices

[<AutoOpen>]
module PancakeView =
    let BackgroundGradientStops = XamarinFormsAttributes.defineBindable<Xamarin.Forms.PancakeView.GradientStopCollection> Xamarin.Forms.PancakeView.PancakeView.BackgroundGradientStopsProperty
    let Content = XamarinFormsAttributes.defineBindableWidget Xamarin.Forms.PancakeView.PancakeView.ContentProperty

    type [<Struct>] PancakeViewWidgetBuilder<'msg> (attributes: Attribute[]) =
        static let key = Widgets.registerNoChildren<Xamarin.Forms.PancakeView.PancakeView>()

        static member inline Create(backgroundGradientStops: Xamarin.Forms.PancakeView.GradientStopCollection, content: IViewWidgetBuilder<'msg>) =
            PancakeViewWidgetBuilder<'msg>([|
                BackgroundGradientStops.WithValue(backgroundGradientStops)
                Content.WithValue(content.Compile())
            |])

        interface IViewWidgetBuilder<'msg> with
            member _.Attributes = attributes
            member _.Compile() =
                { Key = key
                  Attributes = attributes }

    type Fabulous.XamarinForms.View with
        static member inline PancakeView(backgroundGradientStops, content) = PancakeViewWidgetBuilder.Create(backgroundGradientStops, content)