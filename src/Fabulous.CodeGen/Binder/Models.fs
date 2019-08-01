namespace Fabulous.CodeGen.Binder

module Models =
    type AttachedPropertyBinding =
        { TargetType: string
          Name: string
          UniqueName: string
          DefaultValue: string
          InputType: string
          ModelType: string
          ConvertInputToModel: string
          ConvertModelToValue: string
          IsInherited: bool  }
    
    type EventBinding =
        { Name: string
          ShortName: string
          UniqueName: string
          InputType: string
          ModelType: string
          ConvertInputToModel: string
          RelatedProperties: string[]
          IsInherited: bool }
    
    type PropertyBinding =
        { Name: string
          ShortName: string
          UniqueName: string
          DefaultValue: string
          OriginalType: string
          InputType: string
          ModelType: string
          ConvertInputToModel: string
          ConvertModelToValue: string
          IsInherited: bool }
    
    type TypeBinding =
        { Type: string
          TypeToInstantiate: string
          BaseTypeName: string option
          Name: string
          AttachedProperties: AttachedPropertyBinding array
          Events: EventBinding array
          Properties: PropertyBinding array }
    
    type Bindings =
        { Assemblies: string array
          OutputNamespace: string
          BaseAttachedPropertyTargetType: string
          Types: TypeBinding array }