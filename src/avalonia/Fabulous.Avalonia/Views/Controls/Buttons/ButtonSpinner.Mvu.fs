namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous

[<AutoOpen>]
module MvuButtonSpinnerBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ButtonSpinner widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the ButtonSpinner is clicked.</param>
        static member ButtonSpinner(text: string, fn: SpinEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabButtonSpinner>(ButtonSpinner.WidgetKey, ContentControl.ContentString.WithValue(text), MvuSpinner.Spin.WithValue(fn))
