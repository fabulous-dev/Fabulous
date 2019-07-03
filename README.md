Fabulous - F# Functional App Development, using declarative dynamic UI
=======

 [![Build Status](https://dev.azure.com/timothelariviere/Fabulous/_apis/build/status/Full%20Build?branchName=master)](https://dev.azure.com/timothelariviere/Fabulous/_build/latest?definitionId=7&branchName=master) [![Join the chat at https://gitter.im/fsprojects/Fabulous](https://badges.gitter.im/fsprojects/Fabulous.svg)](https://gitter.im/fsprojects/Fabulous?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

Never write a ViewModel class again! Conquer the world with clean dynamic UIs!

This repository contains 3 differents libraries:

Package | NuGet
---|---
Fabulous | [![Fabulous NuGet version](https://badge.fury.io/nu/Fabulous.svg)](https://badge.fury.io/nu/Fabulous)  
Fabulous.XamarinForms | [![Fabulous.XamarinForms NuGet version](https://badge.fury.io/nu/Fabulous.XamarinForms.svg)](https://badge.fury.io/nu/Fabulous.XamarinForms)  
Fabulous.StaticView | [![Fabulous.StaticView NuGet version](https://badge.fury.io/nu/Fabulous.StaticView.svg)](https://badge.fury.io/nu/Fabulous.StaticView)

## Fabulous

This library aims to provide all the core abstractions and tools for writing your own app framework based on the "[model view update](https://guide.elm-lang.org/architecture/)" programming model and dynamic UI. It is a variation of [elmish](https://elmish.github.io/), an Elm architecture implemented in F#.

[Learn more about Fabulous](FABULOUS.md)

## Fabulous for Xamarin.Forms

This library allows you to use the ultra-simple Model-View-Update architecture to build applications for iOS, Android, Mac, WPF and more using Xamarin.Forms. It is built on Fabulous.

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
            children=[
                View.Image(source = "fabulous.png")
                View.Label(text = model.Text, fontSize = 22.)
                View.Button(text = "Click me", command = (fun () -> dispatch ButtonClicked))
            ]
        )
    )
```

[Learn more about Fabulous for Xamarin.Forms](https://github.com/fsprojects/Fabulous/tree/master/Fabulous.XamarinForms)

## Fabulous StaticView

This library allows you to write Xamarin.Forms apps using XAML and the Model-View-Update architecture.

It is not actively maintained.  
If you wish to see more support for Fabulous.StaticView, please consider contributing.

[Learn more about Fabulous StaticView](https://github.com/fsprojects/Fabulous/tree/master/Fabulous.StaticView)

## Links

* [Getting started](https://fsprojects.github.io/Fabulous/index.html#getting=started)

* [Documentation Guide](https://fsprojects.github.io/Fabulous/guide.html)

* [Roadmap](https://github.com/fsprojects/Fabulous/blob/master/ROADMAP.md)

* [Contributor guide](DEVGUIDE.md)

* [Release Notes](RELEASE_NOTES.md)

## Contributing

Please contribute to this library through issue reports, pull requests, code reviews and discussion.

Credits
-----
This library is inspired by [Elmish.WPF](https://github.com/Prolucid/Elmish.WPF), [Elmish.Forms](https://github.com/dboris/elmish-forms) and [elmish](https://github.com/elmish/elmish).