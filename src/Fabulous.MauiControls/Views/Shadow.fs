namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IShadow =
    inherit Fabulous.Maui.IElement

module Shadow =
    let WidgetKey = Widgets.register<Shadow>()

    let Radius =
        Attributes.defineBindableFloat Shadow.RadiusProperty

    let Opacity =
        Attributes.defineBindableFloat Shadow.OffsetProperty

    let Brush =
        Attributes.defineBindableWithEquality<Brush> Shadow.BrushProperty

    let Offset =
        Attributes.defineBindableWithEquality<Point> Shadow.OffsetProperty

[<AutoOpen>]
module ShadowBuilders =
    type Fabulous.Maui.View with
        /// <summary>Create a Shadow widget, that enables a shadow to be added to any layout or view.</summary>
        /// <param name="brush">Brush, of type Brush, represents the brush used to colorize the shadow.</param>
        /// <param name="offset">OffSet, of type Point, specifies the offset for the shadow, which represents the position of the light source that creates the shadow.</param>
        static member inline Shadow(brush: Brush, offset: Point) =
            WidgetBuilder<'msg, IShadow>(
                Shadow.WidgetKey,
                Shadow.Brush.WithValue(brush),
                Shadow.Offset.WithValue(offset)
            )

[<Extension>]
type ShadowModifiers =
    /// <summary>Opacity, of type float, indicates the opacity of the shadow. The default value of this property is 1.</summary>
    [<Extension>]
    static member inline opacity(this: WidgetBuilder<'msg, #IShadow>, value: float) =
        this.AddScalar(Shadow.Opacity.WithValue(value))

    /// <summary>Radius, of type float, defines the radius of the blur used to generate the shadow. The default value of this property is 10.</summary>
    [<Extension>]
    static member inline radius(this: WidgetBuilder<'msg, #IShadow>, value: float) =
        this.AddScalar(Shadow.Radius.WithValue(value))
