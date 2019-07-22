#r "/Users/timothelariviere/.nuget/packages/mono.cecil/0.10.4/lib/netstandard1.3/Mono.Cecil.dll"
#r "/Users/timothelariviere/.nuget/packages/mono.cecil/0.10.4/lib/netstandard1.3/Mono.Cecil.Mdb.dll"
#r "/Users/timothelariviere/.nuget/packages/mono.cecil/0.10.4/lib/netstandard1.3/Mono.Cecil.Pdb.dll"
#r "/Users/timothelariviere/.nuget/packages/mono.cecil/0.10.4/lib/netstandard1.3/Mono.Cecil.Rocks.dll"

type RegistrableResolver() =
    inherit Mono.Cecil.BaseAssemblyResolver()
    let cache = System.Collections.Generic.Dictionary<string, Mono.Cecil.AssemblyDefinition>()

    override this.Resolve(name) =
        match cache.TryGetValue(name.FullName) with
        | true, assembly -> assembly
        | false, _ ->
            let assembly = base.Resolve(name)
            cache.[name.FullName] <- assembly
            assembly

    member this.RegisterAssembly(assembly : Mono.Cecil.AssemblyDefinition) : unit =
        match cache.ContainsKey(assembly.Name.FullName) with
        | true -> ()
        | false -> cache.[assembly.Name.FullName] <- assembly

    member this.Dispose(disposing) =
        cache.Values |> Seq.iter (fun asm -> asm.Dispose())
        cache.Clear()
        base.Dispose()

let loadAssembly (resolver : RegistrableResolver) (path : string) =
    let readerParameters = Mono.Cecil.ReaderParameters()
    readerParameters.AssemblyResolver <- resolver
    let assembly = Mono.Cecil.AssemblyDefinition.ReadAssembly(path, readerParameters)
    resolver.RegisterAssembly assembly
    assembly

let rec filterTypesDerivingFromBaseType (allTypes: Mono.Cecil.TypeDefinition list) baseTypeName =
    allTypes |> List.filter (fun tdef -> tdef.BaseType <> null && tdef.BaseType.FullName = baseTypeName)
    
and findAllDerivingTypes (allTypes: Mono.Cecil.TypeDefinition list) (typesToCheck: Mono.Cecil.TypeDefinition list) (matchingTypes: Mono.Cecil.TypeDefinition list) =
    match typesToCheck with
    | [] -> matchingTypes
    | tdef::remainingTypesToCheck ->
        let derivingTypes = getAllTypesDerivingFrom allTypes tdef.FullName
        let newMatchingTypes = List.concat [ derivingTypes; (tdef::matchingTypes) ]
        findAllDerivingTypes allTypes remainingTypesToCheck newMatchingTypes 

and getAllTypesDerivingFrom (allTypes: Mono.Cecil.TypeDefinition list) baseTypeName =
    let typesToCheck = filterTypesDerivingFromBaseType allTypes baseTypeName
    findAllDerivingTypes allTypes typesToCheck []

let getAssemblyDefinition = loadAssembly (new RegistrableResolver())
let assemblies = [ "packages/neutral/Xamarin.Forms/lib/netstandard2.0/Xamarin.Forms.Core.dll"; "build_output/Fabulous.XamarinForms/Fabulous.XamarinForms.Core/Fabulous.XamarinForms.Core.dll" ]
let allTypes =
    [ for assembly in assemblies do
        let loadedAssembly = getAssemblyDefinition assembly
        for ``module`` in loadedAssembly.Modules do
            for ``type`` in ``module``.Types do
                yield ``type`` ]
    
let derivingTypes = getAllTypesDerivingFrom allTypes "Xamarin.Forms.Element"

let getGenericType (edef: Mono.Cecil.EventDefinition) =
    match edef.EventType with
    | :? Mono.Cecil.GenericInstanceType as git -> git.GenericArguments.[0].Name
    | _ -> "None"

let tdef = allTypes |> List.find (fun tdef -> tdef.FullName = "Xamarin.Forms.VisualElement")
tdef.Events |> Seq.iter (fun edef -> printfn "- Name = %s; EventType = %s; EventGenericType = %s" edef.Name edef.EventType.Name (getGenericType edef))
