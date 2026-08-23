# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

_No unreleased changes_

## [8.1.0-pre17] - 2024-03-26

### Fixed
- Use Fabulous 3.0.0-pre2

## [8.1.0-pre16] - 2024-03-25

### Changed
- Use Fabulous 3.0.0-pre2

## [8.1.0-pre15] - 2024-04-02

### Changed
- Set correct VersionOverride

## [8.1.0-pre14] - 2024-03-02

### Changed
- Use Fabulous 3.0.0-pre1

## [8.1.0-pre13] - 2024-02-26

### Added
- Add support for `Window` widget by @TimLariviere (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/62)

## [8.1.0-pre12] - 2024-02-19

### Changed
- Use Fabulous 2.5.0-pre11

## [8.1.0-pre11] - 2024-02-19

### Changed
- Use Fabulous 2.5.0-pre10

## [8.1.0-pre10] - 2024-02-12

### Changed
- Use Fabulous 2.5.0-pre9

## [8.1.0-pre9] - 2024-01-30

### Changed
- Use Fabulous 2.5.0-pre8

## [8.1.0-pre8] - 2024-01-30

### Changed
- Use Fabulous 2.5.0-pre7

## [8.1.0-pre7] - 2024-01-29

### Changed
- Use Fabulous 2.5.0-pre6

## [8.1.0-pre6] - 2024-01-20

### Changed
- Use Fabulous 2.5.0-pre5

## [8.1.0-pre5] - 2024-01-18

### Changed
- Use Fabulous 2.5.0-pre4

## [8.1.0-pre4] - 2024-01-16

### Changed
- Use Fabulous 2.5.0-pre3

## [8.1.0-pre3] - 2024-01-10

### Changed
- Include changes from 8.0.3, 8.0.4 and 8.0.5

## [8.1.0-pre2] - 2023-12-12

### Changed
- Changes to components

## [8.1.0-pre1] - 2023-11-22

### Added
- Add new Component API by @TimLariviere (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/49)

## [8.0.5] - 2024-01-10

### Changed
- Additional performance optimizations by @TimLariviere (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/55)

## [8.0.4] - 2024-01-08

### Changed
- Avoid allocating a new ImageSource instance on each update by using specialized attributes for each value type by @TimLariviere (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/54)

## [8.0.3] - 2024-01-03

### Fixed
- Fixed a crash related to back navigation in NavigationPage

## [8.0.2] - 2023-12-12

### Added
- Added additional Any widgets to support Memo widget as a root by @TimLariviere (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/52)
- Added missing Cell.ContextActions and MultiPage.CurrentPage modifiers by @TimLariviere (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/52)

## [8.0.1] - 2023-11-14

### Fixed
- Remove call to Android's Resource.UpdateIdValues in the template since it's no longer available in .NET MAUI 8.0 (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/48)

## [8.0.0] - 2023-11-14

IMPORTANT: Fabulous.MauiControls will now follow the same versioning as .NET MAUI to reflect the dependency on a specific version of .NET MAUI.  
Essentially v2.8.1 and v8.0.0 are similar except for the required .NET version.

### Changed
- Target .NET 8.0 (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/47)

### Added
- Add missing `ignoreSafeArea` modifier to layout widgets (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/47)

## [2.8.1] - 2023-10-22

### Fixed
- Check the focus state of the target before calling focus/unfocus by @TimLariviere (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/43)
- Fix crash when dispatching a message after an event occurred by @TimLariviere (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/44)

## [2.8.0] - 2023-08-08

### Changed
- Remove ambiguity when declaring event attributes by using MsgValue instead of obj by @edgarfgp (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/42)

## [2.7.0] - 2023-06-01

### Added
- Add gestureRecognizer shorthand modifier @edgarfgp https://github.com/fabulous-dev/Fabulous.MauiControls/pull/39

## [2.6.0] - 2023-05-22

### Changed
- Update Fabulous dependency to 2.3.0 < 2.4.0 supported

## [2.5.1] - 2023-03-30

### Added
- Add modifier `onAppLinkRequestReceived` to `Application` widget by @TimLariviere (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/34)

## [2.5.0] - 2023-03-06

### Fixed
- Fix an issue where adding pages inside a TabbedPage was not allowed by @edgarfgp (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/30)

### Changed
- `minimumDate` and `maximumDate` modifiers for DatePicker are removed in favor of mandatory min-max parameters in DatePicker constructor by @TimLariviere (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/31)

## [2.4.0] - 2023-02-27

### Added
- Add Border constructor taking only a content widget by @TimLariviere (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/28)
- Add Border stroke modifiers by @TimLariviere (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/28)

### Changed
- Change IndicatorView.maximumVisible and RefreshView.refreshColor to support inheritance by @TimLariviere (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/29)

### Removed
- Remove FabColor and all related modifiers in favor of Microsoft.Maui.Graphics.Color by @TimLariviere (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/27)
- Remove Border constructors taking stroke values to align with other Shape widgets by @TimLariviere (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/28)

## [2.3.2] - 2023-02-10

### Fixed
- Make sure Info.plist is not ignored during build by @TimLariviere (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/22)

## [2.3.1] - 2023-02-09

### Added
- Add missing RoundRectangle widget
- Add alternative `.size(uniformSize)` modifier to all widgets

### Fixed
- Fix wrong attribute definitions for some FabColor modifiers
- Fix crash in NavigationPage when pushing a new page

### Removed
- Remove unneeded default Border stroke shape
- Remove alternative Color/FabColor for Brush modifiers

## [2.3.0] - 2023-02-09

### Added
- Add attributes for both `Microsoft.Maui.Graphics.Color` and `Fabulous.Maui.FabColor` for all Color and Brush modifiers
- Add alternative Brush modifiers to accept either `Microsoft.Maui.Graphics.Brush` or a Brush widget
- Add XML documentation for all widgets and modifiers
- Add new `GraphicsView` widget
- Add ThemeAware support by @TimLariviere (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/19)

### Fixed
- Fix the crash at startup when targeting Windows by using FSharp.Maui.WinUICompat by @TimLariviere (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/10)
- Fix an issue where template could enumerate the whole disk to add under the Android target folder by @Smaug123 (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/9)
- Write a custom NavigationPage to use synchronous push/pop and call Mounted/Unmounted events on pages by @TimLariviere (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/13)
- Fix widgets and modifiers where `Microsoft.Maui.IView` was requested instead of `Fabulous.Maui.IFabView`

### Removed
- Remove obsolete widgets and modifiers
- Remove AppTheme modifiers in favor of ThemeAware
- Remove Color modifiers when Brush modifiers are available (eg. BackgroundColor -> Background)
- Remove Frame widget in favor of Border widget

## [2.2.0] - 2023-01-24

### Changed
- Rename all marker interfaces to IFab* to avoid naming conflicts with Maui interfaces (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/5)
- Fix an issue where FlexLayout was not usable (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/6)
- Upgrade to Fabulous 2.2.0 (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/8)

## [2.1.3] - 2023-01-14

### Changed
- Apply fix to templates to ensure correct version of Fabulous and Fabulous.MauiControls (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/4) 

## [2.1.2] - 2023-01-09

### Changed
- Remove generic types from WidgetItems and GroupedWidgetItems (https://github.com/fabulous-dev/Fabulous.MauiControls/pull/2)

## [2.1.1] - 2023-01-05

### Changed
- Fabulous.MauiControls has moved from the Fabulous repository to its own repository: [https://github.com/fabulous-dev/Fabulous.MauiControls](https://github.com/fabulous-dev/Fabulous.MauiControls)

[unreleased]: https://github.com/fabulous-dev/Fabulous.MauiControls/compare/8.1.0-pre17...HEAD
[8.1.0-pre17]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.1.0-pre17
[8.1.0-pre16]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.1.0-pre16
[8.1.0-pre15]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.1.0-pre15
[8.1.0-pre14]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.1.0-pre14
[8.1.0-pre13]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.1.0-pre13
[8.1.0-pre12]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.1.0-pre12
[8.1.0-pre11]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.1.0-pre11
[8.1.0-pre10]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.1.0-pre10
[8.1.0-pre9]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.1.0-pre9
[8.1.0-pre8]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.1.0-pre8
[8.1.0-pre7]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.1.0-pre7
[8.1.0-pre6]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.1.0-pre6
[8.1.0-pre5]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.1.0-pre5
[8.1.0-pre4]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.1.0-pre4
[8.1.0-pre3]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.1.0-pre3
[8.1.0-pre2]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.1.0-pre2
[8.1.0-pre1]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.1.0-pre1
[8.0.5]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.0.5
[8.0.4]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.0.4
[8.0.2]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.0.2
[8.0.1]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.0.1
[8.0.0]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/8.0.0
[2.8.1]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/2.8.1
[2.8.0]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/2.8.0
[2.7.0]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/2.7.0
[2.6.0]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/2.6.0
[2.5.1]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/2.5.1
[2.5.0]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/2.5.0
[2.4.0]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/2.4.0
[2.3.2]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/2.3.2
[2.3.1]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/2.3.1
[2.3.0]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/2.3.0
[2.2.0]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/2.2.0
[2.1.3]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/2.1.3
[2.1.2]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/2.1.2
[2.1.1]: https://github.com/fabulous-dev/Fabulous.MauiControls/releases/tag/2.1.1
