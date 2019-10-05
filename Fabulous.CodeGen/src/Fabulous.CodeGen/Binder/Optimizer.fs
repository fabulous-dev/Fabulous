namespace Fabulous.CodeGen.Binder

open Fabulous.CodeGen
open Fabulous.CodeGen.Binder.Models

module Optimizer =
    /// When a type references another one available in the bound model, the referenced type is replaced with ViewElement
    /// This enables recursive incremental updates
    module OptimizeKnownTypes =
        let private optimizeForBoundType (knownTypes: string array) (boundType: BoundType) =
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
            { boundModel with
                Types = boundModel.Types |> Array.map (optimizeForBoundType knownTypes) }
            
    /// Optimizes storing list of data for efficiency
    /// When a property/attached property accepts a list as an input type (and no specific instructions were given in the Bindings file),
    /// the model type is changed to be an array with the corresponding ConvertInputToModel function
    module OptimizeLists =
        let private optimizeForBoundType (boundType: BoundType) =
            let properties = boundType.Properties |> Array.map (fun p ->
                if p.InputType.EndsWith(" list") && p.ModelType.EndsWith(" list") && p.ConvertInputToModel = "" then
                    { p with
                        ModelType = p.ModelType.Replace(" list",  " array")
                        ConvertInputToModel = "Array.ofList"
                        CollectionData =
                            p.CollectionData
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
                else
                    p
            )
            
            { boundType with
                 Properties = properties
                 Events = boundType.Events }
            
        let apply (boundModel: BoundModel) =
            { boundModel with
                Types = boundModel.Types |> Array.map optimizeForBoundType }
            
    /// Converts .NET generic notation into F# generic notation
    module OptimizeGenerics =
        let private optimizeForBoundType (boundType: BoundType) =
            { boundType with
                Type = boundType.Type.Replace("`1", "<'T>")
                TypeToInstantiate = boundType.TypeToInstantiate.Replace("`1", "<'T>") }
        
        let apply (boundModel: BoundModel) =
            { boundModel with
                Types = boundModel.Types |> Array.map optimizeForBoundType }
        
    /// Optimize events by storing them as EventHandlers
    module OptimizeEvents =
        let private optimizeForBoundEvent (boundEvent: BoundEvent) =
            if not (System.String.IsNullOrWhiteSpace(boundEvent.ConvertInputToModel)) then
                boundEvent // Should not optimize if convert input to model specified by user
            else
                { boundEvent with
                    ConvertInputToModel =
                        match boundEvent.ModelType with
                        | "System.EventHandler" -> "(fun f -> System.EventHandler(fun _sender _args -> f()))"
                        | _ when not (System.String.IsNullOrWhiteSpace(boundEvent.EventArgsType)) -> sprintf "(fun f -> System.EventHandler<%s>(fun _sender _args -> f _args))" boundEvent.EventArgsType
                        | _ -> boundEvent.ConvertInputToModel }

        let private optimizeForBoundType (boundType: BoundType) =
            { boundType with
                Events = boundType.Events |> Array.map optimizeForBoundEvent }
            
        let apply (boundModel: BoundModel) =
            { boundModel with
                Types = boundModel.Types |> Array.map optimizeForBoundType }
            
    /// Reduce the number of instantiated attribute keys by regrouping similarly named and typed properties under a single UniqueName
    /// (e.g. EntryCell.Text and Entry.Text don't inherit from one another, but the Text property can be represented by a single attribute key)
    module OptimizeAttributeKeys =
        let private optimizeForBoundProperty (keysToUpdate: (string * string) array) (boundProperty: BoundProperty) =
            if not (keysToUpdate |> Array.contains (boundProperty.Name, boundProperty.ModelType)) then
                boundProperty
            else
                { boundProperty with
                    UniqueName = boundProperty.Name }        
        
        let private optimizeForBoundType (keysToUpdate: (string * string) array) (boundType: BoundType) =
            { boundType with
                Properties = boundType.Properties |> Array.map (optimizeForBoundProperty keysToUpdate) }
        
        let apply (boundModel: BoundModel) =
            let keysToUpdate =
                boundModel.Types
                |> Array.collect (fun t -> t.Properties)
                |> Array.map (fun p -> p.Name, p.ModelType)
                |> Array.groupBy id
                |> Array.map (fun (key, items) -> (key, items.Length))
                |> Array.filter (fun (_, count) -> count > 1)
                |> Array.map (fun (key, _) -> key)
                
            { boundModel with
                Types = boundModel.Types |> Array.map (optimizeForBoundType keysToUpdate) }

    /// Applies all optimizations to the bound model
    let optimize boundModel : WorkflowResult<BoundModel> =
        boundModel
        |> OptimizeKnownTypes.apply
        |> OptimizeLists.apply
        |> OptimizeGenerics.apply
        |> OptimizeEvents.apply
        |> OptimizeAttributeKeys.apply
        |> WorkflowResult.ok