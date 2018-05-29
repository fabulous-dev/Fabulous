// dotnet build Generator\Generator.fsproj && dotnet  Generator\bin\Debug\netcoreapp2.0\Generator.dll Generator\bindings.json Elmish.XamarinForms\DynamicXaml.fs && fsc -a -r:packages\androidapp\Xamarin.Forms\lib\netstandard1.0\Xamarin.Forms.Core.dll Elmish.XamarinForms\XamlElement.fs Elmish.XamarinForms\DynamicXamlConverters.fs Elmish.XamarinForms\DynamicXaml.fs

module Generator

open System
open System.Collections.Generic
open System.IO
open System.Linq
open Mono.Cecil
open Newtonsoft.Json

type MemberBinding() =
    /// The name of the property in the target
    member val Name : string = null with get, set
        
    /// A unique name of the property in the model
    member val UniqueName : string = null with get, set

    /// Indicates if the "property" is actually passed as a fixed parameter to the constructor
    member val IsParam : bool = false with get, set

    /// The bound name of the type of the parameter if it is an element requiring creation
    member val ParamTypeBoundName : string = null with get, set

    /// The lowercase name used as a parameter in the API
    member val ShortName : string = null with get, set
        
    /// The input type type of the property as seen in the API
    member val InputType : string = null with get, set 

    /// The default value when applying to the target
    member val DefaultValue : string = null with get, set

    /// The function used to compute equality between previous and subsequent values
    member val Equality : string = null with get, set

    /// Converts the input type to the model type
    member val ConvToModel : string = null with get, set

    /// The expression to convert the model type to the value to be assigned to the property in the target
    member val ConvToValue : string = null with get, set

    /// The full code for incrementally assigning to the property in the target
    member val UpdateCode : string = null with get, set

    /// The type as stored in the model
    /// 
    member val ModelType : string = null with get, set 

    /// The element type of the collection property
    member val ElementType : string = null with get, set

    /// The attached properties for items in the collection property
    member val Attached : List<MemberBinding> = null with get, set

    // Output
    member val Definition : MemberReference = null with get, set

    member this.BoundType : TypeReference  = 
        match this.Definition with 
        | :? PropertyDefinition as p -> p.PropertyType
        | :? EventDefinition as e ->  e.EventType
        | _ -> null

    member this.BoundUniqueName : string = if String.IsNullOrEmpty(this.UniqueName) then this.Name else this.UniqueName

    member this.LowerBoundUniqueName : string = string (Char.ToLowerInvariant (this.BoundUniqueName.[0])) + this.BoundUniqueName.Substring (1)

    member this.BoundShortName : string = if String.IsNullOrEmpty(this.ShortName) then this.Name else this.ShortName

    member this.LowerBoundShortName : string = string (Char.ToLowerInvariant(this.BoundShortName.[0])) + this.BoundShortName.Substring(1)


type TypeBinding() = 
    // Input
    member val  Name : string = null with get, set

    member val  ModelName : string = null with get, set

    member val  CustomType : string = null with get, set

    member val  Members: List<MemberBinding> = null with get, set

    // Output
    member val BoundCode : string = null with get, set 

    member val Definition : TypeDefinition = null with get, set 

    member __.BoundName = "XamlElement" // Definition.Name + "Description"


type Bindings() = 
    // Input
    member val  Assemblies : List<string> = null with get, set 

    member val  Types : List<TypeBinding> = null with get, set 

    member val  OutputNamespace : string = null with get, set 

    member val  AssemblyDefinitions : List<AssemblyDefinition> = null with get, set 

    member this.GetTypeDefinition(name: string) =
        seq { for a in this.AssemblyDefinitions do
                for m in a.Modules do
                  for tdef in m.Types do
                    if tdef.FullName = name then
                        yield tdef }
        |> Seq.tryHead

    member this.FindType (name: string) = this.Types |> Seq.tryFind (fun x -> x.Name = name)

type TextWriter with 
    member this.printf fmt = fprintf this fmt
    member this.printfn fmt = fprintfn this fmt

let rec ResolveGenericParameter (tref: TypeReference, hierarchy: seq<TypeReference * TypeDefinition>) : TypeReference option =
    if (tref = null) then
        None
    elif not (tref.IsGenericParameter) then
        Some tref
    else
        seq { 
            for (b, tdef) in hierarchy do 
               if b.IsGenericInstance then 
                 let ps = tdef.GenericParameters 
                 match ps |> Seq.tryFind (fun x -> x.Name = tref.Name) with 
                 | Some p -> 
                     let pi = ps.IndexOf(p)
                     let args = (b :?> GenericInstanceType).GenericArguments
                     match ResolveGenericParameter (args.[pi], hierarchy) with
                     | Some res -> yield res
                     | None -> 
                          ()
                 | None -> 
                     ()
        } 
        |> Seq.tryHead

type MemberBinding with
    member this.GetInputType(bindings: Bindings, hierarchy: seq<TypeReference * TypeDefinition>) =
        if not (String.IsNullOrWhiteSpace(this.InputType)) then
            this.InputType
        else 
            this.GetModelType(bindings, hierarchy)

    member this.GetModelType(bindings: Bindings, hierarchy: seq<TypeReference * TypeDefinition>) =
        if not (String.IsNullOrWhiteSpace(this.ModelType)) then
            this.ModelType
        elif (this.BoundType = null) then
            failwithf "no type for %s" this.Name
        else
            this.GetModelTypeInner(bindings, this.BoundType, hierarchy)

    member this.GetModelTypeInner(bindings:Bindings, tref:TypeReference, hierarchy: seq<TypeReference * TypeDefinition>) =
        match tref with 
        | _ when tref.IsGenericParameter ->
            if hierarchy <> null then 
                match ResolveGenericParameter(tref, hierarchy) with 
                | Some r -> this.GetModelTypeInner(bindings, r, hierarchy)
                | None -> "XamlElement"
            else
                "XamlElement"

        | _ when tref.IsGenericInstance ->
            let (ns,n) = 
                let n = tref.Name.Substring(0, tref.Name.IndexOf('`'))
                if (tref.IsNested) then
                    let n = tref.DeclaringType.Name + "." + n
                    let ns = tref.DeclaringType.Namespace
                    ns, n
                else
                    let ns = tref.Namespace
                    ns, n
            let args = String.Join(", ", (tref :?> GenericInstanceType).GenericArguments.Select(fun s -> this.GetModelTypeInner(bindings, s, hierarchy)))
            sprintf "%s.%s<%s>" ns n args

        | _ -> 
            match tref.FullName with 
            | "System.String" -> "string"
            | "System.Boolean" -> "bool"
            | "System.Int32" -> "int"
            | "System.Double" -> "double"
            | "System.Single" -> "single"
            | _ -> 
                    match (bindings.Types |> Seq.tryFind (fun x -> x.Name = tref.FullName)) with
                    | None -> tref.FullName.Replace('/', '.')
                    | Some tb -> tb.BoundName

    member this.GetElementType(hierarchy: seq<TypeReference * TypeDefinition>) =
        if not (String.IsNullOrWhiteSpace(this.ElementType)) then
            Some this.ElementType
        else
            this.GetElementTypeInner(this.BoundType, hierarchy)

    member this.GetElementTypeInner(tref: TypeReference, hierarchy: seq<TypeReference * TypeDefinition>) =
        match ResolveGenericParameter(tref, hierarchy) with 
        | None -> 
            None
        | Some r -> 
            if (r.FullName = "System.String") then
                None
            elif (r.Name = "IList`1" && r.IsGenericInstance) then
                let args = (r :?> GenericInstanceType).GenericArguments
                match ResolveGenericParameter(args.[0], hierarchy) with 
                | None -> 
                    None
                | Some elementType -> 
                    Some elementType.Name
            else
                let bs = r.Resolve().Interfaces
                bs |> Seq.tryPick (fun b -> this.GetElementTypeInner(b.InterfaceType, hierarchy))


let GetHierarchy (typ: TypeDefinition ) : seq<TypeReference * TypeDefinition> =
    seq {
        let mutable d = typ
        yield (d :> TypeReference, d)
        while (d.BaseType <> null) do
            let r = d.BaseType
            d <- r.Resolve()
            yield (r, d)
     }

let FindProperty(name: string, typ: TypeDefinition) : PropertyDefinition option =
    let q =
        seq { 
            for (_,tdef) in GetHierarchy(typ) do
              for p in tdef.Properties do
                 if p.Name = name then
                     yield p }
    q |> Seq.tryHead

let FindEvent(name: string , typ: TypeDefinition) : EventDefinition option =
    let q =
        seq { 
            for (_,tdef) in GetHierarchy(typ) do
              for p in tdef.Events do
                 if p.Name = name then
                     yield p }
    q |> Seq.tryHead

let BindTypes (bindings: Bindings) =
    let w = new StringWriter()
    let mutable head = "" // TODO: remove this horror

    w.printfn "namespace rec %s " bindings.OutputNamespace
    w.printfn ""
    w.printfn "#nowarn \"67\" // cast always holds"
    w.printfn ""

    w.printfn "[<AutoOpen>]"
    w.printfn "module XamlElementExtensions = "
    w.printfn ""
    w.printfn "    type XamlElement with"
    for typ in bindings.Types do
        let tdef = typ.Definition
        let hierarchy = GetHierarchy(typ.Definition).ToList()
        let ctor = 
            tdef.Methods |> Seq.filter (fun x -> x.IsConstructor && x.IsPublic) |> Seq.sortBy (fun x -> x.Parameters.Count) |> Seq.tryHead

        w.printfn ""
        if (String.IsNullOrWhiteSpace(typ.ModelName)) then
            w.printfn "        /// Create a %s from the view description" tdef.FullName
            w.printfn "        member internal x.CreateAs%s() : %s =" tdef.Name tdef.FullName
            w.printfn "            match x.Create() with"
            w.printfn "            | :? %s as res -> res" tdef.FullName
            w.printfn "            | obj -> failwithf \"Incorrect element type in view (expected a '%s' but got a '%%s')\" (obj.GetType().ToString()) " tdef.FullName
    let allMembersInAllTypes = new List<MemberBinding>()
    for typ in bindings.Types do
        if (typ.Members <> null) then
            for y in typ.Members do
                allMembersInAllTypes.Add(y)
                if (y.Attached <> null) then
                    for ap in y.Attached do
                        allMembersInAllTypes.Add(ap)

    let allMembersInAllTypesGroupedByName = allMembersInAllTypes.GroupBy(fun y -> y.BoundUniqueName)
    for ms in allMembersInAllTypesGroupedByName do
        let m = ms.First()
        if not (m.IsParam) then
            w.printfn ""
            w.printfn "        /// Try to get the %s property in the visual element" m.BoundUniqueName
            let modelType = m.GetModelType(bindings, null)
            w.printfn "%s" ("        member internal x.Try" + m.BoundUniqueName + " = match x.Attributes.TryFind(\"" + m.BoundUniqueName + "\") with Some v -> ValueSome(unbox<" + modelType + ">(v)) | None -> ValueNone")

    for ms in allMembersInAllTypesGroupedByName do
        let m = ms.First()
        if not (m.IsParam) then
            w.printfn ""
            w.printfn "        /// Adjusts the %s property in the visual element" m.BoundUniqueName
            let conv = if String.IsNullOrWhiteSpace(m.ConvToModel) then "" else m.ConvToModel
            let inputType = m.GetInputType(bindings, null)
            w.printfn "%s" ("        member x." + m.BoundUniqueName + "(value: " + inputType + ") = x.WithAttribute(\"" + m.BoundUniqueName + "\", box (" + conv + "(value)))")

    w.printfn ""
    for ms in allMembersInAllTypesGroupedByName do
        let m = ms.First()
        if not (m.IsParam) then
            let inputType = m.GetInputType(bindings, null)
            //w.printfn ""
            //w.printfn "    /// Adjusts the %s property in the visual element")
            //w.printfn ("    let with" + m.BoundUniqueName + " (value: " + inputType + ") (x: XamlElement) = x." + m.BoundUniqueName + "(value)")
            w.printfn ""
            w.printfn "    /// Adjusts the %s property in the visual element" m.BoundUniqueName
            w.printfn "%s" ("    let " + m.LowerBoundUniqueName + " (value: " + inputType + ") (x: XamlElement) = x." + m.BoundUniqueName + "(value)")

    w.printfn ""
    w.printfn "type Xaml() ="
    for typ in bindings.Types do
        let tdef = typ.Definition
        let nameOfCreator = if String.IsNullOrWhiteSpace(typ.ModelName) then tdef.Name else typ.ModelName
        let customTypeToCreate = if String.IsNullOrWhiteSpace(typ.CustomType) then tdef.FullName else typ.CustomType
        let hierarchy = GetHierarchy(typ.Definition).ToList()
        let boundHierarchy = 
            hierarchy |> Seq.choose (fun (_,x) -> bindings.Types |> Seq.tryFind (fun y -> y.Name = x.FullName)) |> Seq.toArray

        let baseTypeOpt = if boundHierarchy.Length > 1 then Some boundHierarchy.[1] else None

        // All properties and events apart from the attached ones
        let allBaseMembers = boundHierarchy |> Seq.skip(1) |> Seq.collect (fun x -> x.Members) |> Seq.toArray
        let allImmediateMembers = typ.Members.ToList()
        let allMembers = allImmediateMembers.Concat(allBaseMembers)

        let ctor = 
            tdef.Methods
             .Where(fun x -> x.IsConstructor && x.IsPublic)
             .OrderBy(fun x -> x.Parameters.Count)
             .FirstOrDefault()

        let hasCreate = (tdef.IsAbstract || ctor = null || ctor.Parameters.Count > 0)

        // Emit the constructor
        w.printfn ""
        w.printfn "    /// Describes a %s in the view" nameOfCreator
        let qual = if hasCreate then "internal " else ""
        w.printf "    static member %s%s(" qual nameOfCreator
        head <- ""
        for m in allMembers do
            let inputType = m.GetInputType(bindings, null)

            w.printf "%s?%s: %s" head m.LowerBoundShortName inputType
            head <- ", "

        w.printfn ") = "
        match baseTypeOpt with 
        | None -> ()
        | Some baseType ->
            let nameOfBaseCreator = if String.IsNullOrWhiteSpace(baseType.ModelName) then baseType.Definition.Name else baseType.ModelName
            w.printf "        let baseElement : XamlElement = Xaml.%s(" nameOfBaseCreator
            head <- ""
            for m in allBaseMembers do
                let inputType = m.GetInputType(bindings, null)

                w.printf "%s?%s=%s" head m.LowerBoundShortName m.LowerBoundShortName
                head <- ", "
            w.printfn ")"

        w.printfn "        let attribs = [| "
        match baseTypeOpt with 
        | None -> ()
        | Some baseType ->
            w.printfn ("            yield! baseElement.AttributesArray")

        for m in allImmediateMembers do
            let conv = if String.IsNullOrWhiteSpace(m.ConvToModel) then "" else m.ConvToModel
            w.printfn "%s" ("            match " + m.LowerBoundShortName + " with None -> () | Some v -> yield (\"" + m.BoundUniqueName + "\"" + sprintf ", box (" + conv + "(v))) ")

        w.printfn "          |]"

        w.printfn ""
        w.printfn "        let create () ="
        if not (hasCreate) then
            if (allMembers.Any(fun m -> m.IsParam)) then
                w.printf "            match "
                head <- ""
                for m in allImmediateMembers do 
                    if (m.IsParam) then
                        w.printf "%s%s" head m.LowerBoundShortName
                        head <- ", "
                w.printfn " with"
                w.printf "            | "
                head <- ""
                for m in allImmediateMembers do
                    if (m.IsParam) then
                        w.printf "%sSome %s" head m.LowerBoundShortName
                        head <- ", "
                w.printfn " ->"
                w.printf "                box (new %s(" customTypeToCreate
                head <- ""
                for m in allImmediateMembers do
                    if (m.IsParam) then
                        let bt = m.ParamTypeBoundName
                        if (bt <> null) then
                            w.printf "%s%s.CreateAs%s()" head m.LowerBoundShortName bt
                        else
                            w.printf "%s%s" head m.LowerBoundShortName
                        head <- ", "
                w.printfn "))"
                w.printf "            | _ -> box (new %s())" customTypeToCreate
            else
                w.printf "            box (new %s())" customTypeToCreate
        else
            w.printfn "            failwith \"can't create %s\"" tdef.FullName
        w.printfn ""
        w.printfn "        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = "

        match baseTypeOpt with 
        | None -> ()
        | Some baseType ->
            w.printfn "            baseElement.UpdateMethod prevOpt source targetObj"

        if (allImmediateMembers.Count = 0) then
            w.printfn "            ()"
        else

            w.printfn "            let target = (targetObj :?> %s)" tdef.FullName
            for m in allImmediateMembers do
                let hasApply = not (String.IsNullOrWhiteSpace(m.ConvToValue)) || not (String.IsNullOrWhiteSpace(m.UpdateCode))

                let bt = ResolveGenericParameter(m.BoundType, hierarchy)
                let elementType = m.GetElementType(hierarchy)

                match m, elementType, bt with 
                | _ when m.IsParam -> ()

                | _, Some elementType, _ when elementType <> "obj" && not hasApply ->
                    w.printfn "            let prevCollOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.Try%s" m.BoundUniqueName
                    w.printfn "            let collOpt = source.Try%s" m.BoundUniqueName
                    w.printfn "            updateIList prevCollOpt collOpt target.%s" m.Name
                    w.printfn "                (fun (x:XamlElement) -> x.CreateAs%s())" elementType
                    if (m.Attached <> null) then
                        w.printfn "                (fun prevChildOpt newChild targetChild -> "
                        for ap in m.Attached do
                            w.printfn "                    // Adjust the attached properties"
                            w.printfn "                    match (match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.Try%s), newChild.Try%s with" ap.BoundUniqueName ap.BoundUniqueName
                            w.printfn "                    | ValueSome prev, ValueSome v when prev = v -> ()"
                            let apApply = if String.IsNullOrWhiteSpace(ap.ConvToValue) then "" else ap.ConvToValue + " "
                            w.printfn "                    | prevOpt, ValueSome value -> %s.Set%s(targetChild, %svalue)" tdef.FullName ap.Name apApply
                            w.printfn "                    | ValueSome _, ValueNone -> %s.Set%s(targetChild, %s) // TODO: not always perfect, should set back to original default?" tdef.FullName ap.Name ap.DefaultValue
                            w.printfn "                    | _ -> ()"
                        w.printfn "                    ())"
                    else
                        w.printfn "                (fun _ _ _ -> ())"
                    w.printfn "                canReuseChild"
                    w.printfn "                updateChild"

                | _, _, Some bt when bindings.FindType(bt.FullName).IsSome && not hasApply ->

                    if (bt.IsValueType) then
                        w.printfn "            let prevChildOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.Try%s" m.BoundUniqueName
                        w.printfn "            match prevChildOpt, source.Try%s with" m.BoundUniqueName
                        w.printfn "            // For structured objects, dependsOn on reference equality"
                        w.printfn "            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()"
                        w.printfn "            | _, ValueSome newChild ->"
                        w.printfn "                target.%s <- newChild.CreateAs%s()" m.Name bt.Name
                        w.printfn "            | ValueSome _, ValueNone ->"
                        w.printfn "                target.%s <- Unchecked.defaultof<_>" m.Name
                        w.printfn "            | ValueNone, ValueNone -> ()"
                    else
                        w.printfn "            let prevChildOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.Try%s" m.BoundUniqueName
                        w.printfn "            match prevChildOpt, source.Try%s with" m.BoundUniqueName
                        w.printfn "            // For structured objects, dependsOn on reference equality"
                        w.printfn "            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()"
                        w.printfn "            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->"
                        w.printfn "                newChild.UpdateIncremental(prevChild, target.%s)" m.Name
                        w.printfn "            | ValueSome _, ValueSome newChild"
                        w.printfn "            | ValueNone, ValueSome newChild ->"
                        w.printfn "                target.%s <- newChild.CreateAs%s()" m.Name bt.Name
                        w.printfn "            | ValueSome _, ValueNone ->"
                        w.printfn "                target.%s <- null"  m.Name
                        w.printfn "            | ValueNone, ValueNone -> ()"

                | _, _, Some bt when (bt.Name.EndsWith("Handler") || bt.Name.EndsWith("Handler`1") || bt.Name.EndsWith("Handler`2")) && not hasApply ->
                    w.printfn "            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.Try%s" m.BoundUniqueName
                    w.printfn "            match prevValueOpt, source.Try%s with" m.BoundUniqueName
                    w.printfn "            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()"
                    w.printfn "            | ValueSome prevValue, ValueSome value -> target.%s.RemoveHandler(prevValue); target.%s.AddHandler(value)" m.Name m.Name
                    w.printfn "            | ValueNone, ValueSome value -> target.%s.AddHandler(value)" m.Name
                    w.printfn "            | ValueSome prevValue, ValueNone -> target.%s.RemoveHandler(prevValue)" m.Name
                    w.printfn "            | ValueNone, ValueNone -> ()"

                | _ -> 
                    w.printfn "            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.Try%s" m.BoundUniqueName
                    w.printfn "            let valueOpt = source.Try%s" m.BoundUniqueName
                    if not (String.IsNullOrWhiteSpace(m.UpdateCode)) then
                        w.printfn "            %s prevValueOpt valueOpt target" m.UpdateCode
                        if (m.Attached <> null) then
                            w.printfn "                (fun prevChildOpt newChild targetChild -> "
                            for ap in m.Attached do
                                w.printfn "                    // Adjust the attached properties"
                                w.printfn "                    match (match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.Try%s), newChild.Try%s with" ap.BoundUniqueName ap.BoundUniqueName
                                w.printfn "                    | ValueSome prev, ValueSome v when prev = v -> ()"
                                let apApply = if String.IsNullOrWhiteSpace(ap.ConvToValue) then "" else ap.ConvToValue + " "
                                w.printfn "                    | prevOpt, ValueSome value -> %s.Set%s(targetChild, %svalue)" tdef.FullName ap.Name apApply
                                w.printfn "                    | ValueSome _, ValueNone -> %s.Set%s(targetChild, %s) // TODO: not always perfect, should set back to original default?" tdef.FullName ap.Name ap.DefaultValue
                                w.printfn "                    | _ -> ()"
                            w.printfn "                    ())"
                    else
                        let update = if String.IsNullOrWhiteSpace(m.ConvToValue) then "" else m.ConvToValue + " "
                        //var equality = String.IsNullOrWhiteSpace(m.Equality) ? "" : m.Equality + " "

                        w.printfn "            match prevValueOpt, valueOpt with"
                        w.printfn "            | ValueSome prevValue, ValueSome value when prevValue = value -> ()"
                        w.printfn "            | prevOpt, ValueSome value -> System.Diagnostics.Debug.WriteLine(\"Setting %s::%s \"); target.%s <- %s value" nameOfCreator m.Name m.Name update
                        w.printfn "            | ValueSome _, ValueNone -> target.%s <- %s"  m.Name m.DefaultValue
                        w.printfn "            | ValueNone, ValueNone -> ()"
                                
        w.printfn "        new XamlElement(typeof<%s>, create, update, attribs)" tdef.FullName

    w.ToString ()


let LoadAssembly (path: string) : AssemblyDefinition  =
        //if (path.StartsWith("packages")) {
        //    let user = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
        //    path = Path.Combine (user, ".nuget", path)
        // }
        AssemblyDefinition.ReadAssembly(path)


[<EntryPoint>]
let Main(args: string[]) =
        try 
            if (args.Length < 2) then
                Console.Error.WriteLine("usage: generator <bindingsPath> <outputPath>")
                Environment.Exit(1)
            let bindingsPath = args.[0]
            let outputPath = args.[1]

            let bindings = JsonConvert.DeserializeObject<Bindings> (File.ReadAllText (bindingsPath))

            bindings.AssemblyDefinitions <- bindings.Assemblies.Select(LoadAssembly).ToList()

            for x in bindings.Types do
                match bindings.GetTypeDefinition (x.Name) with 
                | None -> failwith (sprintf "Could not find type '%s'"  x.Name)
                | Some d -> 
                    x.Definition <- d

            for x in bindings.Types do
                for m in x.Members do
                    match FindProperty (m.Name, x.Definition) with 
                    | Some p -> 
                        m.Definition <- p
                    | None -> 
                    match FindEvent (m.Name, x.Definition) with 
                    | Some e -> 
                        m.Definition <- e
                    | None -> 
                      if (String.IsNullOrWhiteSpace(m.UpdateCode))  then
                        Console.WriteLine(sprintf "Could not find member '%s'")
            let code = BindTypes (bindings)

            File.WriteAllText (outputPath, code)
            0
        with ex -> 
            System.Console.WriteLine(ex)
            1
