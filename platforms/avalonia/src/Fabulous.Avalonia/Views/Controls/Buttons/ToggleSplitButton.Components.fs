namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

module ComponentToggleSplitButton =
    let CheckedChanged =
        Attributes.Component.defineAvaloniaPropertyWithChangedEvent' "ToggleSplitButton_CheckedChanged" ToggleSplitButton.IsCheckedProperty

[<AutoOpen>]
module ComponentToggleSplitButtonBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ToggleSplitButton widget.</summary>
        /// <param name="text">The text of the ToggleSplitButton.</param>
        /// <param name="isChecked">Whether the ToggleSplitButton is checked.</param>
        /// <param name="fn">Raised when the ToggleSplitButton is checked or unchecked.</param>
        static member ToggleSplitButton(text: string, isChecked: bool, fn: bool -> unit) =
            WidgetBuilder<'msg, IFabToggleSplitButton>(
                ToggleSplitButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ComponentToggleSplitButton.CheckedChanged.WithValue(ComponentValueEventData.create isChecked fn)
            )

        /// <summary>Creates a ToggleSplitButton widget.</summary>
        /// <param name="isChecked">Whether the ToggleSplitButton is checked.</param>
        /// <param name="fn">Raised when the ToggleSplitButton is checked or unchecked.</param>
        /// <param name="content">The content of the ToggleSplitButton.</param>
        static member ToggleSplitButton(isChecked: bool, fn: bool -> unit, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabToggleSplitButton>(
                ToggleSplitButton.WidgetKey,
                AttributesBundle(
                    StackList.one(ComponentToggleSplitButton.CheckedChanged.WithValue(ComponentValueEventData.create isChecked fn)),
                    [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    [||],
                    [||]
                )
            )
