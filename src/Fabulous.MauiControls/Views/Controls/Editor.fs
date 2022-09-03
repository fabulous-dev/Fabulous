namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type IEditor =
    inherit Fabulous.Maui.IInputView

module Editor =
    let WidgetKey = Widgets.register<Editor>()

    let AutoSize =
        Attributes.defineBindableEnum<EditorAutoSizeOption> Editor.AutoSizeProperty

    let FontAttributes =
        Attributes.defineBindableEnum<FontAttributes> Editor.FontAttributesProperty

    let FontFamily =
        Attributes.defineBindableWithEquality<string> Editor.FontFamilyProperty

    let FontSize =
        Attributes.defineBindableFloat Editor.FontSizeProperty

    let IsTextPredictionEnabled =
        Attributes.defineBindableBool Editor.IsTextPredictionEnabledProperty

    let FontAutoScalingEnabled =
        Attributes.defineBindableBool Editor.FontAutoScalingEnabledProperty

    let CursorPosition =
        Attributes.defineBindableInt Editor.CursorPositionProperty

    let SelectionLength =
        Attributes.defineBindableInt Editor.SelectionLengthProperty

    let HorizontalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> Editor.HorizontalTextAlignmentProperty

    let VerticalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> Editor.VerticalTextAlignmentProperty

    let Completed =
        Attributes.defineEventNoArg "Editor_Completed" (fun target -> (target :?> Editor).Completed)

[<AutoOpen>]
module EditorBuilders =
    type Fabulous.Maui.View with
        static member inline Editor<'msg>(text: string, onTextChanged: string -> 'msg) =
            WidgetBuilder<'msg, IEditor>(
                Editor.WidgetKey,
                InputView.TextWithEvent.WithValue(
                    ValueEventData.create text (fun args -> onTextChanged args.NewTextValue |> box)
                )
            )

[<Extension>]
type EditorModifiers =
    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #IEditor>,
            ?size: float,
            ?attributes: FontAttributes,
            ?fontFamily: string,
            ?fontAutoScalingEnabled: bool
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

        match fontAutoScalingEnabled with
        | None -> ()
        | Some v -> res <- res.AddScalar(Editor.FontAutoScalingEnabled.WithValue(v))

        res

    /// <summary>Sets a value that controls whether the editor will change size to accommodate input as the user enters it.</summary>
    /// <param name="value">Value that controls whether the editor will change size to accommodate input</param>
    [<Extension>]
    static member inline autoSize(this: WidgetBuilder<'msg, #IEditor>, value: EditorAutoSizeOption) =
        this.AddScalar(Editor.AutoSize.WithValue(value))

    /// <summary>Sets a value that controls whether the editor will allow text prediction.</summary>
    /// <param name="true will allow text prediction. otherwise false.</param>
    [<Extension>]
    static member inline isPredictionEnabled(this: WidgetBuilder<'msg, #IEditor>, value: bool) =
        this.AddScalar(Editor.IsTextPredictionEnabled.WithValue(value))

    /// <summary>Event that is fired when editing has completed.</summary>
    /// <param name="onCompleted">Msg to dispatch when editing has completed.</param>
    [<Extension>]
    static member inline onCompleted(this: WidgetBuilder<'msg, #IEditor>, onCompleted: 'msg) =
        this.AddScalar(Editor.Completed.WithValue(onCompleted))

    /// <summary>Determines the position at which the next character will be inserted into the string stored in the Text property.</summary>
    [<Extension>]
    static member inline cursorPosition(this: WidgetBuilder<'msg, #IEditor>, value: int) =
        this.AddScalar(Editor.CursorPosition.WithValue(value))

    /// <summary>Set the length of text selection within the SearchBar.</summary>
    [<Extension>]
    static member inline selectionLength(this: WidgetBuilder<'msg, #IEditor>, value: int) =
        this.AddScalar(Editor.SelectionLength.WithValue(value))

    /// <summary>Defines whether an app's UI reflects text scaling preferences set in the operating system.</summary>
    /// <param name="value">The default value of this property is true.</param>
    [<Extension>]
    static member inline fontAutoScalingEnabled(this: WidgetBuilder<'msg, #IEditor>, value: bool) =
        this.AddScalar(Editor.FontAutoScalingEnabled.WithValue(value))

    /// <summary>Set the horizontal text alignment</summary>
    /// param name="value">The horizontal text alignment</summary>
    [<Extension>]
    static member inline horizontalTextAlignment(this: WidgetBuilder<'msg, #IEditor>, value: TextAlignment) =
        this.AddScalar(Editor.HorizontalTextAlignment.WithValue(value))

    /// <summary>Set the vertical text alignment</summary>
    /// param name="value">The vertical text alignment</summary>
    [<Extension>]
    static member inline verticalTextAlignment(this: WidgetBuilder<'msg, #IEditor>, value: TextAlignment) =
        this.AddScalar(Editor.VerticalTextAlignment.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Editor control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IEditor>, value: ViewRef<Editor>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
