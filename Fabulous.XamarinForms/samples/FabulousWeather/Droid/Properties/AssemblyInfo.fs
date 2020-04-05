namespace FabulousWeather.Android

open System.Reflection

// the name of the type here needs to match the name inside the ResourceDesigner attribute
type Resources = FabulousWeather.Android.Resource

[<assembly:Android.Runtime.ResourceDesigner("FabulousWeather.Android.Resource", IsApplication = true)>]
[<assembly: AssemblyTitle("FabulousWeather.Android")>]
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
