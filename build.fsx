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

let repositoryOwner = "fsprojects"
let repositoryName = "Fabulous"
let release = ReleaseNotes.load "RELEASE_NOTES.md"
let buildDir = Path.getFullName "./build_output"

let composeOutputPath subDir projectPath =
    let projectName = Path.GetFileNameWithoutExtension projectPath
    sprintf "%s/%s/%s" buildDir subDir projectName

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

// JavaSdkDirectory is a temporary fix for the Windows 2019 build agent
// It's currently failing to build Xamarin.Android : https://github.com/Microsoft/azure-pipelines-image-generation/blob/master/images/win/Vs2019-Server2019-Readme.md
let addJDK properties =
    match Environment.environVarOrDefault "JAVA_HOME_8_X64" "" with
    | javaHome when not (System.String.IsNullOrWhiteSpace javaHome && Environment.isWindows) -> ("JavaSdkDirectory", javaHome) :: properties
    | _ -> properties

let dotnetBuild paths =
    for projectPath in paths do
        DotNet.build (fun opt ->
            { opt with
                Configuration = DotNet.BuildConfiguration.Release }) projectPath

let computeBounds (semVer: SemVerInfo) =
    match semVer.PreRelease with
    | Some _ ->
        sprintf "[%s]" semVer.AsString
    | None when semVer.Major = 0u ->
        sprintf "[0.%i%%2C0.%i)" semVer.Minor (semVer.Minor + 1u)
    | None ->
        sprintf "[%i.0%%2C%i.0)" semVer.Major (semVer.Major + 1u)

let dotnetPack paths =
    for projectPath in paths do
        let args =
            sprintf "-p:IncludeSourceLink=True -p:IsPacking=true -p:VersionBounds=\"%s\" -p:RestoreAdditionalProjectSources=\"%s\""
                (computeBounds release.SemVer)
                (Path.GetFullPath(buildDir))

        DotNet.pack (fun opt ->
            { opt with
                Common = { opt.Common with CustomParams = Some args }
                Configuration = DotNet.BuildConfiguration.Release
                OutputPath = Some buildDir }) projectPath

let dotnetTest outputSubDir paths =
    for projectPath in paths do
        let outputPath = composeOutputPath outputSubDir projectPath
        DotNet.test (fun opt ->
            { opt with
                Logger = Some "trx"
                ResultsDirectory = Some outputPath }) projectPath

let msbuild paths =
    for projectPath in paths do
        let projectName = Path.GetFileNameWithoutExtension projectPath
        let properties = [ ("Configuration", "Release") ] |> addJDK
        MSBuild.run id "" "Build" properties [projectPath] |> Trace.logItems (projectName + "-Build-Output: ")

let nugetPack paths =
    for nuspecPath in paths do
        NuGet.NuGetPack (fun opt ->
            { opt with
                WorkingDir = Path.GetDirectoryName nuspecPath
                OutputPath = buildDir
                Version = release.NugetVersion
                ReleaseNotes = (String.toLines release.Notes) }) nuspecPath

/// Replaces the value of attribute in an xml node in the XML document specified by a XPath expression.
let replaceXPathAttributeNSIfExists xpath (attribute:string) value (namespaces : #seq<string * string>) (doc : System.Xml.XmlDocument) =
    let nsmgr = System.Xml.XmlNamespaceManager(doc.NameTable)
    namespaces |> Seq.iter nsmgr.AddNamespace
    let node = doc.SelectSingleNode(xpath, nsmgr)
    if not (isNull node) then
        let attributeValue = node.Attributes.[attribute]
        if not (isNull attributeValue) then
            attributeValue.Value <- value
    doc

Target.create "Clean" (fun _ ->
    Shell.cleanDir buildDir
)

Target.create "Restore" (fun _ ->
    // Restore all projects (except templates) compatible with the current platform
    !! "**/*.fsproj" ++ "**/*.csproj"
    -- "**/templates/**/*.fsproj" -- "**/templates/**/*.csproj"
    |> removeIncompatiblePlatformProjects
    |> (fun projects ->
        for project in projects do
            DotNet.restore id project
    )
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
    let templates = !! "**/templates/**/.template.config/template.json"
    for template in templates do
        File.readAsString template
        |> JObject.Parse
        |> (fun o ->
            let prop = o.["name"] :?> JValue
            let name =
                let currentValue = prop.Value.ToString()
                let realName = currentValue.Remove(currentValue.LastIndexOf(" "))
                sprintf "%s v%s" realName release.NugetVersion
            prop.Value <- name
            o
        )
        |> (fun o -> 
            let prop = o.["symbols"].["FabulousPkgsVersion"].["defaultValue"] :?> JValue
            prop.Value <- release.NugetVersion
            o
        )
        |> (fun o -> JsonConvert.SerializeObject(o, Formatting.Indented))
        |> File.writeString false template
)

Target.create "BuildTools" (fun _ ->
    !! "tools/**/*.fsproj"
    |> dotnetBuild
)

Target.create "BuildFabulous" (fun _ -> 
    !! "src/**/*.fsproj"
    |> dotnetBuild
)

Target.create "RunFabulousTests" (fun _ ->
    !! "tests/**/*.fsproj"
    |> dotnetTest "Fabulous/TestResults"
)

Target.create "BuildFabulousCodeGen" (fun _ -> 
    !! "Fabulous.CodeGen/src/**/*.fsproj"
    |> dotnetBuild
)

Target.create "RunFabulousCodeGenTests" (fun _ ->
    !! "Fabulous.CodeGen/tests/**/*.fsproj"
    |> dotnetTest "Fabulous.CodeGen/TestResults"
)

Target.create "BuildFabulousXamarinFormsTools" (fun _ ->
    !! "Fabulous.XamarinForms/tools/**/*.fsproj"
    |> dotnetBuild
)

Target.create "BuildFabulousXamarinFormsDependencies" (fun _ ->
    !! "Fabulous.XamarinForms/src/**/*.fsproj"
    -- "Fabulous.XamarinForms/src/Fabulous.XamarinForms/Fabulous.XamarinForms.fsproj" // This one needs to run the generator beforehand
    |> dotnetBuild
)

Target.create "RunGeneratorForFabulousXamarinForms" (fun _ ->
    let generatorPath = "Fabulous.XamarinForms/tools/Fabulous.XamarinForms.Generator/bin/Release/netcoreapp3.1/Fabulous.XamarinForms.Generator.dll"
    let mappingFilePath = "Fabulous.XamarinForms/src/Fabulous.XamarinForms/Xamarin.Forms.Core.json"
    let attributesOutputFilePath = "Fabulous.XamarinForms/src/Fabulous.XamarinForms/Xamarin.Forms.Core.Attributes.fs"
    let buildersOutputFilePath = "Fabulous.XamarinForms/src/Fabulous.XamarinForms/Xamarin.Forms.Core.fs"

    DotNet.exec id generatorPath (sprintf "-m %s -a %s -b %s" mappingFilePath attributesOutputFilePath buildersOutputFilePath)
    |> (fun x ->
        match x.OK with
        | true -> ()
        | false -> failwith "The generator stopped due to an exception"
    )
)

Target.create "BuildFabulousXamarinForms" (fun _ -> 
    !! "Fabulous.XamarinForms/src/Fabulous.XamarinForms/Fabulous.XamarinForms.fsproj"
    |> dotnetBuild
)

Target.create "RunFabulousXamarinFormsTests" (fun _ ->
    !! "Fabulous.XamarinForms/tests/**/*.fsproj"
    |> dotnetTest "Fabulous.XamarinForms/TestResults"
)

Target.create "RunGeneratorForFabulousXamarinFormsExtensions" (fun _ ->
    let generatorPath = "Fabulous.XamarinForms/tools/Fabulous.XamarinForms.Generator/bin/Release/netcoreapp3.1/Fabulous.XamarinForms.Generator.dll"

    let files =
        !! "Fabulous.XamarinForms/extensions/**/*.json"
        -- "Fabulous.XamarinForms/extensions/**/obj/*.json"
    
    for mappingFile in files do
        let attributesOutputFile = mappingFile.Replace(".json", ".Attributes.fs")
        let buildersOutputFile = mappingFile.Replace(".json", ".fs")

        DotNet.exec id generatorPath (sprintf "-m %s -a %s -b %s" mappingFile attributesOutputFile buildersOutputFile)
        |> (fun x ->
            match x.OK with
            | true -> ()
            | false -> failwith "The generator stopped due to an exception"
        )
)

Target.create "BuildFabulousXamarinFormsExtensions" (fun _ ->
    !! "Fabulous.XamarinForms/extensions/**/*.fsproj"
    |> dotnetBuild
)

Target.create "BuildFabulousStaticView" (fun _ ->
    !! "Fabulous.StaticView/src/**/*.fsproj"
    |> dotnetBuild
)

Target.create "PackFabulous" (fun _ -> 
    // Pack Fabulous first since it is used by other packages
    !! "src/Fabulous/Fabulous.fsproj"
    |> dotnetPack

    !! "src/**/*.fsproj"
    -- "src/Fabulous/Fabulous.fsproj"
    |> dotnetPack
)

Target.create "PackFabulousCodeGen" (fun _ -> 
    !! "Fabulous.CodeGen/src/**/*.fsproj"
    |> dotnetPack
)

Target.create "PackFabulousStaticView" (fun _ -> 
    !! "Fabulous.StaticView/src/**/*.fsproj"
    |> dotnetPack
)

Target.create "PackFabulousXamarinForms" (fun _ -> 
    !! "Fabulous.XamarinForms/src/Fabulous.XamarinForms/*.fsproj"
    |> dotnetPack

    !! "Fabulous.XamarinForms/src/Fabulous.XamarinForms.LiveUpdate/*.fsproj"
    |> dotnetPack
)

Target.create "PackFabulousXamarinFormsTemplates" (fun _ -> 
    !! "Fabulous.XamarinForms/templates/*.nuspec"
    |> nugetPack
)

Target.create "PackFabulousXamarinFormsExtensions" (fun _ -> 
    !! "Fabulous.XamarinForms/extensions/**/*.fsproj"
    |> dotnetPack
)

Target.create "BuildFabulousXamarinFormsSamples" (fun _ ->
    !! "Fabulous.XamarinForms/samples/**/*.fsproj"
    |> removeIncompatiblePlatformProjects
    |> msbuild
)

Target.create "RunFabulousXamarinFormsSamplesTests" (fun _ ->
    !! "Fabulous.XamarinForms/samples/**/*.Tests.fsproj"
    |> dotnetTest "Fabulous.XamarinForms/samples/TestResults"
)

Target.create "BuildFabulousStaticViewSamples" (fun _ ->
    !! "Fabulous.StaticView/samples/**/*.fsproj"
    |> removeIncompatiblePlatformProjects
    |> msbuild
)

Target.create "TestTemplatesNuGet" (fun _ ->
    let ticks = let now = System.DateTime.Now in now.Ticks // Prevents warning FS0052
    let testAppName = "testapp2" + string (abs (hash ticks) % 100)

    // Globally install the templates from the template nuget package we just built
    DotNet.exec id "new" "-u Fabulous.XamarinForms.Templates" |> ignore
    DotNet.exec id "new" (sprintf "-i %s/Fabulous.XamarinForms.Templates.%s.nupkg" buildDir release.NugetVersion) |> ignore

    // Instantiate the template.
    Shell.cleanDir testAppName

    let extraArgs =
        if Environment.isWindows then " --WPF --UWP"
        elif Environment.isMacOS then " --macOS"
        elif Environment.isLinux then " --Android=false --iOS=false"
        else ""
        
    DotNet.exec id "new fabulous-xf-app" (sprintf "-n %s -lang F# --allow-scripts yes --GTK%s" testAppName extraArgs) |> ignore

    // Restore NuGet packages
    let pkgs = Path.GetFullPath(buildDir)
    let sln = sprintf "%s/%s.sln" testAppName testAppName
    let args = sprintf "restore %s -source https://api.nuget.org/v3/index.json -source %s" sln pkgs
    if Environment.isWindows then
        Shell.Exec(".\\.nuget\\NuGet.exe", args) |> ignore
    else 
        Shell.Exec("mono", sprintf ".nuget/NuGet.exe %s" args) |> ignore
    
    // Build for all combinations
    for c in ["Debug"; "Release"] do 
        for p in ["Any CPU"; "iPhoneSimulator"] do
            let properties = [("Platform", p); ("Configuration", c)] |> addJDK
            MSBuild.run id "" "Build" properties [sln] |> Trace.logItems ("Build-Output: ")
)

Target.create "CreateGitHubRelease" (fun _ ->
    let token =
        match Environment.environVarOrDefault "GITHUB_TOKEN" "" with
        | s when not (System.String.IsNullOrWhiteSpace s) -> s
        | _ -> failwith "Please set the GITHUB_TOKEN environment variable to a github personal access token with repo access."
        
    try
        GitHub.createClientWithToken token
        |> GitHub.draftNewRelease repositoryOwner repositoryName release.NugetVersion release.SemVer.PreRelease.IsSome (release.Notes |> List.map (sprintf "- %s"))
        // |> GitHub.uploadFiles !!(buildDir + "/*.nupkg") // Randomly failing to upload for some reasons...
        |> GitHub.publishDraft
        |> Async.RunSynchronously
    with
    | ex -> printfn "GitHub release skipped. Reason: %A" ex
)

Target.create "PublishNuGetPackages" (fun _ ->
    let nugetApiKey =
        match Environment.environVarOrDefault "NUGET_APIKEY" "" with
        | s when not (System.String.IsNullOrWhiteSpace s) -> s
        | _ -> failwith "Please set the NUGET_APIKEY environment variable to a NuGet API key with write access to the Fabulous packages."

    // dotnet publishes both nupkg and snupkg by default
    let path = System.IO.Path.Combine(buildDir, "*.nupkg")
    DotNet.exec id "nuget" (sprintf "push %s -k %s --skip-duplicate -s https://api.nuget.org/v3/index.json" path nugetApiKey) |> ignore
)

Target.create "Prepare" ignore
Target.create "Fabulous" ignore
Target.create "Fabulous.CodeGen" ignore
Target.create "Fabulous.StaticView" ignore
Target.create "StartFabulousXamarinForms" ignore
Target.create "Fabulous.XamarinForms" ignore
Target.create "Fabulous.XamarinForms.Extensions" ignore
Target.create "Build" ignore
Target.create "Pack" ignore
Target.create "TestSamples" ignore
Target.create "Test" ignore
Target.create "Release" ignore

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
    ==> "StartFabulousXamarinForms"

"Prepare"
    ==> "BuildFabulousCodeGen"
    ==> "RunFabulousCodeGenTests"
    ==> "Fabulous.CodeGen"
    ==> "StartFabulousXamarinForms"

"Prepare"
    ==> "BuildFabulousStaticView"
    ==> "Fabulous.StaticView"
    ==> "Build"

"StartFabulousXamarinForms"
    ==> "BuildFabulousXamarinFormsTools"
    ==> "BuildFabulousXamarinFormsDependencies"
    ==> "RunGeneratorForFabulousXamarinForms"
    ==> "BuildFabulousXamarinForms"
    ==> "RunFabulousXamarinFormsTests"
    ==> "Fabulous.XamarinForms"

"Fabulous.XamarinForms"
    ==> "RunGeneratorForFabulousXamarinFormsExtensions"
    ==> "BuildFabulousXamarinFormsExtensions"
    ==> "Fabulous.XamarinForms.Extensions"
    ==> "Build"

"Build"
    ==> "PackFabulous"
    ==> "PackFabulousCodeGen"
    ==> "PackFabulousStaticView"
    ==> "PackFabulousXamarinForms"
    ==> "PackFabulousXamarinFormsTemplates"
    ==> "PackFabulousXamarinFormsExtensions"
    ==> "Pack"

"Build"
    ==> "BuildFabulousXamarinFormsSamples"
    ==> "RunFabulousXamarinFormsSamplesTests"
    ==> "BuildFabulousStaticViewSamples"
    ==> "TestSamples"
    ==> "Test"

"Pack"
    ==> "TestTemplatesNuGet"
    ==> "Test"

"Test"
    ==> "CreateGitHubRelease"
    ==> "PublishNuGetPackages"
    ==> "Release"

Target.runOrDefault "Build"