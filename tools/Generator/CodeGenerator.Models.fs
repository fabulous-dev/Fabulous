namespace Fabulous.Generator

module CodeGeneratorModels =
    type BoundType =
        { Name: string
          FullName: string }

    type ConstructType =
        { LowerShortName: string
          InputType: string }

    type ConstructorType =
        { LowerShortName: string
          InputType: string }

    type BuildMember =
        { Name : string
          UniqueName : string
          InputType : string
          ConvToModel : string
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
        { Name : string
          UniqueName : string
          ModelType : string
          DefaultValue : string
          ConvToValue : string
          UpdateCode : string
          ElementTypeFullName : string option
          IsParameter : bool
          BoundType : BoundType option
          Attached : UpdateMember [] }

    type UpdateData =
        { Name : string
          FullName : string
          BaseName : string option
          ImmediateMembers : UpdateMember []
          KnownTypes : string [] }

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
          Attributes : string []
          Proto : string []
          Builders : BuilderData []
          Viewers : ViewerData []
          Constructors : ConstructorData []
          ViewExtensions : ViewExtensionsData [] }
