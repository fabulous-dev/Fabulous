## ItemsRepeater for Fabulous.Avalonia

The ItemsRepeater control is a cross-platform view for presenting lists of data. It is a container control that can host multiple items and provides layout management for items. See the [Avalonia documentation](https://docs.avaloniaui.net/docs/next/reference/controls/itemsrepeater) for more information.

### How to use
- Add the `Fabulous.Avalonia.ItemsRepeater` package to your project.
- Open `Fabulous.Avalonia` at the top of the file where you declare your Fabulous program (eg. Program.stateful).

```fsharp
open Fabulous.Aavalonia

open type Fabulous.Avalonia.View
```

#### Using the `ItemsRepeater` Widget

Now you can use the `ItemsRepeater` widget in your Fabulous app as follows:

```fsharp
ItemsRepeater(["Item 1"; "Item 2"; "Item 3"], fun x -> TextBlock(x))
```

A full, working example is included in the [ItemsRepeaterPage](https://github.com/fabulous-dev/Fabulous.Avalonia/blob/main/samples/Gallery/Pages/ItemsRepeaterPage.fs) sample

## Other useful links:
- [The official Fabulous website](https://fabulous.dev)
- [Get started](https://docs.fabulous.dev/avalonia/get-started)

Additionally, we have the [Fabulous Discord server](https://discord.gg/bpTJMbSSYK) where you can ask any of your Fabulous related questions.