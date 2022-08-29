namespace Fabulous.Maui

open System.IO
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Handlers

module Image =
    let Aspect = Attributes.defineMauiScalarWithEquality<Aspect> "Aspect"
    let IsOpaque = Attributes.defineMauiScalarWithEquality<bool> "IsOpaque"
    
    module Defaults =
        let [<Literal>] Aspect: Aspect = Microsoft.Maui.Aspect.AspectFit
        let [<Literal>] IsOpaque: bool = false
    
type FabImage(handler: IViewHandler) =
    inherit FabView(handler)
    
    static let _widgetKey = Widgets.register<FabImage>()
    static member WidgetKey = _widgetKey
    
    new() = FabImage(ImageHandler())
    
    interface IImageSourcePart with
        member this.UpdateIsLoading(isLoading) = ()
        member this.IsAnimationPlaying = false
        member this.Source = this.GetScalar(ImageSourcePart.Source, ImageSourcePart.Defaults.Source)
    
    interface IImage with
        member this.Aspect = this.GetScalar(Image.Aspect, Image.Defaults.Aspect)
        member this.IsOpaque = this.GetScalar(Image.IsOpaque, Image.Defaults.IsOpaque)

[<AutoOpen>]
module ImageBuilders =
    type Fabulous.Maui.View with
        static member inline Image<'msg>(aspect: Aspect, path: string) =
            WidgetBuilder<'msg, IImage>(
                FabImage.WidgetKey,
                Image.Aspect.WithValue(aspect),
                ImageSourcePart.Source.WithValue(ImageSources.FabulousFileImageSource(path))
            )
            
        static member inline Image<'msg>(aspect: Aspect, stream: Stream) =
            WidgetBuilder<'msg, IImage>(
                FabImage.WidgetKey,
                Image.Aspect.WithValue(aspect),
                ImageSourcePart.Source.WithValue(ImageSources.FabulousStreamImageSource(stream))
            )
