namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabColorSpectrum =
    inherit IFabTemplatedControl

module ColorSpectrum =
    let WidgetKey = Widgets.register<ColorSpectrum>()

    let Color =
        Attributes.defineAvaloniaPropertyWithEquality ColorSpectrum.ColorProperty

    let Components =
        Attributes.defineAvaloniaPropertyWithEquality ColorSpectrum.ComponentsProperty

    let HsvColor =
        Attributes.defineAvaloniaPropertyWithEquality ColorSpectrum.HsvColorProperty

    let MaxHue =
        Attributes.defineAvaloniaPropertyWithEquality ColorSpectrum.MaxHueProperty

    let MaxSaturation =
        Attributes.defineAvaloniaPropertyWithEquality ColorSpectrum.MaxSaturationProperty

    let MaxValue =
        Attributes.defineAvaloniaPropertyWithEquality ColorSpectrum.MaxValueProperty

    let MinHue =
        Attributes.defineAvaloniaPropertyWithEquality ColorSpectrum.MinHueProperty

    let MinSaturation =
        Attributes.defineAvaloniaPropertyWithEquality ColorSpectrum.MinSaturationProperty

    let MinValue =
        Attributes.defineAvaloniaPropertyWithEquality ColorSpectrum.MinValueProperty

    let Shape =
        Attributes.defineAvaloniaPropertyWithEquality ColorSpectrum.ShapeProperty

[<AutoOpen>]
module ColorSpectrumBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ColorSpectrum widget.</summary>
        static member ColorSpectrum() =
            WidgetBuilder<'msg, IFabColorSpectrum>(ColorSpectrum.WidgetKey)

        /// <summary>Creates a ColorSpectrum widget.</summary>
        /// <param name="color">The Color value.</param>
        static member ColorSpectrum(color: Color) =
            WidgetBuilder<'msg, IFabColorSpectrum>(ColorSpectrum.WidgetKey, ColorSpectrum.Color.WithValue(color))

type ColorSpectrumModifiers =
    /// <summary>Link a ViewRef to access the direct ColorSpectrum control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabColorSpectrum>, value: ViewRef<ColorSpectrum>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    /// <summary>Set the Components property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Components value.</param>
    [<Extension>]
    static member inline components(this: WidgetBuilder<'msg, #IFabColorSpectrum>, value: ColorSpectrumComponents) =
        this.AddScalar(ColorSpectrum.Components.WithValue(value))

    /// <summary>Set the HsvColor property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HsvColor value.</param>
    [<Extension>]
    static member inline hsvColor(this: WidgetBuilder<'msg, #IFabColorSpectrum>, value: HsvColor) =
        this.AddScalar(ColorSpectrum.HsvColor.WithValue(value))

    /// <summary>Set the MaxHue property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MaxHue value.</param>
    [<Extension>]
    static member inline maxHue(this: WidgetBuilder<'msg, #IFabColorSpectrum>, value: int) =
        this.AddScalar(ColorSpectrum.MaxHue.WithValue(value))

    /// <summary>Set the MaxSaturation property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MaxSaturation value.</param>
    [<Extension>]
    static member inline maxSaturation(this: WidgetBuilder<'msg, #IFabColorView>, value: int) =
        this.AddScalar(ColorSpectrum.MaxSaturation.WithValue(value))

    /// <summary>Set the MaxValue property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MaxValue value.</param>
    [<Extension>]
    static member inline maxValue(this: WidgetBuilder<'msg, #IFabColorSpectrum>, value: int) =
        this.AddScalar(ColorSpectrum.MaxValue.WithValue(value))

    /// <summary>Set the MinHue property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MinHue value.</param>
    [<Extension>]
    static member inline minHue(this: WidgetBuilder<'msg, #IFabColorSpectrum>, value: int) =
        this.AddScalar(ColorSpectrum.MinHue.WithValue(value))

    /// <summary>Set the MinSaturation property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MinSaturation value.</param>
    [<Extension>]
    static member inline minSaturation(this: WidgetBuilder<'msg, #IFabColorSpectrum>, value: int) =
        this.AddScalar(ColorSpectrum.MinSaturation.WithValue(value))

    /// <summary>Set the MinValue property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MinValue value.</param>
    [<Extension>]
    static member inline minValue(this: WidgetBuilder<'msg, #IFabColorSpectrum>, value: int) =
        this.AddScalar(ColorSpectrum.MinValue.WithValue(value))

    /// <summary>Set the Shape property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Shape value.</param>
    [<Extension>]
    static member inline shape(this: WidgetBuilder<'msg, #IFabColorSpectrum>, value: ColorSpectrumShape) =
        this.AddScalar(ColorSpectrum.Shape.WithValue(value))
