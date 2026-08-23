namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous

module MvuSpinner =
    let Spin =
        Attributes.Mvu.defineEvent<SpinEventArgs> "Spinner_Spin" (fun target -> (target :?> Spinner).Spin)
