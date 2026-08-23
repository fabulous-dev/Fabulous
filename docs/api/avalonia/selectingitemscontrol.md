# SelectingItemsControl

**Inheritance:** [ItemsControl](itemscontrol.md)\
AvaloniaUI **documentation:** SelectingItemsControl [API](https://reference.avaloniaui.net/api/Avalonia.Controls.Primitives/SelectingItemsControl/)

## Properties

| Properties                            | Description                                 |
| ------------------------------------- | ------------------------------------------- |
| autoScrollToSelectedItem(value: bool) | Sets the AutoScrollToSelectedItem property. |
| selectedIndex(value: int)             | Sets the SelectedIndex property.            |
| selectedItem(value: obj)              | Sets the SelectedItem property.             |
| isTextSearchEnabled(value: bool)      | Sets the IsTextSearchEnabled property.      |
| wrapSelection(value: bool)            | Sets the WrapSelection property.            |
| isSelected(value: bool)               | Sets the IsSelected property.               |

## Events

| Properties                                                | Description                                       |
| --------------------------------------------------------- | ------------------------------------------------- |
| onSelectionChanged(fn: SelectionChangedEventArgs -> 'msg) | Raised when the control's selection changes.      |
| onSelectedIndexChanged(index: int, fn: int -> 'msg)       | Raised when the control's selected index changes. |
