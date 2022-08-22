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
    let ThumbImageSource = Attributes.defineMauiWidget "ThumbImageSource" (fun target -> (target :?> ISlider).ThumbImageSource)
    
    let DragCompleted = Attributes.defineMauiEventNoArgs "DragCompleted"
    let DragStarted = Attributes.defineMauiEventNoArgs "DragStarted"
    
type FabSlider(handler: IViewHandler) =
    inherit FabView(handler)
    
    static let _widgetKey = Widgets.register<FabSlider>()
    static member WidgetKey = _widgetKey
    
    new() = FabSlider(SliderHandler())
    
    interface ISlider with
        member this.DragCompleted() = this.InvokeEvent(Slider.DragCompleted)
        member this.DragStarted() = this.InvokeEvent(Slider.DragStarted)
        member this.Maximum = this.GetScalar(Range.Maximum, 1.0)
        member this.MaximumTrackColor = this.GetScalar(Slider.MaximumTrackColor, null)
        member this.Minimum = this.GetScalar(Range.Minimum, 0.0)
        member this.MinimumTrackColor = this.GetScalar(Slider.MinimumTrackColor, null)
        member this.ThumbColor = this.GetScalar(Slider.ThumbColor, null)
        member this.ThumbImageSource = this.GetScalar(Image.Source, null)
        member this.Value
            with get () = this.GetScalar(Range.Value, 0.0)
            and set value = this.InvokeEvent(Range.ValueChanged, value)
            
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