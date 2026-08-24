namespace Fabulous.Maui

open System
open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.PlatformConfiguration
open Microsoft.Maui.Graphics

type IFabTimePicker =
    inherit IFabView

type TimeSelectedEventArgs(newTime: TimeSpan) =
    inherit EventArgs()
    member _.NewTime = newTime

/// Microsoft.Maui doesn't provide an event for selecting the time on a TimePicker, so we implement it
type FabTimePicker() =
    inherit TimePicker()

    let timeSelected = Event<EventHandler<TimeSelectedEventArgs>, _>()

    [<CLIEvent>]
    member _.TimeSelected = timeSelected.Publish

    override this.OnPropertyChanged(propertyName) =
        base.OnPropertyChanged(propertyName)

        if propertyName = TimePicker.TimeProperty.PropertyName && this.Time.HasValue then
            timeSelected.Trigger(this, TimeSelectedEventArgs(this.Time.Value))

module TimePicker =
    let WidgetKey = Widgets.register<FabTimePicker>()

    let CharacterSpacing =
        Attributes.defineBindableFloat TimePicker.CharacterSpacingProperty

    let TimeWithEvent =
        Attributes.defineBindableWithEvent "TimePicker_TimeSelected" TimePicker.TimeProperty (fun target -> (target :?> FabTimePicker).TimeSelected)

    let FontAttributes =
        Attributes.defineBindableEnum<FontAttributes> TimePicker.FontAttributesProperty

    let FontAutoScalingEnabled =
        Attributes.defineBindableBool TimePicker.FontAutoScalingEnabledProperty

    let FontFamily =
        Attributes.defineBindableWithEquality<string> TimePicker.FontFamilyProperty

    let FontSize = Attributes.defineBindableFloat TimePicker.FontSizeProperty

    let Format = Attributes.defineBindableWithEquality<string> TimePicker.FormatProperty

    let TextColor = Attributes.defineBindableColor TimePicker.TextColorProperty

module TimePickerPlatform =
    let UpdateMode =
        Attributes.defineEnum<iOSSpecific.UpdateMode> "TimePicker_UpdateMode" (fun _ newValueOpt node ->
            let timePicker = node.Target :?> TimePicker

            let value =
                match newValueOpt with
                | ValueNone -> iOSSpecific.UpdateMode.Immediately
                | ValueSome v -> v

            iOSSpecific.TimePicker.SetUpdateMode(timePicker, value))

[<AutoOpen>]
module TimePickerBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a TimePicker widget with a selected time and listen for the selected time changes</summary>
        /// <param name="time">The selected time</param>
        /// <param name="onTimeSelected">Message to dispatch</param>
        static member inline TimePicker<'msg when 'msg: equality>(time: TimeSpan, onTimeSelected: TimeSpan -> 'msg) =
            WidgetBuilder<'msg, IFabTimePicker>(
                TimePicker.WidgetKey,
                TimePicker.TimeWithEvent.WithValue(ValueEventData.create time (fun (args: TimeSelectedEventArgs) -> onTimeSelected args.NewTime))
            )

[<Extension>]
type TimePickerModifiers =
    /// <summary>Set the character spacing</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The character spacing</param>
    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, #IFabTimePicker>, value: float) =
        this.AddScalar(TimePicker.CharacterSpacing.WithValue(value))

    /// <summary>Set the font</summary>
    /// <param name="this">Current widget</param>
    /// <param name="size">The font size</param>
    /// <param name="attributes">The font attributes</param>
    /// <param name="fontFamily">The font family</param>
    /// <param name="autoScalingEnabled">The value indicating whether auto-scaling is enabled</param>
    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #IFabTimePicker>,
            ?size: float,
            ?attributes: FontAttributes,
            ?fontFamily: string,
            ?autoScalingEnabled: bool
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(TimePicker.FontSize.WithValue(v))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(TimePicker.FontAttributes.WithValue(v))

        match fontFamily with
        | None -> ()
        | Some v -> res <- res.AddScalar(TimePicker.FontFamily.WithValue(v))

        match autoScalingEnabled with
        | None -> ()
        | Some v -> res <- res.AddScalar(TimePicker.FontAutoScalingEnabled.WithValue(v))

        res

    /// <summary>Set the display format of the selected time</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The display format</param>
    [<Extension>]
    static member inline format(this: WidgetBuilder<'msg, #IFabTimePicker>, value: string) =
        this.AddScalar(TimePicker.Format.WithValue(value))

    /// <summary>Set the color of the text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the text</param>
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #IFabTimePicker>, value: Color) =
        this.AddScalar(TimePicker.TextColor.WithValue(value))

    /// <summary>Link a ViewRef to access the direct TimePicker control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTimePicker>, value: ViewRef<TimePicker>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type TimePickerPlatformModifiers =
    /// <summary>iOS platform specific. Set a value that controls whether elements in the time picker are continuously updated while scrolling or updated once after scrolling has completed</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value that controls whether elements in the time picker are continuously updated while scrolling or updated once after scrolling has completed</param>
    [<Extension>]
    static member inline updateMode(this: WidgetBuilder<'msg, #IFabTimePicker>, value: iOSSpecific.UpdateMode) =
        this.AddScalar(TimePickerPlatform.UpdateMode.WithValue(value))
