namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Xamarin.Forms.Shapes
open Fabulous
open Fabulous.XamarinForms

type IGeometryGroup =
    inherit IGeometry

module GeometryGroup =

    let WidgetKey = Widgets.register<GeometryGroup> ()

    let Children =
        Attributes.defineWidgetCollection "GeometryGroup_Children" (fun target -> (target :?> GeometryGroup).Children)

    let FillRule =
        Attributes.defineBindable<FillRule> GeometryGroup.FillRuleProperty

[<AutoOpen>]
module GeometryGroupBuilders =
    type Fabulous.XamarinForms.View with
        static member inline GeometryGroup<'msg>() =
            CollectionBuilder<'msg, IGeometryGroup, IGeometry>(
                GeometryGroup.WidgetKey,
                GeometryGroup.Children
            )

[<Extension>]
type GeometryGroupModifiers =

    [<Extension>]
    static member inline fillRule(this: WidgetBuilder<'msg, #IGeometryGroup>, value: FillRule) =
        this.AddScalar(GeometryGroup.FillRule.WithValue(value))
