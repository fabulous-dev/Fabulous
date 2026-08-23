namespace Fabulous.Avalonia

open System.Collections
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabTreeView =
    inherit IFabItemsControl

type TreeWidgetItems =
    { Nodes: IEnumerable
      SubNodesFn: obj -> IEnumerable
      Template: obj -> Widget }

module TreeView =
    let WidgetKey = Widgets.register<TreeView>()

    let ItemsSource =
        Attributes.defineSimpleScalar<TreeWidgetItems>
            "TreeView_ItemsSource"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.Nodes b.Nodes)
            (fun _ newValueOpt node ->
                let treeView = node.Target :?> TreeView

                match newValueOpt with
                | ValueNone ->
                    treeView.ClearValue(TreeView.ItemTemplateProperty)
                    treeView.ClearValue(TreeView.ItemsSourceProperty)
                | ValueSome value ->
                    treeView.SetValue(TreeView.ItemTemplateProperty, WidgetTreeDataTemplate(node, value.SubNodesFn, unbox >> value.Template))
                    |> ignore

                    treeView.SetValue(TreeView.ItemsSourceProperty, value.Nodes) |> ignore)

    let AutoScrollToSelectedItem =
        Attributes.defineAvaloniaPropertyWithEquality TreeView.AutoScrollToSelectedItemProperty

    let SelectedItem =
        Attributes.defineAvaloniaPropertyWithEquality TreeView.SelectedItemProperty

    let SelectedItems =
        Attributes.defineAvaloniaPropertyWithEquality TreeView.SelectedItemsProperty

    let SelectionMode =
        Attributes.defineAvaloniaPropertyWithEquality TreeView.SelectionModeProperty

[<AutoOpen>]
module TreeViewBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TreeView widget.</summary>
        /// <param name="nodes">The root nodes used to populate the TreeView.</param>
        /// <param name="subNodes">The sub nodes used to populate the children of each node.</param>
        /// <param name="template">The template used to render each node.</param>
        static member TreeView<'msg, 'itemData, 'itemMarker when 'msg: equality and 'itemMarker :> IFabControl>
            (nodes: seq<'itemData>, subNodes: 'itemData -> seq<'itemData>, template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>)
            =
            let template (item: obj) =
                let item = unbox<'itemData> item
                (template item).Compile()

            let data: TreeWidgetItems =
                { Nodes = nodes
                  SubNodesFn = (fun subNode -> subNodes(unbox subNode) :> IEnumerable)
                  Template = template }

            WidgetBuilder<'msg, IFabTreeView>(TreeView.WidgetKey, TreeView.ItemsSource.WithValue(data))

type TreeViewModifiers =
    /// <summary>Link a ViewRef to access the direct TreeView control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTreeView>, value: ViewRef<TreeView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    /// <summary>Sets the AutoScrollToSelectedItem property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AutoScrollToSelectedItem value.</param>
    [<Extension>]
    static member inline autoScrollToSelectedItem(this: WidgetBuilder<'msg, #IFabTreeView>, value: bool) =
        this.AddScalar(TreeView.AutoScrollToSelectedItem.WithValue(value))

    /// <summary>Sets the SelectedItem property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectedItem value.</param>
    [<Extension>]
    static member inline selectedItem(this: WidgetBuilder<'msg, #IFabTreeView>, value: obj) =
        this.AddScalar(TreeView.SelectedItem.WithValue(value))

    /// <summary>Sets the SelectedItems property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectedItems value.</param>
    [<Extension>]
    static member inline selectedItems(this: WidgetBuilder<'msg, #IFabTreeView>, value: IList) =
        this.AddScalar(TreeView.SelectedItems.WithValue(value))

    /// <summary>Sets the SelectionMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionMode value.</param>
    [<Extension>]
    static member inline selectionMode(this: WidgetBuilder<'msg, #IFabTreeView>, value: SelectionMode) =
        this.AddScalar(TreeView.SelectionMode.WithValue(value))
