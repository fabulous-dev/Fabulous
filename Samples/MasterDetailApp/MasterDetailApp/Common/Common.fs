namespace MasterDetailApp


/// Represents items in the model
type Item = 
    { Text: string; Description: string }

/// The different targets of navigation
type NavID = 
    | ItemsPageID
    | ItemDetailsPageID
    | NewItemPageID

/// The external messages sent from components when navigation happens
type NavMsg =
    /// Indicates no interaction/navigation message 
    | NoNav

    /// Sent by a component when it wants a new item editor
    | NewItemRequest of requestor: NavID

    /// Sent by a component when it wants an item viewed
    | ItemDetailsRequest of item: Item * requestor: NavID

    /// Sent by a after a page pop when an item has been edited
    | NewItemResult of newItem: Item * requestor: NavID

