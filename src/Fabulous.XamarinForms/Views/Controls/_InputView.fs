namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

type IInputView =
    inherit IView

module InputView =
    let TextChanged =
        Attributes.defineEvent<TextChangedEventArgs>
            "InputView_TextChanged"
            (fun target -> (target :?> InputView).TextChanged)