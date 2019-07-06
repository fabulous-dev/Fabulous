Fabulous for Xamarin.Forms - Guide
=======

{% include_relative contents-views.md %}

Pop-ups
-------------------

Pop-ups are a special case in Fabulous for Xamarin.Forms: they are part of the view, but don't follow the same lifecycle as the rest of the UI. In Xamarin.Forms pop-ups are exposed through 2 methods of the current page: `DisplayAlert` and `DisplayActionSheet`.

In Fabulous for Xamarin.Forms we only describe what a page should look like and have no access to UI elements. As such, there is no direct implementation of those 2 methods in Fabulous but instead we can use the static property `Application.Current.MainPage` exposed by Xamarin.Forms.

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

<img src="https://user-images.githubusercontent.com/52166903/60180195-5d63c480-9817-11e9-9c12-bab34b7fbb77.png" width="400">

_Why don't we add a Fabulous wrapper for those?_
Doing so would only end up duplicating the existing methods and compel us to maintain these in sync with Xamarin.Forms.
See [Pull Request #147](https://github.com/fsprojects/Fabulous/pull/147) for more information

See also:

* [Displaying Pop-ups](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/navigation/pop-ups)
* [`Xamarin.Forms.Core.Page.DisplayAlert`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.page.displayalert)
* [`Xamarin.Forms.Core.Page.DisplayActionSheet`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.page.displayactionsheet)
