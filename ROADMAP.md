## Roadmap

* Programming model: 
  * Move to `seq<_>` as the de-facto model type
  * Add `OpenGLView`
  * Compute the delta between previous and current model in a platform-agnostic way (would allow to support other frameworks like Avalonia or Uno)
  
* Support for external libraries
  * Make the code generator work with components libraries (like SyncFusion or Telerik for Xamarin.Forms)
  * Add a bindings generator to automate extraction of every controls/properties/events in a format readable by the code generator (easier to update with Xamarin.Forms, easier to use other components libraries)

* Docs
  * Generate `///` docs in code generator

* Live Reload
  * State migration: Support hot-reloading of the saved model, reapplying to the same app where possible
  * Use actual newly compiled DLLs on Android instead of F# interperter
  * Check Live Reload on WPF and other same-machine

## Ideas

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

* App size:
  * Remove F# resources in linker, see https://github.com/fsprojects/Fabulous/issues/94

## Discarded Ideas

* Possibly switch to a type provider (see [this comment](https://github.com/fsprojects/Fabulous/issues/50#issuecomment-390396365))
