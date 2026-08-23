namespace Fabulous.Avalonia

open System
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

module ComponentToggleButton =

    let CheckedChanged =
        Attributes.Component.defineAvaloniaPropertyWithChangedEvent "ToggleButton_IsCheckedChanged" ToggleButton.IsCheckedProperty Nullable Nullable.op_Explicit

    let ThreeStateCheckedChanged =
        Attributes.Component.defineAvaloniaPropertyWithChangedEvent' "ToggleButton_CheckedChanged" ToggleButton.IsCheckedProperty

[<AutoOpen>]
module ComponentToggleButtonBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ToggleButton widget.</summary>
        /// <param name="text">The text of the ToggleButton.</param>
        /// <param name="isChecked">Whether the ToggleButton is checked.</param>
        /// <param name="fn">Raised when the ToggleButton is clicked.</param>
        static member ToggleButton(text: string, isChecked: bool, fn: bool -> unit) =
            WidgetBuilder<'msg, IFabToggleButton>(
                ToggleButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ComponentToggleButton.CheckedChanged.WithValue(ComponentValueEventData.create isChecked fn)
            )

        /// <summary>Creates a ThreeStateToggleButton widget.</summary>
        /// <param name="text">The text of the ThreeStateToggleButton.</param>
        /// <param name="isChecked">Whether the ThreeStateToggleButton is checked.</param>
        /// <param name="fn">Raised when the ThreeStateToggleButton is clicked.</param>
        static member ThreeStateToggleButton(text: string, isChecked: bool option, fn: bool option -> unit) =
            WidgetBuilder<'msg, IFabToggleButton>(
                ToggleButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ToggleButton.IsThreeState.WithValue(true),
                ComponentToggleButton.ThreeStateCheckedChanged.WithValue(
                    ComponentValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn)
                )
            )

        /// <summary>Creates a ToggleButton widget.</summary>
        /// <param name="isChecked">Whether the ToggleButton is checked.</param>
        /// <param name="fn">Raised when the ToggleButton is clicked.</param>
        /// <param name="content">The content of the ToggleButton.</param>
        static member ToggleButton(isChecked: bool, fn: bool -> unit, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabToggleButton>(
                ToggleButton.WidgetKey,
                AttributesBundle(
                    StackList.one(ComponentToggleButton.CheckedChanged.WithValue(ComponentValueEventData.create isChecked fn)),
                    [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    [||],
                    [||]
                )
            )

        /// <summary>Creates a ThreeStateToggleButton widget.</summary>
        /// <param name="isChecked">Whether the ThreeStateToggleButton is checked.</param>
        /// <param name="fn">Raised when the ThreeStateToggleButton is clicked.</param>
        /// <param name="content">The content of the ThreeStateToggleButton.</param>
        static member ThreeStateToggleButton(isChecked: bool option, fn: bool option -> unit, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabToggleButton>(
                ToggleButton.WidgetKey,
                AttributesBundle(
                    StackList.two(
                        ComponentToggleButton.ThreeStateCheckedChanged.WithValue(
                            ComponentValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn)
                        ),
                        ToggleButton.IsThreeState.WithValue(true)
                    ),
                    [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    [||],
                    [||]
                )
            )
