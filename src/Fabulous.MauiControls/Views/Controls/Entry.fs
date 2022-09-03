namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.PlatformConfiguration

type IEntry =
    inherit Fabulous.Maui.IInputView

module Entry =
    let WidgetKey = Widgets.register<Entry>()

    let ClearButtonVisibility =
        Attributes.defineBindableWithEquality<ClearButtonVisibility> Entry.ClearButtonVisibilityProperty

    let CursorPosition =
        Attributes.defineBindableInt Entry.CursorPositionProperty

    let FontAttributes =
        Attributes.defineBindableEnum<FontAttributes> Entry.FontAttributesProperty

    let FontFamily =
        Attributes.defineBindableWithEquality<string> Entry.FontFamilyProperty

    let FontSize =
        Attributes.defineBindableFloat Entry.FontSizeProperty

    let HorizontalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> Entry.HorizontalTextAlignmentProperty

    let IsPassword =
        Attributes.defineBindableBool Entry.IsPasswordProperty

    let IsTextPredictionEnabled =
        Attributes.defineBindableBool Entry.IsTextPredictionEnabledProperty

    let ReturnType =
        Attributes.defineBindableEnum<ReturnType> Entry.ReturnTypeProperty

    let SelectionLength =
        Attributes.defineBindableInt Entry.SelectionLengthProperty

    let VerticalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> Entry.VerticalTextAlignmentProperty

    let FontAutoScalingEnabled =
        Attributes.defineBindableBool Entry.FontAutoScalingEnabledProperty

    let Completed =
        Attributes.defineEventNoArg "Entry_Completed" (fun target -> (target :?> Entry).Completed)

    let CursorColor =
        Attributes.defineSmallScalar<FabColor>
            "Entry_CursorColor"
            SmallScalars.FabColor.decode
            (fun _ newValueOpt node ->
                let entry = node.Target :?> Entry

                let value =
                    match newValueOpt with
                    | ValueNone -> null
                    | ValueSome x -> x.ToXFColor()

                iOSSpecific.Entry.SetCursorColor(entry, value))

[<AutoOpen>]
module EntryBuilders =
    type Fabulous.Maui.View with
        static member inline Entry<'msg>(text: string, onTextChanged: string -> 'msg) =
            WidgetBuilder<'msg, IEntry>(
                Entry.WidgetKey,
                InputView.TextWithEvent.WithValue(
                    ValueEventData.create text (fun args -> onTextChanged args.NewTextValue |> box)
                )
            )

[<Extension>]
type EntryModifiers =
    [<Extension>]
    static member inline clearButtonVisibility(this: WidgetBuilder<'msg, #IEntry>, value: ClearButtonVisibility) =
        this.AddScalar(Entry.ClearButtonVisibility.WithValue(value))

    [<Extension>]
    static member inline cursorPosition(this: WidgetBuilder<'msg, #IEntry>, value: int) =
        this.AddScalar(Entry.CursorPosition.WithValue(value))

    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #IEntry>,
            ?size: float,
            ?attributes: FontAttributes,
            ?fontFamily: string,
            ?fontAutoScalingEnabled: bool
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

        match fontAutoScalingEnabled with
        | None -> ()
        | Some v -> res <- res.AddScalar(Entry.FontAutoScalingEnabled.WithValue(v))

        res

    [<Extension>]
    static member inline horizontalTextAlignment(this: WidgetBuilder<'msg, #IEntry>, value: TextAlignment) =
        this.AddScalar(Entry.HorizontalTextAlignment.WithValue(value))

    [<Extension>]
    static member inline isPassword(this: WidgetBuilder<'msg, #IEntry>, value: bool) =
        this.AddScalar(Entry.IsPassword.WithValue(value))

    [<Extension>]
    static member inline isTextPredictionEnabled(this: WidgetBuilder<'msg, #IEntry>, value: bool) =
        this.AddScalar(Entry.IsTextPredictionEnabled.WithValue(value))

    [<Extension>]
    static member inline returnType(this: WidgetBuilder<'msg, #IEntry>, value: ReturnType) =
        this.AddScalar(Entry.ReturnType.WithValue(value))

    [<Extension>]
    static member inline selectionLength(this: WidgetBuilder<'msg, #IEntry>, value: int) =
        this.AddScalar(Entry.SelectionLength.WithValue(value))

    [<Extension>]
    static member inline verticalTextAlignment(this: WidgetBuilder<'msg, #IEntry>, value: TextAlignment) =
        this.AddScalar(Entry.VerticalTextAlignment.WithValue(value))

    [<Extension>]
    static member inline onCompleted(this: WidgetBuilder<'msg, #IEntry>, onCompleted: 'msg) =
        this.AddScalar(Entry.Completed.WithValue(onCompleted))

    /// <summary>Link a ViewRef to access the direct Entry control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IEntry>, value: ViewRef<Entry>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    /// <summary>Defines whether the text will reflect scaling preferences set in the operating system.</summary>
    /// <param name="value">The default value of this property is true.</param>
    [<Extension>]
    static member inline fontAutoScalingEnabled(this: WidgetBuilder<'msg, #IEntry>, value: bool) =
        this.AddScalar(Entry.FontAutoScalingEnabled.WithValue(value))

[<Extension>]
type EntryPlatformModifiers =
    /// <summary>iOS platform specific. Sets the cursor color.</summary>
    /// <param name="value">The new cursor color.</param>
    [<Extension>]
    static member inline cursorColor(this: WidgetBuilder<'msg, #IEntry>, value: FabColor) =
        this.AddScalar(Entry.CursorColor.WithValue(value))
