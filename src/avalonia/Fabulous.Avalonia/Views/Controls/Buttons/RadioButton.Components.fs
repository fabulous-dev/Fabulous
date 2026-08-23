namespace Fabulous.Avalonia

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

[<AutoOpen>]
module RadioButtonBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a RadioButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="isChecked">Whether the RadioButton is checked.</param>
        /// <param name="fn">Raised when the RadioButton is clicked.</param>
        static member RadioButton(text: string, isChecked: bool, fn: bool -> unit) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ComponentToggleButton.CheckedChanged.WithValue(ComponentValueEventData.create isChecked fn)
            )

        /// <summary>Creates a ThreeStateRadioButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="isChecked">Whether the ThreeStateRadioButton is checked.</param>
        /// <param name="fn">Raised when the ThreeStateRadioButton is clicked.</param>
        static member ThreeStateRadioButton(text: string, isChecked: bool option, fn: bool option -> unit) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                ToggleButton.IsThreeState.WithValue(true),
                ContentControl.ContentString.WithValue(text),
                ComponentToggleButton.ThreeStateCheckedChanged.WithValue(
                    ComponentValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn)
                )
            )

        /// <summary>Creates a RadioButton widget.</summary>
        /// <param name="isChecked">Whether the RadioButton is checked.</param>
        /// <param name="fn">Raised when the RadioButton is clicked.</param>
        /// <param name="content">The content of the RadioButton.</param>
        static member RadioButton(isChecked: bool, fn: bool -> unit, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                AttributesBundle(
                    StackList.one(ComponentToggleButton.CheckedChanged.WithValue(ComponentValueEventData.create isChecked fn)),
                    [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    [||],
                    [||]
                )
            )

        /// <summary>Creates a ThreeStateRadioButton widget.</summary>
        /// <param name="isChecked">Whether the ThreeStateRadioButton is checked.</param>
        /// <param name="fn">Raised when the ThreeStateRadioButton is clicked.</param>
        /// <param name="content">The content of the ThreeStateRadioButton.</param>
        static member ThreeStateRadioButton(isChecked: bool option, fn: bool option -> unit, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
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
