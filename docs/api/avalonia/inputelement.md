# InputElement

**Inheritance:** [Interactive](https://reference.avaloniaui.net/api/Avalonia.Interactivity/Interactive/)\
AvaloniaUI **documentation:** InputElement [API](https://reference.avaloniaui.net/api/Avalonia.Input/InputElement/)

### Properties&#x20;

| Properties                    | Description                         |
| ----------------------------- | ----------------------------------- |
| focusable(value: bool)        | Sets the Focusable property.        |
| isEnabled(value: bool)        | Sets the IsEnabled property.        |
| cursor(value: Cursor)         | Sets the Cursor property.           |
| isHitTestVisible(value: bool) | Sets the IsHitTestVisible property. |
| isTabStop(value: bool)        | Sets the IsTabStop property.        |
| tabIndex(value: int)          | Sets the TabIndex property.         |

### Events&#x20;

| Properties                                                                            | Description                                                                                                                                                                                                |
| ------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| onGotFocus(fn: GotFocusEventArgs -> 'msg)                                             | Raised when control receives focus.                                                                                                                                                                        |
| onLostFocus(fn: RoutedEventArgs -> 'msg)                                              | Raised when control loses focus.                                                                                                                                                                           |
| onKeyDown(fn: KeyEventArgs -> 'msg)                                                   | Raised when a key is pressed while the control has focus.                                                                                                                                                  |
| onKeyUp(fn: KeyEventArgs -> 'msg)                                                     | Raised when a key is released while the control has focus.                                                                                                                                                 |
| onTextInput(fn: TextInputEventArgs -> 'msg)                                           | Raised when a user typed some text while the control has focus.                                                                                                                                            |
| onTextInputMethodClientRequested(fn: TextInputMethodClientRequestedEventArgs -> 'msg) | Raised when an input element gains input focus and input method is looking for the corresponding client.                                                                                                   |
| onPointerEntered(fn: PointerEventArgs -> 'msg)                                        | Raised when pointer enters the control.                                                                                                                                                                    |
| onPointerExited(fn: PointerEventArgs -> 'msg)                                         | Raised when pointer leaves the control.                                                                                                                                                                    |
| onPointerMoved(fn: PointerEventArgs -> 'msg)                                          | Raised when pointer moves over the control.                                                                                                                                                                |
| onPointerPressed(fn: PointerPressedEventArgs -> 'msg)                                 | Raised when the pointer is pressed over the control.                                                                                                                                                       |
| onPointerReleased(fn: PointerReleasedEventArgs -> 'msg)                               | Raised when the pointer is released over the control.                                                                                                                                                      |
| onPointerCaptureLost(fn: PointerCaptureLostEventArgs -> 'msg)                         | Raised when the control or its child control loses the pointer capture for any reason event will not be triggered for a parent control if capture was transferred to another child of that parent control. |
| onPointerWheelChanged(fn: PointerWheelEventArgs -> 'msg)                              | Raised when the pointer wheel changes.                                                                                                                                                                     |
| onTapped(fn: RoutedEventArgs -> 'msg)                                                 | Raised when a tap gesture occurs on the control.                                                                                                                                                           |
| onHolding(fn: HoldingRoutedEventArgs -> 'msg)                                         | Raised when a holding gesture occurs on the control.                                                                                                                                                       |
| onDoubleTapped(fn: RoutedEventArgs -> 'msg)                                           | Raised when a double-tap gesture occurs on the control.                                                                                                                                                    |

