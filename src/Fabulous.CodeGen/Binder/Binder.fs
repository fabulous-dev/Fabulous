namespace Fabulous.CodeGen.Binder

open Fabulous.CodeGen.Models
open Fabulous.CodeGen.AssemblyReader.Models
open Fabulous.CodeGen.Binder.Models
open Fabulous.CodeGen.Helpers
open System

module BinderHelpers =
    let getValueOrDefault overwrittenValue defaultValue =
        match overwrittenValue with
        | None -> defaultValue
        | Some value when String.IsNullOrWhiteSpace value -> defaultValue
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
            
    let bindMembers overwriteMembers getPositionFunc tryBindMemberFunc =
        match overwriteMembers with
        | None -> [||]
        | Some members ->
            members
            |> Array.sortBy (fun m -> match (getPositionFunc m) with Some position -> position | None -> System.Int32.MaxValue)
            |> Array.choose tryBindMemberFunc
        
module Binder =
    /// Create an attached property binding from the AssemblyReader data and Overwrite data
    let bindAttachedProperty containerTypeName baseTargetTypeFullName (readerData: AttachedPropertyReaderData) (overwriteData: AttachedPropertyOverwriteData) =
        let name = BinderHelpers.getValueOrDefault overwriteData.Name readerData.Name
        { TargetType = BinderHelpers.getValueOrDefault overwriteData.TargetType baseTargetTypeFullName
          Name = name
          UniqueName = BinderHelpers.getUniqueName containerTypeName overwriteData.UniqueName name
          DefaultValue = BinderHelpers.getValueOrDefault overwriteData.DefaultValue readerData.DefaultValue
          InputType = BinderHelpers.getValueOrDefault overwriteData.InputType readerData.Type
          ModelType = BinderHelpers.getValueOrDefault overwriteData.ModelType readerData.Type
          ConvertInputToModel = BinderHelpers.getValueOrDefault overwriteData.ConvertInputToModel ""
          ConvertModelToValue = BinderHelpers.getValueOrDefault overwriteData.ConvertModelToValue ""
          IsInherited = false }
    
    /// Create an event binding from the AssemblyReader data and Overwrite data
    let bindEvent containerTypeName (readerData: EventReaderData) (overwriteData: EventOverwriteData) =
        let name = BinderHelpers.getValueOrDefault overwriteData.Name readerData.Name
        { Position = BinderHelpers.getPosition overwriteData.Position
          Name = name
          ShortName = BinderHelpers.getShortName overwriteData.ShortName name
          UniqueName = BinderHelpers.getUniqueName containerTypeName overwriteData.UniqueName name
          InputType = BinderHelpers.getValueOrDefault overwriteData.InputType readerData.Type
          ModelType = BinderHelpers.getValueOrDefault overwriteData.ModelType readerData.EventHandlerType
          ConvertInputToModel = BinderHelpers.getValueOrDefault overwriteData.ConvertInputToModel ""
          IsInherited = false }
    
    /// Create a property binding from the AssemblyReader data and Overwrite data
    let bindProperty containerTypeName (readerData: PropertyReaderData) (overwriteData: PropertyOverwriteData) =
        let name = BinderHelpers.getValueOrDefault overwriteData.Name readerData.Name
        { Position = BinderHelpers.getPosition overwriteData.Position
          Name = name
          ShortName = BinderHelpers.getShortName overwriteData.ShortName name
          UniqueName = BinderHelpers.getUniqueName containerTypeName overwriteData.UniqueName name
          DefaultValue = BinderHelpers.getValueOrDefault overwriteData.DefaultValue readerData.DefaultValue
          InputType = BinderHelpers.getValueOrDefault overwriteData.InputType readerData.Type
          ModelType = BinderHelpers.getValueOrDefault overwriteData.ModelType readerData.Type
          ConvertInputToModel = BinderHelpers.getValueOrDefault overwriteData.ConvertInputToModel ""
          ConvertModelToValue = BinderHelpers.getValueOrDefault overwriteData.ConvertModelToValue ""
          IsInherited = false }
       
    /// Try to create an attached property binding from the Overwrite data only 
    let tryCreateAttachedProperty logger containerTypeName baseTargetTypeFullName (overwriteData: AttachedPropertyOverwriteData) =
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
                  InputType = inputType
                  ModelType = BinderHelpers.getValueOrDefault overwriteData.ModelType inputType
                  ConvertInputToModel = BinderHelpers.getValueOrDefault overwriteData.ConvertInputToModel ""
                  ConvertModelToValue = BinderHelpers.getValueOrDefault overwriteData.ConvertModelToValue ""
                  IsInherited = false }
        }
       
    /// Try to create an event binding from the Overwrite data only 
    let tryCreateEvent logger containerTypeName (overwriteData: EventOverwriteData) =
        maybe {
            use_logger logger containerTypeName "event" (BinderHelpers.getValueOrDefault overwriteData.Name "")
            
            let! name = "Name", overwriteData.Name
            let! inputType = "InputType", overwriteData.InputType
            let! modelType = "ModelType", overwriteData.ModelType
            
            return
                { Position = BinderHelpers.getPosition overwriteData.Position
                  Name = name
                  ShortName = BinderHelpers.getShortName overwriteData.ShortName name
                  UniqueName = BinderHelpers.getUniqueName containerTypeName overwriteData.UniqueName name
                  InputType = inputType
                  ModelType = modelType
                  ConvertInputToModel = BinderHelpers.getValueOrDefault overwriteData.ConvertInputToModel ""
                  IsInherited = false }
        }
       
    /// Try to create an event binding from the Overwrite data only 
    let tryCreateProperty logger containerTypeName (overwriteData: PropertyOverwriteData) =
        maybe {
            use_logger logger containerTypeName "property" (BinderHelpers.getValueOrDefault overwriteData.Name "")
            
            let! name = "Name", overwriteData.Name
            let! defaultValue = "DefaultValue", overwriteData.DefaultValue
            let! inputType = "InputType", overwriteData.InputType

            return
                { Position = BinderHelpers.getPosition overwriteData.Position
                  Name = name
                  ShortName = BinderHelpers.getShortName overwriteData.ShortName name
                  UniqueName = BinderHelpers.getUniqueName containerTypeName overwriteData.UniqueName name
                  DefaultValue = defaultValue
                  InputType = inputType
                  ModelType = BinderHelpers.getValueOrDefault overwriteData.ModelType inputType
                  ConvertInputToModel = BinderHelpers.getValueOrDefault overwriteData.ConvertInputToModel ""
                  ConvertModelToValue = BinderHelpers.getValueOrDefault overwriteData.ConvertModelToValue ""
                  IsInherited = false }
        }
    
    /// Try to bind or create an attached property binding
    let tryBindAttachedProperty (logger: Logger) containerType baseTargetType (readerData: AttachedPropertyReaderData array) (overwriteData: AttachedPropertyOverwriteData) =
        BinderHelpers.tryBindOrCreateMember
            readerData
            overwriteData.Source
            (fun a -> a.Name)
            (fun source -> logger.traceWarning (sprintf "Attached property '%s' on type '%s' not found" source containerType))
            (fun () -> tryCreateAttachedProperty logger containerType baseTargetType overwriteData)
            (fun a -> bindAttachedProperty containerType baseTargetType a overwriteData)
    
    /// Try to bind or create an event binding
    let tryBindEvent (logger: Logger) containerType (readerData: EventReaderData array) (overwriteData: EventOverwriteData) =
        BinderHelpers.tryBindOrCreateMember
            readerData
            overwriteData.Source
            (fun e -> e.Name)
            (fun source -> logger.traceWarning (sprintf "Event '%s' on type '%s' not found" source containerType))
            (fun () -> tryCreateEvent logger containerType overwriteData)
            (fun e -> bindEvent containerType e overwriteData)
    
    /// Try to bind or create a property binding
    let tryBindProperty (logger: Logger) containerType (readerData: PropertyReaderData array) (overwriteData: PropertyOverwriteData) =
        BinderHelpers.tryBindOrCreateMember
            readerData
            overwriteData.Source
            (fun p -> p.Name)
            (fun source -> logger.traceWarning (sprintf "Property '%s' on type '%s' not found" source containerType))
            (fun () -> tryCreateProperty logger containerType overwriteData)
            (fun p -> bindProperty containerType p overwriteData)
    
    /// Create a type binding
    let bindType (logger: Logger) baseAttachedPropertyTargetType (readerData: TypeReaderData) (overwriteData: TypeOverwriteData) =
        let typeName = BinderHelpers.getTypeName readerData.Name overwriteData.Name
        { Type = readerData.Name
          TypeToInstantiate = BinderHelpers.getValueOrDefault overwriteData.CustomType readerData.Name
          BaseTypeName = None
          Name = typeName
          AttachedProperties =
              BinderHelpers.bindMembers
                overwriteData.AttachedProperties
                (fun a -> a.Position)
                (tryBindAttachedProperty logger typeName baseAttachedPropertyTargetType readerData.AttachedProperties)
          Events =
              BinderHelpers.bindMembers
                overwriteData.Events
                (fun e -> e.Position)
                (tryBindEvent logger typeName readerData.Events)
          Properties =
              BinderHelpers.bindMembers
                overwriteData.Properties
                (fun p -> p.Position)
                (tryBindProperty logger typeName readerData.Properties) }
    
    /// Try to bind a type
    let tryBindType (logger: Logger) baseAttachedPropertyTargetTypeFullName (readerData: TypeReaderData array) (overwriteData: TypeOverwriteData) =
        BinderHelpers.tryBind
            readerData
            overwriteData.Type
            (fun t -> t.Name)
            (fun source -> logger.traceWarning (sprintf "Type '%s' not found" source))
            (fun t -> bindType logger baseAttachedPropertyTargetTypeFullName t overwriteData)
    
    /// Bind all declared types
    let bind (logger: Logger) (readerData: TypeReaderData array) (overwriteData: OverwriteData) =
        { Assemblies = overwriteData.Assemblies
          OutputNamespace = overwriteData.OutputNamespace
          BaseAttachedPropertyTargetType = overwriteData.BaseAttachedPropertyTargetType
          Types =
              overwriteData.Types
              |> Array.choose (tryBindType logger overwriteData.BaseAttachedPropertyTargetType readerData) }