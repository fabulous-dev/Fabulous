Fabulous for Xamarin.Forms - Guide
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
