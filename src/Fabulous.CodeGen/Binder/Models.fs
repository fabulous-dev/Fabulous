namespace Fabulous.CodeGen.Binder

module Models =
    type AttachedPropertyBinding =
        { Name: string
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
          ElementType: string option
          InputType: string
          ModelType: string
          ConvertInputToModel: string
          ConvertModelToValue: string
          AttachedProperties: AttachedPropertyBinding array
          IsInherited: bool }
    
    type TypeBinding =
        { Type: string
          TypeToInstantiate: string
          BaseTypeName: string option
          Name: string
          Events: EventBinding array
          Properties: PropertyBinding array }
    
    type Bindings =
        { Assemblies: string array
          OutputNamespace: string
          Types: TypeBinding array }