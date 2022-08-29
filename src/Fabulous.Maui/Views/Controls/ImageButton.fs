namespace Fabulous.Maui

open Microsoft.Maui
open Microsoft.Maui.Handlers
open Fabulous

type FabImageButton(handler: IButtonHandler) =
    inherit FabButton(handler)
    
    static let _widgetKey = Widgets.register<FabImageButton>()
    static member WidgetKey = _widgetKey
    
    new() = FabImageButton(ButtonHandler())
        
    interface IImageSourcePart with
        member this.UpdateIsLoading(isLoading) = ()
        member this.IsAnimationPlaying = false
        member this.Source = this.GetScalar(ImageSourcePart.Source, ImageSourcePart.Defaults.Source)
    
    interface Microsoft.Maui.IImage with
        member this.Aspect = this.GetScalar(ImagePart.Aspect, ImagePart.Defaults.Aspect)
        member this.IsOpaque = this.GetScalar(ImagePart.IsOpaque, ImagePart.Defaults.IsOpaque)
    
    interface IImageButton
    
[<AutoOpen>]
module ImageButtonBuilders =
    type Fabulous.Maui.View with
        static member inline ImageButton<'msg>(aspect: Aspect, imagePath: string, onClicked: 'msg) =
            WidgetBuilder<'msg, IImageButton>(
                FabImageButton.WidgetKey,
                ImagePart.Aspect.WithValue(aspect),
                ImageSourcePart.Source.WithValue(ImageSources.FabulousFileImageSource(imagePath)),
                Button.Clicked.WithValue(fun () -> box onClicked)
            )