# API reference

Fabulous 10 API documentation is generated from the maintained F# source instead of the retired hand-authored Xamarin-era pages.

* [Source API inventory](source-inventory.md) lists current widget builders and modifiers for MAUI and Avalonia, grouped by source file.
* [Program constructors](https://fabulous-dev.github.io/Fabulous/docs/concepts/programs/) documents the platform-neutral state APIs from their current signatures.
* The [MAUI Gallery](https://github.com/fabulous-dev/Fabulous/tree/main/samples/maui/Gallery) and [Avalonia Gallery](https://github.com/fabulous-dev/Fabulous/tree/main/samples/avalonia/Gallery) provide compiled usage examples.

Run `python3 -B eng/monorepo/generate-api-reference.py --check` to verify that the committed inventory matches source. Run it without `--check` after adding or removing a public builder/modifier, review the generated Markdown, then run the documentation link validator and both MkDocs builds.
