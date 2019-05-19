namespace Fabulous.Generator

open Fabulous.Generator.Models
open Fabulous.Generator.Helpers
open Fabulous.Generator.Resolvers
open Fabulous.Generator.CodeGeneratorModels
open System.Collections.Generic
open System.Linq
open Mono.Cecil

module CodeGeneratorPreparation =
    type PreparedEvent =
        { Name : string
          UniqueName : string
          LowerShortName : string
          InputType : string
          ModelType : string
          ConvToModel : string
          IsImmediateMember : bool }

    type PreparedProperty =
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
          AttachedMembers : PreparedProperty [] }

    type PreparedType =
        { Name : string
          FullName : string
          BaseName : string option
          CustomTypeFullName : string
          HasCustomConstructor : bool
          Events : PreparedEvent []
          Properties : PreparedProperty [] }

    let private toPreparedEvent isImmediateMember (bindings, resolutions, hierarchy) (e : EventBinding) =
        { Name = e.Name
          UniqueName = e.BoundUniqueName
          LowerShortName = e.BoundLowerShortName
          InputType = e.InputType
          ModelType = getEventModelType (e, bindings, resolutions, hierarchy)
          ConvToModel =  getValueOrDefault "" e.ConvToModel
          IsImmediateMember = isImmediateMember }

    let rec private toPreparedProperty isImmediateMember (bindings, memberResolutions, hierarchy) (m : PropertyBinding) =
        { Name = m.Name
          UniqueName = m.BoundUniqueName
          LowerShortName = m.LowerBoundShortName
          LowerUniqueName = m.LowerBoundUniqueName
          InputType = getInputType (m, bindings, memberResolutions, hierarchy)
          ModelType = getPropertyModelType (m, bindings, memberResolutions, hierarchy)
          ConvToModel = getValueOrDefault "" m.ConvToModel
          DefaultValue = m.DefaultValue
          ConvToValue = m.ConvToValue
          UpdateCode = m.UpdateCode
          ElementTypeFullName = getElementTypeFullName (m, memberResolutions, hierarchy)
          BoundType =
              tryGetPropertyBoundType memberResolutions m
              |> Option.map (fun tref ->
                     { Name = tref.Name
                       FullName = tref.FullName })
          IsParameter = m.IsParam
          IsImmediateMember = isImmediateMember
          AttachedMembers =
              if m.Attached <> null && m.Attached.Count > 0 then
                  m.Attached
                  |> Seq.map (toPreparedProperty false (bindings, memberResolutions, hierarchy))
                  |> Seq.toArray
              else [||] }

    let private extractAttributes (types : PreparedType []) =
        [| for typ in types do
            // Extract property names and their attached properties
            for m in typ.Properties do
                yield m.UniqueName
                if (m.AttachedMembers.Length > 0) then
                    for ap in m.AttachedMembers do
                        yield ap.UniqueName
            // Extract event names
            for e in typ.Events do
                yield e.UniqueName |]
        |> Seq.distinctBy id
        |> Seq.toArray

    let private toProtoData (typ : PreparedType) = typ.Name

    let private toBuildData (typ : PreparedType) =
        let properties =
            typ.Properties
            |> Array.map (fun p ->
                { Name = p.LowerShortName
                  UniqueName = p.UniqueName
                  InputType = p.InputType
                  ConvToModel = p.ConvToModel
                  IsInherited = not p.IsImmediateMember })
        let events =
            typ.Events
            |> Array.map (fun e ->
                { Name = e.LowerShortName
                  UniqueName = e.UniqueName
                  InputType = e.InputType
                  ConvToModel = e.ConvToModel
                  IsInherited = not e.IsImmediateMember })

        { Name = typ.Name
          BaseName = typ.BaseName
          Members = Array.append properties events }

    let private toCreateData (typ : PreparedType) =
        { Name = typ.Name
          FullName = typ.FullName
          HasCustomConstructor = typ.HasCustomConstructor
          TypeToInstantiate = typ.CustomTypeFullName
          Parameters =
              typ.Properties
              |> Array.filter (fun m -> m.IsParameter)
              |> Array.map (fun m -> m.LowerShortName) }

    let private toUpdateData knownTypes (typ : PreparedType) =
        let toUpdateEvent (e : PreparedEvent) : UpdateEvent =
            { Name = e.Name
              UniqueName = e.UniqueName
              ModelType = e.ModelType }

        let rec toUpdateProperty (m : PreparedProperty) =
            { Name = m.Name
              UniqueName = m.UniqueName
              ModelType = m.ModelType
              DefaultValue = m.DefaultValue
              ConvToValue = m.ConvToValue
              UpdateCode = m.UpdateCode
              ElementTypeFullName = m.ElementTypeFullName
              IsParameter = m.IsParameter
              BoundType = m.BoundType
              Attached = m.AttachedMembers |> Array.map toUpdateProperty }

        { Name = typ.Name
          FullName = typ.FullName
          BaseName = typ.BaseName
          KnownTypes = knownTypes
          ImmediateEvents =
            typ.Events
            |> Array.filter (fun e -> e.IsImmediateMember)
            |> Array.map toUpdateEvent
          ImmediateProperties =
            typ.Properties
            |> Array.filter (fun t -> t.IsImmediateMember)
            |> Array.map toUpdateProperty }

    let private toConstructData (typ : PreparedType) : ConstructData =
        let properties =
            typ.Properties
            |> Array.map (fun p -> { LowerShortName = p.LowerShortName; InputType = p.InputType } : ConstructType)
        let events =
            typ.Events
            |> Array.map (fun e -> { LowerShortName = e.LowerShortName; InputType = e.InputType } : ConstructType)

        { Name = typ.Name
          FullName = typ.FullName
          Members = Array.append properties events }

    let private toBuilderData (knownTypes : string []) (typ : PreparedType) =
        { Build = typ |> toBuildData
          Create = typ |> toCreateData
          Update = typ |> (toUpdateData knownTypes)
          Construct = typ |> toConstructData }

    let private toViewerData (typ : PreparedType) : ViewerData =
        let properties =
            typ.Properties
            |> Array.filter (fun p -> p.IsImmediateMember)
            |> Array.map (fun p -> { Name = p.Name; UniqueName = p.UniqueName })
        let events =
            typ.Events
            |> Array.filter (fun e -> e.IsImmediateMember)
            |> Array.map (fun e -> { Name = e.Name; UniqueName = e.UniqueName })

        { Name = typ.Name
          FullName = typ.FullName
          BaseName = typ.BaseName
          Members = Array.append properties events }

    let private toConstructorData (typ : PreparedType) =
        let properties =
            typ.Properties
            |> Array.map (fun p -> { LowerShortName = p.LowerShortName; InputType = p.InputType })
        let events =
            typ.Events
            |> Array.map (fun e -> { LowerShortName = e.LowerShortName; InputType = e.InputType })

        { Name = typ.Name
          FullName = typ.FullName
          Members = Array.append properties events }

    let private getViewExtensionsData (types : PreparedType []) =
        let toViewExtensionsMember (p : PreparedProperty) =
            { LowerShortName = p.LowerShortName
              LowerUniqueName = p.LowerUniqueName
              UniqueName = p.UniqueName
              InputType = p.InputType
              ConvToModel = p.ConvToModel }
        [| for typ in types do
            if (typ.Properties.Length > 0) then
                for p in typ.Properties do
                    yield p
                    if (p.AttachedMembers.Length > 0) then
                        for ap in p.AttachedMembers do
                            yield ap |]
        |> Array.groupBy (fun y -> y.UniqueName)
        |> Array.map (fun (_, members) -> members |> Array.head)
        |> Array.map toViewExtensionsMember

    /// Extract all events of a control
    let private getPreparedEvents bindings hierarchy events (boundHierarchy: TypeBinding []) (typ: TypeBinding) =
        let inputs = (bindings, events, hierarchy)
        
        let allBaseEvents =
            boundHierarchy
            |> Seq.skip (1)
            |> Seq.collect (fun x -> x.Events)
            |> Seq.toArray
            |> Array.map (toPreparedEvent false inputs)

        let allImmediateEvents =
            typ.Events.ToArray()
            |> Array.map (toPreparedEvent true inputs)

        Array.append allImmediateEvents allBaseEvents

    /// Extract all properties of a control
    let private getPreparedProperties bindings hierarchy properties (boundHierarchy: TypeBinding []) (typ: TypeBinding) =
        let inputs = (bindings, properties, hierarchy)

        let allBaseProperties =
            boundHierarchy
            |> Seq.skip (1)
            |> Seq.collect (fun x -> x.Properties)
            |> Seq.toArray
            |> Array.map (toPreparedProperty false inputs)

        let allImmediateProperties =
            typ.Properties.ToArray()
            |> Array.map (toPreparedProperty true inputs)

        Array.append allImmediateProperties allBaseProperties

    /// Extract all declared controls in a PreparedType list
    let private getTypes (bindings : Bindings,
                          resolutions : IDictionary<TypeBinding, TypeDefinition>,
                          events : IDictionary<EventBinding, EventDefinition>,
                          properties : IDictionary<PropertyBinding, PropertyDefinition>) =
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

            yield { Name = nameOfCreator
                    FullName = tdef.FullName
                    BaseName = nameOfBaseCreatorOpt
                    CustomTypeFullName = typeToInstantiate
                    HasCustomConstructor = hasCustomConstructor
                    Events = getPreparedEvents bindings hierarchy events boundHierarchy typ
                    Properties = getPreparedProperties bindings hierarchy properties boundHierarchy typ } |]

    /// Prepare all data to be ready to be consumed by the Code Generator
    let prepareData (bindings : Bindings,
                     resolutions : IDictionary<TypeBinding, TypeDefinition>,
                     events : IDictionary<EventBinding, EventDefinition>,
                     properties : IDictionary<PropertyBinding, PropertyDefinition>) =
        
        let types = getTypes (bindings, resolutions, events, properties)
        let knownTypes = types |> Array.map (fun t -> t.FullName)

        { Namespace = bindings.OutputNamespace
          Attributes = types |> extractAttributes
          Proto = types |> Array.map toProtoData
          Builders = types |> Array.map (toBuilderData knownTypes)
          Viewers = types |> Array.map toViewerData
          Constructors = types |> Array.map toConstructorData
          ViewExtensions = types |> getViewExtensionsData }
