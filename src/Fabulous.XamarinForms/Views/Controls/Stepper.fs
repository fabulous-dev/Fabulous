namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IStepper =
    inherit IView

module Stepper =
    let WidgetKey = Widgets.register<Stepper>()

    let Increment =
        Attributes.defineBindable<float> Stepper.IncrementProperty

    let MinimumMaximum =
        Attributes.define<struct (float * float)> "Stepper_MinimumMaximum" ViewUpdaters.updateStepperMinMax

    let Value =
        Attributes.defineBindable<float> Stepper.ValueProperty

    let ValueChanged =
        Attributes.defineEvent<ValueChangedEventArgs>
            "Stepper_ValueChanged"
            (fun target -> (target :?> Stepper).ValueChanged)

[<AutoOpen>]
module StepperBuilders =
    type Fabulous.XamarinForms.View with
        static member inline Stepper<'msg>(min: float, max: float, value: float, onValueChanged: float -> 'msg) =
            WidgetBuilder<'msg, IStepper>(
                Stepper.WidgetKey,
                Stepper.Value.WithValue(value),
                Stepper.ValueChanged.WithValue(fun args -> onValueChanged args.NewValue |> box),
                Stepper.MinimumMaximum.WithValue(struct (min, max))
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
