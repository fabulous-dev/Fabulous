namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Collections
open Avalonia.Controls
open Avalonia.Layout

open Fabulous

type IFabSlider =
    inherit IFabRangeBase

module Slider =
    let WidgetKey = Widgets.register<Slider>()

    let Orientation =
        Attributes.defineAvaloniaPropertyWithEquality Slider.OrientationProperty

    let IsDirectionReversed =
        Attributes.defineAvaloniaPropertyWithEquality Slider.IsDirectionReversedProperty

    let IsSnapToTickEnabled =
        Attributes.defineAvaloniaPropertyWithEquality Slider.IsSnapToTickEnabledProperty

    let TickFrequency =
        Attributes.defineAvaloniaPropertyWithEquality Slider.TickFrequencyProperty

    let TickPlacement =
        Attributes.defineAvaloniaPropertyWithEquality Slider.TickPlacementProperty

    let Ticks =
        Attributes.defineSimpleScalarWithEquality<float list> "Slider_Ticks" (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(Slider.TicksProperty)
            | ValueSome points ->
                let coll = AvaloniaList<float>()
                points |> List.iter coll.Add
                target.SetValue(Slider.TicksProperty, coll) |> ignore)

type SliderModifiers =
    /// <summary>Sets the Orientation property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Orientation value.</param>
    [<Extension>]
    static member inline orientation(this: WidgetBuilder<'msg, #IFabSlider>, value: Orientation) =
        this.AddScalar(Slider.Orientation.WithValue(value))

    /// <summary>Sets the IsDirectionReversed property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsDirectionReversed value.</param>
    [<Extension>]
    static member inline isDirectionReversed(this: WidgetBuilder<'msg, #IFabSlider>, value: bool) =
        this.AddScalar(Slider.IsDirectionReversed.WithValue(value))

    /// <summary>Sets the IsSnapToTickEnabled property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsSnapToTickEnabled value.</param>
    [<Extension>]
    static member inline isSnapToTickEnabled(this: WidgetBuilder<'msg, #IFabSlider>, value: bool) =
        this.AddScalar(Slider.IsSnapToTickEnabled.WithValue(value))

    /// <summary>Sets the TickFrequency property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TickFrequency value.</param>
    [<Extension>]
    static member inline tickFrequency(this: WidgetBuilder<'msg, #IFabSlider>, value: float) =
        this.AddScalar(Slider.TickFrequency.WithValue(value))

    /// <summary>Sets the TickPlacement property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TickPlacement value.</param>
    [<Extension>]
    static member inline tickPlacement(this: WidgetBuilder<'msg, #IFabSlider>, value: TickPlacement) =
        this.AddScalar(Slider.TickPlacement.WithValue(value))

    /// <summary>Sets the Ticks property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Ticks value.</param>
    [<Extension>]
    static member inline ticks(this: WidgetBuilder<'msg, #IFabSlider>, value: float list) =
        this.AddScalar(Slider.Ticks.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Slider control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabSlider>, value: ViewRef<Slider>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
