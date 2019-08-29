// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen.Tests.AssemblyReaderTests

#nowarn "59" // Casts always hold
#nowarn "66" // Casts always hold

open NUnit.Framework
open Fabulous.CodeGen.AssemblyReader
open FsUnit
open System.Numerics
open System

type TestEnum =
    | FirstValue = 0
    | SecondValue = 1

module ConvertersTests =
    [<TestCase("System.Boolean", "bool")>]
    [<TestCase("System.SByte", "sbyte")>]
    [<TestCase("System.Byte", "byte")>]
    [<TestCase("System.Int16", "int16")>]
    [<TestCase("System.UInt16", "uint16")>]
    [<TestCase("System.Int32", "int")>]
    [<TestCase("System.UInt32", "uint32")>]
    [<TestCase("System.Int64", "int64")>]
    [<TestCase("System.UInt64", "uint64")>]
    [<TestCase("System.BigInteger", "bigint")>]
    [<TestCase("System.Double", "float")>]
    [<TestCase("System.Single", "single")>]
    [<TestCase("System.Decimal", "decimal")>]
    [<TestCase("System.String", "string")>]
    [<TestCase("System.Object", "obj")>]
    let ``convertTypeName should convert known CLR types``(typeName, expectedValue) =
        Converters.convertTypeName typeName |> should equal expectedValue

    [<TestCase("System.Collections.IList")>]
    [<TestCase("System.Collections.Generic.IList`1[System.Object]")>]
    let ``convertTypeName should convert IList/IList<System.Object> to obj list``(typeName) =
        Converters.convertTypeName typeName |> should equal "obj list"

    [<Test>]
    let ``convertTypeName should not convert an unknown type``() =
        Converters.convertTypeName "UnknownType" |> should equal "UnknownType"

    [<Test>]
    let ``convertEventType should return unit -> unit when eventArgsTypeOpt is None``() =
        Converters.convertEventType None |> should equal "unit -> unit"

    [<TestCase("Xamarin.Forms.TextChangedEventArgs", "Xamarin.Forms.TextChangedEventArgs -> unit")>]
    [<TestCase("Xamarin.Forms.EntryCompletedEventArgs", "Xamarin.Forms.EntryCompletedEventArgs -> unit")>]
    let ``convertEventType should a function signature accepting the EventArgs type and returning unit when eventArgsTypeOpt is Some``(eventArgsType, expectedValue) =
        Converters.convertEventType (Some eventArgsType) |> should equal expectedValue
        
    [<Test>]
    let ``tryGetStringRepresentationOfDefaultValue should return the default F# representation for null``() =
        Converters.tryGetStringRepresentationOfDefaultValue null |> should equal (Some "null")

    [<TestCase(true, "true")>]
    [<TestCase(false, "false")>]
    [<TestCase(1y, "1y")>]
    [<TestCase(2uy, "2uy")>]
    [<TestCase(3s, "3s")>]
    [<TestCase(4us, "4us")>]
    [<TestCase(5, "5")>]
    [<TestCase(6u, "6u")>]
    [<TestCase(7L, "7L")>]
    [<TestCase(8UL, "8UL")>]
    [<TestCase(9.1 :> float, "9.1")>]
    [<TestCase(9.2 :> double, "9.2")>]
    [<TestCase(10.1f :> float32, "10.1f")>]
    [<TestCase(10.2f :> single, "10.2f")>]
    [<TestCase("", "System.String.Empty")>]
    let ``tryGetStringRepresentationOfDefaultValue should return the default F# representation for known CLR types``(defaultValue, expectedValue) =
        Converters.tryGetStringRepresentationOfDefaultValue defaultValue |> should equal (Some expectedValue)
        
    [<Test>]
    let ``tryGetStringRepresentationOfDefaultValue should return the default F# representation for System.Numerics.BigInteger``() =
        Converters.tryGetStringRepresentationOfDefaultValue 9I |> should equal (Some "9I")
        
    [<Test>]
    let ``tryGetStringRepresentationOfDefaultValue should return the default F# representation for System.Decimal``() =
        Converters.tryGetStringRepresentationOfDefaultValue 11.1m |> should equal (Some "11.1m")

    [<Test>]
    let ``tryGetStringRepresentationOfDefaultValue should return the default F# representation for DateTime.MinValue``() =
        Converters.tryGetStringRepresentationOfDefaultValue System.DateTime.MinValue |> should equal (Some "System.DateTime.MinValue")
        
    [<Test>]
    let ``tryGetStringRepresentationOfDefaultValue should return the default F# representation for DateTime.MaxValue``() =
        Converters.tryGetStringRepresentationOfDefaultValue System.DateTime.MaxValue |> should equal (Some "System.DateTime.MaxValue")
        
    [<Test>]
    let ``tryGetStringRepresentationOfDefaultValue should return the default F# representation for DateTime``() =
        let now = System.DateTime.UtcNow
        let expectedValue = sprintf "System.DateTime(%i, %i, %i)" now.Year now.Month now.Day
        Converters.tryGetStringRepresentationOfDefaultValue now |> should equal (Some expectedValue)
        
    [<Test>]
    let ``tryGetStringRepresentationOfDefaultValue should return the default F# representation for TimeSpan.Zero``() =
        Converters.tryGetStringRepresentationOfDefaultValue TimeSpan.Zero |> should equal (Some "System.TimeSpan.Zero")

    [<Test>]
    let ``tryGetStringRepresentationOfDefaultValue should return the default F# representation for enum``() =
        Converters.tryGetStringRepresentationOfDefaultValue TestEnum.SecondValue |> should equal (Some "Fabulous.CodeGen.Tests.AssemblyReaderTests.TestEnum.SecondValue")

