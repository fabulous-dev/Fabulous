namespace FabulousContacts.Controls

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open System.Runtime.CompilerServices

type BorderedEntry() =
    inherit Entry()

    static member BorderColorProperty =
        BindableProperty.Create("BorderColor", typeof<Color>, typeof<BorderedEntry>, Color.Default)

    member this.BorderColor
        with get () = this.GetValue(BorderedEntry.BorderColorProperty) :?> Color
        and set (value: Color) = this.SetValue(BorderedEntry.BorderColorProperty, value)

type IBorderedEntry =
    inherit IEntry

module BorderedEntry =
    let WidgetKey = Widgets.register<BorderedEntry>()

    let BorderColor =
        Attributes.defineBindableColor BorderedEntry.BorderColorProperty

[<AutoOpen>]
module EntryBuilders =
    type Fabulous.XamarinForms.View with
        static member inline BorderedEntry<'msg>(text, onTextChanged: string -> 'msg) =
            WidgetBuilder<'msg, IBorderedEntry>(
                BorderedEntry.WidgetKey,
                InputView.TextWithEvent.WithValue(
                    ValueEventData.create text (fun args -> onTextChanged args.NewTextValue |> box)
                )
            )

[<AutoOpen>]
module BorderedEntryModifiers =
    [<Extension>]
    type BorderedEntryExtensions =
        [<Extension>]
        static member inline borderColor(this: WidgetBuilder<'msg, #IBorderedEntry>, value: Color) =
            this.AddScalar(BorderedEntry.BorderColor.WithValue(value))
