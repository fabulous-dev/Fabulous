// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen.Generator

open Fabulous.CodeGen.Binder.Models
open Fabulous.CodeGen.Generator.Models

module Preparator =
    
    let extractAttributes (types: TypeBinding[]) =
        [| for ``type`` in types do
               for a in ``type``.AttachedProperties do
                   yield a.UniqueName
               for e in ``type``.Events do
                   yield e.UniqueName
               for p in ``type``.Properties do
                   yield p.UniqueName |]
        |> Seq.distinctBy id
        |> Seq.toArray

    let toBuildData (``type``: TypeBinding) =
        let eventToPreparedMember (e: EventBinding) : BuildMember =
            { Name = e.ShortName
              UniqueName = e.UniqueName
              InputType = e.InputType
              ConvertInputToModel = e.ConvertInputToModel
              IsInherited = e.IsInherited }
            
        let propertyToPreparedMember (e: PropertyBinding) : BuildMember =
            { Name = e.ShortName
              UniqueName = e.UniqueName
              InputType = e.InputType
              ConvertInputToModel = e.ConvertInputToModel
              IsInherited = e.IsInherited }
        
        let properties = ``type``.Properties |> Array.map propertyToPreparedMember
        let events = ``type``.Events |> Array.map eventToPreparedMember
        let members = Array.concat [ properties; events ]
        
        { Name = ``type``.Name
          BaseName = ``type``.BaseTypeName
          Members = members }

    let toCreateData (``type``: TypeBinding) =
        { Name = ``type``.Name
          FullName = ``type``.Type
          HasCustomConstructor = false // TODO
          TypeToInstantiate = ``type``.TypeToInstantiate
          Parameters = [||] } // TODO

    let toUpdateData (``type``: TypeBinding) =
        let immediateEvents = ``type``.Events |> Array.filter (fun e -> not e.IsInherited)
        let immediateProperties = ``type``.Properties |> Array.filter (fun p -> not p.IsInherited)
        let immediateAttachedProperties = ``type``.AttachedProperties |> Array.filter (fun a -> not a.IsInherited)
        
        let eventMembers = immediateEvents |> Array.map (fun e -> { UniqueName = e.UniqueName; ModelType = e.ModelType })
        let propertyMembers = immediateProperties |> Array.map (fun p -> { UniqueName = p.UniqueName; ModelType = p.ModelType })
        let attachedPropertyMembers = immediateAttachedProperties |> Array.map (fun a -> { UniqueName = a.UniqueName; ModelType = a.ModelType })
        let immediateMembers = Array.concat [ eventMembers; propertyMembers; attachedPropertyMembers ]
        
        let updateEvents = immediateEvents |> Array.map (fun e -> { Name = e.Name; UniqueName = e.UniqueName; RelatedProperties = e.RelatedProperties })
        
        let updateProperties = immediateProperties |> Array.map (fun p ->
            { Name = p.Name
              UniqueName = p.UniqueName
              DefaultValue = p.DefaultValue
              OriginalType = p.OriginalType
              ModelType = p.ModelType
              ConvertModelToValue = p.ConvertModelToValue
              UpdateCode = ""
              ElementType = None }    
        )
        
        { Name = ``type``.Name
          FullName = ``type``.Type
          BaseName = ``type``.BaseTypeName
          ImmediateMembers = immediateMembers
          Events = updateEvents
          Properties = updateProperties
          AttachedProperties = [||] }

    let toConstructData (``type``: TypeBinding) : ConstructData =
        let properties = ``type``.Properties |> Array.map (fun p -> { Name = p.ShortName; InputType = p.InputType } : ConstructType)
        let events = ``type``.Events |> Array.map (fun e -> { Name = e.ShortName; InputType = e.InputType } : ConstructType)
        let members = Array.concat [ properties; events ]
        
        { Name = ``type``.Name
          FullName = ``type``.Type
          Members = members }
    
    let toBuilderData (``type``: TypeBinding) =
        { Build = toBuildData ``type``
          Create = toCreateData ``type``
          Update = toUpdateData ``type``
          Construct = toConstructData ``type`` }

    let toViewerData (``type``: TypeBinding) : ViewerData =
        let properties = ``type``.Properties |> Array.filter (fun p -> not p.IsInherited) |> Array.map (fun p -> { Name = p.Name; UniqueName = p.UniqueName })
        let events = ``type``.Events |> Array.filter (fun e -> not e.IsInherited) |> Array.map (fun e -> { Name = e.Name; UniqueName = e.UniqueName })
        let attachedProperties = ``type``.AttachedProperties |> Array.filter (fun a -> not a.IsInherited) |> Array.map (fun a -> { Name = a.Name; UniqueName = a.UniqueName })
        let members = Array.concat [ properties; events; attachedProperties ]
            
        { Name = ``type``.Name
          FullName = ``type``.Type
          BaseName = ``type``.BaseTypeName
          Members = members }

    let toConstructorData (``type``: TypeBinding) =
        let properties = ``type``.Properties |> Array.map (fun p -> { Name = p.ShortName; InputType = p.InputType })
        let events = ``type``.Events |> Array.map (fun e -> { Name = e.ShortName; InputType = e.InputType })
        let members = Array.concat [ properties; events ]
        
        { Name = ``type``.Name
          FullName = ``type``.Type
          Members = members }

    let getViewExtensionsData (types: TypeBinding []) =
        let propertyToViewExtensionsMember (p: PropertyBinding) =
            { LowerShortName = p.ShortName
              LowerUniqueName = p.UniqueName
              UniqueName = p.UniqueName
              InputType = p.InputType
              ConvToModel = p.ConvertInputToModel }
        let eventToViewExtensionsMember (e: EventBinding) =
            { LowerShortName = e.ShortName
              LowerUniqueName = e.UniqueName
              UniqueName = e.UniqueName
              InputType = e.InputType
              ConvToModel = e.ConvertInputToModel }
        let attachedPropertiesToViewExtensionsMember (a: AttachedPropertyBinding) =
            { LowerShortName = a.Name
              LowerUniqueName = a.UniqueName
              UniqueName = a.UniqueName
              InputType = a.InputType
              ConvToModel = a.ConvertInputToModel }
        [| for typ in types do
            for p in typ.Properties do yield propertyToViewExtensionsMember p
            for e in typ.Events do yield eventToViewExtensionsMember e
            for a in typ.AttachedProperties do yield attachedPropertiesToViewExtensionsMember a |]
        |> Array.groupBy (fun y -> y.UniqueName)
        |> Array.map (fun (_, members) -> members |> Array.head)
    
    let prepareData (bindings: Bindings) =
        { Namespace = bindings.OutputNamespace
          Attributes = extractAttributes bindings.Types
          Builders = bindings.Types |> Array.map toBuilderData
          Viewers = bindings.Types |> Array.map toViewerData
          Constructors = bindings.Types |> Array.map toConstructorData
          ViewExtensions = bindings.Types |> getViewExtensionsData }

