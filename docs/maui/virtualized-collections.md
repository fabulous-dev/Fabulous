# Virtualized collections

Use `ListView`, `CollectionView`, or `CarouselView` when a data set is larger than the controls visible on screen. Fabulous passes the source enumerable to .NET MAUI and uses a `DataTemplateSelector` to create only the native cells MAUI needs.

```fsharp
CollectionView(model.Items)(fun item ->
    Label(item.Name)
)
```

Immutable F# lists are supported. Replacing a list during an MVU update changes the native `ItemsSource` while retaining the existing template selector and its per-control-type template cache. The template function is refreshed, so visible recycled cells render current model data without allocating a new native template for every list update.

The source and item template should be deterministic for the current model. Keep side effects out of template functions; cells can be reused as items enter and leave the viewport. For high-frequency updates, batch model changes where practical rather than rebuilding the source for every individual event.

## Grouped collections

Groups must implement `IEnumerable<'item>`. `GroupedListView` accepts group-header and item templates. `GroupedCollectionView` also accepts a group-footer template.

```fsharp
(GroupedCollectionView
    model.Groups
    (fun group -> Label(group.Name))
    (fun item -> Label(item.Name))
    (fun group -> Label($"{group.Count} items")))
    .selectionMode(SelectionMode.Multiple)
```

Multiple selection is maintained by the native `CollectionView`. Updating the immutable outer group list does not replace the item, group-header, or group-footer template selectors and does not clear selections belonging to other groups. Application code should still use stable item objects, or implement value equality suitable for MAUI selection matching, when replacing the group contents themselves.

Runnable examples for `ListView`, `GroupedListView`, `CollectionView`, `GroupedCollectionView`, and `CarouselView` are registered in `samples/maui/Gallery`.
