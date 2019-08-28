namespace Fabulous.CodeGen.Binder

open Fabulous.CodeGen
open Fabulous.CodeGen.Models
open Fabulous.CodeGen.AssemblyReader.Models
open Fabulous.CodeGen.Binder.Models
open Fabulous.CodeGen.Helpers
open Fabulous.CodeGen.Helpers.ComputationExpressions

module BinderHelpers =
    let makeUniqueName (typeName: string) memberName =
        typeName + memberName
        
    let getShortName value defaultName =
        Text.getValueOrDefault value (Text.toLowerPascalCase defaultName)
        
    let getUniqueName (typeName: string) value defaultName =
        let defaultUniqueName = makeUniqueName typeName defaultName
        Text.getValueOrDefault value defaultUniqueName
        
    let getTypeName (typeFullName: string) value =
        let shortTypeName = typeFullName.Substring(typeFullName.LastIndexOf(".") + 1)
        Text.getValueOrDefault value shortTypeName
        
    let tryBind data source getNameFunc logNotFound bindFunc =
        let item = data |> Array.tryFind (fun m -> (getNameFunc m) = source)
        match item with
        | None -> logNotFound source; None
        | Some i -> Some (bindFunc i)
        
    let tryBindOrCreateMember members source getNameFunc logNotFound tryCreateFunc bindFunc =
        match source with
        | None -> tryCreateFunc()
        | Some source -> tryBind members source getNameFunc logNotFound bindFunc
            
    let bindMembers overwriteMembers tryBindMemberFunc =
        match overwriteMembers with
        | None -> [||]
        | Some members ->
            members
            |> Array.choose tryBindMemberFunc
        
module Binder =
    /// Create an attached property binding from the AssemblyReader data and Overwrite data
    let bindAttachedProperty containerTypeName baseTargetTypeFullName (readerData: ReaderAttachedProperty) (overwriteData: AttachedProperty) =
        let property = overwriteData :> IProperty
        let name = Text.getValueOrDefault overwriteData.Name readerData.Name
        { Name = name
          UniqueName = BinderHelpers.getUniqueName containerTypeName overwriteData.UniqueName name
          DefaultValue = Text.getValueOrDefault property.DefaultValue readerData.DefaultValue
          InputType = Text.getValueOrDefault overwriteData.InputType readerData.Type
          ModelType = Text.getValueOrDefault overwriteData.ModelType readerData.Type
          ConvertInputToModel = Text.getValueOrDefault overwriteData.ConvertInputToModel ""
          ConvertModelToValue = Text.getValueOrDefault property.ConvertModelToValue ""
          IsInherited = false }
    
    /// Create an event binding from the AssemblyReader data and Overwrite data
    let bindEvent containerTypeName (readerData: ReaderEvent) (overwriteData: Event) =
        let constructorMember = overwriteData :> IConstructorMember
        let name = Text.getValueOrDefault overwriteData.Name readerData.Name
        { Name = name
          ShortName = BinderHelpers.getShortName constructorMember.ShortName name
          UniqueName = BinderHelpers.getUniqueName containerTypeName overwriteData.UniqueName name
          InputType = Text.getValueOrDefault overwriteData.InputType readerData.Type
          ModelType = Text.getValueOrDefault overwriteData.ModelType readerData.EventHandlerType
          ConvertInputToModel = Text.getValueOrDefault overwriteData.ConvertInputToModel ""
          RelatedProperties = match overwriteData.RelatedProperties with None -> [||] | Some relatedProperties -> relatedProperties
          IsInherited = false }
    
    /// Create a property binding from the AssemblyReader data and Overwrite data
    let bindProperty containerTypeName (readerData: ReaderProperty) (overwriteData: Property) =
        let property = overwriteData :> IProperty
        let constructorMember = overwriteData :> IConstructorMember
        let name = Text.getValueOrDefault overwriteData.Name readerData.Name
        { Name = name
          ShortName = BinderHelpers.getShortName constructorMember.ShortName name
          UniqueName = BinderHelpers.getUniqueName containerTypeName overwriteData.UniqueName name
          DefaultValue = Text.getValueOrDefault property.DefaultValue readerData.DefaultValue
          OriginalType = readerData.Type
          ElementType = property.ElementType
          InputType = Text.getValueOrDefault overwriteData.InputType readerData.Type
          ModelType = Text.getValueOrDefault overwriteData.ModelType readerData.Type
          ConvertInputToModel = Text.getValueOrDefault overwriteData.ConvertInputToModel ""
          ConvertModelToValue = Text.getValueOrDefault property.ConvertModelToValue ""
          IsInherited = false }
       
    /// Try to create an attached property binding from the Overwrite data only 
    let tryCreateAttachedProperty logger containerTypeName baseTargetTypeFullName (overwriteData: AttachedProperty) =
        maybe {
            use_logger logger containerTypeName "attached property" (Text.getValueOrDefault overwriteData.Name "")
            
            let property = overwriteData :> IProperty
            
            let! name = "Name", overwriteData.Name
            let! defaultValue = "DefaultValue", property.DefaultValue
            let! inputType = "InputType", overwriteData.InputType

            return
                { Name = name
                  UniqueName = BinderHelpers.getUniqueName containerTypeName overwriteData.UniqueName name
                  DefaultValue = defaultValue
                  InputType = inputType
                  ModelType = Text.getValueOrDefault overwriteData.ModelType inputType
                  ConvertInputToModel = Text.getValueOrDefault overwriteData.ConvertInputToModel ""
                  ConvertModelToValue = Text.getValueOrDefault property.ConvertModelToValue ""
                  IsInherited = false }
        }
       
    /// Try to create an event binding from the Overwrite data only 
    let tryCreateEvent logger containerTypeName (overwriteData: Event) =
        maybe {
            use_logger logger containerTypeName "event" (Text.getValueOrDefault overwriteData.Name "")
            
            let constructorMember = overwriteData :> IConstructorMember
            
            let! name = "Name", overwriteData.Name
            let! inputType = "InputType", overwriteData.InputType
            let! modelType = "ModelType", overwriteData.ModelType
            
            return
                { Name = name
                  ShortName = BinderHelpers.getShortName constructorMember.ShortName name
                  UniqueName = BinderHelpers.getUniqueName containerTypeName overwriteData.UniqueName name
                  InputType = inputType
                  ModelType = modelType
                  ConvertInputToModel = Text.getValueOrDefault overwriteData.ConvertInputToModel ""
                  RelatedProperties = match overwriteData.RelatedProperties with None -> [||] | Some relatedProperties -> relatedProperties
                  IsInherited = false }
        }
       
    /// Try to create an event binding from the Overwrite data only 
    let tryCreateProperty logger containerTypeName (overwriteData: Property) =
        maybe {
            use_logger logger containerTypeName "property" (Text.getValueOrDefault overwriteData.Name "")
            
            let property = overwriteData :> IProperty
            let constructorMember = overwriteData :> IConstructorMember
            
            let! name = "Name", overwriteData.Name
            let! defaultValue = "DefaultValue", property.DefaultValue
            let! inputType = "InputType", overwriteData.InputType

            return
                { Name = name
                  ShortName = BinderHelpers.getShortName constructorMember.ShortName name
                  UniqueName = BinderHelpers.getUniqueName containerTypeName overwriteData.UniqueName name
                  DefaultValue = defaultValue
                  OriginalType = inputType
                  ElementType = property.ElementType
                  InputType = inputType
                  ModelType = Text.getValueOrDefault overwriteData.ModelType inputType
                  ConvertInputToModel = Text.getValueOrDefault overwriteData.ConvertInputToModel ""
                  ConvertModelToValue = Text.getValueOrDefault property.ConvertModelToValue ""
                  IsInherited = false }
        }
    
    /// Try to bind or create an attached property binding
    let tryBindAttachedProperty (logger: Logger) containerType baseTargetType (readerData: ReaderAttachedProperty array) (overwriteData: AttachedProperty) =
        BinderHelpers.tryBindOrCreateMember
            readerData
            overwriteData.Source
            (fun a -> a.Name)
            (fun source -> logger.traceWarning (sprintf "Attached property '%s' on type '%s' not found" source containerType))
            (fun () -> tryCreateAttachedProperty logger containerType baseTargetType overwriteData)
            (fun a -> bindAttachedProperty containerType baseTargetType a overwriteData)
    
    /// Try to bind or create an event binding
    let tryBindEvent (logger: Logger) containerType (readerData: ReaderEvent array) (overwriteData: Event) =
        BinderHelpers.tryBindOrCreateMember
            readerData
            overwriteData.Source
            (fun e -> e.Name)
            (fun source -> logger.traceWarning (sprintf "Event '%s' on type '%s' not found" source containerType))
            (fun () -> tryCreateEvent logger containerType overwriteData)
            (fun e -> bindEvent containerType e overwriteData)
    
    /// Try to bind or create a property binding
    let tryBindProperty (logger: Logger) containerType (readerData: ReaderProperty array) (overwriteData: Property) =
        BinderHelpers.tryBindOrCreateMember
            readerData
            overwriteData.Source
            (fun p -> p.Name)
            (fun source -> logger.traceWarning (sprintf "Property '%s' on type '%s' not found" source containerType))
            (fun () -> tryCreateProperty logger containerType overwriteData)
            (fun p -> bindProperty containerType p overwriteData)
    
    /// Create a type binding
    let bindType (logger: Logger) baseAttachedPropertyTargetType (readerData: ReaderType) (overwriteData: Type) =
        let typeName = BinderHelpers.getTypeName readerData.Name overwriteData.Name
        { Type = readerData.Name
          TypeToInstantiate = Text.getValueOrDefault overwriteData.CustomType readerData.Name
          BaseTypeName = None
          Name = typeName
          AttachedProperties =
              BinderHelpers.bindMembers
                overwriteData.AttachedProperties
                (tryBindAttachedProperty logger typeName baseAttachedPropertyTargetType readerData.AttachedProperties)
          Events =
              BinderHelpers.bindMembers
                overwriteData.Events
                (tryBindEvent logger typeName readerData.Events)
          Properties =
              BinderHelpers.bindMembers
                overwriteData.Properties
                (tryBindProperty logger typeName readerData.Properties) }
    
    /// Try to bind a type
    let tryBindType (logger: Logger) baseAttachedPropertyTargetTypeFullName (readerData: ReaderType array) (overwriteData: Type) =
        BinderHelpers.tryBind
            readerData
            overwriteData.Type
            (fun t -> t.Name)
            (fun source -> logger.traceWarning (sprintf "Type '%s' not found" source))
            (fun t -> bindType logger baseAttachedPropertyTargetTypeFullName t overwriteData)
    
    /// Bind all declared types
    let bind (logger: Logger) (baseAttachedPropertyTargetType: string) (readerData: ReaderType array) (overwriteData: OverwriteData) =
        { Assemblies = overwriteData.Assemblies
          OutputNamespace = overwriteData.OutputNamespace
          Types =
              overwriteData.Types
              |> Array.choose (tryBindType logger baseAttachedPropertyTargetType readerData) }