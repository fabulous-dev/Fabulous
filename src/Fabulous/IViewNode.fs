namespace Fabulous

type ViewRef(onAttached, onDetached) =
    let handle = System.WeakReference<obj>(null)

    /// Check if the new target is the same than the previous one
    /// This is done to avoid triggering change events when nothing changes
    member private __.IsSameTarget(target) =
        match handle.TryGetTarget() with
        | true, res when res = target -> true
        | _ -> false

    member x.Set(target: obj) : unit =
        if not (x.IsSameTarget(target)) then
            handle.SetTarget(target)
            onAttached x target

    member x.Unset() : unit =
        if not (x.IsSameTarget(null)) then
            handle.SetTarget(null)
            onDetached x ()

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
      Dispatch: obj -> unit }

and IViewNode =
    abstract member Target: obj
    abstract member Parent: IViewNode voption
    abstract member TreeContext: ViewTreeContext
    abstract member Reference: ViewRef voption with get, set
    abstract member MapMsg: (obj -> obj) voption with get, set

    // note that Widget is struct type, thus we have boxing via option
    // we don't have MemoizedWidget set for 99.9% of the cases
    // thus makes sense to have overhead of boxing
    // in order to save space
    abstract member MemoizedWidget: Widget option with get, set
    abstract member TryGetHandler<'T> : AttributeKey -> 'T voption
    abstract member SetHandler<'T> : AttributeKey * 'T voption -> unit

    abstract member ApplyDiff: WidgetDiff inref -> unit
