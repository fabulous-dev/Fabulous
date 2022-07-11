namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IFormattedLabel =
    inherit ILabel

module FormattedLabel =
    let WidgetKey = Widgets.register<Label>()

    let Spans =
        Attributes.defineListWidgetCollection
            "FormattedString_Spans"
            (fun target ->
                let label = target :?> Label

                if label.FormattedText = null then
                    label.FormattedText <- FormattedString()

                label.FormattedText.Spans)

[<AutoOpen>]
module FormattedLabelBuilders =
    type Fabulous.XamarinForms.View with
        static member inline FormattedLabel<'msg>() =
            CollectionBuilder<'msg, IFormattedLabel, ISpan>(FormattedLabel.WidgetKey, FormattedLabel.Spans)

[<Extension>]
type FormattedLabelModifiers =
    /// <summary>Link a ViewRef to access the direct Label control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFormattedLabel>, value: ViewRef<Label>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
