// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen.Generator

module Models =    
    // Prepared types
    
    // CodeGenerator types
    type GeneratorData =
        { Namespace : string
          Attributes: string[]
          Proto: string[] }
