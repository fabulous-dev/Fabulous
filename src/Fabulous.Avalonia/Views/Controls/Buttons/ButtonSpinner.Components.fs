namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

[<AutoOpen>]
module ComponentsButtonSpinnerBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ButtonSpinner widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the ButtonSpinner is clicked.</param>
        static member ButtonSpinner(text: string, fn: SpinEventArgs -> unit) =
            WidgetBuilder<'msg, IFabButtonSpinner>(ButtonSpinner.WidgetKey, ContentControl.ContentString.WithValue(text), ComponentSpinner.Spin.WithValue(fn))
