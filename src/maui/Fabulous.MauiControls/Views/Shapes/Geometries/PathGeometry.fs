namespace Fabulous.Maui

open System.Collections.Generic
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Shapes

type IFabPathGeometry =
    inherit IFabGeometry

module PathGeometry =
    let WidgetKey = Widgets.register<PathGeometry>()

    let FillRule = Attributes.defineBindableEnum<FillRule> PathGeometry.FillRuleProperty

    let FiguresWidgets =
        Attributes.defineListWidgetCollection "PathGeometry_FiguresWidgets" (fun target -> (target :?> PathGeometry).Figures :> IList<_>)

    let FiguresString =
        Attributes.defineSimpleScalarWithEquality<string> "PathGeometry_FiguresString" (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(PathGeometry.FiguresProperty)
            | ValueSome value -> target.SetValue(PathGeometry.FiguresProperty, PathFigureCollectionConverter().ConvertFromInvariantString(value)))

[<AutoOpen>]
module PathGeometryBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a PathGeometry widget</summary>
        static member inline PathGeometry<'msg when 'msg: equality>() =
            CollectionBuilder<'msg, IFabPathGeometry, IFabPathFigure>(PathGeometry.WidgetKey, PathGeometry.FiguresWidgets)

        /// <summary>Create a PathGeometry widget with the fill rule</summary>
        /// <param name="fillRule">The fill rule</param>
        static member inline PathGeometry<'msg when 'msg: equality>(fillRule: FillRule) =
            CollectionBuilder<'msg, IFabPathGeometry, IFabPathFigure>(
                PathGeometry.WidgetKey,
                PathGeometry.FiguresWidgets,
                PathGeometry.FillRule.WithValue(fillRule)
            )

        /// <summary>Create a PathGeometry widget with a figure data string and a fill rule</summary>
        /// <param name="figures">The figure data string</param>
        static member inline PathGeometry<'msg when 'msg: equality>(figures: string) =
            WidgetBuilder<'msg, IFabPathGeometry>(PathGeometry.WidgetKey, PathGeometry.FiguresString.WithValue(figures))

        /// <summary>Create a PathGeometry widget with a figure data string and a fill rule</summary>
        /// <param name="figures">The figure data string</param>
        /// <param name="fillRule">The fill rule</param>
        static member inline PathGeometry<'msg when 'msg: equality>(figures: string, fillRule: FillRule) =
            WidgetBuilder<'msg, IFabPathGeometry>(
                PathGeometry.WidgetKey,
                PathGeometry.FiguresString.WithValue(figures),
                PathGeometry.FillRule.WithValue(fillRule)
            )

[<Extension>]
type PathGeometryModifiers =
    /// <summary>Link a ViewRef to access the direct PathGeometry control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPathGeometry>, value: ViewRef<PathGeometry>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type PathGeometryYieldExtensions =
    [<Extension>]
    static member inline Yield(_: CollectionBuilder<'msg, #IFabPathGeometry, IFabPathFigure>, x: WidgetBuilder<'msg, #IFabPathFigure>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (
            _: CollectionBuilder<'msg, #IFabPathGeometry, IFabPathFigure>,
            x: WidgetBuilder<'msg, Memo.Memoized<#IFabPathFigure>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
