namespace Fabulous

module MapMsg =
    let MapMsg =
        Attributes.defineScalarWithConverter<obj -> obj, _, _>
            "Fabulous_MapMsg"
            id
            id
            ScalarAttributeComparers.noCompare
            (fun struct (value, node) ->
                match value with
                | ValueNone -> node.MapMsg <- ValueNone
                | ValueSome fn -> node.MapMsg <- ValueSome fn)
