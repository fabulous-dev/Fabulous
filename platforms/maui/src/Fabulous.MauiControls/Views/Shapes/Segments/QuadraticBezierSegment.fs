namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IFabQuadraticBezierSegment =
    inherit IFabPathSegment

module QuadraticBezierSegment =
    let WidgetKey = Widgets.register<QuadraticBezierSegment>()

    let Point1 =
        Attributes.defineBindableWithEquality<Point> QuadraticBezierSegment.Point1Property

    let Point2 =
        Attributes.defineBindableWithEquality<Point> QuadraticBezierSegment.Point2Property

[<AutoOpen>]
module QuadraticBezierSegmentBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a QuadraticBezierSegment with a list of points</summary>
        /// <param name="point1">The first point</param>
        /// <param name="point2">The second point</param>
        static member inline QuadraticBezierSegment<'msg when 'msg: equality>(point1: Point, point2: Point) =
            WidgetBuilder<'msg, IFabQuadraticBezierSegment>(
                QuadraticBezierSegment.WidgetKey,
                QuadraticBezierSegment.Point1.WithValue(point1),
                QuadraticBezierSegment.Point2.WithValue(point2)
            )

[<Extension>]
type QuadraticBezierSegmentModifiers =
    /// <summary>Link a ViewRef to access the direct QuadraticBezierSegment control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabQuadraticBezierSegment>, value: ViewRef<QuadraticBezierSegment>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
