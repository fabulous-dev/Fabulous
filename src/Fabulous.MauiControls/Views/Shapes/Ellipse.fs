namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Shapes

type IFabEllipse =
    inherit IFabShape

module Ellipse =
    let WidgetKey = Widgets.register<Ellipse>()

[<AutoOpen>]
module EllipseBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create an Ellipse widget</summary>
        static member inline Ellipse<'msg when 'msg: equality>() =
            WidgetBuilder<'msg, IFabEllipse>(Ellipse.WidgetKey, AttributesBundle(StackList.empty(), [||], [||], [||]))

[<Extension>]
type EllipseModifiers =
    /// <summary>Link a ViewRef to access the direct Ellipse control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabEllipse>, value: ViewRef<Ellipse>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
