namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IListView =
    inherit IItemsViewOfCell

module ListView =
    let WidgetKey =
        Widgets.registerWithAdditionalSetup<FabulousListView>
            (fun target node -> target.ItemTemplate <- SimpleWidgetDataTemplateSelector(node))
            
    let GroupedWidgetKey =
        Widgets.registerWithAdditionalSetup<FabulousListView>
            (fun target node ->
                target.ItemTemplate <- SimpleWidgetDataTemplateSelector(node)
                target.GroupHeaderTemplate <- GroupedWidgetDataTemplateSelector(node, Header)
                target.IsGroupingEnabled <- true)
            
    let RowHeight =
        Attributes.defineBindable<int> ListView.RowHeightProperty

    let SelectionMode =
        Attributes.defineBindable<ListViewSelectionMode> ListView.SelectionModeProperty

    let ItemTapped =
        Attributes.defineEvent "ListView_ItemTapped" (fun target -> (target :?> ListView).ItemTapped)

[<AutoOpen>]
module ListViewBuilders =
    type Fabulous.XamarinForms.View with
        static member inline ListView<'msg, 'itemData, 'itemMarker when 'itemMarker :> ICell>(items: seq<'itemData>) =
            WidgetHelpers.buildItems<'msg, IListView, 'itemData, 'itemMarker>
                ListView.WidgetKey
                ItemsViewOfCell.ItemsSource
                items
                
        static member inline GroupedListView<'msg, 'groupData, 'groupMarker, 'itemData, 'itemMarker when 'itemMarker :> ICell and 'groupMarker :> ICell and 'groupData :> System.Collections.Generic.IEnumerable<'itemData>>
            (items: seq<'groupData>)
            =
            WidgetHelpers.buildGroupItemsNoFooter<'msg, IListView, 'groupData, 'itemData, 'groupMarker, 'itemMarker>
                ListView.GroupedWidgetKey
                ItemsViewOfCell.GroupedItemsSource
                items
        
[<Extension>]
type ListViewModifiers =
    [<Extension>]
    static member inline rowHeight(this: WidgetBuilder<'msg, #IListView>, value: int) =
        this.AddScalar(ListView.RowHeight.WithValue(value))

    [<Extension>]
    static member inline selectionMode
        (
            this: WidgetBuilder<'msg, #IListView>,
            value: ListViewSelectionMode
        ) =
        this.AddScalar(ListView.SelectionMode.WithValue(value))

    [<Extension>]
    static member inline itemTapped(this: WidgetBuilder<'msg, #IListView>, fn: int -> 'msg) =
        this.AddScalar(ListView.ItemTapped.WithValue(fun args -> fn args.ItemIndex |> box))