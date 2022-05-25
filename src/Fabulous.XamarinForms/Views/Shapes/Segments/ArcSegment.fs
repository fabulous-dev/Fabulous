namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IArcSegment =
    inherit IPathSegment

module ArcSegment =
    let WidgetKey = Widgets.register<ArcSegment>()

    let IsLargeArc =
        Attributes.defineBindableBool ArcSegment.IsLargeArcProperty

    let Point =
        Attributes.defineBindableWithEquality<Point> ArcSegment.SizeProperty

    let RotationAngle =
        Attributes.defineBindableFloat ArcSegment.RotationAngleProperty

    let Size =
        Attributes.defineBindableWithEquality<Size> ArcSegment.SizeProperty

    let SweepDirection =
        Attributes.defineBindableEnum<SweepDirection> ArcSegment.SweepDirectionProperty

[<AutoOpen>]
module ArcSegmentBuilders =

    type Fabulous.XamarinForms.View with
        static member inline ArcSegment<'msg>(point: Point, size: Size) =
            WidgetBuilder<'msg, IArcSegment>(
                ArcSegment.WidgetKey,
                ArcSegment.Point.WithValue(point),
                ArcSegment.Size.WithValue(size)
            )

[<Extension>]
type ArcSegmentModifiers =

    [<Extension>]
    static member inline rotationAngle(this: WidgetBuilder<'msg, #IArcSegment>, value: float) =
        this.AddScalar(ArcSegment.RotationAngle.WithValue(value))

    [<Extension>]
    static member inline sweepDirection(this: WidgetBuilder<'msg, #IArcSegment>, value: SweepDirection) =
        this.AddScalar(ArcSegment.SweepDirection.WithValue(value))

    [<Extension>]
    static member inline isLargeArc(this: WidgetBuilder<'msg, #IArcSegment>, value: bool) =
        this.AddScalar(ArcSegment.IsLargeArc.WithValue(value))
