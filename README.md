Fabulous - F# Functional App Development, using declarative dynamic UI
=======

 [![Build Status](https://dev.azure.com/timothelariviere/Fabulous/_apis/build/status/Full%20Build?branchName=master)](https://dev.azure.com/timothelariviere/Fabulous/_build/latest?definitionId=7&branchName=master) [![Join the chat at https://gitter.im/fsprojects/Fabulous](https://badges.gitter.im/fsprojects/Fabulous.svg)](https://gitter.im/fsprojects/Fabulous?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

Never write a ViewModel class again! Conquer the world with clean dynamic UIs!

Package | NuGet
---|---
Fabulous | [![Fabulous NuGet version](https://badge.fury.io/nu/Fabulous.svg)](https://badge.fury.io/nu/Fabulous)  
Fabulous.XamarinForms | [![Fabulous.XamarinForms NuGet version](https://badge.fury.io/nu/Fabulous.XamarinForms.svg)](https://badge.fury.io/nu/Fabulous.XamarinForms)  
Fabulous.StaticView | [![Fabulous.StaticView NuGet version](https://badge.fury.io/nu/Fabulous.StaticView.svg)](https://badge.fury.io/nu/Fabulous.StaticView)

This repository contains 3 differents libraries:
- Fabulous
- Fabulous for Xamarin.Forms
- Fabulous StaticView

### Fabulous

This library aims to provide all the core abstractions and tools for writing your own app framework based on "[model view update](https://guide.elm-lang.org/architecture/)" programming model and dynamic UI. It is a variation of [elmish](https://elmish.github.io/), an Elm architecture implemented in F#.

**Key elements of Fabulous:**
- ViewElement

A core type on which to build your View DSL for your framework. This type will be used in the diffing process to only update controls that actually changed between 2 view updates.

- Generator

An external tool that will generate Fabulous-compatible wrappers to enable using existing controls (or components libraries) with a dynamic UI code. This tool is configured with a bindings json file.  
Fabulous.XamarinForms uses it to generate all of its View DSL.

- LiveUpdate / fabulous-cli

A combo of a dotnet CLI tool and a plugin for Fabulous. They enable your users to write their apps and see live their changes in the running emulator / real device without restarting.  
It is similar to the Hot Reload module of Flutter.

### Fabulous for Xamarin.Forms

This library allows you to use the ultra-simple Model-View-Update architecture to build applications for iOS, Android, Mac, WPF and more using Xamarin.Forms. It is built on Fabulous.

### Fabulous StaticView

This library allows you to write Xamarin.Forms apps using XAML and the Model-View-Update architecture.

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
This library is inspired by [Elmish.WPF](https://github.com/Prolucid/Elmish.WPF), [Elmish.Forms](https://github.com/dboris/elmish-forms) and [elmish](https://github.com/elmish/elmish), written by [et1975](https://github.com/et1975). This project technically has no tie to [Fable](http://fable.io/), which is an F# to JavaScript transpiler that is great.
