namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Fabulous

type IFabSector =
    inherit IFabShape

module Sector =
    let WidgetKey = Widgets.register<Sector>()

    let StartAngle =
        Attributes.defineAvaloniaPropertyWithEquality Sector.StartAngleProperty

    let SweepAngle =
        Attributes.defineAvaloniaPropertyWithEquality Sector.SweepAngleProperty

[<AutoOpen>]
module SectorBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Sector widget.</summary>
        /// <param name="startAngle">The starting angle.</param>
        /// <param name="sweepAngle">The sweep angle.</param>
        static member Sector(startAngle: float, sweepAngle: float) =
            WidgetBuilder<'msg, IFabSector>(Sector.WidgetKey, Sector.StartAngle.WithValue(startAngle), Sector.SweepAngle.WithValue(sweepAngle))

type SectorModifiers =
    /// <summary>Link a ViewRef to access the direct Sector control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabSector>, value: ViewRef<Sector>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
