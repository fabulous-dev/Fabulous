// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen.Generator

open Fabulous.CodeGen.Generator.CodeGeneratorModels

module CodeGeneratorPreparation =
    let prepareData outputNamespace =
        { Namespace = outputNamespace
          Attributes = [| |] }

