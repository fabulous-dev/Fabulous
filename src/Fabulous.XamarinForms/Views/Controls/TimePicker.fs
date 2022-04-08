namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms
open Xamarin.Forms.PlatformConfiguration

type ITimePicker =
    inherit IView

module TimePicker =
    let WidgetKey = Widgets.register<FabulousTimePicker>()

    let CharacterSpacing =
        Attributes.defineBindable<float> TimePicker.CharacterSpacingProperty

    let Time =
        Attributes.defineBindable<System.TimeSpan> TimePicker.TimeProperty

    let TimeSelected =
        Attributes.defineEvent "TimePicker_TimeSelected" (fun target -> (target :?> FabulousTimePicker).TimeSelected)

    let FontAttributes =
        Attributes.defineBindable<Xamarin.Forms.FontAttributes> TimePicker.FontAttributesProperty

    let FontFamily =
        Attributes.defineBindable<string> TimePicker.FontFamilyProperty

    let FontSize =
        Attributes.defineBindable<float> TimePicker.FontSizeProperty

    let Format =
        Attributes.defineBindable<string> TimePicker.FormatProperty

    let TextColor =
        Attributes.defineAppThemeBindable<Color> TimePicker.TextColorProperty

    let TextTransform =
        Attributes.defineBindable<Xamarin.Forms.TextTransform> TimePicker.TextTransformProperty

    let UpdateMode =
        Attributes.define<iOSSpecific.UpdateMode>
            "TimePicker_UpdateMode"
            (fun _ newValueOpt node ->
                let timePicker = node.Target :?> TimePicker

                let value =
                    match newValueOpt with
                    | ValueNone -> iOSSpecific.UpdateMode.Immediately
                    | ValueSome v -> v

                iOSSpecific.TimePicker.SetUpdateMode(timePicker, value))

[<AutoOpen>]
module TimePickerBuilders =
    type Fabulous.XamarinForms.View with
        static member inline TimePicker<'msg>(time: System.TimeSpan, onTimeSelected: System.TimeSpan -> 'msg) =
            WidgetBuilder<'msg, ITimePicker>(
                TimePicker.WidgetKey,
                TimePicker.Time.WithValue(time),
                TimePicker.TimeSelected.WithValue(fun args -> onTimeSelected args.NewTime |> box)
            )

[<Extension>]
type TimePickerModifiers =
    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, #ITimePicker>, value: float) =
        this.AddScalar(TimePicker.CharacterSpacing.WithValue(value))

    [<Extension>]
    static member inline format(this: WidgetBuilder<'msg, #ITimePicker>, value: string) =
        this.AddScalar(TimePicker.Format.WithValue(value))

    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #ITimePicker>, light: Color, ?dark: Color) =
        this.AddScalar(TimePicker.TextColor.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline textTransform(this: WidgetBuilder<'msg, #ITimePicker>, value: TextTransform) =
        this.AddScalar(TimePicker.TextTransform.WithValue(value))

    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #ITimePicker>,
            ?size: double,
            ?namedSize: NamedSize,
            ?attributes: FontAttributes,
            ?fontFamily: string
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(TimePicker.FontSize.WithValue(v))

        match namedSize with
        | None -> ()
        | Some v -> res <- res.AddScalar(TimePicker.FontSize.WithValue(Device.GetNamedSize(v, typeof<TimePicker>)))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(TimePicker.FontAttributes.WithValue(v))

        match fontFamily with
        | None -> ()
        | Some v -> res <- res.AddScalar(TimePicker.FontFamily.WithValue(v))

        res

    /// <summary>Link a ViewRef to access the direct TimePicker control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ITimePicker>, value: ViewRef<TimePicker>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type TimePickerPlatformModifiers =
    /// <summary>iOS platform specific. Sets a value that controls whether elements in the time picker are continuously updated while scrolling or updated once after scrolling has completed.</summary>
    /// <param name="mode">The new property value to assign.</param>
    [<Extension>]
    static member inline updateMode(this: WidgetBuilder<'msg, #ITimePicker>, mode: iOSSpecific.UpdateMode) =
        this.AddScalar(TimePicker.UpdateMode.WithValue(mode))
