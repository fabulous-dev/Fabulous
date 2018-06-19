F# Functional App Development, using Xamarin.Forms 
=======

[![NuGet version](https://badge.fury.io/nu/Elmish.XamarinForms.svg)](https://badge.fury.io/nu/Elmish.XamarinForms) [![Build status (Windows)](https://ci.appveyor.com/api/projects/status/4qajefd4c6sbjfrt/branch/master?svg=true)](https://ci.appveyor.com/project/dsyme/elmish-xamarinforms/branch/master)  [![Build status (OSX)](https://ci.appveyor.com/api/projects/status/4qajefd4c6sbjfrt/branch/master?svg=true)](https://travis-ci.org/fsprojects/Elmish.XamarinForms.svg?branch=master) [![Gitter chat](https://badges.gitter.im/gitterHQ/gitter.png)](https://gitter.im/fsprojects/Elmish.XamarinForms)

Never write a ViewModel class again!  Conquer the world with clean dynamic UIs!

This library uses a variation of [elmish](https://elmish.github.io/), an Elm architecture implemented in F#, to build Xamarin.Forms applications for iOS, Android, Mac and more. Elmish was originally written for [Fable](https://github.com/fable-compiler) applications, however it is used here for mobile applications using Xamarin.Forms. This is a sample and may change.

To quote [@dsyme](http://github.com/dsyme):

> In my work for Xamarin, I'm asking myself "what will appeal to F# devs who want to do Xamarin programming?". These devs are very code-oriented and know F#.  People are liking Elm and React via [Elmish](https://elmish.github.io/elmish/) and also React Native. Can we apply some of the lessons to Xamarin programming?

* [Getting started](#getting=started)

* [Documentation Guide](https://github.com/fsprojects/Elmish.XamarinForms/blob/master/docs/guide.md)

* [Roadmap/TODOs](https://github.com/fsprojects/Elmish.XamarinForms/blob/master/ROADMAP.md)

* [Contributor guide](DEVGUIDE.md)

Getting started
------

1. Create a blank F# Xamarin Forms app in Visual Studio or Visual Studio Code.  Make sure your shared code is an F# .NET Standard 2.0 Library project. 
2. Add nuget package `Elmish.XamarinForms` to to your shared code project.
3. Put the sample code below in your shared app library

Alternatively clone and adapt the [Simple Calculator Project](https://github.com/nosami/Elmish.Calculator).

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
    
/// The funtion to update the view
let update (msg:Msg) (model:Model) =
    match msg with
    | Pressed -> { model with Pressed = true }

/// The view function giving updated content for the page
let view (model: Model) dispatch =
    if model.Pressed then 
        Xaml.Label(text="I was pressed!")
    else
        Xaml.Button(text="Press Me!", command=(fun () -> dispatch Pressed))

type App () = 
    inherit Application ()

    let runner = 
        Program.mkSimple init update view
        |> Program.withConsoleTrace
        |> Program.withDynamicView
        |> Program.run
```
The init function returns your initial state, and each model gets an update function for message processing. The `view` function computes an immutable Xaml-like description. In the above example, the choice between a label and button depends on the `model.Pressed` value.

Some advantages of using an immutable model are:

* It is easy to unit test your `init`, `update` and `view` functions
* You can save/restore your model relatively easily
* It makes tracing causality usually very simple


Example Views
------

The sample [CounterApp](https://github.com/fsprojects/Elmish.XamarinForms/blob/master/Samples/CounterApp/CounterApp/CounterApp.fs) contains a slightly larger example of Button/Label/Slider controls.

The sample [AllControls](https://github.com/fsprojects/Elmish.XamarinForms/blob/master/Samples/AllControls/AllControls/AllControls.fs) contains examples of instantiating most controls in `Xamarin.Forms.Core`.

Screenshots from Anrdoid (Google Pixel):

<img src="https://user-images.githubusercontent.com/7204669/39318922-57c95174-4977-11e8-94a9-cc385101ce5d.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318926-59f844e6-4977-11e8-9834-325a6517ced6.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318929-5b66c776-4977-11e8-8317-ee1c121301d4.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318934-5cbe3c3a-4977-11e8-92aa-c3fdf644b01c.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318936-5e2380bc-4977-11e8-8912-f078744a2bde.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318938-5f6ec4f4-4977-11e8-97a9-779edd3594bc.png" width="100"> <img src="https://user-images.githubusercontent.com/7204669/39318941-60c1b0f0-4977-11e8-8a4a-57e17ef8c6ec.png" width="100">

## Dynamic Views

Dynamic `view` functions are written using an F# DSL, see ``Elmish.XamarinForms.DynamicViews``.
Dynamic Views excel in cases where the existence, characteristics and layout of the view depends on information in the model. React-style differential update is used to update the Xamarin.Forms display based on the previous and current view descriptions.

## Static Views and "Half Elmish"

In some circumstances there are advantages to using static Xaml, and static bindings from the model to those views. This is called "Half Elmish" and is the primary technique used by [`Elmish.WPF`](https://github.com/Prolucid/Elmish.WPF) at time of writing. (It was also  the original technique used by this repo and the prototype `Elmish.Forms`).   

See [docs/half-elmish.md](docs/half-elmish.md)

## Contributing

Please contribute to this library through issue reports, pull requests, code reviews and discussion.

Credits
-----
This library is inspired by [Elmish.WPF](https://github.com/Prolucid/Elmish.WPF), [Elmish.Forms](https://github.com/dboris/elmish-forms) and [elmish](https://github.com/elmish/elmish), written by [et1975](https://github.com/et1975). This project technically has no tie to [Fable](http://fable.io/), which is an F# to JavaScript transpiler that is definitely worth checking out.

