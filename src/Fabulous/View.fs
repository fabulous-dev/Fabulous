namespace Fabulous

module ViewHelpers =
    let canReuseView (prevWidget: Widget) (currWidget: Widget) =
        let prevKey = prevWidget.Key

        if not(prevKey = currWidget.Key) then
            false
        else if (prevKey = Memo.MemoWidgetKey) then
            Memo.canReuseMemoizedWidget prevWidget currWidget
        else if (prevKey = Component'.WidgetKey) then
            Component'.canReuseComponent prevWidget currWidget
        else
            true

module View =
    /// Avoid recomputing the whole subtree when the key doesn't change
    let lazy'<'msg, 'key, 'marker when 'msg: equality and 'key: equality>
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
    let inline map ([<InlineIfLambda>] fn: 'oldMsg -> 'newMsg) (x: WidgetBuilder<'oldMsg, 'marker>) : WidgetBuilder<'newMsg, 'marker> =
        let replaceWith (oldAttr: ScalarAttribute) =
            let fnWithBoxing (msg: obj) =
                let oldFn = unbox<obj -> obj> oldAttr.Value

                if not(isNull msg) && typeof<'newMsg>.IsAssignableFrom(msg.GetType()) then
                    box msg
                else
                    oldFn msg |> unbox<'oldMsg> |> fn |> box

            { oldAttr with Value = fnWithBoxing }

        let defaultWith () =
            let mappedFn (msg: obj) =
                if not(isNull msg) && typeof<'newMsg>.IsAssignableFrom(msg.GetType()) then
                    box msg
                else
                    unbox<'oldMsg> msg |> fn |> box

            MapMsg.MapMsg.WithValue(mappedFn)

        let builder = x.AddOrReplaceScalar(MapMsg.MapMsg.Key, replaceWith, defaultWith)

        WidgetBuilder<'newMsg, 'marker>(builder.Key, builder.Attributes)

    /// Combine map and lazy. Map the widget's message type to the parent's message type, and then memoize it
    let inline lazyMap ([<InlineIfLambda>] mapFn: 'oldMsg -> 'newMsg) ([<InlineIfLambda>] viewFn: 'key -> WidgetBuilder<'oldMsg, 'marker>) (model: 'key) = lazy' (viewFn >> map mapFn) model
