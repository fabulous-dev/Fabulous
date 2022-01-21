namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

type IEditor =
    inherit IInputView

module Editor =
    let WidgetKey = Widgets.register<Editor> ()

    let Text =
        Attributes.defineBindable<string> Editor.TextProperty

[<AutoOpen>]
module EditorBuilders =
    type Fabulous.XamarinForms.View with
        static member inline Editor<'msg>(text: string, onTextChanged: string -> 'msg) =
            WidgetBuilder<'msg, IEditor>(
                Editor.WidgetKey,
                Editor.Text.WithValue(text),
                InputView.TextChanged.WithValue(fun args -> onTextChanged args.NewTextValue |> box)
            )
