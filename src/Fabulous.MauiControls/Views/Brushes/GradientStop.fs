namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui.Controls

open Fabulous
open Microsoft.Maui.Graphics

type IFabGradientStop =
    inherit IFabElement

module GradientStop =
    let WidgetKey = Widgets.register<GradientStop>()

    let Color = Attributes.defineBindableColor GradientStop.ColorProperty

    let Offset = Attributes.defineBindableFloat GradientStop.OffsetProperty

[<AutoOpen>]
module GradientStopBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a GradientStop widget with an offset position and a color</summary>
        /// <param name="offset">The offset value</param>
        /// <param name="color">The color value</param>
        static member inline GradientStop(offset: float, color: Color) =
            WidgetBuilder<'msg, IFabGradientStop>(GradientStop.WidgetKey, GradientStop.Offset.WithValue(offset), GradientStop.Color.WithValue(color))

[<Extension>]
type GradientStopModifiers =
    /// <summary>Link a ViewRef to access the direct GradientStop control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabGradientStop>, value: ViewRef<GradientStop>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
