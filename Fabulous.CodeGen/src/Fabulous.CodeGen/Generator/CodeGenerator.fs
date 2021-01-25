// Copyright Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen.Generator

open Fabulous.CodeGen
open Fabulous.CodeGen.Binder.Models
open Fabulous.CodeGen.Text
open Fabulous.CodeGen.Generator.Models
open System.IO

module CodeGenerator =
    let getAttributeKeyName uniqueName =
        sprintf "%sAttribKey" uniqueName

    let getAttributeKey customAttributeKey uniqueName =
        match customAttributeKey with
        | None -> sprintf "ViewAttributes.%s" (getAttributeKeyName uniqueName)
        | Some attributeKey -> attributeKey

    let generateNamespace (namespaceOfGeneratedCode: string) (additionalNamespaces: string array) (w: StringWriter) =
        w.printfn "// Copyright Fabulous contributors. See LICENSE.md for license."
        w.printfn "namespace %s" namespaceOfGeneratedCode
        w.printfn ""
        w.printfn "#nowarn \"59\" // cast always holds"
        w.printfn "#nowarn \"66\" // cast always holds"
        w.printfn "#nowarn \"67\" // cast always holds"
        w.printfn "#nowarn \"760\""
        w.printfn ""
        w.printfn "open Fabulous"

        for additionalNamespace in additionalNamespaces do
            w.printfn "open %s" additionalNamespace

        w.printfn ""
        w

    let generateAttributes (members: AttributeData array) (w: StringWriter) =
        w.printfn "module ViewAttributes ="
        for m in members do
            let typeName =
                match m.Name with
                | "Created" -> "(obj -> unit)"
                | _ -> "_"

            w.printfn "    let %s : AttributeKey<%s> = AttributeKey<%s>(\"%s\")" (getAttributeKeyName m.UniqueName) typeName typeName m.UniqueName
        w.printfn ""
        w

    let generateBuildFunction (data: BuildData) (w: StringWriter) =
        let memberNewLine = "\n                              " + String.replicate data.Name.Length " " + " "
        let members =
            data.Members
            |> Array.map (fun m -> sprintf "?%s: %s" m.Name m.InputType)
            |> Array.reduce (fun a b -> sprintf "%s,%s%s" a memberNewLine b)

        let immediateMembers =
            data.Members
            |> Array.filter (fun m -> not m.IsInherited)

        w.printfn "    /// Builds the attributes for a %s in the view" data.Name
        w.printfn "    static member inline Build%s(%s) = " data.Name members

        match data.BaseName with
        | None ->
            w.printfn "        let attribBuilder = AttributesBuilder()"
        | Some nameOfBaseCreator ->
            let baseMemberNewLine = "\n                                              " + String.replicate nameOfBaseCreator.Length " " + " "
            let baseMembers =
                data.Members
                |> Array.filter (fun m -> m.IsInherited)
                |> Array.map (fun m -> sprintf "?%s=%s" m.Name m.Name)
                |> Array.reduce (fun a b -> sprintf "%s,%s%s" a baseMemberNewLine b)
            w.printfn "        let attribBuilder = ViewBuilders.Build%s(%s)" nameOfBaseCreator baseMembers

        for m in immediateMembers do
            let attributeKey = getAttributeKey m.CustomAttributeKey m.UniqueName
            w.printfn "        match %s with None -> () | Some v -> attribBuilder.Add(%s, %s(v)) " m.Name attributeKey m.ConvertInputToModel

        w.printfn "        attribBuilder"
        w.printfn ""
        w

    let generateCreateFunction (data: CreateData option) (w: StringWriter) =
        match data with
        | None -> w
        | Some data ->
            w.printfn "    static member Create%s (curr: DynamicViewElement, parentOpt: obj voption) : %s =" data.Name data.FullName
                
            match data.CreateCode with
            | Some createCode ->
                w.printfn "        %s curr" createCode
                
            | None ->
                if data.TypeToInstantiate = data.FullName then
                    w.printfn "        %s()" data.TypeToInstantiate
                else
                    w.printfn "        upcast (%s())" data.TypeToInstantiate
            
            w.printfn ""
            w

    let generateUpdateAttachedPropertiesFunction (data: UpdateAttachedPropertiesData) (w: StringWriter) =
        let printUpdateBaseIfNeeded (space: string) (isUnitRequired: bool) =
            match data.BaseName with
            | None when isUnitRequired = false ->
                ()
            | None ->
                w.printfn "%s()" space
            | Some baseName ->
                w.printfn "%sViewBuilders.Update%sAttachedProperties(propertyKey, definition, prevOpt, curr, target)" space baseName

        w.printfn "    static member Update%sAttachedProperties (propertyKey: int, definition: ProgramDefinition, prevOpt: IViewElement voption, curr: IViewElement, target: obj) = " data.Name
        if data.PropertiesWithAttachedProperties.Length = 0 then
            printUpdateBaseIfNeeded "        " true
        else
            w.printfn "        if (curr :? DynamicViewElement) && (prevOpt = ValueNone || (prevOpt.IsSome && prevOpt.Value :? DynamicViewElement)) then"
            w.printfn "            let currDyn = curr :?> DynamicViewElement"
            w.printfn "            let prevOptDyn = ValueOption.map (fun (p: IViewElement) -> p :?> DynamicViewElement) prevOpt"
            w.printfn "            match propertyKey with"
            for p in data.PropertiesWithAttachedProperties do
                w.printfn "            | key when key = %s.KeyValue ->" (getAttributeKey p.CustomAttributeKey p.UniqueName)

                for ap in p.AttachedProperties do
                    let hasApply = not (System.String.IsNullOrWhiteSpace(ap.ConvertModelToValue)) || not (System.String.IsNullOrWhiteSpace(ap.UpdateCode))
                    let attributeKey = getAttributeKey ap.CustomAttributeKey ap.UniqueName

                    w.printfn "                let prev%sOpt = match prevOptDyn with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<%s>(%s)" ap.UniqueName ap.ModelType attributeKey
                    w.printfn "                let curr%sOpt = currDyn.TryGetAttributeKeyed<%s>(%s)" ap.UniqueName ap.ModelType attributeKey
                    w.printfn "                let target = target :?> %s" (Option.defaultValue "MISSING_COLLECTION_ELEMENT_TYPE" p.CollectionDataElementType)

                    if ap.ModelType = "IViewElement" && not hasApply then
                        w.printfn "                match struct (prev%sOpt, curr%sOpt) with" ap.UniqueName ap.UniqueName
                        w.printfn "                // For structured objects, dependsOn on reference equality"
                        w.printfn "                | struct (ValueSome prevValue, ValueSome newValue) when identical prevValue newValue -> ()"
                        w.printfn "                | struct (ValueSome prevValue, ValueSome newValue) when definition.canReuseView prevValue newValue ->"
                        w.printfn "                    newValue.Update(definition, ValueSome prevValue, (%s.Get%s(target)))" data.FullName ap.Name
                        w.printfn "                | struct (_, ValueSome newValue) ->"
                        w.printfn "                    %s.Set%s(target, (newValue.Create(definition, ValueSome (box target)) :?> %s))" data.FullName ap.Name ap.OriginalType
                        w.printfn "                | struct (ValueSome _, ValueNone) ->"
                        w.printfn "                    %s.Set%s(target, null)" data.FullName ap.Name
                        w.printfn "                | struct (ValueNone, ValueNone) -> ()"

                    elif not (System.String.IsNullOrWhiteSpace(ap.UpdateCode)) then
                        w.printfn "            %s prev%sOpt curr%sOpt targetChild" ap.UpdateCode ap.UniqueName ap.UniqueName
                        
                    else
                        w.printfn "                match struct (prev%sOpt, curr%sOpt) with" ap.UniqueName ap.UniqueName
                        w.printfn "                | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()"
                        w.printfn "                | struct (_, ValueSome currValue) -> target.SetValue(%s.%sProperty, %s currValue)" data.FullName ap.Name ap.ConvertModelToValue
                        w.printfn "                | struct (ValueSome _, ValueNone) -> target.ClearValue(%s.%sProperty)" data.FullName ap.Name
                        w.printfn "                | _ -> ()"

                printUpdateBaseIfNeeded "                " false

            w.printfn "            | _ ->"
            printUpdateBaseIfNeeded "                " true

            w.printfn "        else"
            printUpdateBaseIfNeeded "            " true

        w.printfn ""
        w


    let generateUpdateFunction (data: UpdateData) (w: StringWriter) =
        let generateProperties (properties: UpdateProperty array) =
            for p in properties do
                let hasApply = not (System.String.IsNullOrWhiteSpace(p.ConvertModelToValue)) || not (System.String.IsNullOrWhiteSpace(p.UpdateCode))
                let attributeKey = getAttributeKey p.CustomAttributeKey p.UniqueName

                // Check if the property is a collection
                match p.CollectionDataElementType with
                | Some collectionDataElementType when not hasApply ->
                    w.printfn "        Collections.updateChildren definition prev%sOpt curr%sOpt target.%s" p.UniqueName p.UniqueName p.Name
                    w.printfn "            (fun definition parentOpt x -> x.Create(definition, parentOpt) :?> %s)" collectionDataElementType
                    w.printfn "            Collections.updateChild"
                    w.printfn "            (fun definition prevChildOpt currChild targetChild -> curr.UpdateAttachedPropertiesForAttribute(%s, definition, prevChildOpt, currChild, targetChild))" attributeKey

                | Some _ when hasApply ->
                    w.printfn "        %s definition prev%sOpt curr%sOpt target" p.UpdateCode p.UniqueName p.UniqueName
                    w.printfn "            (fun definition prevChildOpt currChild targetChild -> curr.UpdateAttachedPropertiesForAttribute(%s, definition, prevChildOpt, currChild, targetChild))" attributeKey

                | _ ->
                    // If the type is ViewElement, then it's a type from the model
                    // Issue recursive calls to "Create" and "UpdateIncremental"
                    if p.ModelType = "IViewElement" && not hasApply then
                        w.printfn "        match struct (prev%sOpt, curr%sOpt) with" p.UniqueName p.UniqueName
                        w.printfn "        // For structured objects, dependsOn on reference equality"
                        w.printfn "        | struct (ValueSome prevValue, ValueSome newValue) when identical prevValue newValue -> ()"
                        w.printfn "        | struct (ValueSome prevValue, ValueSome newValue) when definition.canReuseView prevValue newValue ->"
                        w.printfn "            newValue.Update(definition, ValueSome prevValue, target.%s)" p.Name
                        w.printfn "        | struct (_, ValueSome newValue) ->"
                        w.printfn "            target.%s <- (newValue.Create(definition, ValueSome (box target)) :?> %s)" p.Name p.OriginalType
                        w.printfn "        | struct (ValueSome _, ValueNone) ->"
                        w.printfn "            target.%s <- null"  p.Name
                        w.printfn "        | struct (ValueNone, ValueNone) -> ()"

                    // Explicit update code
                    elif not (System.String.IsNullOrWhiteSpace(p.UpdateCode)) then
                        w.printfn "        %s definition prev%sOpt curr%sOpt target" p.UpdateCode p.UniqueName p.UniqueName

                    else
                        w.printfn "        match struct (prev%sOpt, curr%sOpt) with" p.UniqueName p.UniqueName
                        w.printfn "        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()"
                        w.printfn "        | struct (_, ValueSome currValue) -> target.%s <- %s currValue" p.Name p.ConvertModelToValue
                        if p.DefaultValue = "" then
                            w.printfn "        | struct (ValueSome _, ValueNone) -> target.ClearValue %s.%sProperty" data.FullName p.Name
                        else
                            w.printfn "        | struct (ValueSome _, ValueNone) -> target.%s <- %s" p.Name p.DefaultValue
                        w.printfn "        | struct (ValueNone, ValueNone) -> ()"

        w.printfn "    static member Update%s (definition: ProgramDefinition, prevOpt: DynamicViewElement voption, curr: DynamicViewElement, target: %s) = " data.Name data.FullName

        if (data.ImmediateMembers.Length = 0) then
            if (data.BaseName.IsNone) then
                w.printfn "        ()"
            else
                w.printfn "        ViewBuilders.Update%s(definition, prevOpt, curr, target)" data.BaseName.Value
        else
            if data.ImmediateMembers.Length > 0 then
                for m in data.ImmediateMembers do
                    w.printfn "        let mutable prev%sOpt = ValueNone" m.UniqueName
                    w.printfn "        let mutable curr%sOpt = ValueNone" m.UniqueName
                w.printfn "        for kvp in curr.Attributes do"
                for m in data.ImmediateMembers do
                    let attributeKey = getAttributeKey m.CustomAttributeKey m.UniqueName
                    w.printfn "            if kvp.Key = %s.KeyValue then " attributeKey
                    w.printfn "                curr%sOpt <- ValueSome (kvp.Value :?> %s)" m.UniqueName m.ModelType
                w.printfn "        match prevOpt with"
                w.printfn "        | ValueNone -> ()"
                w.printfn "        | ValueSome prev ->"
                w.printfn "            for kvp in prev.Attributes do"
                for m in data.ImmediateMembers do
                    let attributeKey = getAttributeKey m.CustomAttributeKey m.UniqueName
                    w.printfn "                if kvp.Key = %s.KeyValue then " attributeKey
                    w.printfn "                    prev%sOpt <- ValueSome (kvp.Value :?> %s)" m.UniqueName m.ModelType

            // Unsubscribe previous event handlers
            if data.Events.Length > 0 then
                w.printfn "        // Unsubscribe previous event handlers"
                for e in data.Events do
                    let relatedProperties =
                        e.RelatedProperties
                        |> Array.map (fun p -> sprintf "(identicalVOption prev%sOpt curr%sOpt)" p p)
                        |> Array.fold (fun a b -> a + " && " + b) ""

                    w.printfn "        let shouldUpdate%s = not ((identicalVOption prev%sOpt curr%sOpt)%s)" e.UniqueName e.UniqueName e.UniqueName relatedProperties
                    w.printfn "        if shouldUpdate%s then" e.UniqueName
                    w.printfn "            match prev%sOpt with" e.UniqueName
                    w.printfn "            | ValueSome prevValue -> target.%s.RemoveHandler(prevValue)" e.Name
                    w.printfn "            | ValueNone -> ()"

            // Update priority properties
            if data.PriorityProperties.Length > 0 then
                w.printfn "        // Update priority properties"
                generateProperties data.PriorityProperties

            // Update inherited members
            if data.BaseName.IsSome then
                w.printfn "        // Update inherited members"
                w.printfn "        ViewBuilders.Update%s(definition, prevOpt, curr, target)" data.BaseName.Value

            // Update properties
            if data.Properties.Length > 0 then
                w.printfn "        // Update properties"
                generateProperties data.Properties

            // Subscribe event handlers
            if data.Events.Length > 0 then
                w.printfn "        // Subscribe new event handlers"
                for e in data.Events do
                    w.printfn "        if shouldUpdate%s then" e.UniqueName
                    w.printfn "            match curr%sOpt with" e.UniqueName
                    w.printfn "            | ValueSome currValue -> target.%s.AddHandler(currValue)" e.Name
                    w.printfn "            | ValueNone -> ()"

        w.printfn ""
        w
        
    let generateUnmountFunction (data: UnmountData) (w: StringWriter) =
        w.printfn "    static member Unmount%s (curr: DynamicViewElement, target: %s) =" data.Name data.FullName
        
        // Update inherited members
        if data.BaseName.IsSome then
            w.printfn "        // Unmount inherited members"
            w.printfn "        ViewBuilders.Unmount%s(curr, target)" data.BaseName.Value
            
        if data.Properties.Length = 0 then
            w.printfn "        ()"
        else
            w.printfn "        // Unmount direct members"
            for p in data.Properties do
                let attributeKey = getAttributeKey p.CustomAttributeKey p.UniqueName
                
                w.printfn "        let curr%sOpt = curr.TryGetAttributeKeyed(%s)" p.UniqueName attributeKey
                
                match p.IsCollection, p.HasApply with
                | _, true ->
                    w.printfn "        ()"
                | true, false ->
                    w.printfn "        Collections.unmountChildren curr%sOpt target.%s" p.UniqueName p.Name
                | false, false ->
                    w.printfn "        match curr%sOpt with ValueNone -> () | ValueSome viewElement -> viewElement.Unmount(target)" p.UniqueName
            
        w.printfn ""
        w

    let generateConstruct (data: ConstructData option) (w: StringWriter) =
        match data with
        | None -> ()
        | Some data ->
            let memberNewLine = "\n                                  " + String.replicate data.Name.Length " " + " "
            let space = "\n                               "
            let membersForConstructor =
                data.Members
                |> Array.mapi (fun i m ->
                    let commaSpace = if i = 0 then "" else "," + memberNewLine
                    match m.Name with
                    | "created" -> sprintf "%s?%s: (%s -> unit)" commaSpace m.Name data.FullName
                    | "ref" ->     sprintf "%s?%s: ViewRef<%s>" commaSpace m.Name data.FullName
                    | _ ->         sprintf "%s?%s: %s" commaSpace m.Name m.InputType)
                |> Array.fold (+) ""
            let membersForBuild =
                data.Members
                |> Array.mapi (fun i m ->
                    let commaSpace = if i = 0 then space else "," + space
                    match m.Name with
                    | "created" -> sprintf "%s?%s=(match %s with None -> None | Some createdFunc -> Some (fun (target: obj) -> createdFunc (unbox<%s> target)))" commaSpace m.Name m.Name data.FullName
                    | "ref" ->     sprintf "%s?%s=(match %s with None -> None | Some (ref: ViewRef<%s>) -> Some ref.Unbox)" commaSpace m.Name m.Name data.FullName
                    | _ ->         sprintf "%s?%s=%s" commaSpace m.Name m.Name)
                |> Array.fold (+) ""

            w.printfn "    static member inline Construct%s(%s) = " data.Name membersForConstructor
            w.printfn ""
            w.printfn "        let attribBuilder = ViewBuilders.Build%s(%s)" data.Name membersForBuild
            w.printfn ""
            w.printfn "        let handler ="
            w.printfn "            Registrar.Register("
            w.printfn "                \"%s\"," data.FullName
            w.printfn "                (fun curr parentOpt -> ViewBuilders.Create%s(curr, parentOpt))," data.Name
            w.printfn "                (fun def prev curr target -> ViewBuilders.Update%s(def, prev, curr, target))," data.Name
            w.printfn "                (fun key def prev curr target -> ViewBuilders.Update%sAttachedProperties(key, def, prev, curr, target))," data.Name
            w.printfn "                (fun curr target -> ViewBuilders.Unmount%s(curr, target))" data.Name
            w.printfn "            )"
            w.printfn ""
            w.printfn "        DynamicViewElement.Create(handler, attribBuilder)"
            w.printfn ""


    let generateBuilders (data: BuilderData array) (w: StringWriter) =
        w.printfn "type ViewBuilders() ="
        for typ in data do
            w
            |> generateBuildFunction typ.Build
            |> generateCreateFunction typ.Create
            |> generateUpdateAttachedPropertiesFunction typ.UpdateAttachedProperties
            |> generateUpdateFunction typ.Update
            |> generateUnmountFunction typ.Unmount
            |> generateConstruct typ.Construct
        w

    let generateViewers (data: ViewerData array) (w: StringWriter) =
        for typ in data do
            let genericConstraint =
                match typ.GenericConstraint with
                | None -> ""
                | Some constr -> sprintf "<%s>" constr

            w.printfn "/// Viewer that allows to read the properties of a DynamicViewElement representing a %s" typ.Name
            w.printfn "type %s%s(element: DynamicViewElement) =" typ.ViewerName genericConstraint

            match typ.InheritedViewerName with
            | None -> ()
            | Some inheritedViewerName ->
                let inheritedGenericConstraint =
                    match typ.InheritedGenericConstraint with
                    | None -> ""
                    | Some constr -> sprintf "<%s>" constr

                w.printfn "    inherit %s%s(element)" inheritedViewerName inheritedGenericConstraint

            w.printfn "    do if not ((typeof<%s>).IsAssignableFrom(element.TargetType)) then failwithf \"A DynamicViewElement assignable to type '%s' is expected, but '%%s' was provided.\" element.TargetType.FullName" typ.FullName typ.FullName
            for m in typ.Members do
                match m.Name with
                | "Created" | "Ref" -> ()
                | _ ->
                    let attributeKey = getAttributeKey m.CustomAttributeKey m.UniqueName
                    w.printfn "    /// Get the value of the %s member" m.Name
                    w.printfn "    member this.%s = element.GetAttributeKeyed(%s)" m.Name attributeKey
            w.printfn ""
        w

    let generateConstructors (data: ConstructorData array) (w: StringWriter) =
        w.printfn "[<AbstractClass; Sealed>]"
        w.printfn "type View private () ="

        for d in data do
            let memberNewLine = "\n                         " + String.replicate d.Name.Length " " + " "
            let space = "\n                               "
            let membersForConstructor =
                d.Members
                |> Array.mapi (fun i m ->
                    let commaSpace = if i = 0 then "" else "," + memberNewLine
                    match m.Name with
                    | "created" -> sprintf "%s?%s: (%s -> unit)" commaSpace m.Name d.FullName
                    | "ref" ->     sprintf "%s?%s: ViewRef<%s>" commaSpace m.Name d.FullName
                    | _ ->         sprintf "%s?%s: %s" commaSpace m.Name m.InputType)
                |> Array.fold (+) ""
            let membersForConstruct =
                d.Members
                |> Array.mapi (fun i m ->
                    let commaSpace = if i = 0 then "" else "," + space
                    sprintf "%s?%s=%s" commaSpace m.Name m.Name)
                |> Array.fold (+) ""

            w.printfn "    /// Describes a %s in the view" d.Name
            w.printfn "    static member inline %s(%s) =" d.Name membersForConstructor
            w.printfn ""
            w.printfn "        ViewBuilders.Construct%s(%s)" d.Name membersForConstruct
            w.printfn ""
        w.printfn ""
        w

    let generateViewExtensions (data: ViewExtensionsData array) (w: StringWriter) : StringWriter =
        let newLine = "\n                                       "

        w.printfn "[<AutoOpen>]"
        w.printfn "module DynamicViewElementExtensions = "
        w.printfn ""
        w.printfn "    type DynamicViewElement with"

        for m in data do
            match m.UniqueName with
            | "Created" | "Ref" -> ()
            | _ ->
                let attributeKey = getAttributeKey m.CustomAttributeKey m.UniqueName
                w.printfn ""
                w.printfn "        /// Adjusts the %s property in the visual element" m.UniqueName
                w.printfn "        member x.%s(value: %s) = x.WithAttribute(%s, %s(value))" m.UniqueName m.InputType attributeKey m.ConvertInputToModel

        let members =
            data
            |> Array.filter (fun m -> m.UniqueName <> "Created" && m.UniqueName <> "Ref")
            |> Array.mapi (fun index m -> sprintf "%s%s?%s: %s" (if index > 0 then ", " else "") (if index > 0 && index % 5 = 0 then newLine else "") m.LowerUniqueName m.InputType)
            |> Array.fold (+) ""

        w.printfn ""
        w.printfn "        member inline viewElement.With(%s) =" members
        for m in data do
            match m.UniqueName with
            | "Created" | "Ref" -> ()
            | _ -> w.printfn "            let viewElement = match %s with None -> viewElement | Some opt -> viewElement.%s(opt)" m.LowerUniqueName m.UniqueName
        w.printfn "            viewElement"
        w.printfn ""

        for m in data do
            match m.UniqueName with
            | "Created" | "Ref" -> ()
            | _ ->
                w.printfn "    /// Adjusts the %s property in the visual element" m.UniqueName
                w.printfn "    let %s (value: %s) (x: DynamicViewElement) = x.%s(value)" m.LowerUniqueName m.InputType m.UniqueName
        w

    let generate data =
        let toString (w: StringWriter) = w.ToString()
        use writer = new StringWriter()

        writer
        |> generateNamespace data.Namespace data.AdditionalNamespaces
        |> generateAttributes data.Attributes
        |> generateBuilders data.Builders
        |> generateViewers data.Viewers
        |> generateConstructors data.Constructors
        |> generateViewExtensions data.ViewExtensions
        |> toString

    let generateCode
        (prepareData: BoundModel -> GeneratorData)
        (generate: GeneratorData -> string)
        (bindings: BoundModel) : WorkflowResult<string> =

        bindings
        |> prepareData
        |> generate
        |> WorkflowResult.ok
