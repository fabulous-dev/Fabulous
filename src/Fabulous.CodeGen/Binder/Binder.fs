namespace Fabulous.CodeGen.Binder

open Fabulous.CodeGen.Models
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
        
    let makeUniqueName (typeFullName: string) memberName =
        let typeName = typeFullName.Substring(typeFullName.LastIndexOf(".") + 1)
        typeName + memberName
        
    let getShortName value defaultName =
        getValueOrDefault value (toLowerPascalCase defaultName)
        
    let getUniqueName (typeFullName: string) value defaultName =
        let typeName = typeFullName.Substring(typeFullName.LastIndexOf(".") + 1)
        let defaultUniqueName = typeName + defaultName
        getValueOrDefault value defaultUniqueName
        
module Binder =
    /// Create an attached property binding from the AssemblyReader data and Overwrite data
    let bindAttachedProperty containerTypeFullName baseTargetTypeFullName (readerData: AttachedPropertyReaderData) (overwriteData: AttachedPropertyOverwriteData) =
        let name = BinderHelpers.getValueOrDefault overwriteData.Name readerData.Name
        { TargetType = BinderHelpers.getValueOrDefault overwriteData.TargetType baseTargetTypeFullName
          Name = name
          UniqueName = BinderHelpers.getUniqueName containerTypeFullName overwriteData.UniqueName name
          DefaultValue = BinderHelpers.getValueOrDefault overwriteData.DefaultValue readerData.DefaultValue
          InputType = BinderHelpers.getValueOrDefault overwriteData.InputType readerData.Type
          ModelType = BinderHelpers.getValueOrDefault overwriteData.ModelType readerData.Type
          ConvertInputToModel = BinderHelpers.getValueOrDefault overwriteData.ConvertInputToModel ""
          ConvertModelToValue = BinderHelpers.getValueOrDefault overwriteData.ConvertModelToValue "" }
    
    /// Create an event binding from the AssemblyReader data and Overwrite data
    let bindEvent containerTypeFullName (readerData: EventReaderData) (overwriteData: EventOverwriteData) =
        let name = BinderHelpers.getValueOrDefault overwriteData.Name readerData.Name
        { Name = name
          ShortName = BinderHelpers.getShortName overwriteData.ShortName name
          UniqueName = BinderHelpers.getUniqueName containerTypeFullName overwriteData.UniqueName name
          Type = BinderHelpers.getValueOrDefault overwriteData.Type readerData.Type
          EventArgsType = BinderHelpers.getValueOrDefault overwriteData.EventArgsType readerData.EventArgsType }
    
    /// Create a property binding from the AssemblyReader data and Overwrite data
    let bindProperty containerTypeFullName (readerData: PropertyReaderData) (overwriteData: PropertyOverwriteData) =
        let name = BinderHelpers.getValueOrDefault overwriteData.Name readerData.Name
        { Name = name
          ShortName = BinderHelpers.getShortName overwriteData.ShortName name
          UniqueName = BinderHelpers.getUniqueName containerTypeFullName overwriteData.UniqueName name
          DefaultValue = BinderHelpers.getValueOrDefault overwriteData.DefaultValue readerData.DefaultValue
          InputType = BinderHelpers.getValueOrDefault overwriteData.InputType readerData.Type
          ModelType = BinderHelpers.getValueOrDefault overwriteData.ModelType readerData.Type
          ConvertInputToModel = BinderHelpers.getValueOrDefault overwriteData.ConvertInputToModel ""
          ConvertModelToValue = BinderHelpers.getValueOrDefault overwriteData.ConvertModelToValue "" }
       
    /// Try to create an attached property binding from the Overwrite data only 
    let tryCreateAttachedProperty containerTypeFullName baseTargetTypeFullName (overwriteData: AttachedPropertyOverwriteData) =
        maybe {
            let! name = overwriteData.Name
            let! defaultValue = overwriteData.DefaultValue
            let! inputType = overwriteData.InputType
            let! modelType = overwriteData.ModelType

            return
                { TargetType = BinderHelpers.getValueOrDefault overwriteData.TargetType baseTargetTypeFullName
                  Name = name
                  UniqueName = BinderHelpers.getUniqueName containerTypeFullName overwriteData.UniqueName name
                  DefaultValue = defaultValue
                  InputType = inputType
                  ModelType = modelType
                  ConvertInputToModel = BinderHelpers.getValueOrDefault overwriteData.ConvertInputToModel ""
                  ConvertModelToValue = BinderHelpers.getValueOrDefault overwriteData.ConvertModelToValue "" }
        }
       
    /// Try to create an event binding from the Overwrite data only 
    let tryCreateEvent containerTypeFullName (overwriteData: EventOverwriteData) =
        maybe {
            let! name = overwriteData.Name
            let! ``type`` = overwriteData.Type
            let! eventArgsType = overwriteData.EventArgsType
            
            return
                { Name = name
                  ShortName = BinderHelpers.getShortName overwriteData.ShortName name
                  UniqueName = BinderHelpers.getUniqueName containerTypeFullName overwriteData.UniqueName name
                  Type = ``type``
                  EventArgsType = eventArgsType }
        }
       
    /// Try to create an event binding from the Overwrite data only 
    let tryCreateProperty containerTypeFullName (overwriteData: PropertyOverwriteData) =
        maybe {
            let! name = overwriteData.Name
            let! defaultValue = overwriteData.DefaultValue
            let! inputType = overwriteData.InputType
            let! modelType = overwriteData.ModelType

            return
                { Name = name
                  ShortName = BinderHelpers.getShortName overwriteData.ShortName name
                  UniqueName = BinderHelpers.getUniqueName containerTypeFullName overwriteData.UniqueName name
                  DefaultValue = defaultValue
                  InputType = inputType
                  ModelType = modelType
                  ConvertInputToModel = BinderHelpers.getValueOrDefault overwriteData.ConvertInputToModel ""
                  ConvertModelToValue = BinderHelpers.getValueOrDefault overwriteData.ConvertModelToValue "" }
        }
    
    /// Try to bind or create an attached property binding
    let tryBindAttachedProperty containerType baseTargetType (readerData: AttachedPropertyReaderData array) (overwriteData: AttachedPropertyOverwriteData) =
        match overwriteData.Source with
        | None -> tryCreateAttachedProperty containerType baseTargetType overwriteData
        | Some source ->
            readerData
            |> Array.tryFind (fun a -> a.Name = source)
            |> Option.map (fun adata -> bindAttachedProperty containerType baseTargetType adata overwriteData)
    
    /// Try to bind or create an event binding
    let tryBindEvent containerType (readerData: EventReaderData array) (overwriteData: EventOverwriteData) =
        match overwriteData.Source with
        | None -> tryCreateEvent containerType overwriteData
        | Some source ->
            readerData
            |> Array.tryFind (fun e -> e.Name = source)
            |> Option.map (fun edata -> bindEvent containerType edata overwriteData)
    
    /// Try to bind or create a property binding
    let tryBindProperty containerType (readerData: PropertyReaderData array) (overwriteData: PropertyOverwriteData) =
        match overwriteData.Source with
        | None -> tryCreateProperty containerType overwriteData
        | Some source ->
            readerData
            |> Array.tryFind (fun p -> p.Name = source)
            |> Option.map (fun pdata -> bindProperty containerType pdata overwriteData)
    
    /// Create a type binding
    let bindType baseAttachedPropertyTargetType (readerData: TypeReaderData) (overwriteData: TypeOverwriteData) =
        { Name = readerData.Name
          CustomType = overwriteData.CustomType
          AttachedProperties =
              match overwriteData.AttachedProperties with
              | None -> [||]
              | Some attachedProperties ->
                attachedProperties
                |> Array.sortBy (fun a -> match a.Position with Some position -> position | None -> System.Int32.MaxValue)
                |> Array.choose (tryBindAttachedProperty readerData.Name baseAttachedPropertyTargetType readerData.AttachedProperties)
          Events =
              match overwriteData.Events with
              | None -> [||]
              | Some events ->
                events
                |> Array.sortBy (fun e -> match e.Position with Some position -> position | None -> System.Int32.MaxValue)
                |> Array.choose (tryBindEvent readerData.Name readerData.Events)
          Properties =
              match overwriteData.Properties with
              | None -> [||]
              | Some properties ->
                properties
                |> Array.sortBy (fun p -> match p.Position with Some position -> position | None -> System.Int32.MaxValue)
                |> Array.choose (tryBindProperty readerData.Name readerData.Properties)}
    
    /// Try to bind a type
    let tryBindType baseAttachedPropertyTargetTypeFullName (readerData: TypeReaderData array) (overwriteData: TypeOverwriteData) =
        readerData
        |> Array.tryFind (fun t -> t.Name = overwriteData.Name)
        |> Option.map (fun tdata -> bindType baseAttachedPropertyTargetTypeFullName tdata overwriteData)
    
    /// Bind all declared types
    let bind (readerData: TypeReaderData array) (overwriteData: OverwriteData) =
        { Assemblies = overwriteData.Assemblies
          OutputNamespace = overwriteData.OutputNamespace
          BaseAttachedPropertyTargetType = overwriteData.BaseAttachedPropertyTargetType
          Types =
              overwriteData.Types
              |> Array.choose (tryBindType overwriteData.BaseAttachedPropertyTargetType readerData) }