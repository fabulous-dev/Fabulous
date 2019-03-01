#r "paket:
nuget Fake.Core.ReleaseNotes
nuget Fake.Core.Target
nuget Fake.Core.Xml
nuget Fake.DotNet.Cli
nuget Fake.DotNet.MSBuild
nuget Fake.Dotnet.NuGet
nuget Fake.DotNet.Paket
nuget Fake.IO.FileSystem
nuget Newtonsoft.Json //"
#load "./.fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.DotNet
open Fake.DotNet.NuGet
open Fake.IO
open Fake.IO.Globbing.Operators
open System.IO
open Newtonsoft.Json
open Newtonsoft.Json.Linq

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

Target.create "Clean" (fun _ ->
    Shell.cleanDir buildDir
)

Target.create "Restore" (fun _ ->
    Paket.restore id
    DotNet.restore id "Fabulous.sln"
)

Target.create "FormatBindings" (fun _ ->
    for binding in !! "tools/Generator/*.json" do
        File.readAsString binding
        |> JToken.Parse
        |> (fun token -> token.ToString(Formatting.Indented))
        |> File.writeString false binding
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
    let toolProjects = !!"tools/**/*.fsproj"
    for tool in toolProjects do
        DotNet.build id tool
)

Target.create "BuildControls" (fun _ ->
    DotNet.build id "src/Fabulous.CustomControls/Fabulous.CustomControls.fsproj"
)

Target.create "RunGenerator" (fun _ ->
    let result = DotNet.exec id "tools/Generator/bin/Release/netcoreapp2.1/Generator.dll" " tools/Generator/Xamarin.Forms.Core.json src/Fabulous.Core/Xamarin.Forms.Core.fs"
    match result.OK with
    | true -> ()
    | false -> failwith "The generator stopped due to an exception"
)

Target.create "BuildFabulous" (fun _ ->
    let projects = !!"src/**/*.fsproj"
                   -- "src/Fabulous.CustomControls/Fabulous.CustomControls.fsproj"

    for project in projects do
        DotNet.build id project
)

Target.create "BuildExtensions" (fun _ ->
    let extensionsProjects = !!"extensions/**/*.fsproj"
    for project in extensionsProjects do
        DotNet.build id project
)

Target.create "RunTests" (fun _ ->
    let testProjects = !! "tests/**/*.fsproj"
    for testProject in testProjects do
        DotNet.test id testProject
)

Target.create "BuildSamples" (fun _ ->
    let properties = [ ("Configuration", "Release") ] 

    let samples = !! "samples/**/*.fsproj" |> removeIncompatiblePlatformProjects
    for sample in samples do
        let projectName = Path.GetFileNameWithoutExtension(sample)
        let outputDir = Path.Combine(buildDir, "templates", projectName)
        MSBuild.run id outputDir "Restore" properties [sample] |> Trace.logItems (projectName + "Restore-Output: ")
        MSBuild.run id outputDir "Build" properties [sample] |> Trace.logItems (projectName + "Build-Output: ")
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
        
    DotNet.exec id "new fabulous-app" (sprintf "-n %s -lang F# --GTK %s" testAppName extraArgs) |> ignore

    // The shared project and WPF need to be restored manually as they're using the new SDK-style format
    // When restoring, using the build_output as a package source to pick up the package we just compiled
    let pkgs = Path.GetFullPath(buildDir)
    restorePackageDotnetCli testAppName testAppName "fsproj" pkgs
    
    if Environment.isWindows then
        restorePackageDotnetCli testAppName (testAppName + ".WPF") "fsproj" pkgs
        restorePackageDotnetCli testAppName (testAppName + ".UWP") "csproj" pkgs

    // Build for all combinations
    let slash = if Environment.isUnix then "\\" else ""
    for c in ["Debug"; "Release"] do 
        for p in ["Any CPU"; "iPhoneSimulator"] do
            let args = (sprintf "%s/%s.sln /p:Platform=\"%s\" /p:Configuration=%s /p:PackageSources=%s\"https://api.nuget.org/v3/index.json;%s%s\"" testAppName testAppName p c slash pkgs slash)
            let code = Shell.Exec("msbuild", args) 
            if code <> 0 then failwithf "%s %s failed, error code %d" "msbuild" args code
)

Target.create "PackFabulous" (fun _ ->
    let setParams (options: DotNet.PackOptions) =
        { options with
            Common = { options.Common with CustomParams = Some "-p:IncludeSourceLink=True" }
            Configuration = DotNet.BuildConfiguration.Release
            OutputPath = Some buildDir }

    let projects = !!"src/**/*.fsproj"
    for project in projects do
        DotNet.pack setParams project
)

Target.create "PackExtensions" (fun _ ->
    let setParams (options: DotNet.PackOptions) =
        { options with
            Common = { options.Common with CustomParams = Some "-p:IncludeSourceLink=True" }
            Configuration = DotNet.BuildConfiguration.Release
            OutputPath = Some buildDir }

    let projects = !!"extensions/**/*.fsproj"
    for project in projects do
        DotNet.pack setParams project
)

Target.create "PackTemplates" (fun _ ->
    let nuspecs = !!"templates/**/*.nuspec"
    for nuspec in nuspecs do
        NuGet.NuGetPack (fun opt ->
            { opt with
                WorkingDir = "templates"
                OutputPath = buildDir
                Version = release.NugetVersion
                ReleaseNotes = (String.toLines release.Notes) }) nuspec
)

Target.create "Prepare" ignore
Target.create "Main" ignore
Target.create "Samples" ignore
Target.create "Pack" ignore
Target.create "Full" ignore

open Fake.Core.TargetOperators

"FormatBindings"
  ==> "UpdateVersion"
  ==> "Prepare"

"Clean"
  ==> "Restore"
  ==> "Prepare"
  ==> "BuildTools"
  ==> "BuildControls"
  ==> "RunGenerator"
  ==> "BuildFabulous"
  ==> "BuildExtensions"
  ==> "RunTests"
  ==> "Main"

"Main"
  ==> "BuildSamples"
  ==> "RunSamplesTests"
  ==> "Samples"

"Samples"
  ==> "PackFabulous"
  ==> "PackExtensions"
  ==> "PackTemplates"
  ==> "Pack"

"Pack"
  ==> "TestTemplatesNuGet"
  ==> "Full"

Target.runOrDefault "Main"
