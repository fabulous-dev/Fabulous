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

        let baseMembers =
            data.Members
            |> Array.filter (fun m -> m.IsInherited)
            |> Array.map (fun m -> sprintf ", ?%s=%s" m.Name m.Name)
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
            w.printfn "        let attribBuilder = ViewBuilders.Build%s(attribCount%s)" nameOfBaseCreator baseMembers

        for m in immediateMembers do
            w.printfn "        match %s with None -> () | Some v -> attribBuilder.Add(ViewAttributes.%sAttribKey, %s(v)) " m.Name m.UniqueName m.ConvertInputToModel 

        w.printfn "        attribBuilder"
        w.printfn ""
        w

    let generateBuilders (data: BuilderData []) (w: StringWriter) =
        w.printfn "type ViewBuilders() ="
        for typ in data do
            w
            |> generateBuildFunction typ.Build
            |> ignore
//            |> generateCreateFunction typ.Create
//            |> generateUpdateFunction typ.Update
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
