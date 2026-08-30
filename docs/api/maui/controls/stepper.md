# Stepper

**Inheritance:** [Element](https://github.com/fabulous-dev/Fabulous/blob/main/docs/api/maui/element.md) -> [NavigableElement](https://github.com/fabulous-dev/Fabulous/blob/main/docs/api/maui/navigableelement.md) -> [VisualElement](https://github.com/fabulous-dev/Fabulous/blob/main/docs/api/maui/visualelement.md) -> [View](https://github.com/fabulous-dev/Fabulous/blob/main/docs/api/maui/view.md/)\
**Xamarin.Forms documentation:** Stepper [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.stepper) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/stepper)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/stepper).

### Constructors&#x20;

| Constructors                                                                 | Description                                                           |
| ---------------------------------------------------------------------------- | --------------------------------------------------------------------- |
| Stepper(min: float, max: float, value: float, onValueChanged: float -> ‘msg) | Define a Stepper widget with the min-max bounds and the current value |

### Properties&#x20;

| Properties                          | Description                                                                                          |
| ----------------------------------- | ---------------------------------------------------------------------------------------------------- |
| increment(value: float)             | Sets the increment step between each selected values                                                 |
| reference(value: ViewRef\<Stepper>) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.Stepper` instance associated to this widget |

### Usages&#x20;

```fsharp
Stepper(1000., 5000., model.Value, ValueChangedMsg)
    .increment(250.)
```

#### Get access to the underlying Xamarin.Forms.Stepper&#x20;

```fsharp
let stepperRef = ViewRef<Stepper>()

Stepper(1000., 5000., model.Value, ValueChangedMsg)
    .reference(stepperRef) 
```
