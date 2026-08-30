# ProgressBar

**Xamarin.Forms documentation:** ProgressBar [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.progressbar) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/progressbar)

For details on how the control actually works, please refer to the [Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/progressbar).

### Constructors&#x20;

| Constructors                                                | Description                                                                                     |
| ----------------------------------------------------------- | ----------------------------------------------------------------------------------------------- |
| ProgressBar(progress: float)                                | Define a ProgressBar widget with the progress value (between 0.0 and 1.0)                       |
| ProgressBar(progress: float, duration: int, easing: Easing) | Define a ProgressBar widget with an animated change of the progress value (between 0.0 and 1.0) |

### Properties&#x20;

| Properties                                      | Description                                                                                              |
| ----------------------------------------------- | -------------------------------------------------------------------------------------------------------- |
| progressColor(light: FabColor, ?dark: FabColor) | Sets the progress bar color depending if light or dark mode                                              |
| reference(value: ViewRef\<ProgressBar>)         | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.ProgressBar` instance associated to this widget |

### Usages&#x20;

```fsharp
ProgressBar(0.5)
    .progressColor(Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor())
    
ProgressBar(0.5, 1000, Easing.CubicInOut)
    .progressColor(Color.Red.ToFabColor(), dark = Color.Blue.ToFabColor())
```

#### Get access to the underlying Xamarin.Forms.ProgressBar [#](https://fabulous-dev.github.io/Fabulous/v2/api/controls/progress-bar/#get-access-to-the-underlying-xamarinformsprogressbar) <a href="#get-access-to-the-underlying-xamarinformsprogressbar" id="get-access-to-the-underlying-xamarinformsprogressbar"></a>

```fsharp
let progressBarRef = ViewRef<ProgressBar>()

ProgressBar(0.5)
    .reference(progressBarRef)
```
