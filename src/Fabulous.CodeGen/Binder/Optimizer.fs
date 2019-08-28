namespace Fabulous.CodeGen.Binder

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
            
    /// Optimizes efficiency when storing list of data
    /// When a property/attached property accepts a list as an input type (and no specific instructions were given in the Bindings),
    /// the model type is changed to be an array with the corresponding ConvertInputToModel function
    module OptimizeLists =
        let optimizeListsForTypeBinding (boundType: BoundType) =
            let properties = boundType.Properties |> Array.map (fun p ->
                if p.InputType.EndsWith(" list") && p.ModelType.EndsWith(" list") && p.ConvertInputToModel = "" then
                    { p with
                        ModelType = p.ModelType.Replace(" list",  " array")
                        ConvertInputToModel = "Array.fromList"
                        CollectionData =
                            p.CollectionData
                            |> Option.map (fun cd ->
                                { cd with
                                    AttachedProperties =
                                        cd.AttachedProperties |> Array.map (fun p ->
                                            if p.InputType.EndsWith(" list") && p.ModelType.EndsWith(" list") && p.ConvertInputToModel = "" then
                                                { p with
                                                    ModelType =  p.ModelType.Replace(" list",  " array")
                                                    ConvertInputToModel = "Array.fromList" }
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
        
    /// Applies all optimizations to the bound model
    let optimize boundModel =
        boundModel
        |> OptimizeKnownTypes.apply
        |> OptimizeLists.apply