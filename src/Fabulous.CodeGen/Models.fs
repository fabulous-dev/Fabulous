// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen

module Models =        
    type PropertyOverwriteData =
        { Source: string option
          Name: string option
          ShortName: string option
          UniqueName: string option
          DefaultValue: string option
          InputType: string option
          ModelType: string option
          ConvertInputToModel: string option
          ConvertModelToValue: string option }
        
    type EventOverwriteData =
        { Source: string option
          Name: string option
          ShortName: string option
          UniqueName: string option
          InputType: string option
          ModelType: string option
          ConvertInputToModel: string option
          RelatedProperties: string[] option }
        
    type AttachedPropertyOverwriteData =
        { Source: string option
          TargetType: string option
          Name: string option
          UniqueName: string option
          DefaultValue: string option
          InputType: string option
          ModelType: string option
          ConvertInputToModel: string option
          ConvertModelToValue: string option }
    
    type TypeOverwriteData =
        { Type: string
          CustomType: string option
          Name: string option
          Events: EventOverwriteData array option
          Properties: PropertyOverwriteData array option
          AttachedProperties: AttachedPropertyOverwriteData array option
          ConstructorMemberOrdering: string[] option }
    
    type OverwriteData =
        { Assemblies: string array
          OutputNamespace: string
          BaseAttachedPropertyTargetType: string
          Types: TypeOverwriteData array }