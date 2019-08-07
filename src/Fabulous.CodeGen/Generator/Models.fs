// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen.Generator

module Models =
    type BoundType =
        { Name: string
          FullName: string }

    type ConstructType =
        { Name: string
          InputType: string }

    type ConstructorType =
        { Name: string
          InputType: string }

    type BuildMember =
        { Name : string
          UniqueName : string
          InputType : string
          ConvertInputToModel : string
          IsInherited : bool }

    type BuildData =
        { Name : string
          BaseName : string option
          Members : BuildMember [] }

    type CreateData =
        { Name : string
          FullName : string
          HasCustomConstructor : bool
          TypeToInstantiate : string
          Parameters : string [] }

    type UpdateMember =
        { UniqueName : string
          ModelType : string }
    
    type UpdateEvent =
        { Name : string
          UniqueName : string
          RelatedProperties : string [] }
        
    type UpdateProperty =
        { Name : string
          UniqueName : string
          DefaultValue : string
          OriginalType : string
          ModelType : string
          ConvertModelToValue : string
          UpdateCode : string
          ElementType : string option } 
        
    type UpdateAttachedProperty =
        { Name : string }

    type UpdateData =
        { Name : string
          FullName : string
          BaseName : string option
          ImmediateMembers : UpdateMember []
          Events : UpdateEvent []
          Properties : UpdateProperty []
          AttachedProperties : UpdateAttachedProperty [] }

    type ConstructData =
        { Name : string
          FullName : string
          Members : ConstructType [] }

    type BuilderData =
        { Build : BuildData
          Create : CreateData
          Update : UpdateData
          Construct : ConstructData }

    type ViewerMember =
        { Name : string
          UniqueName : string }

    type ViewerData =
        { Name : string
          FullName : string
          BaseName: string option
          Members : ViewerMember [] }

    type ConstructorData =
        { Name : string
          FullName : string
          Members : ConstructorType [] }

    type ViewExtensionsData =
        { LowerShortName : string
          LowerUniqueName : string
          UniqueName : string
          InputType : string
          ConvToModel : string }
        
    type GeneratorData =
        { Namespace : string
          Attributes : string[]
          Builders : BuilderData []
          Viewers : ViewerData []
          Constructors : ConstructorData []
          ViewExtensions : ViewExtensionsData [] }
