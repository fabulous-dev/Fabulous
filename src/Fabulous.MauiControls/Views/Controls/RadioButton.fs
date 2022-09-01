namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui
open Microsoft.Maui.Controls

type IRadioButton =
    inherit Fabulous.Maui.ITemplatedView

module RadioButton =
    let WidgetKey = Widgets.register<RadioButton>()

    let BorderColor =
        Attributes.defineBindableAppThemeColor RadioButton.BorderColorProperty

    let GroupName =
        Attributes.defineBindableWithEquality<string> RadioButton.GroupNameProperty

    let BorderWidth =
        Attributes.defineBindableFloat RadioButton.BorderWidthProperty

    let CharacterSpacing =
        Attributes.defineBindableFloat RadioButton.CharacterSpacingProperty

    let CornerRadius =
        Attributes.defineBindableFloat RadioButton.CornerRadiusProperty

    let ContentString =
        Attributes.defineBindableWithEquality<string> RadioButton.ContentProperty

    let ContentWidget =
        Attributes.defineBindableWidget RadioButton.ContentProperty

    let FontAttributes =
        Attributes.defineBindableEnum<FontAttributes> RadioButton.FontAttributesProperty

    let FontFamily =
        Attributes.defineBindableWithEquality<string> RadioButton.FontFamilyProperty

    let FontSize =
        Attributes.defineBindableFloat RadioButton.FontSizeProperty

    let TextColor =
        Attributes.defineBindableAppThemeColor RadioButton.TextColorProperty

    let TextTransform =
        Attributes.defineBindableEnum<TextTransform> RadioButton.TextTransformProperty

    let RadioButtonGroupName =
        Attributes.defineBindableWithEquality<string> RadioButtonGroup.GroupNameProperty

    let IsCheckedWithEvent =
        Attributes.defineBindableWithEvent
            "RadioButton_CheckedChanged"
            RadioButton.IsCheckedProperty
            (fun target -> (target :?> RadioButton).CheckedChanged)

[<AutoOpen>]
module RadioButtonBuilders =

    type Fabulous.Maui.View with
        static member inline RadioButton<'msg>(content: string, isChecked: bool, onChecked: bool -> 'msg) =
            WidgetBuilder<'msg, IRadioButton>(
                RadioButton.WidgetKey,
                RadioButton.IsCheckedWithEvent.WithValue(
                    ValueEventData.create isChecked (fun args -> onChecked args.Value |> box)
                ),
                RadioButton.ContentString.WithValue(content)
            )

        static member inline RadioButton<'msg, 'marker when 'marker :> IView>
            (
                content: WidgetBuilder<'msg, 'marker>,
                isChecked: bool,
                onChecked: bool -> 'msg
            ) =
            WidgetBuilder<'msg, IRadioButton>(
                RadioButton.WidgetKey,
                AttributesBundle(
                    StackList.one(
                        RadioButton.IsCheckedWithEvent.WithValue(
                            ValueEventData.create isChecked (fun args -> onChecked args.Value |> box)
                        )
                    ),
                    ValueSome [| RadioButton.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type RadioButtonModifiers =
    /// <summary>Set the border color of the radio button</summary>
    /// <param name="light">The border color of the radio button in the light theme.</param>
    /// <param name="dark">The border color of the radio button in the dark theme.</param>
    [<Extension>]
    static member inline borderColor(this: WidgetBuilder<'msg, #IRadioButton>, light: FabColor, ?dark: FabColor) =
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
    static member inline textColor(this: WidgetBuilder<'msg, #IRadioButton>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(RadioButton.TextColor.WithValue(AppTheme.create light dark))

    /// <summary>Set the casing of any displayed text</summary>
    /// <param name="value">The casing of any displayed text.</param>
    [<Extension>]
    static member inline textTransform(this: WidgetBuilder<'msg, #IRadioButton>, value: TextTransform) =
        this.AddScalar(RadioButton.TextTransform.WithValue(value))

    /// <summary>Link a ViewRef to access the direct RadioButton control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IRadioButton>, value: ViewRef<RadioButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type RadioButtonAttachedModifiers =
    [<Extension>]
    static member inline radioButtonGroupName(this: WidgetBuilder<'msg, #ILayoutOfView>, value: string) =
        this.AddScalar(RadioButton.RadioButtonGroupName.WithValue(value))
