namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabGeometryGroup =
    inherit IFabGeometry

module GeometryGroup =
    let WidgetKey = Widgets.register<GeometryGroup>()

    let Children =
        Attributes.defineAvaloniaListWidgetCollection "GeometryGroup_Children" (fun target -> (target :?> GeometryGroup).Children)

    let FillRule =
        Attributes.defineAvaloniaPropertyWithEquality GeometryGroup.FillRuleProperty

[<AutoOpen>]
module GeometryGroupBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a GeometryGroup widget.</summary>
        /// <param name="fillRule">The fill rule to apply to the geometry group.</param>
        static member GeometryGroup(fillRule: FillRule) =
            CollectionBuilder<'msg, IFabGeometryGroup, IFabGeometry>(
                GeometryGroup.WidgetKey,
                GeometryGroup.Children,
                GeometryGroup.FillRule.WithValue(fillRule)
            )

type GeometryGroupCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabGeometry>
        (_: CollectionBuilder<'msg, 'marker, IFabGeometry>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabGeometry>
        (_: CollectionBuilder<'msg, 'marker, IFabGeometry>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

type GeometryGroupModifiers =

    /// <summary>Link a ViewRef to access the direct GeometryGroup control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabGeometryGroup>, value: ViewRef<GeometryGroup>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
