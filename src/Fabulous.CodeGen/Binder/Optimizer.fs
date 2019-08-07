namespace Fabulous.CodeGen.Binder

open Fabulous.CodeGen.Binder.Models

module Optimizer =
    let private optimizeKnownTypesForTypeBinding (knownTypes: string array) (typeBinding: TypeBinding) =
        let replaceKnownTypeWithViewElement knownTypes typeName =
            if Array.contains typeName knownTypes then "ViewElement" else typeName
        
        let properties = typeBinding.Properties |> Array.map (fun p ->
            { p with
                InputType = replaceKnownTypeWithViewElement knownTypes p.InputType
                ModelType = replaceKnownTypeWithViewElement knownTypes p.ModelType }    
        )
        let attachedProperties = typeBinding.AttachedProperties |> Array.map (fun a ->
            { a with
                InputType = replaceKnownTypeWithViewElement knownTypes a.InputType
                ModelType = replaceKnownTypeWithViewElement knownTypes a.ModelType }    
        )
        
        { typeBinding with
             Properties = properties
             Events = typeBinding.Events
             AttachedProperties = attachedProperties }
    
    let optimizeKnownTypes (bindings: Bindings) =
        let knownTypes = bindings.Types |> Array.map (fun t -> t.Type)
        
        { bindings with
            Types = bindings.Types |> Array.map (optimizeKnownTypesForTypeBinding knownTypes) }
        
    let optimizeListsForTypeBinding (typeBinding: TypeBinding) =
        let properties = typeBinding.Properties |> Array.map (fun p ->
            if p.InputType.EndsWith(" list") && p.ModelType.EndsWith(" list") && p.ConvertInputToModel = "" then
                { p with
                    ModelType =  p.ModelType.Replace(" list",  " array")
                    ConvertInputToModel = "Array.fromList" }
            else
                p
        )
        let attachedProperties = typeBinding.AttachedProperties |> Array.map (fun p ->
            if p.InputType.EndsWith(" list") && p.ModelType.EndsWith(" list") && p.ConvertInputToModel = "" then
                { p with
                    ModelType =  p.ModelType.Replace(" list",  " array")
                    ConvertInputToModel = "Array.fromList" }
            else
                p
        )
        
        { typeBinding with
             Properties = properties
             Events = typeBinding.Events
             AttachedProperties = attachedProperties }
        
    let optimizeLists (bindings: Bindings) =
        { bindings with
            Types = bindings.Types |> Array.map optimizeListsForTypeBinding }
        
    let optimize (bindings: Bindings) =
        bindings
        |> optimizeKnownTypes
        |> optimizeLists