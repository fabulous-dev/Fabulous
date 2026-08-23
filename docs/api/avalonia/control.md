# Control

**Inheritance:** [InputElement](inputelement.md)\
AvaloniaUI **documentation:** Control [API](https://reference.avaloniaui.net/api/Avalonia.Controls/Control/)

## Properties

| Properties                          | Description                      |
| ----------------------------------- | -------------------------------- |
| tag(value: string)                  | Sets the Tag property.           |
| flowDirection(value: FlowDirection) | Sets the FlowDirection property. |

## Events

| Properties                                                        | Description                                                                                                    |
| ----------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------- |
| onContextRequested(fn: ContextRequestedEventArgs -> 'msg)         | Raised when the user has completed a context input gesture, such as a right-click.                             |
| onRequestBringIntoView(fn: RequestBringIntoViewEventArgs -> 'msg) | Raised when an element wishes to be scrolled into view.                                                        |
| onLoaded(fn: RoutedEventArgs -> 'msg)                             | Raised when the control has been fully constructed in the visual tree and both layout and render are complete. |
| onUnLoaded(fn: RoutedEventArgs -> 'msg)                           | Raised when the control is removed from the visual tree.                                                       |
| onSizeChanged(fn: SizeChangedEventArgs -> 'msg)                   | Raised when the control's size changes.                                                                        |
