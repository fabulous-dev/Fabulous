namespace CounterApp.Android

open System.Reflection

// the name of the type here needs to match the name inside the ResourceDesigner attribute
type Resources = CounterApp.Android.Resource

[<assembly:Android.Runtime.ResourceDesigner("CounterApp.Android.Resource", IsApplication = true)>]
[<assembly: AssemblyTitle("CounterApp.Android")>]
[<assembly: AssemblyDescription("")>]
[<assembly: AssemblyConfiguration("")>]
[<assembly: AssemblyCompany("")>]
[<assembly: AssemblyProduct("")>]
[<assembly: AssemblyCopyright("")>]
[<assembly: AssemblyTrademark("")>]

// The assembly version has the format {Major}.{Minor}.{Build}.{Revision}

[<assembly: AssemblyVersion("1.0.0.0")>]

//[<assembly: AssemblyDelaySign(false)>]
//[<assembly: AssemblyKeyFile("")>]

()
