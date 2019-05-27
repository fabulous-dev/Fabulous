#r "paket: groupref fakebuild //"
#load "./.fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.DotNet
open Fake.DotNet.NuGet
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
    { Name: string
      Path: IGlobbingPattern
      Action: BuildAction
      OutputPath: string }

let release = ReleaseNotes.load "RELEASE_NOTES.md"
let buildDir = Path.getFullName "./build_output"

let removeIncompatiblePlatformProjects pattern = 
    if Environment.isMacOS then
        pattern
        -- "samples/**/*.WPF.fsproj"
        -- "samples/**/*.UWP.fsproj"        
    elif Environment.isWindows then
        pattern
        -- "samples/**/*.macOS.fsproj"
        -- "samples/**/*.iOS.fsproj"
    else    
        pattern
        -- "samples/**/*.macOS.fsproj"
        -- "samples/**/*.iOS.fsproj"
        -- "samples/**/*.WPF.fsproj"
        -- "samples/**/*.UWP.fsproj"
        -- "samples/**/*.Droid.fsproj"

let projects = [
    { Name = "Src";         Path = !! "src/**/*.fsproj";        Action = DotNetPack;         OutputPath = buildDir }
    { Name = "Extensions";  Path = !! "extensions/**/*.fsproj"; Action = DotNetPack;         OutputPath = buildDir }
    { Name = "Tests";       Path = !! "tests/**/*.fsproj";      Action = MSBuild Release;    OutputPath = buildDir + "/tests" }
    { Name = "Templates";   Path = !! "templates/**/*.nuspec";  Action = NuGetPack;          OutputPath = buildDir }
]

let tools = { Name = "Tools"; Path = !! "tools/**/*.fsproj"; Action = MSBuild Release; OutputPath = buildDir + "/tools" }
let samples = { Name = "Samples"; Path = (!! "samples/**/*.fsproj" |> removeIncompatiblePlatformProjects); Action = MSBuild Debug; OutputPath = buildDir + "/samples" } 
let controls = { Name = "CustomControls"; Path = !! "src/Fabulous.CustomControls/Fabulous.CustomControls.fsproj"; Action = MSBuild Release; OutputPath = buildDir + "/controls" }


let getOutputDir basePath proj =
    let folderName = Path.GetFileNameWithoutExtension(proj)
    sprintf "%s/%s/" basePath folderName

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
                OutputPath = Some definition.OutputPath }) project

let nugetPack (definition: ProjectDefinition) =
    for nuspec in definition.Path do
        NuGet.NuGetPack (fun opt ->
            { opt with
                WorkingDir = "templates"
                OutputPath = definition.OutputPath
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

Target.create "Restore" (fun _ ->
    Paket.restore id
    DotNet.restore id "Fabulous.sln"
)

Target.create "FormatBindings" (fun _ ->
    for binding in !! "tools/Generator/*.json" do
        File.ReadAllText binding
        |> JToken.Parse
        |> (fun token -> token.ToString(Formatting.Indented))
        |> (fun json -> File.WriteAllText(binding, json))
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

Target.create "BuildControls" (fun _ ->
    controls |> buildProject
)

Target.create "BuildTools" (fun _ ->
    tools |> buildProject
)

Target.create "RunGenerator" (fun _ ->
    DotNet.exec id (tools.OutputPath + "/Generator/Generator.dll") "tools/Generator/Xamarin.Forms.Core.json src/Fabulous.Core/Xamarin.Forms.Core.fs"
    |> (fun x ->
        match x.OK with
        | true -> ()
        | false -> failwith "The generator stopped due to an exception"
    )
)

Target.create "BuildFabulous" (fun _ -> 
    projects |> List.iter buildProject
)

Target.create "BuildSamples" (fun _ ->
    samples |> buildProject
)

Target.create "RunTests" (fun _ ->
    let testProjects = !! "tests/**/*.fsproj"
    for testProject in testProjects do
        DotNet.test (fun opt -> { opt with Logger = Some "trx"; ResultsDirectory = Some (buildDir + "/testresults") }) testProject
)

Target.create "RunSamplesTests" (fun _ ->
    let testProjects = !! "samples/**/*Tests.fsproj"
    for testProject in testProjects do
        DotNet.test id testProject
)

Target.create "TestTemplatesNuGet" (fun _ ->
    let restorePackageDotnetCli appName projectName projectExtension pkgs =
        DotNet.exec id "restore" (sprintf "%s/%s/%s.%s  --source https://api.nuget.org/v3/index.json --source %s" appName projectName projectName projectExtension pkgs) |> ignore

    let ticks = let now = System.DateTime.Now in now.Ticks // Prevents warning FS0052
    let testAppName = "testapp2" + string (abs (hash ticks) % 100)

    // Globally install the templates from the template nuget package we just built
    DotNet.exec id "new" (sprintf "-i %s/Fabulous.Templates.%s.nupkg" buildDir release.NugetVersion) |> ignore

    // Instantiate the template.
    Shell.cleanDir testAppName

    let extraArgs =
        if Environment.isWindows then " --WPF --UWP"
        elif Environment.isMacOS then " --macOS"
        elif Environment.isLinux then " --Android=false --iOS=false"
        else ""
        
    DotNet.exec id "new fabulous-app" (sprintf "-n %s -lang F# --GTK%s" testAppName extraArgs) |> ignore

    // The shared project and WPF need to be restored manually as they're using the new SDK-style format
    // When restoring, using the build_output as a package source to pick up the package we just compiled
    let pkgs = Path.GetFullPath(buildDir)
    restorePackageDotnetCli testAppName testAppName "fsproj" pkgs
    
    if Environment.isWindows then
        restorePackageDotnetCli testAppName (testAppName + ".WPF") "fsproj" pkgs
        restorePackageDotnetCli testAppName (testAppName + ".UWP") "csproj" pkgs

    // Build for all combinations
    for c in ["Debug"; "Release"] do 
        for p in ["Any CPU"; "iPhoneSimulator"] do
            let sln = sprintf "%s/%s.sln" testAppName testAppName
            let properties = [("RestorePackages", "True"); ("Platform", p); ("Configuration", c); ("PackageSources", sprintf "https://api.nuget.org/v3/index.json;%s" pkgs)]
            MSBuild.run id "" "Build" properties [sln] |> Trace.logItems ("Build-Output: ")
)

Target.create "Build" ignore
Target.create "Test" ignore

open Fake.Core.TargetOperators

"Clean"
  ==> "Restore"
  ==> "FormatBindings"
  ==> "UpdateVersion"
  ==> "BuildTools"
  ==> "BuildControls"
  ==> "RunGenerator"
  ==> "BuildFabulous"
  ==> "RunTests"
  ==> "Build"

"Build"
  ==> "TestTemplatesNuGet"
  ==> "BuildSamples"
  ==> "RunSamplesTests"
  ==> "Test"

Target.runOrDefault "Build"
