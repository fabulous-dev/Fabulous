# CollectionView

**Inheritance:** [Element](https://docs.fabulous.dev/v2/api/controls/element/) -> [NavigableElement](https://docs.fabulous.dev/v2/api/navigable-element/) -> [VisualElement](https://docs.fabulous.dev/v2/api/visual-element/) -> [View](https://docs.fabulous.dev/v2/api/view/) -> [View](https://docs.fabulous.dev/v2/api/collections/items-view/)\
**Xamarin.Forms documentation:** CollectionView [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.collectionview) / [Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/collectionview)

For details on how the control actually works, please refer to:

[Xamarin.Forms documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/collectionview). [Virtualized Collections](https://docs.fabulous.dev/v2/architecture/virtualized-collections/)

### Constructors&#x20;

| Constructors                                  | Description                                               |
| --------------------------------------------- | --------------------------------------------------------- |
| CollectionView(items: seq<‘itemData>)         | Creates a CollectionView with the specified items.        |
| GroupedCollectionView(items: seq<‘groupData>) | Creates a GroupedCollectionView with the specified items. |

### Properties&#x20;

| Properties                                           | Description                                                                                                 |
| ---------------------------------------------------- | ----------------------------------------------------------------------------------------------------------- |
| selectionMode(value: SelectionMode)                  | Sets a value that indicates how the items in the CollectionView are selected.                               |
| header(content: WidgetBuilder<‘msg, ‘contentMarker>) | Sets a value that indicates the view to display at the top of the CollectionView.                           |
| footer(content: WidgetBuilder<‘msg, ‘contentMarker>) | Sets a value that indicates the view to display at the bottom of the CollectionView.                        |
| itemSizingStrategy(value: ItemSizingStrategy)        | Sets a value that indicates how the items in the CollectionView are sized.                                  |
| reference(value: ViewRef\<CollectionView>)           | Sets a `ViewRef` instance to retrieve the `Xamarin.Forms.CollectionView` instance associated to this widget |

### Events&#x20;

| Properties                                                                 | Description                                                                                                                                                                                                                                                                                                           |
| -------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| onSelectionChanged(onSelectionChanged: SelectionChangedEventArgs -> ‘msg)  | Event that is fired when the selection changes. The SelectionChangedEventArgs object that accompanies the SelectionChanged event has many properties.                                                                                                                                                                 |
| onScrollToRequested(onScrollToRequested: ScrollToRequestEventArgs -> ‘msg) | Event that is fired when one of the ScrollTo methods is invoked. The ScrollToRequestedEventArgs object that accompanies the ScrollToRequested event has many properties, including IsAnimated, Index, Item, and ScrollToPosition. These properties are set from the arguments specified in the ScrollTo method calls. |
| onScrolled(ItemsViewScrolledEventArgs -> ‘msg)                             | Event that is fired to indicate that scrolling occurred. The ItemsViewScrolledEventArgs object that accompanies the Scrolled event has many properties.                                                                                                                                                               |

### Usages&#x20;

```fsharp
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

#### Get access to the underlying Xamarin.Forms.CollectionView&#x20;

```fsharp
let collectionViewRef = ViewRef<CollectionView>()

(CollectionView(items)
    (fun item -> Label($"{item}")))
    .reference(collectionViewRef)
```
