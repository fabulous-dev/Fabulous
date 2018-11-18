#r "paket:
nuget Fake.Core.ReleaseNotes
nuget Fake.Core.Target
nuget Fake.Core.Xml
nuget Fake.DotNet.Cli
nuget Fake.DotNet.MSBuild
nuget Fake.Dotnet.NuGet
nuget Fake.DotNet.Paket
nuget Fake.DotNet.Testing.VSTest
nuget Fake.IO.FileSystem
nuget Newtonsoft.Json //"
#load "./.fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.DotNet
open Fake.DotNet.NuGet
open Fake.DotNet.Testing
open Fake.IO
open Fake.IO.Globbing.Operators
open System.IO
open Newtonsoft.Json
open Newtonsoft.Json.Linq

type BuildType =
    | Debug
    | Release

type BuildAction =
    | MSBuild of BuildType
    | DotNetPack
    | NuGetPack

[<NoComparison>]
type ProjectDefinition =
    {
        Name: string
        Path: IGlobbingPattern
        Action: BuildAction
        OutputPath: string option
    }

let release = ReleaseNotes.load "RELEASE_NOTES.MD"
let buildDir = Path.getFullName "./build_output"

let removeIncompatiblePlatformProjects pattern = 
    if not Environment.isWindows then
        pattern
        -- "samples/AllControls/WPF/AllControls.WPF.fsproj"
    else    
        pattern

let projects = [
    { Name = "Src";         Path = !! "src/**/*.fsproj";        Action = DotNetPack;         OutputPath = Some buildDir }
    { Name = "Extensions";  Path = !! "extensions/**/*.fsproj"; Action = DotNetPack;         OutputPath = Some buildDir }
    { Name = "Tests";       Path = !! "tests/**/*.fsproj";      Action = MSBuild Release;    OutputPath = Some (buildDir + "/tests") }
    { Name = "Templates";   Path = !! "templates/**/*.nuspec";  Action = NuGetPack;          OutputPath = Some buildDir }
]

let tools = { Name = "Tools"; Path = !! "tools/**/*.fsproj"; Action = MSBuild Release; OutputPath = Some (buildDir + "/tools") }
let samples = { Name = "Samples"; Path = (!! "samples/**/*.fsproj" |> removeIncompatiblePlatformProjects); Action = MSBuild Debug; OutputPath = Some (buildDir + "/samples") } 
let customControls = { Name = "CustomControls"; Path = !! "src/Fabulous.CustomControls/*.fsproj"; Action = MSBuild Release; OutputPath = None }


let getOutputDir basePath proj =
    match basePath with
    | Some path -> 
        let folderName = Path.GetFileNameWithoutExtension(proj)
        sprintf "%s/%s/" path folderName
    | None -> ""

let msbuild (buildType: BuildType) (definition: ProjectDefinition) =
    let configuration = match buildType with Debug -> "Debug" | Release -> "Release"
    let properties = [ ("Configuration", configuration) ] 

    for project in definition.Path do
        let outputDir = getOutputDir definition.OutputPath project
        MSBuild.run id outputDir "Restore" properties [project] |> Trace.logItems (definition.Name + "Restore-Output: ")
        MSBuild.run id outputDir "Build" properties [project] |> Trace.logItems (definition.Name + "Build-Output: ")

let dotnetPack (definition: ProjectDefinition) =
    for project in definition.Path do
        DotNet.pack (fun opt ->
            { opt with
                Common = { opt.Common with CustomParams = Some "-p:IncludeSourceLink=True" }
                Configuration = DotNet.BuildConfiguration.Release
                OutputPath = definition.OutputPath }) project

let nugetPack (definition: ProjectDefinition) =
    for nuspec in definition.Path do
        NuGet.NuGetPack (fun opt ->
            { opt with
                WorkingDir = "templates"
                OutputPath = definition.OutputPath.Value
                Version = release.NugetVersion
                ReleaseNotes = (String.toLines release.Notes) }) nuspec

let buildProject (definition: ProjectDefinition) =    
    match definition.Action with
    | MSBuild buildType -> msbuild buildType definition
    | DotNetPack -> dotnetPack definition
    | NuGetPack -> nugetPack definition


Target.create "Clean" (fun _ ->
    Shell.cleanDir buildDir
)

Target.create "UpdateVersion" (fun _ ->
    // Updates Directory.Build.props
    let props = "./Directory.Build.props"
    Xml.loadDoc props
    |> Xml.replaceXPath "//Version/text()" release.AssemblyVersion
    |> Xml.replaceXPath "//PackageReleaseNotes/text()" (String.toLines release.Notes)
    |> Xml.replaceXPath "//PackageVersion/text()" release.NugetVersion
    |> Xml.saveDoc props

    // Updates template.json
    let templates = !! "templates/**/.template.config/template.json"
    for template in templates do
        File.readAsString template
        |> JObject.Parse
        |> (fun o -> 
                let prop = o.["symbols"].["FabulousPkgsVersion"].["defaultValue"] :?> JValue
                prop.Value <- release.NugetVersion
                o
        )
        |> (fun o -> JsonConvert.SerializeObject(o, Formatting.Indented))
        |> File.writeString false template
)

Target.create "Restore" (fun _ ->
    Paket.restore id
    DotNet.restore id "Fabulous.sln"
)

Target.create "BuildCustomControls" (fun _ ->
    customControls |> buildProject
)

Target.create "BuildTools" (fun _ ->
    tools |> buildProject
)

Target.create "RunGenerator" (fun _ ->
    DotNet.exec id (tools.OutputPath.Value + "/Generator/Generator.dll") "tools/Generator/Xamarin.Forms.Core.json src/Fabulous.Core/Xamarin.Forms.Core.fs"
    |> (fun x ->
        match x.OK with
        | true -> ()
        | false -> failwith "The generator stopped due to an exception"
    )
)

Target.create "Build" (fun _ -> 
    projects |> List.iter buildProject
)

Target.create "BuildSamples" (fun _ ->
    samples |> buildProject
)

Target.create "RunTests" (fun _ ->
    !! (buildDir + "/tests/*test*.dll")
    -- "**/*TestAdapter*.dll"
    -- "**/*TestFramework*.dll" 
    |> VSTest.run (fun opt ->
        { opt with
             Logger = "trx"
             TestAdapterPath = (Path.getFullName "./packages") }
    )
)

Target.create "TestTemplatesNuGet" (fun _ ->
    // Globally install the templates from the template nuget package we just built
    DotNet.exec id "new" ("-i " + buildDir + "/Fabulous.Templates." + release.NugetVersion + ".nupkg") |> ignore

    let testAppName = "testapp2" + string (abs (hash System.DateTime.Now.Ticks) % 100)
    // Instantiate the template. TODO: additional parameters and variations
    Shell.cleanDir testAppName
    let extraArgs = if Environment.isUnix then "" else " --WPF"
    DotNet.exec id "new fabulous-app" (sprintf "-n %s -lang F#%s" testAppName extraArgs) |> ignore

    let pkgs = Path.GetFullPath(buildDir)
    // When restoring, using the build_output as a package source to pick up the package we just compiled
    DotNet.exec id "restore" (sprintf "%s/%s/%s.fsproj  --source https://api.nuget.org/v3/index.json --source %s" testAppName testAppName testAppName pkgs) |> ignore
    if not Environment.isUnix then 
        DotNet.exec id "restore" (sprintf "%s/%s.WPF/%s.WPF.fsproj  --source https://api.nuget.org/v3/index.json --source %s" testAppName testAppName testAppName pkgs) |> ignore
    
    let slash = if Environment.isUnix then "\\" else ""
    for c in ["Debug"; "Release"] do 
        for p in ["Any CPU"; "iPhoneSimulator"] do
            let args = (sprintf "%s/%s.sln /p:Platform=\"%s\" /p:Configuration=%s /p:PackageSources=%s\"https://api.nuget.org/v3/index.json;%s%s\"" testAppName testAppName p c slash pkgs slash)
            let code = Shell.Exec("msbuild", args) 
            if code <> 0 then failwithf "%s %s failed, error code %d" "msbuild" args code

    (* Manual steps without building nupkg
        .\build LibraryNuGet
        dotnet new -i  templates
        rmdir /s /q testapp2
        dotnet new fabulous-app -n testapp2 -lang F#
        dotnet restore testapp2/testapp2/testapp2.fsproj -s build_output/
        dotnet new -i  templates && rmdir /s /q testapp2 && dotnet new fabulous-app -n testapp2 -lang F# && dotnet restore testapp2/testapp2/testapp2.fsproj && msbuild testapp2/testapp2.Android/testapp2.Android.fsproj /t:RestorePackages && msbuild testapp2/testapp2.Android/testapp2.Android.fsproj
        dotnet new -i  templates && rmdir /s /q testapp2 && dotnet new fabulous-app -n testapp2 -lang F# && dotnet restore testapp2/testapp2/testapp2.fsproj && msbuild testapp2/testapp2.iOS/testapp2.iOS.fsproj /t:RestorePackages  && msbuild testapp2/testapp2.iOS/testapp2.iOS.fsproj
        dotnet new -i  templates && rmdir /s /q testapp2 && dotnet new fabulous-app -n testapp2 -lang F# --macOS && dotnet restore testapp2/testapp2/testapp2.fsproj && msbuild testapp2/testapp2.macOS/testapp2.macOS.fsproj /t:RestorePackages  && msbuild testapp2/testapp2.macOS/testapp2.macOS.fsproj

        dotnet restore testapp265/testapp265.WPF/testapp265.WPF.fsproj --source https://api.nuget.org/v3/index.json -s build_output
        *)
)

Target.create "Test" ignore

open Fake.Core.TargetOperators

"Clean"
  ==> "Restore"
  ==> "UpdateVersion"
  ==> "BuildTools"
  ==> "BuildCustomControls"
  ==> "RunGenerator"
  ==> "Build"

"Build"
  // =?> ("RunTests", Environment.isWindows) // Can't be run on OSX
  ==> "BuildSamples"
  ==> "Test"

"Build"
  ==> "TestTemplatesNuGet"
  ==> "Test"

Target.runOrDefault "Build"