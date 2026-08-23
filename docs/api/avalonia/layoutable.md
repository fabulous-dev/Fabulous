# Layoutable

**Inheritance:** [Visual](visual.md)\
AvaloniaUI **documentation:** Layoutable [API](https://reference.avaloniaui.net/api/Avalonia.Layout/Layoutable/)

### Properties&#x20;

| Properties                                                   | Description                                                              |
| ------------------------------------------------------------ | ------------------------------------------------------------------------ |
| width(value: float)                                          | Sets the Width property.                                                 |
| height(value: float)                                         | Sets the Height property.                                                |
| minWidth(value: float)                                       | Sets the MinWidth property.                                              |
| minHeight(value: float)                                      | Sets the MinHeight property.                                             |
| maxWidth(value: float)                                       | Sets the MaxWidth property.                                              |
| maxHeight(value: float)                                      | Sets the MaxHeight property.                                             |
| margin(value: Thickness)                                     | Sets the Margin property.                                                |
| horizontalAlignment(value: HorizontalAlignment)              | Sets the HorizontalAlignment property.                                   |
| verticalAlignment(value: VerticalAlignment)                  | Sets the VerticalAlignment property.                                     |
| useLayoutRounding(value: bool)                               | Sets the UseLayoutRounding property.                                     |
| centerHorizontal()                                           | Sets the HorizontalAlignment property to Center.                         |
| centerVertical()                                             | Sets the VerticalAlignment property to Center.                           |
| center()                                                     | Sets the HorizontalAlignment and VerticalAlignment properties to Center. |
| margin(value: float)                                         | Sets the Margin property.                                                |
| margin(horizontal: float, vertical: float)                   | Sets the Margin property.                                                |
| margin(left: float, top: float, right: float, bottom: float) | Sets the Margin property.                                                |
| size(width: float, height: float)                            | Sets the Width and Height properties.                                    |

### Events&#x20;

| Properties                                                                | Description                                           |
| ------------------------------------------------------------------------- | ----------------------------------------------------- |
| onEffectiveViewportChanged(fn: EffectiveViewportChangedEventArgs -> 'msg) | Raised when the element's effective viewport changes. |
| onLayoutUpdated(msg: 'msg)                                                | Raised when the element's layout is updated.          |
