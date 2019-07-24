namespace Fabulous.CodeGen.Binder

open Fabulous.CodeGen.Models
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
    let bindEvent containerTypeFullName (readerData: EventReaderData) (overwriteData: EventOverwriteData) =
        let name = BinderHelpers.getValueOrDefault overwriteData.Name readerData.Name
        { Name = name
          ShortName = BinderHelpers.getShortName overwriteData.ShortName name
          UniqueName = BinderHelpers.getUniqueName containerTypeFullName overwriteData.UniqueName name
          Type = BinderHelpers.getValueOrDefault overwriteData.Type readerData.Type
          EventArgsType = BinderHelpers.getValueOrDefault overwriteData.EventArgsType readerData.EventArgsType  }
    
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
    
    let tryBindProperty containerTypeFullName (readerData: PropertyReaderData array) (overwriteData: PropertyOverwriteData) =
        match overwriteData.Source with
        | None -> None
        | Some source ->
            match readerData |> Array.tryFind (fun p -> p.Name = source) with
            | None -> None
            | Some pdata -> Some (bindProperty containerTypeFullName pdata overwriteData)
    
    let bindType (readerData: TypeReaderData) (overwriteData: TypeOverwriteData) =
        { Name = readerData.Name
          CustomType = overwriteData.CustomType
          Properties =
              overwriteData.Properties
              |> Array.choose (tryBindProperty readerData.Name readerData.Properties)}
    
    let tryBindType (readerData: TypeReaderData array) (overwriteData: TypeOverwriteData) =
        match readerData |> Array.tryFind (fun t -> t.Name = overwriteData.Name) with
        | None -> None
        | Some tdata -> Some (bindType tdata overwriteData)
        
    let bind (readerData: TypeReaderData array) (overwriteData: OverwriteData) =
        { Assemblies = overwriteData.Assemblies
          OutputNamespace = overwriteData.OutputNamespace
          Types =
              overwriteData.Types
              |> Array.choose (tryBindType readerData)
        }