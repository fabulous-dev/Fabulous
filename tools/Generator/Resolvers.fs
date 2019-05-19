// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.Generator

open Fabulous.Generator.Models
open Fabulous.Generator.Helpers
open Mono.Cecil
open System.Collections.Generic
open System.Linq

module Resolvers =
    let getHierarchy (typ : TypeDefinition) =
        seq {
            let mutable d = typ
            yield (d :> TypeReference, d)
            while (d.BaseType <> null) do
                let r = d.BaseType
                d <- r.Resolve()
                yield (r, d)
        }

    let tryResolveType (assemblyDefinitions : AssemblyDefinition list) (name : string) =
        seq {
            for a in assemblyDefinitions do
                for m in a.Modules do
                    for tdef in m.Types do
                        if tdef.FullName = name then yield tdef
        }
        |> Seq.tryHead

    let tryFindProperty typ name =
        let q =
            seq {
                for (_, tdef) in getHierarchy (typ) do
                    for p in tdef.Properties do
                        if p.Name = name then yield p
            }
        q |> Seq.tryHead

    let tryFindEvent typ name =
        let q =
            seq {
                for (_, tdef) in getHierarchy (typ) do
                    for p in tdef.Events do
                        if p.Name = name then yield p
            }
        q |> Seq.tryHead

    let resolveTypes (assemblyDefinitions : AssemblyDefinition list) (types : List<TypeBinding>) : Result<IDictionary<TypeBinding, TypeDefinition>, string list> =
        let results =
            [ for x in types do
                  match tryResolveType assemblyDefinitions x.Name with
                  | None ->
                      yield Error(sprintf "Could not find type '%s'" x.Name)
                  | Some d -> yield Ok(x, d) ]
        match results |> getResultErrors with
        | [] ->
            results
            |> getResultOks
            |> dict
            |> Ok
        | errors -> errors |> Error

    let resolveEvents (types : List<TypeBinding>) (resolutions : IDictionary<TypeBinding, TypeDefinition>) =
        let results =
            [ for x in types do
                  for m in x.Events do
                      match tryFindEvent resolutions.[x] m.Name with
                      | Some e ->
                          yield (Some(m, e), None)
                      | None ->
                          yield (None, Some
                                         (sprintf
                                              "Could not find event '%s' on '%s'"
                                              m.Name x.Name)) ]

        let resolutions =
            results
            |> List.map fst
            |> List.filter Option.isSome
            |> List.map Option.get
            |> dict

        let warnings =
            results
            |> List.map snd
            |> List.filter Option.isSome
            |> List.map Option.get

        (resolutions, warnings)
        
    let resolveProperties (types : List<TypeBinding>) (resolutions : IDictionary<TypeBinding, TypeDefinition>) =
        let results =
            [ for x in types do
                  for m in x.Properties do
                      match tryFindProperty resolutions.[x] m.Name with
                      | Some p -> yield (Some(m, p), None)
                      | None ->
                          match System.String.IsNullOrWhiteSpace (m.UpdateCode) with
                          | true ->
                              yield (None, Some
                                             (sprintf
                                                  "Could not find property '%s' on '%s'"
                                                  m.Name x.Name))
                          | false -> () ]                         

        let resolutions =
            results
            |> List.map fst
            |> List.filter Option.isSome
            |> List.map Option.get
            |> dict

        let warnings =
            results
            |> List.map snd
            |> List.filter Option.isSome
            |> List.map Option.get

        (resolutions, warnings)

    let resolveMembers (types : List<TypeBinding>) (resolutions : IDictionary<TypeBinding, TypeDefinition>) : IDictionary<EventBinding, EventDefinition> * IDictionary<PropertyBinding, PropertyDefinition> * string list =
        let eventsResolutions, eventsWarnings = resolveEvents types resolutions
        let propertiesResolutions, propertiesWarnings = resolveProperties types resolutions
        let warnings = List.append eventsWarnings propertiesWarnings

        (eventsResolutions, propertiesResolutions, warnings)

    let tryGetEventBoundType (resolutions : IDictionary<EventBinding, EventDefinition>) binding =
        match resolutions.ContainsKey(binding) with
        | true -> Some resolutions.[binding].EventType
        | false -> None

    let tryGetPropertyBoundType (resolutions : IDictionary<PropertyBinding, PropertyDefinition>) binding =
        match resolutions.ContainsKey(binding) with
        | true -> Some resolutions.[binding].PropertyType
        | false -> None

    let rec resolveGenericParameter(tref : TypeReference,
                                    hierarchy : seq<TypeReference * TypeDefinition>) : TypeReference option =
        if (tref = null) then None
        elif not tref.IsGenericParameter then Some tref
        else
            seq {
                for (b, tdef) in hierarchy do
                    if b.IsGenericInstance then
                        let ps = tdef.GenericParameters
                        match ps |> Seq.tryFind (fun x -> x.Name = tref.Name) with
                        | Some p ->
                            let pi = ps.IndexOf(p)
                            let args =
                                (b :?> GenericInstanceType).GenericArguments
                            match resolveGenericParameter(args.[pi], hierarchy) with
                            | Some res -> yield res
                            | None -> ()
                        | None -> ()
            }
            |> Seq.tryHead


    let rec getModelTypeInner (bindings : Bindings,
                               tref : TypeReference,
                               hierarchy : seq<TypeReference * TypeDefinition>) =
        match tref with
        | _ when tref.IsGenericParameter ->
            if hierarchy <> null then
                match resolveGenericParameter(tref, hierarchy) with
                | Some r -> getModelTypeInner (bindings, r, hierarchy)
                | None -> "ViewElement"
            else "ViewElement"
        | _ when tref.IsGenericInstance ->
            let (ns, n) =
                let n = tref.Name.Substring(0, tref.Name.IndexOf('`'))
                if (tref.IsNested) then
                    let n = tref.DeclaringType.Name + "." + n
                    let ns = tref.DeclaringType.Namespace
                    ns, n
                else
                    let ns = tref.Namespace
                    ns, n

            let args =
                System.String.Join (", ",
                     (tref :?> GenericInstanceType)
                         .GenericArguments.Select(fun s ->
                         getModelTypeInner (bindings, s, hierarchy)))
            sprintf "%s.%s<%s>" ns n args
        | _ ->
            match tref.FullName with
            | "System.String" -> "string"
            | "System.Boolean" -> "bool"
            | "System.Int32" -> "int"
            | "System.Double" -> "double"
            | "System.Single" -> "single"
            | _ ->
                match (bindings.Types
                       |> Seq.tryFind (fun x -> x.Name = tref.FullName)) with
                | None -> tref.FullName.Replace('/', '.')
                | Some tb -> "ViewElement"

    let getModelType boundName boundModelType tryGetBoundTypeFunc (bindings : Bindings, hierarchy : seq<TypeReference * TypeDefinition>) =
        match boundModelType with
        | NotNullOrWhitespace s -> s
        | _ ->
            match tryGetBoundTypeFunc() with
            | None -> failwithf "no type for %s" boundName
            | Some boundType ->
                getModelTypeInner (bindings, boundType, hierarchy)

    let getEventModelType (this : EventBinding, bindings : Bindings, resolutions, hierarchy : seq<TypeReference * TypeDefinition>) =
        getModelType this.Name "" (fun () -> tryGetEventBoundType resolutions this) (bindings, hierarchy)

    let getPropertyModelType (this : PropertyBinding, bindings : Bindings, resolutions, hierarchy : seq<TypeReference * TypeDefinition>) =
        getModelType this.Name this.ModelType (fun () -> tryGetPropertyBoundType resolutions this) (bindings, hierarchy)

    let getInputType (this : PropertyBinding, bindings : Bindings, memberResolutions, hierarchy : seq<TypeReference * TypeDefinition>) =
        match this.InputType with
        | NotNullOrWhitespace s -> s
        | _ -> getPropertyModelType (this, bindings, memberResolutions, hierarchy)

    let rec getElementTypeInner (this : PropertyBinding, tref : TypeReference, hierarchy : seq<TypeReference * TypeDefinition>) =
        match resolveGenericParameter(tref, hierarchy) with
        | None -> None
        | Some r ->
            if (r.FullName = "System.String") then None
            elif (r.Name = "IList`1" && r.IsGenericInstance) then
                let args = (r :?> GenericInstanceType).GenericArguments
                match resolveGenericParameter(args.[0], hierarchy) with
                | None -> None
                | Some elementType -> Some elementType
            else
                let bs = r.Resolve().Interfaces
                bs
                |> Seq.tryPick
                       (fun b ->
                       getElementTypeInner (this, b.InterfaceType, hierarchy))

    let getElementTypeFullName (this : PropertyBinding, memberResolutions, hierarchy : seq<TypeReference * TypeDefinition>) =
        match this.ElementType with
        | NotNullOrWhitespace s -> Some s
        | _ ->
            match tryGetPropertyBoundType memberResolutions this with
            | None -> None
            | Some boundType ->
                match getElementTypeInner (this, boundType, hierarchy) with
                | None -> None
                | Some res -> Some res.FullName
