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

    let generateCode bindings =
        let toString (w: StringWriter) = w.ToString()

        let data = Preparator.prepareData bindings
        use writer = new StringWriter()
        writer
        |> generateNamespace data.Namespace
        |> generateAttributes data.Attributes
        |> generateProto data.Proto
        |> toString
