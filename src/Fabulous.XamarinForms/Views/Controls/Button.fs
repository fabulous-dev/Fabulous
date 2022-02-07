namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

[<Struct>]
type ImagePosition =
    | Left
    | Top
    | Right
    | Bottom

[<Struct>]
type ContentLayout =
    | ContentLayout of position: ImagePosition * spacing: float
    member this.Position =
        this
        |> fun (ContentLayout (position, _)) -> position

    member this.Spacing =
        this
        |> fun (ContentLayout (_, spacing)) -> spacing

type IButton =
    inherit IView

module Button =
    let WidgetKey = Widgets.register<Button> ()

    let BorderColor =
        Attributes.defineAppThemeBindable<Color> Button.BorderColorProperty

    let BorderWidth =
        Attributes.defineBindable<float> Button.BorderWidthProperty

    let CharacterSpacing =
        Attributes.defineBindable<float> Button.CharacterSpacingProperty

    let ContentLayout =
        Attributes.defineBindable<Xamarin.Forms.Button.ButtonContentLayout> Button.ContentLayoutProperty

    let CornerRadius =
        Attributes.defineBindable<int> Button.CornerRadiusProperty

    let FontAttributes =
        Attributes.defineBindable<Xamarin.Forms.FontAttributes> Button.FontAttributesProperty

    let FontFamily =
        Attributes.defineBindable<string> Button.FontFamilyProperty

    let FontSize =
        Attributes.defineBindable<float> Button.FontSizeProperty

    let ImageSource =
        Attributes.defineBindable<Xamarin.Forms.ImageSource> Button.ImageSourceProperty

    let ImageSource' =
        Attributes.defineAppThemeBindable<string> Button.ImageSourceProperty

    let Padding =
        Attributes.defineBindable<Thickness> Button.PaddingProperty

    let TextColor =
        Attributes.defineAppThemeBindable<Color> Button.TextColorProperty

    let Text =
        Attributes.defineBindable<string> Button.TextProperty

    let TextTransform =
        Attributes.defineBindable<TextTransform> Button.TextTransformProperty

    let Clicked =
        Attributes.defineEventNoArg "Button_Clicked" (fun target -> (target :?> Button).Clicked)

    let Pressed =
        Attributes.defineEventNoArg "Button_Pressed" (fun target -> (target :?> Button).Pressed)

    let Released =
        Attributes.defineEventNoArg "Button_Released" (fun target -> (target :?> Button).Released)

[<AutoOpen>]
module ButtonBuilders =
    type Fabulous.XamarinForms.View with
        static member inline Button<'msg>(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, IButton>(
                Button.WidgetKey,
                Button.Text.WithValue(text),
                Button.Clicked.WithValue(onClicked)
            )

[<Extension>]
type ButtonModifiers =
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #IButton>, light: Color, ?dark: Color) =
        this.AddScalar(
            Button.TextColor.WithValue(
                { Light = light
                  Dark =
                      match dark with
                      | None -> ValueNone
                      | Some v -> ValueSome v }
            )
        )

    [<Extension>]
    static member inline textTransform(this: WidgetBuilder<'msg, #IButton>, value: TextTransform) =
        this.AddScalar(Button.TextTransform.WithValue(value))

    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IButton>, value: int) =
        this.AddScalar(Button.CornerRadius.WithValue(value))

    [<Extension>]
    static member inline borderColor(this: WidgetBuilder<'msg, #IButton>, light: Color, ?dark: Color) =
        this.AddScalar(
            Button.BorderColor.WithValue(
                { Light = light
                  Dark =
                      match dark with
                      | None -> ValueNone
                      | Some v -> ValueSome v }
            )
        )

    [<Extension>]
    static member inline borderWidth(this: WidgetBuilder<'msg, #IButton>, value: float) =
        this.AddScalar(Button.BorderWidth.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IButton>, value: Thickness) =
        this.AddScalar(Button.Padding.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IButton>, value: float) =
        ButtonModifiers.padding (this, Thickness(value))

    [<Extension>]
    static member inline padding
        (
            this: WidgetBuilder<'msg, #IButton>,
            left: float,
            top: float,
            right: float,
            bottom: float
        ) =
        ButtonModifiers.padding (this, Thickness(left, top, right, bottom))

    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, #IButton>, value: float) =
        this.AddScalar(Button.CharacterSpacing.WithValue(value))

    [<Extension>]
    static member inline contentLayout(this: WidgetBuilder<'msg, #IButton>, value: ContentLayout) =
        let imagePos =
            match value.Position with
            | ImagePosition.Left -> Xamarin.Forms.Button.ButtonContentLayout.ImagePosition.Left
            | ImagePosition.Right -> Xamarin.Forms.Button.ButtonContentLayout.ImagePosition.Right
            | ImagePosition.Top -> Xamarin.Forms.Button.ButtonContentLayout.ImagePosition.Top
            | ImagePosition.Bottom -> Xamarin.Forms.Button.ButtonContentLayout.ImagePosition.Bottom

        this.AddScalar(Button.ContentLayout.WithValue(Button.ButtonContentLayout(imagePos, value.Spacing)))

    [<Extension>]
    static member inline font(this: WidgetBuilder<'msg, #IButton>, value: float) =
        this.AddScalar(Button.FontSize.WithValue(value))

    [<Extension>]
    static member inline font(this: WidgetBuilder<'msg, #IButton>, value: NamedSize) =
        this.AddScalar(Button.FontSize.WithValue(Device.GetNamedSize(value, typeof<Button>)))

    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #IButton>,
            ?size: float,
            ?namedSize: NamedSize,
            ?attributes: FontAttributes
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

        res

    [<Extension>]
    static member inline fontFamily(this: WidgetBuilder<'msg, #IButton>, value: string) =
        this.AddScalar(Button.FontFamily.WithValue(value))

    [<Extension>]
    static member inline imageSource(this: WidgetBuilder<'msg, #IButton>, value: ImageSource) =
        this.AddScalar(Button.ImageSource.WithValue(value))

    [<Extension>]
    static member inline imageSource(this: WidgetBuilder<'msg, #IButton>, light, ?dark) =
        this.AddScalar(
            Button.ImageSource'.WithValue(
                { Light = light
                  Dark =
                      match dark with
                      | None -> ValueNone
                      | Some v -> ValueSome v }
            )
        )

    [<Extension>]
    static member inline pressed(this: WidgetBuilder<'msg, #IButton>, msg: 'msg) =
        this.AddScalar(Button.Pressed.WithValue(msg))

    [<Extension>]
    static member inline released(this: WidgetBuilder<'msg, #IButton>, msg: 'msg) =
        this.AddScalar(Button.Released.WithValue(msg))
