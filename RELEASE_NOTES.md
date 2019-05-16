#### 0.33.2

* [DynamicViews] Fixed an issue in TableView where the items weren't recycled (https://github.com/fsprojects/Fabulous/pull/364)

#### 0.33.1

* [LiveUpdate] Fixed a bug where any changes throw a NullReferenceException (https://github.com/fsprojects/Fabulous/pull/355)

#### 0.33.0

* [DynamicViews] Added SizeChangedEventArgs to give access to the new size when SizeChanged is raised (https://github.com/fsprojects/Fabulous/pull/336)
* [DynamicViews] Added an extension point to give a new default implementation for a control (https://github.com/fsprojects/Fabulous/pull/342)
* [LiveUpdate] Updated Interpreter to fix some bugs. Plus changed the watcher with a new and easier command line syntax (https://github.com/fsprojects/Fabulous/pull/338)
* [Fabulous.Core] Fixed a bug (possibly from Mono) that made Fabulous act weird on some Android devices (https://github.com/fsprojects/Fabulous/pull/347)
* [Templates] Fixed the consistency of the namespace between the files in the WPF template (https://github.com/fsprojects/Fabulous/pull/349)

#### 0.32.0

* [Fabulous.Core] Added better type annotation to make the functions init and update easier to read (https://github.com/fsprojects/Fabulous/pull/313)
* [Template] Added new UWP template (https://github.com/fsprojects/Fabulous/pull/324)
* [Fabulous.Core] Added new helpers to extract data from ViewElement. Helpful for unit testing the views (https://github.com/fsprojects/Fabulous/pull/325)
* [Xamarin.Forms controls] Added the property ScrollTo and the event Scrolled for ScrollView (https://github.com/fsprojects/Fabulous/pull/332)
* [Xamarin.Forms controls] Added the events ChildrenReordered, MeasureInvalidated, Focused, SizeChanged and Unfocused for VisualElement (https://github.com/fsprojects/Fabulous/pull/327)
* [Fabulous.Core] Changed the modules behind View; The builder functions are no longer hidden from IntelliSense (https://github.com/fsprojects/Fabulous/pull/325)
* [Xamarin.Forms controls] Fixed the update of TableSection.Title (https://github.com/fsprojects/Fabulous/pull/330)

#### 0.31.0

* [Fabulous.Core] Added XML docs for Fabulous helpers (https://github.com/fsprojects/Fabulous/pull/284)
* [Xamarin.Forms controls] Fixed the TitleView attached property on Page (https://github.com/fsprojects/Fabulous/pull/305)
* [Xamarin.Forms controls] Fixed the Accelerator property on MenuItem (https://github.com/fsprojects/Fabulous/pull/301)
* [Template] Fixed a typo in assembly name in macOS project (https://github.com/fsprojects/Fabulous/pull/300)
* [Template] Fixed an issue where NuGet restore would fail due to a space in path on Windows (https://github.com/fsprojects/Fabulous/pull/290)
* [LiveUpdate] Fixed: Using ViewRef produces a "No member found for key Fabulous.DynamicViews.ViewRef" error (https://github.com/fsprojects/Fabulous/pull/286)
* [LiveUpdate] Fixed: Using a list a "No member found for key Microsoft.FSharp.Collections.FSharpList" error (https://github.com/fsprojects/Fabulous/pull/286)
* [LiveUpdate] Fixed: Calling a function that takes unit from a module in a separate dll produces a "No member found for key" error (https://github.com/fsprojects/Fabulous/pull/286)

#### 0.30.0

* Added support for Xamarin.Forms 3.4 (https://github.com/fsprojects/Fabulous/pull/257)
* Added new GTK template (https://github.com/fsprojects/Fabulous/pull/268)
* Changed behavior of SKCanvasView "invalidate" (always triggers an invalidation while the property is true) (https://github.com/fsprojects/Fabulous/pull/262)
* Updated WPF template to target .NET Framework 4.7.2 by default (https://github.com/fsprojects/Fabulous/pull/267)
* Updated NuGet inside the template to v4.9.2 (https://github.com/fsprojects/Fabulous/pull/271)
* Fixed MacOS template by adding some missing references (https://github.com/fsprojects/Fabulous/pull/276)

#### 0.29.0

BREAKING CHANGES:
* Replaced Minimum and Maximum properties of Slider/Stepper by a single MinimumMaximum property (tuple) (https://github.com/fsprojects/Fabulous/pull/246)
* Replaced the "fscd" daemon (embedded in the Fabulous.LiveUpdate package) by a new dotnet CLI tool "fabulous-cli". See https://fsprojects.github.io/Fabulous/tools.html for more informations. (https://github.com/fsprojects/Fabulous/pull/247)

#### 0.28.0

* Added a dispatch method accessible in the app projects (https://github.com/fsprojects/Fabulous/pull/240)
* Added a debounche helper function (https://github.com/fsprojects/Fabulous/pull/237)

#### 0.27.1

* Fixed a cast issue in ViewRef&lt;T&gt;.TryValue (https://github.com/fsprojects/Fabulous/pull/235)

#### 0.27.0

* Added TextChanged event to EntryCell (https://github.com/fsprojects/Fabulous/pull/227)

#### 0.26.0

* Added Cmd.ofMsgOption and Cmd.ofAsyncMsgOption (https://github.com/fsprojects/Fabulous/pull/224)
* Fixed Microsoft.CSharp warnings when building a project created with the template (https://github.com/fsprojects/Fabulous/pull/216)
* Fixed a bug in ListViewGrouped that prevented groups to be updated (https://github.com/fsprojects/Fabulous/pull/229)
* Fixed description of the NuGet packages (https://github.com/fsprojects/Fabulous/pull/220)

#### 0.25.0

* Added "CurrentPage" and "CurrentPageChanged" to TabbedPage and CarouselPage (https://github.com/fsprojects/Fabulous/pull/215)
* Added support for byte array with Image.Source (https://github.com/fsprojects/Fabulous/pull/217)
* Improved exception protection in LiveUpdate (https://github.com/fsprojects/Fabulous/pull/214)
* Fixed an issue in LiveUpdate preventing the use of some kinds of discriminated unions (https://github.com/fsprojects/Fabulous/pull/213)

#### 0.24.0

* Added StyleClass property (https://github.com/fsprojects/Fabulous/pull/209)

#### 0.23.0

* Added support for SourceLink (https://github.com/dotnet/sourcelink)
* Fixed wrong type for the new ViewRef
* Fixed missing incremental update for ListView rows

#### 0.22.0

* Added support for Focus and Animations (access to the underlying control with "created" event & ViewRef)
* Added "invalidate" flag to SkiaSharp extension
* Added WPF to template

#### 0.21.1

* Fixed bad dependency for Fabulous.Maps package (https://github.com/fsprojects/Fabulous/pull/188)
* Fixed missing SelectionMode property on ListViewGrouped

#### 0.21.0

* Fixed https://github.com/fsprojects/Fabulous/issues/136
* Updated to Xamarin.Forms 3.1
* Changed LiveUpdate to only display corresponding indications based on the current platform (Android, iOS, other)

#### 0.20.0

* Rename project Elmish.XamarinForms --> Fabulous
* Rename namespace Elmish.XamarinForms --> Fabulous.Core
* Rename dll Elmish.XamarinForms.dll --> Fabulous.Core.dll
* Rename package Elmish.XamarinForms --> Fabulous.Core

#### 0.17.0

* Added TextChanged on SearchBar
* Fixed module name for SkiaSharp extension
* Added LiveUpdate to the iOS template by default

#### 0.16.0

* Added AutomationId property on all controls
* Added LineBreakMode property on Label
* Added ShowJumpList property on ListViewGrouped
* Changed ListViewGrouped's Items property to accept a group name
* Fixed namespace for Extensions
* Fixed NavigationPage recycling

#### 0.15.2

* Added support for ImageSource on Image and ImageCell controls
* Fixed ListViewGrouped

#### 0.14.8

* Fixed LiveUpdate for CalculatorApp (AddressOf, out args, pattern matching)
* Fixed templates so you can update Xamarin Forms

#### 0.14.6

* Fixed LiveUpdate for iOS
* Moved to Newtonsoft.Json instead of FsPickler

#### 0.14.4

* Add 'let rec' to code accepted by LiveUpdate
* Add local mutables to code accepted by LiveUpdate

#### 0.14.2

* Rename Xaml.* --> View.*

#### 0.13.10

* Fix compilation of template on OSX

#### 0.13.8

* Fix packaging problem with fscd tools

#### 0.13.4

* Fix errors raised by interpreter

#### 0.13.2

* Fix sample look and feel
* Fix repeated live updates

#### 0.13.0

* Add experimental LiveUpdate

#### 0.12.10

* Added oxplot extension
* Fix dependencies in nuget packages

#### 0.12.4

* Missed a renaming in the extension API

#### 0.12.2

* Remove unnecesary boxing in extension API
* Improved documentation

#### 0.12.0

* Adjust extension API to be more type safe
* Add Fabulous.SkiaSharp

#### 0.10.0

* Adjust extension API to require use of attribute keys
* Add Fabulous.Maps

#### 0.9.4

* Require extensions to give the correct size for attribute count, and don't reallocate the attribute array

#### 0.9.2

* Fix template

#### 0.9.0

* Use an attribute builder

#### 0.8.12

* Adjust template to deploy to Android by default for Any CPU

#### 0.8.4

* Fix template

#### 0.8.2

* Fix template 

#### 0.8.0

* Rename `XamlElement` --> `ViewElement`
* Rejig  `XamlElement` to store an immutable array of attributes rather than a `Map`
* Using `open Fabulous.StaticViews` is now necessary to use static Xaml bindings and the `Nav.*` type
* Obsolete `Program.withDynamicView` and `Program.withStaticView` in favour of `Program.runWithDynamicView` and `Program.runWithStaticView`
* Remove `StaticXaml/MasterDetailApp` sample since it's not a great sample anyway
* Add template

#### 0.7.0

* Base dependency is now Xamarin.Forms 3.0
* Add `Resources` property to `VisualElement`
* Add `Styles` property to `VisualElement`
* Add `StyleSheets` property to `VisualElement`

#### 0.6.0

* Toolbar, ToolbarItem support
* MenuItem support
* Support Page properties: BackgroundImage, Icon, IsBusy, ToolbarItems
* Support Page events: Appearing, Disappearing, LayoutChanged
* Add docs on modal pages

#### 0.5.1

* Support FormattedText parameter to Label

#### 0.5.0

* Simplify generated code
* Code generator now in F#  
* Remove `x |> margin 3.0`  pipelined versions of properties and instead people always need to use members `x.Margin(3.0)`

#### 0.4.5

* `app.Model` --> `app.CurrentModel` and `app.SetModel(model)`
* Sequences not lists for model inputs
* `itemAppearing` and `itemDisappearing` now use integer indexes
* Old view elements are now reusable after application resumes
* Global `dispatch` function available to reduce number of closures 

#### 0.4.4

* [Fix UpdateIncremental when types of Old and New object differs](https://github.com/fsprojects/Fabulous/pull/53)

#### 0.4.3

* Sync base version of XF to that listed in paket.lock

#### 0.4.2

* Add `fix`, `fixf`
* Add `canExecute` to Button etc.
* Show how to persist model using JSON
* Change `run` to return a runner object (used to reset the model on restore)
* Add docs on validation
* Remove `Program.runDebug` in favour of `Program.withDebug`

#### 0.4.1

* Updates to README
* Add `dependsOn`
* Add `RelativeLayout` and `AbsoluteLayout`
* Use struct options internally
* Add `TableView` support
* Fix repeated update of image sources
* Simplify size requests
* Add `ListView` and `ListViewGrouped` support
* Use and recycle `ObservableCollection` for `ListView` entries
* Updates for accurate `ListViw` selection
* Updates for more accurate view memoization
* Include the code generator

#### 0.4.0

* Lots of updates to dynamic views

#### 0.3.2

* Correct version in assembly

#### 0.3.1

* Correct mistake in nuget pacakge

#### 0.3.0

* Add multi-page and navigation 
* Add dynamic views (NOTE: not usable since they flicker, see README.md)

#### 0.2.0

* Adapt to latest Xamarin.Forms and match latest Elmish.WPF

* Elmish all the Xamarin.Forms!
