// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen.Binder

open Fabulous.CodeGen
open Fabulous.CodeGen.Models
open Fabulous.CodeGen.AssemblyReader.Models
open Fabulous.CodeGen.Binder.Models

type Logger =
    { traceInformation: string -> unit
      traceWarning: string -> unit
      traceError: string -> unit
      getMessages: unit -> string list
      getWarnings: unit -> string list
      getErrors: unit -> string list }
    
type CheckableField =
    { Name: string
      Value: string option
      IsRequired: bool }
        
module BinderHelpers =
    let createLogger () =
        let mutable _messages = []
        let mutable _warnings = []
        let mutable _errors = []
        
        { traceInformation = fun s -> _messages <- s :: _messages
          traceWarning = fun s -> _warnings <- s :: _warnings
          traceError = fun s -> _errors <- s :: _errors
          getMessages = fun () -> List.rev _messages
          getWarnings = fun () -> List.rev _warnings
          getErrors = fun () -> List.rev _errors }
        
    let getShortName value defaultName =
        Text.getValueOrDefault value (Text.toLowerPascalCase defaultName)
        
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
        
    let either elm (cd: PropertyCollectionData option) : (string * PropertyCollectionData) option =
        match elm, cd with
        | Some elmV, None -> Some (elmV, PropertyCollectionData(ElementType = None, AttachedProperties = None))
        | None, Some cdV -> Some ("", cdV)
        | Some elmV, Some cdV -> Some (elmV, cdV)
        | None, None -> None
       
    let createBinding logger containerTypeName memberKind memberNameOpt func (fields: CheckableField list) =
        // Trace invalid values
        let invalidFields =
            fields |> List.filter (fun f -> f.IsRequired && f.Value.IsNone)
            
        match invalidFields with
        | [] ->
            let stringValues =
                fields |> List.map (fun f -> Text.getValueOrDefault f.Value "")
                
            Some (func stringValues)

        | _ ->
            let memberName = Text.getValueOrDefault memberNameOpt ""

            for field in invalidFields do
                logger.traceError (sprintf "Missing value for field %s of %s %s on type %s" field.Name memberKind memberName containerTypeName)
            None
        
module Binder =
    /// Bind an existing attached property
    let bindAttachedProperty (assemblyTypeAttachedProperty: AssemblyTypeAttachedProperty) (bindingsAttachedProperty: AttachedProperty) =
        let name = Text.getValueOrDefault bindingsAttachedProperty.Name assemblyTypeAttachedProperty.Name
        { Name = name
          UniqueName = Text.getValueOrDefault bindingsAttachedProperty.UniqueName name
          CanBeUpdated = bindingsAttachedProperty.CanBeUpdated |> Option.defaultValue true
          CustomAttributeKey = bindingsAttachedProperty.CustomAttributeKey
          DefaultValue = Text.getValueOrDefault bindingsAttachedProperty.DefaultValue assemblyTypeAttachedProperty.DefaultValue
          OriginalType = assemblyTypeAttachedProperty.Type
          InputType = Text.getValueOrDefault bindingsAttachedProperty.InputType assemblyTypeAttachedProperty.Type
          ModelType = Text.getValueOrDefault bindingsAttachedProperty.ModelType assemblyTypeAttachedProperty.Type
          ConvertInputToModel = Text.getValueOrDefault bindingsAttachedProperty.ConvertInputToModel ""
          ConvertModelToValue = Text.getValueOrDefault bindingsAttachedProperty.ConvertModelToValue ""
          UpdateCode = Text.getValueOrDefault bindingsAttachedProperty.UpdateCode "" }
       
    /// Try to create a bound attached property from the bindings data only 
    let tryCreateAttachedProperty logger containerTypeName (bindingsAttachedProperty: AttachedProperty) =
        [
            { Name = "Name"; Value = bindingsAttachedProperty.Name; IsRequired = true }
            { Name = "DefaultValue"; Value = bindingsAttachedProperty.DefaultValue; IsRequired = bindingsAttachedProperty.UpdateCode.IsNone }
            { Name = "InputType"; Value = bindingsAttachedProperty.InputType; IsRequired = true }
        ]
        |> BinderHelpers.createBinding logger containerTypeName "attached property" bindingsAttachedProperty.Name
               (fun values ->
                    let name = values.[0]
                    let defaultValue = values.[1]
                    let inputType = values.[2]
                           
                    { Name = name
                      UniqueName = Text.getValueOrDefault bindingsAttachedProperty.UniqueName name
                      CanBeUpdated = bindingsAttachedProperty.CanBeUpdated |> Option.defaultValue true
                      CustomAttributeKey = bindingsAttachedProperty.CustomAttributeKey
                      DefaultValue = defaultValue
                      OriginalType = inputType
                      InputType = inputType
                      ModelType = Text.getValueOrDefault bindingsAttachedProperty.ModelType inputType
                      ConvertInputToModel = Text.getValueOrDefault bindingsAttachedProperty.ConvertInputToModel ""
                      ConvertModelToValue = Text.getValueOrDefault bindingsAttachedProperty.ConvertModelToValue ""
                      UpdateCode = Text.getValueOrDefault bindingsAttachedProperty.UpdateCode "" }
                )
    
    /// Try to bind or create a bound attached property
    let tryBindAttachedProperty logger containerType (assemblyTypeAttachedProperty: AssemblyTypeAttachedProperty array) (overwriteData: AttachedProperty) =
        BinderHelpers.tryBindOrCreateMember
            assemblyTypeAttachedProperty
            overwriteData.Source
            (fun a -> a.Name)
            (fun source -> logger.traceWarning (sprintf "Attached property '%s' on type '%s' not found" source containerType))
            (fun () -> tryCreateAttachedProperty logger containerType overwriteData)
            (fun a -> bindAttachedProperty a overwriteData)
        
    /// Bind an existing event
    let bindEvent (assemblyTypeEvent: AssemblyTypeEvent) (bindingsTypeEvent: Event) =
        let name = Text.getValueOrDefault bindingsTypeEvent.Name assemblyTypeEvent.Name
        let inputType = sprintf "%s -> unit" assemblyTypeEvent.EventArgsType
        { Name = name
          ShortName = BinderHelpers.getShortName bindingsTypeEvent.ShortName name
          UniqueName = Text.getValueOrDefault bindingsTypeEvent.UniqueName name
          CanBeUpdated = bindingsTypeEvent.CanBeUpdated |> Option.defaultValue true
          CustomAttributeKey = bindingsTypeEvent.CustomAttributeKey
          EventArgsType = Text.getValueOrDefault bindingsTypeEvent.EventArgsType assemblyTypeEvent.EventArgsType
          InputType = Text.getValueOrDefault bindingsTypeEvent.InputType inputType
          ModelType = Text.getValueOrDefault bindingsTypeEvent.ModelType assemblyTypeEvent.EventHandlerType
          ConvertInputToModel = Text.getValueOrDefault bindingsTypeEvent.ConvertInputToModel ""
          RelatedProperties = match bindingsTypeEvent.RelatedProperties with None -> [||] | Some relatedProperties -> relatedProperties
          IsInherited = false }
    
    /// Bind an existing property
    let bindProperty logger containerTypeName (assemblyTypeProperty: AssemblyTypeProperty) (assemblyTypeAttachedProperties: AssemblyTypeAttachedProperty array) (bindingsTypeProperty: Property) =
        let name = Text.getValueOrDefault bindingsTypeProperty.Name assemblyTypeProperty.Name
        { Name = name
          ShortName = BinderHelpers.getShortName bindingsTypeProperty.ShortName name
          UniqueName = Text.getValueOrDefault bindingsTypeProperty.UniqueName name
          CanBeUpdated = bindingsTypeProperty.CanBeUpdated |> Option.defaultValue true
          CustomAttributeKey = bindingsTypeProperty.CustomAttributeKey
          DefaultValue = Text.getValueOrDefault bindingsTypeProperty.DefaultValue assemblyTypeProperty.DefaultValue
          OriginalType = assemblyTypeProperty.Type
          InputType = Text.getValueOrDefault bindingsTypeProperty.InputType assemblyTypeProperty.Type
          ModelType =
              match bindingsTypeProperty.ConvertInputToModel with
              | None ->
                  Text.eitherOrDefault bindingsTypeProperty.ModelType bindingsTypeProperty.InputType assemblyTypeProperty.Type
              | Some _ ->
                  Text.getValueOrDefault bindingsTypeProperty.ModelType assemblyTypeProperty.Type
          ConvertInputToModel = Text.getValueOrDefault bindingsTypeProperty.ConvertInputToModel ""
          ConvertModelToValue = Text.getValueOrDefault bindingsTypeProperty.ConvertModelToValue ""
          UpdateCode = Text.getValueOrDefault bindingsTypeProperty.UpdateCode ""
          CollectionData =
              BinderHelpers.either assemblyTypeProperty.CollectionElementType bindingsTypeProperty.Collection
              |> Option.map (fun (assemblyElementType, bindingsCollection) ->
                  { ElementType = Text.getValueOrDefault bindingsCollection.ElementType assemblyElementType
                    AttachedProperties =
                      BinderHelpers.bindMembers
                        bindingsCollection.AttachedProperties
                        (tryBindAttachedProperty logger containerTypeName assemblyTypeAttachedProperties) })
          IsInherited = false }
       
    /// Try to create a bound event binding from the bindings data only 
    let tryCreateEvent logger containerTypeName (bindingsTypeEvent: Event) =
        [
            { Name = "Name"; Value = bindingsTypeEvent.Name; IsRequired = true }
            { Name = "InputType"; Value = bindingsTypeEvent.InputType; IsRequired = true }
            { Name = "ModelType"; Value = bindingsTypeEvent.ModelType; IsRequired = true }
        ]
        |> BinderHelpers.createBinding logger containerTypeName "event" bindingsTypeEvent.Name
            (fun values ->
                let name = values.[0]
                let inputType = values.[1]
                let modelType = values.[2]
            
                { Name = name
                  ShortName = BinderHelpers.getShortName bindingsTypeEvent.ShortName name
                  UniqueName = Text.getValueOrDefault bindingsTypeEvent.UniqueName name
                  CanBeUpdated = bindingsTypeEvent.CanBeUpdated |> Option.defaultValue true
                  CustomAttributeKey = bindingsTypeEvent.CustomAttributeKey
                  EventArgsType = Text.getValueOrDefault bindingsTypeEvent.EventArgsType ""
                  InputType = inputType
                  ModelType = modelType
                  ConvertInputToModel = Text.getValueOrDefault bindingsTypeEvent.ConvertInputToModel ""
                  RelatedProperties = match bindingsTypeEvent.RelatedProperties with None -> [||] | Some relatedProperties -> relatedProperties
                  IsInherited = false }
            )
       
    /// Try to create a bound property from the bindings data only 
    let tryCreateProperty logger containerTypeName (assemblyTypeAttachedProperties: AssemblyTypeAttachedProperty array) (bindingsTypeProperty: Property) =
        [
            { Name = "Name"; Value = bindingsTypeProperty.Name; IsRequired = true }
            { Name = "DefaultValue"; Value = bindingsTypeProperty.DefaultValue; IsRequired = bindingsTypeProperty.UpdateCode.IsNone }
            { Name = "InputType"; Value = bindingsTypeProperty.InputType; IsRequired = true }
        ]
        |> BinderHelpers.createBinding logger containerTypeName "property" bindingsTypeProperty.Name
            (fun values ->
                let name = values.[0]
                let defaultValue = values.[1]
                let inputType = values.[2]
                
                { Name = name
                  ShortName = BinderHelpers.getShortName bindingsTypeProperty.ShortName name
                  UniqueName = Text.getValueOrDefault bindingsTypeProperty.UniqueName name
                  CanBeUpdated = bindingsTypeProperty.CanBeUpdated |> Option.defaultValue true
                  CustomAttributeKey = bindingsTypeProperty.CustomAttributeKey
                  DefaultValue = defaultValue
                  OriginalType = inputType
                  InputType = inputType
                  ModelType = Text.getValueOrDefault bindingsTypeProperty.ModelType inputType
                  ConvertInputToModel = Text.getValueOrDefault bindingsTypeProperty.ConvertInputToModel ""
                  ConvertModelToValue = Text.getValueOrDefault bindingsTypeProperty.ConvertModelToValue ""
                  UpdateCode = Text.getValueOrDefault bindingsTypeProperty.UpdateCode ""
                  CollectionData =
                      bindingsTypeProperty.Collection
                      |> Option.map (fun cd ->
                          { ElementType = Text.getValueOrDefault cd.ElementType ""
                            AttachedProperties =
                                BinderHelpers.bindMembers
                                    cd.AttachedProperties
                                    (tryBindAttachedProperty logger containerTypeName assemblyTypeAttachedProperties) })                      
                  IsInherited = false }
            )
    
    /// Try to bind or create an event binding
    let tryBindEvent logger containerType (assemblyTypeEvents: AssemblyTypeEvent array) (bindingsTypeEvent: Event) =
        BinderHelpers.tryBindOrCreateMember
            assemblyTypeEvents
            bindingsTypeEvent.Source
            (fun e -> e.Name)
            (fun source -> logger.traceWarning (sprintf "Event '%s' on type '%s' not found" source containerType))
            (fun () -> tryCreateEvent logger containerType bindingsTypeEvent)
            (fun e -> bindEvent e bindingsTypeEvent)
    
    /// Try to bind or create a property binding
    let tryBindProperty logger containerType (assemblyTypeProperties: AssemblyTypeProperty array) (assemblyTypeAttachedProperties: AssemblyTypeAttachedProperty array) (bindingsTypeProperty: Property) =
        BinderHelpers.tryBindOrCreateMember
            assemblyTypeProperties
            bindingsTypeProperty.Source
            (fun p -> p.Name)
            (fun source -> logger.traceWarning (sprintf "Property '%s' on type '%s' not found" source containerType))
            (fun () -> tryCreateProperty logger containerType assemblyTypeAttachedProperties bindingsTypeProperty)
            (fun p -> bindProperty logger containerType p assemblyTypeAttachedProperties bindingsTypeProperty)
    
    /// Bind an existing type
    let bindType logger (assemblyType: AssemblyType) shouldGenerateBindingForType (bindingsType: Type) =
        let typeName = BinderHelpers.getTypeName assemblyType.FullName bindingsType.Name
        { Id = assemblyType.FullName
          FullName = assemblyType.FullName
          ShouldGenerateBinding = shouldGenerateBindingForType
          GenericConstraint = bindingsType.GenericConstraint
          CanBeInstantiated = bindingsType.CanBeInstantiated |> Option.defaultValue assemblyType.CanBeInstantiated
          TypeToInstantiate = Text.getValueOrDefault bindingsType.CustomType assemblyType.FullName
          BaseTypeName = None
          BaseGenericConstraint = bindingsType.BaseGenericConstraint
          Name = typeName
          Events =
              BinderHelpers.bindMembers
                bindingsType.Events
                (tryBindEvent logger typeName assemblyType.Events)
          Properties =
              BinderHelpers.bindMembers
                bindingsType.Properties
                (tryBindProperty logger typeName assemblyType.Properties assemblyType.AttachedProperties)
          PrimaryConstructorMembers = bindingsType.PrimaryConstructorMembers }
    
    /// Try to bind a type
    let tryBindType logger (assemblyTypes: AssemblyType array) shouldGenerateBindingForType (bindingsType: Type) =
        BinderHelpers.tryBind
            assemblyTypes
            bindingsType.Type
            (fun t -> t.FullName)
            (fun source -> logger.traceWarning (sprintf "Type '%s' not found" source))
            (fun t -> bindType logger t shouldGenerateBindingForType bindingsType)
    
    /// Create a bound model using the types extracted from the assemblies and the mapping provided by the caller
    let bind (assemblyTypes: AssemblyType array) (mapping: Mapping, baseMappings: Mapping array option) : WorkflowResult<BoundModel> =
        let logger = BinderHelpers.createLogger ()
        
        let boundTypes =
            [ for typ in mapping.Types do
                  yield tryBindType logger assemblyTypes true typ
                    
              match baseMappings with
              | None -> ()
              | Some bs ->
                  for mapping in bs do
                      for typ in mapping.Types do
                          yield tryBindType logger assemblyTypes false typ ]
            |> Array.ofList
        
        let additionalNamespaces =
            match baseMappings with
            | None -> [||]
            | Some bs -> bs |> Array.map (fun b -> b.OutputNamespace) 
        
        let data =
            { Assemblies = mapping.Assemblies
              OutputNamespace = mapping.OutputNamespace
              AdditionalNamespaces = additionalNamespaces
              Types = boundTypes |> Array.choose id }
        
        match logger.getErrors () with
        | [] -> WorkflowResult.okWarnings data (logger.getMessages ()) (logger.getWarnings ())
        | errors -> WorkflowResult.error errors
        
        