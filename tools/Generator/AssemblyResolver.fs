// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.Generator

open Mono.Cecil
open System.Collections.Generic

module AssemblyResolver =
    type RegistrableResolver() =
        inherit BaseAssemblyResolver()

        let cache = Dictionary<string, AssemblyDefinition>()

        override this.Resolve(name) =
            match cache.TryGetValue(name.FullName) with
            | true, assembly -> assembly
            | false, _ ->
                let assembly = base.Resolve(name)
                cache.[name.FullName] <- assembly
                assembly

        member this.RegisterAssembly(assembly: AssemblyDefinition): unit =
            match cache.ContainsKey(assembly.Name.FullName) with
            | true -> ()
            | false ->
                cache.[assembly.Name.FullName] <- assembly

        member this.Dispose(disposing) =
            cache.Values |> Seq.iter (fun asm -> asm.Dispose())
            cache.Clear()
            base.Dispose()

    let loadAssembly (resolver: RegistrableResolver) (path: string) =
        let readerParameters = ReaderParameters()
        readerParameters.AssemblyResolver <- resolver
        let assembly = AssemblyDefinition.ReadAssembly(path, readerParameters)
        resolver.RegisterAssembly assembly
        assembly
