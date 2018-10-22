namespace FSharpDaemon.Tests

open System
open System.IO
open Microsoft.VisualStudio.TestTools.UnitTesting

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
-r:PACKAGEDIR/fsharp.core/4.5.2/lib/netstandard1.6/FSharp.Core.dll
-r:PACKAGEDIR/microsoft.csharp/4.3.0/ref/netstandard1.0/Microsoft.CSharp.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/Microsoft.Win32.Primitives.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/mscorlib.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/netstandard.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.AppContext.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Collections.Concurrent.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Collections.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Collections.NonGeneric.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Collections.Specialized.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.ComponentModel.Composition.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.ComponentModel.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.ComponentModel.EventBasedAsync.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.ComponentModel.Primitives.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.ComponentModel.TypeConverter.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Console.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Core.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Data.Common.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Data.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Diagnostics.Contracts.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Diagnostics.Debug.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Diagnostics.FileVersionInfo.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Diagnostics.Process.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Diagnostics.StackTrace.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Diagnostics.TextWriterTraceListener.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Diagnostics.Tools.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Diagnostics.TraceSource.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Diagnostics.Tracing.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Drawing.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Drawing.Primitives.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Dynamic.Runtime.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Globalization.Calendars.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Globalization.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Globalization.Extensions.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.IO.Compression.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.IO.Compression.FileSystem.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.IO.Compression.ZipFile.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.IO.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.IO.FileSystem.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.IO.FileSystem.DriveInfo.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.IO.FileSystem.Primitives.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.IO.FileSystem.Watcher.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.IO.IsolatedStorage.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.IO.MemoryMappedFiles.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.IO.Pipes.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.IO.UnmanagedMemoryStream.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Linq.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Linq.Expressions.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Linq.Parallel.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Linq.Queryable.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Net.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Net.Http.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Net.NameResolution.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Net.NetworkInformation.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Net.Ping.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Net.Primitives.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Net.Requests.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Net.Security.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Net.Sockets.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Net.WebHeaderCollection.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Net.WebSockets.Client.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Net.WebSockets.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Numerics.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.ObjectModel.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Reflection.dll
-r:PACKAGEDIR/system.reflection.emit.ilgeneration/4.3.0/ref/netstandard1.0/System.Reflection.Emit.ILGeneration.dll
-r:PACKAGEDIR/system.reflection.emit.lightweight/4.3.0/ref/netstandard1.0/System.Reflection.Emit.Lightweight.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Reflection.Extensions.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Reflection.Primitives.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Resources.Reader.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Resources.ResourceManager.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Resources.Writer.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Runtime.CompilerServices.VisualC.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Runtime.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Runtime.Extensions.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Runtime.Handles.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Runtime.InteropServices.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Runtime.InteropServices.RuntimeInformation.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Runtime.Numerics.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Runtime.Serialization.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Runtime.Serialization.Formatters.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Runtime.Serialization.Json.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Runtime.Serialization.Primitives.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Runtime.Serialization.Xml.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Security.Claims.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Security.Cryptography.Algorithms.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Security.Cryptography.Csp.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Security.Cryptography.Encoding.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Security.Cryptography.Primitives.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Security.Cryptography.X509Certificates.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Security.Principal.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Security.SecureString.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.ServiceModel.Web.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Text.Encoding.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Text.Encoding.Extensions.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Text.RegularExpressions.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Threading.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Threading.Overlapped.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Threading.Tasks.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Threading.Tasks.Parallel.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Threading.Thread.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Threading.ThreadPool.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Threading.Timer.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Transactions.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.ValueTuple.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Web.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Windows.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Xml.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Xml.Linq.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Xml.ReaderWriter.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Xml.Serialization.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Xml.XDocument.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Xml.XmlDocument.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Xml.XmlSerializer.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Xml.XPath.dll
-r:PACKAGEDIR/netstandard.library/2.0.1/build/netstandard2.0/ref/System.Xml.XPath.XDocument.dll
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
        |> fun s -> File.WriteAllText(proj + ".args.txt", s)

    let elmishExtraRefs =
            """
-r:CWD/../../../src/Fabulous.Core/bin/Debug/netstandard2.0/Fabulous.Core.dll
-r:CWD/../../../src/Fabulous.LiveUpdate/bin/Debug/netstandard2.0/Fabulous.LiveUpdate.dll
-r:PACKAGEDIR/newtonsoft.json/11.0.2/lib/netstandard2.0/Newtonsoft.Json.dll
-r:PACKAGEDIR/xamarin.forms/3.1.0.697729/lib/netstandard2.0/Xamarin.Forms.Core.dll
-r:PACKAGEDIR/xamarin.forms/3.1.0.697729/lib/netstandard2.0/Xamarin.Forms.Platform.dll
-r:PACKAGEDIR/xamarin.forms/3.1.0.697729/lib/netstandard2.0/Xamarin.Forms.Xaml.dll
-r:PACKAGEDIR/newtonsoft.json/10.0.1/lib/netstandard1.3/Newtonsoft.Json.dll
"""

    let SimpleTestCase name code =
        Environment.CurrentDirectory <- __SOURCE_DIRECTORY__
        File.WriteAllText (name + ".fs", """
module TestCode
""" + code)
        createNetStandardProjectArgs name ""

        Assert.AreEqual(0, FSharpDaemon.Driver.main( [| "dummy.exe"; "--eval"; "@" + name + ".args.txt" |]))
    [<TestMethod>]
    member this.TestCanEvaluateCounterApp () =
        Environment.CurrentDirectory <- __SOURCE_DIRECTORY__ + "/../Samples/CounterApp/CounterApp"
        createNetStandardProjectArgs "CounterApp"  elmishExtraRefs
        Assert.AreEqual(0, FSharpDaemon.Driver.main( [| "dummy.exe"; "--eval"; "@CounterApp.args.txt" |]))

    [<TestMethod>]
    member this.TestCanEvaluateTicTacToeApp () =
        Environment.CurrentDirectory <- __SOURCE_DIRECTORY__ + "/../Samples/TicTacToe/TicTacToe"
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

    [<TestMethod>]
    member this.TestEvalLocalFunctionOnClass() =
        SimpleTestCase "TestEvalLocalFunctionOnClass" """
type C(x: int) = 
    let f x = x + 1
    member __.Y with get() = f x

let c = C(3)
if c.Y <> 4 then failwith "fail!" 
        """

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

    [<TestMethod>]
    member this.GenericThing() =
        SimpleTestCase "GenericThing" """
let f () = 
    let g x = x
    g 3, g 4, g
let a, b, (c: int -> int) = f()
if a <> 3 then failwith "fail!" 
if b <> 4 then failwith "fail fail!" 
if c 5 <> 5 then failwith "fail fail fail!" 
        """

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
