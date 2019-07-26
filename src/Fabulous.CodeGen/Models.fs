// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen

module Models =
    /// Reader models
    type EventReaderData =
        { Name: string
          Type: string
          EventArgsType: string }
    
    type AttachedPropertyReaderData =
        { Name: string
          Type: string
          DefaultValue: string }
    
    type PropertyReaderData =
        { Name: string
          Type: string
          DefaultValue: string }
    
    type TypeReaderData =
        { Name: string
          Events: EventReaderData array
          AttachedProperties: AttachedPropertyReaderData array
          Properties: PropertyReaderData array }
    
    /// Overwrite models
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
        { Name: string
          CustomType: string option
          Events: EventOverwriteData array option
          Properties: PropertyOverwriteData array option
          AttachedProperties: AttachedPropertyOverwriteData array option }
    
    type OverwriteData =
        { Assemblies: string array
          OutputNamespace: string
          BaseAttachedPropertyTargetType: string
          Types: TypeOverwriteData array }
        
    /// Binding models    
    type AttachedPropertyBinding =
        { TargetType: string
          Name: string
          UniqueName: string
          DefaultValue: string
          InputType: string
          ModelType: string
          ConvertInputToModel: string
          ConvertModelToValue: string }
    
    type EventBinding =
        { Name: string
          ShortName: string
          UniqueName: string
          Type: string
          EventArgsType: string }
    
    type PropertyBinding =
        { Name: string
          ShortName: string
          UniqueName: string
          DefaultValue: string
          InputType: string
          ModelType: string
          ConvertInputToModel: string
          ConvertModelToValue: string }
    
    type TypeBinding =
        { Name: string
          CustomType: string option
          AttachedProperties: AttachedPropertyBinding array
          Events: EventBinding array
          Properties: PropertyBinding array }
    
    type Bindings =
        { Assemblies: string array
          OutputNamespace: string
          BaseAttachedPropertyTargetType: string
          Types: TypeBinding array }