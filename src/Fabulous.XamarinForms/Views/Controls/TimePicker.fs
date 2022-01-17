namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

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
    static member inline fontAttributes(this: WidgetBuilder<'msg, #ITimePicker>, value: FontAttributes) =
        this.AddScalar(TimePicker.FontAttributes.WithValue(value))

    [<Extension>]
    static member inline fontFamily(this: WidgetBuilder<'msg, #ITimePicker>, value: string) =
        this.AddScalar(TimePicker.FontFamily.WithValue(value))

    [<Extension>]
    static member inline fontSize(this: WidgetBuilder<'msg, #ITimePicker>, value: float) =
        this.AddScalar(TimePicker.FontSize.WithValue(value))

    [<Extension>]
    static member inline format(this: WidgetBuilder<'msg, #ITimePicker>, value: string) =
        this.AddScalar(TimePicker.Format.WithValue(value))

    [<Extension>]
    static member inline textColor
        (
            this: WidgetBuilder<'msg, #ITimePicker>,
            light: Color,
            ?dark: Color
        ) =
        this.AddScalar(
            TimePicker.TextColor.WithValue(
                { Light = light
                  Dark =
                      match dark with
                      | None -> ValueNone
                      | Some v -> ValueSome v }
            )
        )

    [<Extension>]
    static member inline textTransform(this: WidgetBuilder<'msg, #ITimePicker>, value: TextTransform) =
        this.AddScalar(TimePicker.TextTransform.WithValue(value))
        
    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, ITimePicker>,
            ?size: double,
            ?namedSize: NamedSize,
            ?attributes: FontAttributes
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

        res
        
    [<Extension>]
    static member inline font(this: WidgetBuilder<'msg, #ITimePicker>, value: NamedSize) =
        this.AddScalar(TimePicker.FontSize.WithValue(Device.GetNamedSize(value, typeof<TimePicker>)))