// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen

module Models =
    type AttachedPropertyOverwriteData =
        { Position: int option
          Source: string option
          TargetType: string option
          Name: string option
          UniqueName: string option
          DefaultValue: string option
          InputType: string option
          ModelType: string option
          ConvertInputToModel: string option
          ConvertModelToValue: string option }
        
    type PropertyOverwriteData =
        { Position: int option
          Source: string option
          Name: string option
          ShortName: string option
          UniqueName: string option
          DefaultValue: string option
          InputType: string option
          ModelType: string option
          ConvertInputToModel: string option
          ConvertModelToValue: string option }
        
    type EventOverwriteData =
        { Position: int option
          Source: string option
          Name: string option
          ShortName: string option
          UniqueName: string option
          Type: string option
          EventArgsType: string option }
    
    type TypeOverwriteData =
        { Type: string
          CustomType: string option
          Name: string option
          Events: EventOverwriteData array option
          Properties: PropertyOverwriteData array option
          AttachedProperties: AttachedPropertyOverwriteData array option }
    
    type OverwriteData =
        { Assemblies: string array
          OutputNamespace: string
          BaseAttachedPropertyTargetType: string
          Types: TypeOverwriteData array }