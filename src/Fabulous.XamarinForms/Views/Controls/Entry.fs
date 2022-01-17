namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IEntry =
    inherit IInputView

module Entry =
    let WidgetKey = Widgets.register<Entry>()

    let Text =
        Attributes.defineBindable<string> Entry.TextProperty

    let Placeholder =
        Attributes.defineBindable<string> Entry.PlaceholderProperty

    let Keyboard =
        Attributes.defineBindable<Keyboard> Entry.KeyboardProperty
        
[<AutoOpen>]
module EntryBuilders =
    type Fabulous.XamarinForms.View with
        static member inline Entry<'msg>(text: string, onTextChanged: string -> 'msg) =
            WidgetBuilder<'msg, IEntry>(
                Entry.WidgetKey,
                Entry.Text.WithValue(text),
                InputView.TextChanged.WithValue(fun args -> onTextChanged args.NewTextValue |> box)
            )
    
[<Extension>]
type EntryModifiers =
    [<Extension>]
    static member inline placeholder(this: WidgetBuilder<'msg, #IEntry>, value: string) =
        this.AddScalar(Entry.Placeholder.WithValue(value))

    [<Extension>]
    static member inline keyboard(this: WidgetBuilder<'msg, #IEntry>, value: Keyboard) =
        this.AddScalar(Entry.Keyboard.WithValue(value))