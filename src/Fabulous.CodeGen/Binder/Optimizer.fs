namespace Fabulous.CodeGen.Binder

open Fabulous.CodeGen
open Fabulous.CodeGen.Binder.Models

module Optimizer =
    /// When a type references another one available in the bound model, the referenced type is replaced with ViewElement
    /// This enables recursive incremental updates
    module OptimizeKnownTypes =
        let private optimizeBoundTypeWithKnownTypes (knownTypes: string array) (boundType: BoundType) =
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
                Types = boundModel.Types |> Array.map (optimizeBoundTypeWithKnownTypes knownTypes) }
            
    /// Optimizes storing list of data for efficiency
    /// When a property/attached property accepts a list as an input type (and no specific instructions were given in the Bindings file),
    /// the model type is changed to be an array with the corresponding ConvertInputToModel function
    module OptimizeLists =
        let optimizeListsForTypeBinding (boundType: BoundType) =
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
                Types = boundModel.Types |> Array.map optimizeListsForTypeBinding }
            
    /// Converts .NET generic notation into F# generic notation
    module OptimizeGenerics =
        let optimizeGenericsForTypeBinding (boundType: BoundType) =
            { boundType with
                Type = boundType.Type.Replace("`1", "<'T>")
                TypeToInstantiate = boundType.TypeToInstantiate.Replace("`1", "<'T>") }
        
        let apply (boundModel: BoundModel) =
            { boundModel with
                Types = boundModel.Types |> Array.map optimizeGenericsForTypeBinding }
            
        
    /// Applies all optimizations to the bound model
    let optimize boundModel : WorkflowResult<BoundModel> =
        let data =
            boundModel
            |> OptimizeKnownTypes.apply
            |> OptimizeLists.apply
            |> OptimizeGenerics.apply
        WorkflowResult.ok data