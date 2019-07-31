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
        { Position: int
          Name: string
          ShortName: string
          UniqueName: string
          Type: string
          EventArgsType: string
          IsInherited: bool }
    
    type PropertyBinding =
        { Position: int
          Name: string
          ShortName: string
          UniqueName: string
          DefaultValue: string
          InputType: string
          ModelType: string
          ConvertInputToModel: string
          ConvertModelToValue: string
          IsInherited: bool }
    
    type TypeBinding =
        { Type: string
          CustomType: string option
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