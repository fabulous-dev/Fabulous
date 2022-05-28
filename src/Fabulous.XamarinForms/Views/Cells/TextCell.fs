namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type ITextCell =
    inherit ICell

module TextCell =
    let WidgetKey = Widgets.register<TextCell>()

    let Text =
        Attributes.defineBindableWithEquality<string> TextCell.TextProperty

    let TextColor =
        Attributes.defineBindableAppThemeColor TextCell.TextColorProperty

    let Detail =
        Attributes.defineBindableWithEquality<string> TextCell.DetailProperty

    let DetailColor =
        Attributes.defineBindableAppThemeColor TextCell.DetailColorProperty

[<AutoOpen>]
module TextCellBuilders =
    type Fabulous.XamarinForms.View with
        static member inline TextCell<'msg>(text: string) =
            WidgetBuilder<'msg, ITextCell>(TextCell.WidgetKey, TextCell.Text.WithValue(text))

[<Extension>]
type TextCellModifiers =
    /// <summary>Set the color of the text.</summary>
    /// <param name="light">The color of the text in the light theme.</param>
    /// <param name="dark">The color of the text in the dark theme.</param>
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #ITextCell>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(TextCell.TextColor.WithValue(ColorPair.create light dark))

    /// <summary>Set the color of the detail text.</summary>
    /// <param name="light">The color of the text in the light theme.</param>
    /// <param name="dark">The color of the text in the dark theme.</param>
    [<Extension>]
    static member inline detailColor(this: WidgetBuilder<'msg, #ITextCell>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(TextCell.DetailColor.WithValue(ColorPair.create light dark))

    /// <summary>Set the text of the detail text cell.</summary>
    /// <param name="text">The text of the detail text cell.</param>
    [<Extension>]
    static member inline detailText(this: WidgetBuilder<'msg, #ITextCell>, text: string) =
        this.AddScalar(TextCell.Detail.WithValue(text))

    /// <summary>Link a ViewRef to access the direct TextCell control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ITextCell>, value: ViewRef<TextCell>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
