// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Generator.Tests

open NUnit.Framework
open FsUnit
open Fabulous.Generator
open Fabulous.Generator.CodeGeneratorPreparation
open Fabulous.Generator.CodeGeneratorModels

module ``CodeGeneratorPreparation Tests`` =
    let preparedType =
        { Name = "PreparedTypeName"
          FullName = "PreparedTypeFullName"
          BaseName = Some "PreparedTypeBaseName"
          CustomTypeFullName = "PreparedTypeCustomTypeFullName"
          HasCustomConstructor = false
          Members =
                [| { Name = "Member1Name"
                     UniqueName = "Member1UniqueName"
                     LowerShortName = "Member1LowerShortName"
                     LowerUniqueName = "Member1LowerUniqueName"
                     InputType = "Member1InputType"
                     ModelType = "Member1ModelType"
                     ConvToModel = "Member1ConvToModel"
                     DefaultValue = "Member1DefaultValue"
                     ConvToValue = "Member1ConvToValue"
                     UpdateCode = "Member1UpdateCode"
                     ElementTypeFullName = None
                     BoundType = None
                     IsParameter = true
                     IsImmediateMember = false
                     AttachedMembers = [||] }
                   { Name = "Member2Name"
                     UniqueName = "Member2UniqueName"
                     LowerShortName = "Member2LowerShortName"
                     LowerUniqueName = "Member2LowerUniqueName"
                     InputType = "Member2InputType"
                     ModelType = "Member2ModelType"
                     ConvToModel = "Member2ConvToModel"
                     DefaultValue = "Member2DefaultValue"
                     ConvToValue = "Member2ConvToValue"
                     UpdateCode = "Member2UpdateCode"
                     ElementTypeFullName = Some "Member2ElementTypeNameFullName"
                     BoundType = Some { Name = "Member2BoundTypeName"; FullName = "Member2BoundTypeFullName" }
                     IsParameter = false
                     IsImmediateMember = true
                     AttachedMembers =
                        [| { Name = "Member2AttachedMember1Name"
                             UniqueName = "Member2AttachedMember1UniqueName"
                             LowerShortName = "Member2AttachedMember1LowerShortName"
                             LowerUniqueName = "Member2AttachedMember1LowerUniqueName"
                             InputType = "Member2AttachedMember1InputType"
                             ModelType = "Member2AttachedMember1ModelType"
                             ConvToModel = "Member2AttachedMember1ConvToModel"
                             DefaultValue = "Member2AttachedMember1DefaultValue"
                             ConvToValue = "Member2AttachedMember1ConvToValue"
                             UpdateCode = "Member2AttachedMember1UpdateCode"
                             ElementTypeFullName = None
                             BoundType = None
                             IsParameter = false
                             IsImmediateMember = true
                             AttachedMembers = [||] } |] } |] }

    let preparedTypes = [| preparedType |]

    [<Test>]
    let ``extractAttributes should return a valid array of unique attribute names``() =
        let expected = [| "Member1UniqueName"; "Member2UniqueName"; "Member2AttachedMember1UniqueName" |]

        preparedTypes |> CodeGeneratorPreparation.extractAttributes |> should equal expected


    [<Test>]
    let ``toProtoData should return the name of the type``() =
        preparedType |> CodeGeneratorPreparation.toProtoData |> should equal "PreparedTypeName"

    [<Test>]
    let ``toBuildData should return a valid BuildData``() =
        let expectedBuildData =
            { Name = "PreparedTypeName"
              BaseName = Some "PreparedTypeBaseName"
              Members =
                [| { Name = "Member1LowerShortName"
                     UniqueName = "Member1UniqueName"
                     InputType = "Member1InputType"
                     ConvToModel = "Member1ConvToModel"
                     IsInherited = true }
                   { Name = "Member2LowerShortName"
                     UniqueName = "Member2UniqueName"
                     InputType = "Member2InputType"
                     ConvToModel = "Member2ConvToModel"
                     IsInherited = false } |] }

        preparedType |> CodeGeneratorPreparation.toBuildData |> should equal expectedBuildData

    [<Test>]
    let ``toCreateData should return a valid CreateData``() =
        let expectedCreateData =
            { Name = "PreparedTypeName"
              FullName = "PreparedTypeFullName"
              HasCustomConstructor = false
              TypeToInstantiate = "PreparedTypeCustomTypeFullName"
              Parameters = [| "Member1LowerShortName" |] }

        preparedType |> CodeGeneratorPreparation.toCreateData |> should equal expectedCreateData

    [<Test>]
    let ``toUpdateData should return a valid UpdateData``() =
        let knownTypes = [| "KnownType1"; "KnownType2" |]

        let expectedUpdateData =
            { Name = "PreparedTypeName"
              FullName = "PreparedTypeFullName"
              BaseName = Some "PreparedTypeBaseName"
              KnownTypes = knownTypes
              ImmediateMembers =
                [| { Name = "Member2Name"
                     UniqueName = "Member2UniqueName"
                     ModelType = "Member2ModelType"
                     DefaultValue = "Member2DefaultValue"
                     ConvToValue = "Member2ConvToValue"
                     UpdateCode = "Member2UpdateCode"
                     ElementTypeFullName = Some "Member2ElementTypeNameFullName"
                     IsParameter = false
                     BoundType = Some { Name = "Member2BoundTypeName"; FullName = "Member2BoundTypeFullName" }
                     Attached =
                        [| { Name = "Member2AttachedMember1Name"
                             UniqueName = "Member2AttachedMember1UniqueName"
                             ModelType = "Member2AttachedMember1ModelType"
                             DefaultValue = "Member2AttachedMember1DefaultValue"
                             ConvToValue = "Member2AttachedMember1ConvToValue"
                             UpdateCode = "Member2AttachedMember1UpdateCode"
                             ElementTypeFullName = None
                             IsParameter = false
                             BoundType = None
                             Attached = [||] } |] } |] }

        preparedType |> CodeGeneratorPreparation.toUpdateData knownTypes |> should equal expectedUpdateData

    [<Test>]
    let ``toConstructData should return a valid ConstructData``() =
        let expectedConstructData : ConstructData =
            { Name = "PreparedTypeName"
              FullName = "PreparedTypeFullName"
              Members =
                [| { LowerShortName = "Member1LowerShortName"
                     InputType = "Member1InputType" }
                   { LowerShortName = "Member2LowerShortName"
                     InputType = "Member2InputType" } |] }

        preparedType |> CodeGeneratorPreparation.toConstructData |> should equal expectedConstructData

    [<Test>]
    let ``toBuilderData should return a valid BuilderData``() =
        let knownTypes = [| "KnownType1"; "KnownType2" |]

        let expectedBuildData =
            { Name = "PreparedTypeName"
              BaseName = Some "PreparedTypeBaseName"
              Members =
                [| { Name = "Member1LowerShortName"
                     UniqueName = "Member1UniqueName"
                     InputType = "Member1InputType"
                     ConvToModel = "Member1ConvToModel"
                     IsInherited = true }
                   { Name = "Member2LowerShortName"
                     UniqueName = "Member2UniqueName"
                     InputType = "Member2InputType"
                     ConvToModel = "Member2ConvToModel"
                     IsInherited = false } |] }
        let expectedCreateData =
            { Name = "PreparedTypeName"
              FullName = "PreparedTypeFullName"
              HasCustomConstructor = false
              TypeToInstantiate = "PreparedTypeCustomTypeFullName"
              Parameters = [| "Member1LowerShortName" |] }
        let expectedUpdateData =
            { Name = "PreparedTypeName"
              FullName = "PreparedTypeFullName"
              BaseName = Some "PreparedTypeBaseName"
              KnownTypes = knownTypes
              ImmediateMembers =
                [| { Name = "Member2Name"
                     UniqueName = "Member2UniqueName"
                     ModelType = "Member2ModelType"
                     DefaultValue = "Member2DefaultValue"
                     ConvToValue = "Member2ConvToValue"
                     UpdateCode = "Member2UpdateCode"
                     ElementTypeFullName = Some "Member2ElementTypeNameFullName"
                     IsParameter = false
                     BoundType = Some { Name = "Member2BoundTypeName"; FullName = "Member2BoundTypeFullName" }
                     Attached =
                        [| { Name = "Member2AttachedMember1Name"
                             UniqueName = "Member2AttachedMember1UniqueName"
                             ModelType = "Member2AttachedMember1ModelType"
                             DefaultValue = "Member2AttachedMember1DefaultValue"
                             ConvToValue = "Member2AttachedMember1ConvToValue"
                             UpdateCode = "Member2AttachedMember1UpdateCode"
                             ElementTypeFullName = None
                             IsParameter = false
                             BoundType = None
                             Attached = [||] } |] } |] }
        let expectedConstructData : ConstructData =
            { Name = "PreparedTypeName"
              FullName = "PreparedTypeFullName"
              Members =
                [| { LowerShortName = "Member1LowerShortName"
                     InputType = "Member1InputType" }
                   { LowerShortName = "Member2LowerShortName"
                     InputType = "Member2InputType" } |] }
        let expectedBuilderData =
            { Build = expectedBuildData
              Create = expectedCreateData
              Update = expectedUpdateData
              Construct = expectedConstructData }

        preparedType |> CodeGeneratorPreparation.toBuilderData knownTypes |> should equal expectedBuilderData

    [<Test>]
    let ``toViewerData should return a valid ViewerData``() =
        let expectedViewerData : ViewerData =
            { Name = "PreparedTypeName"
              FullName = "PreparedTypeFullName"
              BaseName = Some "PreparedTypeBaseName"
              Members =
                [| { Name = "Member2Name"
                     UniqueName = "Member2UniqueName" } |]}

        preparedType |> CodeGeneratorPreparation.toViewerData |> should equal expectedViewerData

    [<Test>]
    let ``toConstructorData should return a valid ConstructorData``() =
        let expectedConstructorData =
            { Name = "PreparedTypeName"
              FullName = "PreparedTypeFullName"
              Members =
                [| { LowerShortName = "Member1LowerShortName"
                     InputType = "Member1InputType" }
                   { LowerShortName = "Member2LowerShortName"
                     InputType = "Member2InputType" } |]}

        preparedType |> CodeGeneratorPreparation.toConstructorData |> should equal expectedConstructorData

    [<Test>]
    let ``getViewExtensionsData should return a valid array of ViewExtensionsData``() =
        let expected =
            [| { LowerShortName = "Member1LowerShortName"
                 LowerUniqueName = "Member1LowerUniqueName"
                 UniqueName = "Member1UniqueName"
                 InputType = "Member1InputType"
                 ConvToModel = "Member1ConvToModel" }
               { LowerShortName = "Member2LowerShortName"
                 LowerUniqueName = "Member2LowerUniqueName"
                 UniqueName = "Member2UniqueName"
                 InputType = "Member2InputType"
                 ConvToModel = "Member2ConvToModel" }
               { LowerShortName = "Member2AttachedMember1LowerShortName"
                 LowerUniqueName = "Member2AttachedMember1LowerUniqueName"
                 UniqueName = "Member2AttachedMember1UniqueName"
                 InputType = "Member2AttachedMember1InputType"
                 ConvToModel = "Member2AttachedMember1ConvToModel" } |]

        preparedTypes |> CodeGeneratorPreparation.getViewExtensionsData |> should equal expected