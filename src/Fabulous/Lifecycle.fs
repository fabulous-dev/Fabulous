namespace Fabulous

module Lifecycle =
    let inline private createAttribute name : ScalarAttributeDefinition<obj, obj, obj> =
        let key =
            ScalarAttributeDefinition.CreateAttributeData<obj -> obj, obj -> obj>(
                (fun (x: obj -> obj) -> x),
                (fun _ _ -> ScalarAttributeComparison.Identical),
                (fun _oldValueOpt _newValueOpt _node -> ())
            )
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name; Convert = id }

    /// Store an event that will be triggered when a Widget has been mounted in the UI tree
    let Mounted = createAttribute "Mounted"

    /// Store an event that will be triggered when a Widget has been unmounted from the UI tree
    let Unmounted = createAttribute "Unmounted"
