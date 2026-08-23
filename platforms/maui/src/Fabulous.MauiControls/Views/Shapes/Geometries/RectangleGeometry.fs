namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IFabRectangleGeometry =
    inherit IFabGeometry

module RectangleGeometry =
    let WidgetKey = Widgets.register<RectangleGeometry>()

    let Rect =
        Attributes.defineBindableWithEquality<Rect> RectangleGeometry.RectProperty

[<AutoOpen>]
module RectangleGeometryBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a RectangleGeometry widget with a dimension</summary>
        /// <param name="rect">The dimension value</param>
        static member inline RectangleGeometry<'msg when 'msg: equality>(rect: Rect) =
            WidgetBuilder<'msg, IFabRectangleGeometry>(RectangleGeometry.WidgetKey, RectangleGeometry.Rect.WithValue(rect))

[<Extension>]
type RectangleGeometryModifiers =
    /// <summary>Link a ViewRef to access the direct RectangleGeometry control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabRectangleGeometry>, value: ViewRef<RectangleGeometry>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
