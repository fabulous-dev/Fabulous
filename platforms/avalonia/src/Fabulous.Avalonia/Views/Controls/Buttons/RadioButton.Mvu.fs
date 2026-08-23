namespace Fabulous.Avalonia

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

[<AutoOpen>]
module MvuRadioButtonBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a RadioButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="isChecked">Whether the RadioButton is checked.</param>
        /// <param name="fn">Raised when the RadioButton is clicked.</param>
        static member RadioButton(text: string, isChecked: bool, fn: bool -> 'msg) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                MvuToggleButton.CheckedChanged.WithValue(ValueEventData.create isChecked fn)
            )

        /// <summary>Creates a ThreeStateRadioButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="isChecked">Whether the ThreeStateRadioButton is checked.</param>
        /// <param name="fn">Raised when the ThreeStateRadioButton is clicked.</param>
        static member ThreeStateRadioButton(text: string, isChecked: bool option, fn: bool option -> 'msg) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                ToggleButton.IsThreeState.WithValue(true),
                ContentControl.ContentString.WithValue(text),
                MvuToggleButton.ThreeStateCheckedChanged.WithValue(ValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn))
            )

        /// <summary>Creates a RadioButton widget.</summary>
        /// <param name="isChecked">Whether the RadioButton is checked.</param>
        /// <param name="fn">Raised when the RadioButton is clicked.</param>
        /// <param name="content">The content of the RadioButton.</param>
        static member RadioButton(isChecked: bool, fn: bool -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                AttributesBundle(
                    StackList.one(MvuToggleButton.CheckedChanged.WithValue(ValueEventData.create isChecked fn)),
                    [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    [||],
                    [||]
                )
            )

        /// <summary>Creates a ThreeStateRadioButton widget.</summary>
        /// <param name="isChecked">Whether the ThreeStateRadioButton is checked.</param>
        /// <param name="fn">Raised when the ThreeStateRadioButton is clicked.</param>
        /// <param name="content">The content of the ThreeStateRadioButton.</param>
        static member ThreeStateRadioButton(isChecked: bool option, fn: bool option -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                AttributesBundle(
                    StackList.two(
                        MvuToggleButton.ThreeStateCheckedChanged.WithValue(
                            ValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn)
                        ),
                        ToggleButton.IsThreeState.WithValue(true)
                    ),
                    [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    [||],
                    [||]
                )
            )
