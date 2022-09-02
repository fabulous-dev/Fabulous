namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.PlatformConfiguration

type IPicker =
    inherit Fabulous.Maui.IView

module Picker =
    let WidgetKey = Widgets.register<CustomPicker>()

    let CharacterSpacing =
        Attributes.defineBindableFloat Picker.CharacterSpacingProperty

    let HorizontalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> Picker.HorizontalTextAlignmentProperty

    let VerticalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> Picker.VerticalTextAlignmentProperty

    let FontAttributes =
        Attributes.defineBindableEnum<FontAttributes> Picker.FontAttributesProperty

    let FontFamily =
        Attributes.defineBindableWithEquality<string> Picker.FontFamilyProperty

    let FontSize =
        Attributes.defineBindableFloat Picker.FontSizeProperty

    let TextColor =
        Attributes.defineBindableAppThemeColor Picker.TextColorProperty

    // let TextTransform =
    //     Attributes.defineBindableEnum<TextTransform> Picker.TextTransformProperty

    let Title =
        Attributes.defineBindableWithEquality<string> Picker.TitleProperty

    let TitleColor =
        Attributes.defineBindableAppThemeColor Picker.TitleColorProperty

    let ItemsSource =
        Attributes.defineSimpleScalarWithEquality<string array>
            "Picker_ItemSource"
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(Picker.ItemsSourceProperty)
                | ValueSome value -> target.SetValue(Picker.ItemsSourceProperty, value))

    let SelectedIndexWithEvent =
        Attributes.defineBindableWithEvent
            "Picker_SelectedIndexChanged"
            Picker.SelectedIndexProperty
            (fun target ->
                (target :?> CustomPicker)
                    .CustomSelectedIndexChanged)

    let UpdateMode =
        Attributes.defineEnum<iOSSpecific.UpdateMode>
            "Picker_UpdateMode"
            (fun _ newValueOpt node ->
                let picker = node.Target :?> Picker

                let value =
                    match newValueOpt with
                    | ValueNone -> iOSSpecific.UpdateMode.Immediately
                    | ValueSome v -> v

                iOSSpecific.Picker.SetUpdateMode(picker, value))

[<AutoOpen>]
module PickerBuilders =
    type Fabulous.Maui.View with
        static member inline Picker<'msg>(items: string list, selectedIndex: int, onSelectedIndexChanged: int -> 'msg) =
            WidgetBuilder<'msg, IPicker>(
                Picker.WidgetKey,
                Picker.ItemsSource.WithValue(Array.ofList items),
                Picker.SelectedIndexWithEvent.WithValue(
                    ValueEventData.create selectedIndex (fun args -> onSelectedIndexChanged args.CurrentPosition |> box)
                )
            )

[<Extension>]
type PickerModifiers =
    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, #IPicker>, value: float) =
        this.AddScalar(Picker.CharacterSpacing.WithValue(value))

    [<Extension>]
    static member inline horizontalTextAlignment(this: WidgetBuilder<'msg, #IPicker>, value: TextAlignment) =
        this.AddScalar(Picker.HorizontalTextAlignment.WithValue(value))

    [<Extension>]
    static member inline verticalTextAlignment(this: WidgetBuilder<'msg, #IPicker>, value: TextAlignment) =
        this.AddScalar(Picker.VerticalTextAlignment.WithValue(value))

    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #IPicker>,
            ?size: double,
            ?namedSize: NamedSize,
            ?attributes: FontAttributes,
            ?fontFamily: string
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(Picker.FontSize.WithValue(v))

        match namedSize with
        | None -> ()
        | Some v -> res <- res.AddScalar(Picker.FontSize.WithValue(Device.GetNamedSize(v, typeof<Picker>)))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(Picker.FontAttributes.WithValue(v))

        match fontFamily with
        | None -> ()
        | Some v -> res <- res.AddScalar(Picker.FontFamily.WithValue(v))

        res

    /// <summary>Set the source of the thumbImage.</summary>
    /// <param name="light">The color of the text in the light theme.</param>
    /// <param name="dark">The color of the text in the dark theme.</param>
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #IPicker>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(Picker.TextColor.WithValue(AppTheme.create light dark))

    // [<Extension>]
    // static member inline textTransform(this: WidgetBuilder<'msg, #IPicker>, value: TextTransform) =
    //     this.AddScalar(Picker.TextTransform.WithValue(value))

    [<Extension>]
    static member inline title(this: WidgetBuilder<'msg, #IPicker>, value: string) =
        this.AddScalar(Picker.Title.WithValue(value))

    /// <summary>Set the source of the thumbImage.</summary>
    /// <param name="light">The color of the title in the light theme.</param>
    /// <param name="dark">The color of the title in the dark theme.</param>
    [<Extension>]
    static member inline titleColor(this: WidgetBuilder<'msg, #IPicker>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(Picker.TitleColor.WithValue(AppTheme.create light dark))

    /// <summary>Link a ViewRef to access the direct Picker control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IPicker>, value: ViewRef<Picker>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type PickerPlatformModifiers =
    /// <summary>iOS platform specific. Sets a value that controls whether elements in the picker are continuously updated while scrolling or updated once after scrolling has completed.</summary>
    /// <param name="mode">The new property value to assign.</param>
    [<Extension>]
    static member inline updateMode(this: WidgetBuilder<'msg, #IPicker>, mode: iOSSpecific.UpdateMode) =
        this.AddScalar(Picker.UpdateMode.WithValue(mode))
