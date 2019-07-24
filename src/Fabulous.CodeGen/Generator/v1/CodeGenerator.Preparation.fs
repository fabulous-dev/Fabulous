namespace Fabulous.CodeGen.Generator

open Fabulous.CodeGen.Generator.Modelsv1
open Fabulous.CodeGen.Generator.Helpersv1
open Fabulous.CodeGen.Generator.Resolvers
open Fabulous.CodeGen.Generator.CodeGeneratorModelsv1
open System.Collections.Generic
open System.Linq
open Mono.Cecil

module CodeGeneratorPreparationv1 =
    type PreparedMember =
        { Name : string
          UniqueName : string
          LowerShortName : string
          LowerUniqueName : string
          InputType : string
          ModelType : string
          ConvToModel : string
          DefaultValue : string
          ConvToValue : string
          UpdateCode : string
          ElementTypeFullName : string option
          BoundType : BoundType option
          IsParameter : bool
          IsImmediateMember : bool
          AttachedMembers : PreparedMember [] }

    type PreparedType =
        { Name : string
          FullName : string
          BaseName : string option
          CustomTypeFullName : string
          HasCustomConstructor : bool
          Members : PreparedMember [] }

    let rec toPreparedMember isImmediateMember (bindings, memberResolutions, hierarchy) (m : MemberBinding) =
        { Name = m.Name
          UniqueName = m.BoundUniqueName
          LowerShortName = m.LowerBoundShortName
          LowerUniqueName = m.LowerBoundUniqueName
          InputType = getInputType (m, bindings, memberResolutions, hierarchy)
          ModelType = getModelType (m, bindings, memberResolutions, hierarchy)
          ConvToModel = getValueOrDefault "" m.ConvToModel
          DefaultValue = m.DefaultValue
          ConvToValue = m.ConvToValue
          UpdateCode = m.UpdateCode
          ElementTypeFullName = getElementTypeFullName (m, memberResolutions, hierarchy)
          BoundType =
              tryGetBoundType memberResolutions m
              |> Option.map (fun tref ->
                     { Name = tref.Name
                       FullName = tref.FullName })
          IsParameter = m.IsParam
          IsImmediateMember = isImmediateMember
          AttachedMembers =
              if m.Attached <> null && m.Attached.Count > 0 then
                  m.Attached
                  |> Seq.map (toPreparedMember false (bindings, memberResolutions, hierarchy))
                  |> Seq.toArray
              else [||] }

    let extractAttributes (types : PreparedType []) =
        [| for typ in types do
               for m in typ.Members do
                   yield m.UniqueName
                   if (m.AttachedMembers.Length > 0) then
                       for ap in m.AttachedMembers do
                           yield ap.UniqueName |]
        |> Seq.distinctBy id
        |> Seq.toArray

    let toProtoData (typ : PreparedType) = typ.Name

    let toBuildData (typ : PreparedType) =
        let toBuildMember (m : PreparedMember) =
            { Name = m.LowerShortName
              UniqueName = m.UniqueName
              InputType = m.InputType
              ConvToModel = m.ConvToModel
              IsInherited = not m.IsImmediateMember }
        { Name = typ.Name
          BaseName = typ.BaseName
          Members = typ.Members |> Array.map toBuildMember }

    let toCreateData (typ : PreparedType) =
        { Name = typ.Name
          FullName = typ.FullName
          HasCustomConstructor = typ.HasCustomConstructor
          TypeToInstantiate = typ.CustomTypeFullName
          Parameters =
              typ.Members
              |> Array.filter (fun m -> m.IsParameter)
              |> Array.map (fun m -> m.LowerShortName) }

    let toUpdateData knownTypes (typ : PreparedType) =
        let rec toUpdateMember (m : PreparedMember) =
            { Name = m.Name
              UniqueName = m.UniqueName
              ModelType = m.ModelType
              DefaultValue = m.DefaultValue
              ConvToValue = m.ConvToValue
              UpdateCode = m.UpdateCode
              ElementTypeFullName = m.ElementTypeFullName
              IsParameter = m.IsParameter
              BoundType = m.BoundType
              Attached = m.AttachedMembers |> Array.map toUpdateMember }
        { Name = typ.Name
          FullName = typ.FullName
          BaseName = typ.BaseName
          KnownTypes = knownTypes
          ImmediateMembers =
              typ.Members
              |> Array.filter (fun t -> t.IsImmediateMember)
              |> Array.map toUpdateMember }

    let toConstructData (typ : PreparedType) : ConstructData =
        let toConstructMember (m : PreparedMember) : ConstructType =
            { LowerShortName = m.LowerShortName
              InputType = m.InputType }
        { Name = typ.Name
          FullName = typ.FullName
          Members = typ.Members |> Array.map toConstructMember }

    let toBuilderData (knownTypes : string []) (typ : PreparedType) =
        { Build = typ |> toBuildData
          Create = typ |> toCreateData
          Update = typ |> (toUpdateData knownTypes)
          Construct = typ |> toConstructData }

    let toViewerData (typ : PreparedType) : ViewerData =
        let toViewerMember (m : PreparedMember) =
            { Name = m.Name
              UniqueName = m.UniqueName }
        { Name = typ.Name
          FullName = typ.FullName
          BaseName = typ.BaseName
          Members = typ.Members |> Array.filter (fun m -> m.IsImmediateMember) |> Array.map toViewerMember }

    let toConstructorData (typ : PreparedType) =
        let toConstructorMember (m : PreparedMember) =
            { LowerShortName = m.LowerShortName
              InputType = m.InputType }
        { Name = typ.Name
          FullName = typ.FullName
          Members = typ.Members |> Array.map toConstructorMember }

    let getViewExtensionsData (types : PreparedType []) =
        let toViewExtensionsMember (m : PreparedMember) =
            { LowerShortName = m.LowerShortName
              LowerUniqueName = m.LowerUniqueName
              UniqueName = m.UniqueName
              InputType = m.InputType
              ConvToModel = m.ConvToModel }
        [| for typ in types do
               if (typ.Members.Length > 0) then
                   for y in typ.Members do
                       yield y
                       if (y.AttachedMembers.Length > 0) then
                           for ap in y.AttachedMembers do
                               yield ap |]
        |> Array.groupBy (fun y -> y.UniqueName)
        |> Array.map (fun (_, members) -> members |> Array.head)
        |> Array.map toViewExtensionsMember

    let getTypes (bindings : Bindings,
                  resolutions : IDictionary<TypeBinding, TypeDefinition>,
                  memberResolutions : IDictionary<MemberBinding, MemberReference>) =
        [| for typ in bindings.Types do
            let tdef = resolutions.[typ]
            let nameOfCreator = getValueOrDefault tdef.Name typ.ModelName
            let hierarchy = getHierarchy(tdef).ToList()

            let boundHierarchy =
                hierarchy
                |> Seq.choose
                        (fun (x, _) ->
                        bindings.Types
                        |> Seq.tryFind (fun y -> y.Name = x.FullName))
                |> Seq.toArray

            let baseTypeOpt =
                if boundHierarchy.Length > 1 then Some boundHierarchy.[1]
                else None

            let nameOfBaseCreatorOpt =
                baseTypeOpt
                |> Option.map (fun baseType ->
                        getValueOrDefault resolutions.[baseType].Name baseType.ModelName)

            let typeToInstantiate =
                getValueOrDefault tdef.FullName typ.CustomType

            let ctor =
                tdef.Methods.Where(fun x -> x.IsConstructor && x.IsPublic)
                    .OrderBy(fun x -> x.Parameters.Count)
                    .FirstOrDefault()

            let hasCustomConstructor =
                (tdef.IsAbstract || ctor = null || ctor.Parameters.Count > 0)

            let inputs = (bindings, memberResolutions, hierarchy)

            let allBaseMembers =
                boundHierarchy
                |> Seq.skip (1)
                |> Seq.collect (fun x -> x.Members)
                |> Seq.toArray
                |> Array.map (toPreparedMember false inputs)

            let allImmediateMembers =
                typ.Members.ToArray()
                |> Array.map (toPreparedMember true inputs)

            let allMembers = Array.append allImmediateMembers allBaseMembers
            
            yield { Name = nameOfCreator
                    FullName = tdef.FullName
                    BaseName = nameOfBaseCreatorOpt
                    CustomTypeFullName = typeToInstantiate
                    HasCustomConstructor = hasCustomConstructor
                    Members = allMembers } |]

    let prepareData (bindings : Bindings,
                     resolutions : IDictionary<TypeBinding, TypeDefinition>,
                     memberResolutions : IDictionary<MemberBinding, MemberReference>) =
        
        let types = getTypes (bindings, resolutions, memberResolutions)
        let knownTypes = types |> Array.map (fun t -> t.FullName)

        { Namespace = bindings.OutputNamespace
          Attributes = types |> extractAttributes
          Proto = types |> Array.map toProtoData
          Builders = types |> Array.map (toBuilderData knownTypes)
          Viewers = types |> Array.map toViewerData
          Constructors = types |> Array.map toConstructorData
          ViewExtensions = types |> getViewExtensionsData }
