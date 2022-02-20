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
