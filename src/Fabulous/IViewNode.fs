namespace Fabulous


/// Context of the whole view tree
[<Struct>]
type ViewTreeContext =
    { CanReuseView: Widget -> Widget -> bool
      GetViewNode: obj -> IViewNode
      Dispatch: obj -> unit }

and IViewNode =
    abstract member Target : obj
    abstract member Parent : IViewNode voption
    abstract member TreeContext : ViewTreeContext
    abstract member MapMsg : (obj -> obj) voption with get, set

    // note that Widget is struct type, thus we have boxing via option
    // we don't have MemoizedWidget set for 99.9% of the cases
    // thus makes sense to have overhead of boxing
    // in order to save space
    abstract member MemoizedWidget : Widget option with get, set
    abstract member TryGetHandler<'T> : AttributeKey -> 'T voption
    abstract member SetHandler<'T> : AttributeKey * 'T voption -> unit

    abstract member ApplyDiff : WidgetDiff inref -> unit
