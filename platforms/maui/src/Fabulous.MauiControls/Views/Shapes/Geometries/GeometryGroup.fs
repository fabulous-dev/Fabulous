namespace Fabulous.Maui

open System.Collections.Generic
open System.Runtime.CompilerServices
open Fabulous.StackAllocatedCollections
open Microsoft.Maui.Controls.Shapes
open Fabulous

type IFabGeometryGroup =
    inherit IFabGeometry

module GeometryGroup =
    let WidgetKey = Widgets.register<GeometryGroup>()

    let Children =
        Attributes.defineListWidgetCollection "GeometryGroup_Children" (fun target -> (target :?> GeometryGroup).Children :> IList<_>)

    let FillRule =
        Attributes.defineBindableEnum<FillRule> GeometryGroup.FillRuleProperty

[<AutoOpen>]
module GeometryGroupBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a GeometryGroup</summary>
        static member inline GeometryGroup<'msg when 'msg: equality>() =
            CollectionBuilder<'msg, IFabGeometryGroup, IFabGeometry>(GeometryGroup.WidgetKey, GeometryGroup.Children)

        /// <summary>Create a GeometryGroup with a fill rule</summary>
        /// <param name="fillRule">The fill rule</param>
        static member inline GeometryGroup<'msg when 'msg: equality>(fillRule: FillRule) =
            CollectionBuilder<'msg, IFabGeometryGroup, IFabGeometry>(
                GeometryGroup.WidgetKey,
                GeometryGroup.Children,
                GeometryGroup.FillRule.WithValue(fillRule)
            )

[<Extension>]
type GeometryGroupModifiers =
    /// <summary>Link a ViewRef to access the direct GeometryGroup control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabGeometryGroup>, value: ViewRef<GeometryGroup>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type GeometryGroupYieldExtensions =
    [<Extension>]
    static member inline Yield(_: CollectionBuilder<'msg, #IFabGeometryGroup, IFabGeometry>, x: WidgetBuilder<'msg, #IFabGeometry>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (
            _: CollectionBuilder<'msg, #IFabGeometryGroup, IFabGeometry>,
            x: WidgetBuilder<'msg, Memo.Memoized<#IFabGeometry>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
