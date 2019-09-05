namespace Fabulous.XamarinForms.Generator

open Fabulous.CodeGen
open Fabulous.CodeGen.Binder
open Fabulous.CodeGen.Binder.Models

module XFOptimizer =
    /// Optimize command properties by asking for an F# function for the input type instead of ICommand
    module OptimizeCommands =
        let optimizeForBoundProperty (boundProperty: BoundProperty) =
            if boundProperty.InputType <> boundProperty.ModelType then
                boundProperty // We shouldn't optimize an already overridden property
            else
                match boundProperty.ModelType with
                | "System.Windows.Input.ICommand" ->
                    { boundProperty with
                        InputType = "unit -> unit"
                        ConvertInputToModel = "ViewConverters.makeCommand" }
                | _ ->
                    boundProperty
            
        let optimizeForBoundType (boundType: BoundType) =
            { boundType with
                Properties = boundType.Properties |> Array.map optimizeForBoundProperty }
        
        let apply boundModel =
            { boundModel with
                Types = boundModel.Types |> Array.map optimizeForBoundType }
    
    let optimize =
        let xfOptimize boundModel =
            boundModel
            |> OptimizeCommands.apply
        
        Optimizer.optimize
        >> WorkflowResult.map xfOptimize

