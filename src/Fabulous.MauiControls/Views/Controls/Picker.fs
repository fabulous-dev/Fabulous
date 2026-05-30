namespace Fabulous.Maui

open System
open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.PlatformConfiguration
open Microsoft.Maui.Graphics

type IFabPicker =
    inherit IFabView

type PositionChangedEventArgs(previousPosition: int, currentPosition: int) =
    inherit EventArgs()
    member _.PreviousPosition = previousPosition
    member _.CurrentPosition = currentPosition

/// Microsoft.Maui doesn't have an event args on the SelectedIndexChanged event, so we implement it
type FabPicker() =
    inherit Picker()

    let mutable oldSelectedIndex = -1

    let selectedIndexChanged = Event<EventHandler<PositionChangedEventArgs>, _>()

    [<CLIEvent>]
    member _.CustomSelectedIndexChanged = selectedIndexChanged.Publish

    override this.OnPropertyChanged(propertyName) =
        base.OnPropertyChanged(propertyName)

        if propertyName = Picker.SelectedIndexProperty.PropertyName then
            selectedIndexChanged.Trigger(this, PositionChangedEventArgs(oldSelectedIndex, this.SelectedIndex))

    override this.OnPropertyChanging(propertyName) =
        base.OnPropertyChanging(propertyName)

        if propertyName = Picker.SelectedIndexProperty.PropertyName then
            oldSelectedIndex <- this.SelectedIndex

module Picker =
    let WidgetKey = Widgets.register<FabPicker>()

    let CharacterSpacing =
        Attributes.defineBindableFloat Picker.CharacterSpacingProperty

    let FontAttributes =
        Attributes.defineBindableEnum<FontAttributes> Picker.FontAttributesProperty

    let FontAutoScalingEnabled =
        Attributes.defineBindableBool Picker.FontAutoScalingEnabledProperty

    let FontFamily =
        Attributes.defineBindableWithEquality<string> Picker.FontFamilyProperty

    let FontSize = Attributes.defineBindableFloat Picker.FontSizeProperty

    let HorizontalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> Picker.HorizontalTextAlignmentProperty

    let ItemsSource =
        Attributes.defineSimpleScalarWithEquality<string array> "Picker_ItemSource" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Picker.ItemsSourceProperty)
            | ValueSome value -> target.SetValue(Picker.ItemsSourceProperty, value))

    let SelectedIndexWithEvent =
        Attributes.defineBindableWithEvent "Picker_SelectedIndexChanged" Picker.SelectedIndexProperty (fun target ->
            (target :?> FabPicker).CustomSelectedIndexChanged)

    let TextColor = Attributes.defineBindableColor Picker.TextColorProperty

    let Title = Attributes.defineBindableWithEquality<string> Picker.TitleProperty

    let TitleColor = Attributes.defineBindableColor Picker.TitleColorProperty

    let VerticalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> Picker.VerticalTextAlignmentProperty

module PickerPlatform =
    let UpdateMode =
        Attributes.defineEnum<iOSSpecific.UpdateMode> "Picker_UpdateMode" (fun _ newValueOpt node ->
            let picker = node.Target :?> Picker

            let value =
                match newValueOpt with
                | ValueNone -> iOSSpecific.UpdateMode.Immediately
                | ValueSome v -> v

            iOSSpecific.Picker.SetUpdateMode(picker, value))

[<AutoOpen>]
module PickerBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a Picker widget with a list of items, the selected index and listen to the selected index changes</summary>
        /// <param name="items">The items list</param>
        /// <param name="selectedIndex">The selected index</param>
        /// <param name="onSelectedIndexChanged">Message to dispatch</param>
        static member inline Picker<'msg when 'msg: equality>(items: string list, selectedIndex: int, onSelectedIndexChanged: int -> 'msg) =
            WidgetBuilder<'msg, IFabPicker>(
                Picker.WidgetKey,
                Picker.ItemsSource.WithValue(Array.ofList items),
                Picker.SelectedIndexWithEvent.WithValue(
                    ValueEventData.create selectedIndex (fun (args: PositionChangedEventArgs) -> onSelectedIndexChanged args.CurrentPosition)
                )
            )

[<Extension>]
type PickerModifiers =
    /// <summary>Set the character spacing of the text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The character spacing</param>
    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, #IFabPicker>, value: float) =
        this.AddScalar(Picker.CharacterSpacing.WithValue(value))

    /// <summary>Set the font</summary>
    /// <param name="this">Current widget</param>
    /// <param name="size">The font size</param>
    /// <param name="attributes">The font attributes</param>
    /// <param name="fontFamily">The font family</param>
    /// <param name="autoScalingEnabled">The value indicating whether auto-scaling is enabled</param>
    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #IFabPicker>,
            ?size: float,
            ?attributes: FontAttributes,
            ?fontFamily: string,
            ?autoScalingEnabled: bool
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(Picker.FontSize.WithValue(v))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(Picker.FontAttributes.WithValue(v))

        match fontFamily with
        | None -> ()
        | Some v -> res <- res.AddScalar(Picker.FontFamily.WithValue(v))

        match autoScalingEnabled with
        | None -> ()
        | Some v -> res <- res.AddScalar(Picker.FontAutoScalingEnabled.WithValue(v))

        res

    /// <summary>Set the horizontal text alignment</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The horizontal text alignment</param>
    [<Extension>]
    static member inline horizontalTextAlignment(this: WidgetBuilder<'msg, #IFabPicker>, value: TextAlignment) =
        this.AddScalar(Picker.HorizontalTextAlignment.WithValue(value))

    /// <summary>Set the color of the text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the text</param>
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #IFabPicker>, value: Color) =
        this.AddScalar(Picker.TextColor.WithValue(value))

    /// <summary>Set the title of the picker</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The title value</param>
    [<Extension>]
    static member inline title(this: WidgetBuilder<'msg, #IFabPicker>, value: string) =
        this.AddScalar(Picker.Title.WithValue(value))

    /// <summary>Set the color of the title</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the title</param>
    [<Extension>]
    static member inline titleColor(this: WidgetBuilder<'msg, #IFabPicker>, value: Color) =
        this.AddScalar(Picker.TitleColor.WithValue(value))

    /// <summary>Set the vertical text alignment</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The vertical text alignment</param>
    [<Extension>]
    static member inline verticalTextAlignment(this: WidgetBuilder<'msg, #IFabPicker>, value: TextAlignment) =
        this.AddScalar(Picker.VerticalTextAlignment.WithValue(value))

    /// <summary>Link a ViewRef to access the direct DatePicker control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPicker>, value: ViewRef<Picker>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type PickerPlatformModifiers =
    /// <summary>iOS platform specific. Set a value that controls whether elements in the picker are continuously updated while scrolling or updated once after scrolling has completed</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value that controls whether elements in the picker are continuously updated while scrolling or updated once after scrolling has completed.</param>
    [<Extension>]
    static member inline updateMode(this: WidgetBuilder<'msg, #IFabPicker>, value: iOSSpecific.UpdateMode) =
        this.AddScalar(PickerPlatform.UpdateMode.WithValue(value))
