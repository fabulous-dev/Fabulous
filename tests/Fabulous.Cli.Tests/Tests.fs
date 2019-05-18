namespace FSharpDaemon.Tests

open System
open NUnit.Framework
open FsUnit
open FSharp.Compiler.PortaCode.Tests.Basic// for TestHelpers

module Versions = 
    let XamarinForms = "3.6.0.344457"
    let NewtonsoftJson = "11.0.2"

[<TestClass>]
type TestClass () =

    // Paths are relative to "__SOURCE_DIRECTORY__/data" where the project files are written to
    let elmishExtraRefs =
        """
-r:CWD/../../../src/Fabulous.CustomControls/bin/Debug/netstandard2.0/Fabulous.CustomControls.dll
-r:CWD/../../../src/Fabulous.Core/bin/Debug/netstandard2.0/Fabulous.Core.dll
-r:CWD/../../../src/Fabulous.LiveUpdate/bin/Debug/netstandard2.0/Fabulous.LiveUpdate.dll
-r:NUGETFALLBACKFOLDER/newtonsoft.json/NEWTONSOFTJSONVERSION/lib/netstandard2.0/Newtonsoft.Json.dll
-r:PACKAGEDIR/xamarin.forms/XAMARINFORMSVERSION/lib/netstandard2.0/Xamarin.Forms.Core.dll
-r:PACKAGEDIR/xamarin.forms/XAMARINFORMSVERSION/lib/netstandard2.0/Xamarin.Forms.Platform.dll
-r:PACKAGEDIR/xamarin.forms/XAMARINFORMSVERSION/lib/netstandard2.0/Xamarin.Forms.Xaml.dll
"""
        |> fun s -> s.Replace("NEWTONSOFTJSONVERSION", Versions.NewtonsoftJson)
        |> fun s -> s.Replace("XAMARINFORMSVERSION", Versions.XamarinForms)

    let ElmishTestCase name code = 
        let directory = __SOURCE_DIRECTORY__ + "/data"
        TestHelpers.GeneralTestCase directory name code elmishExtraRefs

    [<Test>]
    member this.TestCanEvaluateCounterApp () =
        Environment.CurrentDirectory <- __SOURCE_DIRECTORY__ + "/../../samples/CounterApp/CounterApp"
        TestHelpers.createNetStandardProjectArgs "CounterApp"  elmishExtraRefs
        Assert.AreEqual(0, FSharpDaemon.Driver.main( [| "dummy.exe"; "--eval"; "@CounterApp.args.txt" |]))

    [<Test>]
    member this.TestCanEvaluateTicTacToeApp () =
        Environment.CurrentDirectory <- __SOURCE_DIRECTORY__ + "/../../samples/TicTacToe/TicTacToe"
        TestHelpers.createNetStandardProjectArgs "TicTacToe" elmishExtraRefs
        Assert.AreEqual(0, FSharpDaemon.Driver.main( [| "dummy.exe"; "--eval"; "@TicTacToe.args.txt" |]))

    [<Test>]
    member this.ViewRefSmoke() =
        ElmishTestCase "ViewRefSmoke" """
let theRef = Fabulous.DynamicViews.ViewRef<Xamarin.Forms.Label>()
       """

    [<Test>]
    member this.TestCallUnitFunction() =
        ElmishTestCase "TestCallUnitFunction" """ 
let theRef = FSharp.Core.LanguagePrimitives.GenericZeroDynamic<int>()
       """


