namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IPathGeometry =
    inherit IGeometry

module PathGeometry =
    let WidgetKey = Widgets.register<PathGeometry> ()

    // FIXME Figures can be also used as a string using PathFigureCollectionConverter.
    // Should be just use PathSegment Widgets ?
    let Figures =
        Attributes.defineWidgetCollection "PathGeometry_Figures" (fun target -> (target :?> PathGeometry).Figures)

    let FillRule =
        Attributes.defineBindable<FillRule> PathGeometry.FillRuleProperty

[<AutoOpen>]
module PathGeometryBuilders =

    type Fabulous.XamarinForms.View with
        static member inline PathGeometry<'msg>(?fillRule: FillRule) =
            match fillRule with
            | None -> CollectionBuilder<'msg, IPathGeometry, IPathFigure>(PathGeometry.WidgetKey, PathGeometry.Figures)
            | Some fillRule ->
                CollectionBuilder<'msg, IPathGeometry, IPathFigure>(
                    PathGeometry.WidgetKey,
                    PathGeometry.Figures,
                    PathGeometry.FillRule.WithValue(fillRule)
                )
