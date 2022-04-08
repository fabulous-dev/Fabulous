namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.PlatformConfiguration

type IEntry =
    inherit IInputView

module Entry =
    let WidgetKey = Widgets.register<Entry>()

    let ClearButtonVisibility =
        Attributes.defineBindable<ClearButtonVisibility> Entry.ClearButtonVisibilityProperty

    let CursorPosition =
        Attributes.defineBindable<int> Entry.CursorPositionProperty

    let FontAttributes =
        Attributes.defineBindable<FontAttributes> Entry.FontAttributesProperty

    let FontFamily =
        Attributes.defineBindable<string> Entry.FontFamilyProperty

    let FontSize =
        Attributes.defineBindable<float> Entry.FontSizeProperty

    let HorizontalTextAlignment =
        Attributes.defineBindable<TextAlignment> Entry.HorizontalTextAlignmentProperty

    let IsPassword =
        Attributes.defineBindable<bool> Entry.IsPasswordProperty

    let IsTextPredictionEnabled =
        Attributes.defineBindable<bool> Entry.IsTextPredictionEnabledProperty

    let ReturnType =
        Attributes.defineBindable<ReturnType> Entry.ReturnTypeProperty

    let SelectionLength =
        Attributes.defineBindable<int> Entry.SelectionLengthProperty

    let VerticalTextAlignment =
        Attributes.defineBindable<TextAlignment> Entry.VerticalTextAlignmentProperty

    let Completed =
        Attributes.defineEventNoArg "Entry_Completed" (fun target -> (target :?> Entry).Completed)

    let CursorColor =
        Attributes.define<Color>
            "Entry_CursorColor"
            (fun _ newValueOpt node ->
                let entry = node.Target :?> Entry

                let value =
                    match newValueOpt with
                    | ValueNone -> Color.Default
                    | ValueSome x -> x

                iOSSpecific.Entry.SetCursorColor(entry, value))

[<AutoOpen>]
module EntryBuilders =
    type Fabulous.XamarinForms.View with
        static member inline Entry<'msg>(text: string, onTextChanged: string -> 'msg) =
            WidgetBuilder<'msg, IEntry>(
                Entry.WidgetKey,
                InputView.Text.WithValue(text),
                InputView.TextChanged.WithValue(fun args -> onTextChanged args.NewTextValue |> box)
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
            ?namedSize: NamedSize,
            ?attributes: FontAttributes,
            ?fontFamily: string
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(Entry.FontSize.WithValue(v))

        match namedSize with
        | None -> ()
        | Some v -> res <- res.AddScalar(Entry.FontSize.WithValue(Device.GetNamedSize(v, typeof<Entry>)))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(Entry.FontAttributes.WithValue(v))

        match fontFamily with
        | None -> ()
        | Some v -> res <- res.AddScalar(Entry.FontFamily.WithValue(v))

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

[<Extension>]
type EntryPlatformModifiers =
    /// <summary>iOS platform specific. Sets the entry color of the cursor</summary>
    /// <param name="value">The new cursor color.</param>
    [<Extension>]
    static member inline cursorColor(this: WidgetBuilder<'msg, #IEntry>, value: Color) =
        this.AddScalar(Entry.CursorColor.WithValue(value))
