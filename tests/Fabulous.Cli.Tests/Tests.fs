namespace FSharpDaemon.Tests

open System
open NUnit.Framework
open FsUnit
open FSharp.Compiler.PortaCode.Tests // for TestHelpers

[<TestClass>]
type TestClass () =

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

    let ElmishTestCase name code = TestHelpers.GeneralTestCase name code elmishExtraRefs

    [<Test>]
    member this.TestCanEvaluateCounterApp () =
        Environment.CurrentDirectory <- __SOURCE_DIRECTORY__ + "/../../Samples/CounterApp/CounterApp"
        TestHelpers.createNetStandardProjectArgs "CounterApp"  elmishExtraRefs
        Assert.AreEqual(0, FSharpDaemon.Driver.main( [| "dummy.exe"; "--eval"; "@CounterApp.args.txt" |]))

    [<Test>]
    member this.TestCanEvaluateTicTacToeApp () =
        Environment.CurrentDirectory <- __SOURCE_DIRECTORY__ + "/../../Samples/TicTacToe/TicTacToe"
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


