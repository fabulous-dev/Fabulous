namespace Fabulous.Maui

open System.Collections.Generic
open Microsoft.Maui.Controls.Shapes
open Fabulous

type IGeometryGroup =
    inherit Fabulous.Maui.IGeometry

module GeometryGroup =

    let WidgetKey = Widgets.register<GeometryGroup>()

    let Children =
        Attributes.defineListWidgetCollection
            "GeometryGroup_Children"
            (fun target -> (target :?> GeometryGroup).Children :> IList<_>)

    let FillRule =
        Attributes.defineBindableEnum<FillRule> GeometryGroup.FillRuleProperty

[<AutoOpen>]
module GeometryGroupBuilders =
    type Fabulous.Maui.View with
        static member inline GeometryGroup<'msg>(?fillRule: FillRule) =
            match fillRule with
            | None ->
                CollectionBuilder<'msg, IGeometryGroup, Fabulous.Maui.IGeometry>(GeometryGroup.WidgetKey, GeometryGroup.Children)
            | Some fillRule ->
                CollectionBuilder<'msg, IGeometryGroup, Fabulous.Maui.IGeometry>(
                    GeometryGroup.WidgetKey,
                    GeometryGroup.Children,
                    GeometryGroup.FillRule.WithValue(fillRule)
                )
