F# Functional App Development, using Xamarin.Forms
========

Never write a ViewModel class again!  Conquer the world with clean dynamic UIs!

<img src="https://user-images.githubusercontent.com/7204669/39318922-57c95174-4977-11e8-94a9-cc385101ce5d.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318926-59f844e6-4977-11e8-9834-325a6517ced6.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318929-5b66c776-4977-11e8-8317-ee1c121301d4.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318934-5cbe3c3a-4977-11e8-92aa-c3fdf644b01c.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318936-5e2380bc-4977-11e8-8912-f078744a2bde.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318938-5f6ec4f4-4977-11e8-97a9-779edd3594bc.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318941-60c1b0f0-4977-11e8-8a4a-57e17ef8c6ec.png" width="100">

This library allows you to use the ultra-simple Model-View-Update architecture to build applications for iOS, Android, Mac, WPF and more using Xamarin.Forms. It is built on Fabulous.

> The amount of code I'm *not* writing is great!  [@jimbobbennett](https://github.com/jimbobbennett/)

{% include_relative contents.md %}

Getting started
------

1. Install Visual Studio or Visual Studio for Mac and enable both Xamarin and .NET Core support, these are listed as 'Mobile development with .NET' and '.NET Core Cross-platform development' respectively.

2. Open a command prompt window and install the template pack by entering:

       dotnet new -i Fabulous.XamarinForms.Templates

3. Navigate to a folder in the command prompt window where your new app can be created and enter:

       dotnet new fabulous-xf-app -n SqueakyApp

4. Open, edit and build in Visual Studio or Visual Studio for Mac

       SqueakyApp/SqueakyApp.sln

5. Before deploying and running, first connect and enable your device, choose between iOS ([Emulator](https://docs.microsoft.com/en-us/xamarin/ios/get-started/hello-ios/hello-ios-quickstart), [Device](https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/device-provisioning/)) or Android ([Emulator](https://docs.microsoft.com/en-us/xamarin/android/get-started/installation/android-emulator/), [Device](https://docs.microsoft.com/xamarin/android/get-started/installation/set-up-device-for-development)).

6. To run, set either your Android or iOS project as the startup project, then use F5.

By default iOS and Android projects are created. But you can also target WPF with `--WPF`, UWP with `--UWP`, macOS with `--macOS` and/or GTK with `--GTK`. Here some common examples, but feel free to change the targets to the ones you require:

Android only:

    dotnet new fabulous-xf-app -n SqueakyApp --iOS=false
   
iOS only:

    dotnet new fabulous-xf-app -n SqueakyApp --Android=false
   
WPF only:

    dotnet new fabulous-xf-app -n SqueakyApp --WPF --Android=false --iOS=false

UWP only:

    dotnet new fabulous-xf-app -n SqueakyApp --UWP --Android=false --iOS=false
   
macOS only:

    dotnet new fabulous-xf-app -n SqueakyApp --macOS --Android=false --iOS=false

GTK only:

    dotnet new fabulous-xf-app -n SqueakyApp --GTK --Android=false --iOS=false

All 6 platforms:

    dotnet new fabulous-xf-app -n SqueakyApp --WPF --UWP --macOS --GTK

5. If you are using Visual Studio for Mac and you want to start with `File -> New`, make sure you target ".NET Standard" to add the references to Fabulous:
       
       File -> New Solution
       Multiplatform App -> Blank Forms App (F#)
       Shared Code -> Use .NET Standard
       
<img src="https://user-images.githubusercontent.com/1394644/45930814-97bfce80-bf32-11e8-8f7a-ebcbcb0247fa.png" width="500"> 

A Basic Example
------

Here is a full example of an app:

```fsharp
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

/// The messages dispatched by the view
type Msg =
    | Pressed

/// The model from which the view is generated
type Model =
    { Pressed: bool }

/// Returns the initial state
let init() = { Pressed = false }

/// The function to update the view
let update (msg: Msg) (model: Model) =
    match msg with
    | Pressed -> { model with Pressed = true }

/// The view function giving updated content for the page
let view (model: Model) dispatch =
    View.ContentPage(
        content=View.StackLayout(
            children=[
                if model.Pressed then
                    yield View.Label(text="I was pressed!")
                else
                    yield View.Button(text="Press Me!", command=(fun () -> dispatch Pressed))
            ]
        )
    )

type App () as app =
    inherit Application ()

    let runner =
        Program.mkSimple init update view
        |> Program.withConsoleTrace
        |> XamarinFormsProgram.run app
```

The init function returns your initial state, and each model gets an update function for message processing. The `view` function computes an immutable Xaml-like description. In the above example, the choice between a label and button depends on the `model.Pressed` value.

Some advantages of using an immutable model are:

* It is easy to unit test your `init`, `update` and `view` functions
* You can save/restore your model relatively easily
* It makes tracing causality usually very simple

Samples
------

The sample [CounterApp](https://github.com/fsprojects/Fabulous/blob/master/Fabulous.XamarinForms/samples/CounterApp/CounterApp/CounterApp.fs) contains a slightly larger example of Button/Label/Slider elements.

The sample [TicTacToe](https://github.com/fsprojects/Fabulous/blob/master/Fabulous.XamarinForms/samples/TicTacToe/TicTacToe/TicTacToe.fs) contains examples of the Grid and Image elements.

The sample [AllControls](https://github.com/fsprojects/Fabulous/blob/master/Fabulous.XamarinForms/samples/AllControls/AllControls/AllControls.fs) contains examples of instantiating most elements in `Xamarin.Forms.Core`.

The sample [Calculator](https://github.com/fsprojects/Fabulous/blob/master/Fabulous.XamarinForms/samples/Calculator/Calculator/Calculator.fs) ([original external sample](https://github.com/nosami/Elmish.Calculator/)) is a small calculator app.

The external sample [PocketPiggyBank](https://github.com/jimbobbennett/PocketPiggyBank) is a small client-server app with login authentication. (Note: because this is an external sample it may not be up-to-date with the latest version of this library.)

The external sample [FabulousContacts](https://github.com/TimLariviere/FabulousContacts) is a multi-page contacts app featuring maps, group-lists and cross-page messages. (Note: because this is an external sample it may not be up-to-date with the latest version of this library.)

The external sample [FabulousPlanets](https://github.com/TimLariviere/FabulousPlanets) is a multi-page app featuring facts on the planets in the Solar System. It uses Urho3D and Fabulous (Note: because this is an external sample it may not be up-to-date with the latest version of this library.)

The external sample [Fabulous + GraphQL Type Provider](https://github.com/fsprojects/FSharp.Data.GraphQL/tree/dev/samples/star-wars-fabulous-client) is a small app that demonstrates how to use the type provider for GraphQL [FSharp.Data.GraphQL](https://github.com/fsprojects/FSharp.Data.GraphQL).

See also the curated list [Awesome Fabulous](https://github.com/jimbobbennett/Awesome-Fabulous).

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
* [Emulator](https://docs.microsoft.com/en-us/xamarin/ios/get-started/hello-ios/hello-ios-quickstart)
* [Pair to Mac](https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/windows/connecting-to-mac/)
* [Device](https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/device-provisioning/)

Contributing
------

Please contribute to this library through issue reports, pull requests, code reviews and discussion.

* [Submit a fix to this guide](https://github.com/fsprojects/Fabulous/tree/master/docs)

