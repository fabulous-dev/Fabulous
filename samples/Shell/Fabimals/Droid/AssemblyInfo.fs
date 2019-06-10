namespace Droid

open System.Reflection
open System.Runtime.CompilerServices

// the name of the type here needs to match the name inside the ResourceDesigner attribute
type Resources = Droid.Resource

[<assembly:Android.Runtime.ResourceDesigner("Droid.Resources", IsApplication = true)>]
[<assembly:AssemblyTitle("Fabimals.Droid")>]
[<assembly:AssemblyDescription("")>]
[<assembly:AssemblyConfiguration("")>]
[<assembly:AssemblyCompany("")>]
[<assembly:AssemblyProduct("")>]
[<assembly:AssemblyCopyright("")>]
[<assembly:AssemblyTrademark("")>]
[<assembly:AssemblyVersion("1.0.0.0")>]
()
// The assembly version has the format {Major}.{Minor}.{Build}.{Revision}
//[<assembly: AssemblyDelaySign(false)>]
//[<assembly: AssemblyKeyFile("")>]
