# Avalonia licensing

Avalonia uses a freemium product model. The core Avalonia framework and its standard controls are open source and free to use. Avalonia also offers premium controls that require a commercial Avalonia license. Fabulous.Avalonia is open source, but a Fabulous wrapper does not include or replace the license for its underlying Avalonia control.

At the time of writing, Avalonia lists these premium controls:

* [Media Player](https://avaloniaui.net/media-player)
* [TreeDataGrid](https://avaloniaui.net/tree-data-grid)
* [Markdown Viewer](https://avaloniaui.net/markdown-viewer)
* [On-Screen Keyboard](https://avaloniaui.net/on-screen-keyboard)
* [70+ Charts](https://avaloniaui.net/charts)
* [Rich Text Editor](https://avaloniaui.net/rich-text-editor)

Avalonia's current pricing lists the premium controls in the Pro tier and component source code in the Enterprise tier. Product availability and terms can change, so check the linked product page and [Avalonia pricing](https://avaloniaui.net/pricing) before adopting one.

## Using premium controls

Add a premium control only after deciding how its Avalonia license will be supplied to every executable project that uses it. Follow that control's official setup instructions; installing a Fabulous extension package alone is not sufficient.

For CI and release builds, keep license keys in the CI provider's secret store. Do not commit a key to the project file or repository. If a CI job has no license, exclude the premium control from that job rather than treating its license error as a product failure.