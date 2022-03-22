namespace Fabulous

open Fabulous

module Dispatch =
    let dispatchMsgOnViewNode (node: IViewNode) msg =
        let mutable parentOpt = node.Parent

        let mutable mapMsg =
            match node.MapMsg with
            | ValueNone -> id
            | ValueSome fn -> fn

        while parentOpt.IsSome do
            let parent = parentOpt.Value
            parentOpt <- parent.Parent

            mapMsg <-
                match parent.MapMsg with
                | ValueNone -> mapMsg
                | ValueSome fn -> mapMsg >> fn

        let newMsg = mapMsg msg
        node.TreeContext.Dispatch(newMsg)

module Lifecycle =
    let private createAttribute name : ScalarAttributeDefinition<obj, obj, obj> =
        let key = AttributeDefinitionStore.getNextKey ()

        let definition =
            { Key = key
              Name = name
              Convert = id
              ConvertValue = id
              Compare = fun _ _ -> ScalarAttributeComparison.Identical
              UpdateNode = fun _newValueOpt _node -> () }

        AttributeDefinitionStore.set key definition
        definition
        
    
    /// Store an event that will be triggered when a Widget will be mounted in the UI tree
    let WillMountAttribute = createAttribute "WillMount"
    
    /// Store an event that will be triggered when a Widget has been mounted in the UI tree
    let DidMountAttribute = createAttribute "DidMount"
    
    /// Store an event that will be triggered when a Widget will be unmounted from the UI tree
    let WillUnmountAttribute = createAttribute "WillUnmount"
    
    /// Store an event that will be triggered when a Widget has been unmounted from the UI tree
    let DidUnmountAttribute = createAttribute "DidUnmount"