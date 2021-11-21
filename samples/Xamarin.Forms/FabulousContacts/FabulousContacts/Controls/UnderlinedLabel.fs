namespace FabulousContacts.Controls

open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.Widgets
open Fabulous.XamarinForms.XFAttributes
open Xamarin.Forms

type UnderlinedLabel() =
    inherit Label()

[<AutoOpen>]
module FabulousUnderlinedLabel =
    type [<Struct>] UnderlinedLabel<'msg> (attrs: Attributes.AttributesBuilder) =
        static let key = Widgets.register<UnderlinedLabel>()
        member _.Builder = attrs

        static member inline Create(text: string) =
            UnderlinedLabel<'msg>(
                Attributes.AttributesBuilder(
                    [| Label.Text.WithValue(text) |],
                    [||],
                    [||]
                )
            )

        interface ILabelWidgetBuilder<'msg> with
            member x.Compile() = attrs.Build(key)

    type Fabulous.XamarinForms.View with
        static member inline UnderlinedLabel<'msg>(text) = UnderlinedLabel<'msg>.Create(text)