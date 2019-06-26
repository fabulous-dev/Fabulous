#r "paket: groupref fakebuild //"
#load "./.fake/build.fsx/intellisense.fsx"

open Fake.Api
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

let repositoryOwner = "fsprojects"
let repositoryName = "Fabulous"

let release = ReleaseNotes.load "RELEASE_NOTES.md"
let buildDir = Path.getFullName "./build_output"

let removeIncompatiblePlatformProjects pattern = 
    if Environment.isMacOS then
        pattern
        -- "**/*.WPF.fsproj"
        -- "**/*.UWP.fsproj"        
    elif Environment.isWindows then
        pattern
        -- "**/*.macOS.fsproj"
        -- "**/*.iOS.fsproj"
    else    
        pattern
        -- "**/*.macOS.fsproj"
        -- "**/*.iOS.fsproj"
        -- "**/*.WPF.fsproj"
        -- "**/*.UWP.fsproj"
        -- "**/*.Droid.fsproj"

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

// JavaSdkDirectory is a temporary fix for the Windows 2019 build agent
// It's currently failing to build Xamarin.Android : https://github.com/Microsoft/azure-pipelines-image-generation/blob/master/images/win/Vs2019-Server2019-Readme.md
let addJDK properties =
    match Environment.environVarOrDefault "JAVA_HOME_8_X64" "" with
    | javaHome when not (System.String.IsNullOrWhiteSpace javaHome && Environment.isWindows) -> ("JavaSdkDirectory", javaHome) :: properties
    | _ -> properties

let msbuildOld (buildType: BuildType) (definition: ProjectDefinition) =
    let configuration = match buildType with Debug -> "Debug" | Release -> "Release"
    let properties = [ ("Configuration", configuration) ] |> addJDK

    for project in definition.Path do
        let outputDir = getOutputDir definition.OutputPath project
        MSBuild.run id outputDir "Restore" properties [project] |> Trace.logItems (definition.Name + "Restore-Output: ")
        MSBuild.run id outputDir "Build" properties [project] |> Trace.logItems (definition.Name + "Build-Output: ")

let dotnetPackOld (definition: ProjectDefinition) =
    for project in definition.Path do
        DotNet.pack (fun opt ->
            { opt with
                Common = { opt.Common with CustomParams = Some "-p:IncludeSourceLink=True" }
                Configuration = DotNet.BuildConfiguration.Release
                OutputPath = Some definition.OutputPath }) project

let dotnetBuild projectPath outputPath =
    DotNet.build (fun opt ->
        { opt with
            Configuration = DotNet.BuildConfiguration.Release
            OutputPath = Some outputPath }) projectPath

let dotnetPack projectPath outputPath =
    DotNet.pack (fun opt ->
        { opt with
            Common = { opt.Common with CustomParams = Some "-p:IncludeSourceLink=True" }
            Configuration = DotNet.BuildConfiguration.Release
            OutputPath = Some outputPath }) projectPath

let dotnetTest projectPath outputPath =
    DotNet.test (fun opt ->
        { opt with
            Logger = Some "trx"
            ResultsDirectory = Some outputPath }) projectPath

let msbuild buildType projectPath outputPath =
    let projectName = Path.GetFileNameWithoutExtension projectPath
    let configuration = match buildType with Debug -> "Debug" | Release -> "Release"
    let properties = [ ("Configuration", configuration) ] |> addJDK
    MSBuild.run id outputPath "Build" properties [projectPath] |> Trace.logItems (projectName + "-Build-Output: ")

let nugetPack nuspecPath outputPath =
    NuGet.NuGetPack (fun opt ->
        { opt with
            WorkingDir = Path.GetDirectoryName nuspecPath
            OutputPath = outputPath
            Version = release.NugetVersion
            ReleaseNotes = (String.toLines release.Notes) }) nuspecPath 

let nugetPackOld (definition: ProjectDefinition) =
    for nuspec in definition.Path do
        NuGet.NuGetPack (fun opt ->
            { opt with
                WorkingDir = "templates"
                OutputPath = definition.OutputPath
                Version = release.NugetVersion
                ReleaseNotes = (String.toLines release.Notes) }) nuspec

let buildProject (definition: ProjectDefinition) =    
    match definition.Action with
    | MSBuild buildType -> msbuildOld buildType definition
    | DotNetPack -> dotnetPackOld definition
    | NuGetPack -> nugetPackOld definition

let composeOutputPath subDir projectPath =
    let projectName = Path.GetFileNameWithoutExtension projectPath
    sprintf "%s/%s/%s" buildDir subDir projectName


Target.create "Clean" (fun _ ->
    Shell.cleanDir buildDir
)

Target.create "Restore" (fun _ ->
    Paket.restore id
    DotNet.restore id "Fabulous.sln"
)

Target.create "FormatBindings" (fun _ ->
    let bindingFiles =
        !! "Fabulous.XamarinForms/Fabulous.XamarinForms.Controls/Xamarin.Forms.Core.fs"

    for file in bindingFiles do
        File.ReadAllText file
        |> JToken.Parse
        |> (fun token -> token.ToString(Formatting.Indented))
        |> (fun json -> File.WriteAllText(file, json))
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

Target.create "BuildTools" (fun _ ->
    for projectPath in !! "tools/**/*.fsproj" do
        let outputPath = composeOutputPath "tools" projectPath
        dotnetBuild projectPath outputPath
)

Target.create "BuildFabulous" (fun _ -> 
    for projectPath in !! "src/**/*.fsproj" do
        let outputPath = composeOutputPath "Fabulous" projectPath
        dotnetBuild projectPath outputPath
)

Target.create "RunFabulousTests" (fun _ ->
    for projectPath in !! "tests/**/*.fsproj" do
        let outputPath = composeOutputPath "Fabulous/TestResults" projectPath
        dotnetTest projectPath outputPath
)

Target.create "BuildFabulousXamarinForms" (fun _ -> 
    let projectPaths =
        !! "Fabulous.XamarinForms/src/**/*.fsproj"
        -- "Fabulous.XamarinForms/Fabulous.XamarinForms.Controls/*.fsproj" // This one needs to run the generator beforehand

    for projectPath in projectPaths do
        let outputPath = composeOutputPath "Fabulous.XamarinForms" projectPath
        dotnetBuild projectPath outputPath
)

Target.create "RunGeneratorForFabulousXamarinForms" (fun _ ->
    DotNet.exec id (buildDir + "/tools/Generator/Generator.dll") "Fabulous.XamarinForms/src/Fabulous.XamarinForms.Controls/Xamarin.Forms.Core.json Fabulous.XamarinForms/src/Fabulous.XamarinForms.Controls/Xamarin.Forms.Core.fs"
    |> (fun x ->
        match x.OK with
        | true -> ()
        | false -> failwith "The generator stopped due to an exception"
    )
)

Target.create "BuildFabulousXamarinFormsControls" (fun _ -> 
    let projectPath = "Fabulous.XamarinForms/src/Fabulous.XamarinForms.Controls/Fabulous.XamarinForms.Controls.fsproj"
    let outputPath = composeOutputPath "Fabulous.XamarinForms" projectPath
    dotnetBuild projectPath outputPath
)

Target.create "RunFabulousXamarinFormsTests" (fun _ ->
    for projectPath in !! "tests/**/*.fsproj" do
        let outputPath = composeOutputPath "Fabulous/TestResults" projectPath
        dotnetTest projectPath outputPath
)

Target.create "BuildFabulousXamarinFormsExtensions" (fun _ ->
    for projectPath in !! "Fabulous.XamarinForms/extensions/**/*.fsproj" do
        let outputPath = composeOutputPath "Fabulous.XamarinForms/Extensions" projectPath
        dotnetBuild projectPath outputPath
)

Target.create "BuildFabulousStaticView" (fun _ ->
    for projectPath in !! "Fabulous.StaticView/src/**/*.fsproj" do
        let outputPath = composeOutputPath "Fabulous.StaticView" projectPath
        dotnetBuild projectPath outputPath
)

Target.create "PackFabulous" (fun _ -> 
    for projectPath in !! "src/**/*.fsproj" do
        dotnetPack projectPath buildDir
)

Target.create "PackFabulousXamarinForms" (fun _ -> 
    for projectPath in !! "Fabulous.XamarinForms/src/**/*.fsproj" do
        dotnetPack projectPath buildDir
)

Target.create "PackFabulousXamarinFormsTemplates" (fun _ -> 
    for nuspecPath in !! "Fabulous.XamarinForms/templates/*.nuspec" do
        nugetPack nuspecPath buildDir
)

Target.create "PackFabulousXamarinFormsExtensions" (fun _ -> 
    for projectPath in !! "Fabulous.XamarinForms/extensions/**/*.fsproj" do
        dotnetPack projectPath buildDir
)

Target.create "PackFabulousStaticView" (fun _ -> 
    for projectPath in !! "Fabulous.StaticView/src/**/*.fsproj" do
        dotnetPack projectPath buildDir
)

Target.create "BuildFabulousXamarinFormsSamples" (fun _ ->
    let samples = (!! "Fabulous.XamarinForms/samples/**/*.fsproj" |> removeIncompatiblePlatformProjects)
    for projectPath in samples do
        let outputPath = composeOutputPath "Fabulous.XamarinForms/samples" projectPath
        msbuild Release projectPath outputPath
)

Target.create "RunFabulousXamarinFormsSamplesTests" (fun _ ->
    for projectPath in !! "Fabulous.XamarinForms/samples/**/*.Tests.fsproj" do
        let outputPath = composeOutputPath "Fabulous.XamarinForms/TestResults" projectPath
        dotnetTest projectPath outputPath
)

Target.create "BuildFabulousStaticViewSamples" (fun _ ->
    let samples = (!! "Fabulous.StaticView/samples/**/*.fsproj" |> removeIncompatiblePlatformProjects)
    for projectPath in samples do
        let outputPath = composeOutputPath "Fabulous.XamarinForms/samples" projectPath
        msbuild Release projectPath outputPath
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
            let properties = [("RestorePackages", "True"); ("Platform", p); ("Configuration", c); ("PackageSources", sprintf "https://api.nuget.org/v3/index.json;%s" pkgs)] |> addJDK
            MSBuild.run id "" "Build" properties [sln] |> Trace.logItems ("Build-Output: ")
)

Target.create "Release" (fun _ ->
    let token =
        match Environment.environVarOrDefault "github_token" "" with
        | s when not (System.String.IsNullOrWhiteSpace s) -> s
        | _ -> failwith "Please set the github_token environment variable to a github personal access token with repo access."

    let nugetApiKey =
        match Environment.environVarOrDefault "nuget_apikey" "" with
        | s when not (System.String.IsNullOrWhiteSpace s) -> s
        | _ -> failwith "Please set the nuget_apikey environment variable to a NuGet API key with write access to the Fabulous packages."

    GitHub.createClientWithToken token
    |> GitHub.draftNewRelease repositoryOwner repositoryName release.AssemblyVersion false (release.Notes |> List.map (sprintf "- %s"))
    |> GitHub.uploadFiles !!(buildDir + "/*.nupkg")
    |> GitHub.publishDraft
    |> Async.RunSynchronously

    for nupkg in !! (buildDir + "/*.nupkg") do
        let fileName = System.IO.Path.GetFileNameWithoutExtension(nupkg)
        let projectName = fileName.Remove(fileName.LastIndexOf('.'))
        let projectName = projectName.Remove(projectName.LastIndexOf('.'))
        let projectName = projectName.Remove(projectName.LastIndexOf('.'))

        NuGet.NuGetPublish (fun p ->
            { p with AccessKey = nugetApiKey
                     PublishUrl = "https://www.nuget.org"
                     Project = projectName
                     Version = release.NugetVersion
                     WorkingDir = buildDir
                     OutputPath = buildDir }
        )
)

Target.create "Prepare" ignore
Target.create "Fabulous" ignore
Target.create "Fabulous.XamarinForms" ignore
Target.create "Fabulous.XamarinForms.Extensions" ignore
Target.create "Fabulous.StaticView" ignore
Target.create "Build" ignore
Target.create "Pack" ignore
Target.create "TestSamples" ignore
Target.create "Test" ignore

open Fake.Core.TargetOperators

"Clean"
    ==> "Restore"
    ==> "FormatBindings"
    ==> "UpdateVersion"
    ==> "BuildTools"
    ==> "Prepare"

"Prepare"
    ==> "BuildFabulous"
    ==> "RunFabulousTests"
    ==> "Fabulous"

"Fabulous"
    ==> "BuildFabulousXamarinForms"
    ==> "RunGeneratorForFabulousXamarinForms"
    ==> "BuildFabulousXamarinFormsControls"
    ==> "RunFabulousXamarinFormsTests"
    ==> "Fabulous.XamarinForms"

"Fabulous.XamarinForms"
    ==> "BuildFabulousXamarinFormsExtensions"
    ==> "Fabulous.XamarinForms.Extensions"

"Fabulous"
    ==> "BuildFabulousStaticView"
    ==> "Fabulous.StaticView"

"Build"
    <== [ "Fabulous"; "Fabulous.XamarinForms"; "Fabulous.XamarinForms.Extensions"; "Fabulous.StaticView"]

"Build"
    ==> "PackFabulous"
    ==> "PackFabulousXamarinForms"
    ==> "PackFabulousXamarinFormsTemplates"
    ==> "PackFabulousXamarinFormsExtensions"
    ==> "PackFabulousStaticView"
    ==> "Pack"

"Build"
    ==> "BuildFabulousXamarinFormsSamples"
    ==> "RunFabulousXamarinFormsSamplesTests"
    ==> "BuildFabulousStaticViewSamples"
    ==> "TestSamples"

"Pack"
    ==> "TestTemplatesNuGet"

"Test"
    <== [ "TestSamples"; "TestTemplatesNuGet" ]

"Test"
    ==> "Release"

Target.runOrDefault "Test"
