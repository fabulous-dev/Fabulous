namespace Fabulous

open Fabulous.ScalarAttributeDefinitions

module Lifecycle =
    let inline private createAttribute name : SimpleScalarAttributeDefinition<obj> =
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData((fun _ _ -> ScalarAttributeComparison.Identical), (fun _oldValueOpt _newValueOpt _node -> ()))
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }

    /// Store an event that will be triggered when a Widget has been mounted in the UI tree
    let Mounted = createAttribute "Mounted"

    /// Store an event that will be triggered when a Widget has been unmounted from the UI tree
    let Unmounted = createAttribute "Unmounted"
