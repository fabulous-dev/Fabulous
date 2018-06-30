// include Fake lib
#I "packages/FAKE/tools"
#r "packages/FAKE/tools/FakeLib.dll"
open Fake
open System
open System.IO
open Fake.AssemblyInfoFile
open Fake.Git
open Fake.ReleaseNotesHelper

let buildDir = "./build_output"
let release = LoadReleaseNotes "RELEASE_NOTES.md"

let project = "Elmish.XamarinForms"
let summary = "F# bindings for using elmish in WPF"

Target "Build" (fun _ ->

    // needed or else 'project.assets.json' not found'
    DotNetCli.Restore (fun p -> { p with Project = "Elmish.XamarinForms/Elmish.XamarinForms.fsproj" })

    !! "Elmish.XamarinForms/Elmish.XamarinForms.fsproj"
       |> MSBuildRelease buildDir "Restore"
       |> Log "LibraryRestore-Output: "

    !! "Elmish.XamarinForms/Elmish.XamarinForms.fsproj"
       |> MSBuildRelease buildDir "Build"
       |> Log "LibraryBuild-Output: "
)

Target "BuildSamples" (fun _ ->

    // needed or else 'project.assets.json' not found'
    DotNetCli.Restore (fun p -> { p with Project = "Elmish.XamarinForms.sln" })

    // restore the apps debug
    !! "Elmish.XamarinForms.sln"
          |> MSBuildDebug null "Restore"
          |> Log "SamplesRestoreDebug-Output: "

    // build the apps debug
    !! "Elmish.XamarinForms.sln"
          |> MSBuildDebug null "Build"
          |> Log "SamplesBuildDebug-Output: "

)

Target "Clean" (fun _ ->
    CleanDir buildDir
)

// Generate assembly info files with the right version & up-to-date information
Target "AssemblyInfo" (fun _ ->
    let getAssemblyInfoAttributes projectName =
        [ Attribute.Title (projectName)
          Attribute.Product project
          Attribute.Description summary
          Attribute.Version release.AssemblyVersion
          Attribute.FileVersion release.AssemblyVersion ]

    let getProjectDetails projectPath =
        let projectName = System.IO.Path.GetFileNameWithoutExtension(projectPath)
        ( projectPath, 
          projectName,
          System.IO.Path.GetDirectoryName(projectPath),
          (getAssemblyInfoAttributes projectName)
        )

    !! "*/*.??proj"
    |> Seq.map getProjectDetails
    |> Seq.iter (fun (projFileName, projectName, folderName, attributes) ->
        match projFileName with
        | Fsproj -> CreateFSharpAssemblyInfo (folderName @@ "AssemblyInfo.fs") attributes
        | _ -> ()
        )
)

// Build a NuGet package
Target "LibraryNuGet" (fun _ ->
    Paket.Pack(fun p -> 
        { p with
            OutputPath = buildDir + "/"
            TemplateFile = "paket.template"
            Version = release.NugetVersion
            ReleaseNotes = toLines release.Notes})

)
// Build a NuGet package
Target "TemplatesNuGet" (fun _ ->

    // turn on macOS
    

    // build for VS for Mac
    NuGetHelper.NuGetPack (fun p -> 
        { p with
            WorkingDir = "templates"
            OutputPath = buildDir + "/"
            Version = release.NugetVersion
            ReleaseNotes = toLines release.Notes}) @"templates/Elmish.XamarinForms.Templates.nuspec"

    // Copy the versioned one to the VS for Mac add-in
    let package = Directory.GetFiles((buildDir + "/"), "Elmish.XamarinForms.Templates.*.nupkg")
                    |> Array.head
    File.Copy(package, @"./VSMacAddIn/Elmish.XamarinForms.Templates.nupkg", true)

    // turn off macOS

    // Build for dotnet new
    NuGetHelper.NuGetPack (fun p -> 
        { p with
            WorkingDir = "templates"
            OutputPath = buildDir + "/"
            Version = release.NugetVersion
            ReleaseNotes = toLines release.Notes}) @"templates/Elmish.XamarinForms.Templates.nuspec"
)
let exec exe args =
    let code = Shell.Exec(exe, args) 
    if code <> 0 then failwithf "%s %s failed, error code %d" exe args code

Target "TestTemplatesNuGet" (fun _ ->

    // Globally install the templates from the template nuget package we just built
    DotNetCli.RunCommand id ("new -i " + buildDir + "/Elmish.XamarinForms.Templates." + release.NugetVersion + ".nupkg")

    let testAppName = "testapp" + string (abs (hash System.DateTime.Now.Ticks) % 100)
    // Instantiate the template. TODO: additional parameters and variations
    CleanDir testAppName
    DotNetCli.RunCommand id (sprintf "new elmish-forms-app -n %s -lang F#" testAppName)

    let pkgs = System.IO.Path.GetFullPath(buildDir)
    // When restoring, using the build_output as a package source to pick up the package we just compiled
    DotNetCli.RunCommand id (sprintf "restore %s/%s/%s.fsproj  --source https://api.nuget.org/v3/index.json --source %s" testAppName testAppName testAppName pkgs)
    
    let slash = if isUnix then "\\" else ""
    for c in ["Debug"; "Release"] do 
        for p in ["Any CPU"; "iPhoneSimulator"] do 
            exec "msbuild" (sprintf "%s/%s.sln /p:Platform=\"%s\" /p:Configuration=%s /p:PackageSources=%s\"https://api.nuget.org/v3/index.json%s;%s%s\"" testAppName testAppName p c  slash slash pkgs slash)

    (* Manual steps without building nupkg
        .\build LibraryNuGet
        dotnet new -i  templates
        rmdir /s /q testapp
        dotnet new elmish-forms-app -n testapp -lang F#
        dotnet restore testapp/testapp/testapp.fsproj -s build_output/
        dotnet new -i  templates && rmdir /s /q testapp && dotnet new elmish-forms-app -n testapp -lang F# && dotnet restore testapp/testapp/testapp.fsproj && msbuild testapp/testapp.Android/testapp.Android.fsproj /t:RestorePackages && msbuild testapp/testapp.Android/testapp.Android.fsproj
        dotnet new -i  templates && rmdir /s /q testapp && dotnet new elmish-forms-app -n testapp -lang F# && dotnet restore testapp/testapp/testapp.fsproj && msbuild testapp/testapp.iOS/testapp.iOS.fsproj /t:RestorePackages  && msbuild testapp/testapp.iOS/testapp.iOS.fsproj
        dotnet new -i  templates && rmdir /s /q testapp && dotnet new elmish-forms-app -n testapp -lang F# --CreateMacProject && dotnet restore testapp/testapp/testapp.fsproj && msbuild testapp/testapp.macOS/testapp.macOS.fsproj /t:RestorePackages  && msbuild testapp/testapp.macOS/testapp.macOS.fsproj
        *)

)


Target "PublishNuGets" (fun _ ->
    Paket.Push(fun p -> 
        { p with
            WorkingDir = buildDir })
)

Target "NuGet" DoNothing
Target "Test" DoNothing

"Clean"
  ==> "AssemblyInfo"
  ==> "Build"
  ==> "LibraryNuGet" 
  ==> "TemplatesNuGet" 
  ==> "NuGet"

"Build"
  ==> "BuildSamples"
  ==> "Test"

"NuGet" 
  ==> "TestTemplatesNuGet"
  ==> "Test"
  ==> "PublishNuGets"


// start build
RunTargetOrDefault "Build"
