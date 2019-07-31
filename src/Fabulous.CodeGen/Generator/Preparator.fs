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

    let toProtoData (``type``: TypeBinding) = ``type``.Name

    let toBuildData (``type``: TypeBinding) =
        let eventToPreparedMember (e: EventBinding) : BuildMember =
            { Position = e.Position
              Name = e.ShortName
              UniqueName = e.UniqueName
              InputType = e.InputType
              ConvertInputToModel = e.ConvertInputToModel
              IsInherited = e.IsInherited }
            
        let propertyToPreparedMember (e: PropertyBinding) : BuildMember =
            { Position = e.Position
              Name = e.ShortName
              UniqueName = e.UniqueName
              InputType = e.InputType
              ConvertInputToModel = e.ConvertInputToModel
              IsInherited = e.IsInherited }
        
        let events = ``type``.Events |> Array.map eventToPreparedMember
        let properties = ``type``.Properties |> Array.map propertyToPreparedMember
        let members = Array.concat [ events; properties ] |> Array.sortBy (fun m -> m.Position)
        
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
        
        let updateEvents = immediateEvents |> Array.map (fun e -> { Name = e.Name; UniqueName = e.UniqueName; RelatedProperties = [||] })
        
//        let rec toUpdateMember (m : PreparedMember) =
//            { Name = m.Name
//              UniqueName = m.UniqueName
//              ModelType = m.ModelType
//              DefaultValue = m.DefaultValue
//              ConvToValue = m.ConvToValue
//              UpdateCode = m.UpdateCode
//              ElementTypeFullName = m.ElementTypeFullName
//              IsParameter = m.IsParameter
//              BoundType = m.BoundType
//              Attached = m.AttachedMembers |> Array.map toUpdateMember }
        { Name = ``type``.Name
          FullName = ``type``.Type
          BaseName = ``type``.BaseTypeName
          ImmediateMembers = immediateMembers
          Events = updateEvents
          Properties = [||]
          AttachedProperties = [||] }
    
    let toBuilderData (``type``: TypeBinding) =
        { Build = toBuildData ``type``
          Create = toCreateData ``type``
          Update = toUpdateData ``type`` }
    
    let prepareData (bindings: Bindings) =
        { Namespace = bindings.OutputNamespace
          Attributes = extractAttributes bindings.Types
          Proto = bindings.Types |> Array.map toProtoData
          Builders = bindings.Types |> Array.map toBuilderData  }

