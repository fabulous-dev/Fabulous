#### 0.10.0
* Adjust extension API to require use of attribute keys
* Add Elmish.XamarinForms.Maps

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
* Using `open Elmish.XamarinForms.StaticViews` is now necessary to use static Xaml bindings and the `Nav.*` type
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
* [Fix UpdateIncremental when types of Old and New object differs](https://github.com/fsprojects/Elmish.XamarinForms/pull/53)

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
