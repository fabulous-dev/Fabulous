# ItemsView

**Inheritance:** [Element](https://docs.fabulous.dev/v2/api/controls/element/) -> [NavigableElement](https://docs.fabulous.dev/v2/api/navigable-element/) -> [VisualElement](https://docs.fabulous.dev/v2/api/visual-element/) -> [View](https://docs.fabulous.dev/v2/api/view/)\
**Xamarin.Forms documentation:** ItemsView [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.itemsview)

### Properties&#x20;

| Properties                                                    | Description                                                                                                                                                          |
| ------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| remainingItemsThreshold(value: int, onThresholdReached: ‘msg) | Sets a value that indicates the number of items that remain in the view before the remainingItemsThresholdReached event is raised.                                   |
| horizontalScrollBarVisibility(value: ScrollBarVisibility)     | Sets a value that indicates whether the horizontal scroll bar is visible.                                                                                            |
| verticalScrollBarVisibility(value: ScrollBarVisibility)       | Sets a value that indicates whether the vertical scroll bar is visible.                                                                                              |
| itemsUpdatingScrollMode(value: ItemsUpdatingScrollMode)       | Sets a value that indicates how the items in the ItemsView are updated when the scroll position changes. i.e. KeepItemsInView, KeepScrollOffset, KeepLastItemInView. |
| emptyView(content: WidgetBuilder<‘msg, ‘contentMarker>)       | Sets a value that indicates the view to display when the ItemsView has no items.                                                                                     |

### Events&#x20;

| Properties                                                                 | Description                                                                                                                                                                                                                                                                                                           |
| -------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| onScrollToRequested(onScrollToRequested: ScrollToRequestEventArgs -> ‘msg) | Event that is fired when one of the ScrollTo methods is invoked. The ScrollToRequestedEventArgs object that accompanies the ScrollToRequested event has many properties, including IsAnimated, Index, Item, and ScrollToPosition. These properties are set from the arguments specified in the ScrollTo method calls. |
| onScrolled(ItemsViewScrolledEventArgs -> ‘msg)                             | Event that is fired to indicate that scrolling occurred. The ItemsViewScrolledEventArgs object that accompanies the Scrolled event has many properties.                                                                                                                                                               |
