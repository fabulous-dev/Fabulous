namespace FabulousContacts.Android

open System.Reflection
open System.Runtime.CompilerServices
open System.Runtime.InteropServices
open Android.App

// the name of the type here needs to match the name inside the ResourceDesigner attribute
//type Resources = Fabulous.XamarinForms.Samples.FabulousContacts.Android.Resources
type Resources = FabulousContacts.Android.Resource
[<assembly: Android.Runtime.ResourceDesigner("FabulousContacts.Android.Resource", IsApplication=true)>]

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[<assembly: AssemblyTitle("Fabulous.XamarinForms.Samples.FabulousContacts.Android")>]
[<assembly: AssemblyDescription("")>]
[<assembly: AssemblyConfiguration("")>]
[<assembly: AssemblyCompany("")>]
[<assembly: AssemblyProduct("FabulousContacts.Android")>]
[<assembly: AssemblyCopyright("Copyright ©  2014")>]
[<assembly: AssemblyTrademark("")>]
[<assembly: AssemblyCulture("")>]
[<assembly: ComVisible(false)>]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [<assembly: AssemblyVersion("1.0.*")>]
[<assembly: AssemblyVersion("1.0.0.0")>]
[<assembly: AssemblyFileVersion("1.0.0.0")>]

// Add some common permissions, these can be removed if not needed
[<assembly: UsesPermission(Android.Manifest.Permission.Internet)>]
[<assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)>]
[<assembly: UsesPermission(Android.Manifest.Permission.Internet)>]
[<assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)>]
[<assembly: UsesPermission(Android.Manifest.Permission.ReadExternalStorage)>]
[<assembly: UsesPermission(Android.Manifest.Permission.AccessCoarseLocation)>]
[<assembly: UsesPermission(Android.Manifest.Permission.AccessFineLocation)>]
[<assembly: UsesPermission(Android.Manifest.Permission.AccessLocationExtraCommands)>]
[<assembly: UsesPermission(Android.Manifest.Permission.AccessMockLocation)>]
[<assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)>]
[<assembly: UsesPermission(Android.Manifest.Permission.AccessWifiState)>]
[<assembly: UsesPermission(Android.Manifest.Permission.AccessLocationExtraCommands)>]
[<assembly: UsesPermission(Android.Manifest.Permission.Camera)>]

[<assembly: UsesFeature("android.hardware.camera", Required = false)>]
[<assembly: UsesFeature("android.hardware.camera.autofocus", Required = false)>]
do()
