namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IFabSolidColorBrush =
    inherit IFabBrush

module SolidColorBrush =
    let WidgetKey = Widgets.register<SolidColorBrush>()

    let Color = Attributes.defineBindableColor SolidColorBrush.ColorProperty

[<AutoOpen>]
module SolidColorBrushBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a SolidColorBrush widget, which paints an area with a solid color</summary>
        /// <param name="color">The color value</param>
        static member inline SolidColorBrush(color: Color) =
            WidgetBuilder<'msg, IFabSolidColorBrush>(SolidColorBrush.WidgetKey, SolidColorBrush.Color.WithValue(color))
