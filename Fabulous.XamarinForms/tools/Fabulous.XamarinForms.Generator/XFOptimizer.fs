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
        let optimizeBoundProperty (typeName: string) (boundProperty: BoundProperty) : BoundProperty[] =
            match boundProperty.ModelType with
            | "System.Windows.Input.ICommand" ->
                
                [|
                    // Accepts a function but don't apply it now
                    { boundProperty with
                        InputType = "unit -> unit"
                        ModelType = "unit -> unit"
                        UpdateCode = "(fun _ _ _ -> ())" }
                    
                    // Accepts a boolean to know when the function can be executed
                    // Creates a Command for both CanExecute and the function
                    { Name = sprintf "%sCanExecute" boundProperty.Name
                      ShortName = sprintf "%sCanExecute" boundProperty.ShortName
                      UniqueName = sprintf "%sCanExecute" boundProperty.UniqueName
                      CanBeUpdated = true
                      DefaultValue = "true"
                      OriginalType = "bool"
                      InputType = "bool"
                      ModelType = "bool"
                      ConvertInputToModel = ""
                      ConvertModelToValue = ""
                      UpdateCode = sprintf "ViewUpdaters.updateCommand prev%sOpt curr%sOpt (fun _target -> ()) (fun (target: %s) cmd -> target.%s <- cmd)" boundProperty.UniqueName boundProperty.UniqueName typeName boundProperty.Name
                      CollectionData = None
                      IsInherited = false }
                |]
                
                
            | _ ->
                [| boundProperty |]
                
        let optimizeBoundType (boundType: BoundType) =
            { boundType with
                Properties = boundType.Properties |> Array.collect (optimizeBoundProperty boundType.Type) }
        
        let apply (boundModel: BoundModel) =
            { boundModel with
                Types = boundModel.Types |> Array.map optimizeBoundType }
    
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

