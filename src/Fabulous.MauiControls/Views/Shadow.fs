namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IFabShadow =
    inherit IFabElement

module Shadow =
    let WidgetKey = Widgets.register<Shadow>()

    let Radius = Attributes.defineBindableFloat Shadow.RadiusProperty

    let Opacity = Attributes.defineBindableFloat Shadow.OffsetProperty

    let Brush = Attributes.defineBindableWithEquality<Brush> Shadow.BrushProperty

    let Offset = Attributes.defineBindableWithEquality<Point> Shadow.OffsetProperty

[<AutoOpen>]
module ShadowBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a Shadow widget with a brush and an offset</summary>
        /// <param name="brush">Brush, of type Brush, represents the brush used to colorize the shadow</param>
        /// <param name="offset">OffSet, of type Point, specifies the offset for the shadow, which represents the position of the light source that creates the shadow</param>
        static member inline Shadow(brush: Brush, offset: Point) =
            WidgetBuilder<'msg, IFabShadow>(Shadow.WidgetKey, Shadow.Brush.WithValue(brush), Shadow.Offset.WithValue(offset))

[<Extension>]
type ShadowModifiers =
    /// <summary>Set the opacity value applied to the widget when it is rendered</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The opacity value. Values will be clamped between 0 and 1</param>
    [<Extension>]
    static member inline opacity(this: WidgetBuilder<'msg, #IFabShadow>, value: float) =
        this.AddScalar(Shadow.Opacity.WithValue(value))

    /// <summary>Set the radius of the blur used to generate the shadow</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The blur radius value</param>
    [<Extension>]
    static member inline blurRadius(this: WidgetBuilder<'msg, #IFabShadow>, value: float) =
        this.AddScalar(Shadow.Radius.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Shadow control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabShadow>, value: ViewRef<Shadow>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
