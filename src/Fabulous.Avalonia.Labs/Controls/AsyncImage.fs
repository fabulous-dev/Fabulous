namespace Fabulous.Avalonia

open System
open System.IO
open System.Runtime.CompilerServices
open Avalonia.Animation
open Avalonia.Labs.Controls
open Avalonia.Media
open Avalonia.Media.Imaging
open Fabulous
open Fabulous.Avalonia

type IFabAsyncImage =
    inherit IFabTemplatedControl

module AsyncImage =

    let WidgetKey = Widgets.register<AsyncImage>()

    let PlaceholderSource =
        Attributes.defineBindableImageSource AsyncImage.PlaceholderSourceProperty

    let Source = Attributes.defineAvaloniaPropertyWithEquality AsyncImage.SourceProperty

    let Stretch =
        Attributes.defineAvaloniaPropertyWithEquality AsyncImage.StretchProperty

    let PlaceholderStretch =
        Attributes.defineAvaloniaPropertyWithEquality AsyncImage.PlaceholderStretchProperty

    let State = Attributes.defineAvaloniaPropertyWithEquality AsyncImage.StateProperty

    let ImageTransition =
        Attributes.defineAvaloniaPropertyWithEquality AsyncImage.ImageTransitionProperty

    let IsCacheEnabled =
        Attributes.defineAvaloniaPropertyWithEquality AsyncImage.IsCacheEnabledProperty

[<AutoOpen>]
module AsyncImageBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Create an AsyncImage widget.</summary>
        static member AsyncImage() =
            WidgetBuilder<'msg, IFabAsyncImage>(AsyncImage.WidgetKey)

        /// <summary>Create an AsyncImage widget with the specified source.</summary>
        /// <param name="source">The image source.</param>
        static member AsyncImage(source: Bitmap) =
            WidgetBuilder<'msg, IFabAsyncImage>(AsyncImage.WidgetKey, AsyncImage.Source.WithValue(source))

        /// <summary>Create an AsyncImage widget with the specified source.</summary>
        /// <param name="source">The uri of the image source.</param>
        static member AsyncImage(source: Uri) =
            WidgetBuilder<'msg, IFabAsyncImage>(AsyncImage.WidgetKey, AsyncImage.Source.WithValue(source))

        /// <summary>Create an AsyncImage widget with the specified source.</summary>
        /// <param name="source">The string uri of the image source.</param>
        static member AsyncImage(source: string) =
            WidgetBuilder<'msg, IFabAsyncImage>(AsyncImage.WidgetKey, AsyncImage.Source.WithValue(Uri(source)))

type AsyncImageModifiers =
    /// <summary>Sets the PlaceholderSource property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlaceholderSource value.</param>
    [<Extension>]
    static member inline placeholderSource(this: WidgetBuilder<'msg, #IFabAsyncImage>, value: Bitmap) =
        this.AddScalar(AsyncImage.PlaceholderSource.WithValue(ImageSourceValue.Bitmap(value)))

    /// <summary>Sets the PlaceholderSource property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlaceholderSource value.</param>
    [<Extension>]
    static member inline placeholderSource(this: WidgetBuilder<'msg, #IFabAsyncImage>, value: string) =
        this.AddScalar(AsyncImage.PlaceholderSource.WithValue(ImageSourceValue.File(value)))

    /// <summary>Sets the PlaceholderSource property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlaceholderSource value.</param>
    [<Extension>]
    static member inline placeholderSource(this: WidgetBuilder<'msg, #IFabAsyncImage>, value: Uri) =
        this.AddScalar(AsyncImage.PlaceholderSource.WithValue(ImageSourceValue.Uri(value)))

    /// <summary>Sets the PlaceholderSource property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlaceholderSource value.</param>
    [<Extension>]
    static member inline placeholderSource(this: WidgetBuilder<'msg, #IFabAsyncImage>, value: Stream) =
        this.AddScalar(AsyncImage.PlaceholderSource.WithValue(ImageSourceValue.Stream(value)))

    /// <summary>Sets the Stretch property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Stretch value.</param>
    [<Extension>]
    static member inline stretch(this: WidgetBuilder<'msg, #IFabAsyncImage>, value: Stretch) =
        this.AddScalar(AsyncImage.Stretch.WithValue(value))

    /// <summary>Sets the PlaceholderStretch property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlaceholderStretch value.</param>
    [<Extension>]
    static member inline placeholderStretch(this: WidgetBuilder<'msg, #IFabAsyncImage>, value: Stretch) =
        this.AddScalar(AsyncImage.PlaceholderStretch.WithValue(value))

    /// <summary>Sets the State property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The State value.</param>
    [<Extension>]
    static member inline state(this: WidgetBuilder<'msg, #IFabAsyncImage>, value: AsyncImageState) =
        this.AddScalar(AsyncImage.State.WithValue(value))

    /// <summary>Sets the ImageTransition property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ImageTransition value.</param>
    [<Extension>]
    static member inline imageTransition(this: WidgetBuilder<'msg, #IFabAsyncImage>, value: IPageTransition) =
        this.AddScalar(AsyncImage.ImageTransition.WithValue(value))

    /// <summary>Sets the IsCacheEnabled property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsCacheEnabled value.</param>
    [<Extension>]
    static member inline isCacheEnabled(this: WidgetBuilder<'msg, #IFabAsyncImage>, value: bool) =
        this.AddScalar(AsyncImage.IsCacheEnabled.WithValue(value))

    /// <summary>Link a ViewRef to access the direct AsyncImage control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabAsyncImage>, value: ViewRef<AsyncImage>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
