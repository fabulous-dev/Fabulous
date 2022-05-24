namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IStepper =
    inherit IView

module Stepper =
    let WidgetKey = Widgets.register<Stepper>()

    let Increment =
        Attributes.defineBindableFloat Stepper.IncrementProperty

    let MinimumMaximum =
        Attributes.defineSimpleScalarWithEquality<struct (float * float)> "Stepper_MinimumMaximum" ViewUpdaters.updateStepperMinMax

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
