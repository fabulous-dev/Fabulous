# Performance and virtualized collections

Fabulous creates immutable widget descriptions, then compares the previous and next trees. Reusable native controls receive only changed scalar, child, collection, and environment attributes. Performance therefore depends more on stable structure and appropriate controls than on avoiding ordinary widget allocation.

Keep expensive computation and I/O out of `view`. Precompute data in `update`, preserve unchanged model values, and split large screens into components so local state does not redraw unrelated descriptions. Avoid dispatch loops caused by treating programmatic property updates as user input. Measure Release builds on representative hardware before adding caches.

## Collections

Do not render a large or unbounded data set as hundreds of children in `VStack`. Use a backend virtualized control and a template:

* MAUI: `CollectionView` for most lists and grids. See the current builder in [CollectionView.fs](https://github.com/fabulous-dev/Fabulous/blob/main/src/maui/Fabulous.MauiControls/Views/Collections/CollectionView.fs).
* Avalonia: `ListBox`/`ItemsControl` with a virtualizing panel, or the ItemsRepeater extension for custom layouts. See the compiled [ItemsRepeater sample](https://github.com/fabulous-dev/Fabulous/blob/main/samples/avalonia/Gallery/Pages/ItemsRepeaterPage.fs).

Keep item identity stable, make templates inexpensive, and page remote data instead of materializing it in `view`. Use observable collections only when the native collection is intentionally updated in place; otherwise update immutable model data and let reconciliation apply collection differences.

The reconciliation hot path is benchmarked in [Fabulous.Benchmarks](https://github.com/fabulous-dev/Fabulous/tree/main/src/neutral/Fabulous.Benchmarks). Run it with `dotnet run -c Release --project src/neutral/Fabulous.Benchmarks/Fabulous.Benchmarks.fsproj` when changing framework internals, not as an application startup benchmark.