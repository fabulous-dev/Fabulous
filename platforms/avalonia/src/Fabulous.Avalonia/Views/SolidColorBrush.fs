namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabSolidColorBrush =
    inherit IFabBrush

module SolidColorBrush =
    let WidgetKey = Widgets.register<SolidColorBrush>()

    let Color =
        Attributes.defineAvaloniaPropertyWithEquality SolidColorBrush.ColorProperty

[<AutoOpen>]
module SolidColorBrushBuilders =
    type Fabulous.Avalonia.View with
        /// <summary>Creates a SolidColorBrush widget.</summary>
        /// <param name="color">The color of the brush.</param>
        static member SolidColorBrush(color: Color) =
            WidgetBuilder<'msg, IFabSolidColorBrush>(SolidColorBrush.WidgetKey, SolidColorBrush.Color.WithValue(color))

        /// <summary>Creates a SolidColorBrush widget.</summary>
        /// <param name="color">The color of the brush.</param>
        static member SolidColorBrush(color: string) =
            View.SolidColorBrush(Color.Parse(color))

type SolidColorBrushModifiers =
    /// <summary>Link a ViewRef to access the direct SolidColorBrush control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabSolidColorBrush>, value: ViewRef<SolidColorBrush>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
