namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls

type IFabStepper =
    inherit IFabView

module StepperUpdaters =
    let updateStepperMinMax _ (newValueOpt: struct (float * float) voption) (node: IViewNode) =
        let stepper = node.Target :?> Stepper

        match newValueOpt with
        | ValueNone ->
            stepper.ClearValue(Stepper.MinimumProperty)
            stepper.ClearValue(Stepper.MaximumProperty)
        | ValueSome(min, max) ->
            let currMax = stepper.GetValue(Stepper.MaximumProperty) :?> float

            if min > currMax then
                stepper.SetValue(Stepper.MaximumProperty, max)
                stepper.SetValue(Stepper.MinimumProperty, min)
            else
                stepper.SetValue(Stepper.MinimumProperty, min)
                stepper.SetValue(Stepper.MaximumProperty, max)

module Stepper =
    let WidgetKey = Widgets.register<Stepper>()

    let Increment = Attributes.defineBindableFloat Stepper.IncrementProperty

    let MinimumMaximum =
        Attributes.defineSimpleScalarWithEquality<struct (float * float)> "Stepper_MinimumMaximum" StepperUpdaters.updateStepperMinMax

    let ValueWithEvent =
        Attributes.defineBindableWithEvent "Stepper_ValueChanged" Stepper.ValueProperty (fun target -> (target :?> Stepper).ValueChanged)

[<AutoOpen>]
module StepperBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a Stepper widget with min and max values, a current value, and listen for value changes</summary>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <param name="value">The current value</param>
        /// <param name="onValueChanged">Message to dispatch</param>
        static member inline Stepper<'msg when 'msg: equality>(min: float, max: float, value: float, onValueChanged: float -> 'msg) =
            WidgetBuilder<'msg, IFabStepper>(
                Stepper.WidgetKey,
                Stepper.MinimumMaximum.WithValue(struct (min, max)),
                Stepper.ValueWithEvent.WithValue(ValueEventData.create value (fun (args: ValueChangedEventArgs) -> onValueChanged args.NewValue))
            )

[<Extension>]
type StepperModifiers =
    /// <summary>Set the increment step</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The increment step</param>
    [<Extension>]
    static member inline increment(this: WidgetBuilder<'msg, #IFabStepper>, value: float) =
        this.AddScalar(Stepper.Increment.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Stepper control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabStepper>, value: ViewRef<Stepper>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
