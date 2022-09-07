---
id: "v2-collection-view"
title: "CollectionView"
description: ""
lead: ""
date: 2022-06-03T00:00:00+00:00
lastmod: 2022-06-03T00:00:00+00:00
draft: false
images: []
menu:
  docs:
    parent: "collections"
toc: true
---

**Inheritance:** [Element]({{< ref "element.md" >}}) -> [NavigableElement]({{< ref "navigable-element.md" >}}) -> [VisualElement]({{< ref "visual-element.md" >}})  -> [View]({{< ref "view.md" >}}) -> [View]({{< ref "items-view.md" >}})  
**Xamarin.Forms documentation:** CollectionView [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.collectionview) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/collectionview)

For details on how the control actually works, please refer to:

[Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/collectionview).
[Virtualized Collections]({{< ref "../../architecture/virtualized-collections.md" >}})

## Constructors

| Constructors | Description |
|--|--|
| CollectionView(items: seq<'itemData>) | Creates a CollectionView with the specified items. |
| GroupedCollectionView(items: seq<'groupData>) | Creates a GroupedCollectionView with the specified items. |

## Properties

| Properties | Description |
|--|--|
| selectionMode(value: SelectionMode) | Sets a value that indicates how the items in the CollectionView are selected. |
| header(content: WidgetBuilder<'msg, 'contentMarker>) | Sets a value that indicates the view to display at the top of the CollectionView. |
| footer(content: WidgetBuilder<'msg, 'contentMarker>) | Sets a value that indicates the view to display at the bottom of the CollectionView. |
| itemSizingStrategy(value: ItemSizingStrategy) | Sets a value that indicates how the items in the CollectionView are sized. |
| reference(value: ViewRef&lt;CollectionView&gt;) | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.CollectionView` instance associated to this widget |

## Events

| Properties | Description |
|--|--|
| onSelectionChanged(onSelectionChanged: SelectionChangedEventArgs -> 'msg) | Event that is fired when the selection changes. The SelectionChangedEventArgs object that accompanies the SelectionChanged event has many properties. |
| onScrollToRequested(onScrollToRequested: ScrollToRequestEventArgs -> 'msg) | Event that is fired when one of the ScrollTo methods is invoked. The ScrollToRequestedEventArgs object that accompanies the ScrollToRequested event has many properties, including IsAnimated, Index, Item, and ScrollToPosition. These properties are set from the arguments specified in the ScrollTo method calls. |
| onScrolled(ItemsViewScrolledEventArgs -> 'msg) | Event that is fired to indicate that scrolling occurred. The ItemsViewScrolledEventArgs object that accompanies the Scrolled event has many properties. |

## Usages

```fs
let items = [ 1 .. 1000 ]

(CollectionView(items)
    (fun item -> Label($"{item}")))
    .selectionMode(SelectionMode.Single)
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

GroupedCollectionView(groups)
    (fun group -> Label(group.HeaderData))
    (fun item -> Label($"{item}")
    (fun group -> Label(group.FooterData))
```

### Get access to the underlying Xamarin.Forms.CollectionView

```fs
let collectionViewRef = ViewRef<CollectionView>()

(CollectionView(items)
    (fun item -> Label($"{item}")))
    .reference(collectionViewRef)
```
