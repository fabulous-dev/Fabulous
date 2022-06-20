namespace Fabulous

open Fabulous

type ViewRef(onAttached, onDetached) =
    let handle = System.WeakReference<obj>(null)

    /// Check if the new target is the same than the previous one
    /// This is done to avoid triggering change events when nothing changes
    member private _.IsSameTarget(target) =
        match handle.TryGetTarget() with
        | true, res when res = target -> true
        | _ -> false

    member x.Set(target: obj) : unit =
        if not(x.IsSameTarget(target)) then
            handle.SetTarget(target)
            onAttached target

    member x.Unset() : unit =
        if not(x.IsSameTarget(null)) then
            handle.SetTarget(null)
            onDetached()

    member _.TryValue =
        match handle.TryGetTarget() with
        | true, null -> None
        | true, res -> Some res
        | _ -> None

/// Context of the whole view tree
[<Struct>]
type ViewTreeContext =
    { CanReuseView: Widget -> Widget -> bool
      GetViewNode: obj -> IViewNode
      Logger: Logger
      Dispatch: obj -> unit }

and IViewNode =
    /// The view that is being rendered
    abstract member Target: obj

    /// The context of the whole view tree
    abstract member TreeContext: ViewTreeContext

    // note that Widget is struct type, thus we have boxing via option
    // we don't have MemoizedWidget set for 99.9% of the cases
    // thus makes sense to have overhead of boxing
    // in order to save space
    abstract member MemoizedWidget: Widget option with get, set

    /// The parent node
    abstract member Parent: IViewNode option

    /// Indicate if the node has been disconnected from the tree
    abstract member IsDisconnected: bool

    /// Convert the node messages to its parent's message type
    abstract member MapMsg: (obj -> obj) option with get, set

    /// Return the event handler for a given attribute key if set
    abstract member TryGetHandler<'T> : string -> 'T voption

    /// Set the event handler for a given attribute name
    abstract member SetHandler<'T> : string * 'T voption -> unit

    /// Disconnect the node from the tree
    abstract member Disconnect: unit -> unit

    /// Apply the diffing result to this node
    abstract member ApplyDiff: WidgetDiff inref -> unit
