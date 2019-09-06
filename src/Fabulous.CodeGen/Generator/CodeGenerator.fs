// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen.Generator

open Fabulous.CodeGen
open Fabulous.CodeGen.Text
open Fabulous.CodeGen.Generator.Models
open System.IO

module CodeGenerator =
    let generateNamespace (namespaceOfGeneratedCode: string) (w: StringWriter) = 
        w.printfn "// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license."
        w.printfn "namespace %s" namespaceOfGeneratedCode
        w.printfn ""
        w.printfn "#nowarn \"59\" // cast always holds"
        w.printfn "#nowarn \"66\" // cast always holds"
        w.printfn "#nowarn \"67\" // cast always holds"
        w.printfn ""
        w.printfn "open Fabulous"
        w.printfn ""
        w

    let generateAttributes (members: string array) (w: StringWriter) =
        w.printfn "module ViewAttributes ="
        for m in members do
            match m with
            | "ElementCreated" ->
                w.printfn "    let ElementCreatedAttribKey : AttributeKey<(obj -> unit)> = AttributeKey<(obj -> unit)>(\"ElementCreated\")"
            | _ ->
                w.printfn "    let %sAttribKey : AttributeKey<_> = AttributeKey<_>(\"%s\")" m m
        w.printfn ""
        w

    let generateBuildFunction (data: BuildData) (w: StringWriter) =
        let memberNewLine = "\n                              " + String.replicate data.Name.Length " " + " "
        let members =
            data.Members
            |> Array.map (fun m -> sprintf ",%s?%s: %s" memberNewLine m.Name m.InputType)
            |> Array.fold (+) ""

        let immediateMembers =
            data.Members
            |> Array.filter (fun m -> not m.IsInherited)

        w.printfn "    /// Builds the attributes for a %s in the view" data.Name
        w.printfn "    static member inline Build%s(attribCount: int%s) = " data.Name members

        if immediateMembers.Length > 0 then
            w.printfn ""
            for m in immediateMembers do
                w.printfn "        let attribCount = match %s with Some _ -> attribCount + 1 | None -> attribCount" m.Name
            w.printfn ""

        match data.BaseName with 
        | None ->
            w.printfn "        let attribBuilder = new AttributesBuilder(attribCount)"
        | Some nameOfBaseCreator ->
            let baseMemberNewLine = "\n                                              " + String.replicate nameOfBaseCreator.Length " " + " "
            let baseMembers =
                data.Members
                |> Array.filter (fun m -> m.IsInherited)
                |> Array.mapi (fun index m -> sprintf ", %s?%s=%s" (if index > 0 && index % 5 = 0 then baseMemberNewLine else "") m.Name m.Name)
                |> Array.fold (+) ""
            w.printfn "        let attribBuilder = ViewBuilders.Build%s(attribCount%s)" nameOfBaseCreator baseMembers

        for m in immediateMembers do
            w.printfn "        match %s with None -> () | Some v -> attribBuilder.Add(ViewAttributes.%sAttribKey, %s(v)) " m.Name m.UniqueName m.ConvertInputToModel 

        w.printfn "        attribBuilder"
        w.printfn ""
        w

    let generateCreateFunction (data: CreateData option) (w: StringWriter) =
        match data with
        | None -> w
        | Some data ->
            w.printfn "    static member val CreateFunc%s : (unit -> %s) = (fun () -> ViewBuilders.Create%s()) with get, set" data.Name data.FullName data.Name
            w.printfn ""
            w.printfn "    static member Create%s () : %s =" data.Name data.FullName
            
            if data.TypeToInstantiate = data.FullName then
                w.printfn "        new %s()" data.TypeToInstantiate
            else
                w.printfn "        upcast (new %s())" data.TypeToInstantiate
            
            w.printfn ""
            w
        
    let generateUpdateFunction (data: UpdateData) (w: StringWriter) =
        w.printfn "    static member val UpdateFunc%s =" data.Name 
        w.printfn "        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: %s) -> ViewBuilders.Update%s (prevOpt, curr, target)) " data.FullName data.Name
        w.printfn ""
        w.printfn "    static member Update%s (prevOpt: ViewElement voption, curr: ViewElement, target: %s) = " data.Name data.FullName

        
        if (data.BaseName.IsNone && data.ImmediateMembers.Length = 0) then
            w.printfn "        ()"
        elif data.BaseName.IsSome then
            w.printfn "        ViewBuilders.Update%s (prevOpt, curr, target)" data.BaseName.Value

        if (data.ImmediateMembers.Length > 0) then
            for m in data.ImmediateMembers do
                w.printfn "        let mutable prev%sOpt = ValueNone" m.UniqueName
                w.printfn "        let mutable curr%sOpt = ValueNone" m.UniqueName
            w.printfn "        for kvp in curr.AttributesKeyed do"
            for m in data.ImmediateMembers do
                w.printfn "            if kvp.Key = ViewAttributes.%sAttribKey.KeyValue then " m.UniqueName
                w.printfn "                curr%sOpt <- ValueSome (kvp.Value :?> %s)" m.UniqueName m.ModelType
            w.printfn "        match prevOpt with"
            w.printfn "        | ValueNone -> ()"
            w.printfn "        | ValueSome prev ->"
            w.printfn "            for kvp in prev.AttributesKeyed do"
            for m in data.ImmediateMembers do
                w.printfn "                if kvp.Key = ViewAttributes.%sAttribKey.KeyValue then " m.UniqueName
                w.printfn "                    prev%sOpt <- ValueSome (kvp.Value :?> %s)" m.UniqueName m.ModelType

            // Unsubscribe previous event handlers
            for e in data.Events do
                let relatedProperties =
                    e.RelatedProperties
                    |> Array.map (fun p -> sprintf "(identical prev%sOpt curr%sOpt)" p p)
                    |> Array.fold (fun a b -> a + " && " + b) ""

                w.printfn "        let shouldUpdate%s = not ((identical prev%sOpt curr%sOpt)%s)" e.UniqueName e.UniqueName e.UniqueName relatedProperties
                w.printfn "        if shouldUpdate%s then" e.UniqueName
                w.printfn "            match prev%sOpt with" e.UniqueName
                w.printfn "            | ValueSome prevValue -> target.%s.RemoveHandler(prevValue)" e.Name
                w.printfn "            | ValueNone -> ()"
            
            // Update properties
            for p in data.Properties do
                let hasApply = not (System.String.IsNullOrWhiteSpace(p.ConvertModelToValue)) || not (System.String.IsNullOrWhiteSpace(p.UpdateCode))

                // Check if the property is a collection
                match p.CollectionData with 
                | Some collectionData when not hasApply ->
                    w.printfn "        ViewUpdaters.updateCollectionGeneric prev%sOpt curr%sOpt target.%s" p.UniqueName p.UniqueName p.Name
                    w.printfn "            (fun (x:ViewElement) -> x.Create() :?> %s)" collectionData.ElementType
                    if (collectionData.AttachedProperties.Length > 0) then
                        w.printfn "            (fun prevChildOpt newChild targetChild -> "
                        w.printfn "                // Adjust the attached properties"
                        for ap in collectionData.AttachedProperties do
                            w.printfn "                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<%s>(ViewAttributes.%sAttribKey)" ap.ModelType ap.UniqueName
                            w.printfn "                let childValueOpt = newChild.TryGetAttributeKeyed<%s>(ViewAttributes.%sAttribKey)" ap.ModelType ap.UniqueName
                            if System.String.IsNullOrWhiteSpace(ap.UpdateCode) then
                                w.printfn "                match prevChildValueOpt, childValueOpt with"
                                w.printfn "                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()"
                                w.printfn "                | _, ValueSome currChildValue -> %s.Set%s(targetChild, %s currChildValue)" data.FullName ap.Name ap.ConvertModelToValue
                                w.printfn "                | ValueSome _, ValueNone -> %s.Set%s(targetChild, %s)" data.FullName ap.Name ap.DefaultValue
                                w.printfn "                | _ -> ()"
                            else
                                w.printfn "                %s prevChildValueOpt childValueOpt targetChild" ap.UpdateCode
                        w.printfn "                ())"
                    else
                        w.printfn "            (fun _ _ _ -> ())"
                    w.printfn "            ViewHelpers.canReuseView"
                    w.printfn "            ViewUpdaters.updateChild"

                | _ ->
                    // If the type is ViewElement, then it's a type from the model
                    // Issue recursive calls to "Create" and "UpdateIncremental"
                    if p.ModelType = "ViewElement" && not hasApply then
                        w.printfn "        match prev%sOpt, curr%sOpt with" p.UniqueName p.UniqueName
                        w.printfn "        // For structured objects, dependsOn on reference equality"
                        w.printfn "        | ValueSome prevValue, ValueSome newValue when identical prevValue newValue -> ()"
                        w.printfn "        | ValueSome prevValue, ValueSome newValue when canReuseView prevValue newValue ->"
                        w.printfn "            newValue.UpdateIncremental(prevValue, target.%s)" p.Name
                        w.printfn "        | _, ValueSome newValue ->"
                        w.printfn "            target.%s <- (newValue.Create() :?> %s)" p.Name p.OriginalType
                        w.printfn "        | ValueSome _, ValueNone ->"
                        w.printfn "            target.%s <- null"  p.Name
                        w.printfn "        | ValueNone, ValueNone -> ()"

                    // Explicit update code
                    elif not (System.String.IsNullOrWhiteSpace(p.UpdateCode)) then
                        w.printfn "        %s prev%sOpt curr%sOpt target" p.UpdateCode p.UniqueName p.UniqueName

                    else
                        w.printfn "        match prev%sOpt, curr%sOpt with" p.UniqueName p.UniqueName
                        w.printfn "        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()"
                        w.printfn "        | _, ValueSome currValue -> target.%s <- %s currValue" p.Name p.ConvertModelToValue
                        w.printfn "        | ValueSome _, ValueNone -> target.%s <- %s"  p.Name p.DefaultValue
                        w.printfn "        | ValueNone, ValueNone -> ()"
            
            // Subscribe event handlers
            for e in data.Events do
                w.printfn "        if shouldUpdate%s then" e.UniqueName
                w.printfn "            match curr%sOpt with" e.UniqueName
                w.printfn "            | ValueSome currValue -> target.%s.AddHandler(currValue)" e.Name
                w.printfn "            | ValueNone -> ()"
                
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
                |> Array.map (fun m ->
                    match m.Name with
                    | "created" -> sprintf ",%s?%s=(match %s with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<%s> target)))" space m.Name m.Name data.FullName
                    | "ref" ->     sprintf ",%s?%s=(match %s with None -> None | Some (ref: ViewRef<%s>) -> Some ref.Unbox)" space m.Name m.Name data.FullName
                    | _ ->         sprintf ",%s?%s=%s" space m.Name m.Name)
                |> Array.fold (+) ""

            w.printfn "    static member inline Construct%s(%s) = " data.Name membersForConstructor
            w.printfn ""
            w.printfn "        let attribBuilder = ViewBuilders.Build%s(0%s)" data.Name membersForBuild
            w.printfn ""
            w.printfn "        ViewElement.Create<%s>(ViewBuilders.CreateFunc%s, ViewBuilders.UpdateFunc%s, attribBuilder)" data.FullName data.Name data.Name
            w.printfn ""


    let generateBuilders (data: BuilderData array) (w: StringWriter) =
        w.printfn "type ViewBuilders() ="
        for typ in data do
            w
            |> generateBuildFunction typ.Build
            |> generateCreateFunction typ.Create
            |> generateUpdateFunction typ.Update
            |> generateConstruct typ.Construct
        w

    let generateViewers (data: ViewerData array) (w: StringWriter) =
        for typ in data do
            w.printfn "/// Viewer that allows to read the properties of a ViewElement representing a %s" typ.Name
            w.printfn "type %sViewer(element: ViewElement) =" typ.Name

            match typ.BaseName with
            | None -> ()
            | Some baseName ->
                w.printfn "    inherit %sViewer(element)" baseName

            w.printfn "    do if not ((typeof<%s>).IsAssignableFrom(element.TargetType)) then failwithf \"A ViewElement assignable to type '%s' is expected, but '%%s' was provided.\" element.TargetType.FullName" typ.FullName typ.FullName
            for m in typ.Members do
                match m.Name with
                | "Created" | "Ref" -> ()
                | _ ->
                    w.printfn "    /// Get the value of the %s member" m.Name
                    w.printfn "    member this.%s = element.GetAttributeKeyed(ViewAttributes.%sAttribKey)" m.Name m.UniqueName
            w.printfn ""
        w

    let generateConstructors (data: ConstructorData array) (w: StringWriter) =
        w.printfn "type View() ="

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
        let newLine = "\n                             "

        w.printfn "[<AutoOpen>]"
        w.printfn "module ViewElementExtensions = "
        w.printfn ""
        w.printfn "    type ViewElement with"

        for m in data do
            match m.UniqueName with
            | "Created" | "Ref" -> ()
            | _ ->
                w.printfn ""
                w.printfn "        /// Adjusts the %s property in the visual element" m.UniqueName
                w.printfn "        member x.%s(value: %s) = x.WithAttribute(ViewAttributes.%sAttribKey, %s(value))" m.UniqueName m.InputType m.UniqueName m.ConvToModel

        let members =
            data
            |> Array.filter (fun m -> m.UniqueName <> "Created" && m.UniqueName <> "Ref")
            |> Array.mapi (fun index m -> sprintf "%s%s?%s: %s" (if index > 0 then ", " else "") (if index > 0 && index % 5 = 0 then newLine else "") m.LowerUniqueName m.InputType)
            |> Array.fold (+) ""

        w.printfn ""
        w.printfn "        member inline x.With(%s) =" members
        for m in data do
            match m.UniqueName with
            | "Created" | "Ref" -> ()
            | _ -> w.printfn "            let x = match %s with None -> x | Some opt -> x.%s(opt)" m.LowerUniqueName m.UniqueName
        w.printfn "            x"
        w.printfn ""

        for m in data do
            match m.UniqueName with
            | "Created" | "Ref" -> ()
            | _ ->
                w.printfn "    /// Adjusts the %s property in the visual element" m.UniqueName
                w.printfn "    let %s (value: %s) (x: ViewElement) = x.%s(value)" m.LowerUniqueName m.InputType m.UniqueName
        w

    let generateCode bindings : WorkflowResult<string> =
        let toString (w: StringWriter) = w.ToString()

        let data = Preparer.prepareData bindings
        use writer = new StringWriter()
        
        let result =
            writer
            |> generateNamespace data.Namespace
            |> generateAttributes data.Attributes
            |> generateBuilders data.Builders
            |> generateViewers data.Viewers
            |> generateConstructors data.Constructors
            |> generateViewExtensions data.ViewExtensions
            |> toString
            
        WorkflowResult.ok result
