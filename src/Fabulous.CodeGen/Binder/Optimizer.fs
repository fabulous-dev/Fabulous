namespace Fabulous.CodeGen.Binder

open Fabulous.CodeGen.Binder.Models

module Optimizer =
    let private optimizeKnownTypesForTypeBinding (knownTypes: string array) (typeBinding: TypeBinding) =
        let properties = typeBinding.Properties |> Array.map (fun p ->
            { p with
                InputType = if Array.contains p.InputType knownTypes then "ViewElement" else p.InputType
                ModelType = if Array.contains p.ModelType knownTypes then "ViewElement" else p.ModelType }    
        )
        let events = typeBinding.Events |> Array.map (fun e ->
            { e with
                EventArgsType = if Array.contains e.EventArgsType knownTypes then "ViewElement" else e.EventArgsType }    
        )
        let attachedProperties = typeBinding.AttachedProperties |> Array.map (fun a ->
            { a with
                InputType = if Array.contains a.InputType knownTypes then "ViewElement" else a.InputType
                ModelType = if Array.contains a.ModelType knownTypes then "ViewElement" else a.ModelType }    
        )
        
        { typeBinding with
             Properties = properties
             Events = events
             AttachedProperties = attachedProperties }
    
    let optimizeKnownTypes (bindings: Bindings) =
        let knownTypes = bindings.Types |> Array.map (fun t -> t.Name)
        
        { bindings with
            Types = bindings.Types |> Array.map (optimizeKnownTypesForTypeBinding knownTypes) }

