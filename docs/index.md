
F# Functional App Development, using Xamarin.Forms
========

Never write a ViewModel class again!  Conquer the world with clean dynamic UIs!

<img src="https://user-images.githubusercontent.com/7204669/39318922-57c95174-4977-11e8-94a9-cc385101ce5d.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318926-59f844e6-4977-11e8-9834-325a6517ced6.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318929-5b66c776-4977-11e8-8317-ee1c121301d4.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318934-5cbe3c3a-4977-11e8-92aa-c3fdf644b01c.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318936-5e2380bc-4977-11e8-8912-f078744a2bde.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318938-5f6ec4f4-4977-11e8-97a9-779edd3594bc.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318941-60c1b0f0-4977-11e8-8a4a-57e17ef8c6ec.png" width="100">

This library allows you to use a variation of [elmish](https://elmish.github.io/), an Elm architecture implemented in F#,
to build Xamarin.Forms applications for iOS, Android, Mac and more.

> The amount of code I'm *not* writing is great!  [@jimbobbennett](https://github.com/jimbobbennett/)

**This project is a sample and may change.**

{% include_relative contents.md %}

Getting started
------

1. Enable Xamarin support in Visual Studio or Visual Studio for Mac.

2. Install the template pack:

       dotnet new -i Elmish.XamarinForms.Templates

3. Create a blank F# Functional Xamarin Forms app:

       dotnet new elmish-forms-app -lang F# -n SqueakyApp

4. Open, edit, build and deploy in Visual Studio, Visual Studio for Mac and/or "msbuild" command line

       SqueakyApp/SqueakyApp.sln

A Basic Example
------

Here is a full example of an app:

```fsharp
/// The messages dispatched by the view
type Msg =
    | Pressed

/// The model from which the view is generated
type Model =
    { Pressed: bool }

/// Returns the initial state
let init() = { Pressed=false }

/// The function to update the view
let update (msg:Msg) (model:Model) =
    match msg with
    | Pressed -> { model with Pressed = true }

/// The view function giving updated content for the page
let view (model: Model) dispatch =
    if model.Pressed then
        View.Label(text="I was pressed!")
    else
        View.Button(text="Press Me!", command=(fun () -> dispatch Pressed))

type App () =
    inherit Application ()

    let runner =
        Program.mkSimple init update view
        |> Program.withConsoleTrace
        |> Program.runWithDynamicView
```

The init function returns your initial state, and each model gets an update function for message processing. The `view` function computes an immutable Xaml-like description. In the above example, the choice between a label and button depends on the `model.Pressed` value.

Some advantages of using an immutable model are:

* It is easy to unit test your `init`, `update` and `view` functions
* You can save/restore your model relatively easily
* It makes tracing causality usually very simple

Samples
------

The sample [CounterApp](https://github.com/fsprojects/Elmish.XamarinForms/blob/master/Samples/CounterApp/CounterApp/CounterApp.fs) contains a slightly larger example of Button/Label/Slider elements.

The sample [TicTacToe](https://github.com/fsprojects/Elmish.XamarinForms/blob/master/Samples/TicTacToe/TicTacToe/TicTacToe.fs) contains examples of the Grid and Image elements.

The sample [AllControls](https://github.com/fsprojects/Elmish.XamarinForms/blob/master/Samples/AllControls/AllControls/AllControls.fs) contains examples of instantiating most elements in `Xamarin.Forms.Core`.

The external sample [Calculator](https://github.com/nosami/Elmish.Calculator/) is a small calculator app. (Note: because this is an external sample it may not be up-to-date with the latest version of his library.)

The external sample [PocketPiggyBank](https://github.com/jimbobbennett/PocketPiggyBank) is a small client-server app with login authentication. (Note: because this is an external sample it may not be up-to-date with the latest version of this library.)

The external sample [ElmishContacts](https://github.com/TimLariviere/ElmishContacts) is a multi-page contacts app featuring maps, group-lists and cross-page messages. (Note: because this is an external sample it may not be up-to-date with the latest version of this library.)

The external sample [ElmishPlanets](https://github.com/TimLariviere/ElmishPlanets) is a multi-page contacts app featuring facts on the planets in the Solar System. It uses Urho3D and EXF (Note: because this is an external sample it may not be up-to-date with the latest version of this library.)

See also the curated list [awesome EXF](http://aka.ms/AwesomeEXF).

Further Resources
--------

Presentation: [Making Mobile App Development Simple with F#](https://twitter.com/dsyme/status/1037119834969067522)

Presentation: Building mobile apps with F# using Xamarin - Jim Bennett - Xamarin University Guest Lecture

<iframe width="560" height="315" src="https://www.youtube.com/embed/si9YdWhbwSI?rel=0" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>

**General Docs**

* [Xamarin](https://docs.microsoft.com/xamarin/)
* [Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/)
  * [Performance and Security](https://docs.microsoft.com/en-us/xamarin/cross-platform/deploy-test/performance)
  * [Deployment and Debugging](https://docs.microsoft.com/en-us/xamarin/cross-platform/deploy-test/)
  * [Cross-platform for Desktop Developers](https://docs.microsoft.com/en-us/xamarin/cross-platform/desktop/)
* [Xamarin Essentials](https://docs.microsoft.com/en-us/xamarin/essentials/index?context=xamarin/xamarin-forms)

**Android Setup**

* [SDK](https://docs.microsoft.com/en-us/xamarin/android/get-started/installation/android-sdk?tabs=vswin)
* [Emulator](https://docs.microsoft.com/en-us/xamarin/android/get-started/installation/android-emulator/)
* [Device](https://docs.microsoft.com/xamarin/android/get-started/installation/set-up-device-for-development)

**iOS Setup**

* [SDK](https://docs.microsoft.com/en-gb/visualstudio/mac/installation)
* [Emulator](https://docs.microsoft.com/en-us/xamarin/android/get-started/installation/android-emulator/)
* [Pair to Mac](https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/windows/connecting-to-mac/)
* [Device](https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/device-provisioning/)

Contributing
------

Please contribute to this library through issue reports, pull requests, code reviews and discussion.

* [Submit a fix to this guide](https://github.com/fsprojects/Elmish.XamarinForms/tree/master/docs)
