// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen.Generator

open Fabulous.CodeGen.Generator.CodeGeneratorModels
open Fabulous.CodeGen.Models

module CodeGeneratorPreparation =
    
    let extractAttributes (types : TypeBinding[]) =
        [| for ``type`` in types do
               for a in ``type``.AttachedProperties do
                   yield a.UniqueName
               for e in ``type``.Events do
                   yield e.UniqueName
               for p in ``type``.Properties do
                   yield p.UniqueName |]
        |> Seq.distinctBy id
        |> Seq.toArray
    
    let prepareData (bindings: Bindings) =
        { Namespace = bindings.OutputNamespace
          Attributes = extractAttributes bindings.Types }

