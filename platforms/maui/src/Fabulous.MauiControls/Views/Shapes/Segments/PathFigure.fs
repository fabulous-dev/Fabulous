namespace Fabulous.Maui

open System.Collections.Generic
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IFabPathFigure =
    inherit IFabElement

module PathFigure =
    let WidgetKey = Widgets.register<PathFigure>()

    let IsClosed = Attributes.defineBindableBool PathFigure.IsClosedProperty

    let IsFilled = Attributes.defineBindableBool PathFigure.IsFilledProperty

    let Segments =
        Attributes.defineListWidgetCollection "PathGeometry_Segments" (fun target -> (target :?> PathFigure).Segments :> IList<_>)

    let StartPoint =
        Attributes.defineBindableWithEquality<Point> PathFigure.StartPointProperty

[<AutoOpen>]
module PathFigureBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a PathFigure widget</summary>
        static member inline PathFigure<'msg when 'msg: equality>() =
            CollectionBuilder<'msg, IFabPathFigure, IFabPathSegment>(PathFigure.WidgetKey, PathFigure.Segments)

        /// <summary>Create a PathFigure widget with a start point</summary>
        /// <param name="startPoint">The start point</param>
        static member inline PathFigure<'msg when 'msg: equality>(startPoint: Point) =
            CollectionBuilder<'msg, IFabPathFigure, IFabPathSegment>(PathFigure.WidgetKey, PathFigure.Segments, PathFigure.StartPoint.WithValue(startPoint))

[<Extension>]
type PathFigureModifiers =
    /// <summary>Set whether the figure is closed or not</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value indicating whether the figure is closed or not</param>
    [<Extension>]
    static member inline isClosed(this: WidgetBuilder<'msg, #IFabPathFigure>, value: bool) =
        this.AddScalar(PathFigure.IsClosed.WithValue(value))

    /// <summary>Set whether the figure is filled or not</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value indicating whether the figure is filled or not</param>
    [<Extension>]
    static member inline isFilled(this: WidgetBuilder<'msg, #IFabPathFigure>, value: bool) =
        this.AddScalar(PathFigure.IsFilled.WithValue(value))

    /// <summary>Link a ViewRef to access the direct PathFigure control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPathFigure>, value: ViewRef<PathFigure>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type PathFigureYieldExtensions =
    [<Extension>]
    static member inline Yield(_: CollectionBuilder<'msg, #IFabPathFigure, IFabPathSegment>, x: WidgetBuilder<'msg, #IFabPathSegment>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (
            _: CollectionBuilder<'msg, #IFabPathFigure, IFabPathSegment>,
            x: WidgetBuilder<'msg, Memo.Memoized<#IFabPathSegment>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
