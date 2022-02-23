namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type IRadioButton =
    inherit ITemplatedView

module RadioButton =
    let WidgetKey = Widgets.register<RadioButton> ()

    let BorderColor =
        Attributes.defineAppThemeBindable<Color> RadioButton.BorderColorProperty

    let GroupName =
        Attributes.defineBindable<string> RadioButton.GroupNameProperty

    let BorderWidth =
        Attributes.defineBindable<float> RadioButton.BorderWidthProperty

    let CharacterSpacing =
        Attributes.defineBindable<float> RadioButton.CharacterSpacingProperty

    let CornerRadius =
        Attributes.defineBindable<float> RadioButton.CornerRadiusProperty

    let Content =
        Attributes.defineScalarWithConverter<Content.Value, Content.Value, Content.Value>
            "RadioButton_Content"
            id
            id
            ScalarAttributeComparers.equalityCompare
            (fun newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(RadioButton.ContentProperty)
                | ValueSome converter ->
                    match converter with
                    | Content.String string -> target.SetValue(RadioButton.ContentProperty, string)
                    | Content.Widget widget ->
                        let view =
                            Helpers.createViewForWidget node widget |> unbox

                        target.SetValue(RadioButton.ContentProperty, view))

    let FontAttributes =
        Attributes.defineBindable<FontAttributes> RadioButton.FontAttributesProperty

    let FontFamily =
        Attributes.defineBindable<string> RadioButton.FontFamilyProperty

    let FontSize =
        Attributes.defineBindable<float> RadioButton.FontSizeProperty

    let IsChecked =
        Attributes.defineBindable<bool> RadioButton.IsCheckedProperty

    let TextColor =
        Attributes.defineAppThemeBindable<Color> RadioButton.TextColorProperty

    let TextTransform =
        Attributes.defineBindable<TextTransform> RadioButton.TextTransformProperty

    let Value =
        Attributes.defineBindable<obj> RadioButton.ValueProperty

    let RadioButtonGroupName =
        Attributes.defineBindable<string> RadioButtonGroup.GroupNameProperty

    let CheckedChanged =
        Attributes.defineEvent<CheckedChangedEventArgs>
            "RadioButton_CheckedChanged"
            (fun target -> (target :?> RadioButton).CheckedChanged)

[<AutoOpen>]
module RadioButtonBuilders =

    type Fabulous.XamarinForms.View with
        static member inline RadioButton<'msg>(isChecked: bool, content: Content.Value, onChecked: bool -> 'msg) =
            WidgetBuilder<'msg, IRadioButton>(
                RadioButton.WidgetKey,
                RadioButton.IsChecked.WithValue(isChecked),
                RadioButton.Content.WithValue(content),
                RadioButton.CheckedChanged.WithValue(fun args -> onChecked args.Value |> box)
            )

[<Extension>]
type RadioButtonModifiers =
    /// <summary>Set the border color of the radio button</summary>
    /// <param name="light">The border color of the radio button in the light theme.</param>
    /// <param name="dark">The border color of the radio button in the dark theme.</param>
    [<Extension>]
    static member inline borderColor(this: WidgetBuilder<'msg, #IRadioButton>, light: Color, ?dark: Color) =
        this.AddScalar(RadioButton.BorderColor.WithValue(AppTheme.create light dark))

    /// <summary>Sets the name that specifies which RadioButton controls are mutually exclusive.</summary>
    /// <param name="value">Name that specifies which RadioButton controls are mutually exclusive. This property has a default value of null.</param>
    [<Extension>]
    static member inline groupName(this: WidgetBuilder<'msg, #IRadioButton>, value: string) =
        this.AddScalar(RadioButton.GroupName.WithValue(value))

    /// <summary>Sets the border width of the radio button.</summary>
    /// <param name="value">The border width of the radio button.</param>
    [<Extension>]
    static member inline borderWidth(this: WidgetBuilder<'msg, #IRadioButton>, value: float) =
        this.AddScalar(RadioButton.BorderWidth.WithValue(value))

    /// <summary>Sets the spacing between characters of any displayed text.</summary>
    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, #IRadioButton>, spacing: float) =
        this.AddScalar(RadioButton.CharacterSpacing.WithValue(spacing))

    /// <summary>Sets the corner Radius of the radio button.</summary>
    /// <param name="value">The corner Radius of the radio button.</param>
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IRadioButton>, value: float) =
        this.AddScalar(RadioButton.CornerRadius.WithValue(value))

    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #IRadioButton>,
            ?size: double,
            ?namedSize: NamedSize,
            ?attributes: FontAttributes,
            ?fontFamily: string
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(RadioButton.FontSize.WithValue(v))

        match namedSize with
        | None -> ()
        | Some v -> res <- res.AddScalar(RadioButton.FontSize.WithValue(Device.GetNamedSize(v, typeof<RadioButton>)))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(RadioButton.FontAttributes.WithValue(v))

        match fontFamily with
        | None -> ()
        | Some v -> res <- res.AddScalar(RadioButton.FontFamily.WithValue(v))

        res

    /// <param name="light">The text color of the radio button in the light theme.</param>
    /// <param name="dark">The text color of the radio button in the dark theme.</param>
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #IRadioButton>, light: Color, ?dark: Color) =
        this.AddScalar(RadioButton.TextColor.WithValue(AppTheme.create light dark))

    /// <summary>Set the casing of any displayed text</summary>
    /// <param name="value">The casing of any displayed text.</param>
    [<Extension>]
    static member inline textTransform(this: WidgetBuilder<'msg, #IRadioButton>, value: TextTransform) =
        this.AddScalar(RadioButton.TextTransform.WithValue(value))

    /// <summary>Sets an optional unique value associated with the RadioButton.</summary>
    /// <param value="value">An optional unique value associated with the RadioButton.</param>
    [<Extension>]
    static member inline value(this: WidgetBuilder<'msg, #IRadioButton>, value: obj) =
        this.AddScalar(RadioButton.Value.WithValue(value))

[<Extension>]
type RadioButtonAttachedModifiers =
    [<Extension>]
    static member inline radioButtonGroupName(this: WidgetBuilder<'msg, #ILayoutOfView>, value: string) =
        this.AddScalar(RadioButton.RadioButtonGroupName.WithValue(value))
