# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

_No unreleased changes_

## [2.4.1] - 2024-01-29

### Added
- Add Cmd.debounce to issue a message if no other message has been issued within the specified timeout by @TimLariviere (https://github.com/fabulous-dev/Fabulous/pull/1062)

## [2.4.0] - 2023-08-07

### Changed
- Remove ambiguity when declaring event attributes by using MsgValue instead of obj by @TimLariviere (https://github.com/fabulous-dev/Fabulous/pull/1047)

## [2.3.2] - 2023-06-01

### Changed
- view function now runs only on the UI thread by @TimLariviere (https://github.com/fabulous-dev/Fabulous/pull/1043)

## [2.3.1] - 2023-05-22

### Fixed
- Fix an issue in `MutStackArray1.combineMut` that could result in a crash by @TimLariviere (https://github.com/fabulous-dev/Fabulous/pull/1042)

## [2.3.0] - 2023-03-17

### Added
- Add support for float32 properties by @kevkov (https://github.com/fabulous-dev/Fabulous/pull/1041)

## [2.2.1] - 2023-02-01

### Fixed
- Fix a NullReferenceException when applying `View.map` to a view using `Unit` Msg type by @TimLariviere (https://github.com/fabulous-dev/Fabulous/pull/1037) 

## [2.2.0] - 2023-01-24

### Added
- Enable ViewAdapter to attach to an existing view (https://github.com/fabulous-dev/Fabulous/pull/1026)
- Support for adding modifiers before the body of a CollectionBuilder (https://github.com/fabulous-dev/Fabulous/pull/1035)

## [2.2.0-preview.1] - 2022-11-17

### Added
- Enable ViewAdapter to attach to an existing view (https://github.com/fabulous-dev/Fabulous/pull/1026)

## [2.1.1] - 2023-01-14

### Changed
- Fabulous.XamarinForms & Fabulous.MauiControls have been moved been out of the Fabulous repository. Find them in their own repositories: [https://github.com/fabulous-dev/Fabulous.XamarinForms](https://github.com/fabulous-dev/Fabulous.XamarinForms) / [https://github.com/fabulous-dev/Fabulous.MauiControls](https://github.com/fabulous-dev/Fabulous.MauiControls)

[unreleased]: https://github.com/fabulous-dev/Fabulous/compare/2.4.1...HEAD
[2.4.1]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.4.1
[2.4.0]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.4.0
[2.3.2]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.3.2
[2.3.1]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.3.1
[2.3.0]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.3.0
[2.2.1]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.2.1
[2.2.0]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.2.0
[2.2.0-preview.1]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.2.0-preview.1
[2.1.1]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.1.1
