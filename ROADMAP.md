## Roadmap

* Programming model: Do these from `Xamarin.Forms.Core`: 
  * FlexLayout and XF 3.0 additions
  * Move to `seq<_>` as the de-facto model type
  * Menu, MenuItem, NavigationBar, Accelerator
  * Animation
  * OpenGLView
  * Assess further common async patterns
  * Assess further common incremental update of large data sets, e.g. `chunks { ... }`

* Docs
  * Generate `///` docs in code generator

* Programming efficiency
  * Support F# in Xamarin Live Player
  * Support hot-reloading of the saved model, reapplying to the same app where possible

* Handle 3rd party controls.
  * Examples: `Xamarin.Forms.Maps`, `SkiaSharp`
  * Consider whether to continue using a code generator or to switch to a type provider (see [this comment](https://github.com/fsprojects/Elmish.XamarinForms/issues/50#issuecomment-390396365))
  * Make any necessary changes/additions to the `bindings.json` format (nothing is set in stone yet)

* Templates
  * Develop a template pack

* Debugging
  * Improve diagnostics when property update fails
  * Fix bug where ranges for locals seem off-by-one in Android debugging

* Testing
  * Add an explicit unit-test project

* Real-world road-testing:
  * Apps using charting
  * Apps using maps

* App size:
  * Check the Xamarin tree-shaker cuts out all unused code from DynamicXaml.fs

* Performance:
  * Memoize function closure creation
  * Use integer atoms for property names
  * Do better list comparison/diffing
  * Allow a `ChunkList` tree as input to ListView etc., e.g. `chunks { yield! stablePart; yield newElement; yield! stablePart2 }` 
  * Consider keeping a running identity hash on the immutable objects
  * Consider implementing equality and hash on the immutable objects
  * Perf-test on large lists and do resulting perf work
  * Consider moving 'view' and 'model' computations off the UI thread

* Communication
  * Develop a sample that includes both client and server development, like [this talk](https://skillsmatter.com/skillscasts/11308-safe-apps-with-f-web-stack)

* Consider allowing explicit static Xaml through a type provider, e.g `xaml<"""<StackLayout Padding="20">...</StackLayout>""">`, evaluating to a `XamlElement`

* Make some small F# langauge improvements to improve code:
  * Remove `yield` in more cases
  * Automatically save function values that do not capture any arguments and consider making the `dispatch` function global (partly to avoid is being seen as a captured argument)
  * [Allow syntax `Xaml.Foo(prop1=expr1, [ // end of line`](https://github.com/Microsoft/visualfsharp/pull/4929)
  * [`TryGetValue` on F# immutable map](https://github.com/Microsoft/visualfsharp/pull/4827/)
  * Allow a default unnamed argument for `children` so the argument name doesn't have to be given explicitly
  * Allow the use of struct options for optional arguments (to reduce allocations)
  * Implement the C# 5.0 "open static classes" feature in F# to allow the `Xaml.` prefix to be dropped

Bugs:
  * Fix issue for slider where minimum = 1.0, maximum=10.0 (i.e. when value=0 and minimum gets set before maximum?)
  * Fix issue with application reload in AllControls.fs

