namespace Fabulous.XamarinForms.Generator

open Fabulous.CodeGen
open Fabulous.CodeGen.Binder
open Fabulous.CodeGen.Binder.Models

module XFOptimizer =
    let optimizerForProperty (optimizePropertyFunc: BoundProperty -> BoundProperty) =
        let optimizeBoundProperty (boundProperty: BoundProperty) =
            let canBeOptimized =
                boundProperty.InputType = boundProperty.ModelType
                && boundProperty.ConvertModelToValue = ""
                && boundProperty.UpdateCode = ""
                
            if canBeOptimized then
                optimizePropertyFunc boundProperty
            else
                boundProperty
        
        let optimizeBoundType (boundType: BoundType) =
            { boundType with
                Properties = boundType.Properties |> Array.map optimizeBoundProperty }
        
        fun boundModel ->
            { boundModel with
                Types = boundModel.Types |> Array.map optimizeBoundType }
    
    /// Optimize command properties by asking for an F# function for the input type instead of ICommand
    module OptimizeCommands =
        let optimizeBoundProperty (boundProperty: BoundProperty) =
            match boundProperty.ModelType with
            | "System.Windows.Input.ICommand" ->
                { boundProperty with
                    InputType = "unit -> unit"
                    ConvertInputToModel = "ViewConverters.makeCommand" }
            | _ ->
                boundProperty
        
        let apply = optimizerForProperty optimizeBoundProperty
    
    /// Optimize ImageSource properties by asking for InputTypes.Image instead of ImageSource  
    module OptimizeImageSource =
        let optimizeBoundProperty (boundProperty: BoundProperty) =
            match boundProperty.ModelType with
            | "Xamarin.Forms.ImageSource" ->
                { boundProperty with
                    InputType = "Fabulous.XamarinForms.InputTypes.Image"
                    ModelType = "Fabulous.XamarinForms.InputTypes.Image"
                    ConvertModelToValue = "ViewConverters.convertFabulousImageToXamarinFormsImageSource" }
            | _ ->
                boundProperty
        
        let apply = optimizerForProperty optimizeBoundProperty
    
    let optimize =
        let xfOptimize boundModel =
            boundModel
            |> OptimizeCommands.apply
            |> OptimizeImageSource.apply
        
        Optimizer.optimize
        >> WorkflowResult.map xfOptimize

