namespace Fabulous

module View =
    let MapMsg =
        Attributes.defineScalarWithConverter<obj -> obj, _> "Fabulous_MapMsg" id ScalarAttributeComparers.noCompare (fun (value, node) ->
            match value with
            | ValueNone -> node.MapMsg <- ValueNone
            | ValueSome fn -> node.MapMsg <- ValueSome fn
        )
        
    let inline map (fn: 'oldMsg -> 'newMsg) (x: WidgetBuilder<'oldMsg, 'marker>) : WidgetBuilder<'newMsg, 'marker> =
        let fnWithBoxing =
            fun (msg: obj) -> msg |> unbox<'oldMsg> |> fn |> box

        let builder =
            x.AddScalar(MapMsg.WithValue fnWithBoxing)

        WidgetBuilder<'newMsg, 'marker>(builder.Key, builder.Attributes)
