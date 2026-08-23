namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module MvuMaskedTextBox =
    let TextChanged =
        Attributes.Mvu.defineAvaloniaPropertyWithChangedEvent' "MaskedTextBox_TextChanged" MaskedTextBox.TextProperty

[<AutoOpen>]
module MvuMaskedTextBoxBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a MaskedTextBox widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="mask">The mask to apply.</param>
        /// <param name="fn">Raised when the text changes.</param>
        static member inline MaskedTextBox(text: string, mask: string, fn: string -> 'msg) =
            WidgetBuilder<'msg, IFabMaskedTextBox>(
                MaskedTextBox.WidgetKey,
                MaskedTextBox.Mask.WithValue(mask),
                MvuMaskedTextBox.TextChanged.WithValue(ValueEventData.create text fn)
            )
