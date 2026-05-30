namespace Fabulous.Maui

open System
open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics

type IFabRoundRectangle =
    inherit IFabShape

module RoundRectangle =
    let WidgetKey = Widgets.register<RoundRectangle>()

    let CornerRadius =
        Attributes.defineBindableWithEquality<CornerRadius> RoundRectangle.CornerRadiusProperty

[<AutoOpen>]
module RoundRectangleBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a RoundRectangle widget with a corner radius</summary>
        /// <param name="cornerRadius">The corner radius</param>
        static member inline RoundRectangle<'msg when 'msg: equality>(cornerRadius: CornerRadius) =
            WidgetBuilder<'msg, IFabRoundRectangle>(RoundRectangle.WidgetKey, RoundRectangle.CornerRadius.WithValue(cornerRadius))

[<Extension>]
type RoundRectangleModifiers =
    /// <summary>Link a ViewRef to access the direct RoundRectangle control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabRoundRectangle>, value: ViewRef<RoundRectangle>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
