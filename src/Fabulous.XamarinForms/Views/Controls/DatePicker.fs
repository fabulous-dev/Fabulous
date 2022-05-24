namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms
open Xamarin.Forms.PlatformConfiguration

type IDatePicker =
    inherit IView

module DatePicker =
    let WidgetKey = Widgets.register<DatePicker>()

    let CharacterSpacing =
        Attributes.defineBindableFloat DatePicker.CharacterSpacingProperty

    let FontAttributes =
        Attributes.defineBindableWithEquality<Xamarin.Forms.FontAttributes> DatePicker.FontAttributesProperty

    let FontFamily =
        Attributes.defineBindableWithEquality<string> DatePicker.FontFamilyProperty

    let FontSize =
        Attributes.defineBindableFloat DatePicker.FontSizeProperty

    let Format =
        Attributes.defineBindableWithEquality<string> DatePicker.FormatProperty

    let MaximumDate =
        Attributes.defineBindableWithEquality<System.DateTime> DatePicker.MaximumDateProperty

    let MinimumDate =
        Attributes.defineBindableWithEquality<System.DateTime> DatePicker.MinimumDateProperty

    let TextColor =
        Attributes.defineBindableAppTheme<Color> DatePicker.TextColorProperty

    let TextTransform =
        Attributes.defineBindableEnum<Xamarin.Forms.TextTransform> DatePicker.TextTransformProperty

    let DateWithEvent =
        Attributes.defineBindableWithEvent
            "DatePicker_DateSelected"
            DatePicker.DateProperty
            (fun target -> (target :?> DatePicker).DateSelected)

    let UpdateMode =
        Attributes.defineSimpleScalarWithEquality<iOSSpecific.UpdateMode>
            "DatePicker_UpdateMode"
            (fun _ newValueOpt node ->
                let datePicker = node.Target :?> DatePicker

                let value =
                    match newValueOpt with
                    | ValueNone -> iOSSpecific.UpdateMode.Immediately
                    | ValueSome v -> v

                iOSSpecific.DatePicker.SetUpdateMode(datePicker, value))

[<AutoOpen>]
module DatePickerBuilders =
    type Fabulous.XamarinForms.View with
        static member inline DatePicker<'msg>(date: System.DateTime, onDateSelected: System.DateTime -> 'msg) =
            WidgetBuilder<'msg, IDatePicker>(
                DatePicker.WidgetKey,
                DatePicker.DateWithEvent.WithValue(
                    ValueEventData.create date (fun args -> onDateSelected args.NewDate |> box)
                )
            )

[<Extension>]
type DatePickerModifiers =
    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, #IDatePicker>, value: float) =
        this.AddScalar(DatePicker.CharacterSpacing.WithValue(value))

    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #IDatePicker>,
            ?size: double,
            ?namedSize: NamedSize,
            ?attributes: FontAttributes,
            ?fontFamily: string
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(DatePicker.FontSize.WithValue(v))

        match namedSize with
        | None -> ()
        | Some v -> res <- res.AddScalar(DatePicker.FontSize.WithValue(Device.GetNamedSize(v, typeof<DatePicker>)))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(DatePicker.FontAttributes.WithValue(v))

        match fontFamily with
        | None -> ()
        | Some v -> res <- res.AddScalar(DatePicker.FontFamily.WithValue(v))

        res

    [<Extension>]
    static member inline format(this: WidgetBuilder<'msg, #IDatePicker>, value: string) =
        this.AddScalar(DatePicker.Format.WithValue(value))

    [<Extension>]
    static member inline minimumDate(this: WidgetBuilder<'msg, #IDatePicker>, value: System.DateTime) =
        this.AddScalar(DatePicker.MinimumDate.WithValue(value))

    [<Extension>]
    static member inline maximumDate(this: WidgetBuilder<'msg, #IDatePicker>, value: System.DateTime) =
        this.AddScalar(DatePicker.MaximumDate.WithValue(value))

    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #IDatePicker>, light: Color, ?dark: Color) =
        this.AddScalar(DatePicker.TextColor.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline textTransform(this: WidgetBuilder<'msg, #IDatePicker>, value: TextTransform) =
        this.AddScalar(DatePicker.TextTransform.WithValue(value))

    /// <summary>Link a ViewRef to access the direct DatePicker control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IDatePicker>, value: ViewRef<DatePicker>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type DatePickerPlatformModifiers =
    /// <summary>iOS platform specific. Sets a value that controls whether elements in the date picker are continuously updated while scrolling or updated once after scrolling has completed.</summary>
    /// <param name="mode">The new property value to assign.</param>
    [<Extension>]
    static member inline updateMode(this: WidgetBuilder<'msg, #IDatePicker>, mode: iOSSpecific.UpdateMode) =
        this.AddScalar(DatePicker.UpdateMode.WithValue(mode))
