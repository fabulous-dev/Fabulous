namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabEllipse =
    inherit IFabShape

module Ellipse =
    let WidgetKey = Widgets.register<Ellipse>()

[<AutoOpen>]
module EllipseBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates an Ellipse widget.</summary>
        static member Ellipse() =
            WidgetBuilder<'msg, IFabEllipse>(Ellipse.WidgetKey)

type EllipseModifiers =
    /// <summary>Link a ViewRef to access the direct Ellipse control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabEllipse>, value: ViewRef<Ellipse>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
