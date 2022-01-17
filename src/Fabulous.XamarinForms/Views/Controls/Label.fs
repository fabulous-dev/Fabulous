namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type ILabel =
    inherit IView
    
module Label =
    let WidgetKey = Widgets.register<Label>()

    let Text =
        Attributes.defineBindable<string> Label.TextProperty

    let HorizontalTextAlignment =
        Attributes.defineBindable<TextAlignment> Label.HorizontalTextAlignmentProperty

    let VerticalTextAlignment =
        Attributes.defineBindable<TextAlignment> Label.VerticalTextAlignmentProperty

    let FontSize =
        Attributes.defineBindable<double> Label.FontSizeProperty

    let Padding =
        Attributes.defineBindable<Thickness> Label.PaddingProperty

    let TextColor =
        Attributes.defineBindable<Color> Label.TextColorProperty

    let FontAttributes =
        Attributes.defineBindable<Xamarin.Forms.FontAttributes> Label.FontAttributesProperty

    let LineBreakMode =
        Attributes.defineBindable<Xamarin.Forms.LineBreakMode> Label.LineBreakModeProperty
        
[<AutoOpen>]
module LabelBuilders =
    type Fabulous.XamarinForms.View with
        static member inline Label<'msg>(text: string) =
            WidgetBuilder<'msg, ILabel>(Label.WidgetKey, Label.Text.WithValue(text))
        
[<Extension>]
type LabelModifiers =
    [<Extension>]
    static member inline horizontalTextAlignment
        (
            this: WidgetBuilder<'msg, #ILabel>,
            value: TextAlignment
        ) =
        this.AddScalar(Label.HorizontalTextAlignment.WithValue(value))

    [<Extension>]
    static member inline verticalTextAlignment(this: WidgetBuilder<'msg, #ILabel>, value: TextAlignment) =
        this.AddScalar(Label.VerticalTextAlignment.WithValue(value))

    [<Extension>]
    static member inline font(this: WidgetBuilder<'msg, #ILabel>, value: double) =
        this.AddScalar(Label.FontSize.WithValue(value))

    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #ILabel>, value: Color) =
        this.AddScalar(Label.TextColor.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #ILabel>, value: Thickness) =
        this.AddScalar(Label.Padding.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #ILabel>, left: float, top: float, right: float, bottom: float) =
        this.AddScalar(Label.Padding.WithValue(Thickness(left, top, right, bottom)))

    [<Extension>]
    static member inline lineBreakMode(this: WidgetBuilder<'msg, #ILabel>, value: LineBreakMode) =
        this.AddScalar(Label.LineBreakMode.WithValue(value))
        
    [<Extension>]
    static member inline centerTextHorizontal(this: WidgetBuilder<'msg, #ILabel>) =
        this.AddScalar(Label.HorizontalTextAlignment.WithValue(TextAlignment.Center))

    [<Extension>]
    static member inline style(this: WidgetBuilder<'msg, #IView>, style: Style) =
        this.AddScalar(NavigableElement.Style.WithValue(style))

    [<Extension>]
    static member inline centerTextVertical(this: WidgetBuilder<'msg, #ILabel>) =
        this.AddScalar(Label.VerticalTextAlignment.WithValue(TextAlignment.Center))

    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #ILabel>,
            ?size: double,
            ?namedSize: NamedSize,
            ?attributes: FontAttributes
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(Label.FontSize.WithValue(v))

        match namedSize with
        | None -> ()
        | Some v -> res <- res.AddScalar(Label.FontSize.WithValue(Device.GetNamedSize(v, typeof<Label>)))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(Label.FontAttributes.WithValue(v))

        res
