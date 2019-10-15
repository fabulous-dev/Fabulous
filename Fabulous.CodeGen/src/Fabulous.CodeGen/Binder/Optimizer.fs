namespace Fabulous.CodeGen.Binder

open Fabulous.CodeGen
open Fabulous.CodeGen.Binder.Models

module Optimizer =
    /// Apply a function to all properties
    let propertyOptimizer (canBeOptimizedFunc: BoundType -> BoundProperty -> bool) (optimizeFunc: BoundType -> BoundProperty -> BoundProperty[]) =
        let optimizeBoundProperty (boundType: BoundType) (boundProperty: BoundProperty) =                
            if canBeOptimizedFunc boundType boundProperty then
                optimizeFunc boundType boundProperty
            else
                [| boundProperty |]
        
        let optimizeBoundType (boundType: BoundType) =
            { boundType with
                Properties = boundType.Properties |> Array.collect (optimizeBoundProperty boundType) }
        
        fun boundModel ->
            { boundModel with
                Types = boundModel.Types |> Array.map optimizeBoundType }
            
    /// Apply a function to all events
    let eventOptimizer (canBeOptimizedFunc: BoundType -> BoundEvent -> bool) (optimizeFunc: BoundType -> BoundEvent -> BoundEvent[]) =
        let optimizeBoundEvent (boundType: BoundType) (boundEvent: BoundEvent) =                
            if canBeOptimizedFunc boundType boundEvent then
                optimizeFunc boundType boundEvent
            else
                [| boundEvent |]
        
        let optimizeBoundType (boundType: BoundType) =
            { boundType with
                Events = boundType.Events |> Array.collect (optimizeBoundEvent boundType) }
        
        fun boundModel ->
            { boundModel with
                Types = boundModel.Types |> Array.map optimizeBoundType }
            
    
    /// Apply a function to all types
    let typeOptimizer (canBeOptimizedFunc: BoundType -> bool) (optimizeFunc: BoundType -> BoundType[]) =
        let optimizeType boundType =
            if canBeOptimizedFunc boundType then
                optimizeFunc boundType
            else
                [| boundType |]
        
        fun boundModel ->
            { boundModel with
                Types = boundModel.Types |> Array.collect optimizeType }
    
    /// When a type references another one available in the bound model, the referenced type is replaced with ViewElement
    /// This enables recursive incremental updates
    module OptimizeKnownTypes =
        let private optimizeBoundType (knownTypes: string array) (boundType: BoundType) =
            let replaceKnownTypeWithViewElement knownTypes typeName =
                if Array.contains typeName knownTypes then "ViewElement" else typeName
            
            let properties = boundType.Properties |> Array.map (fun p ->
                { p with
                    InputType = replaceKnownTypeWithViewElement knownTypes p.InputType
                    ModelType = replaceKnownTypeWithViewElement knownTypes p.ModelType
                    CollectionData =
                        p.CollectionData
                        |> Option.map (fun cd ->
                            { cd with
                               AttachedProperties =
                                   cd.AttachedProperties |> Array.map (fun a ->
                                       { a with
                                           InputType = replaceKnownTypeWithViewElement knownTypes a.InputType
                                           ModelType = replaceKnownTypeWithViewElement knownTypes a.ModelType }) }) }
            )
            
            { boundType with Properties = properties }
        
        let apply (boundModel: BoundModel) =
            let knownTypes = boundModel.Types |> Array.map (fun t -> t.Type)
            typeOptimizer (fun _ -> true) (fun typ -> [| optimizeBoundType knownTypes typ |]) boundModel
            
    /// Optimizes storing list of data for efficiency
    /// When a property/attached property accepts a list as an input type (and no specific instructions were given in the Bindings file),
    /// the model type is changed to be an array with the corresponding ConvertInputToModel function
    module OptimizeLists =
        let private canBeOptimized (boundProperty: BoundProperty) =
            boundProperty.InputType.EndsWith(" list") && boundProperty.ModelType.EndsWith(" list") && boundProperty.ConvertInputToModel = ""
        
        let private optimizeBoundProperty (boundProperty: BoundProperty) =
            { boundProperty with
                ModelType = boundProperty.ModelType.Replace(" list",  " array")
                ConvertInputToModel = "Array.ofList"
                CollectionData =
                    boundProperty.CollectionData
                    |> Option.map (fun cd ->
                        { cd with
                            AttachedProperties =
                                cd.AttachedProperties |> Array.map (fun p ->
                                    if p.InputType.EndsWith(" list") && p.ModelType.EndsWith(" list") && p.ConvertInputToModel = "" then
                                        { p with
                                            ModelType =  p.ModelType.Replace(" list",  " array")
                                            ConvertInputToModel = "Array.ofList" }
                                    else
                                        p
                                ) }) }
        
        let apply = propertyOptimizer (fun _ prop -> canBeOptimized prop) (fun _ prop -> [| optimizeBoundProperty prop |])
            
    /// Converts .NET generic notation into F# generic notation
    module OptimizeGenerics =
        let private optimizeBoundType (boundType: BoundType) =
           { boundType with
                Type = boundType.Type.Replace("`1", "<'T>")
                TypeToInstantiate = boundType.TypeToInstantiate.Replace("`1", "<'T>") }
        
        let apply = typeOptimizer (fun _ -> true) (fun typ -> [| optimizeBoundType typ |])
        
    /// Optimize events by storing them as EventHandlers
    module OptimizeEvents =
        let private canBeOptimized (boundEvent: BoundEvent) =
            boundEvent.ConvertInputToModel = ""
        
        let private optimizeBoundEvent (boundEvent: BoundEvent) =
            { boundEvent with
                  ConvertInputToModel =
                      match boundEvent.ModelType with
                      | "System.EventHandler" -> "(fun f -> System.EventHandler(fun _sender _args -> f()))"
                      | _ when not (System.String.IsNullOrWhiteSpace(boundEvent.EventArgsType)) -> sprintf "(fun f -> System.EventHandler<%s>(fun _sender _args -> f _args))" boundEvent.EventArgsType
                      | _ -> boundEvent.ConvertInputToModel }
            
        let apply = eventOptimizer (fun _ evt -> canBeOptimized evt) (fun _ evt -> [| optimizeBoundEvent evt |])
            
    /// Reduce the number of instantiated attribute keys by regrouping similarly named and typed properties under a single UniqueName
    /// (e.g. EntryCell.Text and Entry.Text don't inherit from one another, but the Text property can be represented by a single attribute key)
    module OptimizeAttributeKeys =
        let private canBeOptimized (keysToUpdate: (string * string) array) (boundProperty: BoundProperty) =
            keysToUpdate |> Array.contains (boundProperty.Name, boundProperty.ModelType)
        
        let private optimizeBoundProperty (boundProperty: BoundProperty) =
            { boundProperty with
                UniqueName = boundProperty.Name }
        
        let apply (boundModel: BoundModel) =
            let keysToUpdate =
                boundModel.Types
                |> Array.collect (fun t -> t.Properties)
                |> Array.map (fun p -> p.Name, p.ModelType)
                |> Array.groupBy id
                |> Array.map (fun (key, items) -> (key, items.Length))
                |> Array.filter (fun (_, count) -> count > 1)
                |> Array.map (fun (key, _) -> key)
            
            propertyOptimizer (fun _ prop -> canBeOptimized keysToUpdate prop) (fun _ prop -> [| optimizeBoundProperty prop |]) boundModel

    /// Applies all optimizations to the bound model
    let optimize boundModel : WorkflowResult<BoundModel> =
        boundModel
        |> OptimizeKnownTypes.apply
        |> OptimizeLists.apply
        |> OptimizeGenerics.apply
        |> OptimizeEvents.apply
        |> OptimizeAttributeKeys.apply
        |> WorkflowResult.ok