﻿// Copyright 2018 Fabulous contributors. See LICENSE.md for license.

// Windows: dotnet build -c Release tools\Generator\Generator.fsproj && dotnet tools\Generator\bin\Release\netcoreapp2.0\Generator.dll tools\Generator\Xamarin.Forms.Core.json src\Fabulous.Core\Xamarin.Forms.Core.fs

// OSX: dotnet build -c Release tools/Generator/Generator.fsproj && dotnet tools/Generator/bin/Release/netcoreapp2.0/Generator.dll tools/Generator/Xamarin.Forms.Core.json src/Fabulous.Core/Xamarin.Forms.Core.fs

module Generator

open System
open System.Collections.Generic
open System.IO
open System.Linq
open Mono.Cecil
open Newtonsoft.Json

type MemberBinding() =
    /// The name of the property in the target
    member val Name : string = null with get, set
        
    /// A unique name of the property in the model
    member val UniqueName : string = null with get, set

    /// Indicates if the "property" is actually passed as a fixed parameter to the constructor
    member val IsParam : bool = false with get, set

    /// The lowercase name used as a parameter in the API
    member val ShortName : string = null with get, set
        
    /// The input type type of the property as seen in the API
    member val InputType : string = null with get, set 

    /// The default value when applying to the target
    member val DefaultValue : string = null with get, set

    /// Converts the input type to the model type
    member val ConvToModel : string = null with get, set

    /// The expression to convert the model type to the value to be assigned to the property in the target
    member val ConvToValue : string = null with get, set

    /// The full code for incrementally assigning to the property in the target
    member val UpdateCode : string = null with get, set

    /// The type as stored in the model
    member val ModelType : string = null with get, set 

    /// The element type of the collection property
    member val ElementType : string = null with get, set

    /// The attached properties for items in the collection property
    member val Attached : List<MemberBinding> = null with get, set

    member this.BoundType(memberResolutions: IDictionary<MemberBinding, MemberReference>) : TypeReference option = 
        if memberResolutions.ContainsKey(this) then 
            match memberResolutions.[this] with 
            | :? PropertyDefinition as p -> Some p.PropertyType
            | :? EventDefinition as e ->  Some e.EventType
            | _ -> None
        else
            None

    member this.BoundUniqueName : string = if String.IsNullOrEmpty(this.UniqueName) then this.Name else this.UniqueName

    member this.LowerBoundUniqueName : string = string (Char.ToLowerInvariant (this.BoundUniqueName.[0])) + this.BoundUniqueName.Substring (1)

    member this.BoundShortName : string = if String.IsNullOrEmpty(this.ShortName) then this.Name else this.ShortName

    member this.LowerBoundShortName : string = string (Char.ToLowerInvariant(this.BoundShortName.[0])) + this.BoundShortName.Substring(1)


type TypeBinding() = 

    member val Name : string = null with get, set

    member val ModelName : string = null with get, set

    member val CustomType : string = null with get, set

    member val Members: List<MemberBinding> = null with get, set

    member __.BoundName = "ViewElement" // Definition.Name + "Description"


type Bindings() = 

    member val Assemblies : List<string> = null with get, set 

    member val Types : List<TypeBinding> = null with get, set 

    member val OutputNamespace : string = null with get, set 

    member val AssemblyDefinitions : List<AssemblyDefinition> = null with get, set 

    member this.FindType (name: string) = this.Types |> Seq.tryFind (fun x -> x.Name = name)

type TextWriter with 
    member this.printf fmt = fprintf this fmt
    member this.printfn fmt = fprintfn this fmt

let (|NotNullOrWhitespace|_|) (s:string) = if String.IsNullOrWhiteSpace s then None else Some s

let ResolveType(this: Bindings, name: string) =
    seq { for a in this.AssemblyDefinitions do
            for m in a.Modules do
                for tdef in m.Types do
                if tdef.FullName = name then
                    yield tdef }
    |> Seq.tryHead

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
            let args = String.Join(", ", (tref :?> GenericInstanceType).GenericArguments.Select(fun s -> this.GetModelTypeInner(bindings, s, hierarchy)))
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
                | Some tb -> tb.BoundName

    member this.GetModelType(bindings: Bindings, memberResolutions, hierarchy: seq<TypeReference * TypeDefinition>) =
        match this.ModelType with 
        | NotNullOrWhitespace s -> s
        | _ -> 
            match this.BoundType(memberResolutions) with 
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
            match this.BoundType(memberResolutions) with 
            | None -> None
            | Some boundType -> 
                match this.GetElementTypeInner(boundType, hierarchy) with 
                | None -> None
                | Some res -> Some res.FullName


let GetHierarchy (typ: TypeDefinition ) : seq<TypeReference * TypeDefinition> =
    seq {
        let mutable d = typ
        yield (d :> TypeReference, d)
        while (d.BaseType <> null) do
            let r = d.BaseType
            d <- r.Resolve()
            yield (r, d)
     }

let FindProperty(name: string, typ: TypeDefinition) : PropertyDefinition option =
    let q =
        seq { 
            for (_,tdef) in GetHierarchy(typ) do
              for p in tdef.Properties do
                 if p.Name = name then
                     yield p }
    q |> Seq.tryHead

let FindEvent(name: string , typ: TypeDefinition) : EventDefinition option =
    let q =
        seq { 
            for (_,tdef) in GetHierarchy(typ) do
              for p in tdef.Events do
                 if p.Name = name then
                     yield p }
    q |> Seq.tryHead

let iterSep sep f xs = 
    let mutable head = ""
    for x in xs do
        f head x
        head <- sep

let BindTypes (bindings: Bindings, resolutions: IDictionary<TypeBinding, TypeDefinition>, memberResolutions) =
    let w = new StringWriter()

    let allMembersInAllTypes = new List<MemberBinding>()
    for typ in bindings.Types do
        if (typ.Members <> null) then
            for y in typ.Members do
                allMembersInAllTypes.Add(y)
                if (y.Attached <> null) then
                    for ap in y.Attached do
                        allMembersInAllTypes.Add(ap)

    let allMembersInAllTypesGroupedByName = allMembersInAllTypes.GroupBy(fun y -> y.BoundUniqueName)

    //for ms in allMembersInAllTypesGroupedByName do
    //    let m = ms.First()
    //    if not m.IsParam then
    //        w.printfn ""
    //        w.printfn "        /// Try to get the %s property in the visual element" m.BoundUniqueName
    //        w.printfn "%s" ("        member internal x.Try" + m.BoundUniqueName + " = x.TryGetAttributeKeyed<" + modelType + ">(\"" + m.BoundUniqueName + "\")")
    let tryGetCode (m: MemberBinding) = 
        let modelType = m.GetModelType(bindings, memberResolutions, null)
        sprintf "TryGetAttributeKeyed<%s>(View._%sAttribKey)" modelType m.BoundUniqueName

    w.printfn "namespace %s " bindings.OutputNamespace
    w.printfn ""
    w.printfn "#nowarn \"59\" // cast always holds"
    w.printfn "#nowarn \"66\" // cast always holds"
    w.printfn "#nowarn \"67\" // cast always holds"

    let allImmediateMembersCombined = 
       [| for typ in bindings.Types do
            for m in typ.Members.ToList() do
                yield m
                if (m.Attached <> null) then
                    for ap in m.Attached do
                        yield ap
       |]
       |> Seq.distinctBy (fun m -> m.BoundUniqueName)

    w.printfn ""
    w.printfn "type View() ="

    w.printfn ""
    for m in allImmediateMembersCombined do
        w.printfn "    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]"
        w.printfn "    static member val _%sAttribKey : AttributeKey<_> = AttributeKey<_>(\"%s\")" m.BoundUniqueName m.BoundUniqueName

    for typ in bindings.Types do
        let tdef = resolutions.[typ]
        let nameOfCreator = if String.IsNullOrWhiteSpace(typ.ModelName) then tdef.Name else typ.ModelName
        let hierarchy = GetHierarchy(tdef).ToList()
        let boundHierarchy = hierarchy |> Seq.choose (fun (_,x) -> bindings.Types |> Seq.tryFind (fun y -> y.Name = x.FullName)) |> Seq.toArray
        let baseTypeOpt = if boundHierarchy.Length > 1 then Some boundHierarchy.[1] else None
        let nameOfBaseCreatorOpt = baseTypeOpt |> Option.map (fun baseType -> if String.IsNullOrWhiteSpace(baseType.ModelName) then resolutions.[baseType].Name else baseType.ModelName)
        // All properties and events apart from the attached ones
        let allBaseMembers = boundHierarchy |> Seq.skip(1) |> Seq.collect (fun x -> x.Members) |> Seq.toArray
        let allImmediateMembers = typ.Members.ToArray()
        let allMembers = Array.append allImmediateMembers allBaseMembers

        // Emit the constructor
        w.printfn ""
        w.printfn "    /// Builds the attributes for a %s in the view" nameOfCreator
        w.printfn "    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]"
        w.printf    "    static member inline Build%s(attribCount: int" nameOfCreator
        let space = "                              " + String.replicate nameOfCreator.Length " " + " "
        for m in allMembers do
            let inputType = m.GetInputType(bindings, memberResolutions, null)

            w.printfn "," 
            w.printf "%s" space
            w.printf "?%s: %s" m.LowerBoundShortName inputType

        w.printfn ") = "
        w.printfn ""

        for m in allImmediateMembers do
            w.printfn "        let attribCount = match %s with Some _ -> attribCount + 1 | None -> attribCount" m.LowerBoundShortName

        match nameOfBaseCreatorOpt with 
        | None ->
            w.printfn "        let attribBuilder = new AttributesBuilder(attribCount)"
        | Some nameOfBaseCreator ->
            w.printfn ""
            w.printf "        let attribBuilder = View.Build%s(attribCount" nameOfBaseCreator
            for m in allBaseMembers do
                w.printf ", ?%s=%s" m.LowerBoundShortName m.LowerBoundShortName
            w.printfn ")"

        for m in allImmediateMembers do
            let conv = if String.IsNullOrWhiteSpace(m.ConvToModel) then "" else m.ConvToModel
            w.printfn "        match %s with None -> () | Some v -> attribBuilder.Add(View._%sAttribKey, %s(v)) " m.LowerBoundShortName m.BoundUniqueName conv 

        w.printfn "        attribBuilder"

        let customTypeToCreate = if String.IsNullOrWhiteSpace(typ.CustomType) then tdef.FullName else typ.CustomType
        let ctor = 
            tdef.Methods
             .Where(fun x -> x.IsConstructor && x.IsPublic)
             .OrderBy(fun x -> x.Parameters.Count)
             .FirstOrDefault()

        let hasCreate = (tdef.IsAbstract || ctor = null || ctor.Parameters.Count > 0)

        w.printfn ""
        w.printfn "    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]"
        w.printfn "    static member val CreateFunc%s : (unit -> %s) = (fun () -> View.Create%s())" nameOfCreator tdef.FullName nameOfCreator
        w.printfn ""
        w.printfn "    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]"
        w.printfn "    static member Create%s () : %s = " nameOfCreator tdef.FullName
        if not hasCreate then
            if (allMembers.Any(fun m -> m.IsParam)) then
                w.printfn "        match "
                allImmediateMembers |> iterSep ", " (fun head m -> 
                    if m.IsParam then
                        w.printf "%s%s" head m.LowerBoundShortName)
                w.printfn " with"
                w.printfn "        | "
                allImmediateMembers |> iterSep ", " (fun head m -> 
                    if m.IsParam then
                        w.printf "%sSome %s" head m.LowerBoundShortName)
                w.printfn " ->"
                w.printfn "            upcast (new %s(" customTypeToCreate
                allImmediateMembers |> iterSep ", " (fun head m -> 
                    if m.IsParam then
                        //if (bt <> null) then
                        //    w.printf "%s%s.CreateAs%s()" head m.LowerBoundShortName bt
                        //else
                        w.printf "%s%s" head m.LowerBoundShortName)
                w.printfn "))"
                w.printfn "            | _ -> upcast (new %s())" customTypeToCreate
            else
                w.printfn "            upcast (new %s())" customTypeToCreate
        else
            w.printfn "        failwith \"can't create %s\"" tdef.FullName

        w.printfn ""
        w.printfn "    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]"
        w.printfn "    static member val UpdateFunc%s = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: %s) -> View.Update%s (prevOpt, curr, target)) " nameOfCreator tdef.FullName nameOfCreator
        w.printfn ""
        w.printfn "    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]"
        w.printfn "    static member Update%s (prevOpt: ViewElement voption, curr: ViewElement, target: %s) = " nameOfCreator tdef.FullName

        match nameOfBaseCreatorOpt with 
        | None -> ()
        | Some nameOfBaseCreator ->
            w.printfn "        // update the inherited %s element" nameOfBaseCreator
            w.printfn "        let baseElement = (if View.Proto%s.IsNone then View.Proto%s <- Some (View.%s())); View.Proto%s.Value" nameOfBaseCreator nameOfBaseCreator nameOfBaseCreator nameOfBaseCreator
            w.printfn "        baseElement.UpdateInherited (prevOpt, curr, target)"

        if (allImmediateMembers.Length = 0) then
            w.printfn "        ignore prevOpt"
            w.printfn "        ignore curr"
            w.printfn "        ignore target"
        else

            for m in allImmediateMembers do
                w.printfn "        let mutable prev%sOpt = ValueNone" m.BoundUniqueName
                w.printfn "        let mutable curr%sOpt = ValueNone" m.BoundUniqueName
            w.printfn "        for kvp in curr.AttributesKeyed do"
            for m in allImmediateMembers do
                let modelType = m.GetModelType(bindings, memberResolutions, null)
                w.printfn "            if kvp.Key = View._%sAttribKey.KeyValue then " m.BoundUniqueName
                w.printfn "                curr%sOpt <- ValueSome (kvp.Value :?> %s)" m.BoundUniqueName modelType
            w.printfn "        match prevOpt with"
            w.printfn "        | ValueNone -> ()"
            w.printfn "        | ValueSome prev ->"
            w.printfn "            for kvp in prev.AttributesKeyed do"
            for m in allImmediateMembers do
                let modelType = m.GetModelType(bindings, memberResolutions, null)
                w.printfn "                if kvp.Key = View._%sAttribKey.KeyValue then " m.BoundUniqueName
                w.printfn "                    prev%sOpt <- ValueSome (kvp.Value :?> %s)" m.BoundUniqueName modelType

            for m in allImmediateMembers do
                let hasApply = not (String.IsNullOrWhiteSpace(m.ConvToValue)) || not (String.IsNullOrWhiteSpace(m.UpdateCode))


                // Check if "member" is actually a parameter to the constructor
                if not m.IsParam then

                    //w.printfn "        let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.%s" (tryGetCode m)
                    //w.printfn "        let currValueOpt = curr.%s" (tryGetCode m)

                    // Check if the member is a collection
                    let elementTypeOpt = m.GetElementTypeFullName(memberResolutions, hierarchy)

                    match elementTypeOpt with 
                    | Some elementType when not hasApply ->
                        w.printfn "        updateCollectionGeneric prev%sOpt curr%sOpt target.%s" m.BoundUniqueName m.BoundUniqueName m.Name
                        w.printfn "            (fun (x:ViewElement) -> x.Create() :?> %s)" elementType
                        if (m.Attached <> null) then
                            w.printfn "            (fun prevChildOpt newChild targetChild -> "
                            for ap in m.Attached do
                                w.printfn "                // Adjust the attached properties"
                                w.printfn "                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.%s" (tryGetCode ap)
                                w.printfn "                let childValueOpt = newChild.%s" (tryGetCode ap)
                                w.printfn "                match prevChildValueOpt, childValueOpt with"
                                w.printfn "                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()"
                                let apApply = if String.IsNullOrWhiteSpace(ap.ConvToValue) then "" else ap.ConvToValue + " "
                                w.printfn "                | _, ValueSome currChildValue -> %s.Set%s(targetChild, %scurrChildValue)" tdef.FullName ap.Name apApply
                                // TODO: ap.DefaultValue not always perfect, should set back to original default?
                                w.printfn "                | ValueSome _, ValueNone -> %s.Set%s(targetChild, %s)" tdef.FullName ap.Name ap.DefaultValue
                                w.printfn "                | _ -> ()"
                            w.printfn "                ())"
                        else
                            w.printfn "            (fun _ _ _ -> ())"
                        w.printfn "            canReuseChild"
                        w.printfn "            updateChild"

                    | _ -> 
                        let boundType = 
                            match m.BoundType(memberResolutions) with 
                            | None -> None
                            | Some boundType -> ResolveGenericParameter(boundType, hierarchy)
                   
                        match boundType with 

                        // Check if the type of the member is in the model, if so issue recursive calls to "Create" and "UpdateIncremental"
                        | Some bt when bindings.FindType(bt.FullName).IsSome && not hasApply ->

                            w.printfn "        match prev%sOpt, curr%sOpt with" m.BoundUniqueName m.BoundUniqueName
                            w.printfn "        // For structured objects, dependsOn on reference equality"
                            w.printfn "        | ValueSome prevValue, ValueSome newValue when identical prevValue newValue -> ()"
                            w.printfn "        | ValueSome prevValue, ValueSome newValue when canReuseChild prevValue newValue ->"
                            w.printfn "            newValue.UpdateIncremental(prevValue, target.%s)" m.Name
                            w.printfn "        | _, ValueSome newValue ->"
                            w.printfn "            target.%s <- (newValue.Create() :?> %s)" m.Name bt.FullName
                            w.printfn "        | ValueSome _, ValueNone ->"
                            w.printfn "            target.%s <- null"  m.Name
                            w.printfn "        | ValueNone, ValueNone -> ()"

                        // Default for delegate-typed things
                        | Some bt when (bt.Name.EndsWith("Handler") || bt.Name.EndsWith("Handler`1") || bt.Name.EndsWith("Handler`2")) && not hasApply ->
                            w.printfn "        match prev%sOpt, curr%sOpt with" m.BoundUniqueName m.BoundUniqueName
                            w.printfn "        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()"
                            w.printfn "        | ValueSome prevValue, ValueSome currValue -> target.%s.RemoveHandler(prevValue); target.%s.AddHandler(currValue)" m.Name m.Name
                            w.printfn "        | ValueNone, ValueSome currValue -> target.%s.AddHandler(currValue)" m.Name
                            w.printfn "        | ValueSome prevValue, ValueNone -> target.%s.RemoveHandler(prevValue)" m.Name
                            w.printfn "        | ValueNone, ValueNone -> ()"

                        // Explicit update code
                        | _ when not (String.IsNullOrWhiteSpace(m.UpdateCode))  -> 
                            w.printfn "        %s prev%sOpt curr%sOpt target" m.UpdateCode m.BoundUniqueName m.BoundUniqueName
                            if (m.Attached <> null) then
                                w.printfn "            (fun prevChildOpt newChild targetChild -> "
                                for ap in m.Attached do
                                    w.printfn "                // Adjust the attached properties"
                                    w.printfn "                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.%s" (tryGetCode ap)
                                    w.printfn "                let childValueOpt = newChild.%s" (tryGetCode ap)
                                    w.printfn "                match prevChildValueOpt, childValueOpt with"
                                    w.printfn "                | ValueSome prevChildValue, ValueSome currValue when prevChildValue = currValue -> ()"
                                    let apApply = if String.IsNullOrWhiteSpace(ap.ConvToValue) then "" else ap.ConvToValue + " "
                                    w.printfn "                | _, ValueSome currValue -> %s.Set%s(targetChild, %scurrValue)" tdef.FullName ap.Name apApply
                                    w.printfn "                | ValueSome _, ValueNone -> %s.Set%s(targetChild, %s) // TODO: not always perfect, should set back to original default?" tdef.FullName ap.Name ap.DefaultValue
                                    w.printfn "                | _ -> ()"
                                w.printfn "                ())"
                        | _ -> 
                            let update = if String.IsNullOrWhiteSpace(m.ConvToValue) then "" else m.ConvToValue + " "

                            w.printfn "        match prev%sOpt, curr%sOpt with" m.BoundUniqueName m.BoundUniqueName
                            w.printfn "        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()"
#if DEBUG
                            w.printfn "        | _, ValueSome currValue -> System.Diagnostics.Debug.WriteLine(\"Setting %s::%s \"); target.%s <- %s currValue" nameOfCreator m.Name m.Name update
#else
                            w.printfn "        | _, ValueSome currValue -> target.%s <- %s currValue" m.Name update
#endif
                            w.printfn "        | ValueSome _, ValueNone -> target.%s <- %s"  m.Name m.DefaultValue
                            w.printfn "        | ValueNone, ValueNone -> ()"
                                
        // Emit the constructor
        w.printfn ""
        w.printfn "    /// Describes a %s in the view" nameOfCreator
        //let qual = if hasCreate then "internal " else ""
        w.printf "    static member inline %s(" nameOfCreator
        let space = "                         " + String.replicate nameOfCreator.Length " " + " "
        allMembers |> iterSep "," (fun head m -> 
            let inputType = m.GetInputType(bindings, memberResolutions, null)

            if head <> "" then 
                w.printfn ","
                w.printf "%s" space
            if m.LowerBoundShortName = "created" then
                w.printf "?%s: (%s -> unit)" m.LowerBoundShortName tdef.FullName
            elif m.LowerBoundShortName = "ref" then
                w.printf "?%s: ViewRef<%s>"  m.LowerBoundShortName tdef.FullName
            else
                w.printf "?%s: %s" m.LowerBoundShortName inputType)

        w.printfn ") = "
        w.printfn ""
        w.printf "        let attribBuilder = View.Build%s(0" nameOfCreator
        for m in allMembers do
            w.printfn ","
            w.printf "                               "
            if m.LowerBoundShortName = "created" then
                w.printf "?%s=(match %s with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<%s> target)))" m.LowerBoundShortName m.LowerBoundShortName tdef.FullName 
            elif m.LowerBoundShortName = "ref" then
                w.printf "?%s=(match %s with None -> None | Some (ref: ViewRef<%s>) -> Some ref.Unbox)" m.LowerBoundShortName m.LowerBoundShortName tdef.FullName 
            else
                w.printf "?%s=%s" m.LowerBoundShortName m.LowerBoundShortName
        w.printfn ")"
        w.printfn ""
        w.printfn "        ViewElement.Create<%s>(View.CreateFunc%s, View.UpdateFunc%s, attribBuilder)" tdef.FullName nameOfCreator nameOfCreator

        w.printfn ""
        w.printfn "    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]"
        w.printfn "    static member val Proto%s : ViewElement option = None with get, set" nameOfCreator

    w.printfn ""
    w.printfn "[<AutoOpen>]"
    w.printfn "module ViewElementExtensions = "

    w.printfn ""
    w.printfn "    type ViewElement with"

    for ms in allMembersInAllTypesGroupedByName do
        let m = ms.First()
        if not m.IsParam && m.LowerBoundShortName <> "created" && m.LowerBoundShortName <> "ref" then
            w.printfn ""
            w.printfn "        /// Adjusts the %s property in the visual element" m.BoundUniqueName
            let conv = if String.IsNullOrWhiteSpace(m.ConvToModel) then "" else m.ConvToModel
            let inputType = m.GetInputType(bindings, memberResolutions, null)
            w.printfn "        member x.%s(value: %s) = x.WithAttribute(View._%sAttribKey, %s(value))" m.BoundUniqueName inputType m.BoundUniqueName conv

    w.printfn ""
    for ms in allMembersInAllTypesGroupedByName do
        let m = ms.First()
        if not m.IsParam && m.LowerBoundShortName <> "created" && m.LowerBoundShortName <> "ref" then
            let inputType = m.GetInputType(bindings, memberResolutions, null)
            w.printfn ""
            w.printfn "    /// Adjusts the %s property in the visual element" m.BoundUniqueName
            w.printfn "%s" ("    let " + m.LowerBoundUniqueName + " (value: " + inputType + ") (x: ViewElement) = x." + m.BoundUniqueName + "(value)")

    w.ToString ()


let LoadAssembly (path: string) : AssemblyDefinition  =
        //if (path.StartsWith("packages")) {
        //    let user = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
        //    path = Path.Combine (user, ".nuget", path)
        // }
        AssemblyDefinition.ReadAssembly(path)


[<EntryPoint>]
let Main(args: string[]) =
        try 
            if (args.Length < 2) then
                Console.Error.WriteLine("usage: generator <bindingsPath> <outputPath>")
                Environment.Exit(1)
            let bindingsPath = args.[0]
            let outputPath = args.[1]

            let bindings = JsonConvert.DeserializeObject<Bindings> (File.ReadAllText (bindingsPath))

            bindings.AssemblyDefinitions <- bindings.Assemblies.Select(LoadAssembly).ToList()

            let resolutions = 
                [ for x in bindings.Types do
                    match ResolveType (bindings, x.Name) with 
                    | None -> failwith (sprintf "Could not find type '%s'"  x.Name)
                    | Some d -> yield (x, d) ]
                |> dict

            let memberResolutions = 
              [ for x in bindings.Types do
                  for m in x.Members do
                    match FindProperty (m.Name, resolutions.[x]) with 
                    | Some p -> yield (m, (p :> MemberReference))
                    | None -> 
                    match FindEvent (m.Name, resolutions.[x]) with 
                    | Some e -> yield (m, (e :> MemberReference))
                    | None -> 
                      if (String.IsNullOrWhiteSpace(m.UpdateCode))  then
                        Console.WriteLine(sprintf "Could not find member '%s'" m.Name) ]
               |> dict
            let code = BindTypes (bindings, resolutions, memberResolutions)

            File.WriteAllText (outputPath, code)
            0
        with ex -> 
            System.Console.WriteLine(ex)
            1
