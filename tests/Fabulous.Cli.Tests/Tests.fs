namespace FSharpDaemon.Tests

open System
open System.IO
open Microsoft.VisualStudio.TestTools.UnitTesting

module Versions =
    let FSharpCore = "4.5.2"
    let MicrosoftCSharp = "4.5.0"
    let NETStandardLibrary = "2.0.3"
    let SystemReflectionEmitILGeneration = "4.3.0"
    let SystemReflectionEmitLightweight = "4.3.0"
    let NewtonsoftJson = "11.0.2"
    let XamarinForms = "3.4.0.1009999"

[<TestClass>]
type TestClass () =

    let createNetStandardProjectArgs proj extras = 
        """-o:PROJ.dll
-g
--debug:portable
--noframework
--define:TESTEVAL
--define:TRACE
--define:DEBUG
--define:NETSTANDARD2_0
--optimize-
-r:PACKAGEDIR/fsharp.core/FSHARPCOREVERSION/lib/netstandard1.6/FSharp.Core.dll
-r:NUGETFALLBACKFOLDER/microsoft.csharp/MICROSOFTCSHARPVERSION/ref/netstandard2.0/Microsoft.CSharp.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/Microsoft.Win32.Primitives.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/mscorlib.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/netstandard.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.AppContext.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Collections.Concurrent.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Collections.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Collections.NonGeneric.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Collections.Specialized.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.ComponentModel.Composition.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.ComponentModel.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.ComponentModel.EventBasedAsync.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.ComponentModel.Primitives.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.ComponentModel.TypeConverter.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Console.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Core.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Data.Common.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Data.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Diagnostics.Contracts.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Diagnostics.Debug.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Diagnostics.FileVersionInfo.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Diagnostics.Process.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Diagnostics.StackTrace.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Diagnostics.TextWriterTraceListener.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Diagnostics.Tools.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Diagnostics.TraceSource.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Diagnostics.Tracing.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Drawing.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Drawing.Primitives.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Dynamic.Runtime.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Globalization.Calendars.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Globalization.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Globalization.Extensions.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.IO.Compression.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.IO.Compression.FileSystem.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.IO.Compression.ZipFile.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.IO.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.IO.FileSystem.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.IO.FileSystem.DriveInfo.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.IO.FileSystem.Primitives.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.IO.FileSystem.Watcher.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.IO.IsolatedStorage.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.IO.MemoryMappedFiles.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.IO.Pipes.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.IO.UnmanagedMemoryStream.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Linq.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Linq.Expressions.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Linq.Parallel.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Linq.Queryable.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Net.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Net.Http.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Net.NameResolution.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Net.NetworkInformation.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Net.Ping.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Net.Primitives.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Net.Requests.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Net.Security.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Net.Sockets.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Net.WebHeaderCollection.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Net.WebSockets.Client.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Net.WebSockets.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Numerics.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.ObjectModel.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Reflection.dll
-r:NUGETFALLBACKFOLDER/system.reflection.emit.ilgeneration/SYSTEMREFLECTIONEMITILGENERATIONVERSION/ref/netstandard1.0/System.Reflection.Emit.ILGeneration.dll
-r:NUGETFALLBACKFOLDER/system.reflection.emit.lightweight/SYSTEMREFLECTIONEMITLIGHTWEIGHTVERSION/ref/netstandard1.0/System.Reflection.Emit.Lightweight.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Reflection.Extensions.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Reflection.Primitives.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Resources.Reader.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Resources.ResourceManager.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Resources.Writer.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Runtime.CompilerServices.VisualC.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Runtime.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Runtime.Extensions.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Runtime.Handles.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Runtime.InteropServices.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Runtime.InteropServices.RuntimeInformation.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Runtime.Numerics.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Runtime.Serialization.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Runtime.Serialization.Formatters.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Runtime.Serialization.Json.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Runtime.Serialization.Primitives.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Runtime.Serialization.Xml.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Security.Claims.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Security.Cryptography.Algorithms.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Security.Cryptography.Csp.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Security.Cryptography.Encoding.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Security.Cryptography.Primitives.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Security.Cryptography.X509Certificates.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Security.Principal.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Security.SecureString.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.ServiceModel.Web.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Text.Encoding.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Text.Encoding.Extensions.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Text.RegularExpressions.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Threading.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Threading.Overlapped.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Threading.Tasks.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Threading.Tasks.Parallel.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Threading.Thread.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Threading.ThreadPool.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Threading.Timer.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Transactions.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.ValueTuple.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Web.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Windows.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Xml.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Xml.Linq.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Xml.ReaderWriter.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Xml.Serialization.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Xml.XDocument.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Xml.XmlDocument.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Xml.XmlSerializer.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Xml.XPath.dll
-r:NUGETFALLBACKFOLDER/netstandard.library/NETSTANDARDLIBRARYVERSION/build/netstandard2.0/ref/System.Xml.XPath.XDocument.dll
--target:library
--warn:3
--warnaserror:76
--fullpaths
--flaterrors
--highentropyva-
--targetprofile:netstandard
--simpleresolution
--nocopyfsharpcore
PROJ.fs"""
        |> fun s -> s + extras
        |> fun s -> s.Replace("PROJ", proj)
        |> fun s -> s.Replace("CWD", Environment.CurrentDirectory)
        |> fun s -> s.Replace("PACKAGEDIR", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/.nuget/packages")
        |> fun s -> s.Replace("NUGETFALLBACKFOLDER", 
                              match Environment.OSVersion.Platform with
                              | PlatformID.Win32NT -> "C:/Program Files/dotnet/sdk/NuGetFallbackFolder"
                              | PlatformID.Unix -> "/usr/local/share/dotnet/sdk/NuGetFallbackFolder"
                              | platform -> failwithf "No path configured for NuGetFallbackFolder on %A" platform
        )
        |> fun s -> s.Replace("FSHARPCOREVERSION", Versions.FSharpCore)
        |> fun s -> s.Replace("MICROSOFTCSHARPVERSION", Versions.MicrosoftCSharp)
        |> fun s -> s.Replace("NETSTANDARDLIBRARYVERSION", Versions.NETStandardLibrary)
        |> fun s -> s.Replace("SYSTEMREFLECTIONEMITILGENERATIONVERSION", Versions.SystemReflectionEmitILGeneration)
        |> fun s -> s.Replace("SYSTEMREFLECTIONEMITLIGHTWEIGHTVERSION", Versions.SystemReflectionEmitLightweight)
        |> fun s -> s.Replace("NEWTONSOFTJSONVERSION", Versions.NewtonsoftJson)
        |> fun s -> s.Replace("XAMARINFORMSVERSION", Versions.XamarinForms)
        |> fun s -> File.WriteAllText(proj + ".args.txt", s)

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

    let SimpleTestCase name code =
        let directory = __SOURCE_DIRECTORY__ + "/data"
        Directory.CreateDirectory directory |> ignore
        Environment.CurrentDirectory <- directory
        File.WriteAllText (name + ".fs", """
module TestCode
""" + code)
        createNetStandardProjectArgs name ""

        Assert.AreEqual(0, FSharpDaemon.Driver.main( [| "dummy.exe"; "--eval"; "@" + name + ".args.txt" |]))
    [<TestMethod>]
    member this.TestCanEvaluateCounterApp () =
        Environment.CurrentDirectory <- __SOURCE_DIRECTORY__ + "/../../Samples/CounterApp/CounterApp"
        createNetStandardProjectArgs "CounterApp"  elmishExtraRefs
        Assert.AreEqual(0, FSharpDaemon.Driver.main( [| "dummy.exe"; "--eval"; "@CounterApp.args.txt" |]))

    [<TestMethod>]
    member this.TestCanEvaluateTicTacToeApp () =
        Environment.CurrentDirectory <- __SOURCE_DIRECTORY__ + "/../../Samples/TicTacToe/TicTacToe"
        createNetStandardProjectArgs "TicTacToe" elmishExtraRefs
        Assert.AreEqual(0, FSharpDaemon.Driver.main( [| "dummy.exe"; "--eval"; "@TicTacToe.args.txt" |]))

    [<TestMethod>]
    member this.TestTuples () =
        SimpleTestCase "TestTuples" """
module Tuples = 
    let x1 = (1, 2)
    let x2 = match x1 with (a,b) -> 1 + 2
        """

    [<TestMethod>]
    member this.PlusOperator () =
        SimpleTestCase "PlusOperator" """
module PlusOperator = 
    let x1 = 1 + 1
    let x5 = 1.0 + 2.0
    let x6 = 1.0f + 2.0f
    let x7 = 10uy + 9uy
    let x8 = 10us + 9us
    let x9 = 10u + 9u
    let x10 = 10UL + 9UL
    let x11 = 10y + 9y
    let x12 = 10s + 9s
    let x14 = 10 + 9
    let x15 = 10L + 9L
    let x16 = 10.0M + 11.0M
    let x17 = "a" + "b"
        """

    [<TestMethod>]
    member this.MinusOperator () =
        SimpleTestCase "MinusOperator" """
module MinusOperator = 
    let x1 = 1 - 1
    let x5 = 1.0 - 2.0
    let x6 = 1.0f - 2.0f
    let x7 = 10uy - 9uy
    let x8 = 10us - 9us
    let x9 = 10u - 9u
    let x10 = 10UL - 9UL
    let x11 = 10y - 9y
    let x12 = 10s - 9s
    let x14 = 10 - 9
    let x15 = 10L - 9L
    let x16 = 10.0M - 11.0M
        """

    [<TestMethod>]
    member this.Options () =
        SimpleTestCase "Options" """
module Options = 
    let x2 = None : int option 
    let x3 = Some 3 : int option 
    let x5 = x2.IsNone
    let x6 = x3.IsNone
    let x7 = x2.IsSome
    let x8 = x3.IsSome
        """

    [<TestMethod>]
    member this.Exceptions () =
        SimpleTestCase "Exceptions" """
module Exceptions = 
    let x2 = try invalidArg "a" "wtf" with :? System.ArgumentException -> () 
    let x4 = try failwith "hello" with e -> () 
    let x5 = try 1 with e -> failwith "fail!" 
    if x5 <> 1 then failwith "fail! fail!" 
        """

    [<TestMethod>]
    member this.TestEvalIsNone () =
        SimpleTestCase "TestEvalIsNone" """
let x3 = (Some 3).IsNone
        """

    [<TestMethod>]
    member this.TestEvalUnionCaseInGenericCofe () =
        SimpleTestCase "TestEvalUnionCaseInGenericCofe" """
let f<'T>(x:'T) = Some x

let y = f 3
printfn "y = %A, y.GetType() = %A" y (y.GetType())
        """

    [<TestMethod>]
    member this.TestEvalNewOnClass() =
        SimpleTestCase "TestEvalNewOnClass" """
type C(x: int) = 
    member __.X = x

let y = C(3)
let z = if y.X <> 3 then failwith "fail!" else 1
        """

    [<TestMethod>]
    member this.TestEvalSetterOnClass() =
        SimpleTestCase "TestEvalSetterOnClass" """
type C(x: int) = 
    let mutable y = x
    member __.Y with get() = y and set v = y <- v

let c = C(3)
if c.Y <> 3 then failwith "fail!" 
c.Y <- 4
if c.Y <> 4 then failwith "fail! fail!" 
        """

// Known limitation of FSharp Compiler Service
//    [<TestMethod>]
//    member this.TestEvalLocalFunctionOnClass() =
//        SimpleTestCase "TestEvalLocalFunctionOnClass" """
//type C(x: int) = 
//    let f x = x + 1
//    member __.Y with get() = f x

//let c = C(3)
//if c.Y <> 4 then failwith "fail!" 
//        """

    [<TestMethod>]
    member this.TestEquals() =
        SimpleTestCase "TestEquals" """
let x = (1 = 2)
        """


    [<TestMethod>]
    member this.TestTypeTest() =
        SimpleTestCase "TestTypeTest" """
let x = match box 1 with :? int as a -> a | _ -> failwith "fail!"
if x <> 1 then failwith "fail fail!" 
        """


    [<TestMethod>]
    member this.TestTypeTest2() =
        SimpleTestCase "TestTypeTest2" """
let x = match box 2 with :? string as a -> failwith "fail!" | _ -> 1
if x <> 1 then failwith "fail fail!" 
        """

// Known limitation of FSharp Compiler Service
//    [<TestMethod>]
//    member this.GenericThing() =
//        SimpleTestCase "GenericThing" """
//let f () = 
//    let g x = x
//    g 3, g 4, g
//let a, b, (c: int -> int) = f()
//if a <> 3 then failwith "fail!" 
//if b <> 4 then failwith "fail fail!" 
//if c 5 <> 5 then failwith "fail fail fail!" 
//        """

    [<TestMethod>]
    member this.DateTime() =
        SimpleTestCase "DateTime" """
let v1 = System.DateTime.Now
let v2 = v1.Date
let mutable v3 = System.DateTime.Now
let v4 = v3.Date
        """

    [<TestMethod>]
    member this.LocalMutation() =
        SimpleTestCase "LocalMutation" """
let f () = 
    let mutable x = 1
    x <- x + 1
    x <- x + 1
    x
if f() <> 3 then failwith "fail fail!" 
        """


    [<TestMethod>]
    member this.LetRecSmoke() =
        SimpleTestCase "LetRecSmoke" """
let even a = 
    let rec even x = (if x = 0 then true else odd (x-1))
    and odd x = (if x = 0 then false else even (x-1))
    even a

if even 11 then failwith "fail!" 
if not (even 10) then failwith "fail fail!" 
        """


    [<TestMethod>]
    member this.TryGetValueSmoke() =
        SimpleTestCase "TryGetValueSmoke" """
let m = dict  [ (1,"2") ]
let f() = 
    match m.TryGetValue 1 with
    | true, v -> if v <> "2" then failwith "fail!"
    | _ -> failwith "fail2!"

f()
       """


// tests needed:
//   2D arrays
