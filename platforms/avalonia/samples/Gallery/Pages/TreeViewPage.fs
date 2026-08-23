namespace Gallery


open Fabulous.Avalonia
open type Fabulous.Avalonia.View

module TreeViewPage =
    let view () =
        TabControl() {
            TabItem("Simple", SimpleTreeView.view())
            TabItem("With TreeViewItem", SimpleTreeViewItem.view())
            TabItem("With node interaction", TreeViewWithNodeInteraction.view())
            TabItem("Editable", EditableTreeView.view())
        }
