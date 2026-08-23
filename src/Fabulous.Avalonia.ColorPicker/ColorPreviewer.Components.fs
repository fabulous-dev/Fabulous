namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

module ComponentColorPreviewer =
    let ColorChanged =
        Attributes.Component.defineEvent "ColorPreviewer_ColorChanged" (fun target -> (target :?> ColorPreviewer).ColorChanged)

[<AutoOpen>]
module ComponentColorPreviewerBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ColorPreviewer widget.</summary>
        /// <param name="fn">Raised when the color changes.</param>
        static member ColorPreviewer(fn: ColorChangedEventArgs -> unit) =
            WidgetBuilder<'msg, IFabColorPreviewer>(ColorPreviewer.WidgetKey, ComponentColorPreviewer.ColorChanged.WithValue(fn))
