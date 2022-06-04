namespace Fabulous

module ViewHelpers =
    let canReuseView (prevWidget: Widget) (currWidget: Widget) =
        let prevKey = prevWidget.Key

        if not(prevKey = currWidget.Key) then
            false
        else if (prevKey = Memo.MemoWidgetKey) then
            Memo.canReuseMemoizedWidget prevWidget currWidget
        else
            true

module View =
    /// Avoid recomputing the whole subtree when the key doesn't change
    let lazy'<'msg, 'key, 'marker when 'key: equality>
        (fn: 'key -> WidgetBuilder<'msg, 'marker>)
        (key: 'key)
        : WidgetBuilder<'msg, Memo.Memoized<'marker>> =

        let memo: Memo.MemoData =
            { KeyData = box key
              KeyComparer = fun (prev: obj) (next: obj) -> unbox<'key> prev = unbox<'key> next
              CreateWidget = fun k -> fn(unbox<'key> k).Compile()
              KeyType = typeof<'key>
              MarkerType = typeof<'marker> }

        WidgetBuilder<'msg, Memo.Memoized<'marker>>(Memo.MemoWidgetKey, Memo.MemoAttribute.WithValue(memo))

    /// Map the widget's message type to the parent's message type to allow for view composition
    let inline map (fn: 'oldMsg -> 'newMsg) (x: WidgetBuilder<'oldMsg, 'marker>) : WidgetBuilder<'newMsg, 'marker> =
        let replaceWith (oldAttr: ScalarAttribute) =
            let fnWithBoxing: obj -> obj =
                unbox<obj -> obj> oldAttr.Value
                >> unbox
                >> fn
                >> box

            { oldAttr with Value = fnWithBoxing }

        let defaultWith () =
            MapMsg.MapMsg.WithValue(unbox<'oldMsg> >> fn >> box)

        let builder =
            x.AddOrReplaceScalar(MapMsg.MapMsg.Key, replaceWith, defaultWith)

        WidgetBuilder<'newMsg, 'marker>(builder.Key, builder.Attributes)

    /// Combine map and lazy. Map the widget's message type to the parent's message type, and then memoize it
    let inline lazyMap (mapFn: 'oldMsg -> 'newMsg) (viewFn: 'key -> WidgetBuilder<'oldMsg, 'marker>) (model: 'key) =
        lazy'(viewFn >> map mapFn) model
