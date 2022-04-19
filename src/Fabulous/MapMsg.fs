namespace Fabulous

open Fabulous

module MapMsg =
    /// Store a map function to convert a child message to a parent message.
    /// Help compose independent views using different MVU cycle and messages
    let MapMsg: ScalarAttributeDefinition<obj -> obj, obj -> obj, obj -> obj> =
        let key =
            ScalarAttributeDefinition.CreateAttributeData<obj -> obj, obj -> obj>(
                (fun (x: obj -> obj) -> x),
                (fun _ _ -> ScalarAttributeComparison.Different),
                (fun _oldValueOpt newValueOpt node ->
                    match newValueOpt with
                    | ValueNone -> node.MapMsg <- None
                    | ValueSome fn -> node.MapMsg <- Some fn)
            )
            |> AttributeDefinitionStore.registerScalar

        { Key = key
          Name = "Fabulous_MapMsg"
          Convert = id }
