---
id: "v2-attribute-definitions"
title: "Attribute definitions"
description: ""
lead: ""
date: 2022-04-21T00:00:00+00:00
lastmod: 2022-04-21T00:00:00+00:00
draft: false
images: []
menu:
  docs:
    parent: "architecture"
weight: 503
toc: true
---

## Attribute definition helpers

### defineBindableWithEvent (Xamarin.Forms)

Values and event handlers are very similar. They are both values: one has a concrete value, the other has a function value.
That's why in v2, values and events are both treated as individual scalar attributes.

That works most of the time, but some properties and events have a strong dependency.
E.g.:

- Entry: Text / TextChanged
- Slider: Value / ValueChanged
- ListView: SelectedIndex / SelectedIndex

This is required to be able to react to user interactions like users are inputting text, toggling a switch, etc.
But in Xamarin.Forms, those events are also triggered by programmatic changes.

If you, as a developer, decides to toggle the switch from false to true, it will raise a `Toggled` event - the same event if the users had toggle the switch themselves.

Firstly this makes it hard to differentiate if we are reacting to a user change or a programmatic change.
The latter is not really interesting since we already know what's inside the app model.

This behavior seems rather harmless because in case of programmatic change, Fabulous will see that the event is actually trying to set the related property to the same value, so no change is needed.
Eg.: [Programmatic Change: Value = true] -> [Event msg: Value changed to true] -> [Value was true, now is true] -> [do nothing]

But on Android, this can lead to an infinite update loop.
Android delays its event triggering a little bit so if the user is quickly changing the input, Fabulous and Android can get out of sync and freeze the app.

Example: User wants to write "Hello"

1) User taps letter `H`
2) User taps letter `e`
3) Android raises event "TextChanged: H" -> Fabulous will change the Entry's text to `H` (was `He`) -> triggering another event
4) Android raises event "TextChanged: He" -> Fabulous will change the Entry's text to `He` (was `H`)
5) Android raises event "TextChanged: H" (because of (3)) -> Fabulous will change to `H` (was `He`)
6) Android raises event "TextChanged: He" (because of (4)) -> Fabulous will change the Entry's text to `He` (was `H`)
7) etc. 

To avoid this from happening, the only way is to ignore the events triggered by programmatic changes.
This is done by removing the event handler before updating the value and reset it after.

To guarantee the order of execution, we need to handle both the property and the related event in a single attribute, where the `UpdateNode` function of the attribute will take care of updating in the right order.

1) Remove old handler if any
2) Update the value (it will trigger an event, but we don't listen to it anymore)
    - If attribute was removed, then we clean the old value 
    - Otherwise we set the new value
3) Set the new handler if any

Here is the attribute declaration to use:

Before we had 2 attribute definitions (property and event)

```fs
module Slider =
    let Value = Attributes.defineBindable<float> Slider.ValueProperty

    let ValueChanged =
        Attributes.defineEventWithArgs<ValueChangedEventArgs>
            "Slider_ValueChanged"
            (fun target -> (target :?> Slider).ValueChanged)

type Fabulous.XamarinForms.View with
    static member inline Slider<'msg>(value: float, onValueChanged: ValueChangedEventArgs -> 'msg) =
        WidgetBuilder<'msg, ISlider>(
            Slider.WidgetKey,
            Slider.Value.WithValue(value),
            Slider.ValueChanged.WithValue(fun args -> onValueChanged args |> box)
        )
```

Now, there is a new attribute definition to update both the property and the event in a single attribute.
```fs
module Slider =
    let ValueWithEvent =
        Attributes.defineBindableWithEvent<float, ValueChangedEventArgs>
            "Slider_ValueChanged"
            Slider.ValueProperty
            (fun target -> (target :?> Slider).ValueChanged)

type Fabulous.XamarinForms.View with
    static member inline Slider<'msg>(value: float, onValueChanged: ValueChangedEventArgs -> 'msg) =
        WidgetBuilder<'msg, ISlider>(
            Slider.WidgetKey,
            Slider.ValueWithEvent.WithValue(ValueEventData.create value (fun args -> onValueChanged args |> box))
        )
```
