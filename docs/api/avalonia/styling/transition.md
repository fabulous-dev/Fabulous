# Transition

**Inheritance:** [AvaloniaObject](https://reference.avaloniaui.net/api/Avalonia/AvaloniaObject/)\
**AvaloniaUI documentation:** TransitionBase [API](https://reference.avaloniaui.net/api/Avalonia.Animation/Transition\_1/)

## Constructors

| Constructors                                                                  | Description                                     |
| ----------------------------------------------------------------------------- | ----------------------------------------------- |
| DoubleTransition(property: AvaloniaProperty, duration: TimeSpan)              | Creates a DoubleTransition widget.              |
| BoxShadowsTransition(property: AvaloniaProperty, duration: TimeSpan)          | Creates a BoxShadowsTransition widget.          |
| BrushTransition(property: AvaloniaProperty, duration: TimeSpan)               | Creates a BrushTransition widget.               |
| ColorTransition(property: AvaloniaProperty, duration: TimeSpan)               | Creates a ColorTransition widget.               |
| CornerRadiusTransition(property: AvaloniaProperty, duration: TimeSpan)        | Creates a CornerRadiusTransition widget.        |
| FloatTransition(property: AvaloniaProperty, duration: TimeSpan)               | Creates a FloatTransition widget.               |
| IntegerTransition(property: AvaloniaProperty, duration: TimeSpan)             | Creates an IntegerTransition widget.            |
| PointTransition(property: AvaloniaProperty, duration: TimeSpan)               | Creates a PointTransition widget.               |
| SizeTransition(property: AvaloniaProperty, duration: TimeSpan)                | Creates a SizeTransition widget.                |
| ThicknessTransition(property: AvaloniaProperty, duration: TimeSpan)           | Creates a ThicknessTransition widget.           |
| TransformOperationsTransition(property: AvaloniaProperty, duration: TimeSpan) | Creates a TransformOperationsTransition widget. |
| VectorTransition(property: AvaloniaProperty, duration: TimeSpan)              | Creates a VectorTransition widget.              |
| EffectTransition(property: AvaloniaProperty, duration: TimeSpan)              | Creates an EffectTransition widget.             |

## Properties

| Properties                                              | Description                                                         |
| ------------------------------------------------------- | ------------------------------------------------------------------- |
| transition(this: WidgetBuilder<'msg, #IFabAnimatable>)  | Sets the Transitions property.                                      |
| transition(value: WidgetBuilder<'msg, #IFabTransition>) | Sets the Transitions property.                                      |
| delay(value: TimeSpan)                                  | Sets the Delay property.                                            |
| easing(value: Easing)                                   | Sets the Easing property.                                           |
| reference(value: ViewRef)                               | Link a ViewRef to access the direct TransitionBase control instance |

## Usages

```fsharp
Border(...)
    .transitions() {
        ColorTransition(Border.BackgroundProperty, TimeSpan.FromMilliseconds(200.))
        ColorTransition(Border.BackgroundProperty, TimeSpan.FromMilliseconds(200.))
    }

Border(...)
    .transition(ColorTransition(Border.BackgroundProperty, TimeSpan.FromMilliseconds(200.)))
}
```

#### Get access to the underlying Transition

```fsharp
let transitionRef = ViewRef<TransitionBase>()

Border(...)
    .transition(
        ColorTransition(Border.BackgroundProperty, TimeSpan.FromMilliseconds(200.))
            .reference(transitionRef)
    )
```
