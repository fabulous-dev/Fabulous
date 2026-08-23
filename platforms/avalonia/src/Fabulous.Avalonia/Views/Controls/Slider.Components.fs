namespace Fabulous.Avalonia


open Fabulous
open Fabulous.Avalonia

[<AutoOpen>]
module ComponentSliderBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Slider widget.</summary>
        /// <param name="value">The initial value of the slider.</param>
        /// <param name="fn">Raised when the slider value changes.</param>
        static member Slider(value: float, fn: float -> unit) =
            WidgetBuilder<'msg, IFabSlider>(Slider.WidgetKey, ComponentRangeBase.ValueChanged.WithValue(ComponentValueEventData.create value fn))

        /// <summary>Creates a Slider widget.</summary>
        /// <param name="min">The minimum value of the slider.</param>
        /// <param name="max">The maximum value of the slider.</param>
        /// <param name="value">The initial value of the slider.</param>
        /// <param name="fn">Raised when the slider value changes.</param>
        static member inline Slider(min: float, max: float, value: float, fn: float -> unit) =
            WidgetBuilder<'msg, IFabSlider>(
                Slider.WidgetKey,
                RangeBase.MinimumMaximum.WithValue(struct (min, max)),
                ComponentRangeBase.ValueChanged.WithValue(ComponentValueEventData.create value fn)
            )
