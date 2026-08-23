# TopLevel

**Inheritance:** [ContentControl](contentcontrol.md)\
AvaloniaUI **documentation:** TopLevel [API](https://reference.avaloniaui.net/api/Avalonia.Controls/TopLevel/)

## Properties

| Properties                                                             | Description                                             |
| ---------------------------------------------------------------------- | ------------------------------------------------------- |
| pointerOverElement(value: IInputElement)                               | Sets the PointerOverElement property.                   |
| themeVariant(value: ThemeVariant)                                      | Sets the ThemeVariant property.                         |
| transparencyLevelHint(value: WindowTransparencyLevel list)             | Sets the TransparencyLevelHint property.                |
| transparencyBackgroundFallback(value: WidgetBuilder<'msg, #IFabBrush>) | Sets the TransparencyBackgroundFallbackWidget property. |
| transparencyBackgroundFallback(value: IBrush)                          | Sets the TransparencyBackgroundFallback property.       |
| transparencyBackgroundFallback(value: string)                          | Sets the TransparencyBackgroundFallback property.       |
| systemBarColor(value: WidgetBuilder<'msg, #IFabBrush>)                 | Sets the SystemBarColorWidget property.                 |
| systemBarColor(value: string)                                          | Sets the SystemBarColor property.                       |

## Events

| Properties                                      | Description                                   |
| ----------------------------------------------- | --------------------------------------------- |
| onOpened(fn: 'msg)                              | Raised when the window is opened.             |
| onClosed(fn: 'msg)                              | Raised when the window is closed.             |
| onThemeVariantChanged(fn: ThemeVariant -> 'msg) | Raised when the actual theme variant changes. |
