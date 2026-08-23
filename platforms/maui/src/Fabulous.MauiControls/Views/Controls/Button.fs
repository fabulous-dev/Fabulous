namespace Fabulous.Maui

open System
open System.IO
open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IFabButton =
    inherit IFabView

module Button =
    let WidgetKey = Widgets.register<Button>()

    let BorderColor = Attributes.defineBindableColor Button.BorderColorProperty

    let BorderWidth = Attributes.defineBindableFloat Button.BorderWidthProperty

    let CharacterSpacing =
        Attributes.defineBindableFloat Button.CharacterSpacingProperty

    let Clicked =
        Attributes.Mvu.defineEventNoArg "Button_Clicked" (fun target -> (target :?> Button).Clicked)

    let Clicked' =
        Attributes.Component.defineEventNoArg "Button_Clicked" (fun target -> (target :?> Button).Clicked)

    let ContentLayout =
        Attributes.defineBindableWithEquality<Button.ButtonContentLayout> Button.ContentLayoutProperty

    let CornerRadius = Attributes.defineBindableInt Button.CornerRadiusProperty

    let FontAttributes =
        Attributes.defineBindableEnum<FontAttributes> Button.FontAttributesProperty

    let FontAutoScalingEnabled =
        Attributes.defineBindableBool Button.FontAutoScalingEnabledProperty

    let FontFamily =
        Attributes.defineBindableWithEquality<string> Button.FontFamilyProperty

    let FontSize = Attributes.defineBindableFloat Button.FontSizeProperty

    let ImageSource = Attributes.defineBindableImageSource Button.ImageSourceProperty

    let LineBreakMode =
        Attributes.defineBindableWithEquality<LineBreakMode> Button.LineBreakModeProperty

    let Padding =
        Attributes.defineBindableWithEquality<Thickness> Button.PaddingProperty

    let Pressed =
        Attributes.Mvu.defineEventNoArg "Button_Pressed" (fun target -> (target :?> Button).Pressed)

    let Released =
        Attributes.Mvu.defineEventNoArg "Button_Released" (fun target -> (target :?> Button).Released)

    let Text = Attributes.defineBindableWithEquality<string> Button.TextProperty

    let TextColor = Attributes.defineBindableColor Button.TextColorProperty

    let TextTransform =
        Attributes.defineBindableEnum<TextTransform> Button.TextTransformProperty

[<AutoOpen>]
module ButtonBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a Button widget with a text and listen for the Click event</summary>
        /// <param name="text">The button on the tex</param>
        /// <param name="onClicked">Message to dispatch</param>
        static member inline Button<'msg when 'msg: equality>(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, IFabButton>(Button.WidgetKey, Button.Text.WithValue(text), Button.Clicked.WithValue(MsgValue(onClicked)))

        /// <summary>Create a Button widget with a text and listen for the Click event</summary>
        /// <param name="text">The button on the tex</param>
        /// <param name="onClicked">Function to execute</param>
        static member inline Button(text: string, onClicked: unit -> unit) =
            WidgetBuilder<unit, IFabButton>(Button.WidgetKey, Button.Text.WithValue(text), Button.Clicked'.WithValue(onClicked))

[<Extension>]
type ButtonModifiers =
    /// <summary>Set the border color</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The border color</param>
    [<Extension>]
    static member inline borderColor(this: WidgetBuilder<'msg, #IFabButton>, value: Color) =
        this.AddScalar(Button.BorderColor.WithValue(value))

    /// <summary>Set the character spacing</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The character spacing</param>
    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, #IFabButton>, value: float) =
        this.AddScalar(Button.CharacterSpacing.WithValue(value))

    /// <summary>Set the border width</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The border width</param>
    [<Extension>]
    static member inline borderWidth(this: WidgetBuilder<'msg, #IFabButton>, value: float) =
        this.AddScalar(Button.BorderWidth.WithValue(value))

    /// <summary>Set the corner radius</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The corner radius</param>
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IFabButton>, value: int) =
        this.AddScalar(Button.CornerRadius.WithValue(value))

    /// <summary>Set the content layout</summary>
    /// <param name="this">Current widget</param>
    /// <param name="position">The content layout</param>
    /// <param name="spacing">The spacing</param>
    [<Extension>]
    static member inline contentLayout
        (
            this: WidgetBuilder<'msg, #IFabButton>,
            position: Microsoft.Maui.Controls.Button.ButtonContentLayout.ImagePosition,
            spacing: float
        ) =
        this.AddScalar(Button.ContentLayout.WithValue(Button.ButtonContentLayout(position, spacing)))

    /// <summary>Set the font</summary>
    /// <param name="this">Current widget</param>
    /// <param name="size">The font size</param>
    /// <param name="attributes">The font attributes</param>
    /// <param name="fontFamily">The font family</param>
    /// <param name="autoScalingEnabled">The value indicating whether auto-scaling is enabled</param>
    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #IFabButton>,
            ?size: float,
            ?attributes: FontAttributes,
            ?fontFamily: string,
            ?autoScalingEnabled: bool
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(Button.FontSize.WithValue(v))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(Button.FontAttributes.WithValue(v))

        match fontFamily with
        | None -> ()
        | Some v -> res <- res.AddScalar(Button.FontFamily.WithValue(v))

        match autoScalingEnabled with
        | None -> ()
        | Some v -> res <- res.AddScalar(Button.FontAutoScalingEnabled.WithValue(v))

        res

    /// <summary>Set the image source</summary>
    /// <param name="this">Current widget</param>
    /// <param name="source">The image source</param>
    [<Extension>]
    static member inline image(this: WidgetBuilder<'msg, #IFabButton>, source: ImageSource) =
        this.AddScalar(Button.ImageSource.WithValue(ImageSourceValue.Source source))

    /// <summary>Set the line break mode</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The line break mode</param>
    [<Extension>]
    static member inline lineBreakMode(this: WidgetBuilder<'msg, #IFabButton>, value: LineBreakMode) =
        this.AddScalar(Button.LineBreakMode.WithValue(value))

    /// <summary>Listen for the Pressed event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="msg">Message to dispatch</param>
    [<Extension>]
    static member inline onPressed(this: WidgetBuilder<'msg, #IFabButton>, msg: 'msg) =
        this.AddScalar(Button.Pressed.WithValue(MsgValue(msg)))

    /// <summary>Listen for the Released event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="msg">Message to dispatch</param>
    [<Extension>]
    static member inline onReleased(this: WidgetBuilder<'msg, #IFabButton>, msg: 'msg) =
        this.AddScalar(Button.Released.WithValue(MsgValue(msg)))

    /// <summary>Set the padding inside the button</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The padding inside the button</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabButton>, value: Thickness) =
        this.AddScalar(Button.Padding.WithValue(value))

    /// <summary>Set the color of the text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the text</param>
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #IFabButton>, value: Color) =
        this.AddScalar(Button.TextColor.WithValue(value))

    /// <summary>Set the transformation of the text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The transformation of the text</param>
    [<Extension>]
    static member inline textTransform(this: WidgetBuilder<'msg, #IFabButton>, value: TextTransform) =
        this.AddScalar(Button.TextTransform.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Button control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabButton>, value: ViewRef<Button>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type ButtonExtraModifiers =
    /// <summary>Set the image source</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The image source</param>
    [<Extension>]
    static member inline image(this: WidgetBuilder<'msg, #IFabButton>, value: string) =
        this.AddScalar(Button.ImageSource.WithValue(ImageSourceValue.File value))

    /// <summary>Set the image source</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The image source</param>
    [<Extension>]
    static member inline image(this: WidgetBuilder<'msg, #IFabButton>, value: Uri) =
        this.AddScalar(Button.ImageSource.WithValue(ImageSourceValue.Uri value))

    /// <summary>Set the image source</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The image source</param>
    [<Extension>]
    static member inline image(this: WidgetBuilder<'msg, #IFabButton>, value: Stream) =
        this.AddScalar(Button.ImageSource.WithValue(ImageSourceValue.Stream value))

    /// <summary>Set the padding inside the button</summary>
    /// <param name="this">Current widget</param>
    /// <param name="uniformSize">The uniform padding inside the button</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabButton>, uniformSize: float) = this.padding(Thickness(uniformSize))

    /// <summary>Set the padding inside the button</summary>
    /// <param name="this">Current widget</param>
    /// <param name="left">The left component of the padding inside the button</param>
    /// <param name="top">The left component of the padding inside the button</param>
    /// <param name="right">The left component of the padding inside the button</param>
    /// <param name="bottom">The left component of the padding inside the button</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabButton>, left: float, top: float, right: float, bottom: float) =
        this.padding(Thickness(left, top, right, bottom))
