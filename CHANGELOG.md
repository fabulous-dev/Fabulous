# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

_No unreleased changes_

## [3.0.0-pre23] - 2025-06-05

### Changed
- Ensure old widgets are disposed when replaced by new ones by @TimLariviere in https://github.com/fabulous-dev/Fabulous/pull/1105

## [3.0.0-pre22] - 2025-05-18

### Changed
- Optimize `Array.fs` by @kerams in https://github.com/fabulous-dev/Fabulous/pull/1103
- Use `task` CE for task commands by @kerams in https://github.com/fabulous-dev/Fabulous/pull/1104

## [3.0.0-pre21] - 2025-04-07

### Added
- Add YieldFrom to CollectionBuilder by @kerams in https://github.com/fabulous-dev/Fabulous/pull/1098

## [3.0.0-pre20] - 2025-02-28

### Changed
- Optimize diffing by @kerams in https://github.com/fabulous-dev/Fabulous/pull/1097
- Target net8 to fix `AttributeTargets` incompatibilities. by @edgarfgp in https://github.com/fabulous-dev/Fabulous/pull/1101

## [3.0.0-pre19] - 2025-01-16

### Changed
- Avoid memory allocation while writing logs in EnvironmentContext by @TimLariviere

## [3.0.0-pre18] - 2025-01-16

### Changed
- Improve memory usage by @kerams (https://github.com/fabulous-dev/Fabulous/pull/1095)

## [3.0.0-pre17] - 2024-12-15

### Changed
- Remove `match struct` by @kerams
- Refactor `EnumerationMode` by @kerams

## [3.0.0-pre16] - 2024-11-22

### Changed
- Small optimization when building for AOT by @TimLariviere

### Removed
- Removed `SingleChildBuilder` due to its big impact on AOT compilation compared to the low benefits on development experience by @TimLariviere

## [3.0.0-pre15] - 2024-11-21

### Added
- Unwrap EnvironmentAttributeKey for logging by @TimLariviere

## [3.0.0-pre14] - 2024-11-21

### Added
- Unwrap EnvironmentAttributeKey for logging by @TimLariviere

## [3.0.0-pre13] - 2024-11-21

### Added
- Add IDisposable to EnvironmentObject by @TimLariviere

## [3.0.0-pre12] - 2024-11-20

### Added
- Add support for multiple environment modifiers on the same widget by @TimLariviere

## [3.0.0-pre11] - 2024-11-16

### Changed
- Replaced printfn statements with Logger.Log(Debug)

## [3.0.0-pre10] - 2024-11-14

### Changed
- Moved attribute definition functions specific to Mvu/Component into dedicated modules by @TimLariviere

## [3.0.0-pre9] - 2024-11-08

### Fixed
- Fixed an issue where using Cmd in init would not refresh the view by @TimLariviere

## [3.0.0-pre8] - 2024-11-07

### Changed
- Replaced custom MvuComponentBuilder with a Mvu binding by @TimLariviere

### Fixed
- Fixed an invalid cast exception when using a null or unit model with MVU in Component by @TimLariviere 

## [3.0.0-pre7] - 2024-09-28

### Fixed
- Fixed an issue where a modifier applied on a Component itself would not be applied correctly

## [3.0.0-pre6] - 2024-09-24

### Changed
- Add equality constraint on 'msg to prevent confusion with new non-MVU modifiers by @TimLariviere https://github.com/fabulous-dev/Fabulous/pull/1084

## [3.0.0-pre5] - 2024-05-17

### Added
- Add new `CollectionBuilder` constructor using an `AttributesBundle` by @edgarfgp in https://github.com/fabulous-dev/Fabulous/pull/1081

## [3.0.0-pre4] - 2024-04-19

### Added
- Add `defineEventNoDispatch` by @edgarfgp in https://github.com/fabulous-dev/Fabulous/pull/1077

### Fixed
- Fix ScalarAttributes data key lookup by @edgarfgp in https://github.com/fabulous-dev/Fabulous/pull/1076
- Fix bindings + 1 to increment the key when using a Binding by @edgarfgp in https://github.com/fabulous-dev/Fabulous/pull/1078

## [3.0.0-pre3] - 2024-04-12

### Changed
- Find the component data key in the attribute keys (https://github.com/fabulous-dev/Fabulous/pull/1075)

## [3.0.0-pre2] - 2024-03-025

### Added
- Add support for Binding in Components (https://github.com/fabulous-dev/Fabulous/pull/1074)

## [3.0.0-pre1] - 2024-03-01

### Changed
- Bump version te 2.5.0-pre11 to 3.0.0-pre1

## [2.5.0-pre11] - 2024-02-19

### Fixed
- Recreate component on arg change by @TimLariviere (https://github.com/fabulous-dev/Fabulous/pull/1069)

## [2.5.0-pre10] - 2024-02-19

### Fixed
- Lock access to fn in Cmd.debounce to avoid null crash by @TimLariviere (https://github.com/fabulous-dev/Fabulous/pull/1068)

## [2.5.0-pre9] - 2024-02-12

### Fixed
- Improve handling of messages after Runner gets disposed

## [2.5.0-pre8] - 2024-01-30

### Changed
- Dispose properly ViewNode and Component when Widget is removed from tree by @TimLariviere (https://github.com/fabulous-dev/Fabulous/pull/1066)

## [2.5.0-pre7] - 2024-01-30

### Added
- Add SyncAction by @edgarfgp (https://github.com/fabulous-dev/Fabulous/pull/1064)

## [2.5.0-pre6] - 2024-01-29

### Added
- Add Cmd.debounce to issue a message if no other message has been issued within the specified timeout by @TimLariviere (https://github.com/fabulous-dev/Fabulous/pull/1062)

## [2.5.0-pre5] - 2024-01-20

### Added
- Add support for Component in frameworks requiring AttachView (like Fabulous.Avalonia) by @TimLariviere (https://github.com/fabulous-dev/Fabulous/pull/1059)

## [2.5.0-pre4] - 2024-01-18

### Changed
- Couple of changes and fixes to the new Component API by @TimLariviere (https://github.com/fabulous-dev/Fabulous/pull/1057)

## [2.5.0-pre3] - 2024-01-16

### Changed
- Consolidation of the new Component API and the existing ViewAdapter by @TimLariviere (https://github.com/fabulous-dev/Fabulous/pull/1056)

## [2.5.0-pre2] - 2023-11-22

### Changed
- Couple of changes to the new Component API

## [2.5.0-pre1] - 2023-11-22

### Added
- Add new Component API by @TimLariviere (https://github.com/fabulous-dev/Fabulous/pull/1051)

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

[unreleased]: https://github.com/fabulous-dev/Fabulous/compare/3.0.0-pre23...HEAD
[3.0.0-pre23]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre23
[3.0.0-pre22]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre22
[3.0.0-pre21]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre21
[3.0.0-pre20]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre20
[3.0.0-pre19]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre19
[3.0.0-pre18]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre18
[3.0.0-pre17]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre17
[3.0.0-pre16]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre16
[3.0.0-pre15]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre15
[3.0.0-pre14]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre14
[3.0.0-pre13]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre13
[3.0.0-pre12]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre12
[3.0.0-pre11]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre11
[3.0.0-pre10]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre10
[3.0.0-pre9]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre9
[3.0.0-pre8]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre8
[3.0.0-pre7]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre7
[3.0.0-pre6]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre6
[3.0.0-pre5]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre5
[3.0.0-pre4]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre4
[3.0.0-pre3]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre3
[3.0.0-pre2]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre2
[3.0.0-pre1]: https://github.com/fabulous-dev/Fabulous/releases/tag/3.0.0-pre1
[2.5.0-pre11]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.5.0-pre11
[2.5.0-pre10]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.5.0-pre10
[2.5.0-pre9]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.5.0-pre9
[2.5.0-pre8]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.5.0-pre8
[2.5.0-pre7]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.5.0-pre7
[2.5.0-pre6]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.5.0-pre6
[2.5.0-pre5]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.5.0-pre5
[2.5.0-pre4]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.5.0-pre4
[2.5.0-pre3]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.5.0-pre3
[2.5.0-pre2]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.5.0-pre2
[2.5.0-pre1]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.5.0-pre1
[2.4.1]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.4.1
[2.4.0]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.4.0
[2.3.2]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.3.2
[2.3.1]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.3.1
[2.3.0]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.3.0
[2.2.1]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.2.1
[2.2.0]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.2.0
[2.2.0-preview.1]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.2.0-preview.1
[2.1.1]: https://github.com/fabulous-dev/Fabulous/releases/tag/2.1.1
