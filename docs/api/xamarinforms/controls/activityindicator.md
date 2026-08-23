# ActivityIndicator

**Inheritance:** [Element](https://docs.fabulous.dev/v2/api/controls/element/) -> [NavigableElement](https://docs.fabulous.dev/v2/api/navigable-element/) -> [VisualElement](https://docs.fabulous.dev/v2/api/visual-element/) -> [View](https://docs.fabulous.dev/v2/api/view/)\
**Xamarin.Forms documentation:** ActivityIndicator [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.activityindicator) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/activityindicator)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/activityindicator).

### Constructors&#x20;

| Constructors                       | Description                                               |
| ---------------------------------- | --------------------------------------------------------- |
| ActivityIndicator(isRunning: bool) | Define an ActivityIndicator widget with its current state |

### Properties&#x20;

| Properties                                    | Description                                                                                                    |
| --------------------------------------------- | -------------------------------------------------------------------------------------------------------------- |
| color(light: FabColor, ?dark: FabColor)       | Sets the activity indicator color depending if light or dark mode                                              |
| reference(value: ViewRef\<ActivityIndicator>) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.ActivityIndicator` instance associated to this widget |

### Usages&#x20;

```fsharp
ActivityIndicator(true)
    .color(light = Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor())
```

#### Get access to the underlying Xamarin.Forms.ActivityIndicator&#x20;

```fsharp
let activityIndicatorRef = ViewRef<ActivityIndicator>()

ActivityIndicator(true)
    .reference(activityIndicatorRef)
```
