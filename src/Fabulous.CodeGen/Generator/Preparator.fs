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
              InputType = sprintf "%s -> unit" e.EventArgsType
              ConvertInputToModel =
                  match e.Type with
                  | "obj" -> ""
                  | "System.EventHandler" -> sprintf "(fun f -> %s(fun _sender _ -> f ()))" e.Type
                  | _ -> sprintf "(fun f -> %s(fun _sender _args -> f args))" e.Type
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
    
    let toBuilderData (``type``: TypeBinding) =
        { Build = toBuildData ``type`` }
    
    let prepareData (bindings: Bindings) =
        { Namespace = bindings.OutputNamespace
          Attributes = extractAttributes bindings.Types
          Proto = bindings.Types |> Array.map toProtoData
          Builders = bindings.Types |> Array.map toBuilderData  }

