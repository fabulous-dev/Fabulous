namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IFabTextCell =
    inherit IFabCell

module TextCell =
    let WidgetKey = Widgets.register<TextCell>()

    let Detail = Attributes.defineBindableWithEquality<string> TextCell.DetailProperty

    let DetailColor = Attributes.defineBindableColor TextCell.DetailColorProperty

    let Text = Attributes.defineBindableWithEquality<string> TextCell.TextProperty

    let TextColor = Attributes.defineBindableColor TextCell.TextColorProperty

[<AutoOpen>]
module TextCellBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a TextCell widget with a text</summary>
        /// <param name="text">The text value</param>
        static member inline TextCell<'msg when 'msg: equality>(text: string) =
            WidgetBuilder<'msg, IFabTextCell>(TextCell.WidgetKey, TextCell.Text.WithValue(text))

[<Extension>]
type TextCellModifiers =
    /// <summary>Set the color of the detail text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the detail text</param>
    [<Extension>]
    static member inline detailColor(this: WidgetBuilder<'msg, #IFabTextCell>, value: Color) =
        this.AddScalar(TextCell.DetailColor.WithValue(value))

    /// <summary>Set the text of the detail text cell</summary>
    /// <param name="this">Current widget</param>
    /// <param name="text">The text of the detail text cell</param>
    [<Extension>]
    static member inline detailText(this: WidgetBuilder<'msg, #IFabTextCell>, text: string) =
        this.AddScalar(TextCell.Detail.WithValue(text))

    /// <summary>Set the text color of the widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The text color value</param>
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #IFabTextCell>, value: Color) =
        this.AddScalar(TextCell.TextColor.WithValue(value))

    /// <summary>Link a ViewRef to access the direct TextCell control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTextCell>, value: ViewRef<TextCell>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
