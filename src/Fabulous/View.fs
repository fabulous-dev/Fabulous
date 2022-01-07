namespace Fabulous

module ViewHelpers =
    let canReuseView (prevWidget: Widget) (currWidget: Widget) =
        let prevKey = prevWidget.Key

        if not(prevKey = currWidget.Key) then
            false
        else if (prevKey = Memo.MemoWidgetKey) then
            Memo.canReuseMemoizedViewNode prevWidget currWidget
        else
            true

module View =
    let memo<'msg, 'key, 'marker when 'key: equality>
        (key: 'key)
        (fn: 'key -> WidgetBuilder<'msg, 'marker>)
        : WidgetBuilder<'msg, Memo.Memoized<'marker>> =

        let memo: Memo.MemoData =
            {
                KeyData = box key
                KeyComparer = fun (prev: obj) (next: obj) -> unbox<'key> prev = unbox<'key> next
                CreateWidget = fun k -> (fn(unbox<'key> k)).Compile()
                KeyTypeHash = typeof<'key>.GetHashCode ()
                MarkerTypeHash = typeof<'marker>.GetHashCode ()
            }

        WidgetBuilder<'msg, Memo.Memoized<'marker>>(
            Memo.MemoWidgetKey,
            struct ([| Memo.MemoAttribute.WithValue(memo) |], [||], [||])
        )

    let inline map (fn: 'oldMsg -> 'newMsg) (x: WidgetBuilder<'oldMsg, 'marker>) : WidgetBuilder<'newMsg, 'marker> =
        let fnWithBoxing =
            fun (msg: obj) -> msg |> unbox<'oldMsg> |> fn |> box

        let builder =
            x.AddScalar(MapMsg.MapMsg.WithValue fnWithBoxing)

        WidgetBuilder<'newMsg, 'marker>(builder.Key, builder.Attributes)
