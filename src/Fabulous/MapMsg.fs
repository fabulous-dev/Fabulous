namespace Fabulous

module View =
    let MapMsg =
        Attributes.defineScalarWithConverter<obj -> obj, _> "Fabulous_MapMsg" id ScalarAttributeComparers.noCompare (fun (value, node) ->
            node.SetMapMsg(match value with ValueNone -> id | ValueSome fn -> fn)
        )
        
    let inline map (fn: 'oldMsg -> 'newMsg) (x: WidgetBuilder<'oldMsg, 'marker>) : WidgetBuilder<'newMsg, 'marker> =
        let fnWithBoxing =
            fun (msg: obj) -> msg |> unbox<'oldMsg> |> fn |> box

        let builder =
            x.AddScalar(MapMsg.WithValue fnWithBoxing)

        WidgetBuilder<'newMsg, 'marker>(builder.Key, builder.Attributes)
