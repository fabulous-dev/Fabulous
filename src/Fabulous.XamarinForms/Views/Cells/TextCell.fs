namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type ITextCell =
    inherit ICell

module TextCell =
    let WidgetKey = Widgets.register<TextCell> ()

    let Text =
        Attributes.defineBindable<string> TextCell.TextProperty

    let TextColor =
        Attributes.defineBindable<Color> TextCell.TextColorProperty

[<AutoOpen>]
module TextCellBuilders =
    type Fabulous.XamarinForms.View with
        static member inline TextCell<'msg>(text: string) =
            WidgetBuilder<'msg, ITextCell>(TextCell.WidgetKey, TextCell.Text.WithValue(text))

[<Extension>]
type TextCellModifiers =
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, ITextCell>, value: Color) =
        this.AddScalar(TextCell.TextColor.WithValue(value))
