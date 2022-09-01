namespace Fabulous.Maui

open System
open System.IO
open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type IButton =
    inherit IView

module Button =
    let WidgetKey = Widgets.register<Button>()

    let BorderColor =
        Attributes.defineBindableAppThemeColor Button.BorderColorProperty

    let BorderWidth =
        Attributes.defineBindableFloat Button.BorderWidthProperty

    let CharacterSpacing =
        Attributes.defineBindableFloat Button.CharacterSpacingProperty

    let ContentLayout =
        Attributes.defineBindableWithEquality<Button.ButtonContentLayout> Button.ContentLayoutProperty

    let CornerRadius =
        Attributes.defineBindableInt Button.CornerRadiusProperty

    let FontAttributes =
        Attributes.defineBindableEnum<FontAttributes> Button.FontAttributesProperty

    let FontFamily =
        Attributes.defineBindableWithEquality<string> Button.FontFamilyProperty

    let FontSize =
        Attributes.defineBindableFloat Button.FontSizeProperty

    let ImageSource =
        Attributes.defineBindableAppTheme<ImageSource> Button.ImageSourceProperty

    let Padding =
        Attributes.defineBindableWithEquality<Thickness> Button.PaddingProperty

    let TextColor =
        Attributes.defineBindableAppThemeColor Button.TextColorProperty

    let Text =
        Attributes.defineBindableWithEquality<string> Button.TextProperty

    let TextTransform =
        Attributes.defineBindableEnum<TextTransform> Button.TextTransformProperty

    let Clicked =
        Attributes.defineEventNoArg "Button_Clicked" (fun target -> (target :?> Button).Clicked)

    let Pressed =
        Attributes.defineEventNoArg "Button_Pressed" (fun target -> (target :?> Button).Pressed)

    let Released =
        Attributes.defineEventNoArg "Button_Released" (fun target -> (target :?> Button).Released)

[<AutoOpen>]
module ButtonBuilders =
    type Fabulous.Maui.View with
        static member inline Button<'msg>(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, IButton>(
                Button.WidgetKey,
                Button.Text.WithValue(text),
                Button.Clicked.WithValue(onClicked)
            )

[<Extension>]
type ButtonModifiers =
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #IButton>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(Button.TextColor.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline textTransform(this: WidgetBuilder<'msg, #IButton>, value: TextTransform) =
        this.AddScalar(Button.TextTransform.WithValue(value))

    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IButton>, value: int) =
        this.AddScalar(Button.CornerRadius.WithValue(value))

    [<Extension>]
    static member inline borderColor(this: WidgetBuilder<'msg, #IButton>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(Button.BorderColor.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline borderWidth(this: WidgetBuilder<'msg, #IButton>, value: float) =
        this.AddScalar(Button.BorderWidth.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IButton>, value: Thickness) =
        this.AddScalar(Button.Padding.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IButton>, value: float) =
        ButtonModifiers.padding(this, Thickness(value))

    [<Extension>]
    static member inline padding
        (
            this: WidgetBuilder<'msg, #IButton>,
            left: float,
            top: float,
            right: float,
            bottom: float
        ) =
        ButtonModifiers.padding(this, Thickness(left, top, right, bottom))

    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, #IButton>, value: float) =
        this.AddScalar(Button.CharacterSpacing.WithValue(value))

    [<Extension>]
    static member inline contentLayout
        (
            this: WidgetBuilder<'msg, #IButton>,
            position: Microsoft.Maui.Controls.Button.ButtonContentLayout.ImagePosition,
            spacing: float
        ) =
        this.AddScalar(Button.ContentLayout.WithValue(Button.ButtonContentLayout(position, spacing)))

    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #IButton>,
            ?size: float,
            ?namedSize: NamedSize,
            ?attributes: FontAttributes,
            ?fontFamily: string
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(Button.FontSize.WithValue(v))

        match namedSize with
        | None -> ()
        | Some v -> res <- res.AddScalar(Button.FontSize.WithValue(Device.GetNamedSize(v, typeof<Button>)))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(Button.FontAttributes.WithValue(v))

        match fontFamily with
        | None -> ()
        | Some v -> res <- res.AddScalar(Button.FontFamily.WithValue(v))

        res

    [<Extension>]
    static member inline image(this: WidgetBuilder<'msg, #IButton>, light: ImageSource, ?dark: ImageSource) =
        this.AddScalar(Button.ImageSource.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline image(this: WidgetBuilder<'msg, #IButton>, light: string, ?dark: string) =
        let light = ImageSource.FromFile(light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromFile(v))

        ButtonModifiers.image(this, light, ?dark = dark)

    [<Extension>]
    static member inline image(this: WidgetBuilder<'msg, #IButton>, light: Uri, ?dark: Uri) =
        let light = ImageSource.FromUri(light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromUri(v))

        ButtonModifiers.image(this, light, ?dark = dark)

    [<Extension>]
    static member inline image(this: WidgetBuilder<'msg, #IButton>, light: Stream, ?dark: Stream) =
        let light = ImageSource.FromStream(fun () -> light)

        let dark =
            match dark with
            | None -> None
            | Some v -> Some(ImageSource.FromStream(fun () -> v))

        ButtonModifiers.image(this, light, ?dark = dark)

    [<Extension>]
    static member inline onPressed(this: WidgetBuilder<'msg, #IButton>, onPressed: 'msg) =
        this.AddScalar(Button.Pressed.WithValue(onPressed))

    [<Extension>]
    static member inline onReleased(this: WidgetBuilder<'msg, #IButton>, onReleased: 'msg) =
        this.AddScalar(Button.Released.WithValue(onReleased))

    /// <summary>Link a ViewRef to access the direct Button control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IButton>, value: ViewRef<Button>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
