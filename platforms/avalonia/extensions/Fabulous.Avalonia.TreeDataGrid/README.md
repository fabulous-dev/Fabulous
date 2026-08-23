## TreeDataGrid for Fabulous.Avalonia

The tree data grid displays hierarchical and tabular data together in a single view. It is a combination of a tree view and data grid.. See the [Avalonia documentation](https://docs.avaloniaui.net/docs/next/reference/controls/detailed-reference/treedatagrid/) for more information.

### How to use
- Add the `Fabulous.Avalonia.TreeDataGrid` package to your project.
- Open `Fabulous.Avalonia` at the top of the file where you declare your Fabulous program (eg. Program.stateful).

```fsharp
open Fabulous.Avalonia

open type Fabulous.Avalonia.View
```

#### Using the `TreeDataGrid` Widget

Now you can use the `TreeDataGrid` widget in your Fabulous app as follows:

```fsharp
TreeDataGrid(colums)

TreeDataGrid(colums, rows)
```

A full, working example is included in the [TreeDataGridPage](https://github.com/fabulous-dev/Fabulous.Avalonia/blob/main/samples/Gallery/Pages/TreeDataGridPage.fs) sample

## Other useful links:
- [The official Fabulous website](https://fabulous.dev)
- [Get started](https://docs.fabulous.dev/avalonia/get-started)

Additionally, we have the [Fabulous Discord server](https://discord.gg/bpTJMbSSYK) where you can ask any of your Fabulous related questions.