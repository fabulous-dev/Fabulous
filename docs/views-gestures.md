Fabulous - Guide
=======

{% include_relative contents-views.md %}

Gestures
-------------------

Gesture recognizers can be added to any visual element.

### Tap Gestures

The tap gesture is used for tap detection.  For example, here is a `TapGestureRecognizer`:

```fsharp
View.Frame(
    hasShadow = true,
    gestureRecognizers = [ View.TapGestureRecognizer(command=(fun () -> dispatch FrameTapped)) ]
)
```

See also:

* [Adding a Tap Gesture Gesture Recognizer](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/gestures/tap)
* [`Xamarin.Forms.Core.TapGestureRecognizer`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.TapGestureRecognizer)

### Pan Gestures

The pan gesture is used for detecting dragging. A common scenario for the pan gesture is to horizontally and vertically drag an image, so that all of the image content can be viewed when it's being displayed in a viewport smaller than the image dimensions. This is accomplished by moving the image within the viewport, and is demonstrated in this article.

Here is an example of a `PanGestureRecognizer` used to recognize panning touch movements:

```fsharp
View.Frame(
    hasShadow = true,
    gestureRecognizers = [
        View.PanGestureRecognizer(touchPoints=1, panUpdated=(fun panArgs ->
                if panArgs.StatusType = GestureStatus.Running then
                    dispatch (PanGesture panArgs)))
    ]
)
```

See also:

* [Adding a Pan Gesture Gesture Recognizer](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/gestures/pan)
* [`Xamarin.Forms.Core.PanGestureRecognizer`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.PanGestureRecognizer)

### Pinch Gestures

The pinch gesture is used for performing interactive zoom. A common scenario for the pinch gesture is to perform interactive zoom of an image at the pinch location. This is accomplished by scaling the content of the viewport, and is demonstrated in this article.

Here is an example of a `PinchGestureRecognizer` used to recognize pinch-or-expand touch movements:

```fsharp
View.Frame(
    hasShadow=true,
    gestureRecognizers= [
        View.PinchGestureRecognizer(pinchUpdated=(fun pinchArgs ->
            dispatch (UpdateSize (pinchArgs.Scale, pinchArgs.Status))))
    ]
)
```

See also:

* [Adding a Pinch Gesture Gesture Recognizer](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/gestures/pinch)
* [`Xamarin.Forms.Core.PinchGestureRecognizer`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.PinchGestureRecognizer)


Pop-ups
-------------------

Pop-ups are a special case in Fabulous: they are part of the view, but don't follow the same lifecycle as the rest of the UI. In Xamarin.Forms pop-ups are exposed through 2 methods of the current page: `DisplayAlert` and `DisplayActionSheet`.

In Fabulous we only describe what a page should look like and have no access to UI elements. As such, there is no direct implementation of those 2 methods in Fabulous but instead we can use the static property `Application.Current.MainPage` exposed by Xamarin.Forms.

Here is an example of the use of a confirmation pop-up - note the requirement of `Cmd.AsyncMsg` so as not to block on the UI thread:
```fsharp
type Msg =
    | DisplayAlert
    | AlertResult of bool

let update (msg : Msg) (model : Model) =
    match msg with
    | DisplayAlert ->
        let alertResult = async {
            let! alert =
                Application.Current.MainPage.DisplayAlert("Display Alert", "Confirm", "Ok", "Cancel")
                |> Async.AwaitTask
            return AlertResult alert }

        model, Cmd.ofAsyncMsg alertResult

    | AlertResult alertResult -> ... // Do something with the result
```

_Why don't we add a Fabulous wrapper for those?_
Doing so would only end up duplicating the existing methods and compel us to maintain these in sync with Xamarin.Forms.
See [Pull Request #147](https://github.com/fsprojects/Fabulous/pull/147) for more information

See also:

* [Displaying Pop-ups](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/navigation/pop-ups)
* [`Xamarin.Forms.Core.Page.DisplayAlert`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.page.displayalert)
* [`Xamarin.Forms.Core.Page.DisplayActionSheet`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.page.displayactionsheet)
