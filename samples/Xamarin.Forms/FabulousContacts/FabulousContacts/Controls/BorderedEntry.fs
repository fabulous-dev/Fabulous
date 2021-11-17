namespace FabulousContacts.Controls

open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.Attributes
open Fabulous.XamarinForms.Widgets
open Fabulous.XamarinForms.XFAttributes
open Xamarin.Forms
open System.Runtime.CompilerServices

type BorderedEntry() =
    inherit Entry()

    static member BorderColorProperty =
        BindableProperty.Create("BorderColor", typeof<Color>, typeof<BorderedEntry>, Color.Default)

    member this.BorderColor
        with get () =
            this.GetValue(BorderedEntry.BorderColorProperty) :?> Color
        and set (value: Color) =
            this.SetValue(BorderedEntry.BorderColorProperty, value)

[<AutoOpen>]
module FabulousBorderedEntry =
    let BorderColor = Attributes.defineBindable<Color> BorderedEntry.BorderColorProperty
    let BorderedEntryKey = Widgets.register<BorderedEntry>()

    type [<Struct>] BorderedEntry<'msg> =
        val public ScalarAttributes: ScalarAttribute[]
        val public WidgetAttributes: WidgetAttribute[]
        val public WidgetCollectionAttributes: WidgetCollectionAttribute[]
    
        new (scalars: ScalarAttribute[], widgets: WidgetAttribute[], widgetColls: WidgetCollectionAttribute[]) =
            { ScalarAttributes = scalars
              WidgetAttributes = widgets
              WidgetCollectionAttributes = widgetColls }        

        static member Create(text: string, onTextChanged: string -> 'msg) =
            BorderedEntry<'msg>(
                [| Entry.Text.WithValue(text)
                   Entry.TextChanged.WithValue(fun args -> onTextChanged args.NewTextValue |> box) |],
                [||],
                [||]
            )

        interface IEntryWidgetBuilder<'msg> with
            member x.Compile() =
                { Key = BorderedEntryKey
                  ScalarAttributes = x.ScalarAttributes
                  WidgetAttributes = x.WidgetAttributes
                  WidgetCollectionAttributes = x.WidgetCollectionAttributes }

    type Fabulous.XamarinForms.View with
        static member inline BorderedEntry<'msg>(text, onTextChanged) = BorderedEntry<'msg>.Create(text, onTextChanged)


    [<Extension>]
    type BorderedEntryExtensions =
        [<Extension>]
        static member inline borderColor(this: BorderedEntry<_>, value: Color) =
            this.AddScalarAttribute(BorderColor.WithValue(value))
