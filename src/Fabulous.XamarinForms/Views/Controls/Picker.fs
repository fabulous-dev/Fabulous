namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms
open Xamarin.Forms.PlatformConfiguration

type IPicker =
    inherit IView

module Picker =
    let WidgetKey = Widgets.register<Picker> ()

    let CharacterSpacing =
        Attributes.defineBindable<float> Picker.CharacterSpacingProperty

    let HorizontalTextAlignment =
        Attributes.defineBindable<TextAlignment> Picker.HorizontalTextAlignmentProperty

    let VerticalTextAlignment =
        Attributes.defineBindable<TextAlignment> Picker.VerticalTextAlignmentProperty

    let FontAttributes =
        Attributes.defineBindable<FontAttributes> Picker.FontAttributesProperty

    let FontFamily =
        Attributes.defineBindable<string> Picker.FontFamilyProperty

    let FontSize =
        Attributes.defineBindable<float> Picker.FontSizeProperty

    let TextColor =
        Attributes.defineAppThemeBindable<Color> Picker.TextColorProperty

    let TextTransform =
        Attributes.defineBindable<TextTransform> Picker.TextTransformProperty

    let Title =
        Attributes.defineBindable<string> Picker.TitleProperty

    let TitleColor =
        Attributes.defineAppThemeBindable<Color> Picker.TitleColorProperty

    let ItemSource =
        Attributes.define<string array>
            "Picker_ItemSource"
            (fun _ newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(Picker.ItemsSourceProperty)
                | ValueSome value -> target.SetValue(Picker.ItemsSourceProperty, value))

    let SelectedIndexChanged =
        Attributes.defineEventWithAdditionalStep
            "Picker_SelectedIndexChanged"
            (fun target -> (target :?> Picker).SelectedIndexChanged)

    let UpdateMode =
        Attributes.define<iOSSpecific.UpdateMode>
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
    type Fabulous.XamarinForms.View with
        static member inline Picker<'msg>(items: string list, onSelectedIndexChanged: int -> 'msg) =
            WidgetBuilder<'msg, IPicker>(
                Picker.WidgetKey,
                Picker.ItemSource.WithValue(items |> Array.ofList),
                Picker.SelectedIndexChanged.WithValue
                    (fun sender ->
                        let picker = sender :?> Picker

                        onSelectedIndexChanged picker.SelectedIndex |> box)
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
    static member inline textColor(this: WidgetBuilder<'msg, #IPicker>, light: Color, ?dark: Color) =
        this.AddScalar(Picker.TextColor.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline textTransform(this: WidgetBuilder<'msg, #IPicker>, value: TextTransform) =
        this.AddScalar(Picker.TextTransform.WithValue(value))

    [<Extension>]
    static member inline title(this: WidgetBuilder<'msg, #IPicker>, value: string) =
        this.AddScalar(Picker.Title.WithValue(value))

    /// <summary>Set the source of the thumbImage.</summary>
    /// <param name="light">The color of the title in the light theme.</param>
    /// <param name="dark">The color of the title in the dark theme.</param>
    [<Extension>]
    static member inline titleColor(this: WidgetBuilder<'msg, #IPicker>, light: Color, ?dark: Color) =
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
