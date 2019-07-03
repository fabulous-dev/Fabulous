Fabulous - F# Functional App Development library with declarative dynamic UI support
=======

 [![Fabulous NuGet version](https://badge.fury.io/nu/Fabulous.svg)](https://badge.fury.io/nu/Fabulous)

This library aims to provide all the core abstractions and tools for writing your own app framework based on the "[model view update](https://guide.elm-lang.org/architecture/)" programming model and dynamic UI. It is a variation of [elmish](https://elmish.github.io/), an Elm architecture implemented in F#.

**Key elements**
- ViewElement

A core type on which to build your View API (e.g. `View.Button(text = "Hello world")`) for your own framework. This type will be used in the diffing process to only update controls that actually changed between 2 view updates.

- Generator

A tool that will generate Fabulous-compatible wrappers to enable using existing controls (or components libraries) with a dynamic UI code. It can be configured to change how the wrappers are generated.  
Fabulous.XamarinForms uses it to generate all of its View API.

- LiveUpdate / fabulous-cli  
*(Still in early development)*

A combo of a dotnet CLI tool and a plugin for Fabulous. They enable your users to write their apps and see live their changes in the running emulator / real device without restarting.  
It is similar to the Hot Reload module of Flutter.

## Links

* [Getting started](https://fsprojects.github.io/Fabulous/index.html#getting=started)

* [Documentation Guide](https://fsprojects.github.io/Fabulous/guide.html)

* [Roadmap](ROADMAP.md)

* [Release Notes](RELEASE_NOTES.md)

## Contributing

Please contribute to this library through issue reports, pull requests, code reviews and discussion.