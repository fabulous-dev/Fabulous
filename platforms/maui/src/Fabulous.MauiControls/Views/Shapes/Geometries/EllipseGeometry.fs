namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IFabEllipseGeometry =
    inherit IFabGeometry

module EllipseGeometry =
    let WidgetKey = Widgets.register<EllipseGeometry>()

    let Center =
        Attributes.defineBindableWithEquality<Point> EllipseGeometry.CenterProperty

    let RadiusX = Attributes.defineBindableFloat EllipseGeometry.RadiusXProperty

    let RadiusY = Attributes.defineBindableFloat EllipseGeometry.RadiusYProperty

[<AutoOpen>]
module EllipseGeometryBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a EllipseGeometry widget with a center point and a radius</summary>
        /// <param name="center">The center point</param>
        /// <param name="radiusX">The X component of the radius</param>
        /// <param name="radiusY">The Y component of the radius</param>
        static member inline EllipseGeometry<'msg when 'msg: equality>(center: Point, radiusX: float, radiusY: float) =
            WidgetBuilder<'msg, IFabEllipseGeometry>(
                EllipseGeometry.WidgetKey,
                EllipseGeometry.Center.WithValue(center),
                EllipseGeometry.RadiusX.WithValue(radiusX),
                EllipseGeometry.RadiusY.WithValue(radiusY)
            )

[<Extension>]
type EllipseGeometryModifiers =
    /// <summary>Link a ViewRef to access the direct EllipseGeometry control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabEllipseGeometry>, value: ViewRef<EllipseGeometry>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
