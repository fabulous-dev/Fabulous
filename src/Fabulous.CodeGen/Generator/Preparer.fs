// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen.Generator

open Fabulous.CodeGen
open Fabulous.CodeGen.Binder.Models
open Fabulous.CodeGen.Generator.Models

module Preparer =
    let extractAttributes (boundTypes: BoundType array) =
        [| for boundType in boundTypes do
               for e in boundType.Events do
                   yield e.UniqueName
               for p in boundType.Properties do
                   yield p.UniqueName
                   
                   match p.CollectionData with
                   | None -> ()
                   | Some cd ->
                       for ap in cd.AttachedProperties do
                           yield ap.UniqueName |]
        |> Seq.distinctBy id
        |> Seq.toArray

    let toBuildData (boundType: BoundType) =
        let toBuildMember (m: IBoundConstructorMember) : BuildMember =
            { Name = m.ShortName
              UniqueName = m.UniqueName
              InputType = m.InputType
              ConvertInputToModel = m.ConvertInputToModel
              IsInherited = m.IsInherited }
        
        let properties = boundType.Properties |> Array.map toBuildMember
        let events = boundType.Events |> Array.map toBuildMember
        let members = Array.concat [ properties; events ]
        
        { Name = boundType.Name
          BaseName = boundType.BaseTypeName
          Members = members }

    let toCreateData (boundType: BoundType) =
        { Name = boundType.Name
          FullName = boundType.Type
          TypeToInstantiate = boundType.TypeToInstantiate }

    let toUpdateData (boundType: BoundType) =
        let immediateEvents = boundType.Events |> Array.filter (fun e -> not e.IsInherited && e.CanBeUpdated)
        let immediateProperties = boundType.Properties |> Array.filter (fun p -> not p.IsInherited && p.CanBeUpdated)
        
        let eventMembers = immediateEvents |> Array.map (fun e -> { UniqueName = e.UniqueName; ModelType = e.ModelType })
        let propertyMembers = immediateProperties |> Array.map (fun p -> { UniqueName = p.UniqueName; ModelType = p.ModelType })
        let immediateMembers = Array.concat [ eventMembers; propertyMembers ]
        
        let updateEvents = immediateEvents |> Array.map (fun e ->
            { Name = e.Name
              UniqueName = e.UniqueName
              RelatedProperties = e.RelatedProperties }
        )
        
        let updateProperties =
            immediateProperties
            |> Array.map (fun p ->
                { Name = p.Name
                  UniqueName = p.UniqueName
                  DefaultValue = p.DefaultValue
                  OriginalType = p.OriginalType
                  ModelType = p.ModelType
                  ConvertModelToValue = p.ConvertModelToValue
                  UpdateCode = p.UpdateCode
                  CollectionData =
                      p.CollectionData
                      |> Option.map (fun cd ->
                          { ElementType = cd.ElementType
                            AttachedProperties =
                                cd.AttachedProperties
                                |> Array.map (fun ap ->
                                    { Name = ap.Name
                                      UniqueName = ap.UniqueName
                                      DefaultValue = ap.DefaultValue
                                      ModelType = ap.ModelType
                                      ConvertModelToValue = ap.ConvertModelToValue
                                      UpdateCode = ap.UpdateCode }) }) })
        
        { Name = boundType.Name
          FullName = boundType.Type
          BaseName = boundType.BaseTypeName
          ImmediateMembers = immediateMembers
          Events = updateEvents
          Properties = updateProperties }

    let toConstructData (boundType: BoundType) : ConstructData =
        let properties = boundType.Properties |> Array.map (fun p -> { Name = p.ShortName; InputType = p.InputType } : ConstructType)
        let events = boundType.Events |> Array.map (fun e -> { Name = e.ShortName; InputType = e.InputType } : ConstructType)
        let members = Array.concat [ properties; events ]
        
        { Name = boundType.Name
          FullName = boundType.Type
          Members = members }
    
    let toBuilderData (boundType: BoundType) =
        { Build = toBuildData boundType
          Create = if boundType.CanBeInstantiated then Some (toCreateData boundType) else None
          Update = toUpdateData boundType
          Construct = if boundType.CanBeInstantiated then Some (toConstructData boundType) else None }

    let toViewerData (boundType: BoundType) : ViewerData =
        let properties = boundType.Properties |> Array.filter (fun p -> not p.IsInherited) |> Array.map (fun p -> { Name = p.Name; UniqueName = p.UniqueName })
        let events = boundType.Events |> Array.filter (fun e -> not e.IsInherited) |> Array.map (fun e -> { Name = e.Name; UniqueName = e.UniqueName })
        let members = Array.concat [ properties; events ]
            
        { Name = boundType.Name
          FullName = boundType.Type
          BaseName = boundType.BaseTypeName
          Members = members }

    let toConstructorData (boundType: BoundType) =
        let properties = boundType.Properties |> Array.map (fun p -> { Name = p.ShortName; InputType = p.InputType })
        let events = boundType.Events |> Array.map (fun e -> { Name = e.ShortName; InputType = e.InputType })
        let members = Array.concat [ properties; events ]
        
        { Name = boundType.Name
          FullName = boundType.Type
          Members = members }

    let getViewExtensionsData (types: BoundType array) =
        let toViewExtensionsMember (m: IBoundMember) =
            { LowerUniqueName = Text.toLowerPascalCase m.UniqueName
              UniqueName = m.UniqueName
              InputType = m.InputType
              ConvToModel = m.ConvertInputToModel }
            
        [| for typ in types do
               for e in typ.Events do
                   yield toViewExtensionsMember e
               for p in typ.Properties do
                   yield toViewExtensionsMember p
                   
                   match p.CollectionData with
                   | None -> ()
                   | Some cd ->
                       for a in cd.AttachedProperties do
                           yield toViewExtensionsMember a |]
        |> Array.groupBy (fun y -> y.UniqueName)
        |> Array.map (fun (_, members) -> members |> Array.head)
    
    let prepareData (boundModel: BoundModel) =
        { Namespace = boundModel.OutputNamespace
          Attributes = extractAttributes boundModel.Types
          Builders = boundModel.Types |> Array.map toBuilderData
          Viewers = boundModel.Types |> Array.map toViewerData
          Constructors = boundModel.Types |> Array.filter (fun t -> t.CanBeInstantiated) |> Array.map toConstructorData
          ViewExtensions = boundModel.Types |> getViewExtensionsData }

