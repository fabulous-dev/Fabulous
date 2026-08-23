namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabEditor =
    inherit IFabInputView

module Editor =
    let WidgetKey = Widgets.register<Editor>()

    let AutoSize =
        Attributes.defineBindableEnum<EditorAutoSizeOption> Editor.AutoSizeProperty

    let Completed =
        Attributes.Mvu.defineEventNoArg "Editor_Completed" (fun target -> (target :?> Editor).Completed)

    let CursorPosition = Attributes.defineBindableInt Editor.CursorPositionProperty

    let FontAttributes =
        Attributes.defineBindableEnum<FontAttributes> Editor.FontAttributesProperty

    let FontAutoScalingEnabled =
        Attributes.defineBindableBool Editor.FontAutoScalingEnabledProperty

    let FontFamily =
        Attributes.defineBindableWithEquality<string> Editor.FontFamilyProperty

    let FontSize = Attributes.defineBindableFloat Editor.FontSizeProperty

    let HorizontalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> Editor.HorizontalTextAlignmentProperty

    let IsTextPredictionEnabled =
        Attributes.defineBindableBool Editor.IsTextPredictionEnabledProperty

    let SelectionLength = Attributes.defineBindableInt Editor.SelectionLengthProperty

    let VerticalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> Editor.VerticalTextAlignmentProperty

[<AutoOpen>]
module EditorBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create an Editor widget with a text and listen for text changes</summary>
        /// <param name="text">The text value</param>
        /// <param name="onTextChanged">Message to dispatch</param>
        static member inline Editor<'msg when 'msg: equality>(text: string, onTextChanged: string -> 'msg) =
            WidgetBuilder<'msg, IFabEditor>(
                Editor.WidgetKey,
                InputView.TextWithEvent.WithValue(ValueEventData.create text (fun (args: TextChangedEventArgs) -> onTextChanged args.NewTextValue))
            )

[<Extension>]
type EditorModifiers =
    /// <summary>Set the font</summary>
    /// <param name="this">Current widget</param>
    /// <param name="size">The font size</param>
    /// <param name="attributes">The font attributes</param>
    /// <param name="fontFamily">The font family</param>
    /// <param name="autoScalingEnabled">The value indicating whether auto-scaling is enabled</param>
    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #IFabEditor>,
            ?size: float,
            ?attributes: FontAttributes,
            ?fontFamily: string,
            ?autoScalingEnabled: bool
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(Editor.FontSize.WithValue(v))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(Editor.FontAttributes.WithValue(v))

        match fontFamily with
        | None -> ()
        | Some v -> res <- res.AddScalar(Editor.FontFamily.WithValue(v))

        match autoScalingEnabled with
        | None -> ()
        | Some v -> res <- res.AddScalar(Editor.FontAutoScalingEnabled.WithValue(v))

        res

    /// <summary>Set a value that controls whether the editor will change size to accommodate input as the user enters it</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value that controls whether the editor will change size to accommodate input</param>
    [<Extension>]
    static member inline autoSize(this: WidgetBuilder<'msg, #IFabEditor>, value: EditorAutoSizeOption) =
        this.AddScalar(Editor.AutoSize.WithValue(value))

    /// <summary>Set the position of the cursor</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The position of the cursor</param>
    [<Extension>]
    static member inline cursorPosition(this: WidgetBuilder<'msg, #IFabEditor>, value: int) =
        this.AddScalar(Editor.CursorPosition.WithValue(value))

    /// <summary>Set the horizontal text alignment</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The horizontal text alignment</param>
    [<Extension>]
    static member inline horizontalTextAlignment(this: WidgetBuilder<'msg, #IFabEditor>, value: TextAlignment) =
        this.AddScalar(Editor.HorizontalTextAlignment.WithValue(value))

    /// <summary>Set a value that controls whether the editor will allow text prediction</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">true will allow text prediction. otherwise false</param>
    [<Extension>]
    static member inline isPredictionEnabled(this: WidgetBuilder<'msg, #IFabEditor>, value: bool) =
        this.AddScalar(Editor.IsTextPredictionEnabled.WithValue(value))

    /// <summary>Listen for the Completed event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="msg">Message to dispatch</param>
    [<Extension>]
    static member inline onCompleted(this: WidgetBuilder<'msg, #IFabEditor>, msg: 'msg) =
        this.AddScalar(Editor.Completed.WithValue(MsgValue(msg)))

    /// <summary>Set the selection length</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The selection length</param>
    [<Extension>]
    static member inline selectionLength(this: WidgetBuilder<'msg, #IFabEditor>, value: int) =
        this.AddScalar(Editor.SelectionLength.WithValue(value))

    /// <summary>Set the vertical text alignment</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The vertical text alignment</param>
    [<Extension>]
    static member inline verticalTextAlignment(this: WidgetBuilder<'msg, #IFabEditor>, value: TextAlignment) =
        this.AddScalar(Editor.VerticalTextAlignment.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Editor control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabEditor>, value: ViewRef<Editor>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
