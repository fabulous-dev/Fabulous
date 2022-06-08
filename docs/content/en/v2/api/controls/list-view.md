---
id: "v2-list-view"
title: "ListView"
description: ""
lead: ""
date: 2022-06-03T00:00:00+00:00
lastmod: 2022-06-03T00:00:00+00:00
draft: false
images: []
menu:
  docs:
    parent: "controls"
toc: true
---

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "navigableelement.md" >}}) -> [VisualElement]({{< ref "visualelement.md" >}})  -> [View]({{< ref "view.md" >}}) -> [View]({{< ref "items-view.md" >}})
**Xamarin.Forms documentation:** ListView [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.listview) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/listview)

For details on how the control actually works, please refer to the 
[Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/listview).
[Virtualized Collections]({{< ref "../../architecture/virtualized-collections.md" >}})

## Constructors

| Constructors | Description |
|--|--|
| ListView(items: seq<'itemData>) | Creates a new ListView with the given items. |
| GroupedListView(items: seq<'groupData>) | Creates a new GroupedListView with the given items. |

## Properties

| Properties | Description |
|--|--|
| header(content: WidgetBuilder<'msg, 'contentMarker>) | Sets the header of the ListView. |
| footer(content: WidgetBuilder<'msg, 'contentMarker>) | Sets the footer of the ListView. |
| hasEvenRows(value: bool) | Sets whether the rows of the ListView have even or odd rows. |
| horizontalScrollBarVisibility(value: ScrollBarVisibility) | Sets the visibility of the horizontal scroll bar. |
| verticalScrollBarVisibility(value: ScrollBarVisibility) | Sets the visibility of the vertical scroll bar. |
| isPullToRefreshEnabled(value: bool) | Sets whether pull-to-refresh is enabled. |
| isRefreshing(value: bool) | Sets whether the ListView is currently refreshing. |
| refreshControlColor(light: FabColor, ?dark: FabColor) | Sets the color of the refresh control. |
| separatorColor(light: FabColor, ?dark: FabColor) | Sets the color of the separator. |
| separatorVisibility(value: SeparatorVisibility) | Sets the visibility of the separator. |
| rowHeight(value: int) | Sets the height of the rows. |
| selectionMode(value: ListViewSelectionMode) | Sets the selection mode. |
| reference(value: ViewRef&lt;ListView&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.ListView` instance associated to this widget |

## Events

| Properties | Description |
|--|--|
| onItemAppearing(onItemAppearing: ItemVisibilityEventArgs -> 'msg) | This method is guaranteed to fire at some point before the element is on screen. |
| onItemDisappearing(onItemDisappearing: ItemVisibilityEventArgs -> 'msg) | This method is for virtualization usage only. It is not guaranteed to fire for all visible items when the List is removed from the screen. Additionally it fires during virtualization, which may not correspond directly with removal from the screen depending on the platform virtualization technique used. |
| onItemTapped(onItemTapped: int -> 'msg) | Fires when an item is tapped. |
| onItemSelected(onItemSelected: SelectedItemChangedEventArgs -> 'msg) | Fires when an item is selected. |
| onRefreshing(onRefreshing: 'msg) | Fires when the refresh control is triggered. |
| onScrolled(onScrolled: ScrolledEventArgs -> 'msg) | Event that is fired to indicate that scrolling occurred. The ScrolledEventArgs object that accompanies the Scrolled event has many properties. |
| onScrollToRequested(onScrollToRequested: ScrollToRequestedEventArgs -> 'msg) | Event that is fired when one of the ScrollTo methods is invoked. The ScrollToRequestedEventArgs object that accompanies the ScrollToRequested event has many properties. These properties are set from the arguments specified in the ScrollTo method calls. |

## Usages

```fs
let items = [ 1 .. 1000 ]

(ListView(items)
    (fun item -> TextCell($"{item}")))
    .header(Label("I'm a header"))
    .footer(Label("I'm a footer"))
    .hasEvenRows(true)
    .horizontalScrollBarVisibility(ScrollBarVisibility.Never)
    .onItemTapped(ItemTapped)
    
type Group(headerData: string, footerData: string, items: IEnumerable<int>) =
    inherit ObservableCollection<int>(items)
    member _.HeaderData = headerData
    member _.FooterData = footerData

let groups =
    ObservableCollection<Group>(
        [ for i in 0 .. 100 do
            Group($"Header {i}", $"Footer {i}", [1 .. 100]) ]
    )

// ListView has no Footer for groups
GroupedListView(groups)
    (fun group -> TextCell(group.HeaderData))
    (fun item -> TextCell($"{item}"))
```

### Get access to the underlying Xamarin.Forms.ListView

```fs
let listViewRef = ViewRef<ListView>()
(ListView(items)
    (fun item -> TextCell($"{item}")))
    .reference(listViewRef)
```
