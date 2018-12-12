// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Generator.Tests

open NUnit.Framework
open FsUnit
open Fabulous.Generator.Helpers

module ``Helpers Tests`` =
    let defaultValue = "default"
    let getValueOrDefault = getValueOrDefault defaultValue
    
    [<Test>]
    let ``NotNullOrWhitespace should return None if null``() =
        null |> (|NotNullOrWhitespace|_|) |> should equal None
    
    [<Test>]
    let ``NotNullOrWhitespace should return None if string empty``() =
        "" |> (|NotNullOrWhitespace|_|) |> should equal None
    
    [<Test>]
    let ``NotNullOrWhitespace should return None if string is only whitespace``() =
        String.replicate 10 " " |> (|NotNullOrWhitespace|_|) |> should equal None

    [<Test>]
    let ``NotNullOrWhitespace should return Some if string not empty``() =
        "Some string" |> (|NotNullOrWhitespace|_|) |> should equal (Some "Some string")

    [<Test>]
    let ``getValueOrDefault should return default value if value null``() =
        getValueOrDefault null |> should equal defaultValue

    [<Test>]
    let ``getValueOrDefault should return default value if value empty``() =
        getValueOrDefault "" |> should equal defaultValue

    [<Test>]
    let ``getValueOrDefault should return default value if value is only whitespace``() =
        getValueOrDefault (String.replicate 10 " ") |> should equal defaultValue

    [<Test>]
    let ``getValueOrDefault should return value if value not empty``() =
        getValueOrDefault "Some string" |> should equal "Some string"

    [<Test>]
    let ``toLowerPascalCase should return null if string is null``() =
        toLowerPascalCase null |> should equal null

    [<Test>]
    let ``toLowerPascalCase should return empty string if string is empty``() =
        toLowerPascalCase "" |> should equal ""

    [<Test>]
    let ``toLowerPascalCase should return a lowercase string if string is only 1 character long``() =
        toLowerPascalCase "X" |> should equal "x"

    [<Test>]
    let ``toLowerPascalCase should return a correctly cased string if string is not empty``() =
        toLowerPascalCase "IsEnabled" |> should equal "isEnabled"

    [<Test>]
    let ``getResultOks should return only Ok values``() =
        [ Ok true; Error "error"; Ok true; Error "error" ]
        |> getResultOks
        |> should equal [ true; true ]

    [<Test>]
    let ``getResultErrors should return only Error values``() =
        [ Ok true; Error "error"; Ok true; Error "error" ]
        |> getResultErrors
        |> should equal [ "error"; "error" ]

    [<Test>]
    let ``tryFindType should return None if Type is not in array``() =
        let types = [| "Button"; "Label"; "Entry" |]
        tryFindType types "Image" |> should equal None

    [<Test>]
    let ``tryFindType should return Some if Type is in array``() =
        let types = [| "Button"; "Label"; "Entry" |]
        tryFindType types "Label" |> should equal (Some "Label")