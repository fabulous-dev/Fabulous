Fabulous
=======

*F# Functional App Development library with declarative dynamic UI support*

 [![Fabulous NuGet version](https://badge.fury.io/nu/Fabulous.svg)](https://badge.fury.io/nu/Fabulous) [![Build Status](https://dev.azure.com/timothelariviere/Fabulous/_apis/build/status/Full%20Build?branchName=master)](https://dev.azure.com/timothelariviere/Fabulous/_build/latest?definitionId=7&branchName=master) [![Join the chat at https://gitter.im/fsprojects/Fabulous](https://badges.gitter.im/fsprojects/Fabulous.svg)](https://gitter.im/fsprojects/Fabulous?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

This library aims to provide all the core abstractions and tools for writing your own app framework based on the "[model view update](https://guide.elm-lang.org/architecture/)" programming model and dynamic UI. It is a variation of [elmish](https://elmish.github.io/), an Elm architecture implemented in F#.

* [Documentation](https://fsprojects.github.io/Fabulous/Fabulous/)

* [Release Notes](RELEASE_NOTES.md)

## Key elements
- ViewElement

A core type on which to build your View API (e.g. `View.Button(text = "Hello world")`) for your own framework. This type will be used in the diffing process to only update controls that actually changed between 2 view updates.

- Generator

A tool that will generate Fabulous-compatible wrappers to enable using existing controls (or components libraries) with a dynamic UI code. It can be configured to change how the wrappers are generated.  
Fabulous.XamarinForms uses it to generate all of its View API.

- LiveUpdate / fabulous-cli  
*(Still in early development)*

A combo of a dotnet CLI tool and a plugin for Fabulous. They enable your users to write their apps and see live their changes in the running emulator / real device without restarting.  
It is similar to the Hot Reload module of Flutter.

## Roadmap

* Programming model: 
  * Move to `seq<_>` as the de-facto model type
  * Compute the delta between previous and current model in a platform-agnostic way (would allow to support other frameworks like Avalonia or Uno)
  
* Support for external libraries
  * Make the code generator work with components libraries (like SyncFusion or Telerik for Xamarin.Forms)
  * Add a bindings generator to automate extraction of every controls/properties/events in a format readable by the code generator (easier to update with Xamarin.Forms, easier to use other components libraries)

* Docs
  * Generate `///` docs in code generator

* Live Reload
  * State migration: Support hot-reloading of the saved model, reapplying to the same app where possible

* Performance:
  * Consider possibilities for better list comparison/diffing
  * Do more perf-test on large lists and do resulting perf work
  * Consider allowing a `ChunkList` tree as input to ListView etc., e.g. `chunks { yield! stablePart; yield newElement; yield! stablePart2 }` 
  * Consider memoize function closure creation
  * Consider moving 'view' and 'model' computations off the UI thread

* Consider making  some small F# language improvements to improve code:
  * Remove `yield` in more cases
  * Automatically save function values that do not capture any arguments
  * Allow a default unnamed argument for `children` so the argument name doesn't have to be given explicitly
  * Allow the use of struct options for optional arguments (to reduce allocations)
  * Implement the C# 5.0 "open static classes" feature in F# to allow the `View.` prefix to be dropped

* Discarded ideas
  * Possibly switch to a type provider (see [this comment](https://github.com/fsprojects/Fabulous/issues/50#issuecomment-390396365))

## Contributing

Please contribute to this library through issue reports, pull requests, code reviews and discussion.
