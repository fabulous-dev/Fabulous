namespace Fabulous.Maui

open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Handlers

module Slider =
    let MaximumTrackColor = Attributes.defineMauiScalarWithEquality<Color> "MaximumTrackColor"
    let MinimumTrackColor = Attributes.defineMauiScalarWithEquality<Color> "MinimumTrackColor"
    let ThumbColor = Attributes.defineMauiScalarWithEquality<Color> "ThumbColor"
    let ThumbImageSource = Attributes.defineMauiScalarWithEquality<IImageSource> "ThumbImageSource"
    
    let DragCompleted = Attributes.defineMauiEventNoArgs "DragCompleted"
    let DragStarted = Attributes.defineMauiEventNoArgs "DragStarted"
    
    module Defaults =
        let [<Literal>] MaximumTrackColor: Color = null
        let [<Literal>] MinimumTrackColor: Color = null
        let [<Literal>] ThumbColor: Color = null
        let [<Literal>] ThumbImageSource: IImageSource = null
    
type FabSlider(handler: IViewHandler) =
    inherit FabView(handler)
    
    static let _widgetKey = Widgets.register<FabSlider>()
    static member WidgetKey = _widgetKey
    
    new() = FabSlider(SliderHandler())
    
    interface IRange with
        member this.Maximum = this.GetScalar(Range.Maximum, Range.Defaults.Maximum)
        member this.Minimum = this.GetScalar(Range.Minimum, Range.Defaults.Minimum)
        member this.Value
            with get () = this.GetScalar(Range.Value, Range.Defaults.Value)
            and set value = this.InvokeEvent(Range.ValueChanged, value)
    
    interface ISlider with
        member this.DragCompleted() = this.InvokeEvent(Slider.DragCompleted)
        member this.DragStarted() = this.InvokeEvent(Slider.DragStarted)
        member this.MaximumTrackColor = this.GetScalar(Slider.MaximumTrackColor, Slider.Defaults.MaximumTrackColor)
        member this.MinimumTrackColor = this.GetScalar(Slider.MinimumTrackColor, Slider.Defaults.MinimumTrackColor)
        member this.ThumbColor = this.GetScalar(Slider.ThumbColor, Slider.Defaults.ThumbColor)
        member this.ThumbImageSource = this.GetScalar(Slider.ThumbImageSource, Slider.Defaults.ThumbImageSource)
            
[<AutoOpen>]
module SliderBuilders =
    type Fabulous.Maui.View with
        static member inline Slider<'msg>(min: float, max: float, value: float, onValueChanged: float -> 'msg) =
            let x =
                StackList.three(
                    Range.Minimum.WithValue(min),
                    Range.Maximum.WithValue(max),
                    Range.Value.WithValue(value)
                )
                
            WidgetBuilder<'msg, ISlider>(
                FabSlider.WidgetKey,
                AttributesBundle(
                    StackList.add(
                        &x,
                        Range.ValueChanged.WithValue(fun v -> onValueChanged v |> box)
                    ),
                    ValueNone,
                    ValueNone
                )
            )