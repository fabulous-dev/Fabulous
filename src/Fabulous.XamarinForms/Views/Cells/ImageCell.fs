namespace Fabulous.XamarinForms

open System
open System.IO
open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IImageCell =
    inherit ITextCell

module ImageCell =
    let WidgetKey = Widgets.register<ImageCell>()

    let ImageSource =
        Attributes.defineBindableAppTheme<ImageSource> ImageCell.ImageSourceProperty

[<AutoOpen>]
module ImageCellBuilders =
    type Fabulous.XamarinForms.View with
        static member inline ImageCell<'msg>(text: string, light: ImageSource, ?dark: ImageSource) =
            WidgetBuilder<'msg, IImageCell>(
                ImageCell.WidgetKey,
                TextCell.Text.WithValue(text),
                ImageCell.ImageSource.WithValue(AppTheme.create light dark)
            )

        static member inline ImageCell<'msg>(text: string, light: string, ?dark: string) =
            let light = ImageSource.FromFile(light)

            let dark =
                match dark with
                | None -> None
                | Some v -> Some(ImageSource.FromFile(v))

            View.ImageCell<'msg>(text, light, ?dark = dark)

        static member inline ImageCell<'msg>(text: string, light: Uri, ?dark: Uri) =
            let light = ImageSource.FromUri(light)

            let dark =
                match dark with
                | None -> None
                | Some v -> Some(ImageSource.FromUri(v))

            View.ImageCell<'msg>(text, light, ?dark = dark)

        static member inline ImageCell<'msg>(text: string, light: Stream, ?dark: Stream) =
            let light = ImageSource.FromStream(fun () -> light)

            let dark =
                match dark with
                | None -> None
                | Some v -> Some(ImageSource.FromStream(fun () -> v))

            View.ImageCell<'msg>(text, light, ?dark = dark)

[<Extension>]
type ImageCellModifiers =
    /// <summary>Link a ViewRef to access the direct ImageCell control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IImageCell>, value: ViewRef<ImageCell>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
