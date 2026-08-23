namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module ComponentMaskedTextBox =
    let TextChanged =
        Attributes.Component.defineAvaloniaPropertyWithChangedEvent' "MaskedTextBox_TextChanged" MaskedTextBox.TextProperty

[<AutoOpen>]
module ComponentMaskedTextBoxBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a MaskedTextBox widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="mask">The mask to apply.</param>
        /// <param name="fn">Raised when the text changes.</param>
        static member inline MaskedTextBox(text: string, mask: string, fn: string -> unit) =
            WidgetBuilder<'msg, IFabMaskedTextBox>(
                MaskedTextBox.WidgetKey,
                MaskedTextBox.Mask.WithValue(mask),
                ComponentMaskedTextBox.TextChanged.WithValue(ComponentValueEventData.create text fn)
            )
