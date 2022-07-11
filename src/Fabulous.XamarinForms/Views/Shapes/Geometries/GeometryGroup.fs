namespace Fabulous.XamarinForms

open System.Collections.Generic
open Xamarin.Forms.Shapes
open Fabulous

type IGeometryGroup =
    inherit IGeometry

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
    type Fabulous.XamarinForms.View with
        static member inline GeometryGroup<'msg>(?fillRule: FillRule) =
            match fillRule with
            | None ->
                CollectionBuilder<'msg, IGeometryGroup, IGeometry>(GeometryGroup.WidgetKey, GeometryGroup.Children)
            | Some fillRule ->
                CollectionBuilder<'msg, IGeometryGroup, IGeometry>(
                    GeometryGroup.WidgetKey,
                    GeometryGroup.Children,
                    GeometryGroup.FillRule.WithValue(fillRule)
                )
