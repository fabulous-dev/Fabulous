## Roadmap

* Programming model: 
  * Move to `seq<_>` as the de-facto model type
  * Add `Animation`
  * Add `OpenGLView`

* Docs
  * Generate `///` docs in code generator

* Programming efficiency
  * Support hot-reloading of the saved model, reapplying to the same app where possible


## Ideas

* Consider allowing explicit static Xaml through a type provider, e.g `xaml<"""<StackLayout Padding="20">...</StackLayout>""">`, evaluating to a `ViewElement`

* Possibly switch to a type provider (see [this comment](https://github.com/fsprojects/Elmish.XamarinForms/issues/50#issuecomment-390396365))

* Performance:
  * Do better list comparison/diffing
  * Perf-test on large lists and do resulting perf work
  * Consider allowing a `ChunkList` tree as input to ListView etc., e.g. `chunks { yield! stablePart; yield newElement; yield! stablePart2 }` 
  * Consider memoize function closure creation
  * Consider moving 'view' and 'model' computations off the UI thread

* Make some small F# langauge improvements to improve code:
  * Remove `yield` in more cases
  * Automatically save function values that do not capture any arguments
  * Allow a default unnamed argument for `children` so the argument name doesn't have to be given explicitly
  * Allow the use of struct options for optional arguments (to reduce allocations)
  * Implement the C# 5.0 "open static classes" feature in F# to allow the `View.` prefix to be dropped

* App size:
  * Remove F# resources in linker, see https://github.com/fsprojects/Elmish.XamarinForms/issues/94

## Bugs:
  * Fix issue for slider where minimum = 1.0, maximum=10.0 (i.e. when value=0 and minimum gets set before maximum?)
  

