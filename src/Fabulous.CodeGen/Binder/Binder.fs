namespace Fabulous.CodeGen.Binder

open Fabulous.CodeGen.Models
open Fabulous.CodeGen.AssemblyReader.Models
open Fabulous.CodeGen.Binder.Models
open Fabulous.CodeGen.Helpers

module BinderHelpers =
    let getValueOrDefault overwrittenValue defaultValue =
        match overwrittenValue with
        | None -> defaultValue
        | Some value when System.String.IsNullOrWhiteSpace value -> defaultValue
        | Some value -> value

    let toLowerPascalCase (str : string) =
        match str with
        | null -> null
        | "" -> ""
        | x when x.Length = 1 -> x.ToLowerInvariant()
        | x -> string (System.Char.ToLowerInvariant(x.[0])) + x.Substring(1)
        
    let makeUniqueName (typeName: string) memberName =
        typeName + memberName
        
    let getShortName value defaultName =
        getValueOrDefault value (toLowerPascalCase defaultName)
        
    let getUniqueName (typeName: string) value defaultName =
        let defaultUniqueName = makeUniqueName typeName defaultName
        getValueOrDefault value defaultUniqueName
        
    let getTypeName (typeFullName: string) value =
        let shortTypeName = typeFullName.Substring(typeFullName.LastIndexOf(".") + 1)
        getValueOrDefault value shortTypeName
        
    let getPosition positionOpt =
        match positionOpt with
        | Some position -> position
        | None -> System.Int32.MaxValue
        
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
        let name = BinderHelpers.getValueOrDefault overwriteData.Name readerData.Name
        { TargetType = BinderHelpers.getValueOrDefault overwriteData.TargetType baseTargetTypeFullName
          Name = name
          UniqueName = BinderHelpers.getUniqueName containerTypeName overwriteData.UniqueName name
          DefaultValue = BinderHelpers.getValueOrDefault overwriteData.DefaultValue readerData.DefaultValue
          ElementType = overwriteData.ElementType
          InputType = BinderHelpers.getValueOrDefault overwriteData.InputType readerData.Type
          ModelType = BinderHelpers.getValueOrDefault overwriteData.ModelType readerData.Type
          ConvertInputToModel = BinderHelpers.getValueOrDefault overwriteData.ConvertInputToModel ""
          ConvertModelToValue = BinderHelpers.getValueOrDefault overwriteData.ConvertModelToValue ""
          IsInherited = false }
    
    /// Create an event binding from the AssemblyReader data and Overwrite data
    let bindEvent containerTypeName (readerData: ReaderEvent) (overwriteData: Event) =
        let name = BinderHelpers.getValueOrDefault overwriteData.Name readerData.Name
        { Name = name
          ShortName = BinderHelpers.getShortName overwriteData.ShortName name
          UniqueName = BinderHelpers.getUniqueName containerTypeName overwriteData.UniqueName name
          InputType = BinderHelpers.getValueOrDefault overwriteData.InputType readerData.Type
          ModelType = BinderHelpers.getValueOrDefault overwriteData.ModelType readerData.EventHandlerType
          ConvertInputToModel = BinderHelpers.getValueOrDefault overwriteData.ConvertInputToModel ""
          RelatedProperties = match overwriteData.RelatedProperties with None -> [||] | Some relatedProperties -> relatedProperties
          IsInherited = false }
    
    /// Create a property binding from the AssemblyReader data and Overwrite data
    let bindProperty containerTypeName (readerData: ReaderProperty) (overwriteData: Property) =
        let name = BinderHelpers.getValueOrDefault overwriteData.Name readerData.Name
        { Name = name
          ShortName = BinderHelpers.getShortName overwriteData.ShortName name
          UniqueName = BinderHelpers.getUniqueName containerTypeName overwriteData.UniqueName name
          DefaultValue = BinderHelpers.getValueOrDefault overwriteData.DefaultValue readerData.DefaultValue
          OriginalType = readerData.Type
          ElementType = overwriteData.ElementType
          InputType = BinderHelpers.getValueOrDefault overwriteData.InputType readerData.Type
          ModelType = BinderHelpers.getValueOrDefault overwriteData.ModelType readerData.Type
          ConvertInputToModel = BinderHelpers.getValueOrDefault overwriteData.ConvertInputToModel ""
          ConvertModelToValue = BinderHelpers.getValueOrDefault overwriteData.ConvertModelToValue ""
          IsInherited = false }
       
    /// Try to create an attached property binding from the Overwrite data only 
    let tryCreateAttachedProperty logger containerTypeName baseTargetTypeFullName (overwriteData: AttachedProperty) =
        maybe {
            use_logger logger containerTypeName "attached property" (BinderHelpers.getValueOrDefault overwriteData.Name "")
            
            let! name = "Name", overwriteData.Name
            let! defaultValue = "DefaultValue", overwriteData.DefaultValue
            let! inputType = "InputType", overwriteData.InputType

            return
                { TargetType = BinderHelpers.getValueOrDefault overwriteData.TargetType baseTargetTypeFullName
                  Name = name
                  UniqueName = BinderHelpers.getUniqueName containerTypeName overwriteData.UniqueName name
                  DefaultValue = defaultValue
                  ElementType = overwriteData.ElementType
                  InputType = inputType
                  ModelType = BinderHelpers.getValueOrDefault overwriteData.ModelType inputType
                  ConvertInputToModel = BinderHelpers.getValueOrDefault overwriteData.ConvertInputToModel ""
                  ConvertModelToValue = BinderHelpers.getValueOrDefault overwriteData.ConvertModelToValue ""
                  IsInherited = false }
        }
       
    /// Try to create an event binding from the Overwrite data only 
    let tryCreateEvent logger containerTypeName (overwriteData: Event) =
        maybe {
            use_logger logger containerTypeName "event" (BinderHelpers.getValueOrDefault overwriteData.Name "")
            
            let! name = "Name", overwriteData.Name
            let! inputType = "InputType", overwriteData.InputType
            let! modelType = "ModelType", overwriteData.ModelType
            
            return
                { Name = name
                  ShortName = BinderHelpers.getShortName overwriteData.ShortName name
                  UniqueName = BinderHelpers.getUniqueName containerTypeName overwriteData.UniqueName name
                  InputType = inputType
                  ModelType = modelType
                  ConvertInputToModel = BinderHelpers.getValueOrDefault overwriteData.ConvertInputToModel ""
                  RelatedProperties = match overwriteData.RelatedProperties with None -> [||] | Some relatedProperties -> relatedProperties
                  IsInherited = false }
        }
       
    /// Try to create an event binding from the Overwrite data only 
    let tryCreateProperty logger containerTypeName (overwriteData: Property) =
        maybe {
            use_logger logger containerTypeName "property" (BinderHelpers.getValueOrDefault overwriteData.Name "")
            
            let! name = "Name", overwriteData.Name
            let! defaultValue = "DefaultValue", overwriteData.DefaultValue
            let! inputType = "InputType", overwriteData.InputType

            return
                { Name = name
                  ShortName = BinderHelpers.getShortName overwriteData.ShortName name
                  UniqueName = BinderHelpers.getUniqueName containerTypeName overwriteData.UniqueName name
                  DefaultValue = defaultValue
                  OriginalType = inputType
                  ElementType = overwriteData.ElementType
                  InputType = inputType
                  ModelType = BinderHelpers.getValueOrDefault overwriteData.ModelType inputType
                  ConvertInputToModel = BinderHelpers.getValueOrDefault overwriteData.ConvertInputToModel ""
                  ConvertModelToValue = BinderHelpers.getValueOrDefault overwriteData.ConvertModelToValue ""
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
          TypeToInstantiate = BinderHelpers.getValueOrDefault overwriteData.CustomType readerData.Name
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
    let bind (logger: Logger) (readerData: ReaderType array) (overwriteData: OverwriteData) =
        { Assemblies = overwriteData.Assemblies
          OutputNamespace = overwriteData.OutputNamespace
          BaseAttachedPropertyTargetType = overwriteData.BaseAttachedPropertyTargetType
          Types =
              overwriteData.Types
              |> Array.choose (tryBindType logger overwriteData.BaseAttachedPropertyTargetType readerData) }