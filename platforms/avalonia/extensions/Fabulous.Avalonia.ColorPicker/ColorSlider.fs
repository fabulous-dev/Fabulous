namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabColorSlider =
    inherit IFabSlider

module ColorSlider =
    let WidgetKey = Widgets.register<ColorSlider>()

    let Color = Attributes.defineAvaloniaPropertyWithEquality ColorSlider.ColorProperty

    let ColorComponent =
        Attributes.defineAvaloniaPropertyWithEquality ColorSlider.ColorComponentProperty

    let ColorModel =
        Attributes.defineAvaloniaPropertyWithEquality ColorSlider.ColorModelProperty

    let HsvColor =
        Attributes.defineAvaloniaPropertyWithEquality ColorSlider.HsvColorProperty

    let IsAlphaVisible =
        Attributes.defineAvaloniaPropertyWithEquality ColorSlider.IsAlphaVisibleProperty

    let IsPerceptive =
        Attributes.defineAvaloniaPropertyWithEquality ColorSlider.IsPerceptiveProperty

    let IsRoundingEnabled =
        Attributes.defineAvaloniaPropertyWithEquality ColorSlider.IsRoundingEnabledProperty

[<AutoOpen>]
module ColorSliderBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ColorSlider widget.</summary>
        static member ColorSlider() =
            WidgetBuilder<'msg, IFabColorSlider>(ColorSlider.WidgetKey)

        /// <summary>Creates a ColorSlider widget.</summary>
        /// <param name="color">The Color value.</param>
        static member ColorSlider(color: Color) =
            WidgetBuilder<'msg, IFabColorSlider>(ColorSlider.WidgetKey, ColorSlider.Color.WithValue(color))

type ColorSliderModifiers =
    /// <summary>Link a ViewRef to access the direct ColorSlider control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabColorSlider>, value: ViewRef<ColorSlider>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    /// <summary>Set the Components property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Components value.</param>
    [<Extension>]
    static member inline colorComponent(this: WidgetBuilder<'msg, #IFabColorSlider>, value: ColorComponent) =
        this.AddScalar(ColorSlider.ColorComponent.WithValue(value))

    /// <summary>Set the ColorModel property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Components value.</param>
    [<Extension>]
    static member inline colorModel(this: WidgetBuilder<'msg, #IFabColorSlider>, value: ColorModel) =
        this.AddScalar(ColorSlider.ColorModel.WithValue(value))

    /// <summary>Set the HsvColor property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HsvColor value.</param>
    [<Extension>]
    static member inline hsvColor(this: WidgetBuilder<'msg, #IFabColorSlider>, value: HsvColor) =
        this.AddScalar(ColorSlider.HsvColor.WithValue(value))

    /// <summary>Set the IsAlphaVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsAlphaVisible value.</param>
    [<Extension>]
    static member inline isAlphaVisible(this: WidgetBuilder<'msg, #IFabColorSlider>, value: bool) =
        this.AddScalar(ColorSlider.IsAlphaVisible.WithValue(value))

    /// <summary>Set the IsPerceptive property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsPerceptive value.</param>
    [<Extension>]
    static member inline isPerceptive(this: WidgetBuilder<'msg, #IFabColorSlider>, value: bool) =
        this.AddScalar(ColorSlider.IsPerceptive.WithValue(value))

    /// <summary>Set the IsRoundingEnabled property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsRoundingEnabled value.</param>
    [<Extension>]
    static member inline isRoundingEnabled(this: WidgetBuilder<'msg, #IFabColorSlider>, value: bool) =
        this.AddScalar(ColorSlider.IsRoundingEnabled.WithValue(value))
