namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IFabLineGeometry =
    inherit IFabGeometry

module LineGeometry =
    let WidgetKey = Widgets.register<LineGeometry>()

    let EndPoint =
        Attributes.defineBindableWithEquality<Point> LineGeometry.EndPointProperty

    let StartPoint =
        Attributes.defineBindableWithEquality<Point> LineGeometry.StartPointProperty

[<AutoOpen>]
module LineGeometryBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a LineGeometry widget with a start point and an end point</summary>
        /// <param name="startPoint">The start point</param>
        /// <param name="endPoint">The end point</param>
        static member inline LineGeometry<'msg when 'msg: equality>(startPoint: Point, endPoint: Point) =
            WidgetBuilder<'msg, IFabLineGeometry>(
                LineGeometry.WidgetKey,
                LineGeometry.StartPoint.WithValue(startPoint),
                LineGeometry.EndPoint.WithValue(endPoint)
            )

[<Extension>]
type LineGeometryModifiers =
    /// <summary>Link a ViewRef to access the direct LineGeometry control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabLineGeometry>, value: ViewRef<LineGeometry>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
