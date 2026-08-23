namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Collections
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous

type IFabTickBar =
    inherit IFabControl

module TickBar =
    let WidgetKey = Widgets.register<TickBar>()

    let FillWidget = Attributes.defineAvaloniaPropertyWidget TickBar.FillProperty

    let Fill = Attributes.defineAvaloniaPropertyWithEquality TickBar.FillProperty

    let Minimum = Attributes.defineAvaloniaPropertyWithEquality TickBar.MinimumProperty

    let Maximum = Attributes.defineAvaloniaPropertyWithEquality TickBar.MaximumProperty

    let TickFrequency =
        Attributes.defineAvaloniaPropertyWithEquality TickBar.TickFrequencyProperty

    let Orientation =
        Attributes.defineAvaloniaPropertyWithEquality TickBar.OrientationProperty

    let Ticks =
        Attributes.defineSimpleScalarWithEquality<float list> "TickBar_Ticks" (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(TickBar.TicksProperty)
            | ValueSome points ->
                let coll = AvaloniaList<float>()
                points |> List.iter coll.Add
                target.SetValue(TickBar.TicksProperty, coll) |> ignore)

    let IsDirectionReversed =
        Attributes.defineAvaloniaPropertyWithEquality TickBar.IsDirectionReversedProperty

    let Placement =
        Attributes.defineAvaloniaPropertyWithEquality TickBar.PlacementProperty

    let ReservedSpace =
        Attributes.defineAvaloniaPropertyWithEquality TickBar.ReservedSpaceProperty

[<AutoOpen>]
module TickBarBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TickBar widget.</summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        static member TickBar(min: float, max: float) =
            WidgetBuilder<'msg, IFabTickBar>(TickBar.WidgetKey, TickBar.Minimum.WithValue(min), TickBar.Maximum.WithValue(max))

type TickBarModifiers =
    /// <summary>Sets the Fill property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Fill value.</param>
    [<Extension>]
    static member inline fill(this: WidgetBuilder<'msg, #IFabTickBar>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TickBar.FillWidget.WithValue(value.Compile()))

    /// <summary>Sets the Fill property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Fill value.</param>
    [<Extension>]
    static member inline fill(this: WidgetBuilder<'msg, #IFabTickBar>, value: IBrush) =
        this.AddScalar(TickBar.Fill.WithValue(value))

    /// <summary>Sets the Fill property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Fill value.</param>
    [<Extension>]
    static member inline fill(this: WidgetBuilder<'msg, #IFabTickBar>, value: Color) =
        TickBarModifiers.fill(this, View.SolidColorBrush(value))

    /// <summary>Sets the Fill property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Fill value.</param>
    [<Extension>]
    static member inline fill(this: WidgetBuilder<'msg, #IFabTickBar>, value: string) =
        TickBarModifiers.fill(this, View.SolidColorBrush(value))

    /// <summary>Sets the TickFrequency property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TickFrequency value.</param>
    [<Extension>]
    static member inline tickFrequency(this: WidgetBuilder<'msg, #IFabTickBar>, value: float) =
        this.AddScalar(TickBar.TickFrequency.WithValue(value))

    /// <summary>Sets the Orientation property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Orientation value.</param>
    [<Extension>]
    static member inline orientation(this: WidgetBuilder<'msg, #IFabTickBar>, value: Orientation) =
        this.AddScalar(TickBar.Orientation.WithValue(value))

    /// <summary>Sets the Ticks property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Ticks value.</param>
    [<Extension>]
    static member inline ticks(this: WidgetBuilder<'msg, #IFabTickBar>, value: float list) =
        this.AddScalar(TickBar.Ticks.WithValue(value))

    /// <summary>Sets the IsDirectionReversed property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsDirectionReversed value.</param>
    [<Extension>]
    static member inline isDirectionReversed(this: WidgetBuilder<'msg, #IFabTickBar>, value: bool) =
        this.AddScalar(TickBar.IsDirectionReversed.WithValue(value))

    /// <summary>Sets the Placement property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Placement value.</param>
    [<Extension>]
    static member inline placement(this: WidgetBuilder<'msg, #IFabTickBar>, value: TickBarPlacement) =
        this.AddScalar(TickBar.Placement.WithValue(value))

    /// <summary>Sets the ReservedSpace property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ReservedSpace value.</param>
    [<Extension>]
    static member inline reservedSpace(this: WidgetBuilder<'msg, #IFabTickBar>, value: Rect) =
        this.AddScalar(TickBar.ReservedSpace.WithValue(value))

    /// <summary>Link a ViewRef to access the direct TickBar control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTickBar>, value: ViewRef<TickBar>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
