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
    type [<Struct>] UnderlinedLabel<'msg> (scalarAttributes: ScalarAttribute[], widgetAttributes: WidgetAttribute[], widgetCollectionAttributes: WidgetCollectionAttribute[]) =
        static let key = Widgets.register<UnderlinedLabel>()

        static member Create(text: string) =
            UnderlinedLabel<'msg>(
                [| Label.Text.WithValue(text) |],
                [||],
                [||]
            )

        interface ILabelWidgetBuilder<'msg> with
            member _.ScalarAttributes = scalarAttributes
            member _.WidgetAttributes = widgetAttributes
            member _.WidgetCollectionAttributes = widgetCollectionAttributes
            member _.Compile() =
                { Key = key
                  ScalarAttributes = scalarAttributes
                  WidgetAttributes = widgetAttributes
                  WidgetCollectionAttributes = widgetCollectionAttributes }

    type Fabulous.XamarinForms.View with
        static member inline UnderlinedLabel<'msg>(text) = UnderlinedLabel<'msg>.Create(text)