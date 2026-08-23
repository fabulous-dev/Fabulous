# PopupFlyoutBase

**Inheritance:** [FlyoutBase](flyoutbase.md)

### Properties

| Properties                                                                | Description                                       |
| ------------------------------------------------------------------------- | ------------------------------------------------- |
| placement(value: PlacementMode)                                           | Sets the Placement property.                      |
| horizontalOffset(value: double)                                           | Sets the HorizontalOffset property.               |
| verticalOffset(value: double)                                             | Sets the VerticalOffset property.                 |
| placementAnchor(value: PopupAnchor)                                       | Sets the PlacementAnchor property.                |
| placementGravity(value: PopupGravity)                                     | Sets the PlacementGravity property.               |
| showMode(value: FlyoutShowMode)                                           | Sets the ShowMode property.                       |
| overlayInputPassThroughElement(value: IInputElement)                      | Sets the OverlayInputPassThroughElement property. |
| placementConstraintAdjustment(value: PopupPositionerConstraintAdjustment) | Sets the PlacementConstraintAdjustment property.  |

## Events

| Properties                             | Description                                 |
| -------------------------------------- | ------------------------------------------- |
| onOpening(fn: 'msg)                    | Raised when the PopupFlyoutBase is opening. |
| onClosing(fn: CancelEventArgs -> 'msg) | Raised when the PopupFlyoutBase is closing. |
