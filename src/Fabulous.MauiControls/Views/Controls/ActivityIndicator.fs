namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IFabActivityIndicator =
    inherit IFabView

module ActivityIndicator =
    let WidgetKey = Widgets.register<ActivityIndicator>()

    let Color = Attributes.defineBindableColor ActivityIndicator.ColorProperty

    let IsRunning = Attributes.defineBindableBool ActivityIndicator.IsRunningProperty

[<AutoOpen>]
module ActivityIndicatorBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create an ActivityIndicator widget with a running state</summary>
        /// <param name="isRunning">The running state</param>
        static member inline ActivityIndicator<'msg when 'msg: equality>(isRunning: bool) =
            WidgetBuilder<'msg, IFabActivityIndicator>(ActivityIndicator.WidgetKey, ActivityIndicator.IsRunning.WithValue(isRunning))

[<Extension>]
type ActivityIndicatorModifiers =
    /// <summary>Set the activity indicator color</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the activity indicator</param>
    [<Extension>]
    static member inline color(this: WidgetBuilder<'msg, #IFabActivityIndicator>, value: Color) =
        this.AddScalar(ActivityIndicator.Color.WithValue(value))

    /// <summary>Link a ViewRef to access the direct ActivityIndicator control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabActivityIndicator>, value: ViewRef<ActivityIndicator>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
