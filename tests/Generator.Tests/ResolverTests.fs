// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Generator.Tests

open NUnit.Framework
open FsUnit
open Mono.Cecil
open Fabulous.Generator.Resolvers
open Fabulous.Generator.Models
open System.Linq
open System.Collections.Generic

module ``Resolvers Tests`` =
    let assemblies = [
        "../../../../../packages/neutral/Xamarin.Forms/lib/netstandard2.0/Xamarin.Forms.Core.dll"
        "../../../../../packages/neutral/Xamarin.Forms.Maps/lib/netstandard2.0/Xamarin.Forms.Maps.dll"
    ]

    let loadedAssemblies = assemblies |> List.map (fun path -> AssemblyDefinition.ReadAssembly(path, ReaderParameters()))

    let getTypeDefinition assemblyIndex name = loadedAssemblies.[assemblyIndex].Modules.[0].Types |> Seq.find (fun t -> t.FullName = name)

    let getPropertyDefinition (tdef: TypeDefinition) name = tdef.Properties |> Seq.find (fun x -> x.Name = name)

    let getInheritedPropertyDefinition (tdef: TypeDefinition) name = tdef |> getHierarchy |> Seq.map (fun (_, tdef2) -> tdef2.Properties |> Seq.tryFind (fun x -> x.Name = name)) |> Seq.find Option.isSome |> Option.get

    let getEventDefinition (tdef: TypeDefinition) name = tdef.Events |> Seq.find (fun x -> x.Name = name)

    let getInheritedEventDefinition (tdef: TypeDefinition) name = tdef |> getHierarchy |> Seq.map (fun (_, tdef2) -> tdef2.Events |> Seq.tryFind (fun x -> x.Name = name)) |> Seq.find Option.isSome |> Option.get
    
    let createTypeBinding (types: string list) : System.Collections.Generic.List<TypeBinding> =
        let enumerable =
            seq {
                for t in types do
                    let typeBinding = TypeBinding()
                    typeBinding.Name <- t
                    yield typeBinding }
        enumerable.ToList()

    let createTypeBindingWithMembers (types: (string * (string * string) list) list) : System.Collections.Generic.List<TypeBinding> =
        let enumerable =
            seq {
                for (name, ms) in types do
                    let typeBinding = TypeBinding()
                    typeBinding.Name <- name
                    let members = System.Collections.Generic.List<MemberBinding>()
                    for (uniqueName, mName) in ms do
                        let memberBinding = MemberBinding()
                        memberBinding.Name <- mName
                        memberBinding.UniqueName <- uniqueName
                        members.Add(memberBinding)
                    typeBinding.Members <- members
                    yield typeBinding }
        enumerable.ToList()

    [<Test>]
    let ``tryResolveType should return None if Type does not exist``() =
        "Xamarin.Forms.InvalidControl" |> tryResolveType loadedAssemblies |> should equal None

    [<Test>]
    let ``tryResolveType should return Some if Type exists``() =
        let buttonTypeDefinition = getTypeDefinition 0 "Xamarin.Forms.Button"
        "Xamarin.Forms.Button" |> tryResolveType loadedAssemblies |> should equal (Some buttonTypeDefinition)

    [<Test>]
    let ``tryResolveType should return Some if Type exists in another loaded assembly``() =
        let mapTypeDefinition = getTypeDefinition 1 "Xamarin.Forms.Maps.Map"
        "Xamarin.Forms.Maps.Map" |> tryResolveType loadedAssemblies |> should equal (Some mapTypeDefinition)

    [<Test>]
    let ``getHierarchy should return complete hierarchy for a given control``() =
        let buttonTypeDefinition = getTypeDefinition 0 "Xamarin.Forms.Button"
        let expectedHierarchy =
            [| "Xamarin.Forms.Button"
               "Xamarin.Forms.View"
               "Xamarin.Forms.VisualElement"
               "Xamarin.Forms.NavigableElement"
               "Xamarin.Forms.Element"
               "Xamarin.Forms.BindableObject"
               "System.Object" |]

        buttonTypeDefinition |> getHierarchy |> Seq.map (fun (_, tdef) -> tdef.FullName) |> Seq.toArray |> should equal expectedHierarchy

    [<Test>]
    let ``tryFindProperty should return None if Property does not exist``() =
        let buttonTypeDefinition = getTypeDefinition 0 "Xamarin.Forms.Button"
        "InvalidProperty" |> tryFindProperty buttonTypeDefinition |> should equal None

    [<Test>]
    let ``tryFindProperty should return Some if Property exists on the control itself``() =
        let buttonTypeDefinition = getTypeDefinition 0 "Xamarin.Forms.Button"
        let textPropertyDefinition = getPropertyDefinition buttonTypeDefinition "Text"
        "Text" |> tryFindProperty buttonTypeDefinition |> should equal (Some textPropertyDefinition)

    [<Test>]
    let ``tryFindProperty should return Some if Property is inherited``() =
        let buttonTypeDefinition = getTypeDefinition 0 "Xamarin.Forms.Button"
        let idPropertyDefinition = getInheritedPropertyDefinition buttonTypeDefinition "Id"
        "Id" |> tryFindProperty buttonTypeDefinition |> should equal (Some idPropertyDefinition)

    [<Test>]
    let ``tryFindEvent should return None if Event does not exist``() =
        let buttonTypeDefinition = getTypeDefinition 0 "Xamarin.Forms.Button"
        "InvalidEvent" |> tryFindEvent buttonTypeDefinition |> should equal None

    [<Test>]
    let ``tryFindEvent should return Some if Event exists on the control itself``() =
        let buttonTypeDefinition = getTypeDefinition 0 "Xamarin.Forms.Button"
        let clickedEventDefinition = getEventDefinition buttonTypeDefinition "Clicked"
        "Clicked" |> tryFindEvent buttonTypeDefinition |> should equal (Some clickedEventDefinition)

    [<Test>]
    let ``tryFindEvent should return Some if Event is inherited``() =
        let buttonTypeDefinition = getTypeDefinition 0 "Xamarin.Forms.Button"
        let focusedEventDefinition = getInheritedEventDefinition buttonTypeDefinition "Focused"
        "Focused" |> tryFindEvent buttonTypeDefinition |> should equal (Some focusedEventDefinition)

    [<Test>]
    let ``resolveTypes should return Error if at least one type can't be resolved``() =
        let types = createTypeBinding [ "Xamarin.Forms.InvalidControl"; "Xamarin.Forms.Button"; "Xamarin.Forms.Label"; "Xamarin.Forms.Maps.Map" ]
        let expected: Result<IDictionary<TypeBinding, TypeDefinition>, string list> = (Error [ "Could not find type 'Xamarin.Forms.InvalidControl'" ])
        types |> resolveTypes loadedAssemblies |> should equal expected

    [<Test>]
    let ``resolveTypes should return Error with all the unresolved types``() =
        let types = createTypeBinding [ "Xamarin.Forms.InvalidControl"; "Xamarin.Forms.Button"; "Xamarin.Forms.Lbel"; "Xamarin.Forms.Label"; "Xamarin.Forms.Maps.Map" ]
        let expected: Result<IDictionary<TypeBinding, TypeDefinition>, string list> = (Error [ "Could not find type 'Xamarin.Forms.InvalidControl'"; "Could not find type 'Xamarin.Forms.Lbel'" ])
        types |> resolveTypes loadedAssemblies |> should equal expected

    [<Test>]
    let ``resolveTypes should return Ok if all types are resolved``() =
        let types = createTypeBinding [ "Xamarin.Forms.Button"; "Xamarin.Forms.Label"; "Xamarin.Forms.Maps.Map" ]
        let expected: Result<(string * string) list, string list> =
            Ok [ ("Xamarin.Forms.Button", "Button")
                 ("Xamarin.Forms.Label", "Label")
                 ("Xamarin.Forms.Maps.Map", "Map") ]
        types |> resolveTypes loadedAssemblies |> Result.map (fun x -> x |> Seq.map (fun kvp -> (kvp.Key.Name, kvp.Value.Name)) |> Seq.toList) |> should equal expected

    [<Test>]
    let ``resolveMembers should return warnings if member not found, and a list of the resolved members``() =
        let types = 
            createTypeBindingWithMembers
                [ ("Xamarin.Forms.Button", [ ("TestText", "Text"); ("TestId", "Id"); ("TestClicked", "Clicked"); ("TestInvalidProperty", "InvalidProperty") ])
                  ("Xamarin.Forms.Maps.Map", [ ("TestMapType", "MapType"); ("TestInvalidProperty", "InvalidProperty") ]) ]
        let typeResolutions = match resolveTypes loadedAssemblies types with Ok value -> value | Error _ -> failwithf "resolveTypes failure"

        let expected = 
            ([ ("TestText", "System.String Xamarin.Forms.Button::Text()")
               ("TestId", "System.Guid Xamarin.Forms.Element::Id()")
               ("TestClicked", "System.EventHandler Xamarin.Forms.Button::Clicked")
               ("TestMapType", "Xamarin.Forms.Maps.MapType Xamarin.Forms.Maps.Map::MapType()") ], 
             [ "Could not find member 'InvalidProperty' on 'Xamarin.Forms.Button'"
               "Could not find member 'InvalidProperty' on 'Xamarin.Forms.Maps.Map'" ])

        resolveMembers types typeResolutions |> (fun (r, w) -> (r |> Seq.map (fun kvp -> (kvp.Key.UniqueName, kvp.Value.FullName)), w)) |> should equal expected

    [<Test>]
    let ``tryGetBoundType should return None if Property does not exist``() =
        let types = 
            createTypeBindingWithMembers
                [ ("Xamarin.Forms.Button", [ ("TestText", "Text"); ("TestId", "Id"); ("TestClicked", "Clicked") ])
                  ("Xamarin.Forms.Maps.Map", [ ("TestMapType", "MapType") ]) ]
        let typeResolutions = match resolveTypes loadedAssemblies types with Ok value -> value | Error _ -> failwithf "resolveTypes failure"
        let memberResolutions = resolveMembers types typeResolutions |> fst
        let invalidMember = MemberBinding()

        invalidMember |> tryGetBoundType memberResolutions |> should equal None

    [<Test>]
    let ``tryGetBoundType should return Some PropertyType if Property does exist``() =
        let types = 
            createTypeBindingWithMembers
                [ ("Xamarin.Forms.Button", [ ("TestText", "Text"); ("TestId", "Id"); ("TestClicked", "Clicked") ])
                  ("Xamarin.Forms.Maps.Map", [ ("TestMapType", "MapType") ]) ]
        let typeResolutions = match resolveTypes loadedAssemblies types with Ok value -> value | Error _ -> failwithf "resolveTypes failure"
        let memberResolutions = resolveMembers types typeResolutions |> fst
        let textMember = memberResolutions |> Seq.find (fun kvp -> kvp.Key.Name = "Text") |> (fun kvp -> kvp.Key)

        textMember |> tryGetBoundType memberResolutions |> Option.map (fun tref -> tref.FullName) |> should equal (Some "System.String")

    [<Test>]
    let ``tryGetBoundType should return Some EventType if Event does exist``() =
        let types = 
            createTypeBindingWithMembers
                [ ("Xamarin.Forms.Button", [ ("TestText", "Text"); ("TestId", "Id"); ("TestClicked", "Clicked") ])
                  ("Xamarin.Forms.Maps.Map", [ ("TestMapType", "MapType") ]) ]
        let typeResolutions = match resolveTypes loadedAssemblies types with Ok value -> value | Error _ -> failwithf "resolveTypes failure"
        let memberResolutions = resolveMembers types typeResolutions |> fst
        let clickedMember = memberResolutions |> Seq.find (fun kvp -> kvp.Key.Name = "Clicked") |> (fun kvp -> kvp.Key)

        clickedMember |> tryGetBoundType memberResolutions |> Option.map (fun tref -> tref.FullName) |> should equal (Some "System.EventHandler")