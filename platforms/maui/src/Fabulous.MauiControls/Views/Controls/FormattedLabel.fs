namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections
open Microsoft.Maui.Controls

type IFabFormattedLabel =
    inherit IFabLabel

module FormattedLabel =
    let WidgetKey = Widgets.register<Label>()

    let Spans =
        Attributes.defineListWidgetCollection "FormattedString_Spans" (fun target ->
            let label = target :?> Label

            if label.FormattedText = null then
                label.FormattedText <- FormattedString()

            label.FormattedText.Spans)

[<AutoOpen>]
module FormattedLabelBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a FormattedLabel widget</summary>
        static member inline FormattedLabel<'msg when 'msg: equality>() =
            CollectionBuilder<'msg, IFabFormattedLabel, IFabSpan>(FormattedLabel.WidgetKey, FormattedLabel.Spans)

[<Extension>]
type FormattedLabelModifiers =
    /// <summary>Link a ViewRef to access the direct FormattedLabel control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabFormattedLabel>, value: ViewRef<Label>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type FormattedLabelYieldExtensions =
    [<Extension>]
    static member inline Yield(_: CollectionBuilder<'msg, #IFabFormattedLabel, IFabSpan>, x: WidgetBuilder<'msg, #IFabSpan>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield(_: CollectionBuilder<'msg, #IFabFormattedLabel, IFabSpan>, x: WidgetBuilder<'msg, Memo.Memoized<#IFabSpan>>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
