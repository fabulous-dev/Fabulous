namespace Fabulous.Maui

open System
open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IFabRoundRectangleGeometry =
    inherit IFabGeometryGroup

module RoundRectangleGeometry =
    let WidgetKey = Widgets.register<RoundRectangleGeometry>()

    let CornerRadius =
        Attributes.defineBindableWithEquality<CornerRadius> RoundRectangleGeometry.CornerRadiusProperty

    let FillRule =
        Attributes.defineBindableEnum<FillRule> RoundRectangleGeometry.FillRuleProperty

    let Rect =
        Attributes.defineBindableWithEquality<Rect> RoundRectangleGeometry.RectProperty

[<AutoOpen>]
module RoundRectangleGeometryBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a RoundRectangleGeometry widget with a corner radius and a dimension</summary>
        /// <param name="cornerRadius">The corner radius</param>
        /// <param name="rect">The dimension</param>
        static member inline RoundRectangleGeometry<'msg when 'msg: equality>(cornerRadius: CornerRadius, rect: Rect) =
            WidgetBuilder<'msg, IFabRoundRectangleGeometry>(
                RoundRectangleGeometry.WidgetKey,
                RoundRectangleGeometry.CornerRadius.WithValue(cornerRadius),
                RoundRectangleGeometry.Rect.WithValue(rect)
            )

[<Extension>]
type RoundRectangleGeometryModifiers =
    /// <summary>Set the fill rule</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The fill rule</param>
    [<Extension>]
    static member inline fillRule(this: WidgetBuilder<'msg, #IFabRoundRectangleGeometry>, value: FillRule) =
        this.AddScalar(RoundRectangleGeometry.FillRule.WithValue(value))

    /// <summary>Link a ViewRef to access the direct RoundRectangleGeometry control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabRoundRectangleGeometry>, value: ViewRef<RoundRectangleGeometry>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
