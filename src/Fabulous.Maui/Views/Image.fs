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
    
type FabImage(handler: IViewHandler) =
    inherit FabView(handler)
    
    static let _widgetKey = Widgets.register<FabImage>()
    static member WidgetKey = _widgetKey
    
    new() = FabImage(ImageHandler())
    
    interface IImage with
        member this.UpdateIsLoading(isLoading) = ()
        member this.Aspect = this.GetScalar(Image.Aspect, Aspect.AspectFit)
        member this.IsAnimationPlaying = false
        member this.IsOpaque = this.GetScalar(Image.IsOpaque, false)
        member this.Source = this.GetScalar(Image.Source, null)
            

[<AutoOpen>]
module ImageBuilders =
    type Fabulous.Maui.View with
        static member inline Image<'msg>(aspect: Aspect, path: string) =
            WidgetBuilder<'msg, IImage>(
                FabImage.WidgetKey,
                Image.Aspect.WithValue(aspect),
                Image.Source.WithValue(FileImageSource.FabulousFileImageSource(path))
            )
