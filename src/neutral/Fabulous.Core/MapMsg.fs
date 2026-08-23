namespace Fabulous

open Fabulous.ScalarAttributeDefinitions

module MapMsg =
    /// Store a map function to convert a child message to a parent message.
    /// Help compose independent views using different MVU cycle and messages
    let MapMsg: SimpleScalarAttributeDefinition<obj -> obj> =
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                (fun _ _ -> ScalarAttributeComparison.Different),
                (fun _oldValueOpt newValueOpt node ->
                    match newValueOpt with
                    | ValueNone -> node.MapMsg <- None
                    | ValueSome fn -> node.MapMsg <- Some fn)
            )
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = "Fabulous_MapMsg" }
