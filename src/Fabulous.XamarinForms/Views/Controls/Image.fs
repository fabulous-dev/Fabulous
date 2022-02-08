namespace Fabulous.XamarinForms

open System
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open System.IO

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

        static member inline Image<'msg>(aspect: Aspect, light: ImageSource, ?dark: ImageSource) =
            let appTheme =
                Attributes.getAppTheme<ImageSource> light dark

            WidgetBuilder<'msg, IImage>(
                Image.WidgetKey,
                Image.Aspect.WithValue(aspect),
                Image.Source.WithValue(appTheme)
            )

        static member inline Image<'msg>(aspect: Aspect, light: string, ?dark: string) =
            match dark with
            | Some dark -> View.Image<'msg>(aspect, ImageSource.FromFile(light), ImageSource.FromFile(dark))
            | None -> View.Image<'msg>(aspect, ImageSource.FromFile(light))

        static member inline Image<'msg>(aspect: Aspect, light: Uri, ?dark: Uri) =
            match dark with
            | Some dark -> View.Image<'msg>(aspect, ImageSource.FromUri(light), ImageSource.FromUri(dark))
            | None -> View.Image<'msg>(aspect, ImageSource.FromUri(light))


        static member inline Image<'msg>(aspect: Aspect, light: Stream, ?dark: Stream) =
            match dark with
            | Some dark ->
                View.Image<'msg>(
                    aspect,
                    ImageSource.FromStream(fun () -> light),
                    ImageSource.FromStream(fun () -> dark)
                )
            | None -> View.Image<'msg>(aspect, ImageSource.FromStream(fun () -> light))

[<Extension>]
type ImageModifiers =
    [<Extension>]
    static member inline isAnimationPlaying(this: WidgetBuilder<'msg, #IImage>, isAnimationPlaying: bool) =
        this.AddScalar(Image.IsAnimationPlaying.WithValue(isAnimationPlaying))

    [<Extension>]
    static member inline isOpaque(this: WidgetBuilder<'msg, #IImage>, isOpaque: bool) =
        this.AddScalar(Image.IsOpaque.WithValue(isOpaque))
