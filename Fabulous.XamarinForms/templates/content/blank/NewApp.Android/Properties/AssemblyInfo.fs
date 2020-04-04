namespace NewApp.Android

open System.Reflection
open System.Runtime.CompilerServices
open System.Runtime.InteropServices
open Android.App

// the name of the type here needs to match the name inside the ResourceDesigner attribute
type Resources = NewApp.Android.Resource

[<assembly:Android.Runtime.ResourceDesigner("NewApp.Android.Resources", IsApplication = true)>]
[<assembly:AssemblyTitle("NewApp.Android")>]
[<assembly:AssemblyDescription("")>]
[<assembly:AssemblyConfiguration("")>]
[<assembly:AssemblyCompany("")>]
[<assembly:AssemblyProduct("")>]
[<assembly:AssemblyCopyright("${AuthorCopyright}")>]
[<assembly:AssemblyTrademark("")>]
[<assembly:AssemblyVersion("1.0.0.0")>]

//[<assembly: AssemblyDelaySign(false)>]
//[<assembly: AssemblyKeyFile("")>]

()
