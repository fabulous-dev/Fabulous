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
    
    type FabulousImage(handler: IViewHandler) =
        inherit View'.FabulousView(handler)
        
        new() = FabulousImage(ImageHandler())
        
        interface IImage with
            member this.UpdateIsLoading(isLoading) = ()
            member this.Aspect = this.GetScalar(Aspect, Microsoft.Maui.Aspect.AspectFit)
            member this.IsAnimationPlaying = false
            member this.IsOpaque = this.GetScalar(IsOpaque, false)
            member this.Source = this.GetScalar(Source, null)
            
    let WidgetKey = Widgets.register<FabulousImage>()

[<AutoOpen>]
module ImageBuilders =
    type Fabulous.Maui.View with
        static member inline Image<'msg>(aspect: Microsoft.Maui.Aspect, path: string) =
            WidgetBuilder<'msg, IImage>(
                Image.WidgetKey,
                Image.Aspect.WithValue(aspect),
                Image.Source.WithValue(FileImageSource.FabulousFileImageSource(path))
            )
