namespace Fabulous.CodeGen.Binder

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
    /// Bind an existing attached property
    let bindAttachedProperty containerTypeName (assemblyTypeAttachedProperty: AssemblyTypeAttachedProperty) (bindingsAttachedProperty: AttachedProperty) =
        let name = Text.getValueOrDefault bindingsAttachedProperty.Name assemblyTypeAttachedProperty.Name
        { Name = name
          UniqueName = BinderHelpers.getUniqueName containerTypeName bindingsAttachedProperty.UniqueName name
          DefaultValue = Text.getValueOrDefault bindingsAttachedProperty.DefaultValue assemblyTypeAttachedProperty.DefaultValue
          InputType = Text.getValueOrDefault bindingsAttachedProperty.InputType assemblyTypeAttachedProperty.Type
          ModelType = Text.getValueOrDefault bindingsAttachedProperty.ModelType assemblyTypeAttachedProperty.Type
          ConvertInputToModel = Text.getValueOrDefault bindingsAttachedProperty.ConvertInputToModel ""
          ConvertModelToValue = Text.getValueOrDefault bindingsAttachedProperty.ConvertModelToValue ""
          UpdateCode = Text.getValueOrDefault bindingsAttachedProperty.UpdateCode "" }
       
    /// Try to create a bound attached property from the bindings data only 
    let tryCreateAttachedProperty containerTypeName (bindingsAttachedProperty: AttachedProperty) =
        maybe {
            use_logger containerTypeName "attached property" (Text.getValueOrDefault bindingsAttachedProperty.Name "")
            
            let! name = "Name", bindingsAttachedProperty.Name
            let! defaultValue = "DefaultValue", bindingsAttachedProperty.DefaultValue
            let! inputType = "InputType", bindingsAttachedProperty.InputType

            return
                { Name = name
                  UniqueName = BinderHelpers.getUniqueName containerTypeName bindingsAttachedProperty.UniqueName name
                  DefaultValue = defaultValue
                  InputType = inputType
                  ModelType = Text.getValueOrDefault bindingsAttachedProperty.ModelType inputType
                  ConvertInputToModel = Text.getValueOrDefault bindingsAttachedProperty.ConvertInputToModel ""
                  ConvertModelToValue = Text.getValueOrDefault bindingsAttachedProperty.ConvertModelToValue ""
                  UpdateCode = Text.getValueOrDefault bindingsAttachedProperty.UpdateCode "" }
        }
    
    /// Try to bind or create a bound attached property
    let tryBindAttachedProperty containerType (assemblyTypeAttachedProperty: AssemblyTypeAttachedProperty array) (overwriteData: AttachedProperty) =
        BinderHelpers.tryBindOrCreateMember
            assemblyTypeAttachedProperty
            overwriteData.Source
            (fun a -> a.Name)
            (fun source -> sprintf "Attached property '%s' on type '%s' not found" source containerType)
            (fun () -> tryCreateAttachedProperty containerType overwriteData)
            (fun a -> bindAttachedProperty containerType a overwriteData)
        
    /// Bind an existing event
    let bindEvent containerTypeName (assemblyTypeEvent: AssemblyTypeEvent) (bindingsTypeEvent: Event) =
        let name = Text.getValueOrDefault bindingsTypeEvent.Name assemblyTypeEvent.Name
        { Name = name
          ShortName = BinderHelpers.getShortName bindingsTypeEvent.ShortName name
          UniqueName = BinderHelpers.getUniqueName containerTypeName bindingsTypeEvent.UniqueName name
          InputType = Text.getValueOrDefault bindingsTypeEvent.InputType assemblyTypeEvent.Type
          ModelType = Text.getValueOrDefault bindingsTypeEvent.ModelType assemblyTypeEvent.EventHandlerType
          ConvertInputToModel = Text.getValueOrDefault bindingsTypeEvent.ConvertInputToModel ""
          RelatedProperties = match bindingsTypeEvent.RelatedProperties with None -> [||] | Some relatedProperties -> relatedProperties
          IsInherited = false }
    
    /// Bind an existing property
    let bindProperty containerTypeName (assemblyTypeProperty: AssemblyTypeProperty) (assemblyTypeAttachedProperties: AssemblyTypeAttachedProperty array) (bindingsTypeProperty: Property) =
        let name = Text.getValueOrDefault bindingsTypeProperty.Name assemblyTypeProperty.Name
        { Name = name
          ShortName = BinderHelpers.getShortName bindingsTypeProperty.ShortName name
          UniqueName = BinderHelpers.getUniqueName containerTypeName bindingsTypeProperty.UniqueName name
          DefaultValue = Text.getValueOrDefault bindingsTypeProperty.DefaultValue assemblyTypeProperty.DefaultValue
          OriginalType = assemblyTypeProperty.Type
          InputType = Text.getValueOrDefault bindingsTypeProperty.InputType assemblyTypeProperty.Type
          ModelType = Text.getValueOrDefault bindingsTypeProperty.ModelType assemblyTypeProperty.Type
          ConvertInputToModel = Text.getValueOrDefault bindingsTypeProperty.ConvertInputToModel ""
          ConvertModelToValue = Text.getValueOrDefault bindingsTypeProperty.ConvertModelToValue ""
          UpdateCode = Text.getValueOrDefault bindingsTypeProperty.UpdateCode ""
          CollectionData =
              bindingsTypeProperty.Collection
              |> Option.map (fun cd ->
                  { ElementType = Text.eitherOrDefault cd.ElementType assemblyTypeProperty.CollectionElementType ""
                    AttachedProperties =
                      BinderHelpers.bindMembers
                        cd.AttachedProperties
                        (tryBindAttachedProperty containerTypeName assemblyTypeAttachedProperties) })
          IsInherited = false }
       
    /// Try to create a bound event binding from the bindings data only 
    let tryCreateEvent containerTypeName (bindingsTypeEvent: Event) =
        maybe {
            use_logger containerTypeName "event" (Text.getValueOrDefault bindingsTypeEvent.Name "")
            
            let! name = "Name", bindingsTypeEvent.Name
            let! inputType = "InputType", bindingsTypeEvent.InputType
            let! modelType = "ModelType", bindingsTypeEvent.ModelType
            
            return
                { Name = name
                  ShortName = BinderHelpers.getShortName bindingsTypeEvent.ShortName name
                  UniqueName = BinderHelpers.getUniqueName containerTypeName bindingsTypeEvent.UniqueName name
                  InputType = inputType
                  ModelType = modelType
                  ConvertInputToModel = Text.getValueOrDefault bindingsTypeEvent.ConvertInputToModel ""
                  RelatedProperties = match bindingsTypeEvent.RelatedProperties with None -> [||] | Some relatedProperties -> relatedProperties
                  IsInherited = false }
        }
       
    /// Try to create a bound property from the bindings data only 
    let tryCreateProperty containerTypeName (assemblyTypeAttachedProperties: AssemblyTypeAttachedProperty array) (bindingsTypeProperty: Property) =
        maybe {
            use_logger containerTypeName "property" (Text.getValueOrDefault bindingsTypeProperty.Name "")
            
            let! name = "Name", bindingsTypeProperty.Name
            let! defaultValue = "DefaultValue", bindingsTypeProperty.DefaultValue
            let! inputType = "InputType", bindingsTypeProperty.InputType

            return
                { Name = name
                  ShortName = BinderHelpers.getShortName bindingsTypeProperty.ShortName name
                  UniqueName = BinderHelpers.getUniqueName containerTypeName bindingsTypeProperty.UniqueName name
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
        }
    
    /// Try to bind or create an event binding
    let tryBindEvent containerType (assemblyTypeEvents: AssemblyTypeEvent array) (bindingsTypeEvent: Event) =
        BinderHelpers.tryBindOrCreateMember
            assemblyTypeEvents
            bindingsTypeEvent.Source
            (fun e -> e.Name)
            (fun source -> sprintf "Event '%s' on type '%s' not found" source containerType)
            (fun () -> tryCreateEvent containerType bindingsTypeEvent)
            (fun e -> bindEvent containerType e bindingsTypeEvent)
    
    /// Try to bind or create a property binding
    let tryBindProperty containerType (assemblyTypeProperties: AssemblyTypeProperty array) (assemblyTypeAttachedProperties: AssemblyTypeAttachedProperty array) (bindingsTypeProperty: Property) =
        BinderHelpers.tryBindOrCreateMember
            assemblyTypeProperties
            bindingsTypeProperty.Source
            (fun p -> p.Name)
            (fun source -> sprintf "Property '%s' on type '%s' not found" source containerType)
            (fun () -> tryCreateProperty containerType assemblyTypeAttachedProperties bindingsTypeProperty)
            (fun p -> bindProperty containerType p assemblyTypeAttachedProperties bindingsTypeProperty)
    
    /// Bind an existing type
    let bindType (assemblyType: AssemblyType) (bindingsType: Type) =
        let typeName = BinderHelpers.getTypeName assemblyType.Name bindingsType.Name
        { Type = assemblyType.Name
          CanBeInstantiated = Value.getValueOrDefault bindingsType.CanBeInstantiated assemblyType.CanBeInstantiated
          TypeToInstantiate = Text.getValueOrDefault bindingsType.CustomType assemblyType.Name
          BaseTypeName = None
          Name = typeName
          Events =
              BinderHelpers.bindMembers
                bindingsType.Events
                (tryBindEvent typeName assemblyType.Events)
          Properties =
              BinderHelpers.bindMembers
                bindingsType.Properties
                (tryBindProperty typeName assemblyType.Properties assemblyType.AttachedProperties) }
    
    /// Try to bind a type
    let tryBindType (assemblyTypes: AssemblyType array) (bindingsType: Type) =
        BinderHelpers.tryBind
            assemblyTypes
            bindingsType.Type
            (fun t -> t.Name)
            (fun source -> sprintf "Type '%s' not found" source)
            (fun t -> bindType t bindingsType)
    
    /// Create a bound model using the types extracted from the assemblies and the bindings provided by the caller
    let bind (assemblyTypes: AssemblyType array) (bindings: Bindings) : WorkflowResult<BoundModel> =
        let types =
            bindings.Types
            |> Array.choose (tryBindType assemblyTypes)
        
        let data =
            { Assemblies = bindings.Assemblies
              OutputNamespace = bindings.OutputNamespace
              Types = types}
        
        Ok (data, [], [])