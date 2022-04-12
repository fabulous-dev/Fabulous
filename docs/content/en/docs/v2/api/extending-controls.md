---
id: "v2-extending-controls"
title: "Extending controls"
description: ""
lead: ""
date: 2022-04-12T00:00:00+00:00
lastmod: 2022-04-12T00:00:00+00:00
draft: false
images: []
menu:
  docs:
    parent: "api"
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

Attributes are assigned an automatically-incremented key. Fabulous sorts those keys by ascending order to ensure consistency during updates.

Depending on the internal implementation of a control (e.g. in Xamarin.Forms), sometimes a property needs to be updated before another one.

An example of this: the Picker control has an `Items` property and a `SelectedIndex` property.  
The `Items` should be set before we can set the `SelectedIndex`.

In Fabulous, this is done by defining the attribute `Items` before `SelectedIndex`.

```fs
module Picker =
    let Items = Attributes.define(...) // Will be assigned a key X

    let SelectedIndex = Attributes.define(...) // Will be assigned a key (X + 1)
```

Now, let's take an other example.  
Say we have a custom control that has 2 properties: `A` and `B`.  
`A` needs to be set _after_ `B`.

To do that, we need to define `B` before `A`:

```fs
module CustomControl =
    let B = Attributes.define(...)
    let A = Attributes.define(...)
```

### Special case: reusing attributes and sorting order

It is important to notice that attributes defined in your app will be the first to get a key; before the attributes defined in Fabulous.

This means if you need to update an attribute defined by Fabulous _before_ one of your custom attribute, then you'll need to redefine the existing attributes to ensure order is correct:

```fs
// In Fabulous
module Picker =
    let Items = Attributes.define(...)

// In your app
module CustomPicker =
    let WidgetKey = Widgets.register<CustomPicker>()
    let Items = Attributes.define(...)
    let SelectedIndex = Attributes.define(...)

    type Fabulous.XamarinForms.View with
        static member inline CustomPicker<'msg>(items, selectedIndex) =
            WidgetBuilder<'msg, ICustomPicker>(
                WidgetKey,
                CustomPicker.Items.WithValue(items),
                CustomPicker.SelectedIndex.WithValue(selectedIndex)
            )

// CustomPicker.Items.Key = 0
// CustomPicker.SelectedIndex.Key = 1
// Picker.Items.Key = 2 -- this would not work because CustomPicker.SelectedIndex would be applied first
```
