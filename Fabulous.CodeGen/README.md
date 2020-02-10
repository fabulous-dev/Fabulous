Fabulous CodeGen
=======

*Automatically generate bindings to use your favorite UI framework with Fabulous*

[![Fabulous.CodeGen NuGet version](https://badge.fury.io/nu/Fabulous.CodeGen.svg)](https://badge.fury.io/nu/Fabulous.CodeGen) [![Build Status](https://dev.azure.com/timothelariviere/Fabulous/_apis/build/status/Full%20Build?branchName=master)](https://dev.azure.com/timothelariviere/Fabulous/_build/latest?definitionId=7&branchName=master) [![Join the chat at https://gitter.im/fsprojects/Fabulous](https://badges.gitter.im/fsprojects/Fabulous.svg)](https://gitter.im/fsprojects/Fabulous?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

This library automates the creation of UI frameworks bindings for Fabulous through a simple JSON file. CodeGen will output an F# code file that you can include in your own project, like Fabulous for Xamarin.Forms.

It can be easily included in a build process, or run manually through a command line.

For more information, please take a look at the documentation.

* [Documentation](https://fsprojects.github.io/Fabulous/Fabulous.CodeGen/)

* [Release Notes](../RELEASE_NOTES.md)

## Roadmap

* Make it compatible with 3rd party libraries
   * Add support for referencing existing mapping file to allow inheritance of existing bindings

* Add support for 2 new modes, so it can be run by anyone to generate bindings on any given dll
   * `generate-mapping`: Generate the JSON mapping file with all controls and properties
   * `bind`: Generate the F# bindings code for a given mapping file

* Docs
  * Generate better `///` docs

## Contributing

Please contribute to this library through issue reports, pull requests, code reviews and discussion.
