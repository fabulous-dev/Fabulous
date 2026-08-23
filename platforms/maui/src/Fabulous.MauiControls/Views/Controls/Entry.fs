namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.PlatformConfiguration
open Microsoft.Maui.Graphics

type IFabEntry =
    inherit IFabInputView

module Entry =
    let WidgetKey = Widgets.register<Entry>()

    let ClearButtonVisibility =
        Attributes.defineBindableEnum<ClearButtonVisibility> Entry.ClearButtonVisibilityProperty

    let Completed =
        Attributes.Mvu.defineEventNoArg "Entry_Completed" (fun target -> (target :?> Entry).Completed)

    let CursorPosition = Attributes.defineBindableInt Entry.CursorPositionProperty

    let FontAttributes =
        Attributes.defineBindableEnum<FontAttributes> Entry.FontAttributesProperty

    let FontAutoScalingEnabled =
        Attributes.defineBindableBool Entry.FontAutoScalingEnabledProperty

    let FontFamily =
        Attributes.defineBindableWithEquality<string> Entry.FontFamilyProperty

    let FontSize = Attributes.defineBindableFloat Entry.FontSizeProperty

    let HorizontalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> Entry.HorizontalTextAlignmentProperty

    let IsPassword = Attributes.defineBindableBool Entry.IsPasswordProperty

    let IsTextPredictionEnabled =
        Attributes.defineBindableBool Entry.IsTextPredictionEnabledProperty

    let ReturnType = Attributes.defineBindableEnum<ReturnType> Entry.ReturnTypeProperty

    let SelectionLength = Attributes.defineBindableInt Entry.SelectionLengthProperty

    let VerticalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> Entry.VerticalTextAlignmentProperty

module EntryPlatform =
    let CursorColor =
        Attributes.defineSmallScalar "Entry_CursorColor" (fun c -> Color.FromUint(uint c)) (fun _ newValueOpt node ->
            let entry = node.Target :?> Entry

            let value =
                match newValueOpt with
                | ValueNone -> null
                | ValueSome x -> x

            iOSSpecific.Entry.SetCursorColor(entry, value))

[<AutoOpen>]
module EntryBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create an Entry widget with a text and listen for text changes</summary>
        /// <param name="text">The text value</param>
        /// <param name="onTextChanged">Message to dispatch</param>
        static member inline Entry<'msg when 'msg: equality>(text: string, onTextChanged: string -> 'msg) =
            WidgetBuilder<'msg, IFabEntry>(
                Entry.WidgetKey,
                InputView.TextWithEvent.WithValue(ValueEventData.create text (fun (args: TextChangedEventArgs) -> onTextChanged args.NewTextValue))
            )

[<Extension>]
type EntryModifiers =
    /// <summary>Set the visibility of the clear button</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The visibility of the clear button</param>
    [<Extension>]
    static member inline clearButtonVisibility(this: WidgetBuilder<'msg, #IFabEntry>, value: ClearButtonVisibility) =
        this.AddScalar(Entry.ClearButtonVisibility.WithValue(value))

    /// <summary>Set the position of the cursor</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The position of the cursor</param>
    [<Extension>]
    static member inline cursorPosition(this: WidgetBuilder<'msg, #IFabEntry>, value: int) =
        this.AddScalar(Entry.CursorPosition.WithValue(value))

    /// <summary>Set the font</summary>
    /// <param name="this">Current widget</param>
    /// <param name="size">The font size</param>
    /// <param name="attributes">The font attributes</param>
    /// <param name="fontFamily">The font family</param>
    /// <param name="autoScalingEnabled">The value indicating whether auto-scaling is enabled</param>
    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #IFabEntry>,
            ?size: float,
            ?attributes: FontAttributes,
            ?fontFamily: string,
            ?autoScalingEnabled: bool
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(Entry.FontSize.WithValue(v))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(Entry.FontAttributes.WithValue(v))

        match fontFamily with
        | None -> ()
        | Some v -> res <- res.AddScalar(Entry.FontFamily.WithValue(v))

        match autoScalingEnabled with
        | None -> ()
        | Some v -> res <- res.AddScalar(Entry.FontAutoScalingEnabled.WithValue(v))

        res

    /// <summary>Set the horizontal text alignment</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The horizontal text alignment</param>
    [<Extension>]
    static member inline horizontalTextAlignment(this: WidgetBuilder<'msg, #IFabEntry>, value: TextAlignment) =
        this.AddScalar(Entry.HorizontalTextAlignment.WithValue(value))

    /// <summary>Set the value indicating whether the field expects a password</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value indicating whether the field expects a password</param>
    [<Extension>]
    static member inline isPassword(this: WidgetBuilder<'msg, #IFabEntry>, value: bool) =
        this.AddScalar(Entry.IsPassword.WithValue(value))

    /// <summary>Set the value indicating whether the field is enabled for text prediction and suggestion</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value indicating whether the field is enabled for text prediction and suggestion</param>
    [<Extension>]
    static member inline isTextPredictionEnabled(this: WidgetBuilder<'msg, #IFabEntry>, value: bool) =
        this.AddScalar(Entry.IsTextPredictionEnabled.WithValue(value))

    /// <summary>Listen for the Completed event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="msg">Message to dispatch</param>
    [<Extension>]
    static member inline onCompleted(this: WidgetBuilder<'msg, #IFabEntry>, msg: 'msg) =
        this.AddScalar(Entry.Completed.WithValue(MsgValue(msg)))

    /// <summary>Set the return type of the keyboard</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The return type of the keyboard</param>
    [<Extension>]
    static member inline returnType(this: WidgetBuilder<'msg, #IFabEntry>, value: ReturnType) =
        this.AddScalar(Entry.ReturnType.WithValue(value))

    /// <summary>Set the selection length</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The selection length</param>
    [<Extension>]
    static member inline selectionLength(this: WidgetBuilder<'msg, #IFabEntry>, value: int) =
        this.AddScalar(Entry.SelectionLength.WithValue(value))

    /// <summary>Set the vertical text alignment</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The vertical text alignment</param>
    [<Extension>]
    static member inline verticalTextAlignment(this: WidgetBuilder<'msg, #IFabEntry>, value: TextAlignment) =
        this.AddScalar(Entry.VerticalTextAlignment.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Entry control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabEntry>, value: ViewRef<Entry>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type EntryPlatformModifiers =
    /// <summary>iOS platform specific. Set the cursor color.</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The cursor color</param>
    [<Extension>]
    static member inline cursorColor(this: WidgetBuilder<'msg, #IFabEntry>, value: Color) =
        this.AddScalar(EntryPlatform.CursorColor.WithValue(value))
