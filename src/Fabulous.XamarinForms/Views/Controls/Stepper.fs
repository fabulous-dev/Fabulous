namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IStepper =
    inherit IView

module StepperUpdaters =
    let updateStepperMinMax _ (newValueOpt: struct (float * float) voption) (node: IViewNode) =
        let stepper = node.Target :?> Stepper

        match newValueOpt with
        | ValueNone ->
            stepper.ClearValue(Stepper.MinimumProperty)
            stepper.ClearValue(Stepper.MaximumProperty)
        | ValueSome (min, max) ->
            let currMax =
                stepper.GetValue(Stepper.MaximumProperty) :?> float

            if min > currMax then
                stepper.SetValue(Stepper.MaximumProperty, max)
                stepper.SetValue(Stepper.MinimumProperty, min)
            else
                stepper.SetValue(Stepper.MinimumProperty, min)
                stepper.SetValue(Stepper.MaximumProperty, max)

module Stepper =
    let WidgetKey = Widgets.register<Stepper>()

    let Increment =
        Attributes.defineBindableFloat Stepper.IncrementProperty

    let MinimumMaximum =
        Attributes.defineSimpleScalarWithEquality<struct (float * float)>
            "Stepper_MinimumMaximum"
            StepperUpdaters.updateStepperMinMax

    let ValueWithEvent =
        Attributes.defineBindableWithEvent
            "Stepper_ValueChanged"
            Stepper.ValueProperty
            (fun target -> (target :?> Stepper).ValueChanged)

[<AutoOpen>]
module StepperBuilders =
    type Fabulous.XamarinForms.View with
        static member inline Stepper<'msg>(min: float, max: float, value: float, onValueChanged: float -> 'msg) =
            WidgetBuilder<'msg, IStepper>(
                Stepper.WidgetKey,
                Stepper.MinimumMaximum.WithValue(struct (min, max)),
                Stepper.ValueWithEvent.WithValue(
                    ValueEventData.create value (fun args -> onValueChanged args.NewValue |> box)
                )
            )

[<Extension>]
type StepperModifiers =
    /// <summary>Increments the Stepper's value</summary>
    /// <param name="value">The amount to increment the Stepper by.</param>
    [<Extension>]
    static member inline increment(this: WidgetBuilder<'msg, #IStepper>, value: float) =
        this.AddScalar(Stepper.Increment.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Stepper control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IStepper>, value: ViewRef<Stepper>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
