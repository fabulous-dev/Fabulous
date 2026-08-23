namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

module ComponentColorSpectrum =
    let ColorChanged =
        Attributes.Component.defineAvaloniaPropertyWithChangedEvent' "ColorSpectrum_ColorChanged" ColorSpectrum.ColorProperty

[<AutoOpen>]
module ComponentColorSpectrumBuilders =
    type Fabulous.Avalonia.View with
        /// <summary>Creates a ColorSpectrum widget.</summary>
        /// <param name="color">The Color value.</param>
        /// <param name="fn">Raised when the color changes.</param>
        static member ColorSpectrum(color: Color, fn: Color -> unit) =
            WidgetBuilder<'msg, IFabColorSpectrum>(
                ColorSpectrum.WidgetKey,
                ComponentColorSpectrum.ColorChanged.WithValue(ComponentValueEventData.create color fn)
            )
