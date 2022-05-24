namespace Fabulous.XamarinForms

open System.IO
open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms
open System

type IImageButton =
    inherit IView

module ImageButton =
    let WidgetKey = Widgets.register<ImageButton>()

    let Aspect =
        Attributes.defineBindableEnum<Xamarin.Forms.Aspect> ImageButton.AspectProperty

    let BorderColor =
        Attributes.defineBindableAppTheme<Color> ImageButton.BorderColorProperty

    let BorderWidth =
        Attributes.defineBindableFloat ImageButton.BorderWidthProperty

    let CornerRadius =
        Attributes.defineBindableFloat ImageButton.CornerRadiusProperty

    let IsLoading =
        Attributes.defineBindableBool ImageButton.IsLoadingProperty

    let IsOpaque =
        Attributes.defineBindableBool ImageButton.IsOpaqueProperty

    let IsPressed =
        Attributes.defineBindableBool ImageButton.IsPressedProperty

    let Padding =
        Attributes.defineBindableWithEquality<Thickness> ImageButton.PaddingProperty

    let Source =
        Attributes.defineBindableAppTheme<ImageSource> ImageButton.SourceProperty

    let Clicked =
        Attributes.defineEventNoArg "ImageButton_Clicked" (fun target -> (target :?> ImageButton).Clicked)

    let Pressed =
        Attributes.defineEventNoArg "ImageButton_Pressed" (fun target -> (target :?> ImageButton).Pressed)

    let Released =
        Attributes.defineEventNoArg "ImageButton_Released" (fun target -> (target :?> ImageButton).Released)

[<AutoOpen>]
module ImageButtonBuilders =
    type Fabulous.XamarinForms.View with
        static member inline ImageButton<'msg>
            (
                aspect: Aspect,
                light: ImageSource,
                onClicked: 'msg,
                ?dark: ImageSource
            ) =
            WidgetBuilder<'msg, IImageButton>(
                ImageButton.WidgetKey,
                ImageButton.Aspect.WithValue(aspect),
                ImageButton.Clicked.WithValue(onClicked),
                ImageButton.Source.WithValue(AppTheme.create light dark)
            )

        static member inline ImageButton<'msg>(aspect: Aspect, light: string, onClicked: 'msg, ?dark: string) =
            let light = ImageSource.FromFile(light)

            let dark =
                match dark with
                | None -> None
                | Some v -> Some(ImageSource.FromFile(v))

            View.ImageButton<'msg>(aspect, light = light, onClicked = onClicked, ?dark = dark)

        static member inline ImageButton<'msg>(aspect: Aspect, light: Uri, onClicked: 'msg, ?dark: Uri) =
            let light = ImageSource.FromUri(light)

            let dark =
                match dark with
                | None -> None
                | Some v -> Some(ImageSource.FromUri(v))

            View.ImageButton<'msg>(aspect, light = light, onClicked = onClicked, ?dark = dark)

        static member inline ImageButton<'msg>(aspect: Aspect, light: Stream, onClicked: 'msg, ?dark: Stream) =
            let light = ImageSource.FromStream(fun () -> light)

            let dark =
                match dark with
                | None -> None
                | Some v -> Some(ImageSource.FromStream(fun () -> v))

            View.ImageButton<'msg>(aspect, light = light, onClicked = onClicked, ?dark = dark)

[<Extension>]
type ImageButtonModifiers =
    /// <summary>Set the color of the image button border color</summary>
    /// <param name="light">The color of the image button border in the light theme.</param>
    /// <param name="dark">The color of the image button border in the dark theme.</param>
    [<Extension>]
    static member inline borderColor(this: WidgetBuilder<'msg, #IImageButton>, light: Color, ?dark: Color) =
        this.AddScalar(ImageButton.BorderColor.WithValue(AppTheme.create light dark))

    /// <summary>Set the width of the image button border</summary>
    /// <param name="width">The width of the image button border.</param>
    [<Extension>]
    static member inline borderWidth(this: WidgetBuilder<'msg, #IImageButton>, value: float) =
        this.AddScalar(ImageButton.BorderWidth.WithValue(value))

    /// <summary>Set the corner radius of the image button</summary>
    /// <param name="radius">The corner radius of the image button.</param>
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IImageButton>, value: float) =
        this.AddScalar(ImageButton.CornerRadius.WithValue(value))

    [<Extension>]
    static member inline isLoading(this: WidgetBuilder<'msg, #IImageButton>, value: bool) =
        this.AddScalar(ImageButton.IsLoading.WithValue(value))

    [<Extension>]
    static member inline isOpaque(this: WidgetBuilder<'msg, #IImageButton>, value: bool) =
        this.AddScalar(ImageButton.IsOpaque.WithValue(value))

    [<Extension>]
    static member inline isPressed(this: WidgetBuilder<'msg, #IImageButton>, value: bool) =
        this.AddScalar(ImageButton.IsPressed.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IImageButton>, value: Thickness) =
        this.AddScalar(ImageButton.Padding.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IImageButton>, value: float) =
        ImageButtonModifiers.padding(this, Thickness(value))

    [<Extension>]
    static member inline padding
        (
            this: WidgetBuilder<'msg, #IImageButton>,
            left: float,
            top: float,
            right: float,
            bottom: float
        ) =
        ImageButtonModifiers.padding(this, Thickness(left, top, right, bottom))

    /// <summary>Event that is fired when image button is pressed.</summary>
    /// <param name="onPressed">Msg to dispatch when image button is pressed</param>
    [<Extension>]
    static member inline onPressed(this: WidgetBuilder<'msg, #IImageButton>, onPressed: 'msg) =
        this.AddScalar(ImageButton.Pressed.WithValue(onPressed))

    /// <summary>Event that is fired when image button is released.</summary>
    /// <param name="onReleased">Msg to dispatch when image button is released.</param>
    [<Extension>]
    static member inline onReleased(this: WidgetBuilder<'msg, #IImageButton>, onReleased: 'msg) =
        this.AddScalar(ImageButton.Released.WithValue(onReleased))

    /// <summary>Link a ViewRef to access the direct ImageButton control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IImageButton>, value: ViewRef<ImageButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
