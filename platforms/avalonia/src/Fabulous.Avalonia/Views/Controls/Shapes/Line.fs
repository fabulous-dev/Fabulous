namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls.Shapes
open Fabulous

type IFabLine =
    inherit IFabShape

module Line =
    let WidgetKey = Widgets.register<Line>()

    let StartPoint =
        Attributes.defineAvaloniaPropertyWithEquality Line.StartPointProperty

    let EndPoint = Attributes.defineAvaloniaPropertyWithEquality Line.EndPointProperty

[<AutoOpen>]
module LineBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Line widget.</summary>
        /// <param name="starPoint">The start point of the line.</param>
        /// <param name="endPoint">The end point of the line.</param>
        static member Line(starPoint: Point, endPoint: Point) =
            WidgetBuilder<'msg, IFabLine>(Line.WidgetKey, Line.StartPoint.WithValue(starPoint), Line.EndPoint.WithValue(endPoint))


type LineModifiers =
    /// <summary>Link a ViewRef to access the direct Line control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabLine>, value: ViewRef<Line>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
