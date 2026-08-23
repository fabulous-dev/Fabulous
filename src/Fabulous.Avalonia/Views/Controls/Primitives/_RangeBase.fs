namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous

type IFabRangeBase =
    inherit IFabTemplatedControl

module RangeBaseUpdaters =
    let updateSliderMinMax _ (newValueOpt: struct (float * float) voption) (node: IViewNode) =
        let slider = node.Target :?> RangeBase

        match newValueOpt with
        | ValueNone ->
            slider.ClearValue(RangeBase.MinimumProperty)
            slider.ClearValue(RangeBase.MaximumProperty)
        | ValueSome(min, max) ->
            let currMax = slider.GetValue(RangeBase.MaximumProperty)

            if min > currMax then
                slider.SetValue(RangeBase.MaximumProperty, max) |> ignore
                slider.SetValue(RangeBase.MinimumProperty, min) |> ignore
            else
                slider.SetValue(RangeBase.MinimumProperty, min) |> ignore
                slider.SetValue(RangeBase.MaximumProperty, max) |> ignore

module RangeBase =
    let MinimumMaximum =
        Attributes.defineSimpleScalarWithEquality<struct (float * float)> "RangeBase_MinimumMaximum" RangeBaseUpdaters.updateSliderMinMax

    let Minimum =
        Attributes.defineAvaloniaPropertyWithEquality RangeBase.MinimumProperty

    let Maximum =
        Attributes.defineAvaloniaPropertyWithEquality RangeBase.MaximumProperty

    let SmallChange =
        Attributes.defineAvaloniaPropertyWithEquality RangeBase.SmallChangeProperty

    let LargeChange =
        Attributes.defineAvaloniaPropertyWithEquality RangeBase.LargeChangeProperty

type RangeBaserModifiers =
    /// <summary>Sets the SmallChange property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SmallChange value.</param>
    [<Extension>]
    static member inline smallChange(this: WidgetBuilder<'msg, #IFabRangeBase>, value: float) =
        this.AddScalar(RangeBase.SmallChange.WithValue(value))

    /// <summary>Sets the LargeChange property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The LargeChange value.</param>
    [<Extension>]
    static member inline largeChange(this: WidgetBuilder<'msg, #IFabRangeBase>, value: float) =
        this.AddScalar(RangeBase.LargeChange.WithValue(value))
