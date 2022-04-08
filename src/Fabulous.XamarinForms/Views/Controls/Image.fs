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
    let WidgetKey = Widgets.register<Image>()

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
            WidgetBuilder<'msg, IImage>(
                Image.WidgetKey,
                Image.Aspect.WithValue(aspect),
                Image.Source.WithValue(AppTheme.create light dark)
            )

        static member inline Image<'msg>(aspect: Aspect, light: string, ?dark: string) =
            let light = ImageSource.FromFile(light)

            let dark =
                match dark with
                | None -> None
                | Some v -> Some(ImageSource.FromFile(v))

            View.Image<'msg>(aspect, light, ?dark = dark)

        static member inline Image<'msg>(aspect: Aspect, light: Uri, ?dark: Uri) =
            let light = ImageSource.FromUri(light)

            let dark =
                match dark with
                | None -> None
                | Some v -> Some(ImageSource.FromUri(v))

            View.Image<'msg>(aspect, light, ?dark = dark)

        static member inline Image<'msg>(aspect: Aspect, light: Stream, ?dark: Stream) =
            let light = ImageSource.FromStream(fun () -> light)

            let dark =
                match dark with
                | None -> None
                | Some v -> Some(ImageSource.FromStream(fun () -> v))

            View.Image<'msg>(aspect, light, ?dark = dark)

[<Extension>]
type ImageModifiers =
    [<Extension>]
    static member inline isAnimationPlaying(this: WidgetBuilder<'msg, #IImage>, isAnimationPlaying: bool) =
        this.AddScalar(Image.IsAnimationPlaying.WithValue(isAnimationPlaying))

    [<Extension>]
    static member inline isOpaque(this: WidgetBuilder<'msg, #IImage>, isOpaque: bool) =
        this.AddScalar(Image.IsOpaque.WithValue(isOpaque))

    /// <summary>Link a ViewRef to access the direct Image control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IImage>, value: ViewRef<Image>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
