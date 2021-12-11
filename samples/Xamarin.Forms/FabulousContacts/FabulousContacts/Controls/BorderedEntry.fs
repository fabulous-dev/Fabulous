namespace FabulousContacts.Controls

open Fabulous
open Fabulous.XamarinForms
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
    
    type IBorderedEntry = inherit IEntry

    type Fabulous.XamarinForms.View with
        static member inline BorderedEntry<'msg>(text, onTextChanged) =
            ViewHelpers.buildScalars<'msg, IBorderedEntry> BorderedEntryKey
                [| Entry.Text.WithValue(text)
                   Entry.TextChanged.WithValue(fun args -> onTextChanged args.NewTextValue |> box) |]

    [<Extension>]
    type BorderedEntryExtensions =
        [<Extension>]
        static member inline borderColor(this: WidgetBuilder<'msg, #IBorderedEntry>, value: Color) =
            this.AddScalar(BorderColor.WithValue(value))
