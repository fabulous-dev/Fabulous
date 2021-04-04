{% include_relative _header.md %}

{% include_relative contents.md %}

Interface objects (Views) for indicating activity
------
##### `topic last updated: v1.0 - 04.04.2021 - 02:51pm`
<br /> 

### ActivityIndicator
A simple `ActivityIndicator` is as follows:

```fsharp
View.ActivityIndicator(isRunning = (count > 0))
```

<img src="https://user-images.githubusercontent.com/52166903/60177355-9c424c00-9810-11e9-8275-bd8c2ebcf3c8.png" width="400">

See also:

* [`Xamarin.Forms.Core.ActivityIndicator`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.ActivityIndicator)

<br /> 

### ProgressBar

 The Progress Bar represents progress as a horizontal bar, that is filled to a percentage, represented by a float value.

```fsharp 
View.ProgressBar(
    progress = 0.5,
    progressColor = Color.DarkRed
    )
```

* [Xamarin guide to ProgressBar](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/progressbar)
* [`Xamarin.Forms.ProgressBar`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.ProgressBar?view=xamarin-forms)
