namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous

module ComponentSpinner =
    let Spin =
        Attributes.Component.defineEvent<SpinEventArgs> "Spinner_Spin" (fun target -> (target :?> Spinner).Spin)
