namespace Fabulous.XamarinForms

open System
open System.IO
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type IImageCell =
    inherit ITextCell

module ImageCell =
    let WidgetKey = Widgets.register<ImageCell> ()

    let ImageSource =
        Attributes.defineAppThemeBindable<ImageSource> ImageCell.ImageSourceProperty

[<AutoOpen>]
module ImageCellBuilders =
    type Fabulous.XamarinForms.View with
        static member inline ImageCell<'msg>(light: ImageSource, ?dark: ImageSource) =
            WidgetBuilder<'msg, IImageCell>(
                ImageCell.WidgetKey,
                ImageCell.ImageSource.WithValue(AppTheme.create light dark)
            )

        static member inline ImageCell<'msg>(light: string, ?dark: string) =
            let light = ImageSource.FromFile(light)

            let dark =
                match dark with
                | None -> None
                | Some v -> Some(ImageSource.FromFile(v))

            View.ImageCell<'msg>(light, ?dark = dark)

        static member inline ImageCell<'msg>(light: Uri, ?dark: Uri) =
            let light = ImageSource.FromUri(light)

            let dark =
                match dark with
                | None -> None
                | Some v -> Some(ImageSource.FromUri(v))

            View.ImageCell<'msg>(light, ?dark = dark)

        static member inline ImageCell<'msg>(light: Stream, ?dark: Stream) =
            let light = ImageSource.FromStream(fun () -> light)

            let dark =
                match dark with
                | None -> None
                | Some v -> Some(ImageSource.FromStream(fun () -> v))

            View.ImageCell<'msg>(light, ?dark = dark)
