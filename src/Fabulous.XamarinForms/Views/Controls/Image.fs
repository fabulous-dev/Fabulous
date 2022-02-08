namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type IImage =
    inherit IView

module Image =
    let WidgetKey = Widgets.register<Image> ()

    let Aspect =
        Attributes.defineBindable<Aspect> Image.AspectProperty

    let IsAnimationPlaying =
        Attributes.defineBindable<bool> Image.IsAnimationPlayingProperty

    let IsOpaque =
        Attributes.defineBindable<bool> Image.IsOpaqueProperty

    let Source =
        Attributes.defineAppThemeBindable<ImageSource> Image.SourceProperty

[<AutoOpen>]
module ImageBuilders =
    type Fabulous.XamarinForms.View with

        static member inline Image<'msg>(light: ImageSource, aspect: Aspect, ?dark: ImageSource) =
            WidgetBuilder<'msg, IImage>(
                Image.WidgetKey,
                Image.Aspect.WithValue(aspect),
                Image.Source.WithValue(AppThemeValues.create<ImageSource> (light, dark))
            )

        static member inline Image<'msg>(path: string, aspect: Aspect) =
            View.Image<'msg>(ImageSource.FromFile(path), aspect)

        static member inline Image<'msg>(uri: System.Uri, aspect: Aspect) =
            View.Image<'msg>(ImageSource.FromUri(uri), aspect)

        static member inline Image<'msg>(stream: System.IO.Stream, aspect: Aspect) =
            View.Image<'msg>(ImageSource.FromStream(fun () -> stream), aspect)

[<Extension>]
type ImageModifiers =
    [<Extension>]
    static member inline isAnimationPlaying(this: WidgetBuilder<'msg, #IImage>, isAnimationPlaying: bool) =
        this.AddScalar(Image.IsAnimationPlaying.WithValue(isAnimationPlaying))

    [<Extension>]
    static member inline isOpaque(this: WidgetBuilder<'msg, #IImage>, isOpaque: bool) =
        this.AddScalar(Image.IsOpaque.WithValue(isOpaque))
