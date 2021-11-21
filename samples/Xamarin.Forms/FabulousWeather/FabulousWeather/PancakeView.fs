namespace Fabulous.XamarinForms.Samples.FabulousWeather

open Fabulous
open Fabulous.Attributes
open Fabulous.XamarinForms
open Fabulous.XamarinForms.Widgets
open System.Runtime.CompilerServices

[<AutoOpen>]
module PancakeView =
    let BackgroundGradientStops = Attributes.defineBindable<Xamarin.Forms.PancakeView.GradientStopCollection> Xamarin.Forms.PancakeView.PancakeView.BackgroundGradientStopsProperty
    let Content = Attributes.defineBindableWidget Xamarin.Forms.PancakeView.PancakeView.ContentProperty


    type [<Struct>] PancakeView<'msg> (attrs: AttributesBuilder) =
        static let key = Widgets.register<Xamarin.Forms.PancakeView.PancakeView>()
        member _.Builder = attrs
        
        static member inline Create (backgroundGradientStops: Xamarin.Forms.PancakeView.GradientStopCollection, content: IViewWidgetBuilder<'msg>) =
            PancakeView<'msg>(
                AttributesBuilder(
                    [| BackgroundGradientStops.WithValue(backgroundGradientStops) |],
                    [| Content.WithValue(content.Compile()) |],
                    [||]
                )
            )

        interface IViewWidgetBuilder<'msg> with
            member x.Compile() = attrs.Build(key)

    type Fabulous.XamarinForms.View with
        static member inline PancakeView<'msg>(backgroundGradientStops, content) = PancakeView<'msg>.Create(backgroundGradientStops, content)