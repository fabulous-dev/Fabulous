namespace Fabulous

module Lifecycle =
    let private createAttribute name : ScalarAttributeDefinition<obj, obj, obj> =
        let key = AttributeDefinitionStore.getNextKey ()

        let definition =
            { Key = key
              Name = name
              Convert = id
              ConvertValue = id
              Compare = fun _ _ -> ScalarAttributeComparison.Identical
              UpdateNode = fun _oldValueOpt _newValueOpt _node -> () }

        AttributeDefinitionStore.set key definition
        definition
    
    /// Store an event that will be triggered when a Widget has been mounted in the UI tree
    let Mounted = createAttribute "Mounted"
    
    /// Store an event that will be triggered when a Widget has been unmounted from the UI tree
    let Unmounted = createAttribute "Unmounted"