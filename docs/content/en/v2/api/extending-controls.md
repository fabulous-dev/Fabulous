---
id: "v2-extending-controls"
title: "Creating and extending controls"
description: ""
lead: ""
date: 2022-04-12T00:00:00+00:00
lastmod: 2022-04-12T00:00:00+00:00
draft: false
images: []
menu:
  docs:
    parent: "api"
weight: 401
toc: true
---

Here, we will explain how to use custom controls with Fabulous.  
If you are wondering about how to create custom controls, please take a look at the Xamarin.Forms documentation: [Customizing an Entry](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/custom-renderer/entry)

Once you implemented a custom control with Xamarin.Forms, you'll need a wrapper to be able to use it in Fabulous.

Fortunately, creating a wrapper is pretty straightforward.

```fs
// Step 1 - declare a marker for your custom control
// Make it inherit the right marker to automatically inherit all existing modifiers (such as Height/Width, Text, etc.)
type IMyEntry = inherit Fabulous.XamarinForms.IEntry

// Step 2 - create a module to store attributes and constructors
module MyEntry =
    // Step 2.a - register your custom control so Fabulous can instantiate it
    let WidgetKey = Widgets.register<MyProject.MyEntry>()

    // Step 2.b - define the attributes you added to the custom control
    let MandatoryProperty = Attributes.defineBindable<int> MyProject.MyEntry.MandatoryBindableProperty

    let OptionalProperty = Attributes.defineBindable<string> MyProject.MyEntry.OptionalBindableProperty

    // Step 2.c - declare the constructors that will be available for use in the view function
    type Fabulous.XamarinForms.View with
        static member inline MyEntry<'msg>(text: string, onTextChanged: string -> 'msg, mandatoryValue: int) =
            WidgetBuilder<'msg, IMyEntry>(
                WidgetKey,
                Entry.Text.WithValue(text), // here we reuse existing attributes from the control we inherit
                Entry.TextChanged.WithValue(fun args -> onTextChanged args.NewTextValue |> box),
                MandatoryProperty.WithValue(mandatoryValue) // here we add our new attribute
            )

// Step 3 (optional) - if you have properties in your custom control that are optional, you can declare modifiers to set them
[<Extension>]
type MyEntryModifiers =
    /// The # sign before the marker interface is important
    // It will make this modifier available to other marker interfaces inheriting IMyEntry
    [<Extension>]
    static member inline optional(this: WidgetBuilder<'msg, #IMyEntry>, value: string) =
        this.AddScalar(MyEntry.OptionalProperty.WithValue(value))
```

Usage:

```fs
open MyEntry

type Msg =
    | TextChanged of string

let view model =
    MyEntry(model.Text, TextChanged, model.Mandatory)
        .optional(model.Optional)
```

## Important considerations

Depending on the internal implementation of a control (e.g. in Xamarin.Forms), sometimes a property needs to be updated before another one.

An example of this: the Stepper control has a `Minimum` and `Maximum` property.

According to the Xamarin.Forms implementation, those properties follow some rules:

- `Minimum` is required to be less than or equal to `Maximum`
- `Maximum` is required to be more than or equal to `Minimum`
- If any of those 2 conditions are not true, `InvalidOperationException` is thrown

This means if the new minimum value is more than the old maximum value, we need to update maximum first. Same in the other direction.

To ensure consistency, Fabulous doesn't take into account the order of declaration. Hence the 2 following codes will have the same behavior:

```fs
Stepper()
    .minimum(1)
    .maximum(5)

Stepper()
    .maximum(5)
    .minimum(1)
```

This could throw an exception if we try to set the minimum to a value superior to the current maximum.

To be able to guarantee the order of property updates, we need to store those 2 properties in a single Attribute.

```fs
// Step 1 - create a struct holding both values
type [<Struct>] MinMaxValue =
    { Minimum: float
      Maximum: float }

module Stepper =
    // Step 2 - define an attribute that will apply the correct update logic
    let MinimumMaximum =
        Attributes.define<MinMaxValue>
            "Stepper_MinimumMaximum"
            (fun _ newValueOpt node ->
                let stepper = node.Target :?> Stepper

                match newValueOpt with
                | ValueNone ->
                    stepper.ClearValue(Stepper.MinimumProperty)
                    stepper.ClearValue(Stepper.MaximumProperty)
                | ValueSome { Minimum = min; Maximum = max } ->
                    let currMax =
                        stepper.GetValue(Stepper.MaximumProperty) :?> float

                    if min > currMax then
                        stepper.SetValue(Stepper.MaximumProperty, max)
                        stepper.SetValue(Stepper.MinimumProperty, min)
                    else
                        stepper.SetValue(Stepper.MinimumProperty, min)
                        stepper.SetValue(Stepper.MaximumProperty, max)
            )

    // Step 3 - add a constructor or a modifier that will take the 2 values at the same time
    type Fabulous.XamarinForms.View with
        static member inline Stepper<'msg>(min: float, max: float) =
            WidgetBuilder<'msg, IStepper>(
                WidgetKey,
                MinimumMaximum.WithValue({ Minimum = min; Maximum = max })
            )

// Step 4 - use it
let view model =
    Stepper(model.Min, model.Max)
```
