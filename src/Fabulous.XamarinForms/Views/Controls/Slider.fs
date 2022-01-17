namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

type ISlider =
    inherit IView
    
module Slider =
    let WidgetKey = Widgets.register<Slider>()
        
    let MinimumMaximum =
        Attributes.define<struct (float * float)> "Slider_MinimumMaximum" ViewUpdaters.updateSliderMinMax

    let Value =
        Attributes.defineBindable<float> Slider.ValueProperty

    let ValueChanged =
        Attributes.defineEvent<ValueChangedEventArgs>
            "Slider_ValueChanged"
            (fun target -> (target :?> Slider).ValueChanged)

[<AutoOpen>]
module SliderBuilders =
    type Fabulous.XamarinForms.View with
        static member inline Slider<'msg>(min: float, max: float, value: float, onValueChanged: float -> 'msg) =
            WidgetBuilder<'msg, ISlider>(
                Slider.WidgetKey,
                Slider.Value.WithValue(value),
                Slider.ValueChanged.WithValue(fun args -> onValueChanged args.NewValue |> box),
                Slider.MinimumMaximum.WithValue(struct (min, max))
            )
