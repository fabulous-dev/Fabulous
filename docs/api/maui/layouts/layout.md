# Layout

**Inheritance:** [Element](https://github.com/fabulous-dev/Fabulous/blob/main/docs/api/maui/element.md) -> [NavigableElement](https://github.com/fabulous-dev/Fabulous/blob/main/docs/api/maui/navigableelement.md) -> [VisualElement](https://github.com/fabulous-dev/Fabulous/blob/main/docs/api/maui/visualelement.md)\
**Xamarin.Forms documentation:** Layout [API](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.layout)

### Constructors&#x20;

This control can’t be instantiated on its own. Its properties and events are inherited by its descendants.

### Properties&#x20;

| Properties                                                    | Description                                                                                                         |
| ------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------- |
| padding(value: Thickness)                                     | Sets the padding around of the layout.                                                                              |
| padding(value: float)                                         | Sets the padding around of the layout.                                                                              |
| padding(left: float, top: float, right: float, bottom: float) | Sets the padding around of the layout.                                                                              |
| cascadeInputTransparent(value: bool)                          | Sets a value that indicates whether the input transparent property of the children of the layout is to be cascaded. |
| isClippedToBounds(value: bool)                                | Sets a value that indicates whether the layout is to be clipped to its bounds.                                      |

### Events&#x20;

| Properties                   | Description                                     |
| ---------------------------- | ----------------------------------------------- |
| onLayoutChanged(value: ‘msg) | Event that is fired when the layout is changed. |
