// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.Generator

open Fabulous.Generator.Models
open Fabulous.Generator.Helpers
open Fabulous.Generator.Resolvers
open System.Collections.Generic
open System.Linq
open System.IO
open Mono.Cecil

module CodeGenerator =
    type BuildMember =
        { Name: string
          UniqueName: string
          InputType: string
          ConvToModel: string
          IsInherited: bool }

    type BuildData =
        { Name: string
          BaseName: string option
          Members: BuildMember [] }

    type CreateData =
        { Name: string
          FullName: string
          HasCustomConstructor: bool
          TypeToInstantiate: string
          Parameters: string [] }

    type UpdateMember =
        { Name: string
          UniqueName: string
          ModelType: string
          DefaultValue: string
          ConvToValue: string
          UpdateCode: string
          ElementTypeFullName: string option
          IsParameter: bool
          BoundType: (string * string) option
          Attached: UpdateMember [] }

    type UpdateData =
        { Name: string
          FullName: string
          BaseName: string option
          ImmediateMembers: UpdateMember []
          KnownTypes: string [] }

    type ConstructorData =
        { Name: string
          FullName: string
          Members: (string * string) [] }

    type ViewExtensionsMember =
        { LowerShortName: string
          LowerUniqueName: string
          UniqueName: string
          InputType: string
          ConvToModel: string }

    type ViewExtensionsData =
        { Members: ViewExtensionsMember [] }

    let generateNamespaceAndClass (namespaceOfGeneratedCode: string) (w: StringWriter) = 
        w.printfn "// Copyright 2018 Fabulous contributors. See LICENSE.md for license."
        w.printfn "namespace %s" namespaceOfGeneratedCode
        w.printfn ""
        w.printfn "#nowarn \"59\" // cast always holds"
        w.printfn "#nowarn \"66\" // cast always holds"
        w.printfn "#nowarn \"67\" // cast always holds"
        w.printfn ""
        w.printfn "type View() ="

    let generateAttributes (members: string []) (w: StringWriter) =
        for m in members do
            w.printfn "    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]"
            w.printfn "    static member val _%sAttribKey : AttributeKey<_> = AttributeKey<_>(\"%s\")" m m

    let generateBuildFunction (data: BuildData) (w: StringWriter) =
        let memberNewLine = "\n                              " + String.replicate data.Name.Length " " + " "
        let members =
            data.Members
            |> Array.map (fun m -> sprintf ",%s?%s: %s" memberNewLine m.Name m.InputType)
            |> Array.fold (+) ""

        let baseMembers =
            data.Members
            |> Array.filter (fun m -> m.IsInherited)
            |> Array.map (fun m -> sprintf ", ?%s=%s" m.Name m.Name)
            |> Array.fold (+) ""

        let immediateMembers =
            data.Members
            |> Array.filter (fun m -> not m.IsInherited)        

        w.printfn "    /// Builds the attributes for a %s in the view" data.Name
        w.printfn "    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]"
        w.printfn "    static member inline Build%s(attribCount: int%s) = " data.Name members

        if immediateMembers.Length > 0 then
            w.printfn ""
            for m in immediateMembers do
                w.printfn "        let attribCount = match %s with Some _ -> attribCount + 1 | None -> attribCount" m.Name
            w.printfn ""

        match data.BaseName with 
        | None ->
            w.printfn "        let attribBuilder = new AttributesBuilder(attribCount)"
        | Some nameOfBaseCreator ->
            w.printfn "        let attribBuilder = View.Build%s(attribCount%s)" nameOfBaseCreator baseMembers

        for m in immediateMembers do
            w.printfn "        match %s with None -> () | Some v -> attribBuilder.Add(View._%sAttribKey, %s(v)) " m.Name m.UniqueName m.ConvToModel 

        w.printfn "        attribBuilder"

    let generateCreateFunction (data: CreateData) (w: StringWriter) =
        w.printfn "    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]"
        w.printfn "    static member val CreateFunc%s : (unit -> %s) = (fun () -> View.Create%s())" data.Name data.FullName data.Name
        w.printfn ""
        w.printfn "    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]"
        w.printfn "    static member Create%s () : %s = " data.Name data.FullName

        match data.HasCustomConstructor with
        | true ->
            w.printfn "        failwith \"can't create %s\"" data.FullName
        | false ->
            match data.Parameters with
            | [||] ->
                w.printfn "        upcast (new %s())" data.TypeToInstantiate
            | ps ->
                let matchParameters = ps |> Array.reduce (fun a b -> sprintf "%s, %s" a b)
                let someParameters = ps |> Array.reduce (fun a b -> sprintf "%s, Some %s" a b)
                w.printfn "        match %s with" matchParameters
                w.printfn "        | %s ->" someParameters
                w.printfn "            upcast (new %s(%s))" data.TypeToInstantiate matchParameters
                w.printfn "        | _ -> upcast (new %s())" data.TypeToInstantiate                
            
    let generateUpdateFunction (data: UpdateData) (w: StringWriter) =       
        w.printfn "    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]"
        w.printfn "    static member val UpdateFunc%s = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: %s) -> View.Update%s (prevOpt, curr, target)) " data.Name data.FullName data.Name
        w.printfn ""
        w.printfn "    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]"
        w.printfn "    static member Update%s (prevOpt: ViewElement voption, curr: ViewElement, target: %s) = " data.Name data.FullName

        match data.BaseName with 
        | None -> ()
        | Some nameOfBaseCreator ->
            w.printfn "        // update the inherited %s element" nameOfBaseCreator
            w.printfn "        let baseElement = (if View.Proto%s.IsNone then View.Proto%s <- Some (View.%s())); View.Proto%s.Value" nameOfBaseCreator nameOfBaseCreator nameOfBaseCreator nameOfBaseCreator
            w.printfn "        baseElement.UpdateInherited (prevOpt, curr, target)"

        if (data.ImmediateMembers.Length = 0) then
            w.printfn "        ignore prevOpt"
            w.printfn "        ignore curr"
            w.printfn "        ignore target"
        else
            for m in data.ImmediateMembers do
                w.printfn "        let mutable prev%sOpt = ValueNone" m.UniqueName
                w.printfn "        let mutable curr%sOpt = ValueNone" m.UniqueName
            w.printfn "        for kvp in curr.AttributesKeyed do"
            for m in data.ImmediateMembers do
                w.printfn "            if kvp.Key = View._%sAttribKey.KeyValue then " m.UniqueName
                w.printfn "                curr%sOpt <- ValueSome (kvp.Value :?> %s)" m.UniqueName m.ModelType
            w.printfn "        match prevOpt with"
            w.printfn "        | ValueNone -> ()"
            w.printfn "        | ValueSome prev ->"
            w.printfn "            for kvp in prev.AttributesKeyed do"
            for m in data.ImmediateMembers do
                w.printfn "                if kvp.Key = View._%sAttribKey.KeyValue then " m.UniqueName
                w.printfn "                    prev%sOpt <- ValueSome (kvp.Value :?> %s)" m.UniqueName m.ModelType

            let members = data.ImmediateMembers |> Array.filter (fun m -> not m.IsParameter)
            for m in members do
                let hasApply = not (System.String.IsNullOrWhiteSpace(m.ConvToValue)) || not (System.String.IsNullOrWhiteSpace(m.UpdateCode))

                // Check if the member is a collection
                match m.ElementTypeFullName with 
                | Some elementType when not hasApply ->
                    w.printfn "        updateCollectionGeneric prev%sOpt curr%sOpt target.%s" m.UniqueName m.UniqueName m.Name
                    w.printfn "            (fun (x:ViewElement) -> x.Create() :?> %s)" elementType
                    if (m.Attached.Length > 0) then
                        w.printfn "            (fun prevChildOpt newChild targetChild -> "
                        for ap in m.Attached do
                            let apApply = getValueOrDefault "" (ap.ConvToValue + " ")
                            w.printfn "                // Adjust the attached properties"
                            w.printfn "                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<%s>(View._%sAttribKey)" ap.ModelType ap.UniqueName
                            w.printfn "                let childValueOpt = newChild.TryGetAttributeKeyed<%s>(View._%sAttribKey)" ap.ModelType ap.UniqueName
                            w.printfn "                match prevChildValueOpt, childValueOpt with"
                            w.printfn "                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()"
                            w.printfn "                | _, ValueSome currChildValue -> %s.Set%s(targetChild, %scurrChildValue)" data.FullName ap.Name apApply
                            w.printfn "                | ValueSome _, ValueNone -> %s.Set%s(targetChild, %s)" data.FullName ap.Name ap.DefaultValue
                            w.printfn "                | _ -> ()"
                        w.printfn "                ())"
                    else
                        w.printfn "            (fun _ _ _ -> ())"
                    w.printfn "            canReuseChild"
                    w.printfn "            updateChild"

                | _ -> 
                    match m.BoundType with 

                    // Check if the type of the member is in the model, if so issue recursive calls to "Create" and "UpdateIncremental"
                    | Some (_, fullName) when (tryFindType data.KnownTypes fullName).IsSome && not hasApply ->
                        w.printfn "        match prev%sOpt, curr%sOpt with" m.UniqueName m.UniqueName
                        w.printfn "        // For structured objects, dependsOn on reference equality"
                        w.printfn "        | ValueSome prevValue, ValueSome newValue when identical prevValue newValue -> ()"
                        w.printfn "        | ValueSome prevValue, ValueSome newValue when canReuseChild prevValue newValue ->"
                        w.printfn "            newValue.UpdateIncremental(prevValue, target.%s)" m.Name
                        w.printfn "        | _, ValueSome newValue ->"
                        w.printfn "            target.%s <- (newValue.Create() :?> %s)" m.Name fullName
                        w.printfn "        | ValueSome _, ValueNone ->"
                        w.printfn "            target.%s <- null"  m.Name
                        w.printfn "        | ValueNone, ValueNone -> ()"

                    // Default for delegate-typed things
                    | Some (name, _) when (name.EndsWith("Handler") || name.EndsWith("Handler`1") || name.EndsWith("Handler`2")) && not hasApply ->
                        w.printfn "        match prev%sOpt, curr%sOpt with" m.UniqueName m.UniqueName
                        w.printfn "        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()"
                        w.printfn "        | ValueSome prevValue, ValueSome currValue -> target.%s.RemoveHandler(prevValue); target.%s.AddHandler(currValue)" m.Name m.Name
                        w.printfn "        | ValueNone, ValueSome currValue -> target.%s.AddHandler(currValue)" m.Name
                        w.printfn "        | ValueSome prevValue, ValueNone -> target.%s.RemoveHandler(prevValue)" m.Name
                        w.printfn "        | ValueNone, ValueNone -> ()"

                    // Explicit update code
                    | _ when not (System.String.IsNullOrWhiteSpace(m.UpdateCode))  -> 
                        w.printfn "        %s prev%sOpt curr%sOpt target" m.UpdateCode m.UniqueName m.UniqueName
                        if (m.Attached.Length > 0) then
                            w.printfn "            (fun prevChildOpt newChild targetChild -> "
                            for ap in m.Attached do
                                let apApply = getValueOrDefault "" (ap.ConvToValue + " ")
                                w.printfn "                // Adjust the attached properties"
                                w.printfn "                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<%s>(View._%sAttribKey)" ap.ModelType ap.UniqueName
                                w.printfn "                let childValueOpt = newChild.TryGetAttributeKeyed<%s>(View._%sAttribKey)" ap.ModelType ap.UniqueName
                                w.printfn "                match prevChildValueOpt, childValueOpt with"
                                w.printfn "                | ValueSome prevChildValue, ValueSome currValue when prevChildValue = currValue -> ()"
                                w.printfn "                | _, ValueSome currValue -> %s.Set%s(targetChild, %scurrValue)" data.FullName ap.Name apApply
                                w.printfn "                | ValueSome _, ValueNone -> %s.Set%s(targetChild, %s) // TODO: not always perfect, should set back to original default?" data.FullName ap.Name ap.DefaultValue
                                w.printfn "                | _ -> ()"
                            w.printfn "                ())"

                    | _ -> 
                        let update = getValueOrDefault "" m.ConvToValue
                        w.printfn "        match prev%sOpt, curr%sOpt with" m.UniqueName m.UniqueName
                        w.printfn "        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()"
                        w.printfn "        | _, ValueSome currValue -> target.%s <- %s currValue" m.Name update
                        w.printfn "        | ValueSome _, ValueNone -> target.%s <- %s"  m.Name m.DefaultValue
                        w.printfn "        | ValueNone, ValueNone -> ()"

    let generateConstructor (data: ConstructorData) (w: StringWriter) =
        let memberNewLine = "\n                         " + String.replicate data.Name.Length " " + " "
        let space = "\n                               "
        let membersForConstructor =
            data.Members
            |> Array.mapi (fun i (memberName, inputType) ->
                let commaSpace = if i = 0 then "" else "," + memberNewLine
                match memberName with
                | "created" -> sprintf "%s?%s: (%s -> unit)" commaSpace memberName data.FullName
                | "ref" ->     sprintf "%s?%s: ViewRef<%s>" commaSpace memberName data.FullName
                | _ ->         sprintf "%s?%s: %s" commaSpace memberName inputType)
            |> Array.fold (+) ""
        let membersForBuild =
            data.Members
            |> Array.map (fun (memberName, _) ->
                match memberName with
                | "created" -> sprintf ",%s?%s=(match %s with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<%s> target)))" space memberName memberName data.FullName
                | "ref" ->     sprintf ",%s?%s=(match %s with None -> None | Some (ref: ViewRef<%s>) -> Some ref.Unbox)" space memberName memberName data.FullName
                | _ ->         sprintf ",%s?%s=%s" space memberName memberName)
            |> Array.fold (+) ""

        w.printfn "    /// Describes a %s in the view" data.Name
        w.printfn "    static member inline %s(%s) = " data.Name membersForConstructor
        w.printfn ""
        w.printfn "        let attribBuilder = View.Build%s(0%s)" data.Name membersForBuild
        w.printfn ""
        w.printfn "        ViewElement.Create<%s>(View.CreateFunc%s, View.UpdateFunc%s, attribBuilder)" data.FullName data.Name data.Name

    let generateProto (name: string) (w: StringWriter) =
        w.printfn "    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]"
        w.printfn "    static member val Proto%s : ViewElement option = None with get, set" name

    let generateViewExtensions (data: ViewExtensionsData) (w: StringWriter) =
        w.printfn "[<AutoOpen>]"
        w.printfn "module ViewElementExtensions = "
        w.printfn ""
        w.printfn "    type ViewElement with"

        for m in data.Members do
            match m.LowerShortName with
            | "created" | "ref" -> ()
            | _ ->
                let conv = getValueOrDefault "" m.ConvToModel
                w.printfn ""
                w.printfn "        /// Adjusts the %s property in the visual element" m.UniqueName
                w.printfn "        member x.%s(value: %s) = x.WithAttribute(View._%sAttribKey, %s(value))" m.UniqueName m.InputType m.UniqueName conv

        w.printfn ""

        for m in data.Members do
            match m.LowerShortName with
            | "created" | "ref" -> ()
            | _ ->
                w.printfn ""
                w.printfn "    /// Adjusts the %s property in the visual element" m.UniqueName
                w.printfn "    let %s (value: %s) (x: ViewElement) = x.%s(value)" m.LowerUniqueName m.InputType m.UniqueName

    let generateCode (bindings: Bindings, resolutions: IDictionary<TypeBinding, TypeDefinition>, memberResolutions: IDictionary<MemberBinding, MemberReference>) =
        let w = new StringWriter()

        let toViewExtensionsMember (m: MemberBinding) =
            { LowerShortName = m.LowerBoundShortName
              LowerUniqueName = m.LowerBoundUniqueName
              UniqueName = m.BoundUniqueName
              InputType = m.GetInputType(bindings, memberResolutions, null)
              ConvToModel = m.ConvToModel }

        let allMembersInAllTypes =
            [| for typ in bindings.Types do
                if (typ.Members <> null) then
                    for y in typ.Members do
                        yield y
                        if (y.Attached <> null) then
                            for ap in y.Attached do
                                yield ap |]
            |> Array.groupBy (fun y -> y.BoundUniqueName)
            |> Array.map (fun (_, members) -> members |> Array.head)

        let allImmediateMembersCombined = 
           [| for typ in bindings.Types do
                for m in typ.Members.ToList() do
                    yield m.BoundUniqueName
                    if (m.Attached <> null) then
                        for ap in m.Attached do
                            yield ap.BoundUniqueName
           |]
           |> Seq.distinctBy id
           |> Seq.toArray    

        w |> generateNamespaceAndClass bindings.OutputNamespace
        w.printfn ""
        w |> generateAttributes allImmediateMembersCombined

        for typ in bindings.Types do
            let tdef = resolutions.[typ]
            let nameOfCreator = getValueOrDefault tdef.Name typ.ModelName
            let hierarchy = getHierarchy(tdef).ToList()
            let boundHierarchy = hierarchy |> Seq.choose (fun (x, _) -> bindings.Types |> Seq.tryFind (fun y -> y.Name = x.FullName)) |> Seq.toArray
            let baseTypeOpt = if boundHierarchy.Length > 1 then Some boundHierarchy.[1] else None
            let nameOfBaseCreatorOpt = baseTypeOpt |> Option.map (fun baseType -> getValueOrDefault resolutions.[baseType].Name baseType.ModelName)
            let allBaseMembers = boundHierarchy |> Seq.skip(1) |> Seq.collect (fun x -> x.Members) |> Seq.toArray
            let allImmediateMembers = typ.Members.ToArray()
            let allMembers = Array.append allImmediateMembers allBaseMembers
            let ctor = 
                tdef.Methods
                 .Where(fun x -> x.IsConstructor && x.IsPublic)
                 .OrderBy(fun x -> x.Parameters.Count)
                 .FirstOrDefault()

            let toBuildMember isInherited (m: MemberBinding) =
                { Name = m.LowerBoundShortName
                  UniqueName = m.BoundUniqueName
                  InputType = m.GetInputType(bindings, memberResolutions, hierarchy)
                  ConvToModel = getValueOrDefault "" m.ConvToModel
                  IsInherited = isInherited }

            let rec toUpdateMember (m: MemberBinding) =
                { Name = m.Name
                  UniqueName = m.BoundUniqueName
                  ModelType = m.GetModelType(bindings, memberResolutions, hierarchy)
                  DefaultValue = m.DefaultValue
                  ConvToValue = m.ConvToValue
                  UpdateCode = m.UpdateCode
                  ElementTypeFullName = m.GetElementTypeFullName(memberResolutions, hierarchy)
                  IsParameter = m.IsParam
                  BoundType = tryGetBoundType memberResolutions m |> Option.map (fun tref -> (tref.Name, tref.FullName))
                  Attached =
                    if m.Attached <> null && m.Attached.Count > 0 then
                        m.Attached |> Seq.map toUpdateMember |> Seq.toArray
                    else
                        [||] }

            w.printfn ""
            w |> generateBuildFunction
                    { Name = nameOfCreator
                      BaseName = nameOfBaseCreatorOpt
                      Members = 
                        Array.append
                            (allImmediateMembers |> Array.map (toBuildMember false))
                            (allBaseMembers |> Array.map (toBuildMember true)) }

            w.printfn ""
            w |> generateCreateFunction
                    { Name = nameOfCreator
                      FullName = tdef.FullName
                      HasCustomConstructor = (tdef.IsAbstract || ctor = null || ctor.Parameters.Count > 0)
                      TypeToInstantiate = getValueOrDefault tdef.FullName typ.CustomType
                      Parameters = allMembers |> Array.filter (fun m -> m.IsParam) |> Array.map (fun m -> m.LowerBoundShortName) }

            w.printfn ""
            w |> generateUpdateFunction
                    { Name = nameOfCreator
                      FullName = tdef.FullName
                      BaseName = nameOfBaseCreatorOpt
                      KnownTypes = bindings.Types |> Seq.map (fun t -> t.Name) |> Seq.toArray 
                      ImmediateMembers = allImmediateMembers |> Array.map toUpdateMember }

            w.printfn ""
            w |> generateConstructor
                    { Name = nameOfCreator
                      FullName = tdef.FullName
                      Members = allMembers |> Array.map (fun m -> (m.LowerBoundShortName, m.GetInputType(bindings, memberResolutions, null))) }

            w.printfn ""
            w |> generateProto nameOfCreator

        w.printfn ""
        w |> generateViewExtensions
                { Members = allMembersInAllTypes |> Array.map toViewExtensionsMember }

        w.ToString ()
