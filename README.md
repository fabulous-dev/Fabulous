# <img src="logo/logo-title.png" height="120px" alt="Fabulous" />

*F# Functional App Development, using declarative dynamic UI*

 [![Build Status](https://dev.azure.com/timothelariviere/Fabulous/_apis/build/status/Full%20Build?branchName=master)](https://dev.azure.com/timothelariviere/Fabulous/_build/latest?definitionId=7&branchName=master) [![Fabulous.XamarinForms NuGet version](https://badge.fury.io/nu/Fabulous.XamarinForms.svg)](https://badge.fury.io/nu/Fabulous.XamarinForms) [![Join the chat at https://gitter.im/fsprojects/Fabulous](https://badges.gitter.im/fsprojects/Fabulous.svg)](https://gitter.im/fsprojects/Fabulous?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

Never write a ViewModel class again! Conquer the world with clean dynamic UIs!

Fabulous allows you to combine the power of functional programming (F#) and the ultra-simple Model-View-Update architecture to build any kind of mobile and desktop applications with an expressive, dynamic and clean UI DSL. Go cross-platform with Fabulous for Xamarin.Forms and target iOS, Android, Mac, WPF and more!

## Documentation

* [Getting started](https://fsprojects.github.io/Fabulous/Fabulous.XamarinForms/index.html#getting-started)

* [Fabulous documentation](https://fsprojects.github.io/Fabulous/)

* [Contributing to Fabulous](.github/GETTING_STARTED.md)

See also the [release notes](RELEASE_NOTES.md) of the current version and [roadmap](ROADMAP.md) for the future of Fabulous.

## About Fabulous

This library aims to provide all the core abstractions and tools for writing your own app framework based on the "[model view update](https://guide.elm-lang.org/architecture/)" programming model and dynamic UI. It is a variation of [Elmish](https://elmish.github.io/), an Elm architecture implemented in F#.

[Learn more about Fabulous](FABULOUS.md)

With Fabulous for Xamarin.Forms, you will be able to write complete applications fully in F#, like this:
```fsharp
type Model = { Text: string }
type Msg = ButtonClicked

let init () = { Text = "Hello Fabulous!" }

let update msg model =
    match msg with
    | ButtonClicked -> { model with Text = "Thanks for using Fabulous!" }

let view model dispatch =
    View.ContentPage(
        View.StackLayout(
            children = [
                View.Image(source = Image.fromPath "fabulous.png")
                View.Label(text = model.Text)
                View.Button(text = "Click me", command = fun () -> dispatch ButtonClicked)
            ]
        )
    )
```

[Learn more about Fabulous for Xamarin.Forms](https://github.com/fsprojects/Fabulous/tree/master/Fabulous.XamarinForms)

## They use it

<img alt="Tawasal" src="docs/assets/apps-using-fabulous/tawasal/logo.png" height="75" />

### Tawasal - [https://tawasal.ae](https://tawasal.ae)

Tawasal is a secure multi-purpose messenger and superapp, offering free voice, text, videoconferencing and lifestyle services to clients around the world.  
[Learn more about Tawasal](https://fsprojects.github.io/Fabulous/Fabulous.XamarinForms/they-use-it.html#Tawasal)

## Credits
This repository is inspired by [Elmish.WPF](https://github.com/Prolucid/Elmish.WPF), [Elmish.Forms](https://github.com/dboris/elmish-forms) and [elmish](https://github.com/elmish/elmish).
