// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.Cli.Tests

open System
open System.IO
open NUnit.Framework

module Versions =
    let FSharpCore = "4.5.2"
    let MicrosoftCSharp = "4.5.0"
    let NETStandardLibrary = "2.0.3"
    let XamarinForms = "3.4.0.1009999"
    let NewtonsoftJson = "11.0.2"

[<AutoOpen>]
module TestHelpers = 
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

    /// Helper used by Fabulous.Cli testing
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
-r:CWD/../../../packages/neutral/System.Reflection.Emit.ILGeneration/ref/netstandard1.0/System.Reflection.Emit.ILGeneration.dll
-r:CWD/../../../packages/neutral/System.Reflection.Emit.Lightweight/ref/netstandard1.0/System.Reflection.Emit.Lightweight.dll
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
                                                  | PlatformID.Unix ->
                                                    if Environment.CurrentDirectory.StartsWith("/Users/vsts/") then
                                                        "/Users/vsts/.nuget/packages"
                                                    else if Environment.CurrentDirectory.StartsWith("/home/vsts/") then
                                                        "/home/vsts/.nuget/packages"
                                                    else            
                                                        "/usr/local/share/dotnet/sdk/NuGetFallbackFolder"
                                                  | platform -> failwithf "No path configured for NuGetFallbackFolder on %A" platform
        )
        |> fun s -> s.Replace("FSHARPCOREVERSION", Versions.FSharpCore)
        |> fun s -> s.Replace("MICROSOFTCSHARPVERSION", Versions.MicrosoftCSharp)
        |> fun s -> s.Replace("NETSTANDARDLIBRARYVERSION", Versions.NETStandardLibrary)
        |> fun s -> File.WriteAllText(proj + ".args.txt", s)


    let GeneralTestCaseLiveChecks directory name code refs livechecks =
        Directory.CreateDirectory directory |> ignore
        Environment.CurrentDirectory <- directory
        File.WriteAllText (name + ".fs", """
module TestCode
""" + code)
        createNetStandardProjectArgs name refs

        let args = 
            [| yield "dummy.exe"; 
               yield "--eval"; 
               if livechecks then yield "--livechecksonly"; 
               yield "@" + name + ".args.txt" |]
        Assert.AreEqual(0, FSharp.Compiler.PortaCode.ProcessCommandLine.ProcessCommandLine(args))

    let GeneralTestCase directory name code refs = GeneralTestCaseLiveChecks directory name code refs false


    let ElmishTestCase name code =
        let directory = __SOURCE_DIRECTORY__ + "/data"
        Directory.CreateDirectory directory |> ignore
        Environment.CurrentDirectory <- directory
        File.WriteAllText (name + ".fs", """
module TestCode
    """ + code)
        createNetStandardProjectArgs name elmishExtraRefs

        let args = 
            [| yield "dummy.exe"; 
               yield "--eval"; 
               yield "@" + name + ".args.txt" |]
        Assert.AreEqual(0, FSharp.Compiler.PortaCode.ProcessCommandLine.ProcessCommandLine(args))