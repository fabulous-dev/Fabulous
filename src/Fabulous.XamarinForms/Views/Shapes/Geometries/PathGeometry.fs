namespace Fabulous.XamarinForms

open System.Collections.Generic
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IPathGeometry =
    inherit IGeometry

module PathGeometry =
    let WidgetKey = Widgets.register<PathGeometry> ()

    let FiguresWidgets =
        Attributes.defineWidgetCollection
            "PathGeometry_FiguresWidgets"
            (fun target -> (target :?> PathGeometry).Figures :> IList<_>)

    let FiguresString =
        Attributes.define<string>
            "PathGeometry_FiguresString"
            (fun newValueOpt node ->
                let target = node.Target :?> BindableObject

                match newValueOpt with
                | ValueNone -> target.ClearValue(PathGeometry.FiguresProperty)
                | ValueSome value ->
                    target.SetValue(
                        PathGeometry.FiguresProperty,
                        PathFigureCollectionConverter()
                            .ConvertFromInvariantString(value)
                    ))

    let FillRule =
        Attributes.defineBindable<FillRule> PathGeometry.FillRuleProperty

[<AutoOpen>]
module PathGeometryBuilders =

    type Fabulous.XamarinForms.View with
        static member inline PathGeometry<'msg>(?fillRule: FillRule) =
            match fillRule with
            | None ->
                CollectionBuilder<'msg, IPathGeometry, IPathFigure>(PathGeometry.WidgetKey, PathGeometry.FiguresWidgets)
            | Some fillRule ->
                CollectionBuilder<'msg, IPathGeometry, IPathFigure>(
                    PathGeometry.WidgetKey,
                    PathGeometry.FiguresWidgets,
                    PathGeometry.FillRule.WithValue(fillRule)
                )

        static member inline PathGeometry<'msg>(content: string, ?fillRule: FillRule) =
            match fillRule with
            | None ->
                WidgetBuilder<'msg, IPathGeometry>(
                    PathGeometry.WidgetKey,
                    PathGeometry.FiguresString.WithValue(content)
                )
            | Some fillRule ->
                WidgetBuilder<'msg, IPathGeometry>(
                    PathGeometry.WidgetKey,
                    PathGeometry.FiguresString.WithValue(content),
                    PathGeometry.FillRule.WithValue(fillRule)
                )
