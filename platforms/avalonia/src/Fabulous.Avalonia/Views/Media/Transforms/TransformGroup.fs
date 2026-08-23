namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabTransformGroup =
    inherit IFabTransform

module TransformGroup =

    let WidgetKey = Widgets.register<TransformGroup>()

    let Children =
        Attributes.defineAvaloniaListWidgetCollection "TransformGroup_Children" (fun target -> (target :?> TransformGroup).Children)

[<AutoOpen>]
module TransformGroupBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TransformGroup widget.</summary>
        static member TransformGroup() =
            CollectionBuilder<'msg, IFabTransformGroup, IFabTransform>(TransformGroup.WidgetKey, TransformGroup.Children)

type TransformGroupCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabTransform>
        (_: CollectionBuilder<'msg, 'marker, IFabTransform>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabTransform>
        (_: CollectionBuilder<'msg, 'marker, IFabTransform>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

type TransformGroupModifiers =
    /// <summary>Link a ViewRef to access the direct TransformGroup control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTransformGroup>, value: ViewRef<TransformGroup>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
