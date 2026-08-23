namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabColorView =
    inherit IFabTemplatedControl

module ColorView =
    let WidgetKey = Widgets.register<ColorView>()

    let Color = Attributes.defineAvaloniaPropertyWithEquality ColorView.ColorProperty

    let ColorModel =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.ColorModelProperty

    let ColorSpectrumComponents =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.ColorSpectrumComponentsProperty

    let ColorSpectrumShape =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.ColorSpectrumShapeProperty

    let HexInputAlphaPosition =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.HexInputAlphaPositionProperty

    let HsvColor =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.HsvColorProperty

    let IsAccentColorsVisible =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.IsAccentColorsVisibleProperty

    let IsAlphaEnabled =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.IsAlphaEnabledProperty

    let IsAlphaVisible =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.IsAlphaVisibleProperty

    let IsColorComponentsVisible =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.IsColorComponentsVisibleProperty

    let IsColorModelVisible =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.IsColorModelVisibleProperty

    let IsColorPaletteVisible =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.IsColorPaletteVisibleProperty

    let IsColorPreviewVisible =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.IsColorPreviewVisibleProperty

    let IsColorSpectrumVisible =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.IsColorSpectrumVisibleProperty

    let IsColorSpectrumSliderVisible =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.IsColorSpectrumSliderVisibleProperty

    let IsComponentSliderVisible =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.IsComponentSliderVisibleProperty

    let IsComponentTextInputVisible =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.IsComponentTextInputVisibleProperty

    let IsHexInputVisible =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.IsHexInputVisibleProperty

    let MaxHue = Attributes.defineAvaloniaPropertyWithEquality ColorView.MaxHueProperty

    let MaxSaturation =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.MaxSaturationProperty

    let MaxValue =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.MaxValueProperty

    let MinHue = Attributes.defineAvaloniaPropertyWithEquality ColorView.MinHueProperty

    let MinSaturation =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.MinSaturationProperty

    let PaletteColumnCount =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.PaletteColumnCountProperty

    let Palette =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.PaletteProperty

    let SelectedIndex =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.SelectedIndexProperty

    let PaletteColors =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.PaletteColorsProperty

[<AutoOpen>]
module ColorViewBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ColorView widget.</summary>
        static member ColorView() =
            WidgetBuilder<'msg, IFabColorView>(ColorView.WidgetKey)

        /// <summary>Creates a ColorView widget.</summary>
        /// <param name="color">The Color value.</param>
        static member ColorView(color: Color) =
            WidgetBuilder<'msg, IFabColorView>(ColorView.WidgetKey, ColorView.Color.WithValue(color))

type ColorViewModifiers =
    /// <summary>Link a ViewRef to access the direct ColorView control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabColorView>, value: ViewRef<ColorView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    /// <summary>Set the ColorModel property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ColorModel value.</param>
    [<Extension>]
    static member inline colorModel(this: WidgetBuilder<'msg, #IFabColorView>, value: ColorModel) =
        this.AddScalar(ColorView.ColorModel.WithValue(value))

    /// <summary>Set the ColorSpectrumComponents property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ColorSpectrumComponents value.</param>
    [<Extension>]
    static member inline colorSpectrumComponents(this: WidgetBuilder<'msg, #IFabColorView>, value: ColorSpectrumComponents) =
        this.AddScalar(ColorView.ColorSpectrumComponents.WithValue(value))

    /// <summary>Set the ColorSpectrumShape property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ColorSpectrumShape value.</param>
    [<Extension>]
    static member inline colorSpectrumShape(this: WidgetBuilder<'msg, #IFabColorView>, value: ColorSpectrumShape) =
        this.AddScalar(ColorView.ColorSpectrumShape.WithValue(value))

    /// <summary>Set the HexInputAlphaPosition property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HexInputAlphaPosition value.</param>
    [<Extension>]
    static member inline hexInputAlphaPosition(this: WidgetBuilder<'msg, #IFabColorView>, value: AlphaComponentPosition) =
        this.AddScalar(ColorView.HexInputAlphaPosition.WithValue(value))

    /// <summary>Set the HsvColor property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HsvColor value.</param>
    [<Extension>]
    static member inline hsvColor(this: WidgetBuilder<'msg, #IFabColorView>, value: HsvColor) =
        this.AddScalar(ColorView.HsvColor.WithValue(value))

    /// <summary>Set the IsAccentColorsVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsAccentColorsVisible value.</param>
    [<Extension>]
    static member inline isAccentColorsVisible(this: WidgetBuilder<'msg, #IFabColorView>, value: bool) =
        this.AddScalar(ColorView.IsAccentColorsVisible.WithValue(value))

    /// <summary>Set the IsAlphaEnabled property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsAlphaEnabled value.</param>
    [<Extension>]
    static member inline isAlphaEnabled(this: WidgetBuilder<'msg, #IFabColorView>, value: bool) =
        this.AddScalar(ColorView.IsAlphaEnabled.WithValue(value))

    /// <summary>Set the IsAlphaVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsAlphaVisible value.</param>
    [<Extension>]
    static member inline isAlphaVisible(this: WidgetBuilder<'msg, #IFabColorView>, value: bool) =
        this.AddScalar(ColorView.IsAlphaVisible.WithValue(value))

    /// <summary>Set the IsColorComponentsVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsColorComponentsVisible value.</param>
    [<Extension>]
    static member inline isColorComponentsVisible(this: WidgetBuilder<'msg, #IFabColorView>, value: bool) =
        this.AddScalar(ColorView.IsColorComponentsVisible.WithValue(value))

    /// <summary>Set the IsColorModelVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsColorModelVisible value.</param>
    [<Extension>]
    static member inline isColorModelVisible(this: WidgetBuilder<'msg, #IFabColorView>, value: bool) =
        this.AddScalar(ColorView.IsColorModelVisible.WithValue(value))

    /// <summary>Set the IsColorPaletteVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsColorPaletteVisible value.</param>
    [<Extension>]
    static member inline isColorPaletteVisible(this: WidgetBuilder<'msg, #IFabColorView>, value: bool) =
        this.AddScalar(ColorView.IsColorPaletteVisible.WithValue(value))

    /// <summary>Set the IsColorPreviewVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsColorPreviewVisible value.</param>
    [<Extension>]
    static member inline isColorPreviewVisible(this: WidgetBuilder<'msg, #IFabColorView>, value: bool) =
        this.AddScalar(ColorView.IsColorPreviewVisible.WithValue(value))

    /// <summary>Set the IsColorSpectrumVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsColorSpectrumVisible value.</param>
    [<Extension>]
    static member inline isColorSpectrumVisible(this: WidgetBuilder<'msg, #IFabColorView>, value: bool) =
        this.AddScalar(ColorView.IsColorSpectrumVisible.WithValue(value))

    /// <summary>Set the IsColorSpectrumSliderVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsColorSpectrumSliderVisible value.</param>
    [<Extension>]
    static member inline isColorSpectrumSliderVisible(this: WidgetBuilder<'msg, #IFabColorView>, value: bool) =
        this.AddScalar(ColorView.IsColorSpectrumSliderVisible.WithValue(value))

    /// <summary>Set the IsComponentSliderVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsComponentSliderVisible value.</param>
    [<Extension>]
    static member inline isComponentSliderVisible(this: WidgetBuilder<'msg, #IFabColorView>, value: bool) =
        this.AddScalar(ColorView.IsComponentSliderVisible.WithValue(value))

    /// <summary>Set the IsComponentTextInputVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsComponentTextInputVisible value.</param>
    [<Extension>]
    static member inline isComponentTextInputVisible(this: WidgetBuilder<'msg, #IFabColorView>, value: bool) =
        this.AddScalar(ColorView.IsComponentTextInputVisible.WithValue(value))

    /// <summary>Set the IsHexInputVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsHexInputVisible value.</param>
    [<Extension>]
    static member inline isHexInputVisible(this: WidgetBuilder<'msg, #IFabColorView>, value: bool) =
        this.AddScalar(ColorView.IsHexInputVisible.WithValue(value))

    /// <summary>Set the MaxHue property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MaxHue value.</param>
    [<Extension>]
    static member inline maxHue(this: WidgetBuilder<'msg, #IFabColorView>, value: int) =
        this.AddScalar(ColorView.MaxHue.WithValue(value))

    /// <summary>Set the MaxSaturation property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MaxSaturation value.</param>
    [<Extension>]
    static member inline maxSaturation(this: WidgetBuilder<'msg, #IFabColorView>, value: int) =
        this.AddScalar(ColorView.MaxSaturation.WithValue(value))

    /// <summary>Set the MaxValue property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MaxValue value.</param>
    [<Extension>]
    static member inline maxValue(this: WidgetBuilder<'msg, #IFabColorView>, value: int) =
        this.AddScalar(ColorView.MaxValue.WithValue(value))

    /// <summary>Set the MinHue property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MinHue value.</param>
    [<Extension>]
    static member inline minHue(this: WidgetBuilder<'msg, #IFabColorView>, value: int) =
        this.AddScalar(ColorView.MinHue.WithValue(value))

    /// <summary>Set the MinSaturation property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MinSaturation value.</param>
    [<Extension>]
    static member inline minSaturation(this: WidgetBuilder<'msg, #IFabColorView>, value: int) =
        this.AddScalar(ColorView.MinSaturation.WithValue(value))

    /// <summary>Set the PaletteColumnCount property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PaletteColumnCount value.</param>
    [<Extension>]
    static member inline paletteColumnCount(this: WidgetBuilder<'msg, #IFabColorView>, value: int) =
        this.AddScalar(ColorView.PaletteColumnCount.WithValue(value))

    /// <summary>Set the Palette property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Palette value.</param>
    [<Extension>]
    static member inline palette(this: WidgetBuilder<'msg, #IFabColorView>, value: IColorPalette) =
        this.AddScalar(ColorView.Palette.WithValue(value))

    /// <summary>Set the SelectedIndex property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectedIndex value.</param>
    [<Extension>]
    static member inline selectedIndex(this: WidgetBuilder<'msg, #IFabColorView>, value: int) =
        this.AddScalar(ColorView.SelectedIndex.WithValue(value))
