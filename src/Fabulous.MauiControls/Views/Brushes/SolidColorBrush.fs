namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type ISolidColorBrush =
    inherit IBrush

module SolidColorBrush =

    let WidgetKey = Widgets.register<SolidColorBrush>()

    let Color =
        Attributes.defineBindableAppTheme SolidColorBrush.ColorProperty

[<AutoOpen>]
module SolidColorBrushBuilders =
    type Fabulous.Maui.View with
        /// <summary>SolidColorBrush, which paints an area with a solid color. For more information, see Solid color brushes.</summary>
        /// <param name="light">The color in light theme.</param>
        /// <param name="dark">The color in dark theme.</param>
        static member inline SolidColorBrush(light: Color, ?dark: Color) =
            WidgetBuilder<'msg, ISolidColorBrush>(
                SolidColorBrush.WidgetKey,
                SolidColorBrush.Color.WithValue(AppTheme.create light dark)
            )
