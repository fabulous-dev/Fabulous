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
    let UnderlineLabelKey = Widgets.register<UnderlinedLabel>()

    type [<Struct>] UnderlinedLabel<'msg> =
        val public ScalarAttributes: ScalarAttribute[]
        val public WidgetAttributes: WidgetAttribute[]
        val public WidgetCollectionAttributes: WidgetCollectionAttribute[]
    
        new (scalars: ScalarAttribute[], widgets: WidgetAttribute[], widgetColls: WidgetCollectionAttribute[]) =
            { ScalarAttributes = scalars
              WidgetAttributes = widgets
              WidgetCollectionAttributes = widgetColls }        

        static member inline Create(text: string) =
            UnderlinedLabel<'msg>(
                [| Label.Text.WithValue(text) |],
                [||],
                [||]
            )

        interface ILabelWidgetBuilder<'msg> with
            member x.Compile() =
                { Key = UnderlineLabelKey
                  ScalarAttributes = x.ScalarAttributes
                  WidgetAttributes = x.WidgetAttributes
                  WidgetCollectionAttributes = x.WidgetCollectionAttributes }

    type Fabulous.XamarinForms.View with
        static member inline UnderlinedLabel<'msg>(text) = UnderlinedLabel<'msg>.Create(text)