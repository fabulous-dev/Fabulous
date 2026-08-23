namespace Fabulous.Avalonia

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

[<AutoOpen>]
module MvuCheckBoxBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a CheckBox widget.</summary>
        /// <param name="isChecked">Whether the CheckBox is checked.</param>
        /// <param name="fn">Raised when the CheckBox is clicked.</param>
        static member CheckBox(isChecked: bool, fn: bool -> 'msg) =
            WidgetBuilder<'msg, IFabCheckBox>(CheckBox.WidgetKey, MvuToggleButton.CheckedChanged.WithValue(ValueEventData.create isChecked fn))

        /// <summary>Creates a CheckBox widget.</summary>
        /// <param name="text">The CheckBox text.</param>
        /// <param name="isChecked">Whether the CheckBox is checked.</param>
        /// <param name="fn">Raised when the CheckBox is clicked.</param>
        static member CheckBox(text: string, isChecked: bool, fn: bool -> 'msg) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                MvuToggleButton.CheckedChanged.WithValue(ValueEventData.create isChecked fn)
            )

        /// <summary>Creates a CheckBox widget</summary>
        /// <param name="isChecked">Whether the CheckBox is checked.</param>
        /// <param name="fn">Raised when the CheckBox is clicked.</param>
        /// <param name="content">The CheckBox content.</param>
        static member CheckBox(isChecked: bool, fn: bool -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                AttributesBundle(
                    StackList.one(MvuToggleButton.CheckedChanged.WithValue(ValueEventData.create isChecked fn)),
                    [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    [||],
                    [||]
                )
            )

        /// <summary>Creates a ThreeStateCheckBox widget.</summary>
        /// <param name="isChecked">Whether the ThreeStateCheckBox is checked.</param>
        /// <param name="fn">Raised when the ThreeStateCheckBox is clicked.</param>
        static member inline ThreeStateCheckBox(isChecked: bool option, fn: bool option -> 'msg) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                ToggleButton.IsThreeState.WithValue(true),
                MvuToggleButton.ThreeStateCheckedChanged.WithValue(ValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn))
            )

        /// <summary>Creates a ThreeStateCheckBox widget.</summary>
        /// <param name="text">The ThreeStateCheckBox text.</param>
        /// <param name="isChecked">Whether the ThreeStateCheckBox is checked.</param>
        /// <param name="fn">Raised when the ThreeStateCheckBox is clicked.</param>
        static member inline ThreeStateCheckBox(text: string, isChecked: bool option, fn: bool option -> 'msg) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                ToggleButton.IsThreeState.WithValue(true),
                ContentControl.ContentString.WithValue(text),
                MvuToggleButton.ThreeStateCheckedChanged.WithValue(ValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn))
            )

        /// <summary>Creates a ThreeStateCheckBox widget.</summary>
        /// <param name="isChecked">Whether the ThreeStateCheckBox is checked.</param>
        /// <param name="fn">Raised when the ThreeStateCheckBox is clicked.</param>
        /// <param name="content">The ThreeStateCheckBox content.</param>
        static member inline ThreeStateCheckBox(isChecked: bool option, fn: bool option -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
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
