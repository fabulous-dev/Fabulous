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
(*

    let toBuildData (``type``: TypeBinding) =
        let eventToPreparedMember (e: EventBinding) =
            { Name = e.ShortName
              UniqueName = e.UniqueName
              InputType = sprintf "%s -> unit" e.EventArgsType
              ConvertInputToModel =
                  match e.Type with
                  | "System.EventHandler" -> sprintf "(fun f -> %s(fun _sender _ -> f ()))" e.Type
                  | _ -> sprintf "(fun f -> %s(fun _sender _args -> f args))" e.Type
              IsInherited = not m.IsImmediateMember }
        
        
        let events = ``type``.Events |> Array.map (fun e -> (e.Order, e.ShortName, sprintf "%s -> unit" e.EventArgsType))
        let properties = ``type``.Properties |> Array.map (fun p -> (p.Order, p.ShortName, p.InputType))
        let members = Array.concat [ events; properties ] |> Array.sortBy (fun (order, _, _) -> match order with Some i -> i | None -> System.Int32.MaxValue) |> Array.map ()
        
        let toBuildMember (m : PreparedMember) =
            { Name = m.LowerShortName
              UniqueName = m.UniqueName
              InputType = m.InputType
              ConvToModel = m.ConvToModel
              IsInherited = not m.IsImmediateMember }
        { Name = typ.Name
          BaseName = typ.BaseName
          Members = typ.Members |> Array.map toBuildMember }
    
    let toBuilderData (``type``: TypeBinding) =
        { Build = typ |> toBuildData }*)
    
    let prepareData (bindings: Bindings) =
        { Namespace = bindings.OutputNamespace
          Attributes = extractAttributes bindings.Types
          Proto = bindings.Types |> Array.map toProtoData }

