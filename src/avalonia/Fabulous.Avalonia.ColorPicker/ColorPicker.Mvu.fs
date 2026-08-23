namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous
open Fabulous.Avalonia


[<AutoOpen>]
module MvuColorPickerBuilders =
    type Fabulous.Avalonia.View with
        /// <summary>Creates a ColorPicker widget.</summary>
        /// <param name="color">The Color value.</param>
        /// <param name="fn">Raised when the color changes.</param>
        static member ColorPicker(color: Color, fn: Color -> 'msg) =
            WidgetBuilder<'msg, IFabColorPicker>(ColorPicker.WidgetKey, MvuColorView.ColorChanged.WithValue(ValueEventData.create color fn))
