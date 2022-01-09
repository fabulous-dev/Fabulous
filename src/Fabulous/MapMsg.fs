namespace Fabulous

module MapMsg =
    let MapMsg =
        Attributes.defineScalarWithConverter<obj -> obj, _>
            "Fabulous_MapMsg"
            id
            ScalarAttributeComparers.noCompare
            (fun (value, node) ->
                match value with
                | ValueNone -> node.MapMsg <- ValueNone
                | ValueSome fn -> node.MapMsg <- ValueSome fn)
