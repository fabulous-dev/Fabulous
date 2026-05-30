namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IFabLineSegment =
    inherit IFabPathSegment

module LineSegment =
    let WidgetKey = Widgets.register<LineSegment>()

    let Point = Attributes.defineBindableWithEquality<Point> LineSegment.PointProperty

[<AutoOpen>]
module LineSegmentBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a LineSegment widget with a start and end point</summary>
        /// <param name="point">The start and end point</param>
        static member inline LineSegment<'msg when 'msg: equality>(point: Point) =
            WidgetBuilder<'msg, IFabLineSegment>(LineSegment.WidgetKey, LineSegment.Point.WithValue(point))

[<Extension>]
type LineSegmentModifiers =
    /// <summary>Link a ViewRef to access the direct LineSegment control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabLineSegment>, value: ViewRef<LineSegment>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
