namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

module MvuColorSpectrum =
    let ColorChanged =
        Attributes.Mvu.defineAvaloniaPropertyWithChangedEvent' "ColorSpectrum_ColorChanged" ColorSpectrum.ColorProperty

[<AutoOpen>]
module MvuColorSpectrumBuilders =
    type Fabulous.Avalonia.View with
        /// <summary>Creates a ColorSpectrum widget.</summary>
        /// <param name="color">The Color value.</param>
        /// <param name="fn">Raised when the color changes.</param>
        static member ColorSpectrum(color: Color, fn: Color -> 'msg) =
            WidgetBuilder<'msg, IFabColorSpectrum>(ColorSpectrum.WidgetKey, MvuColorSpectrum.ColorChanged.WithValue(ValueEventData.create color fn))
