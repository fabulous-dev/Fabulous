// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.Generator

open Fabulous.Generator.Models
open Fabulous.Generator.Helpers
open Mono.Cecil
open System.Collections.Generic
open System.Linq

module Resolvers =
    let getHierarchy (typ: TypeDefinition) =
        seq {
            let mutable d = typ
            yield (d :> TypeReference, d)
            while (d.BaseType <> null) do
                let r = d.BaseType
                d <- r.Resolve()
                yield (r, d)
         }

    let tryResolveType (assemblyDefinitions: AssemblyDefinition list)  (name: string) =
        seq {
            for a in assemblyDefinitions do
                for m in a.Modules do
                    for tdef in m.Types do
                        if tdef.FullName = name then
                            yield tdef }
        |> Seq.tryHead

    let tryFindProperty typ name =
        let q =
            seq { 
                for (_, tdef) in getHierarchy(typ) do
                    for p in tdef.Properties do
                        if p.Name = name then
                            yield p }
        q |> Seq.tryHead

    let tryFindEvent typ name =
        let q =
            seq { 
                for (_, tdef) in getHierarchy(typ) do
                    for p in tdef.Events do
                        if p.Name = name then
                            yield p }
        q |> Seq.tryHead

    let resolveTypes (assemblyDefinitions: AssemblyDefinition list) (types: List<TypeBinding>) : Result<IDictionary<TypeBinding, TypeDefinition>, string list> =
        let results =
            [ for x in types do
                match tryResolveType assemblyDefinitions x.Name with 
                | None -> yield Error (sprintf "Could not find type '%s'"  x.Name)
                | Some d -> yield Ok (x, d) ]

        match results |> getResultErrors with
        | [] -> results |> getResultOks |> dict |> Ok
        | errors -> errors |> Error

    let resolveMembers (types: List<TypeBinding>) (resolutions: IDictionary<TypeBinding, TypeDefinition>) : IDictionary<MemberBinding, MemberReference> * string list =
        let results =
            [ for x in types do
                for m in x.Members do
                    match tryFindProperty resolutions.[x] m.Name with 
                    | Some p -> yield (Some (m, (p :> MemberReference)), None)
                    | None -> 
                        match tryFindEvent resolutions.[x] m.Name with 
                        | Some e -> yield (Some (m, (e :> MemberReference)), None)
                        | None -> 
                            match System.String.IsNullOrWhiteSpace(m.UpdateCode) with
                            | true -> yield (None, Some (sprintf "Could not find member '%s' on '%s'" m.Name x.Name))
                            | false -> () ]

        let memberResolutions = results |> List.map fst |> List.filter Option.isSome |> List.map Option.get |> dict
        let warnings = results |> List.map snd |> List.filter Option.isSome |> List.map Option.get
        (memberResolutions, warnings)

    let tryGetBoundType (memberResolutions: IDictionary<MemberBinding, MemberReference>) (memberBinding: MemberBinding) : TypeReference option =
       if memberResolutions.ContainsKey(memberBinding) then 
           match memberResolutions.[memberBinding] with 
           | :? PropertyDefinition as p -> Some p.PropertyType
           | :? EventDefinition as e ->  Some e.EventType
           | _ -> None
       else
           None

    let rec ResolveGenericParameter (tref: TypeReference, hierarchy: seq<TypeReference * TypeDefinition>) : TypeReference option =
        if (tref = null) then
            None
        elif not tref.IsGenericParameter then
            Some tref
        else
            seq { 
                for (b, tdef) in hierarchy do 
                   if b.IsGenericInstance then 
                     let ps = tdef.GenericParameters
                     match ps |> Seq.tryFind (fun x -> x.Name = tref.Name) with 
                     | Some p -> 
                         let pi = ps.IndexOf(p)
                         let args = (b :?> GenericInstanceType).GenericArguments
                         match ResolveGenericParameter (args.[pi], hierarchy) with
                         | Some res -> yield res
                         | None -> 
                              ()
                     | None -> 
                         ()
            } 
            |> Seq.tryHead

    type MemberBinding with
        member this.GetModelTypeInner(bindings:Bindings, tref:TypeReference, hierarchy: seq<TypeReference * TypeDefinition>) =
            match tref with 
            | _ when tref.IsGenericParameter ->
                if hierarchy <> null then 
                    match ResolveGenericParameter(tref, hierarchy) with 
                    | Some r -> this.GetModelTypeInner(bindings, r, hierarchy)
                    | None -> "ViewElement"
                else
                    "ViewElement"

            | _ when tref.IsGenericInstance ->
                let (ns,n) = 
                    let n = tref.Name.Substring(0, tref.Name.IndexOf('`'))
                    if (tref.IsNested) then
                        let n = tref.DeclaringType.Name + "." + n
                        let ns = tref.DeclaringType.Namespace
                        ns, n
                    else
                        let ns = tref.Namespace
                        ns, n
                let args = System.String.Join(", ", (tref :?> GenericInstanceType).GenericArguments.Select(fun s -> this.GetModelTypeInner(bindings, s, hierarchy)))
                sprintf "%s.%s<%s>" ns n args

            | _ -> 
                match tref.FullName with 
                | "System.String" -> "string"
                | "System.Boolean" -> "bool"
                | "System.Int32" -> "int"
                | "System.Double" -> "double"
                | "System.Single" -> "single"
                | _ -> 
                    match (bindings.Types |> Seq.tryFind (fun x -> x.Name = tref.FullName)) with
                    | None -> tref.FullName.Replace('/', '.')
                    | Some tb -> "ViewElement"

        member this.GetModelType(bindings: Bindings, memberResolutions, hierarchy: seq<TypeReference * TypeDefinition>) =
            match this.ModelType with 
            | NotNullOrWhitespace s -> s
            | _ -> 
                match tryGetBoundType memberResolutions this with 
                | None -> failwithf "no type for %s" this.Name
                | Some boundType -> this.GetModelTypeInner(bindings, boundType, hierarchy)

        member this.GetInputType(bindings: Bindings, memberResolutions, hierarchy: seq<TypeReference * TypeDefinition>) =
            match this.InputType with 
            | NotNullOrWhitespace s -> s
            | _ -> 
                this.GetModelType(bindings, memberResolutions, hierarchy)

        member this.GetElementTypeInner(tref: TypeReference, hierarchy: seq<TypeReference * TypeDefinition>) =
            match ResolveGenericParameter(tref, hierarchy) with 
            | None -> None
            | Some r -> 
                if (r.FullName = "System.String") then
                    None
                elif (r.Name = "IList`1" && r.IsGenericInstance) then
                    let args = (r :?> GenericInstanceType).GenericArguments
                    match ResolveGenericParameter(args.[0], hierarchy) with 
                    | None -> 
                        None
                    | Some elementType -> 
                        Some elementType
                else
                    let bs = r.Resolve().Interfaces
                    bs |> Seq.tryPick (fun b -> this.GetElementTypeInner(b.InterfaceType, hierarchy))

        member this.GetElementTypeFullName(memberResolutions, hierarchy: seq<TypeReference * TypeDefinition>) =
            match this.ElementType with 
            | NotNullOrWhitespace s -> Some s
            | _ -> 
                match tryGetBoundType memberResolutions this with 
                | None -> None
                | Some boundType -> 
                    match this.GetElementTypeInner(boundType, hierarchy) with 
                    | None -> None
                    | Some res -> Some res.FullName

