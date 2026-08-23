namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IFabBezierSegment =
    inherit IFabPathSegment

module BezierSegment =
    let WidgetKey = Widgets.register<BezierSegment>()

    let Point1 =
        Attributes.defineBindableWithEquality<Point> BezierSegment.Point1Property

    let Point2 =
        Attributes.defineBindableWithEquality<Point> BezierSegment.Point2Property

    let Point3 =
        Attributes.defineBindableWithEquality<Point> BezierSegment.Point3Property

[<AutoOpen>]
module BezierSegmentBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a BezierSegment with 3 points</summary>
        /// <param name="point1">The first point</param>
        /// <param name="point2">The second point</param>
        /// <param name="point3">The third point</param>
        static member inline BezierSegment<'msg when 'msg: equality>(point1: Point, point2: Point, point3: Point) =
            WidgetBuilder<'msg, IFabBezierSegment>(
                BezierSegment.WidgetKey,
                BezierSegment.Point1.WithValue(point1),
                BezierSegment.Point2.WithValue(point2),
                BezierSegment.Point3.WithValue(point3)
            )

[<Extension>]
type BezierSegmentModifiers =
    /// <summary>Link a ViewRef to access the direct ArcSegment control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabBezierSegment>, value: ViewRef<BezierSegment>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
