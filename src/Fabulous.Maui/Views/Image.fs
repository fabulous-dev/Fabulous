namespace Fabulous.Maui

open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui
open Microsoft.Maui.Handlers

module FileImageSource =
    [<Struct>]
    type FabulousFileImageSource(file: string) =
        interface IFileImageSource with
            member this.File = file
            member this.IsEmpty = false

module Image =
    let Aspect = Attributes.defineMauiScalarWithEquality<Aspect> "Aspect"
    let IsOpaque = Attributes.defineMauiScalarWithEquality<bool> "IsOpaque"
    let Source = Attributes.defineMauiScalarWithEquality<IImageSource> "Source"
    
    module Defaults =
        let [<Literal>] Aspect: Aspect = Microsoft.Maui.Aspect.AspectFit
        let [<Literal>] IsOpaque: bool = false
        let [<Literal>] Source: IImageSource = null
    
type FabImage(handler: IViewHandler) =
    inherit FabView(handler)
    
    static let _widgetKey = Widgets.register<FabImage>()
    static member WidgetKey = _widgetKey
    
    new() = FabImage(ImageHandler())
    
    interface IImage with
        member this.UpdateIsLoading(isLoading) = ()
        member this.Aspect = this.GetScalar(Image.Aspect, Image.Defaults.Aspect)
        member this.IsAnimationPlaying = false
        member this.IsOpaque = this.GetScalar(Image.IsOpaque, Image.Defaults.IsOpaque)
        member this.Source = this.GetScalar(Image.Source, Image.Defaults.Source)
            

[<AutoOpen>]
module ImageBuilders =
    type Fabulous.Maui.View with
        static member inline Image<'msg>(aspect: Aspect, path: string) =
            WidgetBuilder<'msg, IImage>(
                FabImage.WidgetKey,
                Image.Aspect.WithValue(aspect),
                Image.Source.WithValue(FileImageSource.FabulousFileImageSource(path))
            )
