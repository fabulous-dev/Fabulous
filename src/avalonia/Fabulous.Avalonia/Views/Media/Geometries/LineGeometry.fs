namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabLineGeometry =
    inherit IFabGeometry

module LineGeometry =
    let WidgetKey = Widgets.register<LineGeometry>()

    let StartPoint =
        Attributes.defineAvaloniaPropertyWithEquality LineGeometry.StartPointProperty

    let EndPoint =
        Attributes.defineAvaloniaPropertyWithEquality LineGeometry.EndPointProperty

[<AutoOpen>]
module ComponentLineGeometryBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a LineGeometry widget.</summary>
        /// <param name="startPoint">The start point of the line.</param>
        /// <param name="endPoint">The end point of the line.</param>
        static member LineGeometry(startPoint: Point, endPoint: Point) =
            WidgetBuilder<'msg, IFabLineGeometry>(
                LineGeometry.WidgetKey,
                LineGeometry.StartPoint.WithValue(startPoint),
                LineGeometry.EndPoint.WithValue(endPoint)
            )

type LineGeometryModifiers =

    /// <summary>Link a ViewRef to access the direct LineGeometry control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabLineGeometry>, value: ViewRef<LineGeometry>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
