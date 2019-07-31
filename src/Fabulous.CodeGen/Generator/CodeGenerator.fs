// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen.Generator

open Fabulous.CodeGen.Helpers
open Fabulous.CodeGen.Generator.Models
open System.IO

module CodeGenerator =
    let generateNamespace (namespaceOfGeneratedCode: string) (w: StringWriter) = 
        w.printfn "// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license."
        w.printfn "namespace %s" namespaceOfGeneratedCode
        w.printfn ""
        w.printfn "#nowarn \"59\" // cast always holds"
        w.printfn "#nowarn \"66\" // cast always holds"
        w.printfn "#nowarn \"67\" // cast always holds"
        w.printfn ""
        w.printfn "open Fabulous"
        w.printfn ""
        w

    let generateAttributes (members: string []) (w: StringWriter) =
        w.printfn "module ViewAttributes ="
        for m in members do
            w.printfn "    let %sAttribKey : AttributeKey<_> = AttributeKey<_>(\"%s\")" m m
        w.printfn ""
        w

    let generateProto (types: string []) (w: StringWriter) =
        w.printfn "type ViewProto() ="
        for name in types do
            w.printfn "    static member val Proto%s : ViewElement option = None with get, set" name
        w.printfn ""
        w

    let generateBuildFunction (data: BuildData) (w: StringWriter) =
        let memberNewLine = "\n                              " + String.replicate data.Name.Length " " + " "
        let members =
            data.Members
            |> Array.map (fun m -> sprintf ",%s?%s: %s" memberNewLine m.Name m.InputType)
            |> Array.fold (+) ""

        let immediateMembers =
            data.Members
            |> Array.filter (fun m -> not m.IsInherited)

        w.printfn "    /// Builds the attributes for a %s in the view" data.Name
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
            let baseMemberNewLine = "\n                                              " + String.replicate nameOfBaseCreator.Length " " + " "
            let baseMembers =
                data.Members
                |> Array.filter (fun m -> m.IsInherited)
                |> Array.mapi (fun index m -> sprintf ", %s?%s: %s" (if index > 0 && index % 5 = 0 then baseMemberNewLine else "") m.Name m.InputType)
                |> Array.fold (+) ""
            w.printfn "        let attribBuilder = ViewBuilders.Build%s(attribCount%s)" nameOfBaseCreator baseMembers

        for m in immediateMembers do
            w.printfn "        match %s with None -> () | Some v -> attribBuilder.Add(ViewAttributes.%sAttribKey, %s(v)) " m.Name m.UniqueName m.ConvertInputToModel 

        w.printfn "        attribBuilder"
        w.printfn ""
        w

    let generateCreateFunction (data: CreateData) (w: StringWriter) =
        w.printfn "    static member val CreateFunc%s : (unit -> %s) = (fun () -> ViewBuilders.Create%s()) with get, set" data.Name data.FullName data.Name
        w.printfn ""
        w.printfn "    static member Create%s () : %s =" data.Name data.FullName

        match data.HasCustomConstructor with
        | true ->
            w.printfn "        failwith \"can't create %s\"" data.FullName
        | false ->
            match data.Parameters with
            | [||] ->
                if data.TypeToInstantiate = data.FullName then
                    w.printfn "        new %s()" data.TypeToInstantiate
                else
                    w.printfn "        upcast (new %s())" data.TypeToInstantiate
            | ps ->
                // TODO
                failwith "Constructor with parameters not implemented"
        w.printfn ""
        w
        
    let generateUpdateFunction (data: UpdateData) (w: StringWriter) =
        w.printfn "    static member val UpdateFunc%s =" data.Name 
        w.printfn "        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: %s) -> ViewBuilders.Update%s (prevOpt, curr, target)) " data.FullName data.Name
        w.printfn ""
        w.printfn "    static member Update%s (prevOpt: ViewElement voption, curr: ViewElement, target: %s) = " data.Name data.FullName

        match data.BaseName with 
        | None -> ()
        | Some nameOfBaseCreator ->
            // TODO : Foireux - appeler direct UpdateXXX
            w.printfn "        // update the inherited %s element" nameOfBaseCreator
            w.printfn "        let baseElement = (if ViewProto.Proto%s.IsNone then ViewProto.Proto%s <- Some (ViewBuilders.Construct%s())); ViewProto.Proto%s.Value" nameOfBaseCreator nameOfBaseCreator nameOfBaseCreator nameOfBaseCreator
            w.printfn "        baseElement.UpdateInherited (prevOpt, curr, target)"

        if (data.ImmediateMembers.Length = 0) then
            w.printfn "        ()"
        else
            for m in data.ImmediateMembers do
                w.printfn "        let mutable prev%sOpt = ValueNone" m.UniqueName
                w.printfn "        let mutable curr%sOpt = ValueNone" m.UniqueName
            w.printfn "        for kvp in curr.AttributesKeyed do"
            for m in data.ImmediateMembers do
                w.printfn "            if kvp.Key = ViewAttributes.%sAttribKey.KeyValue then " m.UniqueName
                w.printfn "                curr%sOpt <- ValueSome (kvp.Value :?> %s)" m.UniqueName m.ModelType
            w.printfn "        match prevOpt with"
            w.printfn "        | ValueNone -> ()"
            w.printfn "        | ValueSome prev ->"
            w.printfn "            for kvp in prev.AttributesKeyed do"
            for m in data.ImmediateMembers do
                w.printfn "                if kvp.Key = ViewAttributes.%sAttribKey.KeyValue then " m.UniqueName
                w.printfn "                    prev%sOpt <- ValueSome (kvp.Value :?> %s)" m.UniqueName m.ModelType

            // Unsubscribe previous event handlers
            for e in data.Events do
                let relatedProperties =
                    e.RelatedProperties
                    |> Array.map (fun p -> sprintf "(identical prev%sOpt curr%sOpt)" p p)
                    |> Array.fold (fun a b -> a + " && " + b) ""

                w.printfn "        let shouldUpdate%s = not ((identical prev%sOpt curr%sOpt)%s)" e.UniqueName e.UniqueName e.UniqueName relatedProperties
                w.printfn "        if shouldUpdate%s then" e.UniqueName
                w.printfn "            match prev%sOpt with" e.UniqueName
                w.printfn "            | ValueSome prevValue -> target.%s.RemoveHandler(prevValue)" e.Name
                w.printfn "            | ValueNone -> ()"
            
            
            // Subscribe event handlers
            for e in data.Events do
                w.printfn "        if shouldUpdate%s then" e.UniqueName
                w.printfn "            match curr%sOpt with" e.UniqueName
                w.printfn "            | ValueSome currValue -> target.%s.AddHandler(currValue)" e.Name
                w.printfn "            | ValueNone -> ()"
            
//            for m in members do
//                let hasApply = not (System.String.IsNullOrWhiteSpace(m.ConvToValue)) || not (System.String.IsNullOrWhiteSpace(m.UpdateCode))
//
//                // Check if the member is a collection
//                match m.ElementTypeFullName with 
//                | Some elementType when not hasApply ->
//                    w.printfn "        updateCollectionGeneric prev%sOpt curr%sOpt target.%s" m.UniqueName m.UniqueName m.Name
//                    w.printfn "            (fun (x:ViewElement) -> x.Create() :?> %s)" elementType
//                    if (m.Attached.Length > 0) then
//                        w.printfn "            (fun prevChildOpt newChild targetChild -> "
//                        for ap in m.Attached do
//                            w.printfn "                // Adjust the attached properties"
//                            w.printfn "                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<%s>(ViewAttributes.%sAttribKey)" ap.ModelType ap.UniqueName
//                            w.printfn "                let childValueOpt = newChild.TryGetAttributeKeyed<%s>(ViewAttributes.%sAttribKey)" ap.ModelType ap.UniqueName
//                            if System.String.IsNullOrWhiteSpace(ap.UpdateCode) then
//                                let apApply = getValueOrDefault "" (ap.ConvToValue + " ")
//                                w.printfn "                match prevChildValueOpt, childValueOpt with"
//                                w.printfn "                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()"
//                                w.printfn "                | _, ValueSome currChildValue -> %s.Set%s(targetChild, %scurrChildValue)" data.FullName ap.Name apApply
//                                w.printfn "                | ValueSome _, ValueNone -> %s.Set%s(targetChild, %s)" data.FullName ap.Name ap.DefaultValue
//                                w.printfn "                | _ -> ()"
//                            else
//                                w.printfn "                %s prevChildValueOpt childValueOpt targetChild" ap.UpdateCode
//                        w.printfn "                ())"
//                    else
//                        w.printfn "            (fun _ _ _ -> ())"
//                    w.printfn "            canReuseView"
//                    w.printfn "            updateChild"
//
//                | _ -> 
//                    match m.BoundType with 
//
//                    // Check if the type of the member is in the model, if so issue recursive calls to "Create" and "UpdateIncremental"
//                    // ModelType = "ViewElement" is also accepted because some properties (like FlyoutHeader) are typed object by default (thus disabling control reuse in the generator)
//                    | Some boundType when ((tryFindType data.KnownTypes boundType.FullName).IsSome || m.ModelType = "ViewElement") && not hasApply ->
//                        w.printfn "        match prev%sOpt, curr%sOpt with" m.UniqueName m.UniqueName
//                        w.printfn "        // For structured objects, dependsOn on reference equality"
//                        w.printfn "        | ValueSome prevValue, ValueSome newValue when identical prevValue newValue -> ()"
//                        w.printfn "        | ValueSome prevValue, ValueSome newValue when canReuseView prevValue newValue ->"
//                        w.printfn "            newValue.UpdateIncremental(prevValue, target.%s)" m.Name
//                        w.printfn "        | _, ValueSome newValue ->"
//                        w.printfn "            target.%s <- (newValue.Create() :?> %s)" m.Name boundType.FullName
//                        w.printfn "        | ValueSome _, ValueNone ->"
//                        w.printfn "            target.%s <- null"  m.Name
//                        w.printfn "        | ValueNone, ValueNone -> ()"
//
//                    // Default for delegate-typed things
//                    | Some boundType when (boundType.Name.EndsWith("Handler") || boundType.Name.EndsWith("Handler`1") || boundType.Name.EndsWith("Handler`2")) && not hasApply ->
//                        w.printfn "        match prev%sOpt, curr%sOpt with" m.UniqueName m.UniqueName
//                        w.printfn "        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()"
//                        w.printfn "        | ValueSome prevValue, ValueSome currValue -> target.%s.RemoveHandler(prevValue); target.%s.AddHandler(currValue)" m.Name m.Name
//                        w.printfn "        | ValueNone, ValueSome currValue -> target.%s.AddHandler(currValue)" m.Name
//                        w.printfn "        | ValueSome prevValue, ValueNone -> target.%s.RemoveHandler(prevValue)" m.Name
//                        w.printfn "        | ValueNone, ValueNone -> ()"
//
//                    // Explicit update code
//                    | _ when not (System.String.IsNullOrWhiteSpace(m.UpdateCode))  -> 
//                        w.printfn "        %s prev%sOpt curr%sOpt target" m.UpdateCode m.UniqueName m.UniqueName
//                        if (m.Attached.Length > 0) then
//                            w.printfn "            (fun prevChildOpt newChild targetChild -> "
//                            for ap in m.Attached do
//                                w.printfn "                // Adjust the attached properties"
//                                w.printfn "                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<%s>(ViewAttributes.%sAttribKey)" ap.ModelType ap.UniqueName
//                                w.printfn "                let childValueOpt = newChild.TryGetAttributeKeyed<%s>(ViewAttributes.%sAttribKey)" ap.ModelType ap.UniqueName
//
//                                if System.String.IsNullOrWhiteSpace(ap.UpdateCode) then
//                                    let apApply = getValueOrDefault "" (ap.ConvToValue + " ")
//                                    w.printfn "                match prevChildValueOpt, childValueOpt with"
//                                    w.printfn "                | ValueSome prevChildValue, ValueSome currValue when prevChildValue = currValue -> ()"
//                                    w.printfn "                | _, ValueSome currValue -> %s.Set%s(targetChild, %scurrValue)" data.FullName ap.Name apApply
//                                    w.printfn "                | ValueSome _, ValueNone -> %s.Set%s(targetChild, %s) // TODO: not always perfect, should set back to original default?" data.FullName ap.Name ap.DefaultValue
//                                    w.printfn "                | _ -> ()"
//                                else
//                                    w.printfn "                %s prevChildValueOpt childValueOpt targetChild" ap.UpdateCode
//                            w.printfn "                ())"
//
//                    | _ -> 
//                        let update = getValueOrDefault "" m.ConvToValue
//                        w.printfn "        match prev%sOpt, curr%sOpt with" m.UniqueName m.UniqueName
//                        w.printfn "        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()"
//                        w.printfn "        | _, ValueSome currValue -> target.%s <- %s currValue" m.Name update
//                        w.printfn "        | ValueSome _, ValueNone -> target.%s <- %s"  m.Name m.DefaultValue
//                        w.printfn "        | ValueNone, ValueNone -> ()"
        w.printfn ""
        w   


    let generateBuilders (data: BuilderData []) (w: StringWriter) =
        w.printfn "type ViewBuilders() ="
        for typ in data do
            w
            |> generateBuildFunction typ.Build
            |> generateCreateFunction typ.Create
            |> generateUpdateFunction typ.Update
            |> ignore
//            |> generateConstruct typ.Construct
        w

    let generateCode bindings =
        let toString (w: StringWriter) = w.ToString()

        let data = Preparator.prepareData bindings
        use writer = new StringWriter()
        writer
        |> generateNamespace data.Namespace
        |> generateAttributes data.Attributes
        |> generateProto data.Proto
        |> generateBuilders data.Builders
        |> toString
