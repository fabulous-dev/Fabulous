namespace Fabulous.Maui

#nowarn "44"

open System
open System.IO
open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls

type IFabImageCell =
    inherit IFabTextCell

module ImageCell =
    let WidgetKey = Widgets.register<ImageCell>()

    let ImageSource = Attributes.defineBindableImageSource ImageCell.ImageSourceProperty

[<AutoOpen>]
module ImageCellBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create an ImageCell widget with a text and an image source</summary>
        /// <param name="text">The text of the cell</param>
        /// <param name="source">The image source</param>
        static member inline ImageCell<'msg when 'msg: equality>(text: string, source: ImageSource) =
            WidgetBuilder<'msg, IFabImageCell>(
                ImageCell.WidgetKey,
                TextCell.Text.WithValue(text),
                ImageCell.ImageSource.WithValue(ImageSourceValue.Source source)
            )

        /// <summary>Create an ImageCell widget with a text and an image source</summary>
        /// <param name="text">The text of the cell</param>
        /// <param name="source">The image source</param>
        static member inline ImageCell<'msg when 'msg: equality>(text: string, source: string) =
            WidgetBuilder<'msg, IFabImageCell>(
                ImageCell.WidgetKey,
                TextCell.Text.WithValue(text),
                ImageCell.ImageSource.WithValue(ImageSourceValue.File source)
            )

        /// <summary>Create an ImageCell widget with a text and an image source</summary>
        /// <param name="text">The text of the cell</param>
        /// <param name="source">The image source</param>
        static member inline ImageCell<'msg when 'msg: equality>(text: string, source: Uri) =
            WidgetBuilder<'msg, IFabImageCell>(ImageCell.WidgetKey, TextCell.Text.WithValue(text), ImageCell.ImageSource.WithValue(ImageSourceValue.Uri source))

        /// <summary>Create an ImageCell widget with a text and an image source</summary>
        /// <param name="text">The text of the cell</param>
        /// <param name="source">The image source</param>
        static member inline ImageCell<'msg when 'msg: equality>(text: string, source: Stream) =
            WidgetBuilder<'msg, IFabImageCell>(
                ImageCell.WidgetKey,
                TextCell.Text.WithValue(text),
                ImageCell.ImageSource.WithValue(ImageSourceValue.Stream source)
            )

[<Extension>]
type ImageCellModifiers =
    /// <summary>Link a ViewRef to access the direct ImageCell control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabImageCell>, value: ViewRef<ImageCell>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
